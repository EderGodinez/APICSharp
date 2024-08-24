using MoviesHubAPI.Models.MediaF.SerieF.Episodes;
using MoviesHubAPI.Models.MediaF.SerieF.SeasonF;

namespace MoviesHubAPI.Models.MediaF.SerieF.EpisodeListF
{
    public class EpisodeList : IEpisodeList
    {
        public int EpisodeId { get; set; }
        public Episode Episode { get; set; }
        public int SeasonId { get; set; }
        public Season Season { get; set; }
    }
}
