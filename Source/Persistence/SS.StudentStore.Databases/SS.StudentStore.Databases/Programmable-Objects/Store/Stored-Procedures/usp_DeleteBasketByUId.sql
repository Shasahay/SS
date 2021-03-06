Create Procedure [Store].[usp_DeleteBasketByUId]
@basketUId nvarchar(500)
As 
Begin

Update [Store].[Basket]
Set [IsActive] = 0,
 [IsDelete] = 1
where 
[BasketUId] = @basketUId

Update [Store].[BasketItem]
Set [IsActive] = 0,
 [IsDelete] = 1
 where 
[BasketId] = (Select BasketId from [Store].[Basket] where [BasketUId] = @basketUId)

End 
