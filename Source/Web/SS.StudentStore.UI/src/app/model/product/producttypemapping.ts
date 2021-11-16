export interface IProducttypeMapping{
    productTypeMappingId: number;
    productTypeId: number;
    productId: number;
    name: string;
    desctiption: string;
    price: number;
}

export class ProductTypeMapping implements IProducttypeMapping{
    productTypeMappingId: number;
    productTypeId: number;
    productId: number;
    name: string;
    desctiption: string;
    price: number;
    
}