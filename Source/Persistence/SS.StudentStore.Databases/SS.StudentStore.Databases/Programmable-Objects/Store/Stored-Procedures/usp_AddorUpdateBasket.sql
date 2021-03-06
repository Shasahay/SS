Create procedure [Store].[usp_AddorUpdateBasket]
@basketId bigint,
@basketUId nvarchar(100),
@deliveryMethodId int,
@clientSecret nvarchar(100),
@paymentIntendId nvarchar(50),
@shippingPrice Decimal (7,2),
@basketItemTable [Store].[BasketItemTableType] ReadOnly,
@loggedUser nvarchar(100)

As 

Begin
Set Nocount On
Declare @ErrorMsg nvarchar(max);
Declare @ReturnStatus int = 0 -- Default Success
Declare  @lastIdentity bigint;

Begin Try

	Begin Transaction
			If Exists(select top 1 1 from [Store].[Basket] with (nolock) where BasketId = @basketId) OR 
				Exists(select top 1 1 from [Store].[BasketItem] with (nolock) where BasketId = @basketId)
				Begin

				-- Update Basket Table 

				Update [Store].[Basket]

					Set [DeliveryMethodId] = @deliveryMethodId, 
						[ClientSecret] = @clientSecret,
						[PaymentIntendId] = @paymentIntendId,
						[ShippingPrice] =@shippingPrice,	
						[ModifiedBy] = @loggedUser,
						[ModifiedDate] = GETUTCDATE()
					where [BasketUId] = @basketUId
					OR [BasketId] = @basketId

						-- Removing this step for now
						-- INSERT INTO History table

						--Insert into [Store].[BasketItem_History] (
						--							[BasketItemId],[BasketId],[ProductId], [ProductName],[Quantity], [PictureUrl],[Price], [IsActive], [IsDelete],
						--							[CreatedBy],[CreatedDate], [ModifiedBy],[ModifiedDate],[EntryBy]
						--	)
						--Select 
						--		BT.[BasketItemId], BT.[BasketId], BT.[ProductId], BT.[ProductName],	BT.[Quantity], BT.[PictureUrl], BT.[Price], BT.[IsActive], BT.[IsDelete],
						--		BT.[CreatedBy],BT.[CreatedDate],BT.[ModifiedBy],BT.[ModifiedDate], GETUTCDATE()
						--		from [Store].[BasketItem] BT
						--		Inner join @basketItemTable BTT
						--		on BT.BasketItemId = BTT.BasketItemId


				-- Delete from current Basket Item table


				Delete from [Store].[BasketItem] where BasketId= @basketId

				-- Basket Table Insert 

				 Insert into [Store].[BasketItem]
				 (
					[BasketId],	[ProductId], [ProductTypeId],[ProductName],[Quantity], [PictureUrl],[Price],[NumberOfMonths],
					[CreatedBy],[CreatedDate], [ModifiedBy],[ModifiedDate]
				 )
 
				 Select  @basketId ,BT.ProductId,BT.ProductTypeId, BT.ProductName, BT.Quantity, BT.[PictureUrl], BT.[Price],BT.[NumberOfMonths],
						@loggedUser,GETUTCDATE(), @loggedUser, GETUTCDATE()
				 From @basketItemTable BT

				End
				

			Else

			Begin 


			-- Basket Table Insert 

					 Insert Into [Store].[Basket]
					 ( 
						[BasketUId], [DeliveryMethodId], [ClientSecret],[PaymentIntendId], [ShippingPrice],	
						[CreatedBy],[CreatedDate], [ModifiedBy],[ModifiedDate]
					 )
 
					Select @basketUId, @deliveryMethodId, @clientSecret, @paymentIntendId, @shippingPrice, @loggedUser,GETUTCDATE(), @loggedUser, GETUTCDATE()
 
			Set @lastIdentity = SCOPE_IDENTITY()

			 Insert into [Store].[BasketItem]
				 (
					[BasketId],	[ProductId],[ProductTypeId], [ProductName],[Quantity], [PictureUrl],[Price],[NumberOfMonths],
					[CreatedBy],[CreatedDate], [ModifiedBy],[ModifiedDate]
				 )
 
				 Select @lastIdentity,BT.ProductId,BT.ProductTypeId, BT.ProductName, BT.Quantity, BT.[PictureUrl], BT.[Price], BT.[NumberOfMonths],
						@loggedUser,GETUTCDATE(), @loggedUser, GETUTCDATE()
				 From @basketItemTable BT

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
	Select * From [Store].[vwBasketView] where BasketUId = @basketUId
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
