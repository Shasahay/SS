Create Procedure [AppIdentity].[usp_GetAddressByEmail]
@email nvarchar(30)
As 
Begin

		Select A.[AddressId],
				A.[UserId],
				A.[AddressTypeId],
				A.[FirstName],
				A.[LastName],
				A.[HouseNumber],
				A.[Apartment],
				A.[Street],
				A.[Colony],
				A.[Locality],
				A.[City],
				A.[State],
				A.[PinCode],
				A.[Country],
				A.[LandMark],
				A.[FullAddress],
				A.[IsActive]
				From [AppIdentity].[Address] A
				Inner Join [AppIdentity].[Users] U
				on A.UserId = u.UserId
				where U.Email = @email and U.IsActive = 1
	
End 
Go
