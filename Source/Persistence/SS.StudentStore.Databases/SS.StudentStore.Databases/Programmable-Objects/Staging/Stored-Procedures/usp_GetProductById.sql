Create Procedure [Staging].[usp_GetProductById]
@productId bigInt, 
@userEmail nvarchar(100)  -- productMaufacturer = User email

As
Begin

Select * from [Staging].[vwStagingProduct] where ProductId = @productId and ProductManufacturer = @userEmail

End