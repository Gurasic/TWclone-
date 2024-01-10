using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCore;

namespace Test
{

    public class Program
    {
        
        public static string playerName = "[Change]";
        public static string playerNickName = "[Change]";
        public static int statPointsforEngStm = 5;
        public static void Write(string msg)
        {
            string[] ss = msg.Split('{', '}');
            ConsoleColor c;
            foreach (var s in ss)
                if (s.StartsWith("/"))
                    Console.ResetColor();
                else if (s.StartsWith("=") && Enum.TryParse(s.Substring(1), out c))
                    Console.ForegroundColor = c;
                else
                    Console.Write(s);
        }

        public class ProgressBarInfo 
        {
          public string barName    { get; set; }
          public string barSprite  { get; set; }
          public int progress      { get; set; }
          public int totalProgress { get; set; }
          public int currentProgress { get; set; }

        }

        public class TraitInfo
        { 
            public string traitName { get; set; }
            public bool energyChanges { get; set; }
            public bool staminaChanges { get; set; }
            public bool chosenByPlayer  { get; set; }
        }
        public class RaceInfo 
        { 
            public string raceName { get; set; }
            public int energyChanges { get; set; }
            public int staminaChanges { get; set; }
            public bool chosenByPlayer { get; set; }
        }

        static Dictionary<int, TraitInfo> traitsDic = new Dictionary<int, TraitInfo>();
        public static Dictionary<string, ProgressBarInfo> progressbarDic = new Dictionary<string, ProgressBarInfo>();
        static Dictionary<int, RaceInfo> raceDic = new Dictionary<int, RaceInfo>();
        static void MakeProgressBar(string Barname, int Progress, int totalProgress, string barsprite, int currentprogress) 
        {
            progressbarDic[Barname] = new ProgressBarInfo {progress = Progress, totalProgress = totalProgress, barSprite = barsprite, currentProgress = currentprogress};
        }
        public static void CalculateBarLogic(string Barname)
        {
            int maxValue = progressbarDic[Barname].totalProgress;
            int currentValue = progressbarDic[Barname].currentProgress;

            // Calculate the progress percentage
            double progressPercentage = (double)currentValue / maxValue * 100;

            // Check if progressPercentage is very close to 0
            if (progressPercentage < 0.01)
            {
                progressbarDic[Barname].barSprite = "▒▒▒▒▒▒▒▒▒▒ ( " + progressbarDic[Barname].currentProgress + " / " + progressbarDic[Barname].totalProgress + " )";
                
            }
            else
            {
                // Round the percentage to the nearest multiple of 10
                int roundedPercentage = (int)Math.Round(progressPercentage / 10) * 10;

                // Update the barSprite based on the rounded percentage
                progressbarDic[Barname].barSprite = new string('█', roundedPercentage / 10) +
                    new string('▒', 10 - (roundedPercentage / 10)) +
                    " ( " + progressbarDic[Barname].currentProgress + " / " + progressbarDic[Barname].totalProgress + " )";
            }
        }
        static void MakeTrait(string name,int ID, bool energych, bool staminach) 
        {
            traitsDic[ID] = new TraitInfo { traitName = name, energyChanges = energych, staminaChanges = staminach, chosenByPlayer = false };
        }
        static void CalculateTraitLogic(int ID, int energyAdd, int StaminaAdd) 
        { 
            if (traitsDic[ID].energyChanges)
            {
                progressbarDic["EnergyBar"].currentProgress += energyAdd;
                progressbarDic["EnergyBar"].totalProgress += energyAdd;
            }
            if (traitsDic[ID].staminaChanges) 
            {
                progressbarDic["StaminaBar"].currentProgress += StaminaAdd;
                progressbarDic["StaminaBar"].totalProgress += StaminaAdd;
            }

        }

