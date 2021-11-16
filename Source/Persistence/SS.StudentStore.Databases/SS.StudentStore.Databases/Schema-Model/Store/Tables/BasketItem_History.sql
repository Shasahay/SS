Create table [Store].[BasketItem_History](
	[BasketItemId] Bigint, 
	[BasketId] Bigint Not Null,
	[ProductId] BigInt not null,
	[ProductTypeId] int Null,
	[ProductName] nvarchar (100),
	[Quantity] int Not Null,
	[PictureUrl] nvarchar(1000),
	[Price] decimal (7,2) null,
	[NumberOfMonths] int Null,
	[IsActive] bit default(1),
	[IsDelete] bit default(0),
	[CreatedBy] nvarchar(100) null,
	[CreatedDate]  datetime2 default(getdate()),
	[ModifiedBy] nvarchar(100) null,
	[ModifiedDate] Datetime2 null,
	[EntryBy] datetime2 default(getdate())
)

