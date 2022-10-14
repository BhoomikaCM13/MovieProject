using CoreEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreData.Repository
{
    public interface ITheaterRepository
    {
        void AddTheaterI(Theater theater);
        void UpdateTheaterI(Theater theater);
        void DeleteTheaterI(int Id);
        Theater GetT(int Id);
        IEnumerable<Theater> GetTheaters();

    }
}
