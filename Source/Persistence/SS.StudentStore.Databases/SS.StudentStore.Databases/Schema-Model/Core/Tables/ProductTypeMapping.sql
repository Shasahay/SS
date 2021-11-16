Create Table [Core].[ProductTypeMapping](
	[ProductTypeMappingId] Bigint Identity(1,1)  Not null, 
	[ProductId] bigint not null,
	[ProductTypeId] int, 
	[Description] nvarchar(max) null,
	[Price] decimal(7,2) null,
	[IsActive] bit default(1),
	constraint [PK_ProductTypeMapping_ProductTypeMappingId] Primary key clustered ([ProductTypeMappingId] asc),
	Constraint [FK_ProductTypeMapping_ProductId_Product_ProductId] Foreign key (ProductId) References [Core].[Product],
	Constraint [FK_ProductTypeMapping_ProductTypeId_ProductType_ProductTypeId] Foreign key ([ProductTypeId]) References [Core].[ProductType]
)

