Create Procedure [Core].[usp_GetAllBrand]
As 
Begin

Select [BrandId],[Name],[Description] ,[IsActive]
From [Core].[Brand]
where 
[IsActive] = 1
End 
Go
