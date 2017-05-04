using System;
using System.Collections.Generic;

namespace Stregsystem
{
	public interface IStregsystem
	{
		void GetAllProducts();
		void GetAllUsers();
		void ExecuteTransaction(Transaction transaction);
		IEnumerable<Product> ActiveProducts { get; }
		InsertCashTransaction AddCreditsToAccount(User user, decimal amount);
		BuyTransaction BuyProduct(User user, Product product);
		Product GetProductByID(int productID);
		IEnumerable<Transaction> GetTransactions(User user, int count);
		User GetUser(Func<User, bool> predicate);
		User GetUserByUsername(string username);
		//event UserBalanceNotification UserBalanceWarning;
	}
}