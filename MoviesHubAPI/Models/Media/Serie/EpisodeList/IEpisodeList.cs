using MoviesHubAPI.Models.MediaF.SerieF.Episodes;
using MoviesHubAPI.Models.MediaF.SerieF.SeasonF;
namespace MoviesHubAPI.Models.MediaF.SerieF.EpisodeListF
{
    public interface IEpisodeList
    {
        int SeasonId { get; set; }
        Season Season { get; set; }
        int EpisodeId { get; set; }
        Episode Episode { get; set; }

    }
}
