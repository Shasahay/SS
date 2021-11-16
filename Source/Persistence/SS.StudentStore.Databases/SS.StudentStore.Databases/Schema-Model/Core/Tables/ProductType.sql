Create Table [Core].[ProductType](
	[ProductTypeId] int Identity(1,1)  Not null,
	[Name] nvarchar(50) null,
	[Description] nvarchar(max) null,
	[IsActive] bit default(1),
	constraint [PK_ProductType_ProductTypeId] Primary key clustered ([ProductTypeId] asc)
)