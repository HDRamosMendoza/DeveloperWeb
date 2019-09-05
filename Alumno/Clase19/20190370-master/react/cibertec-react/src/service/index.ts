import http from "axios";
import { IProduct } from "./../@types";

function getBaseConfig() {
    return {
        "headers": {
            "Content-Type": "application/json",
            "Authorization": `Bearer ${process.env.REACT_APP_TEST_JWT}`
        }
    }
}

export async function getProducts(): Promise<IProduct[]> {
    const response = await http.get(`${process.env.REACT_APP_API_URL}products`, getBaseConfig());
    return (response.data as IProduct[]);
}

export async function insertProduct(newProduct: IProduct): Promise<number> {
    const response = await http.post(`${process.env.REACT_APP_API_URL}products`, newProduct, getBaseConfig());

    return (response.data as number);
}

export async function getProductById(id: number): Promise<IProduct> {
    const response = await http.get(`${process.env.REACT_APP_API_URL}products/${id}`, getBaseConfig())
    return response.data as IProduct;
}

export async function editProduct(product: IProduct): Promise<string> {
    const response = await http.put(`${process.env.REACT_APP_API_URL}products`, product, getBaseConfig());

    return response.data as string;
}

export async function deleteProduct(id: number): Promise<string> {
    const response = await http.delete(`${process.env.REACT_APP_API_URL}products/${id}`, getBaseConfig());

    return response.data as string;
}
