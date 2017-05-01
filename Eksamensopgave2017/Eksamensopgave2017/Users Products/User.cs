using System;
using System.Text.RegularExpressions;

namespace Eksamensopgave2017
{
	public class User : IComparable<User>
	{
		private int _iD;
		private string _firstname = null;
		private string _lastname = null;
		private string _username = null;
		private string _email = null;
		private decimal _balance;
		private int _numberOfTransactions = 0;

		public User(int iD, string firstname, string lastname, string username, string email, decimal balance)
		{
			this.ID = iD;
			this.Firstname = firstname;
			this.Lastname = lastname;
			this.Username = username;
			this.Email = email;
			this.Balance = balance;
		}

		public int ID
		{
			get { return _iD; }
			set
			{
				if (value >= 0)
					_iD = value;
				else
					throw new InvalidValueException("ID must be larger than or equal to 0");
			}
		}

		public string Firstname
		{
			get
			{
				if (_firstname != null)
					return _firstname;
				else
					throw new ArgumentNullException("Firstname can't be empty");
			}
			set
			{
				if (value != null) //Not Null, but what about numbers?
					_firstname = value;
				else
					throw new ArgumentNullException("Firstname can't be empty");
			}
		}

		public string Lastname
		{
			get
			{
				if (_lastname != null)
					return _lastname;
				else
					throw new ArgumentNullException("Lastname can't be empty");
			}
			set
			{
				if (value != null) //Not Null, but what about numbers?
					_lastname = value;
				else
					throw new ArgumentNullException("Lastname can't be empty");
			}
		}

		public string Username
		{
			get
			{
				if (_username != null && _usernameValidator.IsMatch(_username) == true)
					return _username;
				else
				{
					throw new ArgumentNullException("Username can't be empty and only allowed to consist " +
													"of small letters, numbers and underscore");
				}
			}
			set
			{
				if (value != null && _usernameValidator.IsMatch(value) == true)
					_username = value;
				else
					throw new ArgumentNullException("Username can't be empty");
			}
		}

		public string Email
		{
			get
			{
				if (_email != null && EmailValidator(_email))
					return _email;
				else
					throw new ArgumentNullException("Email can't be empty and has specific rules " +
													"for what an email must and must not consist of");
			}
			set
			{
				if (value != null && EmailValidator(value))
					_email = value;
				else
					throw new ArgumentNullException("Email can't be empty and has specific rules " +
													"for what an email must and must not consist of");
			}
		}

		public decimal Balance
		{
			get { return _balance; }
			set { _balance = value; }
		}

		public int NumberOfTransactions
		{
			get { return _numberOfTransactions; }
			set
			{
				if (value >= 0)
					_numberOfTransactions = value;
				else
					throw new InvalidValueException("Number of transactions must be larger than or equal to 0");
			}
		}

		public void UserBalanceNotification(User user, decimal balance)
		{
			user.Balance = balance;

			if (user.Balance < 50)
				Console.WriteLine($"!!!WARNING!!!\n" +
								  "You have less than 50,- left!\n" +
								  $"Your current balance is: {Balance},- ");
		}

		public override string ToString()
		{
			return string.Format($"{Firstname} {Lastname} [{Username}] ({Email})");
		}

		public override int GetHashCode()
		{
			return this.ID.GetHashCode(); //Assuming ID is unique
		}

		public bool EmailValidator(string email)
		{
			string[] emailString = new string[2];

			if (email.Contains("@"))
				emailString = email.Split('@');
			else
				return false;

			if (_emailLocalpartValidator.IsMatch(emailString[0]) &&
				_emailDomainValidatorMayConsistOf.IsMatch(emailString[1]) &&
				!emailString[1].StartsWith(".") &&
				!emailString[1].StartsWith("-") &&
				emailString[1].Contains("."))
				return true;
			return false;
		}

		private static readonly Regex _emailLocalpartValidator = new Regex(@"^[a-zA-Z0-9_@\.\-]+$");
		private static readonly Regex _emailDomainValidatorMayConsistOf = new Regex(@"^[a-zA-Z0-9@\.\-]+$");
		private static readonly Regex _usernameValidator = new Regex(@"^[a-z0-9_]+$");

		public override bool Equals(object user)
		{
			return (this.ID.Equals(((User)user).ID)
				&& this.Firstname.Equals(((User)user).Firstname)
				&& this.Lastname.Equals(((User)user).Lastname)
				&& this.Username.Equals(((User)user).Username)
				&& this.Email.Equals(((User)user).Email)
				&& this.Balance.Equals(((User)user).Balance));
		}

		public int CompareTo(User other)
		{
			if (other != null)
				return ID.CompareTo(other);
			else
				return 1;
		}
	}
}