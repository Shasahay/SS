Create Table [Core].[SubCategory](
	[SubCategoryId] int Identity (1,1) Not null,
	[Name] nvarchar(70) not null,
	[CategoryId] int Not null,
	[IsActive] bit default(1),
	[CreatedBy] nvarchar(100) null,
	[CreatedDate]  datetime2 default(getdate()),
	[ModifiedBy] nvarchar(100) null,
	[ModifiedDate] Datetime2 null,
	constraint [PK_SubCategory_SubcategoryId] primary key clustered (SubcategoryId),
	Constraint [FK_Subcategory_CategoryId_Category_CategoryId] Foreign key (CategoryId) References [Core].[Category](CategoryId)
)