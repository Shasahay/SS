Create Procedure [Core].[usp_GetAllGrade]
As 
Begin

Select [GradeId],[Name],[Description] ,[IsActive]
From [Core].[Grade]
where 
[IsActive] = 1
End 
Go
