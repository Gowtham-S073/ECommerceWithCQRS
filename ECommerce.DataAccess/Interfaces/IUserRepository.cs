using Ecommerce.Domain.Models.CoreModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DataAccess.Interfaces
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllUsers();
        Task<User> GetUserById(Guid userId);
        Task AddUser(User user);
        Task UpdateUser(User user);
        Task DeleteUser(Guid userId);
    }
}
