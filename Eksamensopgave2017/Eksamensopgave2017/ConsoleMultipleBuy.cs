using System;
using System.Collections.Generic;

namespace Eksamensopgave2017
{
    public class ConsoleMultipleBuy : ConsoleDesign
    {
		private BuyTransaction _transaction;

        public ConsoleMultipleBuy(BuyTransaction transaction)
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
			printingList.Add("| ID |       Products      | Price | ID |       Products      | Price |");
			printingList.Add("|    |                     |       |    |                     |       |");
			printingList.Add("|    |                     |       |    |                     |       |");
			printingList.Add("|    |                     |       |    |                     |       |");
			printingList.Add("|    |                     |       |    |                     |       |");
			printingList.Add("|    |                     |       |    |                     |       |");
			printingList.Add("|    |                     |       |    |                     |       |");
			printingList.Add("|    |                     |       |    |                     |       |");
			printingList.Add("|    |                     |       |    |                     |       |");
			printingList.Add("|    |                     |       |    |                     |       |");
			printingList.Add("|    |                     |       |    |                     |       |");
			printingList.Add("|    |                     |       |    |                     |       |");
			printingList.Add("|    |                     |       |    |                     |       |");
			printingList.Add("|    |                     |       |    |                     |       |");
			printingList.Add("|    |                     |       |    |                     |       |");
			printingList.Add("|____|_____________________|_______|____|_____________________|_______|");
            printingList.Add("                                                                       ");

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
			printingList.Add($"{Transaction.User.Username} made a ");
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

		public void Buttons()
		{
            string write = "Previous";
			string write1 = "Next";

            Console.SetCursorPosition(Console.WindowWidth / 2 - write.Length, Console.CursorTop - 1);
            Console.Write(write);

            Console.SetCursorPosition(Console.WindowWidth / 2 + write1.Length, Console.CursorTop);
			Console.Write(write1);

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
            Buttons();
        }
    }
}
