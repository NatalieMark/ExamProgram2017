using System;
using System.Collections.Generic;

namespace Eksamensopgave2017
{
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
            else
                throw new InsufficientCreditsException($"{User.Username} does not have money enough for the attempted purchase\n" +
                                                       $"Tried to buy: {Product.Name} (ID {Product.ID}) which costs {Product.Price},-\n" +
                                                       $"Current balance: {User.Balance}");
        }
    }
}