using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Policy;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Test.NPCs;

namespace Test
{

    public class BeforeStart
    {
        public static Random random = new Random();
        public static double baseExp = 500;
        public static double initialMultiplier = 1.3;
        public static double increment = 0.1; 

        public static double CalculateRequiredExpForLevel(int level)
        {
           
            double expMultiplier = BeforeStart.initialMultiplier + (level - 1) * BeforeStart.increment;
            return BeforeStart.baseExp * Math.Pow(expMultiplier, level - 1);
        }
        public class book 
        { 
            public string Name { get; set; }
            public bool PlayerEquiped { get; set; }
            public bool IsInStock { get; set; }
            public int DayCounter = 7;
        
        }
        public class skill 
        { 
            public string Name { get; set; }
            public int Level { get; set; }
            public Program.ProgressBarInfo SkillProgressBar { get; set; }
        }
        public class item 
        { 
            public string Name { get; set; }
            public int amount { get; set; }
            public bool payerOwned { get; set; }
            public bool IsEquipable { get; set; }
            public bool playerEquiped { get; set; }
            public string ItemDescription { get; set; }
        }
        public class foodItem : item 
        { 
            public bool isMaterial { get; set; }
            public bool isFood { get; set; }
            public int FoodTier {  get; set; }
            public int EnergyRec {  get; set; }
            public int StaminaRec { get; set; }

        }
        public class foodRecipes 
        { 
            public int MaterialAmount { get; set; }
            public foodItem Result { get; set; }
            public foodItem Material1 {  get; set; }
            public foodItem Material2 { get; set; }
            public foodItem Material3 { get; set; }

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
            public int EmotionalStateINT { get; set; }
            public string EmotionalStateSTR { get; set; }

            public string[] ConvLine1 = new string[400];
            public string[] ConvLine2 = new string[400];
            public string[] ConvLine3 = new string[400];

            public string ImagePath { get; set; }
            public int ImagePoint1 { get; set; }
            public int ImagePoint2 { get; set; }
            public int ImageSize1 { get; set; }
            public int ImageSize2 { get; set; }

            public Program.ProgressBarInfo NPCEnergyBar { get; set; }
        }
        public class place 
        {
            public string Name { get; set; }
            public bool IsHouse {  get; set; }
            public npc[] space = new npc[5];
            public int[] times = new int[14];
        }

        public static Dictionary<int, item> itemDic = new Dictionary<int, item>();
        public static Dictionary<int, place> placeDic = new Dictionary<int,place>();
        public static Dictionary<int, npc> npcDic = new Dictionary<int, npc>();
        public static Dictionary<int, skill> skillDic = new Dictionary<int, skill>();
        public static Dictionary<int, foodItem> foodDic = new Dictionary<int, foodItem>();
        public static Dictionary<int, foodRecipes> recipesDic = new Dictionary<int, foodRecipes>();
        public static Dictionary<int, book> bookDic = new Dictionary<int, book>();

        public static void CreateBook(int id, string name)
        {
            bookDic[id] = new book { Name = name };
        }

        public static void CreateRecipe(int materialamount,int ID, foodItem material1, foodItem material2, foodItem material3) 
        { 
         if (materialamount == 1) { recipesDic[ID] = new foodRecipes { MaterialAmount = materialamount, Material1 = material1, Material2 = null, Material3 = null }; }
         else if (materialamount == 2) { recipesDic[ID] = new foodRecipes { MaterialAmount = materialamount, Material1 = material1, Material2 = material2, Material3 = null }; }
         else if (materialamount == 3) { recipesDic[ID] = new foodRecipes { MaterialAmount = materialamount, Material1 = material1, Material2 = material2, Material3 = material3 }; }
        }
        public static void CalculateNPCState(int ID) 
        {
            if (npcDic[ID].EmotionalStateINT == 1) 
            {
                npcDic[ID].EmotionalStateSTR = "{=Green}[Normal]{/}";
            }
            if (npcDic[ID].EmotionalStateINT == 2)
            {
                npcDic[ID].EmotionalStateSTR = "{=DarkRed}[Angry]{/}";
            }
            if (npcDic[ID].EmotionalStateINT == 3)
            {
                npcDic[ID].EmotionalStateSTR = "{=Blue}[Sad]{/}";
            }
            if (npcDic[ID].EmotionalStateINT == 4)
            {
                npcDic[ID].EmotionalStateSTR = "{=DarkYellow}[Happy]{/}";
            }

        }
        public static void CreateFoodItem(string name, int ID, bool isfood, bool ismaterial)
        {
            foodDic[ID] = new foodItem { Name = name, isFood = isfood, isMaterial = ismaterial };
        }
        
