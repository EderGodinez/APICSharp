﻿using EntityFrameworkExample.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesHubAPI.Models;
using MoviesHubAPI.Services.DTOS;
using MoviesHubAPI.Services.Movies.Responses;

namespace MoviesHubAPI.Services.MovieS
{
    public class MovieService:IMovieService
    {
        private readonly IContextDB _context;
        public MovieService(ContextDB context)
        {
            _context = context;
        }
        public async Task<IEnumerable<MovieResponse>> GetAllMoviesAsync()
        {
            return await _context.Movies
                .Include(m => m.Media)
                    .ThenInclude(gl => gl.GendersLists)
                .Select(m => new MovieResponse
                {
                    MovieData = new MediaMovie
                    {
                        Id = m.Media.Id,
                        Title = m.Media.Title,
                        OriginalTitle = m.Media.OriginalTitle,
                        Overview = m.Media.Overview,
                        ImagePath = m.Media.ImagePath,
                        PosterImage = m.Media.PosterImage,
                        TrailerLink = m.Media.TrailerLink,
                        WatchLink = m.Media.WatchLink,
                        AddedDate = m.Media.AddedDate,
                        RelaseDate = m.Media.RelaseDate,
                        AgeRate = m.Media.AgeRate,
                        IsActive = m.Media.IsActive,
                        TypeMedia = m.Media.TypeMedia,
                    },
                    Duration = m.Duration,
                    GenderLists = m.Media.GendersLists.Select(gl => gl.Gender.Name).ToList()
                })
    .OrderBy(m => m.MovieData.Id)
    .ToListAsync();
        }

        public async Task<MovieResponse> GetMovieByIdAsync(int id)
        {
            var movie = await _context.Movies
        .Include(m => m.Media)
                    .ThenInclude(gl => gl.GendersLists)
        .Where(m => m.MediaId == id && m.Media.TypeMedia == "movie")
        .Select(m => new MovieResponse
        {
            MovieData = new MediaMovie
            {
                Id = m.Media.Id,
                Title = m.Media.Title,
                OriginalTitle = m.Media.OriginalTitle,
                Overview = m.Media.Overview,
                ImagePath = m.Media.ImagePath,
                PosterImage = m.Media.PosterImage,
                TrailerLink = m.Media.TrailerLink,
                WatchLink = m.Media.WatchLink,
                AddedDate = m.Media.AddedDate,
                RelaseDate = m.Media.RelaseDate,
                AgeRate = m.Media.AgeRate,
                IsActive = m.Media.IsActive,
                TypeMedia = m.Media.TypeMedia
                                
            },
            Duration = m.Duration,
            GenderLists = m.Media.GendersLists.Select(gl => gl.Gender.Name).ToList()
        })
        .FirstOrDefaultAsync();
            return movie;
        }

        public async Task<string> RegisterMovieAsync(Movie model)
        {
            _context.Movies.Add(model);
            await _context.SaveChangesAsync(true);
            return "Pelicula registrada correctamente";
        }

        public async Task<string> UpdateMovieAsync(int id, Movie model)
        {
            var movie = await _context.Movies.FindAsync(id);
            if (movie == null) return "Pelicula no encontrada";

            movie.Media.Title = model.Media.Title;
            movie.Media.OriginalTitle = model.Media.OriginalTitle;
            movie.Media.Overview = model.Media.Overview;
            movie.Media.ImagePath = model.Media.ImagePath;
            movie.Media.PosterImage = model.Media.PosterImage;
            movie.Media.TrailerLink = model.Media.TrailerLink;
            movie.Media.WatchLink = model.Media.WatchLink;
            movie.Media.AddedDate = model.Media.AddedDate;
            movie.Media.RelaseDate = model.Media.RelaseDate;
            movie.Media.AgeRate = model.Media.AgeRate;
            movie.Duration = model.Duration;

            await _context.SaveChangesAsync(true);
            return "Pelicula actualizada correctamente";
        }

        public async Task<string> DeleteMovieByIdAsync(int id)
        {
            var movie = await _context.Movies.FindAsync(id);
            if (movie == null) return "Pelicula no encontrada";

            _context.Movies.Remove(movie);
            await _context.SaveChangesAsync(true);
            return "Pelicula eliminada con exito";
        }

        public async Task<IEnumerable<TrendingDTO>> GetTrendingMovies()
        {
            var trendingMovies = await _context.TrendingDTOs
                .FromSqlRaw("EXEC GetTrendingMovies")
                .ToListAsync();

            var trendingDTOs = trendingMovies.Select(movie => new TrendingDTO
            {
                Id = movie.Id,
                Title = movie.Title,
                OriginalTitle = movie.OriginalTitle,
                Overview = movie.Overview,
                ImagePath = movie.ImagePath,
                PosterImage = movie.PosterImage,
                TrailerLink = movie.TrailerLink,
                WatchLink = movie.WatchLink,
                AddedDate = movie.AddedDate,
                TypeMedia = movie.TypeMedia,
                RelaseDate = movie.RelaseDate,
                AgeRate = movie.AgeRate,
                IsActive = movie.IsActive
            }).ToList();

            return trendingDTOs;
        }

       
    }
}
