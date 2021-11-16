Create Procedure [Order].[usp_GetOrderByUserEmail]
@userEmail nvarchar(70)

As Begin

	Select	* From [Order].[vwOrderView]
	where [UserEmail] = @userEmail

End 

 