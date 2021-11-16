Create Procedure [Core].[usp_GetAllSection]
As 
Begin

Select [SectionId],[Name],[Description] ,[IsActive]
From [Core].[Section]
where 
[IsActive] = 1
End 
Go
