using System;
using Stregsystem;
using System.Collections.Generic;

namespace Eksamensopgave2017
{
    class StregsystemCLI : IStregsystemUI
    {
        private bool _running = true;
        private IStregsystem _stregsystem;

        public StregsystemCLI(IStregsystem stregsystem)
        {
            _stregsystem = stregsystem;
        }

        public void PrintDisplay()
        {
            //BuyTransaction transaction = new BuyTransaction(sss.GetUserByID(3), DateTime.Now, sss.GetProductByID(2));
            

			ConsoleMenu menu = new ConsoleMenu();
            //ConsoleReceipt receipt = new ConsoleReceipt(transaction);
            //ConsoleMultipleBuy01 multi = new ConsoleMultipleBuy01();
            //ConsoleMultipleBuy02 multi2 = new ConsoleMultipleBuy02();

            menu.Print();
            //Console.ReadLine();
            //receipt.Print();
            //Console.ReadLine();
            //multi.Print();
            //Console.ReadLine();
            //multi2.Print();
            //Console.ReadLine();
        }

        public void DisplayUserNotFound(string username)
        {
			Console.BackgroundColor = ConsoleColor.Red;
			Console.ForegroundColor = ConsoleColor.White;
            string write = $"   A username such as {username} does not exist (yet)   ";
			Console.SetCursorPosition((Console.WindowWidth - write.Length) / 2, Console.CursorTop - 1);
			Console.WriteLine(write);
        }

        public void DisplayProductNotFound()
        {
			Console.BackgroundColor = ConsoleColor.Red;
			Console.ForegroundColor = ConsoleColor.White;
			string write = $"          A product with that ID does not exist           ";
			Console.SetCursorPosition((Console.WindowWidth - write.Length) / 2, Console.CursorTop - 1);
			Console.WriteLine(write);
        }

		public void DisplayProductNotActive(string product)
		{
			Console.BackgroundColor = ConsoleColor.Red;
			Console.ForegroundColor = ConsoleColor.White;
            string write = null;

            if (product.Length == 1)
                write = $"     A product with the ID: {product} is not currently active     ";
            else if (product.Length == 2)
				write = $"    A product with the ID: {product} is not currently active     ";
            else
				write = $"   A product with the ID: {product} is not currently active    ";

			Console.SetCursorPosition((Console.WindowWidth - write.Length) / 2, Console.CursorTop - 1);
            Console.WriteLine(write);
		}

        public void DisplayTooManyArgumentsError()
        {
            Console.WriteLine($"!ERROR!\nToo many arguments!");
        }

        public void DisplayAdminCommandNotFoundMessage(string adminCommand)
        {
            Console.WriteLine($"!ERROR!\nCommand not found!");
        }
       
        public void DisplayInsufficientCash(User user, Product product)
        {
            Console.WriteLine($"{user.Firstname} {user.Lastname} (ID {user.ID}) does not have money enough for the attempted purchase\n" +
                              $"Tried to buy: {product.Name} (ID {product.ID}) which costs {product.Price},-\n" +
                              $"Current balance: {user.Balance}");
        }

        public void DisplayGeneralError(string errorString)
        {
            Console.WriteLine(errorString);
        }

        public void Start()
        {
            while (_running)
            {
				PrintDisplay();
				string command = Console.ReadLine();
				CommandEntered?.Invoke(command);
				Console.ReadLine();
            }
        }
        
        public void Close()
        {
            throw new NotImplementedException();
        }

        public event StregsystemEvent CommandEntered;
    }
}

/*
StregsystemCLI er karakteriseret ved:
• Start
    ◦ En metode der starter brugergrænsefladen.
    ◦ Når brugergrænsefladen er startet, vil menuen blive vist,
        og være klar til at modtage quickbuy kommandoer. Mere om kommandoer i 3. del.
    ◦ Brugergrænsefladen skal kun vise aktive produkter.
    ◦ Denne klasse er den eneste i systemet der må skrive noget ud til brugeren!
*/
