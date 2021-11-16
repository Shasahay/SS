Create Procedure [Order].[usp_CreateOrder]
@orderId bigint,
@userEmail nvarchar(100),
@userId bigint,
@addressId Bigint,
@subTotal Decimal (7,2),
@status nvarchar(20),
@paymentIntentId nvarchar(100),
@deliveryMethodId Int,
@createdBy nvarchar(100),
@createdDate DateTime,
@orderItemTable [Order].[OrderItemTableType] ReadOnly

As 
Begin

Set Nocount On
Declare @ErrorMsg nvarchar(max);
Declare @ReturnStatus int = 0 -- Default Success
Declare  @lastIdentity bigint;
Declare @isActive bit = 1

Begin Try

	Begin Transaction
			If Exists(select top 1 1 from [Order].[Order] with (nolock) where [OrderId] = @orderId) OR 
				Exists(select top 1 1 from [Order].[OrderItem] with (nolock) where [OrderId] = @orderId)
				Begin

				-- Update Basket Table 

				Update [Order].[Order]

					Set [UserId] = @userId, 
						[UserEmail] = @userEmail,
						[AddressId] = @addressId,
						[SubTotal] =@subTotal,	
						[Status] = @status,
						[PaymentIntentId] = @paymentIntentId,
						[DeliveryMethodId] = @deliveryMethodId,
						[CreatedBy] = @createdBy,
						[CreatedDate] = @createdDate,
						[IsActive] = @isActive
					where [OrderId] = @orderId
					
						-- INSERT INTO History table



				-- Delete from current Order Item table


				Delete from [Order].[OrderItem] where [OrderId] = @orderId

				-- Basket Table Insert 

				 Insert into [Order].[OrderItem]
				 (
						[OrderId], [ProductId],[ProductTypeId], [Quantity], [Price],[NumberOfMonths], [CreatedDate], [IsActive]
				 )
 
				 Select  @orderId ,OI.ProductId, OI.ProductTypeId ,OI.[Quantity], OI.[Price], OI.[NumberOfMonths], @createdDate, @isActive
						
				 From @orderItemTable OI

				End
				

			Else

			Begin 


			-- Basket Table Insert 

					 Insert Into [Order].[Order]
					 ( 
					[UserId], [UserEmail], [AddressId], [SubTotal], [Status], [PaymentIntentId], [DeliveryMethodId], [CreatedBy], [CreatedDate], [IsActive]
					 )
 
					Select	@userId, 
							@userEmail,
							@addressId,
							@subTotal,	
							@status,
							@paymentIntentId,
							@deliveryMethodId,
							@createdBy,
							@createdDate,
							@isActive
 
			Set @lastIdentity = SCOPE_IDENTITY()

			  Insert into [Order].[OrderItem]
				 (
						[OrderId], [ProductId],[ProductTypeId], [Quantity], [Price],[NumberOfMonths], [CreatedDate], [IsActive]
				 )
 
				 Select @lastIdentity, OI.ProductId, OI.ProductTypeId ,OI.[Quantity], OI.[Price], OI.[NumberOfMonths], @createdDate, @isActive
						
				 From @orderItemTable OI

			End

				

			

	Commit Transaction;

--	Select O.[OrderId], O.[UserEmail], O.[AddressId], O.[SubTotal], O.[Status], O.[PaymentIntentId], O.[DeliveryMethodId], O.[CreatedDate] As 'OrderCreatedDate',
--OI.[OrderItemId], OI.[ProductId],P.[Title] as  'ProductTitle', P.[PictureUrl], OI.[Quantity],OI.[Price], OI.[CreatedDate] as 'OrderItemCreatedDate'

--From 
--[Order].[Order] O
--Inner Join
--[Order].[OrderItem] OI On
--O.[OrderId] = OI.[OrderId]
--Inner Join [Core].[Product] P
--on 
--OI.[ProductId] = P.[ProductId]
--Where 
--O.[IsActive] = 1 and 
--OI.[IsActive] = 1

	Select	* From [Order].[vwOrderView]


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

