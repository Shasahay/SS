Create Table [Order].[DeliveryMethod](
[DeliveryMethodId] int Identity(1,1) Not Null,
[ShortName] nvarchar(20),
[Description] nvarchar(max) Null,
[DeliveryTime] Nvarchar(30) null,
[Price] Decimal(7,2) null,
[IsActive] bit default(1),
constraint [PK_DeliveryMethod_DeliveryMethodId] Primary key clustered (DeliveryMethodId asc) 
)

