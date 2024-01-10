using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

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

            // Round the percentage to the nearest multiple of 10
            int roundedPercentage = (int)Math.Round(progressPercentage / 10) * 10;

            // Checks what rounded percentage we are in and assignes a barSprite
            if (roundedPercentage == 10) { progressbarDic[Barname].barSprite = "▓░░░░░░░░░  ( " + progressbarDic[Barname].currentProgress + " / " + progressbarDic[Barname].totalProgress + " )"; }
            if (roundedPercentage == 20) { progressbarDic[Barname].barSprite = "▓▓░░░░░░░░  ( " + progressbarDic[Barname].currentProgress + " / " + progressbarDic[Barname].totalProgress + " )"; }
            if (roundedPercentage == 30) { progressbarDic[Barname].barSprite = "▓▓▓░░░░░░░  ( " + progressbarDic[Barname].currentProgress + " / " + progressbarDic[Barname].totalProgress + " )"; }
            if (roundedPercentage == 40) { progressbarDic[Barname].barSprite = "▓▓▓▓░░░░░░  ( " + progressbarDic[Barname].currentProgress + " / " + progressbarDic[Barname].totalProgress + " )"; }
            if (roundedPercentage == 50) { progressbarDic[Barname].barSprite = "▓▓▓▓▓░░░░░  ( " + progressbarDic[Barname].currentProgress + " / " + progressbarDic[Barname].totalProgress + " )"; }
            if (roundedPercentage == 60) { progressbarDic[Barname].barSprite = "▓▓▓▓▓▓░░░░  ( " + progressbarDic[Barname].currentProgress + " / " + progressbarDic[Barname].totalProgress + " )"; }
            if (roundedPercentage == 70) { progressbarDic[Barname].barSprite = "▓▓▓▓▓▓▓░░░  ( " + progressbarDic[Barname].currentProgress + " / " + progressbarDic[Barname].totalProgress + " )"; }
            if (roundedPercentage == 80) { progressbarDic[Barname].barSprite = "▓▓▓▓▓▓▓▓░░  ( " + progressbarDic[Barname].currentProgress + " / " + progressbarDic[Barname].totalProgress + " )"; }
            if (roundedPercentage == 90) { progressbarDic[Barname].barSprite = "▓▓▓▓▓▓▓▓▓░  ( " + progressbarDic[Barname].currentProgress + " / " + progressbarDic[Barname].totalProgress + " )"; }
           if (roundedPercentage == 100) { progressbarDic[Barname].barSprite = "▓▓▓▓▓▓▓▓▓▓  ( " + progressbarDic[Barname].currentProgress + " / " + progressbarDic[Barname].totalProgress + " )"; }
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
            Console.WriteLine("-- Basic Player Info --");
            Console.WriteLine("[1] Name: " + playerName);
            Console.WriteLine("[2] Nickname: " + playerNickName);
            Console.WriteLine("");
            Console.WriteLine("Energy:  " +progressbarDic["EnergyBar"].barSprite);
            Console.WriteLine("");
            Console.WriteLine("Stamina: "+progressbarDic["StaminaBar"].barSprite);
            Console.WriteLine("═════════════════════════════════════════════════════════════════════════════════════════════════════");
            Console.WriteLine("-- Traits --");
            Console.WriteLine("[3] Chose a Trait");
            Console.WriteLine("");
            Console.WriteLine("- Chosen Traits -");
            if (traitsDic[1].chosenByPlayer) { Console.Write(traitsDic[1].traitName); }
            if (traitsDic[2].chosenByPlayer) { Console.Write(traitsDic[2].traitName); }
            Console.WriteLine("");
            Console.WriteLine("═════════════════════════════════════════════════════════════════════════════════════════════════════");
            Console.WriteLine("-- Race Selection --");
            Console.WriteLine("[4] Chose a Race");
            Console.WriteLine("");
            Console.Write("Chosen Race: ");
            if (raceDic[1].chosenByPlayer) { Console.Write(raceDic[1].raceName); }
            if (raceDic[2].chosenByPlayer) { Console.Write(raceDic[2].raceName); }
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
            BeforeStart.CreatePlace("Player House", 0);
            BeforeStart.CreatePlace("Reika's House", 1);
            BeforeStart.CreatePlace("EmptyHouse-2", 2);
            BeforeStart.CreatePlace("EmptyHouse-3", 3);
            BeforeStart.CreatePlace("EmptyHouse-4", 4);
            BeforeStart.CreatePlace("EmptyHouse-5", 5);
            BeforeStart.CreatePlace("EmptyHouse-6", 6);
            BeforeStart.CreatePlace("EmptyHouse-7", 7);
            BeforeStart.CreatePlace("EmptyHouse-8", 8);
            BeforeStart.CreatePlace("Public Well", 9);
            BeforeStart.CreatePlace("Residence Street", 10);

            //Creating Items
            BeforeStart.CreateItem("Placeholder", 0, false);
            BeforeStart.CreateItem("Stick", 1, true);

            //Loading Item Descriptions
            ItemDescriptions.ItemDescription();

            //Creating NPCs
            BeforeStart.CreateNpc("Player", 0, "Gray");
            BeforeStart.CreateNpc("Reika", 1, "Green");
            BeforeStart.CreateNpc("Molly", 2, "Red");

            //NPCs Energy Bar Logic
            MakeProgressBar("ReikaEnergyBar", 0, 2000, "", 2000);
            BeforeStart.npcDic[1].NPCEnergyBar = progressbarDic["ReikaEnergyBar"];
            CalculateBarLogic("ReikaEnergyBar");
            MakeProgressBar("MollyEnergyBar", 0, 2000, "", 2000);
            BeforeStart.npcDic[2].NPCEnergyBar = progressbarDic["MollyEnergyBar"];
            CalculateBarLogic("MollyEnergyBar");

            //Setting up NPC Locatons
            BeforeStart.placeDic[1].space[1] = BeforeStart.npcDic[1];
            BeforeStart.placeDic[1].space[2] = BeforeStart.npcDic[2];

            //Time Calculations for Places
            ResidenceAreaTravelTime.RATimeCalculations();

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
