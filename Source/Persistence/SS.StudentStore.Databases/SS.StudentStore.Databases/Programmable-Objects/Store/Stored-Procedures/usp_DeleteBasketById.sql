Create Procedure [Store].[usp_DeleteBasketById]
@basketId bigint
As 
Begin

Update [Store].[Basket]
Set [IsActive] = 0,
 [IsDelete] = 1
where 
[BasketId] = @basketId

End 
Go
