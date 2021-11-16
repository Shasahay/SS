Create Procedure [Core].[usp_GetAllCategory]
As 
Begin

Select [CategoryId], [Name],[Description],[IsActive]
From [Core].[Category]
where 
[IsActive] = 1
End 
Go
