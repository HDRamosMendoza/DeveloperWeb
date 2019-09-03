import React from "react";

interface IProps {
    title: string;
    data?: any[];
    onEditClick: (id: number) => void;
    onDeleteClick: (id: number) => void;
}

interface ITHeadProps {
    headers: string[];
}

interface ITBodyProps {
    data: any[];
    headers: string[];
    onEditClick: (id: number) => void;
    onDeleteClick: (id: number) => void;
}

const THeader: React.FC<ITHeadProps> = (props) => {
    const listaCabeceras: any[] = [];
    // debugger;
    // console.log("estos son los headers: ",props.headers)
    for (const header of props.headers) {
        listaCabeceras.push(<th key={header}>
            {header}
        </th>)
    }
    return <thead>
        <tr>
            {listaCabeceras}
            <th></th>
        </tr>
    </thead>
}

const TBody: React.FC<ITBodyProps> = (props) => {
    const filas: any[] = [];
    for (let index = 0; index < props.data.length; index++) {
        const item = props.data[index];
        const columnas: any[] = [];
        for (const header of props.headers) {
            columnas.push(
                <td key={`${header}-${index}`}>
                    {item[header]}
                </td>
            )
        }
        const objectId = item["id"] || 0;
        filas.push(
            <tr key={index}>
                {columnas}
                <td>
                    <a href="#" onClick={() => { props.onEditClick(objectId as number) }}>Editar</a>
                    <a href="#" onClick={() => { props.onDeleteClick(objectId as number) }}>Eliminar</a>
                </td>
            </tr>
        )
    }

    return <tbody>
        {filas}
    </tbody>
}

export const Table: React.FC<IProps> = (props) => {
    // si no hay data, mostrar un mensaje y salir de la función
    if (!props.data || props.data.length <= 0) {
        return <p>
            No hay data
        </p>
    }

    const listaHeaders = Object.entries(props.data[0]).map(([a, v]) => {
        return a;
    })
    return <table className="table is-striped is-hoverable">
        <THeader headers={listaHeaders}></THeader>
        <TBody headers={listaHeaders} data={props.data} onEditClick={props.onEditClick} onDeleteClick={props.onDeleteClick}></TBody>
    </table>
}