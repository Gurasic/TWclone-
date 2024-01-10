using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.NPCs;
using TestCore;
using TestCore.Data.NPCs;

namespace Test
{
    internal class PlayerScreen
    {
        public static Random random = new Random();
     
        public static void NPCEnergyLogic(int ID) 
        { 
            switch (ID) 
            {
                case 1: Program.progressbarDic["ReikaEnergyBar"].currentProgress = BeforeStart.npcDic[ID].NPCEnergyBar.currentProgress; Program.CalculateBarLogic("ReikaEnergyBar"); break;
                case 2: Program.progressbarDic["MollyEnergyBar"].currentProgress = BeforeStart.npcDic[ID].NPCEnergyBar.currentProgress; Program.CalculateBarLogic("MollyEnergyBar"); break;
                case 3: Program.progressbarDic["ElfinaEnergyBar"].currentProgress = BeforeStart.npcDic[ID].NPCEnergyBar.currentProgress; Program.CalculateBarLogic("ElfinaEnergyBar"); break;
            }
        
        }
        public static void DialogueNPCLogic(int ID) 
        { 
            if (BeforeStart.npcDic[ID].PlayerSelected) 
            {
                options.PlayerAction = 1;
                int i = random.Next(1, 3);
                int b = random.Next(4, 12);
                if (BeforeStart.npcDic[ID].EmotionalStateINT == 2) 
                {
                    Console.WriteLine("");
                    Console.WriteLine(BeforeStart.npcDic[ID].Name + " isin't in the mood to talk to you");
                    Console.WriteLine("");
                    Console.ReadLine();
                    PlayerScreen.MainScreen();
                    options.PlayerAction = 0;
                }
                if (BeforeStart.npcDic[ID] == BeforeStart.npcDic[1] && !BeforeStart.npcDic[ID].PlayerMeet) { ReikaNPC.GreatingsDialogue(); PlayerScreen.MainScreen();}
                if (BeforeStart.npcDic[ID] == BeforeStart.npcDic[2] && !BeforeStart.npcDic[ID].PlayerMeet) { MollyNPC.GreatingsDialogue(); PlayerScreen.MainScreen();}
                if(BeforeStart.npcDic[ID] == BeforeStart.npcDic[3] && !BeforeStart.npcDic[ID].PlayerMeet) { ElfinaNPC.GreatingsDialogue(); PlayerScreen.MainScreen();}
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Program.Write(BeforeStart.npcDic[ID].ConvLine1[i]);
                Console.ReadLine();
                Program.Write(BeforeStart.npcDic[ID].ConvLine2[i]);
                Console.ReadLine();
                Program.Write(BeforeStart.npcDic[ID].ConvLine3[i]);
                Console.ReadLine();
                TimeUsage(10);
                Console.WriteLine("");
                Program.Write("{=Red}-"+ BeforeStart.RemoveEnergy(50) +" {/}{=Yellow}Player Energy {/}");
                Console.WriteLine("");
                Program.Write("{=Red}-50 {/}{=Yellow}"+ BeforeStart.npcDic[ID].Name +" Energy {/}");
                Console.WriteLine("");
                Console.WriteLine("+" + b +" Favor");
                Console.ReadLine();
                Console.WriteLine("+10 Conversation XP");
                BeforeStart.GiveSkillXP(0, 10, "ConversationXPBar");
                Console.ReadLine();
                BeforeStart.npcDic[ID].NPCEnergyBar.currentProgress -= 50;
                BeforeStart.npcDic[ID].NPCFavor += b;
                Program.CalculateBarLogic("EnergyBar");
                NPCEnergyLogic(ID);
                PlayerScreen.MainScreen();
                options.PlayerAction = 0;
            }
        }
        public static void SkinshiPNPCLogic(int ID)
        {
            if (BeforeStart.npcDic[ID].PlayerSelected)
            {
                int i = 0;
                int b = 0;
                string c = "";
                if (BeforeStart.npcDic[ID].NPCFavor <= 500) { i = random.Next(301, 304); b = random.Next(-28, -8); BeforeStart.npcDic[ID].EmotionalStateINT = 2; }
                if (BeforeStart.npcDic[ID].NPCFavor >= 500) { i = random.Next(351, 354); b = random.Next(18, 27); c = "+"; }
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Program.Write(BeforeStart.npcDic[ID].ConvLine1[i]);
                Console.ReadLine();
                Program.Write(BeforeStart.npcDic[ID].ConvLine2[i]);
                Console.ReadLine();
                Program.Write(BeforeStart.npcDic[ID].ConvLine3[i]);
                Console.ReadLine();
                TimeUsage(10);
                Console.WriteLine("");
                Program.Write("{=Red}-" + BeforeStart.RemoveEnergy(50) + " {/}{=Yellow}Player Energy {/}");
                Console.WriteLine("");
                Program.Write("{=Red}-50 {/}{=Yellow}" + BeforeStart.npcDic[ID].Name + " Energy {/}");
                Console.WriteLine("");
                Console.WriteLine(c + b + " Favor");
                Console.ReadLine();
                BeforeStart.npcDic[ID].NPCEnergyBar.currentProgress -= 50;
                BeforeStart.npcDic[ID].NPCFavor += b;
                Program.CalculateBarLogic("EnergyBar");
                NPCEnergyLogic(ID);
                PlayerScreen.MainScreen();
            }
        }
        public static void InventoryLogic(int ID) 
        {
            if (BeforeStart.itemDic[ID].amount <= 0) 
            {
                BeforeStart.itemDic[ID].payerOwned = false;
            }

        }
        public static void InventoryfoodLogic(int ID) 
        {
            if (BeforeStart.foodDic[ID].amount <= 0)
            {
                BeforeStart.foodDic[ID].payerOwned = false;
            }
        }
        public static void DisplayingInventory() 
        {
            for (int i = 0; i < BeforeStart.itemDic.Count; i++)
            { 
                InventoryLogic(i);
            }
            for (int i = 0; i < BeforeStart.foodDic.Count; i++)
            {
                InventoryfoodLogic(i);
            }
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌");
            Console.WriteLine("Inventory: ");
            Console.WriteLine("");
            for (int i = 0; i < BeforeStart.itemDic.Count; i++)
            {
                if (BeforeStart.itemDic[i] != null) 
                { 
                    if (BeforeStart.itemDic[i].payerOwned)
                    {
                       Console.Write("("+i+"I) [" + BeforeStart.itemDic[i].Name + "]  (owned: " + BeforeStart.itemDic[i].amount + ")");
                       if (BeforeStart.itemDic[i].playerEquiped) 
                       {
                            Console.Write("   [Equiped]");
                       }
                        Console.WriteLine();
                       
                    }
                }
            }
            Console.WriteLine("");
            Console.WriteLine("╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌");
            Console.WriteLine("Food Materials: ");
            Console.WriteLine("");
            for (int i = 0; i < BeforeStart.foodDic.Count; i++)
            {
                if (BeforeStart.foodDic[i].isMaterial)
                {
                    if (BeforeStart.foodDic[i].payerOwned)
                    {
                        Console.Write("(" + i + "F) [" + BeforeStart.foodDic[i].Name + "]  (owned: " + BeforeStart.foodDic[i].amount + ")");
                        Console.WriteLine();

                    }
                }
            }
            Console.WriteLine("");
            Console.WriteLine("Food: ");
            Console.WriteLine("");
            for (int i = 0; i < BeforeStart.foodDic.Count; i++)
            {
                if (BeforeStart.foodDic[i].isFood)
                {
                    if (BeforeStart.foodDic[i].payerOwned)
                    {
                        Console.Write("(" + i + "F) [" + BeforeStart.foodDic[i].Name + "]");
                        Console.WriteLine();

                    }
                }
            }
            Console.WriteLine("");
            Console.WriteLine("╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌");
            string sw = Console.ReadLine();
            for (int i = 0; i < BeforeStart.itemDic.Count; i++)
            {
                if (BeforeStart.itemDic[i].payerOwned)
                {
                    if (sw == Convert.ToString(i)+"I") 
                    {
                        Console.WriteLine();
                        Console.WriteLine(BeforeStart.itemDic[i].Name);
                        Console.WriteLine();
                        Console.WriteLine("[1] Info");
                        Console.WriteLine("[2] Equip/Unequip (If Equipable)");
                        Console.WriteLine("[3] Return");
                        string sd = Console.ReadLine();
                        if (sd == "1") 
                        {
                            Console.WriteLine();
                            Console.WriteLine("------------------");
                            Console.WriteLine();
                            Console.WriteLine(BeforeStart.itemDic[i].ItemDescription);
                            Console.WriteLine();
                            Console.WriteLine("------------------");
                            Console.WriteLine();
                            Console.ReadLine();
                            Console.Clear();
                            DisplayingInventory(); 
                        
                        }
                        if (sd == "2") 
                        { 
                            if (BeforeStart.itemDic[i].IsEquipable) 
                            {
                                if (BeforeStart.itemDic[i].playerEquiped)
                                {
                                    BeforeStart.itemDic[i].playerEquiped = false;
                                    Console.Clear();
                                    DisplayingInventory();
                                }
                                else
                                { BeforeStart.itemDic[i].playerEquiped = true; }
                            } 
                            else 
                            {
                                Console.WriteLine();
                                Console.WriteLine("Thats not Equipable"); 
                                Console.ReadLine();
                                Console.Clear();
                                DisplayingInventory(); 
                            } 
                        }
                        if (sd == "3") { Console.Clear(); DisplayingInventory(); }
                    }
                }
            }
            MainScreen();
        }
        public static void DisplaySkills() 
        {
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌");
            Console.WriteLine("Skills: ");
            Console.WriteLine("");
            for (int i = 0; i < BeforeStart.skillDic.Count; i++)
            {
                if (BeforeStart.skillDic[i] != null)
                {
                    Console.WriteLine(BeforeStart.skillDic[i].Name + "  Lv: " + BeforeStart.skillDic[i].Level + "     ");
                    Console.WriteLine(BeforeStart.skillDic[i].SkillProgressBar.barSprite + "     ");
                    Console.WriteLine();
                }
            }
            Console.WriteLine("");
            Console.WriteLine("╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌");
            Console.ReadLine();
            MainScreen();
        }

