using System.ComponentModel.DataAnnotations;

namespace MoviesHubAPI.Models
{
    public class EpisodeList
    {
        [Required]
        public int Seasonld { get; set; }

        [Required]
        public int Episodeld { get; set; }

        public virtual Season Season { get; set; }
        public virtual Episode Episode { get; set; }
    }

    public class Gender
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string Name { get; set; }

        public virtual ICollection<GenderList> GendersLists { get; set; }
    }

    public class GenderList
    {
        [Required]
        public int MediaId { get; set; }

        [Required]
        public int GenderId { get; set; }

        public virtual Media Media { get; set; }
        public virtual Gender Gender { get; set; }
    }

    public class MediaAvailibleIn
    {
        [Required]
        public int MediaId { get; set; }

        [Required]
        public int PlatformId { get; set; }

        public virtual Media Media { get; set; }
        public virtual Platform Platform { get; set; }
    }

    public class Platform
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string Name { get; set; }

        public virtual ICollection<MediaAvailibleIn> MediaAvailibleIns { get; set; }
    }

    public class Rating
    {
        public int UserId { get; set; }
        public int MediaId { get; set; }

        [Required]
        public byte Rate { get; set; }

        [Required]
        public DateTime RateDate { get; set; }

        public virtual User User { get; set; }
        public virtual Media Media { get; set; }
    }

    public class Season
    {
        [Key]
        public int Seasonld { get; set; }

        [Required]
        public int SerieId { get; set; }

        [Required]
        public byte NumSeason { get; set; }

        [Required]
        public DateTime DateRelease { get; set; }

        public virtual Media Serie { get; set; }
        public virtual ICollection<EpisodeList> EpisodesLists { get; set; }
    }

    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(150)]
        public string Password { get; set; }

        [Required]
        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(10)]
        public string Role { get; set; }

        public virtual ICollection<Rating> Ratings { get; set; }
        public virtual ICollection<UserAction> UserActions { get; set; }
    }

    public class UserAction
    {
        public int UserId { get; set; }
        public int MediaId { get; set; }

        [Required]
        [StringLength(1)]
        public string TypeAction { get; set; }

        [Required]
        public DateTime ActionDate { get; set; }

        public virtual User User { get; set; }
        public virtual Media Media { get; set; }
    }
}
