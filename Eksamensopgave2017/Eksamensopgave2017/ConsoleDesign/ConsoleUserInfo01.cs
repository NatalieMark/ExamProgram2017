using System;
using System.Collections.Generic;
using Stregsystem;

namespace Eksamensopgave2017
{
	/// <summary>
	/// ConsoleUserinfo01 is the subclass of ConsoleDesign.
	/// It has a header, a body, a bodytext the print method which calls all the other methods.
	/// This displays a users info.
	/// </summary>
	public class ConsoleUserInfo01 : ConsoleDesign
    {
        public ConsoleUserInfo01(User user)
        {
            this.User = user;
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

			printingList.Add(" ________________________________________________________ ");
			printingList.Add("|                                                        |");
            printingList.Add("|                                                        |");
			printingList.Add("|   ··················································   |");
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
			printingList.Add("|           Hit enter to see the last purhases           |");
			printingList.Add("|________________________________________________________|");

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

            printingList.Add($"   About {User.Firstname} {User.Lastname}");
			printingList.Add("");
			printingList.Add("");
			printingList.Add($"Username:         {User.Username}");
			printingList.Add("");
			printingList.Add($"User ID:          {User.ID}");
			printingList.Add("");
			printingList.Add($"Email:            {User.Email}");
			printingList.Add("");
			printingList.Add($"Current Balance:  {User.Balance},-");

            foreach (string line in printingList)
            {
				Console.SetCursorPosition((Console.WindowWidth - 50) / 2, Console.CursorTop);
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