        public static bool PlayerHasFood() 
        { 
            for (int i = 0; i <  foodDic.Count; i++) 
            {
                if (foodDic[i].isFood && foodDic[i].payerOwned) { return true; }
            }
            return false;
        }
        public static string PlayerHasFoodString()
        {
            for (int i = 0; i < foodDic.Count; i++)
            {
                if (foodDic[i].isFood && foodDic[i].payerOwned) { return "(" + i + "F) [" + BeforeStart.foodDic[i].Name + "]"; }
            }
            return null;
        }
        public static void GiveFoodItems(int ID, int amount)
        {
            foodDic[ID].payerOwned = true;
            foodDic[ID].amount += amount;
        }
        public static void GiveFoodItemsWithItemClass(BeforeStart.foodItem food, int amount)
        {
            food.payerOwned = true;
            food.amount += amount;
        }

        public static int RemoveEnergy(int amount)
        {
            int evn = 0;
            int total = 0;
            if (options.PlayerAction == 1)
            {  
                for (int i = 1; i < BeforeStart.skillDic[0].Level; i++) 
                {
                    if (BeforeStart.skillDic[0].Level != 1) { evn += 2; }
                }
            }
            if (options.PlayerAction == 2)
            {
                for (int i = 1; i < BeforeStart.skillDic[1].Level; i++)
                {
                    if (BeforeStart.skillDic[1].Level != 1) { evn += 1; }
                }
            }
            total = amount - evn;
            Program.progressbarDic["EnergyBar"].currentProgress -= total;
            Program.CalculateBarLogic("EnergyBar");
            return total;
        }
        public static void CreateSkill(string name, int ID)
        {
            skillDic[ID] = new skill { Name = name };
        }
        public static void GiveSkillXP(int ID, int Amount, string BarDicName)
        {
            if (options.PlayerAction == 2) 
            {
                if (bookDic[0].PlayerEquiped) 
                {
                    Amount = Amount * 2;
                }
            }
            skillDic[ID].SkillProgressBar.currentProgress += Amount;
            if (skillDic[ID].SkillProgressBar.currentProgress >= skillDic[ID].SkillProgressBar.totalProgress)
            {
                skillDic[ID].SkillProgressBar.currentProgress -= skillDic[ID].SkillProgressBar.totalProgress;
                skillDic[ID].Level++;
                skillDic[ID].SkillProgressBar.totalProgress = Convert.ToInt32(CalculateRequiredExpForLevel(skillDic[ID].Level));
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("You Leveled up " + skillDic[ID].Name);
            }
            Program.CalculateBarLogic(BarDicName);
            Console.WriteLine();
            Console.WriteLine(BeforeStart.skillDic[ID].Name + "  Lv: " + BeforeStart.skillDic[ID].Level);
            Console.WriteLine(BeforeStart.skillDic[ID].SkillProgressBar.barSprite);
            Console.WriteLine(); 
        }
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
        public static void CreatePlace(string name, int ID, bool ishouse) 
        {
            placeDic[ID] = new place { Name = name, IsHouse = ishouse };
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
            int hour = options.PlayerTimeLeft - 24;
            if (options.PlayerTimeRight >= 60) { options.PlayerTimeRight -= time; options.PlayerTimeLeft++;  }
            if (options.PlayerTimeLeft >= 24) {  options.PlayerTimeLeft = hour;}
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
            // This will generate a random number from the amount of book, use that number in the for loop
            // And that for loop will generate a number and with that number we set the book that is selected as "InStock" 
            int rn = random.Next(0, bookDic.Count);
            for (int i = 0; i < rn; i++) 
            {
                int r = random.Next(0, bookDic.Count);
                bookDic[r].IsInStock = true;
            }
            
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
