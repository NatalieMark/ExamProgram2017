﻿using System;
using Stregsystem;
using System.Collections.Generic;

namespace Eksamensopgave2017
{
    /// <summary>
    /// StregsystemCLI implents IStregsystemUI.
    /// All the visual errors.
    /// </summary>
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
			ConsoleMenu menu = new ConsoleMenu();
            menu.Print();
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
			Console.BackgroundColor = ConsoleColor.Red;
			Console.ForegroundColor = ConsoleColor.White;
			string write = "                         !ERROR!                          ";
            string write1 = "                   Too many arguments!!                   ";
            Console.SetCursorPosition((Console.WindowWidth - write.Length) / 2, Console.CursorTop - 1);
			Console.WriteLine(write);
			Console.SetCursorPosition((Console.WindowWidth - write.Length) / 2, Console.CursorTop);
			Console.WriteLine(write1);
        }

        public void DisplayAdminCommandNotFoundMessage()
        {
			Console.BackgroundColor = ConsoleColor.Red;
			Console.ForegroundColor = ConsoleColor.White;
			string write = "                         !ERROR!                          ";
			string write1 = "           You did something wronge - Try again           ";
			Console.SetCursorPosition((Console.WindowWidth - write.Length) / 2, Console.CursorTop - 1);
			Console.WriteLine(write);
			Console.SetCursorPosition((Console.WindowWidth - write.Length) / 2, Console.CursorTop);
			Console.WriteLine(write1);
		}
       
        public void DisplayInsufficientCash(User user, Product product)
        {
            Console.WriteLine($"{user.Firstname} {user.Lastname} (ID {user.ID}) does not have money enough for the attempted purchase\n" +
                              $"Tried to buy: {product.Name} (ID {product.ID}) which costs {product.Price},-\n" +
                              $"Current balance: {user.Balance}");
        }

        public void DisplayGeneralError()
        {
			Console.BackgroundColor = ConsoleColor.Red;
			Console.ForegroundColor = ConsoleColor.White;
			string write = $"            Something went wrong  -  Try again            ";
			Console.SetCursorPosition((Console.WindowWidth - write.Length) / 2, Console.CursorTop - 1);
			Console.WriteLine(write);
        }

        // When program is started, the MenuDisplay is started
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

        // When close is calles, _running = false, and Start() will stop running, and the program stops.
        public void Close()
        {
            _running = false;
        }

        // An event used in Start()
        public event StregsystemEvent CommandEntered;
    }
}