using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using CoreEntity;
using System.Runtime.InteropServices;

namespace CoreData
{
    public class MovieDAL
    {
        MoviedbContext db = null ;
      
            
            public MovieDAL(MoviedbContext db) 

            { 
            this.db = db;
            }

        public MovieDAL()
        {
        }

        public string AddMovie(Movie movie)
        {

            //db = new MoviedbContext();
            db.movies.Add(movie);
            db.SaveChanges();
            return "added";
        }
        public string UpdateMovie(Movie movie)
        {
            //db = new MoviedbContext();
            db.Entry(movie).State = EntityState.Modified;
            db.SaveChanges();
            return "updated";
        }
        public string DeleteMovie(int MovieId)
        {
            //db = new MoviedbContext();
            Movie movieObj = db.movies.Find(MovieId);
            db.Entry(movieObj).State = EntityState.Deleted; 
            db.SaveChanges();
            return "deleted";
         }
            public List<Movie> ShowAll()
            {
            //db = new MoviedbContext();
            List<Movie> movieList = db.movies.ToList();
            return movieList;
        }
        //public List<MovieDAL> ShowAllByMovieType(string type)
        //{
        //    db = new MoviedbContext();
        //    List<MovieDAL> movieList = db.movies.ToList();

        //    //LINQ query: select * from movie where movietype='type'
        //    var result = from movies in movieList
        //                 where movies.MovieType == type
        //                 select new Movie
        //                 {
        //                     Id = movies.Id,
        //                     Name = movies.Name
        //                 };
        //    List<MovieDAL> movieResult = new List<MovieDAL>();
        //    foreach (var item in result)//linq query excution 
        //    {
        //        movieResult.Add(item);
        //    }
        //    return movieResult;
        //}
        //public MovieDAL ShowMovieById(int movieId)
        //{
        //    db = new MoviedbContext();
        //    MovieDAL movie = db.movies.Find(movieId);
        //    return movie;
        //}
        ////public Movie Movi


    }

    }

  
