﻿Create Procedure [Core].[usp_GetAllProduct]
AS 
Begin 

select P.[ProductId],P.[Title], P.[Name], P.[Description], P.[Price], P.[CategoryId], C.[Name] As CategoryName ,P.[SubCategoryId], SC.[Name] as SubCategoryName, 
P.[GradeId],G.[Name] As GradeName,P.[SectionId], S.[Name] As SectionName ,P.[BrandId], B.[Name] as BrandName ,P.[ShortPictureUrl],P.[PictureUrl],P.[ProductManufacturer],
P.[ProductManufacturerPicture],P.[ProductManufacturerProfile],P.[DocumentUrl],P.[DocumentType],P.[IsActive],P.[CreatedBy],P.[CreatedDate],
P.[ModifiedBy],P.[ModifiedDate]  from [core].[Product] P
Inner join [Core].[Category] C on C.[CategoryId] = P.[CategoryId] 
Inner Join [Core].[SubCategory] SC on SC.SubCategoryId = P.[SubCategoryId]
Inner Join [Core].[Brand] B on B.[BrandId] = P.[BrandId]
Inner Join [Core].[Grade] G on G.[GradeId] = P.[GradeId]
Inner Join [Core].[Section] S on S.[SectionId] = P.[SectionId]
where P.[IsActive] = 1 And
C.[IsActive] = 1 And
SC.[IsActive] = 1 And
B.[IsActive] = 1 And
G.[IsActive] = 1 And
S.[IsActive] = 1 
End
Go