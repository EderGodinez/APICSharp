namespace MoviesHubAPI.Services.DTOS
{
    public class TrendingDTO
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
        public string TypeMedia { get; set; }
        public DateTime RelaseDate { get; set; }
        public string AgeRate { get; set; }
        public bool? IsActive { get; set; }
    }
}
