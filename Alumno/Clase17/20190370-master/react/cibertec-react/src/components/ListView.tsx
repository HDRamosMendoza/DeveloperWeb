import React from "react";

export const ListView: React.FC = () => {
    const [contador, setContador] = React.useState(0);
    const [nombre,setNombre] = React.useState("ingresa nombre");

    const onInputNombreChange = (e:any)=>{
        const value = e.target.value;
        setNombre(value);
    }

    return (
        <div>
            <p>
                Listado de Productos
            </p>
            <p>
                Contador: {contador}
            </p>
            <button onClick={() => { setContador(contador + 1) }}>Incrementar Contador</button>
            <p>
                <input type="text" id="nombre" onChange={onInputNombreChange}/>
            </p>
            <p>
                Tu nombre es: {nombre}
            </p>
        </div>
    )
}