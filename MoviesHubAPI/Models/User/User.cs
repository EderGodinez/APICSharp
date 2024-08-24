using MoviesHubAPI.Models.Ratings;
using MoviesHubAPI.Models.UserActionsF;
using System.ComponentModel.DataAnnotations;

namespace MoviesHubAPI.Models.UserF
{
    public class User : IUser
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Nombre del usuario requerido")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Correo requerido")]
        [EmailAddress(ErrorMessage = "Correo invalido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "La contraseña es requerida")]
        [MinLength(10,ErrorMessage ="Contraseña debe de ser minimo de 10 caracteres")]
        public string Password { get; set; }

        [RegularExpression("^(admin|user)$", ErrorMessage = "El rol unicamente puede ser 'admin' o 'user'")]
        public string Role { get; set; } = "user";
        public ICollection<UserAction> UserActions { get; set; }
        public ICollection<Rating> Ratings { get; set; }
    }
}
