using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test;
using static Test.BeforeStart;

namespace TestCore
{
    internal class CookingLogic
    {
        public class Cooking 
        {
            public static Random random = new Random();

            // Creates a recipe with the values inputed in the constructor
            public static void CreateRecipe(int materialamount, int ID, foodItem resoult,foodItem material1, int amount1, foodItem material2, int amount2, foodItem material3, int amount3)
            {
                if (materialamount == 1)
                { 
                    recipesDic[ID] = new foodRecipes { Result = resoult, MaterialAmount = materialamount, Material1 = material1, Material2 = null, Material3 = null }; 
                    recipesDic[ID].Material1.amount = amount1;
                }
                else if (materialamount == 2) 
                { 
                    recipesDic[ID] = new foodRecipes { Result = resoult, MaterialAmount = materialamount, Material1 = material1, Material2 = material2, Material3 = null };
                    recipesDic[ID].Material1.amount = amount1;
                    recipesDic[ID].Material2.amount = amount2;
                }
                else if (materialamount == 3) 
                { 
                    recipesDic[ID] = new foodRecipes { Result = resoult, MaterialAmount = materialamount, Material1 = material1, Material2 = material2, Material3 = material3 };
                    recipesDic[ID].Material1.amount = amount1;
                    recipesDic[ID].Material2.amount = amount2;
                    recipesDic[ID].Material3.amount = amount3;
                }
            }

