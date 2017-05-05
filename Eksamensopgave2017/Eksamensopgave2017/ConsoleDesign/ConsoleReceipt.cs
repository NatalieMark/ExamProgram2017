using System;
using System.Collections.Generic;
using Stregsystem;

namespace Eksamensopgave2017
{
	/// <summary>
	/// ConsoleReceipt is the subclass of ConsoleDesign.
	/// It has a header, a body, a bodytext the print method which calls all the other methods.
	/// This receipt displays after the buytransaction has gone through.
	/// </summary>
	public class ConsoleReceipt : ConsoleDesign
	{
		public ConsoleReceipt(BuyTransaction transaction, int amount, bool isQuickbuy)
		{
			this.Transaction = transaction;
            this.Amount = amount;
            this.IsQuickbuy = isQuickbuy;
		}

		public BuyTransaction Transaction { get; set; }

		public int Amount { get; set; }

        public bool IsQuickbuy { get; set; }

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

            string quickbuy = "";
            if (IsQuickbuy)
                quickbuy = "Quickbuy";


            List < string > printingList = new List<string>();
            printingList.Add($"{Transaction.User.Firstname} {Transaction.User.Lastname} made a {quickbuy}purchase");
			printingList.Add("and bought the following products:");
			printingList.Add("");
            printingList.Add($"{Amount}x {Transaction.Product.Name} {Transaction.Product.Price},-");
			printingList.Add("");
			printingList.Add("·······························");
            printingList.Add($"Total price: {Amount * Transaction.Product.Price},-");
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
