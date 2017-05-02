using System;
using System.Collections.Generic;

namespace Eksamensopgave2017
{
    class StregsystemCLI : IStregsystemUI
    {
        private IStregsystem _stregsystem;

        public StregsystemCLI(IStregsystem stregsystem)
        {
            _stregsystem = stregsystem;
        }

        public void PrintDisplay()
        {
            Stregsystem sss = new Stregsystem();
            BuyTransaction transaction = new BuyTransaction(sss.GetUserByID(3), DateTime.Now, sss.GetProductByID(2));
            
			
			ConsoleMenu menu = new ConsoleMenu();
            ConsoleReceipt receipt = new ConsoleReceipt(transaction);
            ConsoleMultipleBuy multi = new ConsoleMultipleBuy(transaction);

            menu.Print();
            Console.ReadLine();
            receipt.Print();
            Console.ReadLine();
            multi.Print();

        }

        public void DisplayUserNotFound(string username)
        {
            Console.WriteLine($"{username} not found");
        }

        public void DisplayProductNotFound(string product)
        {
            Console.WriteLine($"{product} not found");
        }

        public void DisplayUserInfo(User user)
        {
            Console.WriteLine($"{user} not found");
        }

        public void DisplayTooManyArgumentsError(string command)
        {
            Console.WriteLine($"!ERROR!\nToo many arguments!");
        }

        public void DisplayAdminCommandNotFoundMessage(string adminCommand)
        {
            Console.WriteLine($"!ERROR!\nCommand not found!");
        }

        public void DisplayUserBuysProduct(BuyTransaction transaction)
        {
            Console.WriteLine(transaction.ToString());
        }

        public void DisplayUserBuysProduct(int count, BuyTransaction transaction)
        {
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine(transaction.ToString());
            }
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
            PrintDisplay();
            string command = Console.ReadLine();
            CommandEntered?.Invoke(command);
            Console.ReadLine();
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
