Create Type [Order].[OrderItemTableType] as Table
(
	[OrderItemId] BigInt,
	[OrderId] Bigint,
	[ProductId] bigint,
	[Quantity] int Not Null,
	[Price] decimal(5,2) 
	)
Go