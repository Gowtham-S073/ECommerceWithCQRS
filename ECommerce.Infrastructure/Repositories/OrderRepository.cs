using Dapper;
using Ecommerce.Domain.Models.CoreModels;
using ECommerce.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly IDbConnection _dbConnection;

        public OrderRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

     
        public async Task AddOrder(Order order)
        {
            var sql = "INSERT INTO Orders (OrderID, UserID, OrderDate, Status) VALUES (@OrderID, @UserID, @OrderDate, @Status)";
            await _dbConnection.ExecuteAsync(sql, order);
        }

        public async Task<List<Order>> GetAllOrders()
        {
            var sql = "SELECT * FROM Orders";
            var result = await _dbConnection.QueryAsync<Order>(sql);
            return result.AsList();
        }

        public async Task<Order> GetOrderById(Guid orderId)
        {
            var sql = "SELECT * FROM Orders WHERE OrderID = @OrderID";
            return await _dbConnection.QueryFirstOrDefaultAsync<Order>(sql, new { OrderID = orderId });
        }

        public async Task UpdateOrder(Order order)
        {
            var sql = "UPDATE Orders SET UserID = @UserID, OrderDate = @OrderDate, Status = @Status WHERE OrderID = @OrderID";
            await _dbConnection.ExecuteAsync(sql, order);
        }

        public async Task DeleteOrder(Guid orderId)
        {
            var sql = "DELETE FROM Orders WHERE OrderID = @OrderID";
            await _dbConnection.ExecuteAsync(sql, new { OrderID = orderId });
        }

     
    }
}
