using Dapper;
using Ecommerce.Domain.Models.CoreModels;
using ECommerce.Domain.Interfaces;
using System.Data;

namespace ECommerce.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IDbConnection _dbConnection;

        public ProductRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<List<Product>> GetAllProducts()
        {
            var sql = "SELECT * FROM Products";
            var result = await _dbConnection.QueryAsync<Product>(sql);
            return result.AsList();
        }

        public async Task<Product> GetProductById(Guid productId)
        {
            var sql = "SELECT * FROM Products WHERE ProductID = @ProductID";
            return await _dbConnection.QueryFirstOrDefaultAsync<Product>(sql, new { ProductID = productId });
        }

        public async Task AddProduct(Product product)
        {
            var sql = "INSERT INTO Products (ProductID, Name, Description, Price, Quantity) VALUES (@ProductID, @Name, @Description, @Price, @Quantity)";
            await _dbConnection.ExecuteAsync(sql, product);
        }

        public async Task UpdateProduct(Product product)
        {
            var sql = "UPDATE Products SET Name = @Name, Description = @Description, Price = @Price, Quantity = @Quantity WHERE ProductID = @ProductID";
            await _dbConnection.ExecuteAsync(sql, product);
        }

        public async Task DeleteProduct(Guid productId)
        {
            var sql = "DELETE FROM Products WHERE ProductID = @ProductID";
            await _dbConnection.ExecuteAsync(sql, new { ProductID = productId });
        }
    }
}
