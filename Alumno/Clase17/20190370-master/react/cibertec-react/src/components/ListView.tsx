import React from "react";
import { IProduct } from "../..@types";
import { getProducts } from "../service";

export const ListView: React.FC = () => {
    const [listaProductos, setListaProductos] = React.useState<IProduct>([]);

    const cargarProductos = async() => {
        setListaProductos(await getProducts());
    }

    React.useEffect(() => {
        cargarProductos();
    });

    return (
        <div>
            <Table data={listaProductos} title="Lista de Productos"></Table>
        </div>
    )
}