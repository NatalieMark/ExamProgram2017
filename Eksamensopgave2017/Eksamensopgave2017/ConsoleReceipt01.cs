using System;
using System.Collections.Generic;
using Stregsystem;

namespace Eksamensopgave2017
{
    public class ConsoleReceipt01 : ConsoleDesign
    {
        public ConsoleReceipt01(BuyTransaction transaction)
        {
            this.Transaction = transaction;
        }

        public BuyTransaction Transaction { get; set; }

        public string TypeOfPurchase { get; set; }

		public override void Header()
		{
			Console.WriteLine();

			List<string> printingList = new List<string>();

            printingList.Add("____ ____ ____ ____    ___ ___");
            printingList.Add("|__/ |___ |    |___ | | __] |");
            printingList.Add("|  \\ |___ |___ |___ | |     |");

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
			printingList.Add("|                                                        |");
			printingList.Add("|                                                        |");
			printingList.Add("|                                                        |");
			printingList.Add("|                                                        |");
			printingList.Add("|                                                        |");
			printingList.Add("|                                                        |");
			printingList.Add("|                                                        |");
			printingList.Add("|                                                        |");
			printingList.Add("|                                                        |");
			printingList.Add("|________________________________________________________|");

			foreach (string line in printingList)
			{
				Console.SetCursorPosition((Console.WindowWidth - line.Length) / 2, Console.CursorTop);
				Console.WriteLine(line);
            }
        }

        public void BodyText()
        {
            Console.SetCursorPosition(0, 7);

			List<string> printingList = new List<string>();
            printingList.Add($"{Transaction.User.Firstname} {Transaction.User.Lastname} made a Quickbuy");
			printingList.Add("and bought following product:");
            printingList.Add("");
            printingList.Add($"{Transaction.Product.Name} {Transaction.Product.Price},-");
			printingList.Add("");
			printingList.Add("");
			printingList.Add("");
			printingList.Add($"{Transaction.Date}");

			foreach (string line in printingList)
			{
				Console.SetCursorPosition((Console.WindowWidth - line.Length) / 2, Console.CursorTop);
				Console.WriteLine(line);
			}
        }

        public override void Print()
        {
			Console.BackgroundColor = ConsoleColor.Black;
			Console.ForegroundColor = ConsoleColor.Gray;
            Console.Clear();
            Header();
            Body();

            BodyText();
        }
    }
}
