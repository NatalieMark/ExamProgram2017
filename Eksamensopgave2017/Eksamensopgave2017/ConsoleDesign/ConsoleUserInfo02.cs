using System;
using Stregsystem;
using System.Collections.Generic;
using System.Linq;

namespace Eksamensopgave2017
{
	/// <summary>
	/// ConsoleUserinfo02 is the subclass of ConsoleDesign.
	/// It has a header, a body, a bodytext the print method which calls all the other methods.
	/// This displays up to 10 of a users purchases.
	/// </summary>
	public class ConsoleUserInfo02 : ConsoleDesign
    {
        private IStregsystem _stregsystem;
		private int _lineLength = 0;

		public ConsoleUserInfo02(User user, IStregsystem stregsystem)
        {
            this.User = user;
            this._stregsystem = stregsystem;
        }

		public User User { get; set; }
		
        public override void Header()
		{
			Console.WriteLine();
			
			List<string> printingList = new List<string>();
			
			printingList.Add("_  _ ____ ____ ____    _ _  _ ____ ____");
			printingList.Add("|  | [__  |___ |__/    | |\\ | |___ |  |");
			printingList.Add("|__| ___] |___ |  \\    | | \\| |    |__|");
			
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


            printingList.Add(" _______________________________________________________________ ");
            printingList.Add("|                                                               |");
            printingList.Add("|                         Last purchases                        |");
            printingList.Add("|   ·························································   |");
            printingList.Add("| 1                                                             |"); //ID
            printingList.Add("| 2                                                             |");
            printingList.Add("| 3                                                             |");
            printingList.Add("| 4                                                             |");
            printingList.Add("| 5                                                             |");
            printingList.Add("| 6                                                             |");
            printingList.Add("| 7                                                             |");
            printingList.Add("| 8                                                             |");
            printingList.Add("| 9                                                             |");
            printingList.Add("| 10                                                            |");
            printingList.Add("|                                                               |");
            printingList.Add("|                  Hit enter to return to Menu                  |");
            printingList.Add("|_______________________________________________________________|");


            foreach (string line in printingList)
            {
                Console.SetCursorPosition((Console.WindowWidth - line.Length) / 2, Console.CursorTop);
                Console.WriteLine(line);
                _lineLength = line.Length;
            }
        }

        public void BodyText()
        {
			Console.SetCursorPosition(0, 9);

            IEnumerable<Transaction> transactions = _stregsystem.GetTransactions(User, 10).ToList();

            foreach (Transaction transaction in transactions)
            {
                Console.SetCursorPosition((Console.WindowWidth - _lineLength + 10) / 2, Console.CursorTop);
                Console.WriteLine(((BuyTransaction)transaction).Product.ToString());
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
