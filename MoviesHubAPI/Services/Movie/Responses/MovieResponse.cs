


namespace MoviesHubAPI.Services.Movies.Responses
{
    public class MovieResponse : IMovieResponse
    {
        public MediaMovie MovieData { get; set; }
        public TimeSpan? Duration { get; set; }
        public List<string> GenderLists { get; set; }
    }
     public class MediaMovie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string OriginalTitle { get; set; }
        public string Overview { get; set; }
        public string ImagePath { get; set; }
        public string PosterImage { get; set; }
        public string TrailerLink { get; set; }
        public string WatchLink { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime RelaseDate { get; set; }
        public string AgeRate { get; set; }
        public string TypeMedia { get; set; }
        public bool? IsActive { get; set; }
    }
}
