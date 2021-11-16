using Microsoft.Data.SqlClient;
using SS.StudentStore.Services.Core.Constants;
using SS.StudentStore.Services.Core.Entities;
using SS.StudentStore.Services.Core.Interfaces.Infrastructures;
using SS.StudentStore.Services.Infrastructure.DBContext;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SS.StudentStore.Services.Infrastructure.Providers
{
    public class DeliveryMethodProvider : BaseProvider<DeliveryMethod>, IDeliveryMethodProvider
    {
        private const string SCHEMA = Constant.Schema_Order;
        public DeliveryMethodProvider(OrderDBContext dbContext) : base(dbContext)  {  }

        public async Task<DeliveryMethod> GetDeliveryMethod(int deliveryMethodId, CancellationToken cancellationToken)
            => await this.ExecuteQueryForEntity(SCHEMA, "usp_GetDeliveryMethodById", "@deliveryMethodId", new SqlParameter("@deliveryMethodId", deliveryMethodId), cancellationToken);

        public async Task<IEnumerable<DeliveryMethod>> GetDeliveryMethods(CancellationToken cancellationToken)
            => await this.ExecuteQueryForEntities(SCHEMA, "[usp_GetDeliveryMethods]", cancellationToken);
    }
}
