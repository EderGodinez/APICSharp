using MoviesHubAPI.Models.Genders.GenderListF;
using MoviesHubAPI.Models.MediaF.SerieF.EpisodeListF;
using MoviesHubAPI.Models.Platforms.EnablePlatform;
using MoviesHubAPI.Models.Ratings;

namespace MoviesHubAPI.Models.MediaF
{
    public interface IMedia
    {
        int Id { get; set; }
        string Title { get; set; }
        string OriginalTitle { get; set; }
        string Overview { get; set; }
        string ImagePath { get; set; }
        string PosterImage { get; set; }
        string TrailerLink { get; set; }
        string WatchLink { get; set; }
        DateTime AddedDate { get; set; }
        string TypeMedia { get; set; }
        DateTime RelaseDate { get; set; }
        string AgeRate { get; set; }
        bool? IsActive { get; set; }
         ICollection<Rating> Ratings { get; set; }
        ICollection<GenderList> GenderLists { get; set; }
        ICollection<MediaAvailibleIn> MediaAvailibleIns { get; set; }
    }
}
