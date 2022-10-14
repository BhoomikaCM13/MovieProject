using CoreEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreData.Repository
{
    public class MovieRepository : IMovieRepository
    {
        MoviedbContext _moviedbContext; 
        public MovieRepository(MoviedbContext movieDbContext)
        {
            _moviedbContext = movieDbContext;
        }
      
        public void Addmovie(Movie movie)
        {
            _moviedbContext.movies.Add(movie);
            _moviedbContext.SaveChanges();
        }

        public void Deletemovie(int id)
        {
            var movie = _moviedbContext.movies.Find(id);
            _moviedbContext.movies.Remove(movie);
            _moviedbContext.SaveChanges();
        }

        public Movie Getmovie(int id)
        {
            return _moviedbContext.movies.Find(id);
        }

        public IEnumerable<Movie> GetMovies()
        {
            return _moviedbContext.movies.ToList();
        }
 

        public void Updatemovie(Movie movie)
        {
            _moviedbContext.Entry(movie).State = EntityState.Modified;
            _moviedbContext.SaveChanges();
        }
    }
    
}
