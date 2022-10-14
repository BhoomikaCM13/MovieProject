using System;
using System.Collections.Generic;
using System.Text;
using CoreEntity;
using Microsoft.EntityFrameworkCore;

namespace CoreData
{
    
    public class MoviedbContext : DbContext //Configuring dbContext
    {


        public MoviedbContext(DbContextOptions<MoviedbContext> options) : base(options)
        {

        }
        public DbSet<Movie> movies { get; set; }
        public DbSet<Theater> theaters { get; set; }
        public DbSet<ShowTiming> showTimings { get; set; }
        public DbSet<User> users { get; set; }
        public DbSet<Booking> books { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            dbContextOptionsBuilder.UseSqlServer("Data Source=VDC01LTC2126;Initial Catalog=BookMovie;Integrated Security=True;");
        }
    }
    

    
}
