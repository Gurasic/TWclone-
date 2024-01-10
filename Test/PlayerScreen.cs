using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.NPCs;

namespace Test
{
    internal class PlayerScreen
    {
        public static Random random = new Random();
        public static void NPCEnergyLogic(int ID) 
        { 
            switch (ID) 
            {
                case 1:  Program.progressbarDic["ReikaEnergyBar"].currentProgress = BeforeStart.npcDic[ID].NPCEnergyBar.currentProgress; Program.CalculateBarLogic("ReikaEnergyBar"); break;
                case 2: Program.progressbarDic["MollyEnergyBar"].currentProgress = BeforeStart.npcDic[ID].NPCEnergyBar.currentProgress; Program.CalculateBarLogic("MollyEnergyBar"); break;
            }
        
        }
        public static void DialogueNPCLogic(int ID) 
        { 
            if (BeforeStart.npcDic[ID].PlayerSelected) 
            {
                int i = random.Next(1, 3);
                int b = random.Next(4, 12);
                if (BeforeStart.npcDic[ID] == BeforeStart.npcDic[1] && !BeforeStart.npcDic[ID].PlayerMeet) { ReikaNPC.GreatingsDialogue(); PlayerScreen.MainScreen();}
                if (BeforeStart.npcDic[ID] == BeforeStart.npcDic[2] && !BeforeStart.npcDic[ID].PlayerMeet) { MollyNPC.GreatingsDialogue(); PlayerScreen.MainScreen(); }
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Program.Write(BeforeStart.npcDic[ID].ConvLine1[i]);
                Console.ReadLine();
                Program.Write(BeforeStart.npcDic[ID].ConvLine2[i]);
                Console.ReadLine();
                Program.Write(BeforeStart.npcDic[ID].ConvLine3[i]);
                Console.ReadLine();
                Console.WriteLine();
                TimeUsage(10);
                Console.WriteLine("");
                Program.Write("{=Red}-50 {/}{=Yellow}Player Energy {/}");
                Console.WriteLine("");
                Program.Write("{=Red}-50 {/}{=Yellow}"+ BeforeStart.npcDic[ID].Name +" Energy {/}");
                Console.WriteLine("");
                Console.WriteLine("+" + b +" Favor");
                Console.ReadLine();
                Program.progressbarDic["EnergyBar"].currentProgress -= 50;
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
        public static void DisplayingInventory() 
        {
            for (int i = 0; i < BeforeStart.itemDic.Count; i++)
            { 
                InventoryLogic(i);
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
                       Console.Write("("+i+")[" + BeforeStart.itemDic[i].Name + "]  (owned: " + BeforeStart.itemDic[i].amount + ")");
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
            string sw = Console.ReadLine();
            for (int i = 0; i < BeforeStart.itemDic.Count; i++)
            {
                if (BeforeStart.itemDic[i].payerOwned)
                {
                    if (sw == Convert.ToString(i)) 
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
                            DisplayingInventory(); 
                        
                        }
                        if (sd == "2") 
                        { 
                            if (BeforeStart.itemDic[i].IsEquipable) 
                            {
                                if (BeforeStart.itemDic[i].playerEquiped)
                                {
                                    BeforeStart.itemDic[i].playerEquiped = false;
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
                                DisplayingInventory(); 
                            } 
                        }
                        if (sd == "3") { DisplayingInventory(); }
                    }
                }
            }
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
            BeforeStart.itemDic[1].playerEquiped = true;
            string sw = "";
            Console.WriteLine("════════════════════════════════════════════════════════════════════════════════════════════════════════");
            BeforeStart.CalculateTimeLogic();
            Console.WriteLine("");
            Console.WriteLine("You are on " + "[" + options.PlayerLocation.Name + "]");
            Console.WriteLine("Energy:  " + Program.progressbarDic["EnergyBar"].barSprite+ "       Stamina: " + Program.progressbarDic["StaminaBar"].barSprite);
            for (int c = 1; c < BeforeStart.npcDic.Count; c++)
            {
                if (BeforeStart.npcDic[c] != null && BeforeStart.npcDic[c].PlayerSelected)
                {
                    Console.WriteLine("");
                    Console.WriteLine("Selected: " + BeforeStart.npcDic[c].Name + "( Favor: " + BeforeStart.npcDic[c].NPCFavor + "   Trust: " + BeforeStart.npcDic[c].NPCTrust + " )  ENR: " + BeforeStart.npcDic[c].NPCEnergyBar.barSprite);
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
                            
                            Program.Write("{="+ BeforeStart.npcDic[c].Color + "}[" + BeforeStart.npcDic[c].Name + "]  {/}");
                            options.SelectedNPC = BeforeStart.npcDic[c];
                        }
                        else 
                        {
                            Console.Write("["+ BeforeStart.npcDic[c].Name + "]  "); 
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
            Console.WriteLine("╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌");
            for (int b = 1; b < BeforeStart.placeDic[0].space.Length; b++)
            {
                for (int c = 1; c < BeforeStart.npcDic.Count; c++)
                {
                    if (options.PlayerLocation.space[b] == BeforeStart.npcDic[c])
                    {
                        if (BeforeStart.npcDic[c].PlayerSelected)
                        {
                            Console.Write(" [10] Talk");
                        }
                    }
                }
            }
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("╼╼╼╼╼╼╼╼╼╼╼╼╼╼╼╼╼╼╼╼╼╼╼╼╼╼╼╼╼╼╼╼╼╼╼╼╼╼╼╼╼╼╼╼╼╼╼╼╼╼╼╼╼╼╼╼╼╼╼╼╼╼╼╼╼╼╼╼╼╼╼╼╼╼╼╼╼╼╼╼╼╼╼╼╼╼╼╼╼╼╼╼╼╼╼╼╼╼╼╼╼╼╼╼");
            Console.WriteLine(" Move [99]    Inventory [100]");
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
            if (sw == "10") 
            {
                DialogueNPCLogic(1);
                DialogueNPCLogic(2);
            }
            else if (sw == "99") 
            {
                Maps.Residence_Area();

            }
            else if (sw == "100") 
            {
                DisplayingInventory();
            }
            else { MainScreen(); }
        }
    }
}
