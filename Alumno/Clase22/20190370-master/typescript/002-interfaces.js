const nuevoProducto = {
    id: 1,
    productName: "nuevo producto",
    validatePrice() {
        return 5;
    }
};
const nuevoProducto2 = {
    id: 1,
    productName: "custom",
    customName: "other",
};
console.log(nuevoProducto.validatePrice());
class Producto {
    Producto() {
    }
}
