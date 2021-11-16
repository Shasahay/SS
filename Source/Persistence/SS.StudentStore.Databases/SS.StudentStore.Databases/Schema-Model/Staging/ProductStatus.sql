Create table [Staging].[ProductStatus](
[ProductStatusId] int identity(1,1) not null,
[status] nvarchar(30),
[Description] nvarchar (1000),
[IsActive] bit default(1),
constraint [PK_ProductStatus_ProductStatusId] Primary key clustered ([ProductStatusId] asc) 
)