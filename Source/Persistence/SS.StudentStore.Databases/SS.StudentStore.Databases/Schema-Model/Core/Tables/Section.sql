Create Table [Core].[Section](
[SectionId] int Identity(1,1)  Not null,
	[Name] nvarchar(100) not null,
	[Description] nvarchar(max) null,
	[IsActive] bit default(1),
	[CreatedBy] nvarchar(100) null,
	[CreatedDate]  datetime2 default(getdate()),
	[ModifiedBy] nvarchar(100) null,
	[ModifiedDate] Datetime2 null,
	constraint [PK_Section_SectionId] Primary key clustered (SectionId asc) 
)