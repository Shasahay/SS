Create Table [Order].[Order](
[OrderId] BigInt Identity(1,1) Not Null,
[UserId] BigInt,
[UserEmail] nvarchar(70),
[AddressId] BigInt,
[SubTotal] Decimal(7,2),
[Status] nvarchar(20),
[PaymentIntentId] nvarchar(100),
[DeliveryMethodId] Int,
[CreatedBy] nvarchar(70),
[CreatedDate] Datetime2 default(getdate()),
[IsActive] bit default(1),
constraint [PK_Order_OrderId] Primary key clustered (OrderId asc) 
)
