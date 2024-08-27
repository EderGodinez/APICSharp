using EntityFrameworkExample.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration.UserSecrets;
using MoviesHubAPI.Helpers;
using MoviesHubAPI.Models;
using MoviesHubAPI.Services.DTOS;
using MoviesHubAPI.Services.UserDtos;
using MoviesHubAPI.Services.Users.Responses;


namespace MoviesHubAPI.Services.Users
{
    public class UserService : IUserService
    {
        private readonly IContextDB _context;
        private readonly ILogger<UserService> _logger;
        
        public UserService(IContextDB context, ILogger<UserService> logger)
        {
           
            _context = context;
            _logger = logger;
        }

        public async Task<User> RegisterUser(string name, string email, string password)
        {
            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);
            var user = new User { Name = name, Email = email, Password = hashedPassword,Role="user" };
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
            try
            {
                var user = await _context.Users
                    .Include(u => u.Ratings)
                    .Include(u => u.UserActions)
                    .FirstOrDefaultAsync(u => u.Id == id);

                if (user == null)
                {
                    throw new DllNotFoundException($"User con id {id} no encontrado");
                }

                return user;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while fetching user with id {id}");
                throw;
            }
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

        public async Task<userResponse> Login(LoginDto model)
        {
            var user = await _context.Users.SingleOrDefaultAsync(u => u.Email == model.Email);
            if (user == null || !BCrypt.Net.BCrypt.Verify(model.Password, user.Password))
            {
                return null;
            }

            userResponse response = new userResponse
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                Role = user.Role,
                FavoritesMediaId= await LikeMedia(user.Id)
            };

            return response; 
        }


        public async Task<List<int>> LikeMedia(int userid)
        {
            try
            {
                var resp = await _context.UserActions
                    .Where(u => u.UserId == userid && u.TypeAction.Equals("L"))
                    .Select(u => u.MediaId)
                    .ToListAsync();

                return resp;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener medios con 'me gusta' para el usuario {userid}: {ex.Message}");
                return new List<int>(); 
            }
        }

        public async Task<List<int>> ViewMedia(int userid)
        {
            try
            {
                var resp = await _context.UserActions
                    .Where(u => u.UserId == userid && u.TypeAction == "V")
                    .Select(u => u.MediaId)
                    .ToListAsync();

                return resp;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener medios vistos para el usuario {userid}: {ex.Message}");
                return new List<int>(); 
            }
        }
        public async Task<string> AddRating(int userId, int mediaId, int rating)
        {
            try
            {
                var existingRating = await _context.Ratings
                    .FirstOrDefaultAsync(r => r.UserId == userId && r.MediaId == mediaId);

                if (existingRating != null)
                {
                    existingRating.Rate = (byte)rating;
                    _context.Ratings.Update(existingRating);
                }
                else
                {
                    var newRating = new Rating
                    {
                        UserId = userId,
                        MediaId = mediaId,
                        Rate = (byte)rating
                    };
                    await _context.Ratings.AddAsync(newRating);
                }

                await _context.SaveChangesAsync(true);
                return "Rating added/updated successfully";
            }
            catch (Exception ex)
            {
                // Log exception
                return $"Error while adding/updating rating: {ex.Message}";
            }
        }

        public async Task<string> AddAction(int userId,AddActionDto infoAction)
        {
            try
            {
                var existingAction = await _context.UserActions
                    .FirstOrDefaultAsync(a => a.UserId == userId && a.MediaId == infoAction.MediaId && a.TypeAction == infoAction.Action);

                if (existingAction != null)
                {
                    return "Accion solicitada ya existe";
                }
                else
                {
                    var newAction = new UserAction
                    {
                        UserId = userId,
                        MediaId = infoAction.MediaId,
                        TypeAction = infoAction.Action
                    };
                    await _context.UserActions.AddAsync(newAction);
                    await _context.SaveChangesAsync(true);
                    return "Accion de usuario agregado exitosamente";
                }
            }
            catch (Exception ex)
            {
                return $"Error while adding action: {ex.Message}";
            }
        }

        public async Task<string> RemoveAction(int userId, int mediaId, string action)
        {
            try
            {
                var actionToRemove = await _context.UserActions
                    .FirstOrDefaultAsync(a => a.UserId == userId && a.MediaId == mediaId && a.TypeAction == action);

                if (actionToRemove != null)
                {
                    _context.UserActions.Remove(actionToRemove);
                    await _context.SaveChangesAsync(true);
                    return "Action removed successfully";
                }
                else
                {
                    return "Action not found";
                }
            }
            catch (Exception ex)
            {
                // Log exception
                return $"Error while removing action: {ex.Message}";
            }
        }

       
    }
}
