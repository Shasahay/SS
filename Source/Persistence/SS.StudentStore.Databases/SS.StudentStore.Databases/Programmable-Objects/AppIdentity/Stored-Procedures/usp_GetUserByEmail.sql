Create Procedure [AppIdentity].[usp_GetUserByEmail]
@email nvarchar(30)
As 
Begin

		Select [UserId],[FirstName],[MiddleName], [lastName], [DisplayName], [UserName], [Email], [PhoneNumber],
				[ClearPassword], [PasswordHash], [LastLoginDate], [IsLocked], [AccessFailedCount],[IsActive]
				From [AppIdentity].[Users]
	where 
	[Email] = @email
	And 
	[IsActive] = 1

End 
Go
