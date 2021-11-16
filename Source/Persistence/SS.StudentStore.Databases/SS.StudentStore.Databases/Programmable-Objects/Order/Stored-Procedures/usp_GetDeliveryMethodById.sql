Create Procedure [Order].[usp_GetDeliveryMethodById]
@deliveryMethodId int
As 
Begin 

	Select	[DeliveryMethodId],
			[ShortName],
			[Description],
			[DeliveryTime],
			[Price],
			[IsActive]

			From [Order].[DeliveryMethod]
			Where [DeliveryMethodId] = @deliveryMethodId
			And
			[IsActive] = 1

End



