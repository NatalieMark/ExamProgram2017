using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Stregsystem;

namespace Eksamensopgave2017
{
	/// <summary>
    /// Stregsystem inherits from IStregsystem (its Interface).
    /// It consists of methods that does what the program needs to be doing.
    /// (individual methods that are all needed for the program to be working)
	/// </summary>
	class Stregsystem : IStregsystem
	{
        //What is made here, can be reached from all the methods in this class (Stregsystem).
		private List<Product> _listOfProducts = new List<Product>();
        private List<User> _listOfUsers = new List<User>();
        private List<Transaction> _transactionList = new List<Transaction>();
        private WritingFiles _writingfiles = new WritingFiles();

        public Stregsystem()
        {
            //Calls these methods from start
			GetAllUsers();
            GetAllProducts();          
		}

        // Making a product (and puts them into a list) from every line in the file products.csv
        public void GetAllProducts()
		{
			ReadingFiles productsFile = new ReadingFiles();
			List<string[]> products = productsFile.ReadProductsFile();

			foreach (string[] productLine in products)
			{
				int intTemp;
				int iD;
				bool active;

				if (int.TryParse(productLine[0], out intTemp))
					iD = intTemp;
				else
					throw new ParseFailedException("Could not parse string to int");

				string name = productsFile.RemoveHTMLCode(productLine[1]).Trim();

				// Dividing with 100 because the input was not in whole KR, but in ØRE
				decimal price = (decimal.Parse(productLine[2], NumberStyles.Any, CultureInfo.InvariantCulture) / 100); 

				if (productLine[3] == "1")
					active = true;
				else
					active = false;

                // Making the list of products
				_listOfProducts.Add(new Product(iD, name, price, active));
			}
		}

		// Making a product (and puts them into a list) from every line in the file products.csv
		public void GetAllUsers()
		{
			ReadingFiles usersFile = new ReadingFiles();
			List<string[]> users = usersFile.ReadingUsersFile();

			foreach (string[] userLine in users)
			{
				int intTemp;
				int iD;
				decimal balance;

				if (int.TryParse(userLine[0], out intTemp))
					iD = intTemp;
				else
					throw new ParseFailedException("Could not parse string to int");

                string firstname = userLine[1].Replace("\"", "");
				string lastname = userLine[2].Replace("\"", "");
				string username = userLine[3].Replace("\"", "");
				string email = userLine[4].Replace("\"", "");

                balance = decimal.Parse(userLine[5], NumberStyles.Any, CultureInfo.InvariantCulture);

				// Making the list of products
				_listOfUsers.Add(new User(iD, firstname, lastname, username, email, balance));
			}
		}

        // Executing the transaction, no matter whether it is Buytransaction og InsertCashTransaction.
		public void ExecuteTransaction(Transaction transaction)
		{
			transaction.Execute();
			_transactionList.Add(transaction);
		}

        // Creating a list with only active products
		public IEnumerable<Product> ActiveProducts
		{
			get { return _listOfProducts.Where((Product product) => product.Active); }
		}

		// Inserting cash to a users account
		public InsertCashTransaction AddCreditsToAccount(User user, decimal amount)
		{
			InsertCashTransaction insertCashTransaction = new InsertCashTransaction(user, DateTime.Now, amount);
			ExecuteTransaction(insertCashTransaction);
			_writingfiles.WritingUsersFile(insertCashTransaction);
            user.NumberOfTransactions++;
            return insertCashTransaction;
		}

        // A user buying a product (a transaction is made)
		public BuyTransaction BuyProduct(User user, Product product)
        {
            BuyTransaction buytransaction = new BuyTransaction(user, DateTime.Now, product);
            ExecuteTransaction(buytransaction);
            _writingfiles.WritingUsersFile(buytransaction);
            user.NumberOfTransactions++;

            return buytransaction;
		}

        // Get a product by giving an ID, or return null
		public Product GetProductByID(int productID)
		{
            try
            {
            	return _listOfProducts.First(product => (product.ID == productID));
            }
            catch(Exception)
            {
				return null;
            }
		}

        // Getting a list of a users transaction up to <count> times 
		public IEnumerable<Transaction> GetTransactions(User user, int count)
		{
            return _transactionList.Where((Transaction transaction) => (transaction.User.ID == user.ID)).Reverse().Take(count);
		}

        // Finding a user with <username> as username, or return null
        public User GetUserByUsername(string username)
        {
			foreach (User user in _listOfUsers)
			{
                if (user.Username == username)
					return user;
			}
            return null;
        }

		public event UserBalanceNotification UserBalanceWarning;

        protected virtual void OnUserBalanceWarning(User user)
        {
            UserBalanceWarning?.Invoke(user, user.Balance);
        }
	}
}