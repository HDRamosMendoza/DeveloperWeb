import http from "axios";
import { IProduct } from "./../@types";

function getBaseConfig() {
    return {
        "headers": {
            "Content-Type": "application/json",
            "Authorization": `Bearer ${window.localStorage.getItem("__token_key")}`
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

interface IGetUserTokenResponse {
    status: "success" | "error",
    data: any
}

interface IGetTokenRequest {
    username: string,
    password: string,
}

export async function getUserToken(request: IGetTokenRequest): Promise<IGetUserTokenResponse> {
    try {
        const response = await http.post(`${process.env.REACT_APP_API_URL}account/token`, request);

        if (response.status !== 200) {
            return { status: "error", data: { message: "Usuario no válido" } }
        }

        return { status: "success", data: response.data };
    } catch (error) {
        return { status: "error", data: { error } }
    }
}