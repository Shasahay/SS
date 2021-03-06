Create procedure [AppIdentity].[usp_AddOrUpdateAddress]
	@addressId bigint,
	@userId bigint,
	@addressTypeId int,
	@firstName nvarchar(30),
	@lastName nvarchar(30),
	@houseNumber nvarchar(30),
	@apartment nvarchar(100),
	@street nvarchar(100),
	@colony nvarchar(100),
	@locality nvarchar(200),
	@city nvarchar(70),
	@state nvarchar(70),
	@pincode nvarchar(6),
	@country nvarchar(100),
	@landMark nvarchar(100),
	@fullAddress nvarchar(max),
	@isActive bit
As 

Begin
Set Nocount On
Declare @ErrorMsg nvarchar(max);
Declare @ReturnStatus int = 0 -- Default Success
Declare  @lastIdentity bigint;
 

Begin Try

	Begin Transaction
			If Exists( select top 1 1 from [AppIdentity].[Address] with (nolock) where AddressId = @addressId)
				Begin
				 
		-- Update users Table
				Update [AppIdentity].[Address]

				Set [UserId] = @userId,
					[AddressTypeId] = @addressTypeId,
					[FirstName] = @firstName,
					[LastName] = @lastName,
					[HouseNumber] = @houseNumber,
					[Apartment] = @apartment,
					[Street] = @street,
					[Colony] = @colony,
					[Locality] = @locality,
					[City] = @city,
					[State] = @state,
					[PinCode] = @pincode,
					[Country] = @country,
					[LandMark] = @landMark,
					[FullAddress] = @fullAddress,
					[IsActive] = @isActive
					where [AddressId] = @addressId And [IsActive] = 1

				End

			Else

			Begin 

			-- Insert Users Table  

				Insert Into [AppIdentity].[Address]
				(
					[UserId],
					[AddressTypeId], 
					[FirstName],
					[LastName],
					[HouseNumber],
					[Apartment],
					[Street],
					[Colony],
					[Locality],
					[City],
					[State],
					[PinCode],
					[Country],
					[LandMark],
					[FullAddress],
					[IsActive]
				)
				Select
				@userId,
				@addressTypeId,
				@firstName,
				@lastName,
				@houseNumber,
				@apartment ,
				@street,
				@colony,
				@locality,
				@city,
				@state,
				@pincode,
				@country,
				@landMark,
				@fullAddress,
				@isActive

		Set @lastIdentity = SCOPE_IDENTITY()

			End

			
	Commit Transaction
		-- Returning

		Select  [AddressId], [UserId],
					[AddressTypeId], 
					[FirstName],
					[LastName],
					[HouseNumber],
					[Apartment],
					[Street],
					[Colony],
					[Locality],
					[City],
					[State],
					[PinCode],
					[Country],
					[LandMark],
					[FullAddress],
					[IsActive]
					From [AppIdentity].[Address]
					where (AddressId = @addressId OR [AddressId] = @lastIdentity)
					and [IsActive] = 1
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
