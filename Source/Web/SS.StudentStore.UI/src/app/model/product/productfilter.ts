export class ProductFilter{
    productId: number;
    categoryId: number;
    subCategoryId: number;
    brandId: number;
    GradeId: number;
    SectionId: number;
    pageNumber: number = 1;
    pageSize: number = 5;
    SortField: string;
    SortDirection: string = 'OrderBy';
    search: string;
}