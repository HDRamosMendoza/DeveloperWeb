import React from "react";
import { IProduct } from "../@types";
import { editProduct, getProductById } from "../service";

interface IProps {
    cambiarVistaProp: any;
    idProducto: number;
}

export const EditView: React.FC<IProps> = (props) => {
    const [product, setProduct] = React.useState<IProduct>({
        id: 0,
        productName: "",
        supplierId: 0,
        unitPrice: 0,
        package: "",
        isDiscontinued: false,
    });

    // cargar la data
    const cargarProducto = async () => {
        setProduct(await getProductById(props.idProducto));
    }
    React.useEffect(() => {
        // obtener el producto por id
        cargarProducto();
    }, [])

    const onInputChange = (e: React.ChangeEvent<HTMLInputElement>) => {
        const inputName = e.target.name;
        const inputValue = e.target.value;
        setProduct((prevData: IProduct) => ({ ...prevData, [inputName]: inputValue }));
    }

    const onHandleSubmit = async (e: React.FormEvent) => {
        e.preventDefault();
        e.stopPropagation();

        // guardar el producto
        const mensaje = await editProduct(product);
        alert(`${mensaje}`);
        props.cambiarVistaProp("lista");
    }

    return <div>
        <h1 className="title">Editar un producto</h1>
        <h2 className="subtitle">Ingresa los campos para editar el producto</h2>

        <div className="columns">
            <div className="column">
                <form onSubmit={onHandleSubmit}>
                    <div className="field">
                        <label className="label">Nombre</label>
                        <div className="control">
                            <input className="input" type="text" placeholder="Ingrese el nombre del producto"
                                name="productName" onChange={onInputChange} required value={product.productName} />
                        </div>
                    </div>
                    <div className="field">
                        <label className="label">Supplier</label>
                        <div className="control">
                            <input className="input" type="text" placeholder="Ingrese un ID" name="supplierId" onChange={onInputChange} required value={product.supplierId} />
                        </div>
                    </div>
                    <div className="field">
                        <label className="label">Unit Price</label>
                        <div className="control">
                            <input className="input" type="text" placeholder="Ingrese el precio" name="unitPrice" onChange={onInputChange} value={product.unitPrice} />
                        </div>
                    </div>
                    <div className="field">
                        <label className="label">Package</label>
                        <div className="control">
                            <input className="input" type="text" placeholder="Ingrese el empaque" name="package" onChange={onInputChange} value={product.package} />
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