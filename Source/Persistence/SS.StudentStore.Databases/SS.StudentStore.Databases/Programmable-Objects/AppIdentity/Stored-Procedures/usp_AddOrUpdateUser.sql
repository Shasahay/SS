Create procedure [AppIdentity].[usp_AddOrUpdateUser]
@userId bigint,
@firstName nvarchar(30),
@middleName nvarchar(30),
@lastName nvarchar(30),
@displayName nvarchar(70),
@userName nvarchar(30),
@email nvarchar(30),
@phoneNumber nvarchar(12),
@clearPassword nvarchar(100),
@passwordHash nvarchar(100),
@lastLoginDate DateTime2,
@isLocked bit,
@accessFailedCount int,
@isActive bit
As 

Begin
Set Nocount On
Declare @ErrorMsg nvarchar(max);
Declare @ReturnStatus int = 0 -- Default Success
Declare  @lastIdentity bigint;

Begin Try

	Begin Transaction
			If Exists( select top 1 1 from [AppIdentity].[users] with (nolock) where UserId = @userId) OR 
				Exists (select top 1 1 from [AppIdentity].[users] with (nolock) where Email = @email)
				Begin
				 
		-- Update users Table
				Update [AppIdentity].[Users]

				Set [FirstName] = @firstName,
					[MiddleName] = @middleName,
					[lastName] = @lastName,
					[DisplayName] = @displayName,
					[UserName] = @userName,
					[Email] = @email, 
					[PhoneNumber] = @phoneNumber,
					[ClearPassword] = @clearPassword,
					[PasswordHash] = @passwordHash,
					[LastLoginDate] = @lastLoginDate,
					[IsLocked] = @isLocked,
					[AccessFailedCount] = @accessFailedCount,
					[IsActive] = @isActive
					where [UserId] = @userId or [Email] = @email

				End
				
				

			Else

			Begin 


			-- Insert Users Table  

					 Insert Into [AppIdentity].[Users]
				(
					[FirstName],[MiddleName], [lastName], [DisplayName], [UserName], [Email], [PhoneNumber],
					[ClearPassword], [PasswordHash], [LastLoginDate], [IsLocked], [AccessFailedCount],[IsActive]
				)
				Select @firstName, @middleName,  @lastName, @displayName, @userName, @email, @phoneNumber,
						@clearPassword, @passwordHash, @lastLoginDate, @isLocked, @accessFailedCount, @isActive

		Set @lastIdentity = SCOPE_IDENTITY()

			End

			
	Commit Transaction
		-- Returning

		Select [UserId],[FirstName],[MiddleName], [lastName], [DisplayName], [UserName], [Email], [PhoneNumber],
					[ClearPassword], [PasswordHash], [LastLoginDate], [IsLocked], [AccessFailedCount], [IsActive]
					From [AppIdentity].[Users]
					where Email = @email and [IsActive] = 1
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
