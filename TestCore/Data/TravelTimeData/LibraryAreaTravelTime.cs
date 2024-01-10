using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    internal class LibraryAreaTravelTime
    {
        public static void LATimeCalculations() 
        {
            // Place 11: MainHall Time Data Sheet
            BeforeStart.placeDic[11].times[11] = 0;
            BeforeStart.placeDic[11].times[12] = 5;
            BeforeStart.placeDic[11].times[0] = 30;
              
            // Place 12: Lilith's House Time Data Sheet
            BeforeStart.placeDic[12].times[11] = 3;
            BeforeStart.placeDic[12].times[12] = 3;
            BeforeStart.placeDic[12].times[0] = 30;

        }
    }
}
