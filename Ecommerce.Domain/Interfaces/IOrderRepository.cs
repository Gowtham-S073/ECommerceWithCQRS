using Ecommerce.Domain.Models.CoreModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain.Interfaces
{
    public interface IOrderRepository
    {
        Task AddOrder(Order order);
        Task<List<Order>> GetAllOrders();
        Task<Order> GetOrderById(Guid orderId);
        Task<Order> UpdateOrder(Order order);
        Task<Order> DeleteOrder(Guid orderId);
    }
}
