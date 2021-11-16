Create Procedure [Store].[usp_GetBasketByUId]
@basketUId nvarchar(500)
As 
Begin

Select [BasketId], [BasketUId], [DeliveryMethodId],[ClientSecret], [PaymentIntendId], [ShippingPrice],[IsActive]
From [Store].[Basket]
where 
[BasketUId] = @basketUId
And 
[IsActive] = 1
AND
[IsDelete] = 0
End 
Go
