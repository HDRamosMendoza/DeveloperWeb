import React from "react";
import { IProduct } from "../@types";
import { insertProduct } from "../service";

interface IProps {
    cambiarVistaProp: any;
}

export const InsertView: React.FC<IProps> = (props) => {
    const [newProduct, setNewProduct] = React.useState<IProduct>({
        id: 0,
        productName: "",
        supplierId: 0,
        unitPrice: 0,
        package: "",
        isDiscontinued: false,
    });

    const onInputChange = (e: React.ChangeEvent<HTMLInputElement>) => {
        const inputName = e.target.name;
        const inputValue = e.target.value;
        setNewProduct((prevData: IProduct) => ({ ...prevData, [inputName]: inputValue }));
    }

    const onHandleSubmit = async (e: React.FormEvent) => {
        e.preventDefault();
        e.stopPropagation();

        // guardar el producto
        const nuevoId = await insertProduct(newProduct);
        alert(`El nuevo id es ${nuevoId}`);
        props.cambiarVistaProp("lista");
    }

    return <div>
        <h1 className="title">Insertar un nuevo producto</h1>
        <h2 className="subtitle">Ingresa los campos para crear un nuevo producto</h2>

        <div className="columns">
            <div className="column">
                <form onSubmit={onHandleSubmit}>
                    <div className="field">
                        <label className="label">Nombre</label>
                        <div className="control">
                            <input className="input" type="text" placeholder="Ingrese el nombre del producto"
                                name="productName" onChange={onInputChange} required />
                        </div>
                    </div>
                    <div className="field">
                        <label className="label">Supplier</label>
                        <div className="control">
                            <input className="input" type="text" placeholder="Ingrese un ID" name="supplierId" onChange={onInputChange} required />
                        </div>
                    </div>
                    <div className="field">
                        <label className="label">Unit Price</label>
                        <div className="control">
                            <input className="input" type="text" placeholder="Ingrese el precio" name="unitPrice" onChange={onInputChange} />
                        </div>
                    </div>
                    <div className="field">
                        <label className="label">Package</label>
                        <div className="control">
                            <input className="input" type="text" placeholder="Ingrese el empaque" name="package" onChange={onInputChange} />
                        </div>
                    </div>
                    <div className="control">
                        <button className="button is-primary">Guardar</button>
                    </div>
                </form>
            </div>
        </div>

        <button className="button is-primary" onClick={() => { props.cambiarVistaProp("lista") }}>Regresar</button>
    </div>
}