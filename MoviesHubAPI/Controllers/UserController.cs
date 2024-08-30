using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoviesHubAPI.Helpers;
using MoviesHubAPI.Models;
using MoviesHubAPI.Services.DTOS;
using MoviesHubAPI.Services.UserDtos;
using MoviesHubAPI.Services.Users;
namespace MoviesHubAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserService _userService;
        private readonly IAuthHelpers _authHelpers;
        /// <summary>
        /// Se inicializa el controllador <see cref="UserController"/> class.
        /// </summary>
        /// <param name="userService">Servicio para gestion de usuarios.</param>
        public UserController(IUserService userService, ILogger<UserController> logger, IAuthHelpers authHelper)
        {
            _authHelpers = authHelper;
            _userService = userService;
            _logger = logger;
        }


        // GET: api/<UserController>
        /// <summary>
        /// Obtiene todos los usuarios.
        /// </summary>
        /// <returns>Listado de llos usuarios.</returns>
        [HttpGet]
        [ProducesResponseType(typeof(List<User>), 200)]
        [ProducesResponseType(500)]
        [HttpGet]
        public async Task<List<User>> Get()
        {
          return await this._userService.GetUsers();
        }


        // GET api/<UserController>/5
        /// <summary>
        /// Se obtiene el usuario y su informacion por medio de ID.
        /// </summary>
        /// <param name="id">Id de usuario.</param>
        /// <returns>La informacion del usuario con el ID especificado.</returns>
        [ProducesResponseType(typeof(User), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            try
            {
                var user = await _userService.GetUser(id);
                return Ok(user);
            }
            catch (DllNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, $"Error occurred while fetching user with id {id}");
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }


        /// <summary>
        /// Login de usuario.
        /// </summary>
        /// <param name="loginDto">Credenciales de login.</param>
        /// <returns>Login response.</returns>
        [ProducesResponseType(typeof(object), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            var user = await _userService.Login(loginDto);
            Console.WriteLine("User: ", user);
            if (user == null)
            {
                return NotFound(new { message = "Usuario o contraseña incorrectos" });
            }
            var token = _authHelpers.GenerateJWTToken(user);
            return Ok(new
            {
                message = "Login de usuario exitoso",
                user,
                token 
            });
        }

        /// <summary>
        /// Actualizar la informacion de usuarios.
        /// </summary>
        /// <param name="id">The user ID.</param>
        /// <param name="updateUserDto">Actualiza la informacion de usuario.</param>
        /// <returns>Update response.</returns>
        [ProducesResponseType(typeof(object), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UpdateUserDto updateUserDto)
        {
            var user = await _userService.UpdateUser(id, updateUserDto.Name, updateUserDto.Email, updateUserDto.Password);
            if (user == null)
            {
                return NotFound(new { message = "Usuario no encontrado" });
            }
            return Ok(new { message = "Usuario actualizado correctamente", user });
        }


        /// <summary>
        /// Elimina el usuario que se especifica en el ID.
        /// </summary>
        /// <param name="id"> user ID.</param>
        /// <returns>Deletion response.</returns>
        [ProducesResponseType(typeof(object), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var success = await _userService.DeleteUser(id);
            if (!success)
            {
                return NotFound(new { message = "Usuario no encontrado" });
            }
            return Ok(new { message = "Usuario eliminado correctamente" });
        }

        /// <summary>
        /// Se registra un nuevo usuario.
        /// </summary>
        /// <param name="registerUserDto">Detalles de registro de usuario.</param>
        /// <returns>Registration response.</returns>
      
        [ProducesResponseType(typeof(object), 200)]
        [ProducesResponseType(500)]
        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser([FromBody] RegisterUserDto registerUserDto)
        {
            Console.WriteLine("RegisterUserDto: ", registerUserDto);
            var user = await _userService.RegisterUser(registerUserDto.Name, registerUserDto.Email, registerUserDto.Password);
            return Ok(new { message = "Usuario creado correctamente", user });
        }
        /// <summary>
        /// Entrea la lista de medias que les gusta al usuario.
        /// </summary>
        /// <param name="id"> user ID.</param>
        /// <returns>Lista de medias que les gusta al usuario.</returns>
        //[Authorize]
        [ProducesResponseType(typeof(object), 200)]
        [ProducesResponseType(500)]
        [HttpPost("{userid}/action")]
        public async Task<IActionResult> AddLike(int userid, [FromQuery] AddActionDto addActionDto)
        {
            var resp = await _userService.AddAction(userid,addActionDto);
            return Ok(new { Message = resp  });
        }
        /// <summary>
        /// Entrea la lista de medias que les gusta al usuario.
        /// </summary>
        /// <param name="id"> user ID.</param>
        /// <returns>Lista de medias que les gusta al usuario.</returns>
        [Authorize]
        [ProducesResponseType(typeof(object), 200)]
        [ProducesResponseType(500)]
        [HttpGet("{id}/likes")]
        public async Task<IActionResult> GetMediaLiked(int id)
        {
            var likes = await _userService.LikeMedia(id);
            return Ok(new { MediaLike = likes });
        }
        /// <summary>
        /// Entrega la lista de vistas que les gusta al usuario.
        /// </summary>
        /// <param name="id"> user ID.</param>
        /// <returns>Lista de vistas que les gusta al usuario.</returns>
        //[Authorize]
        [ProducesResponseType(typeof(object), 200)]
        [ProducesResponseType(500)]
        [HttpGet("{id}/view")]
        public async Task<IActionResult> GetMediaView(int id)
        {
            var views = await _userService.ViewMedia(id);
            return Ok(new { MediaView = views });
        }
    }
}
