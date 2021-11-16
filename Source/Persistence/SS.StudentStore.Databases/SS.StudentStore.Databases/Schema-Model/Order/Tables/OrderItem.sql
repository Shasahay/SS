CREATE TABLE [Order].[OrderItem](
	[OrderItemId] [bigint] IDENTITY(1,1) NOT NULL,
	[OrderId] [bigint] NULL,
	[ProductId] [bigint] NULL,
	[ProductTypeId] int Null,
	[Quantity] [int] NULL,
	[Price] [decimal](7, 2) NULL,
	[NumberOfMonths] Int Null,
	[CreatedDate] [datetime2](7) NULL,
	[IsActive] [bit] NULL,
CONSTRAINT [PK_OrderItem_OrderItemId] Primary key clustered ([OrderItemId] asc),
CONSTRAINT [FK_OrderItem_Order_OrderId] foreign Key ([OrderId]) references [Order].[Order]([OrderId]),
)
GO


