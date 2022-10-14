using CoreData;
using CoreEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CorePresentation
{
    public class TheaterPL
    {
        public void TMenu()
        {
            Console.WriteLine("Againnnnnn........");
            Console.WriteLine("enter 1 to add");
            Console.WriteLine("enter 2 to delete");
            int x = Convert.ToInt32(Console.ReadLine());
            if (x == 1)
            {
                AddTheater();
            }
            else if (x == 2)
            {
                RemoveTheater();
            }
        }

        public void AddTheater()
        {
            TheaterDAL TheaterOperations = new TheaterDAL();
            Theater theater = new Theater();
            Console.Write("Enter theater name:");
            theater.TName = Console.ReadLine();
            Console.WriteLine("Enter the address:");
            theater.Address = Console.ReadLine();
            Console.WriteLine("enter comments:");
            theater.Comments = Console.ReadLine();
            string msg = TheaterOperations.AddTheater(theater);
            Console.WriteLine(msg);
            TMenu();
        }
        public void RemoveTheater()
        {
            TheaterDAL TheaterOperations = new TheaterDAL();
            Console.Write("enter the Mvie ID :");
            var id = Convert.ToInt32(Console.ReadLine());
            string msg = TheaterOperations.DeleteTheater(id);
            Console.WriteLine(msg);
            TMenu();

        }
        public void ShowAllTheater()
        {
            TheaterDAL TheaterOperations = new TheaterDAL();
            List<Theater> theater = TheaterOperations.ShowAllT();
            foreach (var item in theater)
            {
                Console.WriteLine("THEATER_NAME: " + item.TName);
                Console.WriteLine("ADDRESS: " + item.Address);
                Console.WriteLine("COMMENTS: " + item.Comments);
            }
        }

    }
}
