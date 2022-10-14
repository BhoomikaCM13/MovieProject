using CoreEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreData.Repository
{
    public interface IMovieRepository
    {
        void Addmovie(Movie movie);
        void Updatemovie(Movie movie);
        void Deletemovie(int Id);
        Movie Getmovie(int Id);
        IEnumerable<Movie> GetMovies();

    }
}
