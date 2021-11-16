Create Procedure [Order].[usp_GetOrderById]
@orderId bigint

As Begin

	Select	* From [Order].[vwOrderView]
	where [OrderId] = @orderId

End 