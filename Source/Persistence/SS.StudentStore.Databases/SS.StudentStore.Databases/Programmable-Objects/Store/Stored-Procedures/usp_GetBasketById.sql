Create Procedure [Store].[usp_GetBasketById]
@basketId bigint
As 
Begin

Select [BasketId], [BasketUId], [DeliveryMethodId],[ClientSecret], [PaymentIntendId], [ShippingPrice],[IsActive]
From [Store].[Basket]
where 
[BasketId] = @basketId and 
[IsActive] = 1 AND 
[IsDelete] = 0
End 
Go
