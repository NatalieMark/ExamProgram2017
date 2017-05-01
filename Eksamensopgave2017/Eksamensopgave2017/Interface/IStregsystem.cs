using System;
using System.Collections.Generic;

namespace Eksamensopgave2017
{
	public interface IStregsystem
	{
		void GetAllProducts();
		void GetAllUsers();
		void AddToTransactionList(Transaction instance);
		void ExecuteTransaction(Transaction transaction);
		IEnumerable<Product> ActiveProducts { get; }
		InsertCashTransaction AddCreditsToAccount(User user, int amount);
		BuyTransaction BuyProduct(User user, Product product);
		Product GetProductByID(int productID);
		IEnumerable<Transaction> GetTransactions(User user, int count);
		User GetUser(Func<User, bool> predicate);
		User GetUserByUsername(string username);
		//event UserBalanceNotification UserBalanceWarning;
	}
}