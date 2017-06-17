using System;
using System.Collections.Generic;

namespace Stregsystem
{
	/// <summary>
	/// Buytransaction inherits from Transactions.
	/// Buytransaction has the same parameters as Transaction and a product.
    /// A user buys a product if they have enough money 
    /// or the product can be bought on credit.
	/// </summary>
	public class BuyTransaction : Transaction
    {
        private Product _product;

        public BuyTransaction(User user, DateTime date, Product product) : base(user, date)
        {
            this.Product = product;
        }

        public Product Product
        {
            get { return _product; }
            set { _product = value; }
        }

        public override string ToString()
        {
            return string.Format($"[Transaction ID {ID}]\n" +
                                 $" {Date}\n" +
                                 $" {User}\n" +
                                 $" Bought: {Product}\n");
        }

        public override void Execute()
        {
            if (User.Balance >= Product.Price || Product.CanBeBoughtOnCredit)
                User.Balance -= Product.Price;
        }
    }
}