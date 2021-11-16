export interface IStageProduct {
    productId: number;
    productUID : string;
    productTypeId: number;
    title : string;
    name: string;
    description: string;
    productTypeName: string
    price: number;
    categoryId : number;
    subCategoryId : number;
    gradeId : number;
    sectionId : number;
    brandId : number;
    shortPictureUrl: string;
    pictureUrl: string;
    productManufacturer: string;
    productManufacturerPicture: string;
    documentUrl: string;
    isActive: string;
    statusId: number;
}

export class StageProduct implements IStageProduct{
    productId: number;
    productUID: string;
    productTypeId: number;
    title: string;
    name: string;
    description: string;
    productTypeName: string;
    price: number;
    categoryId: number;
    subCategoryId: number;
    gradeId: number;
    sectionId: number;
    brandId: number;
    shortPictureUrl: string;
    pictureUrl: string;
    productManufacturer: string;
    productManufacturerPicture: string;
    documentUrl: string;
    isActive: string;
    statusId: number;
    
}
