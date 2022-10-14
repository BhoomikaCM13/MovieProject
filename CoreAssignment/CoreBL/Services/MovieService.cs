using System;
using System.Collections.Generic;
using System.Text;
using CoreData.Repository;
using CoreEntity;


namespace CoreBL.Services
{
    public class MovieService
    {
        IMovieRepository _movieRepository;
        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }
        //add movie
        public void AddMovie(Movie movie)
        {
            _movieRepository.Addmovie(movie);
        }

        //update movie
        public void UpdateMovie(Movie movie)
        {
            _movieRepository.Updatemovie(movie);
        }

        public void DeleteMovie(int Id)
        {
            _movieRepository.Deletemovie(Id);
        }

        //get moviebyid
        public Movie GetMovieById(int id)
        {
            return _movieRepository.Getmovie(id);
        }
        //get getmovies
        public IEnumerable<Movie> GetMovies()
        {
            return _movieRepository.GetMovies();
        }
    }
}
