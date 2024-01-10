using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test;

namespace TestCore
{
    internal class LibraryLogic
    {
        public static Random random = new Random();
        public static bool conv = true;
        public static void LibraryLines()
        {
            options.LibraryConv[0] = "{=Cyan}⌊ Welcome!! ⌉{/}";
            options.LibraryConv[1] = "{=Cyan}⌊ How are you?..⌉{/}";
            options.LibraryConv[2] = "{=Cyan}⌊ This Book is my favorite, you should try it ⌉{/}";
            options.LibraryConv[3] = "{=Cyan}⌊ Have you Chosen a book yet? ⌉{/}";
            options.LibraryConv[4] = "{=Cyan}⌊ Well see if you return it... ⌉{/}";
            options.LibraryConv[5] = "{=Cyan}⌊ Books have a lot of knowlage, maybe some of it is helpful... ⌉{/}";
            options.LibraryConv[6] = "{=Cyan}⌊ The Cooking guide has some nice tips, i really love it ⌉{/}";
            options.LibraryConv[7] = "{=Cyan}⌊ How is your day going?.. ⌉{/}";
            options.LibraryConv[8] = "{=Cyan}⌊ Maybe youll find something cool to read ⌉{/}";
            options.LibraryConv[9] = "{=Cyan}⌊ Dont you love the smell of new Books?.. ⌉{/}";
            options.LibraryConv[10] = "{=Cyan}⌊ Did you know that i love books?.. ⌉{/}";
            options.LibraryConv[11] = "{=Cyan}⌊ You should read more books ⌉{/}";
            options.LibraryConv[12] = "{=Cyan}⌊ This place is the knowlage paradise ⌉{/}";
            options.LibraryConv[13] = "{=Cyan}⌊ There are some... books... that ill rather avoid... ⌉{/}";
            options.LibraryConv[14] = "{=Cyan}⌊ Reading is the best way to learn a languege ⌉{/}";
            options.LibraryConv[15] = "{=Cyan}⌊ Working here is fun ⌉{/}";
            options.LibraryConv[16] = "{=Cyan}⌊ Mystery books are... well... a Mystery ⌉{/}";
            options.LibraryConv[17] = "{=Cyan}⌊ We should buy more books for the library ⌉{/}";
            options.LibraryConv[18] = "{=Cyan}⌊ Speaking with people is hard, try reading the Speach Guide!! ⌉{/}";
            options.LibraryConv[19] = "{=Cyan}⌊ Maybe you can donate a book to the library?.. ⌉{/}";
            options.LibraryConv[20] = "{=Cyan}⌊ Thanks for coming to the Library!!! ⌉{/}";
            
        }
        public static void LibraryTimeReturn()
        {
            options.DayBookOptained = options.AbsuluteDayCouter;
            options.DayBookReturn = options.DayBookOptained + 7;
        }
        public static bool PlayerHasABook() 
        { 
            for(int i = 0; i < BeforeStart.bookDic.Count; i++) 
            {
                if (BeforeStart.bookDic[i].PlayerEquiped) 
                {
                    return true;
                }
            }

            return false;
        }
        public static void LibraryGFX() 
        {
            
            int r = random.Next(0, 21);
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            if (conv) { Program.Write(options.LibraryConv[r]); Console.WriteLine(""); Console.ReadLine(); conv = false; }
            Console.WriteLine("╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌");
            Console.WriteLine("Books: ");
            Console.WriteLine("");
            for (int i = 0; i < BeforeStart.bookDic.Count; i++) 
            {
                if (BeforeStart.bookDic[i].IsInStock) 
                {
                    Console.WriteLine("[" + i + "]" + " / [" + BeforeStart.bookDic[i].Name + "]");
                }
                else 
                {
                    Console.WriteLine();
                    Program.Write("{=DarkGray}" + "[" + i + "]" + " / [" + BeforeStart.bookDic[i].Name + "]   (OUT OF STOCK)" + "{/}");
                    Console.WriteLine();
                }
            }
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌");
            Console.WriteLine("[99] Return");
            Console.WriteLine("");
            string sw = Console.ReadLine();
            for (int b  = 0; b < BeforeStart.bookDic.Count; b++) 
            { 
                if(sw == Convert.ToString(b))
                {
                    if (BeforeStart.bookDic[b].IsInStock && !PlayerHasABook())
                    {
                        BeforeStart.bookDic[b].IsInStock = false;
                        BeforeStart.bookDic[b].PlayerEquiped = true;
                        Console.WriteLine();
                        Console.WriteLine();
                        Program.Write("{=Cyan}⌊ You now own the " + BeforeStart.bookDic[b].Name + " ⌉{/}");
                        LibraryTimeReturn();
                        Console.ReadLine();
                        PlayerScreen.MainScreen();
                    }
                    else if (!BeforeStart.bookDic[b].IsInStock)
                    {
                        Console.WriteLine();
                        Console.WriteLine();
                        Program.Write("{=Cyan}⌊ That book is out of stock!! ⌉{/}");
                        Console.ReadLine();
                        LibraryGFX();
                    }
                    else 
                    {
                        Console.WriteLine();
                        Console.WriteLine();
                        Program.Write("{=Cyan}⌊ You already own a book, return it first!! ⌉{/}");
                        Console.ReadLine();
                        LibraryGFX();

                    }

                }
                else if(sw == "99") 
                {
                    conv = true;
                    PlayerScreen.MainScreen();
                }
            }
        }

    }
}
