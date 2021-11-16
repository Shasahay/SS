Create Type [Store].[BasketItemTableType] as Table
(
	[BasketItemId] BigInt null,
	[BasketId] Bigint null,
	[ProductId] bigint not null,
	[ProductTypeId] int null,
	[ProductName] nvarchar(100) null,
	[Quantity] int Not Null,
	[PictureUrl] nvarchar(1000) null,
	[Price] decimal(5,2), 
	[NumberOfMonths] int Null
	)
Go