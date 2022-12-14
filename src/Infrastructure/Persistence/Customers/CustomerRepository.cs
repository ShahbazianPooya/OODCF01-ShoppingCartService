using CustomerBasketManagement.Domain.Customers;
using CustomerBasketManagement.Domain.Customers.Repository;
using CustomerBasketManagement.Domain.Customers.ValueObjects;
using Dapper;
using System.Data;

namespace CustomerBasketManagement.Infrastructure.Persistence.Customers
{
    public class CustomerRepository : Repository<Customer, int>, ICustomerRepository
    {
        private readonly IDbConnection _dbConnection;

        public CustomerRepository(IDbConnection dbConnection)
            : base(dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public override async Task AddAsync(Customer customer)
        {
            var customerId = await InsertCustomer(customer);

            await InsertAddress(customer.Address, customerId);

            await InsertCreditCard(customer.CreditCard, customerId);
        }

        private async Task<int> InsertCustomer(Customer customer)
        {
            var insertCustomer = @"INSERT INTO [dbo].[Customers]
                                   ([FullName])
                                   VALUES
                                   (@CustomerName);
                                   SELECT CAST(SCOPE_IDENTITY() AS INT)";

            return await _dbConnection.QuerySingleAsync<int>(insertCustomer, new { CustomerName = customer.FullName });
        }

        private async Task<int> InsertAddress(Address address, int customerId)
        {
            var insertAdress = @"INSERT INTO [dbo].[Addresses]
                                    ([FullName]
                                    ,[CustomerId])
                                    VALUES
                                    (@AddressFullName
                                    ,@CustomerId)";

            return await _dbConnection.ExecuteAsync(insertAdress, new { AddressFullName = address.FullName, CustomerId = customerId });
        }

        private async Task<int> InsertCreditCard(CreditCard creditCard, int customerId)
        {
            var parameters = new
            {
                CardBalance = creditCard.CardBalance,
                ExpirationDate = creditCard.ExpirationDate,
                OwnerName = creditCard.OwnerName,
                CardNumber = creditCard.CardNumber,
                CustomerId = customerId
            };

            var insertCreditCard = @"INSERT INTO [dbo].[CreditCards]
                                         ([CardBalance]
                                         ,[ExpirationDate]
                                         ,[OwnerName]
                                         ,[CardNumber]
                                         ,[CustomerId])
                                   VALUES
                                         (@CardBalance
                                         ,@ExpirationDate
                                         ,@OwnerName
                                         ,@CardNumber
                                         ,@CustomerId)";

            return await _dbConnection.ExecuteAsync(insertCreditCard, parameters);
        }
    }
}
