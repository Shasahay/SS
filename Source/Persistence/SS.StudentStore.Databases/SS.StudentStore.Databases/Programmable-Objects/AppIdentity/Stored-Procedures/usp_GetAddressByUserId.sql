Create Procedure [AppIdentity].[usp_GetAddressByUserId]
@userId BigInt
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
				A.[Pincode],
				A.[Country],
				A.[LandMark],
				A.[FullAddress],
				A.[IsActive]
				From [AppIdentity].[Address] A
				Inner Join [AppIdentity].[Users] U
				on A.UserId = u.UserId
				where U.Email = @userId and U.IsActive = 0
	
End 
Go
