using CoreData.Repository;
using CoreEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreBL.Services
{
    public class TimingService
    {
        ITimingRepository _showRepository;
        public TimingService(ITimingRepository showRepository)
        {
            _showRepository = showRepository;
        }

        public void AddTiming(ShowTiming showTiming)
        {
            _showRepository.AddTimingI(showTiming);
        }


        public void UpdateTiming(ShowTiming showTiming)
        {
            _showRepository.UpdateTimingI(showTiming);
        }

        public void DeleteTiming(int Id)
        {
            _showRepository.DeleteTimingI(Id);
        }

        public ShowTiming GetSById(int id)
        {
           return _showRepository.GetS(id);
        }
        public IEnumerable<ShowTiming> GetTiming()
        {
            return _showRepository.GetShowTiming();
        }
    }
}
