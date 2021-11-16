using Microsoft.Data.SqlClient;
using SS.StudentStore.Services.Core.Constants;
using SS.StudentStore.Services.Core.Entities;
using SS.StudentStore.Services.Core.Interfaces.Infrastructures;
using SS.StudentStore.Services.Infrastructure.DBContext;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SS.StudentStore.Services.Infrastructure.Providers
{
    public class OrderProvider : BaseProvider<Order>, IOrderProvider
    {
        private const string SCHEMA = Constant.Schema_Order;
        public OrderProvider(OrderDBContext dbContext) : base(dbContext)    {   }
        public Task<Order> AddOrder(Order order, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<OrderView> CreateOrder(Order order, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<OrderView>> CreateOrder(Order order, IEnumerable<OrderItem> orderItems, CancellationToken cancellationToken)
        {
            var sqlParams = new List<SqlParameter>
            {
                new SqlParameter("@orderId", order.OrderId.GetValueOrDefault(0) == 0 ? (object)DBNull.Value : order.OrderId) { SqlDbType = SqlDbType.BigInt, IsNullable= true, Direction = ParameterDirection.Input},
                new SqlParameter("@userEmail", order.UserEmail) { SqlDbType = SqlDbType.NVarChar, IsNullable = true, Direction = ParameterDirection.Input},
                new SqlParameter("@userId", order.UserId.GetValueOrDefault(0) == 0 ? (object)DBNull.Value : order.UserId) { SqlDbType = SqlDbType.BigInt, IsNullable= true, Direction = ParameterDirection.Input},
                new SqlParameter("@addressId", order.AddressId) { SqlDbType = SqlDbType.BigInt, Direction = ParameterDirection.Input},
                new SqlParameter("@subTotal",order.SubTotal) { SqlDbType = SqlDbType.Decimal, Direction = ParameterDirection.Input},
                new SqlParameter("@status",order.Status) { SqlDbType = SqlDbType.NVarChar, Direction = ParameterDirection.Input},
                new SqlParameter("@paymentIntentId",string.IsNullOrEmpty(order.PaymentIntentId)? (object)DBNull.Value : order.PaymentIntentId) { SqlDbType = SqlDbType.NVarChar, Direction = ParameterDirection.Input},
                new SqlParameter("@deliveryMethodId",order.DeliveryMethodId) { SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Input},
                new SqlParameter("@createdBy",order.CreatedBy) { SqlDbType = SqlDbType.NVarChar, Direction = ParameterDirection.Input},
                new SqlParameter("@createdDate",order.CreatedDate) { SqlDbType = SqlDbType.DateTime, Direction = ParameterDirection.Input},

                await this.BuildTableParameter(new StoredProcParam()
                                                {
                                                    PARAMETER_NAME = "@orderItemTable",
                                                    USER_DEFINED_TYPE_SCHEMA = "Order",
                                                    USER_DEFINED_TYPE_NAME = "OrderItemTableType",
                                                    PARAMATER_MODE = Constant.StoredProcedure_Parameter_Mode_In
                                                }, orderItems
                                              )
            };

            var strParam = "@orderId, @userEmail, @userId, @addressId, @subTotal, @status, @paymentIntentId, @deliveryMethodId, @createdBy, @createdDate, @orderItemTable";

            return await this.ExecuteQueryForOtherEntities<OrderView>(SCHEMA, "[usp_CreateOrder]", strParam, sqlParams, cancellationToken);
        }

        public async Task<IEnumerable<OrderView>> GetOrder(string userEmail, CancellationToken cancellationToken)
            => await this.ExecuteQueryForOtherEntities<OrderView>(SCHEMA, "usp_GetOrderByUserEmail", "@userEmail", new SqlParameter("@userEmail", userEmail), cancellationToken);

        public async Task<IEnumerable<OrderView>> GetOrder(long orderId, CancellationToken cancellationToken)
        => await this.ExecuteQueryForOtherEntities<OrderView>(SCHEMA, "usp_GetOrderById", "@orderId", new SqlParameter("@orderId", orderId), cancellationToken);
    }
}
