
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoviesHubAPI.Models
{
    public class Movie : IMovie
    {
        [Key]
        [ForeignKey("Media")]
        public int MediaId { get; set; }

        [Required]
        public TimeSpan Duration { get; set; }

        public virtual Media Media { get; set; }
    }
}