Create Procedure [Core].[usp_GetProductTypeMappingByProductId]
@productId bigint
As 
Begin

select PTM.ProductTypeMappingId, PTM.ProductTypeId, PTM.ProductId,PT.[Name], PTM.[Description], PTM.[Price], PTM.[IsActive]

From 
[Core].[ProductTypeMapping] PTM
Inner Join [Core].[ProductType] PT
On
PTM.ProductTypeId = PT.ProductTypeId
where 
[PTM].ProductId = @productId And
[PTM].IsActive = 1 And
[PT].[IsActive] = 1 

End 
Go
