using Dapper;
using Ecommerce.Domain.Models.CoreModels;
using ECommerce.Domain.Interfaces;
using Microsoft.Data.SqlClient;
using System.Data;


namespace ECommerce.Infrastructure.Repositories
{

    public class UserRepository : IUserRepository
    {
        private readonly IDbConnection _dbConnection;

        public UserRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<List<User>> GetAllUsers()
        {
            var sql = "SELECT * FROM Users";
            var result = await _dbConnection.QueryAsync<User>(sql);
            return result.AsList();
        }

        public async Task<User> GetUserById(Guid userId)
        {
            var sql = "SELECT * FROM Users WHERE UserID = @UserID";
            return await _dbConnection.QueryFirstOrDefaultAsync<User>(sql, new { UserID = userId });
        }

        #region To add the New User
        public async Task AddUser(User user)
        {
            try
            {
                if (user == null)
                {
                    throw new ArgumentNullException(nameof(user), "User details must not be empty");
                }
                var sql = "INSERT INTO Users (UserID, Username, FirstName, LastName, Email, Password, Hashkey, Address, PhoneNumber) VALUES (@UserID, @Username, @FirstName, @LastName, @Email, @Password, @Hashkey, @Address, @PhoneNumber)";
                await _dbConnection.ExecuteAsync(sql, user);
            }
            catch (SqlException ex)
            {
                throw new Exception("An error occurred while executing the SQL command.", ex);
            }
        }

        #endregion

        public async Task UpdateUser(User user)
        {
            var sql = "UPDATE Users SET Username = @Username, FirstName = @FirstName, LastName = @LastName, Email = @Email, Password = @Password, Hashkey = @Hashkey, Address = @Address, PhoneNumber = @PhoneNumber WHERE UserID = @UserID";
            await _dbConnection.ExecuteAsync(sql, user);
        }

        public async Task DeleteUser(Guid userId)
        {
            var sql = "DELETE FROM Users WHERE UserID = @UserID";
            await _dbConnection.ExecuteAsync(sql, new { UserID = userId });
        }
    }
}
