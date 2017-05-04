using System;
using System.Linq;
using Stregsystem;

// NOT ENOUGH MONEY
namespace Eksamensopgave2017
{
	class StregsystemController
	{
		private IStregsystemUI _ui;
		private IStregsystem _stregsystem;

		public StregsystemController(IStregsystemUI ui, IStregsystem stregsystem)
		{
			this._ui = ui;
			this._stregsystem = stregsystem;
            ui.CommandEntered += HandleInput;
		}


        public void HandleInput(string command)
        {
            string[] commandSplitted = null;
            User user = _stregsystem.GetUserByUsername(command); 

            if (command != null)
            {
				commandSplitted = command.Split(' ');

				if (commandSplitted.Length == 1)
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
                else if (commandSplitted.Length == 2)
                {
                    //Quickbuy
                    string username = commandSplitted[0];
					int productID;
                    int.TryParse(commandSplitted[1], out productID);
					Receipt(username, productID, 1);               
                }
                else
                    _ui.DisplayTooManyArgumentsError();
            }
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
                        BuyTransaction purchase = _stregsystem.BuyProduct(user, product);
                        ConsoleReceipt receipt = new ConsoleReceipt(purchase, quantity, false);
						receipt.Print();
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
							MultiBuyProducts02();
					}
					else if (commandSplitted.Length == 3)
                    {
                        _running = false;
						string username = commandSplitted[0];
                        int productID, quantity;
						int.TryParse(commandSplitted[1], out productID);
                        int.TryParse(commandSplitted[2], out quantity);

                        Receipt(username, productID, quantity);
                    }
					else
						_ui.DisplayTooManyArgumentsError();
                }
            }
        }

        public void MultiBuyProducts02()
        {
			bool _running = true;
			ConsoleMultipleBuy02 multibuyPage02 = new ConsoleMultipleBuy02();

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
							MultiBuyProducts01();
					}
					else if (commandSplitted.Length == 3)
					{
						_running = false;
						string username = commandSplitted[0];
						int productID, quantity;
						int.TryParse(commandSplitted[1], out productID);
						int.TryParse(commandSplitted[2], out quantity);

						Receipt(username, productID, quantity);
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
		/*public bool CheckIfUsernameExist(string username)
		{
			foreach (User user in ListOfUsers)
			{
				if (user.Username == username)
					return true;
			}
			return false;
		}
*/
	}
}


/*
if (string.Compare(command, "user") == 0)
                {
                    _ui.DisplayUserInfo(user);
                }
                */
