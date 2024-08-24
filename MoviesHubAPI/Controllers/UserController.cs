using Microsoft.AspNetCore.Mvc;
using MoviesHubAPI.Models.UserF;
using MoviesHubAPI.Services.UserDtos;
using MoviesHubAPI.Services.Users;
namespace MoviesHubAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        /// <summary>
        /// Se inicializa el controllador <see cref="UserController"/> class.
        /// </summary>
        /// <param name="userService">Servicio para gestion de usuarios.</param>
        public UserController(IUserService userService)
        {
            _userService = userService;
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
            var resp=await this._userService.GetUser(id);
            if (resp == null)
            {
                return NotFound("Usuario no encontrado");
            }
            return Ok(resp);

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
            var user = await _userService.Login(loginDto.Email, loginDto.Password );
            if (user == null)
            {
                return NotFound(new { message = "Usuario o contraseña incorrectos" });
            }
            return Ok(new { message = "Login de usuario exitoso", user });
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
            var user = await _userService.RegisterUser(registerUserDto.Name, registerUserDto.Email, registerUserDto.Password);
            return Ok(new { message = "Usuario creado correctamente", user });
        }
    }
}
