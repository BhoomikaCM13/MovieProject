using CoreEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreData.Repository
{
    public interface ITimingRepository
    {
        void AddTimingI(ShowTiming timing);
        void UpdateTimingI(ShowTiming timing);
        void DeleteTimingI(int Id);
        ShowTiming GetS(int Id);
        IEnumerable<ShowTiming> GetShowTiming();
    }
}
