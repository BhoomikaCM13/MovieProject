using CoreEntity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreData.Repository
{
    public class TimingRepository : ITimingRepository
    {
        MoviedbContext _showdbContext;
        public TimingRepository(MoviedbContext showDbContext)
        {
            _showdbContext = showDbContext;
        }

        public void AddTimingI(ShowTiming timing)
        {
            _showdbContext.showTimings.Add(timing);
            _showdbContext.SaveChanges();
        }

        public void DeleteTimingI(int id)
        {
            var showtiming = _showdbContext.showTimings.Find(id);
            _showdbContext.showTimings.Remove(showtiming);
            _showdbContext.SaveChanges();
        }

        public ShowTiming GetS(int id)
        {
            return _showdbContext.showTimings.Find(id);
        }

        public IEnumerable<ShowTiming> GetShowTiming()
        {
            return _showdbContext.showTimings.ToList();
        }


        public void UpdateTimingI(ShowTiming timing)
        {
            _showdbContext.Entry(timing).State = EntityState.Modified;
            _showdbContext.SaveChanges();
        }
    }
}
