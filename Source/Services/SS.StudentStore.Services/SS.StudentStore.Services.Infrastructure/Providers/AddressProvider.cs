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
    public class AddressProvider : BaseProvider<Address>, IAddressProvider
    {
        private const string SCHEMA = Constant.Schema_AppIdentity;
        private const int defaultAddressType = 1; // primary address
        public AddressProvider(AppIdentityDBContext dbContext) : base(dbContext) { }

        public async Task<Address> AddAddress(Address address, CancellationToken cancellationToken)
        {
            var sqlParams = new List<SqlParameter>
            {

                new SqlParameter("@addressId", address.AddressId.GetValueOrDefault() == 0 ? (object)DBNull.Value : address.AddressId.Value) { SqlDbType = SqlDbType.BigInt, IsNullable= true, Direction = ParameterDirection.Input},
                new SqlParameter("@userId", address.UserId.Value ) { SqlDbType = SqlDbType.BigInt, IsNullable= true, Direction = ParameterDirection.Input},
                new SqlParameter("@addressTypeId", address.AddressTypeId.GetValueOrDefault() == 0 ? defaultAddressType : address.AddressTypeId.Value) { SqlDbType = SqlDbType.Int, IsNullable= true, Direction = ParameterDirection.Input},
                new SqlParameter("@firstName", string.IsNullOrEmpty(address.FirstName) ? (object)DBNull.Value : address.FirstName) { SqlDbType = SqlDbType.NVarChar, Direction = ParameterDirection.Input},
                new SqlParameter("@lastName", string.IsNullOrEmpty(address.LastName)? (object)DBNull.Value : address.LastName) { SqlDbType = SqlDbType.NVarChar, IsNullable = true, Direction = ParameterDirection.Input},
                new SqlParameter("@houseNumber", address.HouseNumber) { SqlDbType = SqlDbType.NVarChar, Direction = ParameterDirection.Input},
                new SqlParameter("@apartment", string.IsNullOrEmpty(address.Apartment)? (object)DBNull.Value : address.Apartment) { SqlDbType = SqlDbType.NVarChar, Direction = ParameterDirection.Input},
                new SqlParameter("@street", string.IsNullOrEmpty(address.State)? (object)DBNull.Value : address.State) { SqlDbType = SqlDbType.NVarChar, Direction = ParameterDirection.Input},
                new SqlParameter("@colony", string.IsNullOrEmpty(address.Colony)? (object)DBNull.Value : address.Colony) { SqlDbType = SqlDbType.NVarChar, Direction = ParameterDirection.Input},
                new SqlParameter("@locality", string.IsNullOrEmpty(address.Locality)? (object)DBNull.Value : address.Locality) { SqlDbType = SqlDbType.NVarChar, Direction = ParameterDirection.Input},
                new SqlParameter("@city", address.City) { SqlDbType = SqlDbType.NVarChar, Direction = ParameterDirection.Input},
                new SqlParameter("@state", address.State) { SqlDbType = SqlDbType.NVarChar, Direction = ParameterDirection.Input},
                new SqlParameter("@pinCode", address.PinCode) { SqlDbType = SqlDbType.NVarChar, Direction = ParameterDirection.Input},
                new SqlParameter("@country", string.IsNullOrEmpty(address.Country)? (object)DBNull.Value : address.Country) { SqlDbType = SqlDbType.NVarChar, Direction = ParameterDirection.Input},
                new SqlParameter("@fullAddress", string.IsNullOrEmpty(address.FullAddress)? (object)DBNull.Value : address.FullAddress) { SqlDbType = SqlDbType.NVarChar, Direction = ParameterDirection.Input},
                new SqlParameter("@landMark", string.IsNullOrEmpty(address.LandMark)? (object)DBNull.Value : address.LandMark) { SqlDbType = SqlDbType.NVarChar, Direction = ParameterDirection.Input},
                new SqlParameter("@isActive",  address.IsActive == null? true : address.IsActive) { SqlDbType = SqlDbType.Bit, IsNullable= true, Direction = ParameterDirection.Input},
            };

            var strParam = "@addressId, @userId, @addressTypeId, @firstName, @lastName, @houseNumber, @apartment, @street, @colony, @locality, @city, @state, @pinCode, @country, @fullAddress, @landMark, @isActive";

            return await this.ExecuteQueryForEntity(SCHEMA, "usp_AddOrUpdateAddress", strParam, sqlParams, cancellationToken);
        }

        public async Task<Address> GetAddress(string email, CancellationToken cancellationToken)
            => await this.ExecuteQueryForEntity(SCHEMA, "usp_GetAddressByEmail", "@email", new SqlParameter("@email", email), cancellationToken);

        public async Task<Address> GetAddress(int userId, CancellationToken cancellationToken)
            => await this.ExecuteQueryForEntity(SCHEMA, "usp_GetAddressByUserId", "@userId", new SqlParameter("@userId", userId), cancellationToken);

        public async Task<Address> GetAddressByUserName(string userName, CancellationToken cancellationToken)
            => await this.ExecuteQueryForEntity(SCHEMA, "usp_GetAddressByUserName", "@userName", new SqlParameter("@userName", userName), cancellationToken);

        public Task<IEnumerable<Address>> GetAllAddress(string email, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
