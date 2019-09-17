interface IProduct{
    id: number;
    productName: string;
    unitPrice?: number;
    isDiscontinued?: boolean;

    validatePrice?(): number;
}

interface ICustomProduct extends IProduct{
    customName:string;
}

const nuevoProducto: IProduct = {
    id: 1,
    productName: "nuevo producto",
    validatePrice (){
        return 5;
    }
}

const nuevoProducto2: ICustomProduct ={
    id:1,
    productName: "custom",
    customName: "other",
}

console.log(nuevoProducto.validatePrice());

class Producto {
    public Producto() {

    }    
}