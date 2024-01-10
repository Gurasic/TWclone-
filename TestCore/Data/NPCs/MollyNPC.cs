using System;using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    internal class MollyNPC
    {
        public static void MollyMovmentLogic()
        {

        }
        public static void MollyConv()
        {

            // Conversation 1
            BeforeStart.npcDic[2].ConvLine1[1] = "{=Red}⌊ ... ⌉{/}";
            BeforeStart.npcDic[2].ConvLine2[1] = "{=Red}⌊ ....... ⌉{/}";
            BeforeStart.npcDic[2].ConvLine3[1] = "{=Red}⌊ ........... ⌉{/}";

            // Conversation 2
            BeforeStart.npcDic[2].ConvLine1[2] = "{=Red}⌊ ... ⌉{/}";
            BeforeStart.npcDic[2].ConvLine2[2] = "{=Red}⌊ ....... ⌉{/}";
            BeforeStart.npcDic[2].ConvLine3[2] = "{=Red}⌊ ........... ⌉{/}";

            // Conversation 3
            BeforeStart.npcDic[2].ConvLine1[3] = "{=Red}⌊ ... ⌉{/}";
            BeforeStart.npcDic[2].ConvLine2[3] = "{=Red}⌊ ....... ⌉{/}";
            BeforeStart.npcDic[2].ConvLine3[3] = "{=Red}⌊ ........... ⌉{/}";

            // Skinship 1 (below 500 Favor)
            BeforeStart.npcDic[2].ConvLine1[301] = "{=Red}⌊ ¿What? ⌉{/}";
            BeforeStart.npcDic[2].ConvLine2[301] = "{=Red}⌊ Dont get too close to me ⌉{/}";
            BeforeStart.npcDic[2].ConvLine3[301] = "{=Red}⌊ Dumbass... ⌉{/}";

            // Skinship 2 (below 500 Favor)
            BeforeStart.npcDic[2].ConvLine1[302] = "{=Red}⌊ ¿well? ⌉{/}";
            BeforeStart.npcDic[2].ConvLine2[302] = "{=Red}⌊ ....... ⌉{/}";
            BeforeStart.npcDic[2].ConvLine3[302] = "{=Red}⌊ ........... ⌉{/}";

            // Skinship 3 (below 500 Favor)
            BeforeStart.npcDic[2].ConvLine1[303] = "{=Red}⌊ ¿not good? ⌉{/}";
            BeforeStart.npcDic[2].ConvLine2[303] = "{=Red}⌊ ....... ⌉{/}";
            BeforeStart.npcDic[2].ConvLine3[303] = "{=Red}⌊ ........... ⌉{/}";

            // Skinship 51 (above 500 Favor)
            BeforeStart.npcDic[2].ConvLine1[351] = "{=Red}⌊ i Liked that ⌉{/}";
            BeforeStart.npcDic[2].ConvLine2[351] = "{=Red}⌊ ....... ⌉{/}";
            BeforeStart.npcDic[2].ConvLine3[351] = "{=Red}⌊ ........... ⌉{/}";

            // Skinship 52 (above 500 Favor)
            BeforeStart.npcDic[2].ConvLine1[352] = "{=Red}⌊ Funny man ⌉{/}";
            BeforeStart.npcDic[2].ConvLine2[352] = "{=Red}⌊ ....... ⌉{/}";
            BeforeStart.npcDic[2].ConvLine3[352] = "{=Red}⌊ ........... ⌉{/}";

            // Skinship 53 (above 500 Favor)
            BeforeStart.npcDic[2].ConvLine1[353] = "{=Red}⌊ very silly ⌉{/}";
            BeforeStart.npcDic[2].ConvLine2[353] = "{=Red}⌊ ....... ⌉{/}";
            BeforeStart.npcDic[2].ConvLine3[353] = "{=Red}⌊ ........... ⌉{/}";
        }
        public static void GreatingsDialogue()
        {
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Program.Write("{=DarkGray}......{/}");
            Console.ReadLine();
            Program.Write("{=DarkGray}...{/}");
            Console.ReadLine();
            BeforeStart.npcDic[2].PlayerMeet = true;
        }
    }
}
