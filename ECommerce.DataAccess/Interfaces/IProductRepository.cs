using Ecommerce.Domain.Models.CoreModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DataAccess.Interfaces
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllProducts();
        Task<Product> GetProductById(Guid productId);
        Task AddProduct(Product product);
        Task UpdateProduct(Product product);
        Task DeleteProduct(Guid productId);
    }
}
