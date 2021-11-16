Create Procedure [Staging].[usp_AddorUpdateProduct]
@productId bigint,
@productUID UniqueIdentifier,
@title nvarchar(100),
@name nvarchar(100),
@description nvarchar(max),
@price Decimal(7,2),
@categoryId int,
@subCategoryId int,
@gradeId int,
@sectionId int,
@brandId int,
@shortPictureUrl nvarchar(500),
@pictureUrl nvarchar(500),
@productManufacturer nvarchar(500),  --  loged in user 
@productManufacturerPicture nvarchar(500),
@productManufacturerProfile nvarchar(500),
@documentUrl nvarchar(1000),
@documentType int,
@statusId int, 
@isActive bit

As
Begin 
Set Nocount On
Declare @ErrorMsg nvarchar(max);
Declare @ReturnStatus int = 0 -- Default Success
Declare  @lastIdentity bigint;
Declare @defaultActive bit = 1;
Declare @defaultDelete bit = 0;

Begin Try

	Begin Transaction
			If Exists(select top 1 1 from [Staging].[Product] with (nolock) where ProductId = @ProductId) OR 
				Exists(select top 1 1 from [Staging].[Product] with (nolock) where ProductUID = @ProductUID)
				Begin

				-- Update Basket Table 

				Update [Staging].[Product]

					Set [Title] = @title,
						[Name] = @name,
						[Description] = @description,
						[Price] = @price,
						[CategoryId] = @categoryId,
						[SubCategoryId] = @subCategoryId,
						[GradeId] = @gradeId,
						[SectionId] = @sectionId,
						[BrandId] = @brandId,
						[ShortPictureUrl] = @shortPictureUrl,
						[PictureUrl] = @pictureUrl,
						[ProductManufacturer] = @productManufacturer,
						[ProductManufacturerPicture] = @productManufacturerPicture,
						[ProductManufacturerProfile] = @productManufacturerProfile,
						[DocumentUrl] = @documentUrl,
						[DocumentType] = @documentType,
						[StatusId] = @statusId,
						[IsActive] = @isActive,
						[CreatedBy] = @productManufacturer,
						[CreatedDate] = GETDATE(),
						[ModifiedBy] = @productManufacturer,
						[ModifiedDate] = GETDATE()
					where [ProductId] = @ProductId
					OR [ProductUID] = @ProductUID

				End
				

			Else

			Begin 


			-- Basket Table Insert 

					 Insert Into [Staging].[Product]
					 ( 
						[ProductUID], 
						[Title],
						[Name],
						[Description],
						[Price],
						[CategoryId],
						[SubCategoryId],
						[GradeId],
						[SectionId],
						[BrandId],
						[ShortPictureUrl],
						[PictureUrl],
						[ProductManufacturer],
						[ProductManufacturerPicture],
						[ProductManufacturerProfile],
						[DocumentUrl],
						[DocumentType],
						[ProductReviewedBy],
						[ProductApprovedBy],
						[ReviewedDate],
						[ApprovedDate],
						[StatusId],
						[IsActive],
						[IsDelete],
						[Commnent],
						[CreatedBy],
						[CreatedDate],
						[ModifiedBy],
						[ModifiedDate]
					 )
 
					Select @productUID, @title, @name, @description, @price, @categoryId, @subCategoryId, @gradeId, @sectionId, @brandId,
					 @shortPictureUrl, @pictureUrl, @productManufacturer, @productManufacturerPicture, @productManufacturerProfile,
					 @documentUrl, @documentType, null, null, null, null, @statusId, @defaultActive, @defaultDelete, null,
					 @productManufacturer, GETDATE(), @productManufacturer, GETDATE()
		Set @lastIdentity = SCOPE_IDENTITY()
		set @productId = @lastIdentity
			End

				

			

	Commit Transaction;

	--Select B.[BasketId],
	--B.[BasketUId], B.[DeliveryMethodId], B.[ClientSecret],B.[PaymentIntendId], B.[ShippingPrice],
	--BI.[BasketItemId], BI.[ProductId], PT.[ProductTypeId], BI.[ProductName],PT.[Name] as 'ProductTypeName', BI.[Quantity], BI.[PictureUrl],
	--BI.[Price], BI.[NumberOfMonths]
	--from [Store].[Basket]  B 
	--Inner Join [Store].[BasketItem] BI on B.BasketId = BI.BasketId
	--Inner Join [Core].[ProductType] PT On BI.[ProductTypeId] = PT.ProductTypeId
	--where b.BasketUId = @basketUId and B.[IsActive] = 1 and BI.[IsActive] = 1 and PT.[IsActive] = 1

	-- Chec with view later
	Select * From [Staging].[vwStagingProduct] where ProductId = @productId
End Try

Begin Catch

	If(@@TRANCOUNT > 0)

	RollBack Transaction
		Set @ErrorMsg = ERROR_MESSAGE();
		RAISERROR(@ErrorMsg, 16, -1)
		Set @ReturnStatus = -1  -- Failure
End Catch

Return (@returnStatus)

End