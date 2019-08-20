import React from "react";

interface IProps {
    title: string;
    data?:[];
}

export const Table: React.FC<IProps> = (props) => {
    return <p>
        Mi componente tabla {props.title}
    </p>
}