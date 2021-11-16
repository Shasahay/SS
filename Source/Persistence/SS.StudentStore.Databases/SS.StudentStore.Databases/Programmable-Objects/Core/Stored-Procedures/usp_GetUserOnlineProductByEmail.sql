Create Procedure [Core].[usp_GetUserOnlineProductByEmail]
@userEmail nvarchar(100),
@productTypeIdTable [Core].[CommonIdIntTableType] Readonly
As 
Begin

select P.[ProductId],P.[Title], P.[Name], P.[Description], PT.[Price],P.[CategoryId],P.[CategoryName] ,P.[SubCategoryId], P.[SubCategoryName], 
P.[GradeId], P.[GradeName], P.[SectionId], P.[SectionName] ,P.[BrandId], P.[BrandName] ,P.[ShortPictureUrl],P.[PictureUrl],P.[ProductManufacturer],
P.[ProductManufacturerPicture],P.[ProductManufacturerProfile],P.[DocumentUrl], P.[DocumentType], P.[IsActive], P.[CreatedBy], P.[CreatedDate],
P.[ModifiedBy], P.[ModifiedDate] 
From 
[Core].[vwProduct] P
Inner Join [Order].[OrderItem] OI On P.[ProductId] = OI.[ProductId]
Inner join [Order].[Order] O on O.[OrderId] = OI.[OrderId]
Inner Join [Core].[ProductTypeMapping] PT on PT.ProductId = P.[ProductId]
Inner join @productTypeIdTable PTT on PTT.Id = PT.ProductTypeId 
--Inner Join [AppIdentity].[Users] U on U.[UserId] = O.[UserId]

where 
O.[UserEmail] = @userEmail And
OI.[IsActive] = 1  

End 
Go
