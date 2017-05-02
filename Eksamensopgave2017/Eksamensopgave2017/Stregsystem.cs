using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Eksamensopgave2017
{
	class Stregsystem : IStregsystem
	{
		public List<Product> ListOfProducts = new List<Product>();
		public List<User> ListOfUsers = new List<User>();
		public List<Transaction> TransactionList = new List<Transaction>();

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

		public InsertCashTransaction AddCreditsToAccount(User user, int amount)
		{
			decimal newAmount = decimal.Parse((string)amount.ToString());
			return new InsertCashTransaction(user, DateTime.Now, newAmount);
		}

		public BuyTransaction BuyProduct(User user, Product product)
		{
			try
			{
				BuyTransaction buytransaction = new BuyTransaction(user, DateTime.Now, product);
				WritingFiles writingFiles = new WritingFiles();

				writingFiles.WritingUsersFile(buytransaction);

				return buytransaction; //return 
			}
			catch (InsufficientCreditsException e)
			{
				Console.WriteLine(e.Message);
			}
			return null; //If "try" fails, return null
		}

		public Product GetProductByID(int productID)
		{
            return ListOfProducts.First(product => (product.ID == productID));
		}

        public User GetUserByID(int userID)
		{
            return ListOfUsers.First(user => (user.ID == userID));
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
			if (ListOfUsers != null)
			{
				foreach (User user in ListOfUsers)
					if (user.Username == username)
						return user;
					else
						throw new UserDoesNotExistException($"A user with the username: {username} does not exist");
			}
			throw new EmptyListException("List of users is empty");
		}
	}
}