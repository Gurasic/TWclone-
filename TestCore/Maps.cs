using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.NPCs;

namespace Test
{
    internal class Maps
    {
        public static BeforeStart.place LastPlayerLocation;
        public static void NpcLogic() 
        {
            ReikaNPC.Reika();
            ReikaNPC.ReikaConv();
            MollyNPC.MollyMovmentLogic();
            MollyNPC.MollyConv();
        }
        public static void ImportantNPCStuff() 
        {
            for (int c = 1; c < BeforeStart.npcDic.Count; c++)
            {
                if (BeforeStart.npcDic[c] != null && BeforeStart.npcDic[c].PlayerSelected)
                {
                    BeforeStart.npcDic[c].PlayerSelected = false;
                }
            }
        }
        public static void MovingTimeLogic(int place) 
        {
            options.PlayerTimeRight += LastPlayerLocation.times[place];
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Moving to " + options.PlayerLocation.Name);
            Console.WriteLine();
            Console.ReadLine();
            Program.Write("{=Blue}-----------------------------------{/}");
            Console.WriteLine();
            Program.Write("{=Blue}|                                 |{/}");
            Console.WriteLine();
            Program.Write("{=Blue}       +"+ LastPlayerLocation.times[place]+ " Minutes....             {/}");
            Console.WriteLine();
            Program.Write("{=Blue}|                                 |{/}");
            Console.WriteLine();
            Program.Write("{=Blue}-----------------------------------{/}");
            Console.ReadLine();
            PlayerScreen.MainScreen();
        }
        public static void Human_City() 
        {
            NpcLogic();
            Console.WriteLine("═════════════════════════════════════════════════════════════════════════════════════════════════════");
            Console.WriteLine("");
            Program.Write("{=Green}♠♠♠♠♠♠♠♠♠♠♠♠♠♠♠♠♠♠♠♠♠♠♠♠♠♠♠♠♠♠♠♠♠♠♠♠♠♠♠♠♠♠♠♠♠♠♠♠♠♠♠♠♠♠♠♠♠♠♠♠♠♠♠♠♠♠♠♠♠♠♠♠♠{/}");
            Console.WriteLine("");
            Program.Write("{=Green}♠♠♠♠♠♠♠♠♠♠♠                                 ♠♠♠♠♠♠♠♠♠                   ♠{/}");
            Console.WriteLine(""); 
            Program.Write("{=Green}♠      ♠♠♠                                   ♠♠♠                        ♠{/}");
            Console.WriteLine("");
            Program.Write("{=Green}♠                             {/}{=DarkYellow}■────────────■           ■────■───■ {/}{=Green} ♠{/}");
            Console.WriteLine("");
            Program.Write("{=Green}♠     {/}{=DarkYellow}■────■───────■       │             │          ∙ │     │    │   {/}{=Green}♠{/}");
            Console.WriteLine("");
            Program.Write("{=Green}♠♠    {/}{=DarkYellow}│     │        │  .     │ [5]         │       ∙ ∙          [4]│   {/}{=Green}♠{/}");
            Console.WriteLine("");
            Program.Write("{=Green}♠♠    {/}{=DarkYellow}│       [2]      . .    │             │      ∙  ∙  │     │    │   {/}{=Green}♠{/}");
            Console.WriteLine("");
            Program.Write("{=Green}♠♠    {/}{=DarkYellow}│     │        │ ...    │             │     ∙ ∙    ■────■───■ {/}{=Green}♠♠{/}");
            Console.WriteLine("");
            Program.Write("{=Green}♠     {/}{=DarkYellow}■────■───────■  ..   ■─────  ─────■    ∙ ∙ ∙                {/}{=Green}♠♠{/}");
            Console.WriteLine("");
            Program.Write("{=Green}♠{/}{=DarkYellow}                       .              ∙          ∙ ∙                 {/}{=Green}♠♠♠{/}");
            Console.WriteLine("");
            Program.Write("{=Green}♠{/}{=DarkYellow}                         .           ∙  ∙ ∙ ∙ ∙ ∙    ∙               {/}{=Green}♠♠♠{/}");
            Console.WriteLine("");
            Program.Write("{=Green}♠{/}{=DarkYellow}    ┌──┐ ┌──┐ ┌──┐ ┌──┐ .             ∙ ∙  ∙   ∙ ∙                 {/}{=Green}♠♠♠♠♠{/}");
            Console.WriteLine("");
            Program.Write("{=Green}♠{/}{=DarkYellow}    │  │ │  │ │  │ │  │  .             ∙                           {/}{=Green}♠♠♠♠♠{/}");
            Console.WriteLine("");
            Program.Write("{=Green}♠♠{/}{=DarkYellow}   └  ┘.└  ┘ └  ┘.└  ┘.  .         ∙∙∙                              {/}{=Green}♠♠♠{/}");
            Console.WriteLine("");
            Program.Write("{=Green}♠♠♠{/}{=DarkYellow}    .    .  .  . . .  .          ∙  ∙      ■───────■              {/}{=Green}♠♠{/}");
            Console.WriteLine("");
            Program.Write("{=Green}♠♠♠{/}{=DarkYellow}  ┌  ┐ ┌  ┐ ┌  ┐ ┌  ┐  .         ∙  ∙      │        │                {/}{=Green}♠{/}");
            Console.WriteLine("");
            Program.Write("{=Green}♠♠♠♠{/}{=DarkYellow} │  │ │  │ │  │ │  │ .            ∙     ∙ ■─  ────■               {/}{=Green}♠{/}");
            Console.WriteLine("");
            Program.Write("{=Green}}♠♠♠♠{/}{=DarkYellow} └──┘ └──┘ └──┘ └──┘. .         ∙  ∙ . . .  . .[3] . .. . .         {/}{=Green}♠{/}");
            Console.WriteLine("");
            Program.Write("{=Green}♠♠{/}{=DarkYellow}                      .         ∙ ∙  ..  . . .  . .  .  . .           {/}{=Green}♠{/}");
            Console.WriteLine("");
            Program.Write("{=Green}♠{/}{=DarkYellow}  ┌──┐  .  [1]  . .  .  . ∙ ∙    .  . ■─  ─■  ■─  ─■  ■─  ─■     {/}{=Green}♠{/}");
            Console.WriteLine("");
            Program.Write("{=Green}♠{/}{=DarkYellow}  │     .  .  .  .  . .  . . ∙ . .. . │     │   │     │   │     │     {/}{=Green}♠♠{/}");
            Console.WriteLine("");
            Program.Write("{=Green}♠{/}{=DarkYellow}  │  │    .  .       . . .   .  . .   │     │   │     │   │     │     {/}{=Green}♠♠{/}");
            Console.WriteLine("");
            Program.Write("{=Green}♠♠{/}{=DarkYellow} └──┘                      .  . .    ■────■  ■────■  ■────■   {/}{=Green}♠♠♠{/}");
            Console.WriteLine("");
            Program.Write("{=Green}♠♠{/}{=DarkYellow}                            .  .  .                               {/}{=Green}♠♠♠♠♠{/}");
            Console.WriteLine("");
            Program.Write("{=Green}♠♠♠♠♠♠♠♠♠♠♠♠♠♠♠♠♠♠♠♠♠♠♠♠♠♠♠♠♠♠       ♠♠♠♠♠♠♠♠♠♠♠♠♠♠♠♠♠♠♠♠♠♠♠♠♠♠♠♠♠♠♠♠♠♠♠♠{/}");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("═════════════════════════════════════════════════════════════════════════════════════════════════════");
            Console.WriteLine("[1] Residence Area    [2] Library    [3] Shoping District   [4] Bath/Sauna    [5] EmptyZone");
            Console.WriteLine("[0] Go to your House");
            Console.WriteLine("[99] Return");
            string sl = Console.ReadLine();
            if (sl == "1") { Console.Clear(); Residence_Area(); }
            if (sl == "99") { Console.Clear(); PlayerScreen.MainScreen(); }
            if (sl == "2") { PlayerScreen.TimeUsage(30); Console.Clear(); Library_Area(); }
        }
        public static void Residence_Area()
        {
            NpcLogic();
            Console.WriteLine("═════════════════════════════════════════════════════════════════════════════════════════════════════");
            Console.WriteLine("");
            Program.Write("{=Green}♠             ♠        ♠{/}");
            Console.WriteLine("");
            Program.Write("{=DarkYellow}  ╔═════╗  ╔═════╗  ╔═════╗  ╔═════╗{/}");
            Console.WriteLine("");
            Program.Write("{=DarkYellow}  ║     ║  ║     ║  ║     ║  ║     ║  {/}{=Green}♠{/}{=DarkYellow} {/}");
            Console.WriteLine("");
            Program.Write("{=DarkYellow}  ║ [1] ║{/}{=Green}♠{/}{=DarkYellow} ║ [2] ║  ║ [3] ║  ║ [4] ║{/}");
            Console.WriteLine("");
            Program.Write("{=DarkYellow}  ║     ║  ║     ║  ║     ║  ║     ║ {/}{=Green}♠{/}{=DarkYellow}{/}");
            Console.WriteLine("");
            Program.Write("{=DarkYellow}  ╚══ ══╝  ╚══ ══╝  ╚══ ══╝  ╚══ ══╝{/}");
            Console.WriteLine("");
            Program.Write("{=DarkYellow}   ∙      ∙   ∙   ∙ ∙     ∙      ∙    ∙{/}");
            Console.WriteLine("");
            Program.Write("{=DarkYellow} ∙∙  ∙    ∙∙        ∙ ∙   ∙   ∙ ∙  ∙ {/}");
            Console.WriteLine("");
            Program.Write("{=DarkYellow}  ╔══ ══╗  ╔══ ══╗  ╔══ ══╗  ╔══ ══╗  ∙ {/}");
            Console.WriteLine("");
            Program.Write("{=Green}♠{/}{=DarkYellow} ║     ║  ║     ║  ║     ║  ║     ║   ∙{/}");
            Console.WriteLine("");
            Program.Write("{=DarkYellow}  ║ [5] ║ {/}{=Green}♠{/}{=DarkYellow}║ [6] ║  ║ [7] ║  ║ [8] ║{/}");
            Console.WriteLine("");
            Program.Write("{=DarkYellow}  ║     ║  ║     ║  ║     ║  ║     ║   ∙{/}");
            Console.WriteLine("");
            Program.Write("{=DarkYellow}  ╚═════╝  ╚═════╝  ╚═════╝  ╚═════╝  ∙ {/}");
            Console.WriteLine("");
            Program.Write("{=DarkYellow}     {/}{=Green}♠{/}{=DarkYellow}                 {/}{=Green}♠{/}{=DarkYellow}            ∙{/}");
            Console.WriteLine("");
            Program.Write("{=DarkYellow}                {/}{=Green}♠{/}{=DarkYellow}                 {/}{=Green}♠{/}{=DarkYellow}    ∙{/}");
            Console.WriteLine("");
            Program.Write("{=DarkYellow}  ╔═════╗                   {/}{=Green}♠{/}{=DarkYellow}        ∙ {/}");
            Console.WriteLine("");
            Program.Write("{=DarkYellow}  ║     ║         ∙              ∙ ∙  ∙{/}");
            Console.WriteLine("");
            Program.Write("{=DarkYellow}  ║          ∙ ∙   ∙    ∙   ∙ ∙ ∙ [11]->{/}");
            Console.WriteLine("");
            Program.Write("{=DarkYellow} {/}{=Green}♠{/}{=DarkYellow}║ [9] ║  ∙          ∙    ∙     ∙∙  ∙ {/}");
            Console.WriteLine("");
            Program.Write("{=DarkYellow}  ║     ║                |---|     ∙  ∙{/}");
            Console.WriteLine("");
            Program.Write("{=DarkYellow}  ╚═════╝        {/}{=Green}♠{/}{=DarkYellow}       | 0 |[10]  ∙{/}");
            Console.WriteLine("");
            Program.Write("{=DarkYellow}  {/}{=Green}♠{/}{=DarkYellow}        {/}{=Green}♠{/}{=DarkYellow}             |---|     ∙  ∙{/}");
            Console.WriteLine("");
            Program.Write("{=DarkYellow}                                      ∙{/}");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("═════════════════════════════════════════════════════════════════════════════════════════════════════");
            Console.WriteLine("[1] Reika's House    [2] EmptyHouse-2    [3] EmptyHouse-3    [4] EmptyHouse-4    [5] EmptyHouse-5");
            Console.WriteLine("[6] EmptyHouse-6     [7] EmptyHouse-7    [8] EmptyHouse-8    [9] Public Well     [10] Residence Street");
            Console.WriteLine("[0] Go to your House ");
            Console.WriteLine("[99] Return          [100] Go to Village Map");
            Console.WriteLine("You are on: " + options.PlayerLocation.Name);
            for (int i = 0; i < BeforeStart.placeDic[0].space.Length; i++)
            {
                if (BeforeStart.placeDic[0].space[i] != null )
                {
                    Console.WriteLine("You find: " + BeforeStart.placeDic[0].space[i].Name);
                }
            }
            string sl = Console.ReadLine();
            for (int i = 0; i < BeforeStart.placeDic.Count; i++)
            {
                if (sl == Convert.ToString(i))
                {
                    
                    LastPlayerLocation = options.PlayerLocation;
                    options.PlayerLocation = BeforeStart.placeDic[i];
                    ImportantNPCStuff();
                    MovingTimeLogic(i);
                }
            }
            if (sl == "99") { Console.Clear(); PlayerScreen.MainScreen(); }
            if (sl == "100") { Console.Clear(); Human_City(); }
            else { Console.Clear(); Residence_Area(); }
        }
        public static void Library_Area()
        {
            NpcLogic();
            Console.WriteLine("═════════════════════════════════════════════════════════════════════════════════════════════════════");
            Console.WriteLine("═════════════════════════════════════════════════════════════════════════════════════════════════════");
            Console.WriteLine("[1] Main Hall     [2] Elfina's House");
            Console.WriteLine("[0] Go to your House ");
            Console.WriteLine("[99] Return          [100] Go to Village Map");
            Console.WriteLine("You are on: " + options.PlayerLocation.Name);
            for (int i = 0; i < BeforeStart.placeDic[0].space.Length; i++)
            {
                if (BeforeStart.placeDic[0].space[i] != null)
                {
                    Console.WriteLine("You find: " + BeforeStart.placeDic[0].space[i].Name);
                }
            }
            string sl = Console.ReadLine();
            for (int i = 0; i < BeforeStart.placeDic.Count; i++)
            {
                if (sl == Convert.ToString(0)) 
                {
                    LastPlayerLocation = options.PlayerLocation;
                    options.PlayerLocation = BeforeStart.placeDic[0];
                    ImportantNPCStuff();
                    MovingTimeLogic(i);
                }
                else if (sl == Convert.ToString(i))
                {
                    i += 10;
                    LastPlayerLocation = options.PlayerLocation;
                    options.PlayerLocation = BeforeStart.placeDic[i];
                    ImportantNPCStuff();
                    MovingTimeLogic(i);
                }
            }
            if (sl == "99") { Console.Clear(); PlayerScreen.MainScreen(); }
            if (sl == "100") { PlayerScreen.TimeUsage(30); Console.Clear(); Human_City(); }
            else { Console.Clear(); Library_Area(); }
        }
    }

}
