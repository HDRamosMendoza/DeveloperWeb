import React from "react";
import { IProduct } from "./../@types";
import { getProducts, deleteProduct } from "../service";
import { Table } from "./Table";

interface IProps{
    cambiarVistaProp:any;
    onEditClick: (id:number)=>void;
}

export const ListView: React.FC<IProps> = (props) => {
    const [listaProductos, setListaProductos] = React.useState<IProduct[]>([]);

    const cargarProductos = async () => {
        setListaProductos(await getProducts());
    }
    
    const onDelete= async(id:number)=>{
        // eliminar el producto
        const mensaje = await deleteProduct(id);
        console.log(`${mensaje}`);

        // volver a cargar la lista de productos
        cargarProductos();
    }

    React.useEffect(() => {
        cargarProductos();
    }, [])

    return (
        <div>
            <h1 className="title">Lista de Productos</h1>
            <h2 className="subtitle">Los productos registrados son</h2>
            <button className="button is-primary" onClick={()=>{props.cambiarVistaProp("insertar")}}>Crear nuevo Producto</button>           
            <Table data={listaProductos} title="Lista de Productos" onEditClick={props.onEditClick} onDeleteClick={onDelete}></Table>
        </div>
    )
}