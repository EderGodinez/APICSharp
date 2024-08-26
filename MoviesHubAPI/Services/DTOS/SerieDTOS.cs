namespace MoviesHubAPI.Services.DTOS
{
    using System;
    using System.Collections.Generic;

    public class MediaDto
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

        public List<string> GendersLists { get; set; }  
        public List<string> MediaAvailibleIns { get; set; }  
        public List<SeasonDto>? Seasons { get; set; }  
        public float? Rating { get; set; }
        public int? Votes { get; set; }

    }

    public class SeasonDto
    {
        public int SeasonId { get; set; }
        public int NumSeason { get; set; }
        public List<EpisodeDto> Episodes { get; set; }  // Episodes in this season
    }

    public class EpisodeDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Overview { get; set; }
        public int E_Num { get; set; }
        public TimeSpan Duration { get; set; }
        public string ImagePath { get; set; }
        public DateTime AddedDate { get; set; }
        public string WatchLink { get; set; }
        public DateTime RelaseDate { get; set; }
    }

}
