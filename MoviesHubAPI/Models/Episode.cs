
using System.ComponentModel.DataAnnotations;

namespace MoviesHubAPI.Models
{
    public class Episode : IEpisode
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Title { get; set; }

        [Required]
        public string Overview { get; set; }

        [Required]
        public int E_Num { get; set; }

        [Required]
        public TimeSpan Duration { get; set; }

        [Required]
        [StringLength(255)]
        public string ImagePath { get; set; }

        [Required]
        public DateTime AddedDate { get; set; }

        [Required]
        [StringLength(255)]
        public string WatchLink { get; set; }

        [Required]
        public DateTime RelaseDate { get; set; }

        public virtual ICollection<EpisodeList> EpisodesLists { get; set; }
    }
}