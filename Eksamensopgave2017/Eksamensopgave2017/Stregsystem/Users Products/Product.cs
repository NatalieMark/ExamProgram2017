﻿using System;
using System.Text.RegularExpressions;

namespace Stregsystem
{
    /// <summary>
    /// Product has an ID, a name, price, an active flag, 
    /// and can or can not be bought on credit.
    /// Some properties have some validations, and may throw exceptions.
    /// </summary>
	public class Product
	{
		private int _iD;
		private string _name = null;
		private decimal _price;
		private bool _active;
		private bool _canBeBoughtOnCredit = false;

        public Product(int iD, string name, decimal price, bool active)
		{
			this.ID = iD;
			this.Name = name;
			this.Price = price;
			this.Active = active;
		}

		public int ID
		{
			get { return _iD; }
			set
			{
				if (value > 0)
					_iD = value;
				else
					throw new InvalidValueException("ID must be larger than 0");
			}
		}

		public string Name
		{
			get
			{
				if (_name != null)
					return _name;
				else
					throw new ArgumentNullException("Product name can't be empty");
			}
			set
			{
				if (value != null) 
					_name = value;
				else
					throw new ArgumentNullException("Product name can't be empty");
			}
		}

        public decimal Price
		{
			get { return _price; }
			set
			{
				if (value >= 0)
					_price = value;
				else
					throw new InvalidValueException("Price must be larger than or equal to 0");
			}
		}

		public bool Active
		{
			get { return _active; }
			set { _active = value; }
		}

		public bool CanBeBoughtOnCredit
		{
			get { return _canBeBoughtOnCredit; }
			set { _canBeBoughtOnCredit = value; }
		}

		public override string ToString()
		{
			return string.Format($"{Name} {Price},- [ID {ID}]");
		}
	}
}
