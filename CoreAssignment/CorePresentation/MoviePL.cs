using System;
using CoreEntity;
using CoreData;
using System.Collections.Generic;

namespace CorePresentation
{
    public class MoviePL
    {
        public void Menu()
        {
            Console.WriteLine("Againnnnnn........");
            Console.WriteLine("enter 1 to add");
            Console.WriteLine("enter 2 to delete");
            int x = Convert.ToInt32(Console.ReadLine());
            if(x == 1)
            {
                AddMovie();
            }
            else if (x == 2)
            {
                RemoveMovie();
            }
        }
        
        public void AddMovie()
        {
            MovieDAL movieOperations = new MovieDAL();
            Movie movie = new Movie();
            Console.Write("Enter movie name:");
            movie.Name = Console.ReadLine();
            Console.WriteLine("Enter Movie Description:");
            movie.MovieDesc = Console.ReadLine();
            Console.WriteLine("enter movie type:");
            movie.MovieType = Console.ReadLine();
            string msg = movieOperations.AddMovie(movie);
            Console.WriteLine(msg);
            Menu();
        }
        public void RemoveMovie()
        {

            MovieDAL movieOperations = new MovieDAL();
            Movie movie = new Movie();
            Console.Write("enter the Mvie ID :");
            var id= Convert.ToInt32(Console.ReadLine());
            string msg= movieOperations.DeleteMovie(id);
            Console.WriteLine(msg);
            Menu();

        }
        public void ShowAllMovies()
        {
            MovieDAL movieOperations = new MovieDAL();
            List<Movie> movies = movieOperations.ShowAll();
            foreach (var movie in movies)
            {
                Console.WriteLine("NAME: " + movie.Name);
                Console.WriteLine("DESCRIPTION: " + movie.MovieDesc);
                Console.WriteLine("MovieType: " + movie.MovieType);
            }
        }
    }
}
