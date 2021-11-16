using SS.StudentStore.Services.Core.Constants;
using SS.StudentStore.Services.Core.Entities;
using SS.StudentStore.Services.Core.Interfaces.Infrastructures;
using SS.StudentStore.Services.Infrastructure.DBContext;
using System;
using System.Collections.Generic;
using System.Data;
//using System.Data.SqlClient;
using Microsoft.Data.SqlClient;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SS.StudentStore.Services.Infrastructure.Providers
{
    public class BasketProvider : BaseProvider<Basket>, IBasketProvider
    {
        private const string SCHEMA = Constant.Schema_Store;
        public BasketProvider(StoreDBContext dbContext): base(dbContext)    {   }

        public async Task<bool> AddBasket(Basket basket, IEnumerable<BasketItem> basketItems, string user, CancellationToken cancellationToken)
            => await AddBasket(basket.BasketId, basket.BasketUId, basket.DeliveryMethodId.Value, basket.ClientSecret, basket.PaymentIntendId, basket.ShippingPrice.Value, basketItems, user, cancellationToken);

        public async Task<bool> AddBasket(long basketId, string basketUId, int deliveryMethodId, string clientSecret, string paymentIntendId, decimal shippingPrice, IEnumerable<BasketItem> basketItems, string user, CancellationToken cancellationToken)
        {
            var sqlParams = new List<SqlParameter>
            {
                new SqlParameter("@basketId", basketId == 0 ? (object)DBNull.Value : basketId) { SqlDbType = SqlDbType.BigInt, IsNullable= true, Direction = ParameterDirection.Input},
                new SqlParameter("@basketUId", basketUId) { SqlDbType = SqlDbType.NVarChar, Direction = ParameterDirection.Input},
                new SqlParameter("@deliveryMethodId", deliveryMethodId == 0 ? (object)DBNull.Value : deliveryMethodId) { SqlDbType = SqlDbType.Int, IsNullable = true, Direction = ParameterDirection.Input},
                new SqlParameter("@clientSecret", string.IsNullOrEmpty(clientSecret) ? (object)DBNull.Value : clientSecret) { SqlDbType = SqlDbType.NVarChar, IsNullable = true, Direction = ParameterDirection.Input},
                new SqlParameter("@paymentIntendId", string.IsNullOrEmpty(paymentIntendId) ? (object)DBNull.Value : paymentIntendId) { SqlDbType = SqlDbType.NVarChar, IsNullable = true, Direction = ParameterDirection.Input},
                new SqlParameter("@shippingPrice", shippingPrice == 0 ? (object)DBNull.Value : shippingPrice) { SqlDbType = SqlDbType.Decimal, IsNullable= true, Direction = ParameterDirection.Input},


                await this.BuildTableParameter(new StoredProcParam()
                                                {
                                                    PARAMETER_NAME = "@basketItemTable",
                                                    USER_DEFINED_TYPE_SCHEMA = SCHEMA,
                                                    USER_DEFINED_TYPE_NAME = "BasketItemTableType",
                                                    PARAMATER_MODE = Constant.StoredProcedure_Parameter_Mode_In
                                                }, basketItems
                                              ),
                new SqlParameter("@loggedUser", String.IsNullOrEmpty(user) ? (object)DBNull.Value : user)  { SqlDbType = SqlDbType.NVarChar, Direction = ParameterDirection.Input}
            };

            var strParam = "@basketId, @basketUId, @deliveryMethodId, @clientSecret, @PaymentIntendId, @ShippingPrice, @basketItemTable, @loggedUser";
            
           return await this.ExecuteNonQuery(SCHEMA, "usp_AddBasket", strParam, sqlParams, cancellationToken);
        }

        public async Task<IEnumerable<BasketView>> AddOrUpdateBasket(long basketId, string basketUId, int deliveryMethodId, string clientSecret, string paymentIntendId, decimal shippingPrice, IEnumerable<BasketItem> basketItems, string user, CancellationToken cancellationToken)
        {
            var sqlParams = new List<SqlParameter>
            {
                new SqlParameter("@basketId", basketId == 0 ? (object)DBNull.Value : basketId) { SqlDbType = SqlDbType.BigInt, IsNullable= true, Direction = ParameterDirection.Input},
                new SqlParameter("@basketUId", basketUId) { SqlDbType = SqlDbType.NVarChar, Direction = ParameterDirection.Input},
                new SqlParameter("@deliveryMethodId", deliveryMethodId == 0 ? (object)DBNull.Value : deliveryMethodId) { SqlDbType = SqlDbType.Int, IsNullable = true, Direction = ParameterDirection.Input},
                new SqlParameter("@clientSecret", string.IsNullOrEmpty(clientSecret) ? (object)DBNull.Value : clientSecret) { SqlDbType = SqlDbType.NVarChar, IsNullable = true, Direction = ParameterDirection.Input},
                new SqlParameter("@paymentIntendId", string.IsNullOrEmpty(paymentIntendId) ? (object)DBNull.Value : paymentIntendId) { SqlDbType = SqlDbType.NVarChar, IsNullable = true, Direction = ParameterDirection.Input},
                new SqlParameter("@shippingPrice", shippingPrice == 0 ? (object)DBNull.Value : shippingPrice) { SqlDbType = SqlDbType.Decimal, IsNullable= true, Direction = ParameterDirection.Input},


                await this.BuildTableParameter(new StoredProcParam()
                                                {
                                                    PARAMETER_NAME = "@basketItemTable",
                                                    USER_DEFINED_TYPE_SCHEMA = SCHEMA,
                                                    USER_DEFINED_TYPE_NAME = "BasketItemTableType",
                                                    PARAMATER_MODE = Constant.StoredProcedure_Parameter_Mode_In
                                                }, basketItems
                                              ),
                new SqlParameter("@loggedUser", String.IsNullOrEmpty(user) ? (object)DBNull.Value : user)  { SqlDbType = SqlDbType.NVarChar, Direction = ParameterDirection.Input}
            };

            var strParam = "@basketId, @basketUId, @deliveryMethodId, @clientSecret, @PaymentIntendId, @ShippingPrice, @basketItemTable, @loggedUser";

            return await this.ExecuteQueryForOtherEntities<BasketView>(SCHEMA, "usp_AddOrUpdateBasket", strParam, sqlParams, cancellationToken);
        }

        public async Task<bool> DeleteBasket(string basketUId, CancellationToken cancellationToken)
            => await this.ExecuteNonQuery(SCHEMA, "usp_DeleteBasketByUId", "@basketUId", new SqlParameter("@basketUId", basketUId), cancellationToken);

        public async Task<Basket> GetBasket(long basketId, CancellationToken cancellationToken)
            => await this.ExecuteQueryForEntity(SCHEMA, "usp_GetBasketById", "@basketId", new SqlParameter("@basketId", basketId), cancellationToken);
        public  async Task<Basket> GetBasket(string basketUId, CancellationToken cancellationToken)
            => await this .ExecuteQueryForEntity(SCHEMA, "usp_GetBasketByUId", "@basketUId", new SqlParameter("@basketUId", basketUId), cancellationToken);

        public async Task<IEnumerable<BasketItem>> GetBasketItems(string basketUId, CancellationToken cancellationToken)
            => await this.ExecuteQueryForOtherEntities<BasketItem>(SCHEMA, "usp_GetBasketItemByBasketUId", "@basketUId", new SqlParameter("@basketUId", basketUId), cancellationToken);

        public async Task<IEnumerable<BasketView>> GetBasketView(string basketUId, CancellationToken cancellationToken)
        => await this.ExecuteQueryForOtherEntities<BasketView>(SCHEMA, "usp_GetBasketByBasketUId", "@basketUId", new SqlParameter("@basketUId", basketUId), cancellationToken);

        public Task<Basket> UpdateBasket(string basketUId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
