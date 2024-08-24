
using MoviesHubAPI.Models.MediaF.SerieF.EpisodeListF;
using MoviesHubAPI.Models.MediaF.SerieF.SeasonF;

namespace MoviesHubAPI.Models.MediaF.SerieF.Episodes
{
    public interface IEpisode
    {
        int Id { get; set; }
        string Title { get; set; }
        string Overview { get; set; }
        byte E_Num { get; set; }
        TimeSpan Duration { get; set; }
        string ImagePath { get; set; }
        DateTime AddedDate { get; set; }
        string WatchLink { get; set; }
        DateTime RelaseDate { get; set; }
         ICollection<EpisodeList> EpisodeLists { get; set; }

    }
}
