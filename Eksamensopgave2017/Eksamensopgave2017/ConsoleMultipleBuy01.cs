using System;
using System.Collections.Generic;
using Stregsystem;

namespace Eksamensopgave2017
{
    public class ConsoleMultipleBuy01 : ConsoleDesign
    {
        private int _productsPrinted;

        public ConsoleMultipleBuy01(IStregsystem stregsystem)
        {
            this.stregsystem = stregsystem;
        }

        IStregsystem stregsystem;
        List<Product> activeProductsList = new List<Product>();
        List<int> activeProductsCounter = new List<int>();

        public void ActiveProductsToList()
        {
			IEnumerable<Product> activeProducts = stregsystem.ActiveProducts;

            foreach (Product product in activeProducts)
            {
				activeProductsList.Add(product);
                activeProductsCounter.Add(product.ID);
            }
		}

		public override void Header()
		{
			Console.WriteLine();

			List<string> printingList = new List<string>();

			printingList.Add("____ _    _       ___  ____ ____ ___  _  _ ____ ___ ____");
			printingList.Add("|__| |    |       |__] |__/ |  | |  \\ |  | |     |  [__ ");
			printingList.Add("|  | |___ |___    |    |  \\ |__| |__/ |__| |___  |  ___]");

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

			printingList.Add(" _____________________________________________________________________ ");
			printingList.Add("|  ID  |                     Products                     |   Price   |");
			printingList.Add("|      |                                                  |           |");
			printingList.Add("|      |                                                  |           |");
			printingList.Add("|      |                                                  |           |");
			printingList.Add("|      |                                                  |           |");
			printingList.Add("|      |                                                  |           |");
			printingList.Add("|      |                                                  |           |");
			printingList.Add("|      |                                                  |           |");
			printingList.Add("|      |                                                  |           |");
			printingList.Add("|      |                                                  |           |");
			printingList.Add("|      |                                                  |           |");
			printingList.Add("|      |                                                  |           |");
			printingList.Add("|      |                                                  |           |");
			printingList.Add("|______|__________________________________________________|___________|");
			printingList.Add("                                                                       ");
			printingList.Add("                                                                   P.1 ");

			foreach (string line in printingList)
			{
				Console.SetCursorPosition((Console.WindowWidth - line.Length) / 2, Console.CursorTop);
				Console.WriteLine(line);
			}
        }

		public void BodyText()
		{
            ActiveProductsToList();
			Console.SetCursorPosition(0, 8);

            if (activeProductsCounter.Count > 11)
                _productsPrinted = 11;
            else
                _productsPrinted = activeProductsCounter.Count;

                for (int i = 0; i < _productsPrinted; i++)
                {
                    Console.SetCursorPosition((Console.WindowWidth - 67) / 2, Console.CursorTop);
                    Console.WriteLine(activeProductsList[i].ID);
                }

            Console.SetCursorPosition(0, 8);
            for (int i = 0; i < _productsPrinted; i++)
            {
				Console.SetCursorPosition((Console.WindowWidth - 52) / 2, Console.CursorTop);
                Console.WriteLine(activeProductsList[i].Name);
			}

			Console.SetCursorPosition(0, 8);
			for (int i = 0; i < _productsPrinted; i++)
			{
				Console.SetCursorPosition((Console.WindowWidth + 53) / 2, Console.CursorTop);
                Console.WriteLine($"{activeProductsList[i].Price,6}");
			}
        }

        public void Choice()
		{
			Console.SetCursorPosition(0, 20);

			string write = "Buy multiple products (username product ID quantity)";
			Console.SetCursorPosition((Console.WindowWidth - write.Length) / 2, Console.CursorTop);
			Console.WriteLine(write);

			string writeMore = "(or write \"more\" to see more products)";
            Console.SetCursorPosition((Console.WindowWidth - writeMore.Length) / 2, Console.CursorTop);
            Console.WriteLine(writeMore);

            string choice = "                                                                       ";
            Console.BackgroundColor = ConsoleColor.White;
            Console.SetCursorPosition((Console.WindowWidth - choice.Length) / 2, Console.CursorTop);
            Console.WriteLine(choice);

			string choiceWrite = " Your choice:                                                          ";
            Console.SetCursorPosition((Console.WindowWidth - choiceWrite.Length) / 2, Console.CursorTop - 1);
            Console.Write(choiceWrite);

			Console.ForegroundColor = ConsoleColor.DarkBlue;
			Console.SetCursorPosition(Console.WindowWidth / 3, Console.CursorTop);
		}

		public override void Print()
        {
            Console.BackgroundColor = ConsoleColor.Black;
			Console.ForegroundColor = ConsoleColor.Gray;
			Console.Clear();
            Header();
            Body();
            BodyText();
            Choice();
        }
    }
}

/*

*/
