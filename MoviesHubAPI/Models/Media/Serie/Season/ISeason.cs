using MoviesHubAPI.Models.MediaF.SerieF.EpisodeListF;

namespace MoviesHubAPI.Models.MediaF.SerieF.SeasonF
{
    public interface ISeason
    {
         int Id { get; set; }
         string Name { get; set; }

         ICollection<EpisodeList> EpisodeLists { get; set; }
    }
}
