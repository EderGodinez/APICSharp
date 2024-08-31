namespace MoviesHubAPI.Services.Movies.Responses
{
    public interface IMovieResponse
    {
        MediaMovie MovieData { get; set; }
        TimeSpan? Duration { get; set; }
        List<string> GenderLists { get; set; }
    }
}
