import http from "axios";
import { IProduct } from "./../@types";

export async function getProducts(): Promise<IProduct[]> {
    const response = await http.get("https://localhost:5001/api/products");
    return (response.data as IProduct[]);
}

