using System;
using System.Collections.Generic;

namespace Eksamensopgave2017
{
	public abstract class Transaction
	{
		private static int _iD = 1; //Starting with 1 and counts up 1 for every transaction
		private User _user;
		private DateTime _date = DateTime.Now;

		public Transaction(User user, DateTime date)
		{
			this.User = user;
			this.Date = date;
			this.ID = _iD++;
		}

		public int ID { get; }

		public User User
		{
			get { return _user; }
			set { _user = value; }
		}

		public DateTime Date
		{
			get { return _date; }
			set { _date = value; }
		}

		public override string ToString()
		{
			return string.Format($"{User}\n" +
								 $"[Transaction ID {ID}] ({Date})\n");
		}

		public abstract void Execute();
	}
}