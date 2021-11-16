Create Procedure [Core].[usp_GetProduct]
As 
Begin

select [ProductId],[Title], [Name], [Description], [Price],[CategoryId],[CategoryName] ,[SubCategoryId], [SubCategoryName], 
[GradeId], [GradeName], [SectionId], [SectionName] ,[BrandId], [BrandName] ,[ShortPictureUrl],[PictureUrl],[ProductManufacturer],
[ProductManufacturerPicture],[ProductManufacturerProfile],[DocumentUrl], [DocumentType], [IsActive], [CreatedBy], [CreatedDate],
[ModifiedBy], [ModifiedDate] 
From 
[Core].[vwProduct]
End 
Go