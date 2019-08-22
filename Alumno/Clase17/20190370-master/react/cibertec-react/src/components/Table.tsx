import React from "react";

interface IProps {
    title: string;
    data?: any[];
}

interface ITHeadProps {
    headers: string[];
}

interface ITBodyProps {
    data: any[];
    headers: string[];
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
        filas.push(
            <tr key={index}>
                {columnas}
            </tr>
        )
    }

    return <tbody>
        {filas}
    </tbody>
}

export const Table: React.FC<IProps> = (props) => {
    // si no hay data, mostrar un mensaje y salir de la función
    if (!props.data) {
        return <p>
            No hay data
        </p>
    }

    const listaHeaders = Object.entries(props.data[0]).map(([a, v]) => {
        return a;
    })
    return <table>
        <THeader headers={listaHeaders}></THeader>
        <TBody headers={listaHeaders} data={props.data}></TBody>
    </table>
}