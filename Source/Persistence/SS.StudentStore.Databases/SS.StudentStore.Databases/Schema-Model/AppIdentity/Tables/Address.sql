Create Table [AppIdentity].[Address] (
	[AddressId] bigint Identity(1,1)  Not null,
	[UserId] bigint not null,
	[AddressTypeId] int not null,
	[FirstName] nvarchar(30) null,
	[LastName]  nvarchar(30) null,
	[HouseNumber] nvarchar(30) null,
	[Apartment] nvarchar(100) null,
	[Street] nvarchar(100) null,
	[Colony] nvarchar(100) null,
	[Locality] nvarchar(200) null,
	[City] nvarchar(70) null,
	[State] nvarchar(70) null,
	[PinCode] nvarchar(6) null,
	[Country] nvarchar(100) null,
	[LandMark] nvarchar(100) null,
	[FullAddress] nvarchar(max) null,
	[IsActive] bit default(1),
	constraint [PK_Address_AddressId] Primary key clustered (AddressId asc),
	--constraint [FK_AddressType_AddressTypeId_Address_AddressId] Foreign key (AddressTypeId) References [AppIdentity].[AddressType](AddressTypeId)
	
	)