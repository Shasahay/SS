CREATE TABLE [Store].[Basket](
	[BasketId] [bigint] IDENTITY(1,1) NOT NULL,
	[BasketUId] [nvarchar](100) NULL,
	[DeliveryMethodId] [int] NULL,
	[ClientSecret] [nvarchar](100) NULL,
	[PaymentIntendId] [nvarchar](50) NULL,
	[ShippingPrice] [decimal](5, 2) NULL,
	[IsActive] [bit] NULL Default(1),
	[IsDelete] [bit] NULL Default(0),
	[CreatedBy] [nvarchar](100) NULL,
	[CreatedDate] [datetime2](7) NULL Default Getdate(),
	[ModifiedBy] [nvarchar](100) NULL,
	[ModifiedDate] [datetime2](7) NULL,
CONSTRAINT [PK_Basket_BasketId] PRIMARY KEY CLUSTERED([BasketId] ASC)
)