        public static void DisplayingFood() 
        {
            for (int i = 0; i < BeforeStart.foodDic.Count; i++)
            {
                InventoryfoodLogic(i);
            }
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌");
            Console.WriteLine("Dishes: ");
            Console.WriteLine("");
            for (int b = 1; b < BeforeStart.recipesDic.Count; b++)
            {
                for (int i = 0; i < BeforeStart.foodDic.Count; i++) 
                { 
                    if (BeforeStart.foodDic[i].isFood)
                    {
                        Console.WriteLine("[" + b + "] " + BeforeStart.foodDic[i].Name);
                        if (BeforeStart.recipesDic[b].MaterialAmount == 1) 
                        { 
                            Program.Write("{=DarkGray}Materials Required: " + BeforeStart.recipesDic[b].Material1.Name + "{/}"); 
                        }
                        if (BeforeStart.recipesDic[b].MaterialAmount == 2) 
                        {
                            Program.Write("{=DarkGray}Materials Required: " + BeforeStart.recipesDic[b].Material1.Name + ", "+ BeforeStart.recipesDic[b].Material2.Name + "{/}");
                        }
                        if (BeforeStart.recipesDic[b].MaterialAmount == 3) 
                        {
                            Program.Write("{=DarkGray}Materials Required: " + BeforeStart.recipesDic[b].Material1.Name + ", " + BeforeStart.recipesDic[b].Material2.Name + ", " + BeforeStart.recipesDic[b].Material3.Name + "{/}");
                        }
                        Console.WriteLine();
                        b++;
                    }
                }

            }
                Console.WriteLine("");
            Console.WriteLine("╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌");
            Console.WriteLine("[99] Return");
            string sw = Console.ReadLine();
            for (int i = 0; i < BeforeStart.recipesDic.Count; i++)
            {
                if(sw == Convert.ToString(i)) 
                {
                    BeforeStart.skillDic[1].Level = 20;

                    if (BeforeStart.recipesDic[i].MaterialAmount == 1) 
                    { 
                        if (BeforeStart.recipesDic[i].Material1.payerOwned) 
                        {
                            int z = 10;
                            options.PlayerAction = 2;
                            if (BeforeStart.bookDic[0].PlayerEquiped) { z = z * 2; }
                            Console.WriteLine();
                            Console.WriteLine("The " + BeforeStart.recipesDic[i].Result.Name + " Was ");
                            for (int x = 0; x < BeforeStart.foodDic.Count;x++) 
                            { 
                                if (BeforeStart.foodDic[x] == BeforeStart.recipesDic[i].Result) 
                                {
                                    CookingLogic.Cooking.FoodTierCalculatons(x);
                                }
                            }
                            Console.WriteLine();
                            Console.ReadLine();
                            TimeUsage(30);
                            Program.Write("{=Red}-" + BeforeStart.RemoveEnergy(100) + " {/}{=Yellow}Player Energy {/}");
                            Console.WriteLine();
                            Console.WriteLine("+"+z+" Cooking XP");
                            Console.WriteLine();
                            BeforeStart.GiveSkillXP(1, z, "CookingXPBar");
                            BeforeStart.GiveFoodItemsWithItemClass(BeforeStart.recipesDic[i].Result, 1);
                            CookingLogic.Cooking.RemoveUsedFoodMaterials(i);
                            options.PlayerAction = 0;
                        }
                        else 
                        {
                            Console.WriteLine("");
                            Console.WriteLine("You Dont Have the Neccesary Materials");
                            Console.WriteLine("");
                            Console.ReadLine();
                            DisplayingFood();
                        }
                    }
                   
                    if (BeforeStart.recipesDic[i].MaterialAmount == 2) 
                    {
                        if (BeforeStart.recipesDic[i].Material1.payerOwned && BeforeStart.recipesDic[i].Material2.payerOwned)
                        {
                            int z = 10;
                            options.PlayerAction = 2;
                            if (BeforeStart.bookDic[0].PlayerEquiped) { z = z * 2; }
                            Console.WriteLine();
                            Console.WriteLine("The " + BeforeStart.recipesDic[i].Result.Name + " Was ");
                            for (int x = 0; x < BeforeStart.foodDic.Count; x++)
                            {
                                if (BeforeStart.foodDic[x] == BeforeStart.recipesDic[i].Result)
                                {
                                    CookingLogic.Cooking.FoodTierCalculatons(x);
                                }
                            }
                            Console.WriteLine();
                            Console.ReadLine();
                            TimeUsage(30);
                            Program.Write("{=Red}-" + BeforeStart.RemoveEnergy(100) + " {/}{=Yellow}Player Energy {/}");
                            Console.WriteLine();
                            Console.WriteLine("+" + z + " Cooking XP");
                            Console.WriteLine();
                            BeforeStart.GiveSkillXP(1, z, "CookingXPBar");
                            BeforeStart.GiveFoodItemsWithItemClass(BeforeStart.recipesDic[i].Result, 1);
                            CookingLogic.Cooking.RemoveUsedFoodMaterials(i);
                            options.PlayerAction = 0;
                        }
                        else
                        {
                            Console.WriteLine("");
                            Console.WriteLine("You Dont Have the Neccesary Materials");
                            Console.WriteLine("");
                            Console.ReadLine();
                            DisplayingFood();
                        }
                    }
                  
                    if (BeforeStart.recipesDic[i].MaterialAmount == 3) 
                    {
                        if (BeforeStart.recipesDic[i].Material1.payerOwned && BeforeStart.recipesDic[i].Material2.payerOwned && BeforeStart.recipesDic[i].Material3.payerOwned)
                        {
                            int z = 10;
                            options.PlayerAction = 2;
                            if (BeforeStart.bookDic[0].PlayerEquiped) { z = z * 2; }
                            Console.WriteLine();
                            Console.WriteLine("The " + BeforeStart.recipesDic[i].Result.Name + " Was ");
                            for (int x = 0; x < BeforeStart.foodDic.Count; x++)
                            {
                                if (BeforeStart.foodDic[x] == BeforeStart.recipesDic[i].Result)
                                {
                                    CookingLogic.Cooking.FoodTierCalculatons(x);
                                }
                            }
                            Console.WriteLine();
                            Console.ReadLine();
                            TimeUsage(30);
                            Program.Write("{=Red}-" + BeforeStart.RemoveEnergy(100) + " {/}{=Yellow}Player Energy {/}");
                            Console.WriteLine();
                            Console.WriteLine("+" + z + " Cooking XP");
                            Console.WriteLine();
                            BeforeStart.GiveSkillXP(1, z, "CookingXPBar");
                            BeforeStart.GiveFoodItemsWithItemClass(BeforeStart.recipesDic[i].Result, 1);
                            CookingLogic.Cooking.RemoveUsedFoodMaterials(i);
                            options.PlayerAction = 0;
                        }
                        else
                        {
                            Console.WriteLine("");
                            Console.WriteLine("You Dont Have the Neccesary Materials");
                            Console.WriteLine("");
                            Console.ReadLine();
                            DisplayingFood();
                        }
                    }
                }
            }
            Console.ReadLine();
            MainScreen();

        }

