using CoreData.Repository;
using CoreEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreBL.Services
{
    public class TheaterService
    {
        ITheaterRepository _theaterRepository;
        public TheaterService(ITheaterRepository TheaterRepository)
        {
            _theaterRepository = TheaterRepository;
        }
        
        public void AddTheater(Theater theater)
        {
            _theaterRepository.AddTheaterI(theater);
        }

        
        public void UpdateTheater(Theater theater)
        {
            _theaterRepository.UpdateTheaterI(theater);
        }

        public void DeleteTheater(int Id)
        {
            _theaterRepository.DeleteTheaterI(Id);
        }

        public Theater GetTById(int id)
        {
           return _theaterRepository.GetT(id);
        }
        public IEnumerable<Theater> GetTheaters()
        {
            return _theaterRepository.GetTheaters();
        }
    }
}
