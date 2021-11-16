Create Table [AppIdentity].[Users](
		[UserId] bigint Identity(1,1)  Not null,
	 	[FirstName] nvarchar(30) null,
		[MiddleName] nvarchar(30) null,
		[lastName] nvarchar(30) null,
		[DisplayName] nvarchar(70) null,
		[UserName] nvarchar(30) null,
		[Email] nvarchar(30) Not null,
		[PhoneNumber] nvarchar(12) null,
		[ClearPassword] nvarchar(100) null,
		[PasswordHash] nvarchar(100) null,
		[LastLoginDate] datetime2 default GetUTCDate(),
		[IsLocked] bit null default 0,
		[AccessFailedCount] int null,
		[IsActive] bit default(1),
		constraint [PK_Usres_UserId] Primary key clustered ([UserId] asc),
		Constraint [UK_Users_Email] Unique ([Email])
)