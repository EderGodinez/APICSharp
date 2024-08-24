using Microsoft.EntityFrameworkCore;
using MoviesHubAPI.Models.UserF;

namespace MoviesHubAPI.Services.Users
{
    public interface IUserService
    {
        public  Task<User> RegisterUser(string name, string email, string password);

        public Task<User> UpdateUser(int id, string name, string email, string password);

        public Task<User> GetUser(int id);

        public Task<List<User>> GetUsers();

        public Task<bool> DeleteUser(int id);

        public Task<User> Login(string email, string password);
        
    }
}
