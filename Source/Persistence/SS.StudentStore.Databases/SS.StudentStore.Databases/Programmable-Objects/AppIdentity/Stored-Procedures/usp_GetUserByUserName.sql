Create Procedure [AppIdentity].[usp_GetUserByUserName]
@userName nvarchar(30)
As 
Begin

		Select [UserId],[FirstName],[MiddleName], [lastName], [DisplayName], [UserName], [Email], [PhoneNumber],
				[ClearPassword], [PasswordHash], [LastLoginDate], [IsLocked], [AccessFailedCount],[IsActive]
				From [AppIdentity].[Users]
	where 
	[UserName] = @userName
	And 
	[IsActive] = 1

End 
Go
