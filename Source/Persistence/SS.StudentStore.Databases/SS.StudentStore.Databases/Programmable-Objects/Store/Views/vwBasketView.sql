Create View [Store].[vwBasketView]
As 
	Select B.[BasketId],
	B.[BasketUId], B.[DeliveryMethodId], B.[ClientSecret],B.[PaymentIntendId], B.[ShippingPrice],
	BI.[BasketItemId], BI.[ProductId], PT.[ProductTypeId], BI.[ProductName],PT.[Name] as 'ProductTypeName', BI.[Quantity], BI.[PictureUrl],
	BI.[Price], BI.[NumberOfMonths]
	from [Store].[Basket]  B 
	Inner Join [Store].[BasketItem] BI on B.BasketId = BI.BasketId
	Inner Join [Core].[ProductType] PT On BI.[ProductTypeId] = PT.ProductTypeId
	where B.[IsActive] = 1 and BI.[IsActive] = 1 and BI.[IsDelete] = 0 and PT.[IsActive] = 1
GO