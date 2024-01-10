using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Test.NPCs;

namespace Test
{
    public class BeforeStart
    {
        public class skill 
        { 
            public string Name { get; set; }
        }
        public class item 
        { 
            public string Name { get; set; }
            public int amount {  get; set; }
            public bool payerOwned { get; set; }
            public bool IsEquipable { get; set; }
            public bool playerEquiped { get; set; }
            public string ItemDescription { get; set; }
        }
        public class npc 
        { 
            public string Name { get; set; }
            public string FamillyName {  get; set; }
            public bool PlayerMeet { get; set; }
            public bool PlayerSelected { get; set; }
            public int NPCFavor {  get; set; }
            public int NPCTrust { get; set; }
            public string Color { get; set; }

           public string[] ConvLine1 = new string[20];
           public string[] ConvLine2 = new string[20];
           public string[] ConvLine3 = new string[20];

           public Program.ProgressBarInfo NPCEnergyBar { get; set; }
           public Program.ProgressBarInfo NPCStaminaBar { get; set; }
        }
        public class place 
        {
            public string Name { get; set; }
            public npc[] space = new npc[5];
            public int[] times = new int[11];
        }

        public static Dictionary<int, item> itemDic = new Dictionary<int, item>();
        public static Dictionary<int,place> placeDic = new Dictionary<int,place>();
        public static Dictionary<int, npc> npcDic = new Dictionary<int, npc>();
        public static void GiveItems(int ID, int amount)
        {
            itemDic[ID].payerOwned = true;
            itemDic[ID].amount += amount;
        }
        public static void RemoveItems(int ID, int amount)
        {
            itemDic[ID].amount -= amount;
        }
        public static void CreateItem(string name, int ID, bool Equipable)
        {
            itemDic[ID] = new item { Name = name, IsEquipable = Equipable };        
        }
        public static bool ItemIsOnPlayrInv(int ID) 
        { 
            if (itemDic[ID].payerOwned) 
            { 
                return true; 
            }
            else 
            { 
                return false; 
            }
        }
        public static void CreatePlace(string name, int ID) 
        {
            placeDic[ID] = new place { Name = name };
        }
        public static bool ThereIsNoOneInThePlace(int ID) 
        {
            if (placeDic[ID].space.Contains(null)) 
            {
                return true;
            }
            else { return false; }
        }
        public static bool ThereIsXNPCInThePlace(int ID, npc Npc)
        {
            if (placeDic[ID].space.Contains(Npc))
            {
                return true;
            }
            else { return false; }
        }
        public static void CreateNpc(string name, int ID, string color) 
        {
            npcDic[ID] = new npc { Name = name, Color = color };
        }
        public static void CalculateDayLogic() 
        { 
        if (options.DayCounter == 32) { options.DayCounter = 1; options.MonthCounter++; }
        }
        public static void CalculateTimeLogic() 
        {
            // Time Logic
            string empty0 = "0";
            string empty02 = "0";
            int time = 60;
            if (options.PlayerTimeRight >= 60) { options.PlayerTimeRight -= time; options.PlayerTimeLeft++;  }
            if (options.PlayerTimeLeft >= 24) {  options.PlayerTimeLeft = 1; }
            if (options.PlayerTimeRight >= 10) { empty02 = ""; }
            if (options.PlayerTimeLeft >= 10) { empty0 = ""; }
            Console.Write(empty0 + options.PlayerTimeLeft + ":" + empty02 + options.PlayerTimeRight);
        }
        public static void CalculateMonthLogic()
        {
            if (options.MonthCounter == 13) { options.YearCounter++; options.MonthCounter = 1; }
            if (options.MonthCounter == 1) { options.MonthName = "[January]"; }
            if (options.MonthCounter == 2) { options.MonthName = "[Febuary]"; }
            if (options.MonthCounter == 3) { options.MonthName = "[March]"; }
            if (options.MonthCounter == 4) { options.MonthName = "[April]"; }
            if (options.MonthCounter == 5) { options.MonthName = "[May]"; }
            if (options.MonthCounter == 6) { options.MonthName = "[June]"; }
            if (options.MonthCounter == 7) { options.MonthName = "[July]"; }
            if (options.MonthCounter == 8) { options.MonthName = "[August]"; }
            if (options.MonthCounter == 9) { options.MonthName = "[September]"; }
            if (options.MonthCounter == 10) { options.MonthName = "[October]"; }
            if (options.MonthCounter == 11) { options.MonthName = "[November]"; }
            if (options.MonthCounter == 12) { options.MonthName = "[December]"; }
        }
        public static void BeforeStarMenu() 
        {
            GiveItems(1, 1);
            GiveItems(0, 1);
            options.PlayerLocation = BeforeStart.placeDic[0];
            CalculateDayLogic();
            CalculateMonthLogic();
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("═════════════════════════════════════════════════════════════════════════════════════════════════════");
            Console.Write("Day: " + options.DayCounter + ",  Month: " + options.MonthName + ",  Year: " + options.YearCounter + "    " + options.MoneyCounter + "$    ");
            CalculateTimeLogic();
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("   [1] Start Day");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("   [99] Save");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            string w = Console.ReadLine();

            if (w == "1") { PlayerScreen.MainScreen(); }
        }
    }
}