        static void MakeRace(int ID, string name, int energychages, int staminachanges) 
        {
        raceDic[ID] = new RaceInfo { raceName = name, energyChanges = energychages, staminaChanges = staminachanges };
        }
        public static void CalculateRaceLogic(int ID) 
        {
            progressbarDic["EnergyBar"].currentProgress += raceDic[ID].energyChanges;
            progressbarDic["EnergyBar"].totalProgress += raceDic[ID].energyChanges;
            progressbarDic["StaminaBar"].currentProgress += raceDic[ID].staminaChanges;
            progressbarDic["StaminaBar"].totalProgress += raceDic[ID].staminaChanges;
        }
        static void MainMenu() 
        {
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
            Console.WriteLine("                                    ╦═╗┌─┐┌─┐┬  ");
            Console.WriteLine("                                    ╠╦╝├┤ ├─┤│  ");
            Console.WriteLine("                                    ╩╚═└─┘┴ ┴┴─┘");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("                                   [1] New Game");
            Console.WriteLine("                                   [2] Continue");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            string real = Console.ReadLine();

            if (real == "1")
            {
                AferMainMenu();
            }
            else if (real == "2")
            {
                MainMenu();
            }
            else
            {
                Console.WriteLine("Thats not an Option, Choosee again");
                MainMenu();
            }
        }
        static void AferMainMenu() 
        {
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
            Console.WriteLine(" ☆☆ Slect Mode ☆☆");
            Console.WriteLine("");
            Console.WriteLine("      [1] Create a New Character");
            Console.WriteLine("      [2] Return to Main Menu");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            string real = Console.ReadLine();

            if (real == "1")
            {
                MakeProgressBar("EnergyBar", 0, 2000, "", 2000);
                MakeProgressBar("StaminaBar", 0, 2000, "", 2000);
                MakeTrait("[Strong] ", 1, false, true);
                MakeTrait("[Resistent] ", 2, true, false);
                CharacterCreation();

            }
            else if (real == "2")
            {
                MainMenu();
            }
            else
            {
                Console.WriteLine("Thats not an Option, Choosee again");
                AferMainMenu();
            }
        }
        static void CharacterCreation() 
        {
            CalculateBarLogic("EnergyBar");
            CalculateBarLogic("StaminaBar");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("═════════════════════════════════════════════════════════════════════════════════════════════════════");
            Console.WriteLine("");
            Console.WriteLine("-- Basic Player Info --");
            Console.WriteLine("");
            Console.WriteLine("[1] Name: " + playerName);
            Console.WriteLine("[2] Nickname: " + playerNickName);
            Console.WriteLine("");
            Console.WriteLine("Energy:  " +progressbarDic["EnergyBar"].barSprite);
            Console.WriteLine("");
            Console.WriteLine("Stamina: "+progressbarDic["StaminaBar"].barSprite);
            Console.WriteLine("");
            Console.WriteLine("═════════════════════════════════════════════════════════════════════════════════════════════════════");
            Console.WriteLine("");
            Console.WriteLine("-- Traits --");
            Console.WriteLine("");
            Console.WriteLine("[3] Chose a Trait");
            Console.WriteLine("");
            Console.WriteLine("- Chosen Traits -");
            if (traitsDic[1].chosenByPlayer) { Console.Write(traitsDic[1].traitName); }
            if (traitsDic[2].chosenByPlayer) { Console.Write(traitsDic[2].traitName); }
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("═════════════════════════════════════════════════════════════════════════════════════════════════════");
            Console.WriteLine("");
            Console.WriteLine("-- Race Selection --");
            Console.WriteLine("");
            Console.WriteLine("[4] Chose a Race");
            Console.WriteLine("");
            Console.Write("Chosen Race: ");
            if (raceDic[1].chosenByPlayer) { Console.Write(raceDic[1].raceName); }
            if (raceDic[2].chosenByPlayer) { Console.Write(raceDic[2].raceName); }
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("═════════════════════════════════════════════════════════════════════════════════════════════════════");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("[99] Save      [100] Return to Main Menu");
            Console.WriteLine("");
           
            string real = Console.ReadLine();

            if (real == "1")
            {
                Console.WriteLine("Choose a Name");
                string name = Console.ReadLine();
                playerName = name;
                CharacterCreation();

            }
            else if (real == "2")
            {
                Console.WriteLine("Choose a NickName");
                string nickname = Console.ReadLine();
                playerNickName = nickname;
                CharacterCreation();
            }
            else if (real == "3")
            {
                Console.WriteLine("");
                Console.WriteLine("Traits:");
                Console.Write("(1)" + traitsDic[1].traitName + "");
                Console.Write("(2)" + traitsDic[2].traitName + "");
                string traits = Console.ReadLine();
                if(traits == "1") 
                {
                    if (!traitsDic[1].chosenByPlayer)
                    {
                       Console.WriteLine("");
                       Console.WriteLine("[1] Info");
                       Console.WriteLine("[2] Chose Trait");
                       string options = Console.ReadLine();
                       if (options == "1") { Console.WriteLine("");  Console.WriteLine("[Strong]"); Console.WriteLine("Increeses Stamina by 100"); Console.ReadLine(); }
                       if (options == "2") { CalculateTraitLogic(1, 0, 100); Console.WriteLine("[Strong] Trait Chosen"); Console.ReadLine(); traitsDic[1].chosenByPlayer = true; CharacterCreation(); }
                    }
                    else { Console.WriteLine("You Have already chosen this Trait"); Console.ReadLine(); }
                }
                if (traits == "2")
                {
                    if (!traitsDic[2].chosenByPlayer)
                    {
                        Console.WriteLine("");
                        Console.WriteLine("[1] Info");
                        Console.WriteLine("[2] Chose Trait");
                        string options = Console.ReadLine();
                        if (options == "1") { Console.WriteLine(""); Console.WriteLine("[Resistent]"); Console.WriteLine("Increeses Energy by 100"); Console.ReadLine(); }
                        if (options == "2") { CalculateTraitLogic(2, 100, 0); Console.WriteLine("[Resistent] Trait Chosen"); Console.ReadLine(); traitsDic[2].chosenByPlayer = true; CharacterCreation(); }
                    }
                    else { Console.WriteLine("You Have already chosen this Trait"); Console.ReadLine(); }
                }
                CharacterCreation();
            }
            else if (real == "4") 
            {
                if (!raceDic[1].chosenByPlayer && !raceDic[2].chosenByPlayer)
                {
                    Console.WriteLine();
                    Console.WriteLine("What race would you like to choose?   (You can only Chose One)");
                    Console.WriteLine("[1] " + raceDic[1].raceName);
                    Console.WriteLine("[2] " + raceDic[2].raceName);
                    Console.WriteLine("");
                    Console.WriteLine("[99] Return");
                    string options = Console.ReadLine();
                    if (options == "1") { Console.WriteLine("[Human] was Chosen"); Console.ReadLine(); raceDic[1].chosenByPlayer = true; CalculateRaceLogic(1); CharacterCreation(); }
                    if (options == "2") { Console.WriteLine("[Elf] was Chosen"); Console.ReadLine(); raceDic[2].chosenByPlayer = true; CalculateRaceLogic(2); CharacterCreation(); }
                }
                else 
                {
                    Console.WriteLine("");
                    Console.WriteLine("You already chose a race");
                    Console.ReadLine();
                }
            
                CharacterCreation();
            }
            else if (real == "99") 
            {
            
                using (StreamWriter sw = new StreamWriter("Saves/" + playerName + ".txt"))
                {
                    if (playerName != "[Change]") { sw.WriteLine(playerName); } else { sw.WriteLine("null"); }
                    if (playerNickName != "[Change]") { sw.WriteLine(playerNickName); } else { sw.WriteLine("null"); }
                    sw.WriteLine(progressbarDic["EnergyBar"].totalProgress);
                    sw.WriteLine(progressbarDic["EnergyBar"].currentProgress);
                    sw.WriteLine(progressbarDic["StaminaBar"].totalProgress);
                    sw.WriteLine(progressbarDic["StaminaBar"].currentProgress);
                    if (traitsDic[1].chosenByPlayer) { sw.WriteLine(traitsDic[1].traitName); } else { sw.WriteLine("null"); }
                    if (traitsDic[2].chosenByPlayer) { sw.WriteLine(traitsDic[2].traitName); } else { sw.WriteLine("null"); }
                    if (raceDic[1].chosenByPlayer) { sw.WriteLine(raceDic[1].raceName); } else { sw.WriteLine("null"); }
                    if (raceDic[2].chosenByPlayer) { sw.WriteLine(raceDic[2].raceName); } else { sw.WriteLine("null"); }
                    sw.Close();
                    
                }
                Console.Clear();
                BeforeStart.BeforeStarMenu();
            }
            else if (real == "100") { MainMenu(); }
            else
            {
                Console.WriteLine("Thats not an Option, Choosee again");
                CharacterCreation();
            }
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            //Creating Races
            MakeRace(1, "[Human]", 0, 0);
            MakeRace(2, "[Elf]", 100, -50);

            //Creating Places
            BeforeStart.CreatePlace("Player House", 0, true);
            BeforeStart.CreatePlace("Reika's House", 1, true);
            BeforeStart.CreatePlace("EmptyHouse-2", 2, true);
            BeforeStart.CreatePlace("EmptyHouse-3", 3, true);
            BeforeStart.CreatePlace("EmptyHouse-4", 4, true);
            BeforeStart.CreatePlace("EmptyHouse-5", 5, true);
            BeforeStart.CreatePlace("EmptyHouse-6", 6, true);
            BeforeStart.CreatePlace("EmptyHouse-7", 7, true);
            BeforeStart.CreatePlace("EmptyHouse-8", 8, true);
            BeforeStart.CreatePlace("Public Well", 9, false);
            BeforeStart.CreatePlace("Residence Street", 10, false);
            BeforeStart.CreatePlace("Main Hall", 11, true);
            BeforeStart.CreatePlace("Elfina's Room", 12, false);
            BeforeStart.CreatePlace("EmptyHouse-9", 13, true);
            BeforeStart.CreatePlace("EmptyHouse-10", 14, true);

            //Creating Items
            BeforeStart.CreateItem("Placeholder", 0, false);
            BeforeStart.CreateItem("Stick", 1, true);

            //Creating Books
            BeforeStart.CreateBook(0, "Cooking Guide");
            BeforeStart.CreateBook(1, "Placeholder");

            // Loading Library Conv Lines
            LibraryLogic.LibraryLines();

            //Creating Food Items
            BeforeStart.CreateFoodItem("placeholder", 0, false, false);
            BeforeStart.CreateFoodItem("Pizza", 1, true, false);
            BeforeStart.foodDic[1].EnergyRec = 500;
            BeforeStart.foodDic[1].StaminaRec = 450;
            BeforeStart.CreateFoodItem("Dough", 2, false, true);
            BeforeStart.CreateFoodItem("Tomato", 3, false, true);
            BeforeStart.CreateFoodItem("Cheese", 4, false, true);
            BeforeStart.CreateFoodItem("Cooked Meat", 5, true, false);
            BeforeStart.foodDic[5].EnergyRec = 200;
            BeforeStart.foodDic[5].StaminaRec = 100;
            BeforeStart.CreateFoodItem("Meat", 6, false, true);
            BeforeStart.CreateFoodItem("Cooked Bacon", 7, true, false);
            BeforeStart.foodDic[7].EnergyRec = 300;
            BeforeStart.foodDic[7].StaminaRec = 200;
            BeforeStart.CreateFoodItem("Raw Bacon", 8, false, true);
            BeforeStart.CreateFoodItem("Ramen", 9, true, false);
            BeforeStart.foodDic[9].EnergyRec = 100;
            BeforeStart.foodDic[9].StaminaRec = 100;
            BeforeStart.CreateFoodItem("Uncooked Ramen", 10, false, true);

            //Testing
            BeforeStart.GiveFoodItems(2, 1);
            BeforeStart.GiveFoodItems(3, 1);
            BeforeStart.GiveFoodItems(4, 1);
            BeforeStart.GiveFoodItems(6, 1);
            BeforeStart.GiveFoodItems(8, 1);
            BeforeStart.GiveFoodItems(10, 1);
            BeforeStart.GiveFoodItems(6, 1);

            //Creating Food Recipes
            CookingLogic.Cooking.CreateRecipe(3, 1,
                BeforeStart.foodDic[1],
                BeforeStart.foodDic[2], 1,
                BeforeStart.foodDic[3], 1,
                BeforeStart.foodDic[4], 1);
            CookingLogic.Cooking.CreateRecipe(1, 2,
                BeforeStart.foodDic[5],
                BeforeStart.foodDic[6], 1,
                null,0,null,0);
            CookingLogic.Cooking.CreateRecipe(1, 3,
                BeforeStart.foodDic[7],
                BeforeStart.foodDic[8], 1,
                null, 0, null, 0);
            CookingLogic.Cooking.CreateRecipe(1, 4,
                BeforeStart.foodDic[9],
                BeforeStart.foodDic[10], 1,
                null, 0, null, 0);
            CookingLogic.Cooking.CreateRecipe(1, 5,
                BeforeStart.foodDic[9],
                BeforeStart.foodDic[10], 1,
                null, 0, null, 0);

            //Loading Item Descriptions
            ItemDescriptions.ItemDescription();

            //Creating NPCs
            BeforeStart.CreateNpc("Player", 0, "Gray");
            BeforeStart.CreateNpc("Reika", 1, "Green");
            BeforeStart.CreateNpc("Molly", 2, "Red"); 
            BeforeStart.CreateNpc("Elfina", 3, "Cyan");

            //NPCs Energy Bar Logic
            MakeProgressBar("ReikaEnergyBar", 0, 2000, "", 2000);
            BeforeStart.npcDic[1].NPCEnergyBar = progressbarDic["ReikaEnergyBar"];
            CalculateBarLogic("ReikaEnergyBar");
            MakeProgressBar("MollyEnergyBar", 0, 2000, "", 2000);
            BeforeStart.npcDic[2].NPCEnergyBar = progressbarDic["MollyEnergyBar"];
            CalculateBarLogic("MollyEnergyBar");
            MakeProgressBar("ElfinaEnergyBar", 0, 2100, "", 2100);
            BeforeStart.npcDic[3].NPCEnergyBar = progressbarDic["ElfinaEnergyBar"];
            CalculateBarLogic("ElfinaEnergyBar");

            //NPCs Base Emotional State
            BeforeStart.npcDic[1].EmotionalStateINT = 1;
            BeforeStart.npcDic[2].EmotionalStateINT = 1;
            BeforeStart.npcDic[3].EmotionalStateINT = 1;

            //Setting up NPC Locatons
            BeforeStart.placeDic[1].space[1] = BeforeStart.npcDic[1];
            BeforeStart.placeDic[1].space[2] = BeforeStart.npcDic[2];
            BeforeStart.placeDic[11].space[1] = BeforeStart.npcDic[3];

            //Time Calculations for Places
            ResidenceAreaTravelTime.RATimeCalculations();
            LibraryAreaTravelTime.LATimeCalculations();

            //Creating Skills
            BeforeStart.CreateSkill("Conversation", 0);
            BeforeStart.CreateSkill("Cooking", 1);

            //Skills XP Bar Logic
            MakeProgressBar("ConversationXPBar", 0, 500, "", 0);
            BeforeStart.skillDic[0].SkillProgressBar = progressbarDic["ConversationXPBar"];
            BeforeStart.skillDic[0].Level = 1;
            CalculateBarLogic("ConversationXPBar");
            MakeProgressBar("CookingXPBar", 0, 500, "", 0);
            BeforeStart.skillDic[1].SkillProgressBar = progressbarDic["CookingXPBar"];
            BeforeStart.skillDic[1].Level = 1;
            CalculateBarLogic("CookingXPBar");

            //Misc...
            Directory.CreateDirectory("Saves");

            //Cool
            for(int i = 0; i < 50; i++) 
            {
                Console.WriteLine();
            }

            MainMenu();

        }
    }
}
