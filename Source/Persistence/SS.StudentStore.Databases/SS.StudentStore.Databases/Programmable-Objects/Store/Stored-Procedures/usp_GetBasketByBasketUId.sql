Create Procedure [Store].[usp_GetBasketByBasketUId]
@basketUId nvarchar(100)
As
Begin

--Select B.BasketId, B.BasketUId, B.DeliveryMethodId, B.ClientSecret, b.PaymentIntendId, B.ShippingPrice,
--BI.BasketItemId, BI.ProductId, BI.ProductName, BI.Quantity, BI.PictureUrl, BI.Price
--From [Store].[Basket] B 
--Inner Join [Store].[BasketItem] BI on
--B.BasketId = BI.BasketId
--where B.BasketUId = @basketUId And
--B.IsActive = 1 And
--BI.IsActive = 1


-- selecting from View now
Select * From [Store].[vwBasketView]
Where [BasketUId] = @basketUId

End

GO


