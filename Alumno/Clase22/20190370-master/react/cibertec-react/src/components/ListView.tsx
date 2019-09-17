import React from "react";
import { IProduct } from "./../@types";
import { getProducts, deleteProduct } from "../service";
import { Table } from "./Table";
import * as SignalR from "@aspnet/signalr";

interface IProps {
    cambiarVistaProp: any;
    onEditClick: (id: number) => void;
}

export const ListView: React.FC<IProps> = (props) => {
    const [listaProductos, setListaProductos] = React.useState<IProduct[]>([]);

    const cargarProductos = async () => {
        setListaProductos(await getProducts());
    }

    const onDelete = async (id: number) => {
        // eliminar el producto
        const mensaje = await deleteProduct(id);
        console.log(`${mensaje}`);

        // volver a cargar la lista de productos
        cargarProductos();
    }

    React.useEffect(() => {
        cargarProductos();

        // configurar el hub
        // instanciar la conexión con el hub
        const newHubConnection = new SignalR.HubConnectionBuilder().withUrl("https://192.168.14.10:5001/productshub").build();

        // inicializar conexión
        newHubConnection.start().catch(error => console.error(error));

        // el código que se va a ejecutar cuando se reciba el evento de actualizar la lista
        newHubConnection.on("actualizarLista", function (product: IProduct) {
            console.log("Se actualizará la lista", product);            
            cargarProductos();
        })
    }, [])

    return (
        <div>
            <h1 className="title">Lista de Productos</h1>
            <h2 className="subtitle">Los productos registrados son</h2>
            <button className="button is-primary" onClick={() => { props.cambiarVistaProp("insertar") }}>Crear nuevo Producto</button>
            <Table data={listaProductos} title="Lista de Productos" onEditClick={props.onEditClick} onDeleteClick={onDelete}></Table>
        </div>
    )
}