        public static void TimeUsage(int time)
        {
            options.PlayerTimeRight += time;
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.ReadLine();
            Program.Write("{=Blue}-----------------------------------{/}");
            Console.WriteLine();
            Program.Write("{=Blue}|                                 |{/}");
            Console.WriteLine();
            Program.Write("{=Blue}       +" + time + " Minutes....             {/}");
            Console.WriteLine();
            Program.Write("{=Blue}|                                 |{/}");
            Console.WriteLine();
            Program.Write("{=Blue}-----------------------------------{/}");
            Console.ReadLine();
        }
        public static void MainScreen() 
        {
            BeforeStart.CalculateNPCState(1);
            BeforeStart.CalculateNPCState(2);
            BeforeStart.CalculateNPCState(3);

            string sw = "";
            Console.WriteLine("════════════════════════════════════════════════════════════════════════════════════════════════════════");
            BeforeStart.CalculateTimeLogic();
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("You are on " + "[" + options.PlayerLocation.Name + "]");
            Console.WriteLine("");
            Console.WriteLine("Energy:  " + Program.progressbarDic["EnergyBar"].barSprite+ "       Stamina: " + Program.progressbarDic["StaminaBar"].barSprite);
            for (int c = 1; c < BeforeStart.npcDic.Count; c++)
            {
                if (BeforeStart.npcDic[c] != null && BeforeStart.npcDic[c].PlayerSelected)
                {
                    Console.WriteLine("");
                    Console.Write("Selected: " + BeforeStart.npcDic[c].Name + "( Favor: " + BeforeStart.npcDic[c].NPCFavor + "   Trust: " + BeforeStart.npcDic[c].NPCTrust + " )  ENR: " + BeforeStart.npcDic[c].NPCEnergyBar.barSprite);
                    Program.Write(" State: " + BeforeStart.npcDic[c].EmotionalStateSTR);
                    Console.WriteLine("");
                }
            }
            for (int b = 1; b < BeforeStart.placeDic[0].space.Length; b++) 
            { 
                for (int c = 1; c < BeforeStart.npcDic.Count; c++)
                { 
                   if (options.PlayerLocation.space[b] == BeforeStart.npcDic[c])
                    {
                        if (BeforeStart.npcDic[c] != null && BeforeStart.npcDic[c].PlayerSelected) 
                        {
                            
                            Program.Write("{="+ BeforeStart.npcDic[c].Color + "}" + "(" + c + ")" + " [" + BeforeStart.npcDic[c].Name + "]  {/}");
                            options.SelectedNPC = BeforeStart.npcDic[c];
                            // DrawingImages.DrawImage(BeforeStart.npcDic[c].ImagePath, BeforeStart.npcDic[c].ImagePoint1, BeforeStart.npcDic[c].ImagePoint2, BeforeStart.npcDic[c].ImageSize1, BeforeStart.npcDic[c].ImageSize2);
                        }
                        else 
                        {
                            Console.Write("(" + c + ")" + " ["+ BeforeStart.npcDic[c].Name + "]  "); 
                        }
                    }
                }
            } 
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
            Console.WriteLine("╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌");
            for (int b = 1; b < BeforeStart.placeDic[0].space.Length; b++)
            {
                for (int c = 1; c < BeforeStart.npcDic.Count; c++)
                {
                    if (options.PlayerLocation.space[b] == BeforeStart.npcDic[c])
                    {
                        if (BeforeStart.npcDic[c].PlayerSelected)
                        {
                            Console.Write(" [10] Talk     ");   
                            if (BeforeStart.npcDic[c].PlayerMeet) { Console.Write("[11] Skinship     "); }
                            if (BeforeStart.npcDic[c].EmotionalStateINT == 2) { Console.Write("[16] Apologize     "); }
                        }
                    }
                }
            }
            if (options.PlayerLocation.IsHouse) { Console.Write(" [12] Cooking     "); }
            if (BeforeStart.PlayerHasFood()) { Console.Write(" [13] Have a Meal     "); }
            if (options.PlayerTimeLeft >= 20 && options.PlayerLocation == BeforeStart.placeDic[0]) { Console.Write(" [SL] Sleep     "); }
            Console.WriteLine("");
            if (options.PlayerLocation == BeforeStart.placeDic[11]) { Console.Write(" [14] Library     "); }
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("╼╼╼╼╼╼╼╼╼╼╼╼╼╼╼╼╼╼╼╼╼╼╼╼╼╼╼╼╼╼╼╼╼╼╼╼╼╼╼╼╼╼╼╼╼╼╼╼╼╼╼╼╼╼╼╼╼╼╼╼╼╼╼╼╼╼╼╼╼╼╼╼╼╼╼╼╼╼╼╼╼╼╼╼╼╼╼╼╼╼╼╼╼╼╼╼╼╼╼╼╼╼╼╼");
            Console.WriteLine(" Move [99]      Inventory [100]      Skills [101]");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("════════════════════════════════════════════════════════════════════════════════════════════════════════");
            
            sw = Console.ReadLine();
            for (int b = 1; b < BeforeStart.placeDic[0].space.Length; b++)
            {
                for (int c = 1; c < BeforeStart.npcDic.Count; c++)
                {
                    if (options.PlayerLocation.space[b] == BeforeStart.npcDic[c])
                    {
                        if (sw == Convert.ToString(c))
                        {
                            for (int d = 1; d < BeforeStart.npcDic.Count; d++)
                            { 
                                if (BeforeStart.npcDic[d].PlayerSelected)  
                                {
                                    BeforeStart.npcDic[d].PlayerSelected = false;
                                    BeforeStart.npcDic[c].PlayerSelected = true;
                                }
                                else { BeforeStart.npcDic[c].PlayerSelected = true; }


                            }
                        }
                    }
                }
            }
            if (sw == "23") { BeforeStart.bookDic[0].PlayerEquiped = true; MainScreen(); }
            if (sw == "10") 
            {
                DialogueNPCLogic(1);
                DialogueNPCLogic(2);
                DialogueNPCLogic(3);
            }
            if (sw == "11") 
            {
                SkinshiPNPCLogic(1);
                SkinshiPNPCLogic(2);
                SkinshiPNPCLogic(3);
            }
            if (sw == "12")
            {
                if (options.PlayerLocation.IsHouse)
                {
                    if (!BeforeStart.PlayerHasFood()) 
                    {
                        DisplayingFood();
                    }
                    else 
                    {
                        Console.WriteLine("");
                        Console.WriteLine("There is no need to cook, you already have food");
                        Console.WriteLine("");
                        Console.ReadLine();
                        MainScreen();
                    }
                }
            }
            if (sw == "13" && BeforeStart.PlayerHasFood()) 
            {
                Console.WriteLine("");
                Console.WriteLine("");
                Program.Write("{=DarkGray}You Peacefully eat the food{/}");
                Console.WriteLine("");
                Console.ReadLine();
                CookingLogic.Cooking.EnergyAndStaminaLogic();

            }
            if (sw == "14" && options.PlayerLocation == BeforeStart.placeDic[11]) 
            {
                LibraryLogic.LibraryGFX();
            }
            if (sw == "SL" && options.PlayerTimeLeft >= 20 && options.PlayerLocation == BeforeStart.placeDic[0])
            {
                int rn = random.Next(8, 13);
                int ln = 0;
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("You slept for " + rn + " Hours");
                Console.ReadLine();
                options.PlayerTimeLeft += rn;
                options.DayCounter++;
                options.AbsuluteDayCouter++;
                Console.WriteLine();
                Console.WriteLine();
                if (options.DayBookReturn != options.AbsuluteDayCouter)
                {
                    ln = options.DayBookReturn -= options.AbsuluteDayCouter;
                    Console.WriteLine("You have " + ln + " Days to return the book you took.....");
                }
                else { }
                Console.WriteLine();
                Console.WriteLine();
                Console.ReadLine();
                BeforeStart.BeforeStarMenu();

            }
            if (sw == "T") 
            {
                TimeUsage(60);
                MainScreen();

            }
            else if (sw == "99") 
            {
                Console.Clear();
                if (options.PlayerLocation == BeforeStart.placeDic[0]) { Maps.Residence_Area(); }
                if (options.PlayerLocation == BeforeStart.placeDic[1]) { Maps.Residence_Area(); }
                if (options.PlayerLocation == BeforeStart.placeDic[2]) { Maps.Residence_Area(); }
                if (options.PlayerLocation == BeforeStart.placeDic[3]) { Maps.Residence_Area(); }
                if (options.PlayerLocation == BeforeStart.placeDic[4]) { Maps.Residence_Area(); }
                if (options.PlayerLocation == BeforeStart.placeDic[5]) { Maps.Residence_Area(); }
                if (options.PlayerLocation == BeforeStart.placeDic[6]) { Maps.Residence_Area(); }
                if (options.PlayerLocation == BeforeStart.placeDic[7]) { Maps.Residence_Area(); }
                if (options.PlayerLocation == BeforeStart.placeDic[8]) { Maps.Residence_Area(); }
                if (options.PlayerLocation == BeforeStart.placeDic[9]) { Maps.Residence_Area(); }
                if (options.PlayerLocation == BeforeStart.placeDic[10]) { Maps.Residence_Area(); }
                if (options.PlayerLocation == BeforeStart.placeDic[11]) { Maps.Library_Area(); }
                if (options.PlayerLocation == BeforeStart.placeDic[12]) { Maps.Library_Area(); }
            }
            else if (sw == "100") 
            {
                Console.Clear();
                DisplayingInventory();
            }
            else if (sw == "101")
            {
                Console.Clear();
                DisplaySkills();
            }
            else { MainScreen(); }
        }
    }
}
