using MoviesHubAPI.Models.MediaF.SerieF.EpisodeListF;
using MoviesHubAPI.Models.MediaF.SerieF.SeasonF;

namespace MoviesHubAPI.Models.MediaF.SerieF.Episodes
{
    public class Episode : IEpisode
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Overview { get; set; }
        public byte E_Num { get; set; }
        public TimeSpan Duration { get; set; }
        public string ImagePath { get; set; }
        public DateTime AddedDate { get; set; }
        public string WatchLink { get; set; }
        public DateTime RelaseDate { get; set; }
        public ICollection<EpisodeList> EpisodeLists { get; set; }
    }
}
