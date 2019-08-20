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
}

const THeader: React.FC<ITHeadProps> = (props) => {
    const listaCabeceras:any[] = [];
    // debugger
    // console.log("estos son los headers: ", props.headers);

    for(const header of props.headers) {
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



export const Table: React.FC<IProps> = (props) => {
    if(!props.data) {
        return <p>
            No hay data
        </p>
    }

    const listaHeaders = Object.entries(props.data[0]).map(
        ([a, v]) => {
            return a;
        }
    )

    return <table>
        <THeader headers={listaHeaders}></THeader>
    </table>
}