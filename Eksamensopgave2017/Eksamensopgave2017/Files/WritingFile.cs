using System;
using System.Collections.Generic;
using System.IO;

namespace Eksamensopgave2017
{
	public class WritingFiles
	{
		public void Header()
		{
			StreamWriter file = new StreamWriter("logFile.csv"); //",true" to not delete file

			using (file)
			{
				file.WriteLine($"ID;Date;User;Transaction Type;Product ID;Product Name;Product Price;Deposit;Current Balance");
			}
		}

		public void WritingUsersFile(Transaction transaction)
		{
			StreamWriter file = new StreamWriter("logFile.csv", true);

			using (file)
			{
				bool isBuyTransaction = transaction is BuyTransaction;
				string iD = transaction.ID.ToString();
				string date = transaction.Date.ToString();
				string user = transaction.User.ToString();
				string transactionType = isBuyTransaction == true ? "Purchase" : "Deposit";
				string productID = isBuyTransaction == true ? ((BuyTransaction)transaction).Product.ID.ToString() : "";
				string productName = isBuyTransaction == true ? ((BuyTransaction)transaction).Product.Name : "";
				string productPrice = isBuyTransaction == true ? ((BuyTransaction)transaction).Product.Price.ToString() : "";
				string deposit = isBuyTransaction == true ? "" : ((InsertCashTransaction)transaction).Deposit.ToString();
				string currentBalance = transaction.User.Balance.ToString();

				file.WriteLine($"{iD};{date};{user};{transactionType};{productID};{productName};{productPrice};{deposit};{currentBalance}");
			}
		}
	}
}
