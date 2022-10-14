using CoreData;
using CoreEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CorePresentation
{
    public class ShowTimingPL
    {
        public void MenuS()
        {
            Console.WriteLine("Againnnnnn........");
            Console.WriteLine("enter 1 to add");
            Console.WriteLine("enter 2 to delete");
            int x = Convert.ToInt32(Console.ReadLine());
            if (x == 1)
            {
                AddTimingP();
            }
            else if (x == 2)
            {
                RemoveTiming();
            }
            else if (x == 3)
            {
                ShowAllTiming();
            }
        }

        public void AddTimingP()
        {
            ShowTimingDL showOperations = new ShowTimingDL();
            ShowTiming show = new ShowTiming();
            
            Console.WriteLine("enter show timing:");
            show.ShowTime = Convert.ToDateTime(Console.ReadLine());
            string msg = showOperations.AddShowtiming(show);
            Console.WriteLine(msg);
            ShowAllTiming();
            MenuS();
        }
        public void RemoveTiming()
        {

            ShowTimingDL showOperations = new ShowTimingDL();
            Console.Write("enter the show ID :");
            var id = Convert.ToInt32(Console.ReadLine());
            string msg = showOperations.DeleteTiming(id);
            Console.WriteLine(msg);
            ShowAllTiming();
            MenuS();

        }
        public void ShowAllTiming()
        {
            ShowTimingDL showOperations = new ShowTimingDL();
            List<ShowTiming> showTimings = showOperations.ShowAllT();
            foreach (var item in showTimings)
            {
                //Console.WriteLine("NAME: " + item.Name);
                //Console.WriteLine("Theater_name: " + item.TName);
                Console.WriteLine("show_timing: " + item.ShowTime);
            }
        }
    }
}
