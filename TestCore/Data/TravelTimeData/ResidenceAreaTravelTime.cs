using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    internal class ResidenceAreaTravelTime
    {
        public static void RATimeCalculations() 
        { 
            // Place 0: Player House Time Data Sheet
            BeforeStart.placeDic[0].times[0] = 0;
            BeforeStart.placeDic[0].times[1] = 28;
            BeforeStart.placeDic[0].times[2] = 26;
            BeforeStart.placeDic[0].times[3] = 23;
            BeforeStart.placeDic[0].times[4] = 20;
            BeforeStart.placeDic[0].times[5] = 28;
            BeforeStart.placeDic[0].times[6] = 26;
            BeforeStart.placeDic[0].times[7] = 23;
            BeforeStart.placeDic[0].times[8] = 20;
            BeforeStart.placeDic[0].times[9] = 7;
            BeforeStart.placeDic[0].times[10] = 5;

            // Place 1: Reika's House Time Data Sheet
            BeforeStart.placeDic[1].times[0] = 28;
            BeforeStart.placeDic[1].times[1] = 0;
            BeforeStart.placeDic[1].times[2] = 5;
            BeforeStart.placeDic[1].times[3] = 10;
            BeforeStart.placeDic[1].times[4] = 15;
            BeforeStart.placeDic[1].times[5] = 5;
            BeforeStart.placeDic[1].times[6] = 7;
            BeforeStart.placeDic[1].times[7] = 10;
            BeforeStart.placeDic[1].times[8] = 15;
            BeforeStart.placeDic[1].times[9] = 28;
            BeforeStart.placeDic[1].times[10] = 25;

            // Place 2: EmptyHouse-2 Time Data Sheet
            BeforeStart.placeDic[2].times[0] = 26;
            BeforeStart.placeDic[2].times[1] = 5;
            BeforeStart.placeDic[2].times[2] = 0;
            BeforeStart.placeDic[2].times[3] = 5;
            BeforeStart.placeDic[2].times[4] = 10;
            BeforeStart.placeDic[2].times[5] = 7;
            BeforeStart.placeDic[2].times[6] = 5;
            BeforeStart.placeDic[2].times[7] = 7;
            BeforeStart.placeDic[2].times[8] = 12;
            BeforeStart.placeDic[2].times[9] = 26;
            BeforeStart.placeDic[2].times[10] = 23;

            // Place 3: EmptyHouse-3 Time Data Sheet
            BeforeStart.placeDic[3].times[0] = 23;
            BeforeStart.placeDic[3].times[1] = 10;
            BeforeStart.placeDic[3].times[2] = 5;
            BeforeStart.placeDic[3].times[3] = 0;
            BeforeStart.placeDic[3].times[4] = 5;
            BeforeStart.placeDic[3].times[5] = 12;
            BeforeStart.placeDic[3].times[6] = 7;
            BeforeStart.placeDic[3].times[7] = 5;
            BeforeStart.placeDic[3].times[8] = 7;
            BeforeStart.placeDic[3].times[9] = 23;
            BeforeStart.placeDic[3].times[10] = 20;

            // Place 4: EmptyHouse-4 Time Data Sheet
            BeforeStart.placeDic[4].times[0] = 20;
            BeforeStart.placeDic[4].times[1] = 15;
            BeforeStart.placeDic[4].times[2] = 10;
            BeforeStart.placeDic[4].times[3] = 5;
            BeforeStart.placeDic[4].times[4] = 0;
            BeforeStart.placeDic[4].times[5] = 17;
            BeforeStart.placeDic[4].times[6] = 12;
            BeforeStart.placeDic[4].times[7] = 7;
            BeforeStart.placeDic[4].times[8] = 5;
            BeforeStart.placeDic[4].times[9] = 20;
            BeforeStart.placeDic[4].times[10] = 17;

            // Place 5: EmptyHouse-5 Time Data Sheet
            BeforeStart.placeDic[5].times[0] = 28;
            BeforeStart.placeDic[5].times[1] = 5;
            BeforeStart.placeDic[5].times[2] = 7;
            BeforeStart.placeDic[5].times[3] = 12;
            BeforeStart.placeDic[5].times[4] = 17;
            BeforeStart.placeDic[5].times[5] = 0;
            BeforeStart.placeDic[5].times[6] = 5;
            BeforeStart.placeDic[5].times[7] = 7;
            BeforeStart.placeDic[5].times[8] = 12;
            BeforeStart.placeDic[5].times[9] = 28;
            BeforeStart.placeDic[5].times[10] = 25;

            // Place 6: EmptyHouse-6 Time Data Sheet
            BeforeStart.placeDic[6].times[0] = 26;
            BeforeStart.placeDic[6].times[1] = 7;
            BeforeStart.placeDic[6].times[2] = 5;
            BeforeStart.placeDic[6].times[3] = 7;
            BeforeStart.placeDic[6].times[4] = 12;
            BeforeStart.placeDic[6].times[5] = 5;
            BeforeStart.placeDic[6].times[6] = 0;
            BeforeStart.placeDic[6].times[7] = 5;
            BeforeStart.placeDic[6].times[8] = 7;
            BeforeStart.placeDic[6].times[9] = 26;
            BeforeStart.placeDic[6].times[10] = 23;

            // Place 7: EmptyHouse-7 Time Data Sheet
            BeforeStart.placeDic[7].times[0] = 23;
            BeforeStart.placeDic[7].times[1] = 10;
            BeforeStart.placeDic[7].times[2] = 7;
            BeforeStart.placeDic[7].times[3] = 5;
            BeforeStart.placeDic[7].times[4] = 7;
            BeforeStart.placeDic[7].times[5] = 7;
            BeforeStart.placeDic[7].times[6] = 5;
            BeforeStart.placeDic[7].times[7] = 0;
            BeforeStart.placeDic[7].times[8] = 7;
            BeforeStart.placeDic[7].times[9] = 23;
            BeforeStart.placeDic[7].times[10] = 20;

            // Place 8: EmptyHouse-8 Time Data Sheet
            BeforeStart.placeDic[8].times[0] = 20;
            BeforeStart.placeDic[8].times[1] = 15;
            BeforeStart.placeDic[8].times[2] = 12;
            BeforeStart.placeDic[8].times[3] = 7;
            BeforeStart.placeDic[8].times[4] = 5;
            BeforeStart.placeDic[8].times[5] = 12;
            BeforeStart.placeDic[8].times[6] = 7;
            BeforeStart.placeDic[8].times[7] = 7;
            BeforeStart.placeDic[8].times[8] = 0;
            BeforeStart.placeDic[8].times[9] = 20;
            BeforeStart.placeDic[8].times[10] = 17;

            // Place 9: Public Well Time Data Sheet
            BeforeStart.placeDic[9].times[0] = 7;
            BeforeStart.placeDic[9].times[1] = 18;
            BeforeStart.placeDic[9].times[2] = 26;
            BeforeStart.placeDic[9].times[3] = 23;
            BeforeStart.placeDic[9].times[4] = 20;
            BeforeStart.placeDic[9].times[5] = 28;
            BeforeStart.placeDic[9].times[6] = 26;
            BeforeStart.placeDic[9].times[7] = 23;
            BeforeStart.placeDic[9].times[8] = 20;
            BeforeStart.placeDic[9].times[9] = 0;
            BeforeStart.placeDic[9].times[10] = 5;

            // Place 10: Residence Street Time Data Sheet
            BeforeStart.placeDic[10].times[0] = 5;
            BeforeStart.placeDic[10].times[1] = 25;
            BeforeStart.placeDic[10].times[2] = 23;
            BeforeStart.placeDic[10].times[3] = 20;
            BeforeStart.placeDic[10].times[4] = 17;
            BeforeStart.placeDic[10].times[5] = 25;
            BeforeStart.placeDic[10].times[6] = 23;
            BeforeStart.placeDic[10].times[7] = 20;
            BeforeStart.placeDic[10].times[8] = 17;
            BeforeStart.placeDic[10].times[9] = 5;
            BeforeStart.placeDic[10].times[10] = 0;
        }
    }
}
