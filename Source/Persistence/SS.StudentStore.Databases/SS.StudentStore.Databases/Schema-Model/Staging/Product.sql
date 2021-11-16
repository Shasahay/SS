﻿Create table [Staging].[Product](
	[ProductId] bigint Identity(1,1)  Not null,
	[ProductUID] UniqueIdentifier default newid(),
	[Title] nvarchar(100) not null, 
	[Name] nvarchar(100) not null,
	[Description] nvarchar(max) null,
	[Price] Decimal(7,2) null,
	[CategoryId] int null,
	[SubCategoryId] int null,
	[GradeId] int null,
	[SectionId] int,
	[BrandId] int null,
	[ShortPictureUrl] nvarchar(500),
	[PictureUrl] nvarchar(500),
	[ProductManufacturer] nvarchar(500),
	[ProductManufacturerPicture] nvarchar(500),
	[ProductManufacturerProfile] nvarchar(500),
	[DocumentUrl] nvarchar(1000),
	[DocumentType] int,
	[ProductReviewedBy] nvarchar(100),
	[ProductApprovedBy] nvarchar(100),
	[ReviewedDate]  datetime2,
	[ApprovedDate]  datetime2,
	[StatusId] int, 
	[IsActive] bit default(1),
	[IsDelete] bit default(0),
	[Commnent] nvarchar(max),
	[CreatedBy] nvarchar(100) null,
	[CreatedDate]  datetime2 default(getdate()),
	[ModifiedBy] nvarchar(100) null,
	[ModifiedDate] Datetime2 null,
	constraint [PK_Product_ProductId] Primary key clustered (ProductId asc),
	constraint [FK_Product_StatusId_ProductStatus_ProductStatusId] Foreign key ([StatusId]) References [Staging].[ProductStatus]([ProductStatusId])
)