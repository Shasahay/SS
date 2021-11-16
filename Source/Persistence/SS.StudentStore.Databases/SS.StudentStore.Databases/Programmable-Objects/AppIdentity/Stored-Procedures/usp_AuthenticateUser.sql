Create Procedure [AppIdentity].[usp_AuthenticateUser]
@email nvarchar(30),
@password nvarchar(100)
As 
Begin

		Select [UserId],[FirstName],[MiddleName], [lastName], [DisplayName], [UserName], [Email], [PhoneNumber],
				[ClearPassword], [PasswordHash], [LastLoginDate], [IsLocked], [AccessFailedCount],[IsActive]
				From [AppIdentity].[Users]
	where 
	[Email] = @email 
	And
	[PasswordHash] = @password
	And 
	[IsActive] = 1

End 
GO


