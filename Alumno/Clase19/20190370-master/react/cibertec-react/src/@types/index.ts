export interface IProduct {
    id: number;
    productName: string;
    supplierId: number;
    unitPrice: number;
    package: string;
    isDiscontinued: boolean;
}