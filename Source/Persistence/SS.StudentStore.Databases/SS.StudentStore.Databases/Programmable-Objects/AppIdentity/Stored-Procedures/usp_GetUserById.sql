Create Procedure [AppIdentity].[usp_GetUserById]
@userId BigInt
As 
Begin

		Select [UserId],[FirstName],[MiddleName], [lastName], [DisplayName], [UserName], [Email], [PhoneNumber],
				[ClearPassword], [PasswordHash], [LastLoginDate], [IsLocked], [AccessFailedCount],[IsActive]
				From [AppIdentity].[Users]
	where 
	[UserId] = @userId
	And 
	[IsActive] = 1

End 
Go
