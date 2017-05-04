using System;
using Stregsystem;
using System.Collections.Generic;
using System.Linq;

namespace Eksamensopgave2017
{
    public class ConsoleUserInfo02 : ConsoleDesign
    {
        private IStregsystem _stregsystem;

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
            int lineLength = 0;
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
                lineLength = line.Length;
            }
        }

        public void BodyText()
        {
			Console.SetCursorPosition(0, 7);

			List<string> printingList = new List<string>();

            IEnumerable<Transaction> transactions = _stregsystem.GetTransactions(User, 1).ToList();

            foreach (Transaction transaction in transactions)
            {
                printingList.Add(transaction.ToString());
            }
            foreach(string line in printingList)
            {
				Console.WriteLine($"{line}");
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
