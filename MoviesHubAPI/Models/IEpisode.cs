

namespace MoviesHubAPI.Models
{
    public interface IEpisode
    {
        int Id { get; set; }
        string Title { get; set; }
        string Overview { get; set; }
        int E_Num { get; set; }
        TimeSpan Duration { get; set; }
        string ImagePath { get; set; }
        DateTime AddedDate { get; set; }
        string WatchLink { get; set; }
        DateTime RelaseDate { get; set; }
    }
}