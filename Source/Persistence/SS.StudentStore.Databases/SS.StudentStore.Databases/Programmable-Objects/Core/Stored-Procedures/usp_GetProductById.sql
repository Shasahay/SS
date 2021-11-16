Create Procedure [Core].[usp_GetProductById]
@id bigint
As 
Begin

select [ProductId],[ProductTypeId], [Title], [Name], [Description],[ProductTypeName], [Price],[CategoryId],[CategoryName] ,[SubCategoryId], [SubCategoryName], 
[GradeId], [GradeName], [SectionId], [SectionName] ,[BrandId], [BrandName] ,[ShortPictureUrl],[PictureUrl],[ProductManufacturer],
[ProductManufacturerPicture],[ProductManufacturerProfile],[DocumentUrl], [DocumentType], [IsActive], [CreatedBy], [CreatedDate],
[ModifiedBy], [ModifiedDate] 
From 
[Core].[vwProduct]
where 
[ProductId] = @id And
[IsActive] = 1 

End 
Go
