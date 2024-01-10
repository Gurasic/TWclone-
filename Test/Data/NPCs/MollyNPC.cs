using System;
using System.Collections.Generic;
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
