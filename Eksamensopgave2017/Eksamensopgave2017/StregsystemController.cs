using System;
using System.Collections.Generic;
using System.Linq;
using Stregsystem;

// NOT ENOUGH MONEY
namespace Eksamensopgave2017
{
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

        public void HandleInput(string command)
        {
            string[] commandSplitted = null;
            User user = _stregsystem.GetUserByUsername(command); 

            if (command != null)
            {
                commandSplitted = command.Split(' ');

                if (command.StartsWith(":"))
                {
                    try
                    {
						AdminCommands[commandSplitted[0]](commandSplitted);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
                else
                {
                    if (commandSplitted.Length == 1)
                        commandParse01(command, user);
                    else if (commandSplitted.Length == 2)
                        commansParse02(commandSplitted);
                    else
                        _ui.DisplayTooManyArgumentsError();
                }
            }
		}

        public void commandParse01(string command, User user)
        {
			if (command == "multi")
				MultiBuyProducts01();
			else if (user != null)
			{
				if (command == user.Username)
					UserInfo(command);
			}
			else
				_ui.DisplayGeneralError();
        }

        public void commansParse02(string[] commandSplitted)
        {
			//Quickbuy
			string username = commandSplitted[0];
			int productID;
			int.TryParse(commandSplitted[1], out productID);
			Receipt(username, productID, 1);
        }

        public void Receipt(string username, int productID, int quantity)
        {
            User user;
            Product product;

            if (_stregsystem.GetUserByUsername(username) != null)
            {
                user = _stregsystem.GetUserByUsername(username);

                if (_stregsystem.GetProductByID(productID) != null)
                {
                    product = _stregsystem.GetProductByID(productID);

                    if (product.Active)
                    {
                        if (product.Price * quantity <= user.Balance || product.CanBeBoughtOnCredit)
                        {
                            BuyTransaction purchase = _stregsystem.BuyProduct(user, product);
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

        public void MultiBuyProducts01()
        {
            bool _running = true;
			ConsoleMultipleBuy01 multibuyPage01 = new ConsoleMultipleBuy01(_stregsystem);
			while(_running)
            {
				multibuyPage01.Print();
				string[] commandSplitted = null;
                string command = Console.ReadLine();

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

        public void MultiBuyProducts02()
        {
			bool _running = true;
            ConsoleMultipleBuy02 multibuyPage02 = new ConsoleMultipleBuy02(_stregsystem);

			while (_running)
			{
				multibuyPage02.Print();
				string[] commandSplitted = null;
				string command = Console.ReadLine();

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