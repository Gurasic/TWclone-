using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test;

namespace TestCore.Data.NPCs
{
    internal class ElfinaNPC
    {
        public static void Elfina()
        {
            BeforeStart.npcDic[3].ImagePath = @"C:\Users\Amr\source\repos\Test\TestCore\reikaNPC.png";
            BeforeStart.npcDic[3].ImagePoint1 = 150;
            BeforeStart.npcDic[3].ImagePoint2 = 200;
            BeforeStart.npcDic[3].ImageSize1 = 100;
            BeforeStart.npcDic[3].ImageSize2 = 20;

            // if (options.PlayerTimeLeft >= 1 && options.PlayerTimeRight >= 1 && BeforeStart.ThereIsXNPCInThePlace(2, BeforeStart.npcDic[1]))
            // {
            //     BeforeStart.placeDic[0].space[1] = BeforeStart.npcDic[1];
            //   BeforeStart.placeDic[2].space[1] = null;
            // }
            // if (options.PlayerTimeLeft >= 2 && options.PlayerTimeRight >= 1 && BeforeStart.ThereIsXNPCInThePlace(0, BeforeStart.npcDic[1]))
            // {
            //     BeforeStart.placeDic[1].space[1] = BeforeStart.npcDic[1];
            //     BeforeStart.placeDic[0].space[1] = null;
            // }
            // if (options.PlayerTimeLeft >= 3 && options.PlayerTimeRight >= 1 && BeforeStart.ThereIsXNPCInThePlace(1, BeforeStart.npcDic[1]))
            // {
            //     BeforeStart.placeDic[2].space[1] = BeforeStart.npcDic[1];
            //     BeforeStart.placeDic[1].space[1] = null;
            // }
        }
        public static void ElfinaConv()
        {
            // Conversation 1
            BeforeStart.npcDic[3].ConvLine1[1] = "{=Magenta}⌊ Fuck you ⌉{/}";
            BeforeStart.npcDic[3].ConvLine2[1] = "{=Magenta}⌊ Kiss my ass ⌉{/}";
            BeforeStart.npcDic[3].ConvLine3[1] = "{=Magenta}⌊ Get real ⌉{/}";
            
            // Conversation 2
            BeforeStart.npcDic[3].ConvLine1[2] = "{=Magenta}⌊ get fucking real ⌉{/}";
            BeforeStart.npcDic[3].ConvLine2[2] = "{=Magenta}⌊ shut the fuck up you stupid bitch ⌉{/}";
            BeforeStart.npcDic[3].ConvLine3[2] = "{=Magenta}⌊ it fucking works and thats what matters ⌉{/}";

            // Conversation 3
            BeforeStart.npcDic[3].ConvLine1[3] = "{=Magenta}⌊ ... ⌉{/}";
            BeforeStart.npcDic[3].ConvLine2[3] = "{=Magenta}⌊ ....... ⌉{/}";
            BeforeStart.npcDic[3].ConvLine3[3] = "{=Magenta}⌊ ........... ⌉{/}";
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
            BeforeStart.npcDic[3].PlayerMeet = true;
        }
    }
}
