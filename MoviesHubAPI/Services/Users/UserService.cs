using EntityFrameworkExample.Context;
using Microsoft.EntityFrameworkCore;
using MoviesHubAPI.Models.UserF;

namespace MoviesHubAPI.Services.Users
{
    public class UserService : IUserService
    {
        private readonly IContextDB _context;
        public UserService(IContextDB context)
        {
            _context = context;
        }

        public async Task<User> RegisterUser(string name, string email, string password)
        {
            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);
            var user = new User { Name = name, Email = email, Password = hashedPassword };
            _context.Users.Add(user);
            await _context.SaveChangesAsync(true);
            return user;
        }

        public async Task<User> UpdateUser(int id, string name, string email, string password)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null) return null;

            user.Name = name;
            user.Email = email;
            user.Password = BCrypt.Net.BCrypt.HashPassword(password);

            _context.Users.Update(user);
            await _context.SaveChangesAsync(true);

            return user;
        }

        public async Task<User> GetUser(int id)
        {
            var resp = await this._context.Users.FindAsync(id);
            return resp;
        }

        public async Task<List<User>> GetUsers()
        {
            return await this._context.Users.ToListAsync();
        }
        public async Task<bool> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null) return false;

            _context.Users.Remove(user);
            await _context.SaveChangesAsync(true);
            return true;
        }
        
        public async Task<User> Login(string email, string password)
        {
            var user = await _context.Users.SingleOrDefaultAsync(u => u.Email == email);
            if (user != null && BCrypt.Net.BCrypt.Verify(password, user.Password))
            {
                return user;
            }
            return null;
        }
    }
}