            // Takes the Cooking level of the player and uses that to generate x random number, that number will assign a food tier to that 
            // Food, wich will give buffs and debuffs
            public static void FoodTierCalculatons(int i)
            {
                if (BeforeStart.skillDic[1].Level == 1)
                {
                    BeforeStart.foodDic[i].FoodTier = 1;
                }
                if (BeforeStart.skillDic[1].Level == 2)
                {
                    int b = random.Next(0, 2);
                    if (b == 0) { BeforeStart.foodDic[i].FoodTier = 1; }
                    if (b == 1) { BeforeStart.foodDic[i].FoodTier = 2; }
                }
                if (BeforeStart.skillDic[1].Level == 3)
                {
                    int b = random.Next(0, 2);
                    if (b == 0) { BeforeStart.foodDic[i].FoodTier = 1; }
                    if (b == 1) { BeforeStart.foodDic[i].FoodTier = 2; }
                }
                if (BeforeStart.skillDic[1].Level == 4)
                {
                    int b = random.Next(0, 3);
                    if (b == 0) { BeforeStart.foodDic[i].FoodTier = 1; }
                    if (b == 1) { BeforeStart.foodDic[i].FoodTier = 2; }
                    if (b == 2) { BeforeStart.foodDic[i].FoodTier = 3; }
                }
                if (BeforeStart.skillDic[1].Level == 5)
                {
                    int b = random.Next(0, 3);
                    if (b == 0) { BeforeStart.foodDic[i].FoodTier = 2; }
                    if (b == 1) { BeforeStart.foodDic[i].FoodTier = 3; }
                    if (b == 2) { BeforeStart.foodDic[i].FoodTier = 4; }
                }
                if (BeforeStart.skillDic[1].Level == 6)
                {
                    int b = random.Next(0, 3);
                    if (b == 0) { BeforeStart.foodDic[i].FoodTier = 3; }
                    if (b == 1) { BeforeStart.foodDic[i].FoodTier = 4; }
                    if (b == 2) { BeforeStart.foodDic[i].FoodTier = 5; }
                }
                if (BeforeStart.skillDic[1].Level == 7)
                {
                    int b = random.Next(0, 3);
                    if (b == 0) { BeforeStart.foodDic[i].FoodTier = 3; }
                    if (b == 1) { BeforeStart.foodDic[i].FoodTier = 4; }
                    if (b == 2) { BeforeStart.foodDic[i].FoodTier = 5; }
                }
                if (BeforeStart.skillDic[1].Level == 8)
                {
                    int b = random.Next(0, 3);
                    if (b == 0) { BeforeStart.foodDic[i].FoodTier = 4; }
                    if (b == 1) { BeforeStart.foodDic[i].FoodTier = 5; }
                    if (b == 2) { BeforeStart.foodDic[i].FoodTier = 6; }
                }
                if (BeforeStart.skillDic[1].Level == 9)
                {
                    int b = random.Next(0, 3);
                    if (b == 0) { BeforeStart.foodDic[i].FoodTier = 4; }
                    if (b == 1) { BeforeStart.foodDic[i].FoodTier = 5; }
                    if (b == 2) { BeforeStart.foodDic[i].FoodTier = 6; }
                }
                if (BeforeStart.skillDic[1].Level == 10)
                {
                    int b = random.Next(0, 3);
                    if (b == 0) { BeforeStart.foodDic[i].FoodTier = 5; }
                    if (b == 1) { BeforeStart.foodDic[i].FoodTier = 6; }
                    if (b == 2) { BeforeStart.foodDic[i].FoodTier = 7; }
                }
                if (BeforeStart.skillDic[1].Level == 15)
                {
                    int b = random.Next(0, 3);
                    if (b == 0) { BeforeStart.foodDic[i].FoodTier = 6; }
                    if (b == 1) { BeforeStart.foodDic[i].FoodTier = 7; }
                    if (b == 2) { BeforeStart.foodDic[i].FoodTier = 8; }
                }
                if (BeforeStart.skillDic[1].Level == 20)
                {
                    int b = random.Next(0, 3);
                    if (b == 0) { BeforeStart.foodDic[i].FoodTier = 7;}
                    if (b == 1) { BeforeStart.foodDic[i].FoodTier = 8;}
                    if (b == 2) { BeforeStart.foodDic[i].FoodTier = 9;}
                }
                switch (BeforeStart.foodDic[i].FoodTier) 
                {
                    case 1: Program.Write("{=DarkRed}[Trash]{/}"); break;
                    case 2: Program.Write("{=DarkRed}[Horrible]{/}"); break;
                    case 3: Program.Write("{=Red}[Terrible]{/}"); break;
                    case 4: Program.Write("{=DarkGreen}[Acceptable]{/}"); break;
                    case 5: Program.Write("{=Green}[Inedible]{/}"); break;
                    case 6: Program.Write("{=DarkCyan}[Decent]{/}"); break;
                    case 7: Program.Write("{=Cyan}[Good]{/}"); break;
                    case 8: Program.Write("{=DarkMagenta}[Delicious]{/}"); break;
                    case 9: Program.Write("{=Magenta}[Fantastic]{/}"); break;

                }

            }
            public static void EnergyAndStaminaLogic() 
            {
                for (int i = 0; i < BeforeStart.foodDic.Count; i++)
                {

                    if (BeforeStart.foodDic[i].isFood)
                    {
                        Console.WriteLine("first");
                        if (BeforeStart.foodDic[i].payerOwned)
                        {
                            Console.WriteLine("second");
                            int e = BeforeStart.foodDic[i].EnergyRec;
                            int s = BeforeStart.foodDic[i].StaminaRec;
                            for (int b = 1; b < 10; b++) 
                            {
                                Console.WriteLine("third");
                                Console.WriteLine(BeforeStart.foodDic[i].FoodTier);
                                if (BeforeStart.foodDic[i].FoodTier == b)
                                {
                                    Program.Write("{=Green}[+" + e + " Player Energy]{/}");
                                    Console.WriteLine();
                                    Program.Write("{=Green}[+" + s + " Player Stamina]{/}");
                                    Console.WriteLine();
                                    Console.ReadLine();
                                    Program.progressbarDic["EnergyBar"].currentProgress += BeforeStart.foodDic[i].EnergyRec;
                                    Program.progressbarDic["StaminaBar"].currentProgress += BeforeStart.foodDic[i].StaminaRec;
                                    if (Program.progressbarDic["EnergyBar"].currentProgress >= Program.progressbarDic["EnergyBar"].totalProgress)
                                    {
                                        Program.progressbarDic["EnergyBar"].currentProgress = Program.progressbarDic["EnergyBar"].totalProgress;
                                    }
                                    if (Program.progressbarDic["StaminaBar"].currentProgress >= Program.progressbarDic["StaminaBar"].totalProgress)
                                    {
                                        Program.progressbarDic["StaminaBar"].currentProgress = Program.progressbarDic["StaminaBar"].totalProgress;
                                    }
                                    Program.CalculateBarLogic("EnergyBar");
                                    Program.CalculateBarLogic("StaminaBar");
                                    PlayerScreen.TimeUsage(10);
                                    BeforeStart.foodDic[i].payerOwned = false;
                                    PlayerScreen.MainScreen();
                                }
                                e += 20;
                                s += 20;
                            }
                        }
                    }
                }
            }
            public static void RemoveUsedFoodMaterials(int i)
            {
                if (BeforeStart.recipesDic[i].MaterialAmount == 1)
                {
                    for (int b = 0; b < BeforeStart.foodDic.Count; b++) 
                    {
                        if (BeforeStart.recipesDic[i].Material1 == BeforeStart.foodDic[b])
                        {
                            if (BeforeStart.foodDic[b].amount >= BeforeStart.recipesDic[i].Material1.amount)
                            {
                                BeforeStart.foodDic[b].amount -= BeforeStart.recipesDic[i].Material1.amount;
                            }
                        }
                    }
                }
                else if (BeforeStart.recipesDic[i].MaterialAmount == 2)
                {
                    for (int b = 0; b < BeforeStart.foodDic.Count; b++)
                    {
                        if (BeforeStart.recipesDic[i].Material1 == BeforeStart.foodDic[b])
                        {
                            if (BeforeStart.foodDic[b].amount >= BeforeStart.recipesDic[i].Material1.amount)
                            {
                                BeforeStart.foodDic[b].amount -= BeforeStart.recipesDic[i].Material1.amount;
                            }
                        }
                        if (BeforeStart.recipesDic[i].Material2 == BeforeStart.foodDic[b])
                        {
                            if (BeforeStart.foodDic[b].amount >= BeforeStart.recipesDic[i].Material2.amount)
                            {
                                BeforeStart.foodDic[b].amount -= BeforeStart.recipesDic[i].Material2.amount;
                            }
                        }

                    }

                }
                else if (BeforeStart.recipesDic[i].MaterialAmount == 3)
                {
                    for (int b = 0; b < BeforeStart.foodDic.Count; b++)
                    {
                        if (BeforeStart.recipesDic[i].Material1 == BeforeStart.foodDic[b])
                        {
                            if (BeforeStart.foodDic[b].amount > BeforeStart.recipesDic[i].Material1.amount) 
                            {
                                BeforeStart.foodDic[b].amount -= BeforeStart.recipesDic[i].Material1.amount;
                            }
                        }
                        if (BeforeStart.recipesDic[i].Material2 == BeforeStart.foodDic[b])
                        {
                            if (BeforeStart.foodDic[b].amount > BeforeStart.recipesDic[i].Material2.amount)
                            {
                                BeforeStart.foodDic[b].amount -= BeforeStart.recipesDic[i].Material2.amount;
                            }
                        }
                        if (BeforeStart.recipesDic[i].Material3 == BeforeStart.foodDic[b])
                        {
                            if (BeforeStart.foodDic[b].amount > BeforeStart.recipesDic[i].Material3.amount)
                            {
                                BeforeStart.foodDic[b].amount -= BeforeStart.recipesDic[i].Material3.amount;
                            }

                        }
                    }
                }
            }
        }
    }
}
