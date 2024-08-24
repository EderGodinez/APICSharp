using MoviesHubAPI.Models.Genders.GenderListF;
using MoviesHubAPI.Models.MediaF.SerieF.EpisodeListF;
using MoviesHubAPI.Models.MediaF.SerieF.SeasonF;
using MoviesHubAPI.Models.Platforms.EnablePlatform;
using MoviesHubAPI.Models.Ratings;

namespace MoviesHubAPI.Models.MediaF.SerieF
{
    public class Serie : ISerie
    {
        public ICollection<Season> Seasons { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
        public string OriginalTitle { get; set; }
        public string Overview { get; set; }
        public string ImagePath { get; set; }
        public string PosterImage { get; set; }
        public string TrailerLink { get; set; }
        public string WatchLink { get; set; }
        public DateTime AddedDate { get; set; }
        public string TypeMedia { get; set; }
        public DateTime RelaseDate { get; set; }
        public string AgeRate { get; set; }
        public bool? IsActive { get; set; }
        public ICollection<Rating> Ratings { get ; set ; }
        public ICollection<GenderList> GenderLists { get; set; }
        public ICollection<MediaAvailibleIn> MediaAvailibleIns { get; set ; }
    }
}
