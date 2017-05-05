using System;
using System.Collections.Generic;
using Stregsystem;

namespace Eksamensopgave2017
{
    /// <summary>
    /// StregsystemController handles what happens in the program.
    /// The input from the user comes in as one string and is handled here.
    /// </summary>
	class StregsystemController
	{
		private IStregsystemUI _ui;
		private IStregsystem _stregsystem;
        public Dictionary<string, Action<string[]>> AdminCommands = new Dictionary<string, Action<string[]>>();

		public StregsystemController(IStregsystemUI ui, IStregsystem stregsystem)
		{
			this._ui = ui;
			this._stregsystem = stregsystem;
            ui.CommandEntered += HandleInput;
			AddAdminCommands();
		}

        // All the admin commands and what they do
        public void AddAdminCommands()
        {
            AdminCommands.Add(":activate", args => _stregsystem.GetProductByID(int.Parse(args[1])).Active = true);
            AdminCommands.Add(":addcredits", args => _stregsystem.AddCreditsToAccount(_stregsystem.GetUserByUsername(args[1]), decimal.Parse(args[2])));
            AdminCommands.Add(":deactivate", args => _stregsystem.GetProductByID(int.Parse(args[1])).Active = false);
            AdminCommands.Add(":creditoff", args => _stregsystem.GetProductByID(int.Parse(args[1])).CanBeBoughtOnCredit = false);
            AdminCommands.Add(":crediton", args => _stregsystem.GetProductByID(int.Parse(args[1])).CanBeBoughtOnCredit = true);
			AdminCommands.Add(":q", args => _ui.Close());
			AdminCommands.Add(":quit", args => _ui.Close());
		}

        // The one input is handled here, splitted and putted into a stringarray
        public void HandleInput(string command)
        {
            string[] commandSplitted = null;
            User user = _stregsystem.GetUserByUsername(command); 

            //Checks if the command is empty
            if (command != null)
            {
                commandSplitted = command.Split(' ');

                // Checks if the command if it starts with ":", if <true>, it is an admin command.
                if (command.StartsWith(":"))
                {
                    try
                    {
						AdminCommands[commandSplitted[0]](commandSplitted);
                    }
                    catch (Exception)
                    {
                        _ui.DisplayAdminCommandNotFoundMessage();
                    }
                }
                // If it is not an admin command, it should be handled differently.
                else
                {
                    if (commandSplitted.Length == 1)
                        commandParse01(command, user);
                    else if (commandSplitted.Length == 2)
                        commandParse02(commandSplitted);
                    else
                        _ui.DisplayTooManyArgumentsError();
                }
            }
		}

        // If command consists of one word
        public void commandParse01(string command, User user)
        {
            // If the word is "multi"
			if (command == "multi")
				MultiBuyProducts01();
            // If the word contains a username
			else if (user != null)
			{
				if (command == user.Username)
					UserInfo(command);
			}
			else
				_ui.DisplayGeneralError();
        }

        // If commans consists of two words it is a quickbuy
        public void commandParse02(string[] commandSplitted)
        {
            string username = commandSplitted[0];
            int productID;
            int.TryParse(commandSplitted[1], out productID);
			// "1" Because a Quickbuy only consists of one single product
            Receipt(username, productID, 1);
        }

        // The transaction is handled here
        public void Receipt(string username, int productID, int quantity)
        {
            User user;
            Product product;

            // Checks whether a username as the given, exists
            if (_stregsystem.GetUserByUsername(username) != null)
            {
                user = _stregsystem.GetUserByUsername(username);

				// Checks whether a product ID as the given, exists
				if (_stregsystem.GetProductByID(productID) != null)
                {
                    product = _stregsystem.GetProductByID(productID);

					// Checks whether the product is active
					if (product.Active)
                    {
                        // Checks if the user can afford the product and the quantity of it, and if not, if the product can be bought on credit
                        if (product.Price * quantity <= user.Balance || product.CanBeBoughtOnCredit)
                        {
                            BuyTransaction purchase = null;

                            for (int i = 0; i < quantity; i++)
                            {
							    purchase = _stregsystem.BuyProduct(user, product);
                            }
                            ConsoleReceipt receipt = new ConsoleReceipt(purchase, quantity, false);
                            receipt.Print();
                        }
                        else
                            _ui.DisplayInsufficientCash(user, product);
                    }
                    else
                        _ui.DisplayProductNotActive($"{product.ID}");
                }
                else
                    _ui.DisplayProductNotFound();
            }
            else
                _ui.DisplayUserNotFound(username);
        }

        // Disply for multibuy
        public void MultiBuyProducts01()
        {
            bool _running = true;
			ConsoleMultipleBuy01 multibuyPage01 = new ConsoleMultipleBuy01(_stregsystem);
			while(_running)
            {
				multibuyPage01.Print();
				string[] commandSplitted = null;
                string command = Console.ReadLine();

                // Handles input (wheter to go to next display or to buy)
                if (command != null)
                {
                    commandSplitted = command.Split(' ');

                    if (commandSplitted.Length == 1)
                    {
                        if (command == "more")
                        {
                            _running = false;
                            MultiBuyProducts02();
                        }
                    }
                    else if (commandSplitted.Length == 3)
                    {
                        _running = false;
                        string username = commandSplitted[0];
                        int productID, quantity;
                        int.TryParse(commandSplitted[1], out productID);
                        int.TryParse(commandSplitted[2], out quantity);

                        if (quantity > 0)
                            Receipt(username, productID, quantity);
                        else
                            _ui.DisplayGeneralError();
                    }
                    else
                        _ui.DisplayTooManyArgumentsError();
                }
            }
        }

		// Disply for multibuy
		public void MultiBuyProducts02()
        {
			bool _running = true;
            ConsoleMultipleBuy02 multibuyPage02 = new ConsoleMultipleBuy02(_stregsystem);

			while (_running)
			{
				multibuyPage02.Print();
				string[] commandSplitted = null;
				string command = Console.ReadLine();

				// Handles input (wheter to go to next display or to buy)
				if (command != null)
				{
					commandSplitted = command.Split(' ');

					if (commandSplitted.Length == 1)
					{
						if (command == "more")
                        {
                            _running = false;                     
							MultiBuyProducts01();
                        }
					}
					else if (commandSplitted.Length == 3)
					{
						_running = false;
						string username = commandSplitted[0];
						int productID, quantity;
						int.TryParse(commandSplitted[1], out productID);
						int.TryParse(commandSplitted[2], out quantity);

                        if (quantity > 0)
                            Receipt(username, productID, quantity);
                        else
                            _ui.DisplayGeneralError();					
                    }
					else
						_ui.DisplayTooManyArgumentsError();
				}
			}
        }

        // Display for userinfo
        public void UserInfo(string username)
        {
            User user = _stregsystem.GetUserByUsername(username);
            ConsoleUserInfo01 userInfo = new ConsoleUserInfo01(user);
            userInfo.Print();
            Console.ReadLine();
            ConsoleUserInfo02 userinfo2 = new ConsoleUserInfo02(user, _stregsystem);
            userinfo2.Print();
        }
	}
}