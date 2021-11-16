Create View [Order].[vwOrderView] As

Select O.[OrderId], O.[UserEmail], O.[AddressId], O.[SubTotal], O.[Status], O.[PaymentIntentId], O.[DeliveryMethodId], O.[CreatedDate] As 'OrderCreatedDate',
OI.[OrderItemId], OI.[ProductId],OI.[ProductTypeId], P.[Name] as  'ProductName', P.[Title] as 'ProductTitle',PT.[Name] as 'ProductTypeName', P.[PictureUrl], OI.[Quantity],OI.[Price],OI.[NumberOfMonths], OI.[CreatedDate] as 'OrderItemCreatedDate'

From 
[Order].[Order] O
Inner Join
[Order].[OrderItem] OI On
O.[OrderId] = OI.[OrderId]
Inner Join [Core].[Product] P
on 
OI.[ProductId] = P.[ProductId]
Inner Join 
[Core].[ProductType] PT on OI.[ProductTypeId] = PT.ProductTypeId
Where 
O.[IsActive] = 1 and 
OI.[IsActive] = 1 And
P.IsActive = 1 And
PT.IsActive = 1



