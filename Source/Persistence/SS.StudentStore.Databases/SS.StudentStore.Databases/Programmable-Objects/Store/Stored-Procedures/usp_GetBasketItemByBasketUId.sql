Create Procedure [Store].[usp_GetBasketItemByBasketUId]
@basketUId nvarchar(100)
As 
Begin

--Select BI.[BasketItemId],
--	BI.[BasketId],
--	B.[BasketUId],
--	BI.[ProductId],
--	BI.[ProductName],
--	BI.[Quantity],
--	BI.[PictureUrl],
--	BI.[Price],
--	BI.[IsActive]
--From [Store].[BasketItem] BI
--Inner join 
--[Store].[Basket] B
--on
--BI.[BasketId] = B.[BasketId]
--where 
--B.[BasketUId] = @basketUId And B.[IsActive] = 1 AND B.[IsDelete] = 0
--And 
--BI.[IsActive] = 1 And BI.[IsDelete] = 0

-- Using View now 
-- selecting from View now
Select [BasketId], [BasketUId],[DeliveryMethodId],[ClientSecret],[PaymentIntendId],[ShippingPrice],
[BasketItemId],[ProductId],[ProductTypeId],[ProductName],[Quantity],[PictureUrl],[Price], [NumberOfMonths] 
From [Store].[vwBasketView]
Where [BasketUId] = @basketUId


End 

Go

