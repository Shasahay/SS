Create Procedure [Order].[usp_GetDeliveryMethods]
As 
Begin 

	Select	[DeliveryMethodId],
			[ShortName],
			[Description],
			[DeliveryTime],
			[Price],
			[IsActive]

			From [Order].[DeliveryMethod]
			Where [IsActive] = 1

End

Go