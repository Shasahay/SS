Create Procedure [Staging].[usp_GetProductByUser]
@userEmail nvarchar (100)  -- productMaufacturer = User email

As
Begin

Select * from [Staging].[vwStagingProduct] where ProductManufacturer = @userEmail

End