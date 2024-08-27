using Microsoft.AspNetCore.Mvc;
using MoviesHubAPI.Models;
using MoviesHubAPI.Services.DTOS;
using MoviesHubAPI.Services.UserDtos;
using MoviesHubAPI.Services.Users.Responses;

namespace MoviesHubAPI.Services.Users
{
    public interface IUserService
    {
        public  Task<User> RegisterUser(string name, string email, string password);

        public Task<User> UpdateUser(int id, string name, string email, string password);

        public Task<User> GetUser(int id);

        public Task<List<User>> GetUsers();

        public Task<bool> DeleteUser(int id);
        public Task<userResponse> Login(LoginDto model);
        public Task<string> AddRating(int userId, int mediaId, int rating);
        public Task<string> AddAction(int userId, AddActionDto infoAction);
        public Task<string> RemoveAction(int userId, int mediaId, string action);

        public Task<List<int>> LikeMedia(int userid); 
        public Task<List<int>> ViewMedia(int userid);
        
    }
}
