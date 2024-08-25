using Microsoft.AspNetCore.Mvc;
using MoviesHubAPI.Models;
using MoviesHubAPI.Services.UserDtos;

namespace MoviesHubAPI.Services.Users
{
    public interface IUserService
    {
        public  Task<User> RegisterUser(string name, string email, string password);

        public Task<User> UpdateUser(int id, string name, string email, string password);

        public Task<User> GetUser(int id);

        public Task<List<User>> GetUsers();

        public Task<bool> DeleteUser(int id);
        public Task<ActionResult> Login(LoginDto model);
        public Task<string> AddRating(int userId, int mediaId, int rating);
        public Task<string> AddAction(int userId, int mediaId, string action);
        public Task<string> RemoveAction(int userId, int mediaId, string action);

        public Task<List<string>> LikeMedia(int userid); 
        public Task<List<string>> ViewMedia(int userid);
        
    }
}
