
using System.ComponentModel.DataAnnotations;

namespace MoviesHubAPI.Models
{
    public class Media : IMedia
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Title { get; set; }

        [Required]
        [StringLength(50)]
        public string OriginalTitle { get; set; }

        [Required]
        public string Overview { get; set; }

        [Required]
        [StringLength(255)]
        public string ImagePath { get; set; }

        [Required]
        [StringLength(255)]
        public string PosterImage { get; set; }

        [Required]
        [StringLength(255)]
        public string TrailerLink { get; set; }

        [Required]
        [StringLength(255)]
        public string WatchLink { get; set; }

        [Required]
        public DateTime AddedDate { get; set; }

        [Required]
        [StringLength(10)]
        public string TypeMedia { get; set; }

        [Required]
        public DateTime RelaseDate { get; set; }

        [StringLength(8)]
        public string AgeRate { get; set; }

        public bool? IsActive { get; set; }

        public virtual Movie Movie { get; set; }
        public virtual ICollection<GenderList> GendersLists { get; set; }
        public virtual ICollection<MediaAvailibleIn> MediaAvailibleIns { get; set; }
        public virtual ICollection<Rating> Ratings { get; set; }
        public virtual ICollection<UserAction> UserActions { get; set; }
        public virtual ICollection<Season> Seasons { get; set; }
        public ICollection<Episode> Episodes { get; set; }
    }
}