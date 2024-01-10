using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static Test.BeforeStart;

namespace Test.NPCs
{
    internal class ReikaNPC
    {
        public static void Reika() 
        {
            BeforeStart.npcDic[1].ImagePath = @"C:\Users\Amr\source\repos\Test\TestCore\reikaNPC.png";
            BeforeStart.npcDic[1].ImagePoint1 = 150;
            BeforeStart.npcDic[1].ImagePoint2 = 200;
            BeforeStart.npcDic[1].ImageSize1 = 100;
            BeforeStart.npcDic[1].ImageSize2 = 20;

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
        public static void ReikaConv() 
        {
            // Conversation 1
            BeforeStart.npcDic[1].ConvLine1[1] = "{=Green}⌊ Today i saw some incredible things ⌉{/}";
            BeforeStart.npcDic[1].ConvLine2[1] = "{=Green}⌊ There was a strange Creature in the Forest ⌉{/}";
            BeforeStart.npcDic[1].ConvLine3[1] = "{=Green}⌊ I was amazed when i saw it ⌉{/}";

            // Conversation 2
            BeforeStart.npcDic[1].ConvLine1[2] = "{=Green}⌊ get fucking real ⌉{/}";
            BeforeStart.npcDic[1].ConvLine2[2] = "{=Green}⌊ shut the fuck up you stupid bitch ⌉{/}";
            BeforeStart.npcDic[1].ConvLine3[2] = "{=Green}⌊ it fucking works and thats what matters ⌉{/}";

            // Conversation 3
            BeforeStart.npcDic[1].ConvLine1[3] = "{=Green}⌊ ... ⌉{/}";
            BeforeStart.npcDic[1].ConvLine2[3] = "{=Green}⌊ ....... ⌉{/}";
            BeforeStart.npcDic[1].ConvLine3[3] = "{=Green}⌊ ........... ⌉{/}";
        }

        public static void GreatingsDialogue() 
        {
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Program.Write("{=DarkGray}You see a woman, with a green hair, a circular eye glasses, and a fair skin{/}");
            Console.ReadLine();
            Program.Write("{=DarkGray}observing her surroundings. she's writing on her notebook while{/}");
            Console.ReadLine();
            Program.Write("{=DarkGray}observing her surroundings, being able to write while not looking is on{/}");
            Console.ReadLine();
            Program.Write("{=DarkGray}what's she's supposed to write is an amazing feat.{/}");
            Console.ReadLine();
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Program.Write("{=DarkGray}Reika finally notices you, she observes you for a brief moment while {/}");
            Console.ReadLine();
            Program.Write("{=DarkGray}writing at her notebook, she then shifted her attention somewhere else{/}");
            Console.ReadLine();
            Program.Write("{=DarkGray}she doesn't seem to care about your existence at all.{/}");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("[1] Introduce Yourself");
            Console.WriteLine("[2] Ignore Her Exsistence");
            string sw = Console.ReadLine();
            if (sw == "1") 
            {
                Console.WriteLine(""); 
                Console.WriteLine("");
                Console.WriteLine("");
                Program.Write("{=DarkGray}As you give out your name, Reika finally notices you existence, for once.{/}");
                Console.ReadLine();
                Console.WriteLine("");
                Program.Write("{=Green}⌊ Hmmm, " + Program.playerName + ", is it? ⌉{/}");
                Console.ReadLine();
                Console.WriteLine("");
                Program.Write("{=DarkGray}Reika continues to write at her notebook, you have a tinge feeling that{/}");
                Console.WriteLine("");
                Program.Write("{=DarkGray}she wrote something about you in her notebook.{/}");
                Console.ReadLine();
                Program.Write("{=DarkGray}In turn, Reika introduces herself as well.{/}");
                Console.ReadLine();
                Console.WriteLine("");
                Program.Write("{=Green}⌊ My name is Reika, it's a nice day isn't it? ⌉{/}");
                Console.ReadLine();
                Console.WriteLine("");
                Program.Write("{=DarkGray}Reika remains emotionless as her attention begins to shift somewhere {/}");
                Console.WriteLine("");
                Program.Write("{=DarkGray}else after introducing herself{/}");
                Console.ReadLine();
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("Reika is now your acquaintance.");
                Console.ReadLine();
                BeforeStart.npcDic[1].PlayerMeet = true;
            }
            else
            {
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");
                Program.Write("{=DarkGray}As you ignore Reika's existence, Reika doesn't seem to care about being {/}");
                Console.WriteLine("");
                Program.Write("{=DarkGray}ignored, instead, she continues to do her things, observing and writing.{/}");
                Console.ReadLine();
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("Reika remains a stranger but she knows of your existence");
                Console.ReadLine();
                BeforeStart.npcDic[1].PlayerMeet = true;
            }
        }
    }
}
