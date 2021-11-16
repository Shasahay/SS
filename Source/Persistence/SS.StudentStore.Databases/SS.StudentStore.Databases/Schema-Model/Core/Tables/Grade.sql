Create Table [Core].[Grade](
	[GradeId] int Identity(1,1) Not Null,
	[Name] nvarchar(30),
	[Description] nvarchar(2000),
	[IsActive] bit default(1),
	[CreatedBy] nvarchar(100) null,
	[CreatedDate]  datetime2 default(getdate()),
	[ModifiedBy] nvarchar(100) null,
	[ModifiedDate] Datetime2 null,
	Constraint [PK_Grade_GradeId] Primary Key Clustered (GradeId Asc)
)