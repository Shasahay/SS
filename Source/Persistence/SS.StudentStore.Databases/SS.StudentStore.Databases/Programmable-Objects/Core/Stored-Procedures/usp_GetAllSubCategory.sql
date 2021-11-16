Create Procedure [Core].[usp_GetAllSubCategory]
As 
Begin

Select [SubCategoryId],[Name],[CategoryId],[IsActive]
From [Core].[SubCategory]
where 
[IsActive] = 1
End 
Go
