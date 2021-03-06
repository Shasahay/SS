Create Procedure [Store].[usp_GetBasketItemByBasketId]
@basketId bigint
As 
Begin

Select BI.[BasketItemId],
	BI.[BasketId],
	BI.[ProductId],
	BI.[ProductName],
	BI.[Quantity],
	BI.[PictureUrl],
	BI.[Price],
	BI.[IsActive]
From [Store].[BasketItem] BI
where 
BI.[BasketId] = @basketId And BI.[IsActive] = 1 AND BI.[IsDelete] = 0

End 
