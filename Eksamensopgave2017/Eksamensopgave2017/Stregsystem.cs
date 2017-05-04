using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Stregsystem;

namespace Eksamensopgave2017
{
	class Stregsystem : IStregsystem
	{
        //Lav private
		public List<Product> ListOfProducts = new List<Product>();
		public List<User> ListOfUsers = new List<User>();
		public List<Transaction> TransactionList = new List<Transaction>();
        private WritingFiles _writingfiles = new WritingFiles();

        public Stregsystem()
        {
			GetAllUsers();
            GetAllProducts();          
		}

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

                decimal price = (decimal.Parse(productLine[2], NumberStyles.Any, CultureInfo.InvariantCulture) / 100);

				if (productLine[3] == "1")
					active = true;
				else
					active = false;

				ListOfProducts.Add(new Product(iD, name, price, active));
			}
		}

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
             	
                ListOfUsers.Add(new User(iD, firstname, lastname, username, email, balance));
			}
		}

		public void AddToTransactionList(Transaction instance)
		{
			if (instance != null)
				TransactionList.Add(instance);
			else
				throw new ArgumentNullException("Missing transaction instance");
		}

		public void ExecuteTransaction(Transaction transaction)
		{
			transaction.Execute();
			TransactionList.Add(transaction);
		}

		public IEnumerable<Product> ActiveProducts
		{
			get { return ListOfProducts.Where((Product product) => product.Active); }
		}

		public InsertCashTransaction AddCreditsToAccount(User user, decimal amount)
		{
				InsertCashTransaction insertCashTransaction = new InsertCashTransaction(user, DateTime.Now, amount);
				ExecuteTransaction(insertCashTransaction);
				_writingfiles.WritingUsersFile(insertCashTransaction);

                return insertCashTransaction;
		}

		public BuyTransaction BuyProduct(User user, Product product)
        {
            BuyTransaction buytransaction = new BuyTransaction(user, DateTime.Now, product);
            ExecuteTransaction(buytransaction);
            _writingfiles.WritingUsersFile(buytransaction);

		    return buytransaction;
		}

		public Product GetProductByID(int productID)
		{
            try
            {
            	return ListOfProducts.First(product => (product.ID == productID));
            }
            catch(Exception)
            {
				return null;
            }
		}

		public IEnumerable<Transaction> GetTransactions(User user, int count)
		{
			return TransactionList.Where((Transaction transaction) => (transaction.User == user)).Take(count);
		}

		public User GetUser(Func<User, bool> predicate)
		{
			//Goes through the list, until it finds a match
			return ListOfUsers.FirstOrDefault(predicate);
		}

        public User GetUserByUsername(string username)
        {
			try
			{
				return ListOfUsers.First(user => string.Compare(user.Username, username) == 0);
			}
			catch (Exception)
			{
				return null;
			}
        }
	}
}