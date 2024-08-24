
using MoviesHubAPI.Models.MediaF.SerieF.EpisodeListF;

namespace MoviesHubAPI.Models.MediaF.SerieF.SeasonF
{
    public class Season : ISeason
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<EpisodeList> EpisodeLists { get; set; }

    }
}
