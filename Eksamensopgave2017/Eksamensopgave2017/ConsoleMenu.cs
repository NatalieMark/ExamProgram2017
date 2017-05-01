using System;
using System.Collections.Generic;
namespace Eksamensopgave2017
{
    public class ConsoleMenu : ConsoleDesign
    {
        public ConsoleMenu()
        {
        }
		

		public override void Header()
		{
            Console.WriteLine();
			
			List<string> printingList = new List<string>();

			printingList.Add(" _  _ ____ _  _ _  _");
			printingList.Add(" |\\/| |___ |\\ | |  |");
			printingList.Add(" |  | |___ | \\| |__|");

			foreach (string line in printingList)
			{
				Console.SetCursorPosition((Console.WindowWidth - line.Length) / 2, Console.CursorTop);
				Console.WriteLine(line);
			}
            Console.WriteLine();
        }

        public override void Body()
        {
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Black;

            List<string> printingList = new List<string>();

            printingList.Add(" ________________________________________________________ ");
            printingList.Add("|  Options:                                      Write:  |");
            printingList.Add("|––––––––––––––––––––––––––––––––––––––––––––––––––––––––|");
            printingList.Add("|                                                        |");
            printingList.Add("|  Quickbuy                    ( Username, product ID )  |");
			printingList.Add("|                                                        |");
			printingList.Add("|  User info                               ( Username )  |");
			printingList.Add("|                                                        |");
			printingList.Add("|  Buy multiple products                    ( \"multi\" )  |");
			printingList.Add("|                                                        |");
			printingList.Add("|________________________________________________________|");

			foreach(string line in printingList)
            {
				Console.SetCursorPosition((Console.WindowWidth - line.Length) / 2, Console.CursorTop);
                Console.WriteLine(line);
            }

		}

        public void Choice()
        {
			Console.BackgroundColor = ConsoleColor.Gray;
			Console.ForegroundColor = ConsoleColor.Black;

			string write = " Your choice:                                             ";
			Console.SetCursorPosition((Console.WindowWidth - write.Length) / 2, Console.CursorTop);
			Console.Write(write);
            Console.SetCursorPosition(Console.WindowWidth / 3), Console.CursorTop);
            Console.ReadLine();
        }

        public override void Print()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Clear();
            Header();
            Body();
            Choice();
			Console.BackgroundColor = ConsoleColor.Black;
			Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
