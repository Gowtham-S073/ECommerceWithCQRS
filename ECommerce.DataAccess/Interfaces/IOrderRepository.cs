using Ecommerce.Domain.Models.CoreModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DataAccess.Interfaces
{
    public interface IOrderRepository
    {
        Task AddOrder(Order order);
    
    }
}
