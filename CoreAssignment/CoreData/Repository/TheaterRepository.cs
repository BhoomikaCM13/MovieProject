using CoreEntity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreData.Repository
{
    public class TheaterRepository : ITheaterRepository
    {
        MoviedbContext _theaterdbContext;
        public TheaterRepository(MoviedbContext theaterDbContext)
        {
            _theaterdbContext = theaterDbContext;
        }

        public void AddTheaterI(Theater theater)
        {
            _theaterdbContext.theaters.Add(theater);
            _theaterdbContext.SaveChanges();
        }

        public void DeleteTheaterI(int id)
        {
            var theater = _theaterdbContext.theaters.Find(id);
            _theaterdbContext.theaters.Remove(theater);
            _theaterdbContext.SaveChanges();
        }

        public Theater GetT(int id)
        {
            return _theaterdbContext.theaters.Find(id);
        }

        public IEnumerable<Theater> GetTheaters()
        {
            return _theaterdbContext.theaters.ToList();
        }


        public void UpdateTheaterI(Theater theater)
        {
            _theaterdbContext.Entry(theater).State = EntityState.Modified;
            _theaterdbContext.SaveChanges();
        }
    }
    
}
