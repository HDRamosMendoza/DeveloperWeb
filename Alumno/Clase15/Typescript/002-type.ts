interface IProduct{
    id: Number;
    productName: String;
    unitPrice?: Number;
    isDiscontinued?: boolean;

    validatePrice?() : Number;
}

// const nuevoProducto2: ICustomsProducto