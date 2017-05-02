using System;
using System.Collections.Generic;

namespace Eksamensopgave2017
{
    public class ConsoleReceipt : ConsoleDesign
    {
        private BuyTransaction _transaction;
        public string quickbuy = "Quickbuy";
        public string multipleBuy = "Purchase";  //Make function so Purcashe or Quickbuy is used

        public ConsoleReceipt(BuyTransaction transaction)
        {
            this.Transaction = transaction;
        }

        public BuyTransaction Transaction
        {
            get { return _transaction; }
            set { _transaction = value; }
        }

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
            Console.SetCursorPosition(0, 6);

			List<string> printingList = new List<string>();
            printingList.Add("");
            printingList.Add($"{Transaction.User.Username} made a {quickbuy}");
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
