using System;

namespace Stregsystem
{
    /// <summary>
    /// Seasonalproducts inherits from Products
    /// Seasonalproducts has the same parameters as Products, 
    /// a start date and an end date.
    /// </summary>
	public class SeasonalProduct : Product
	{
		private DateTime _seasonStartDate;
		private DateTime _seasonEndDate;

		public SeasonalProduct(int iD, string name, int price, bool active, DateTime seasonStartDate, DateTime seasonEndDate) : base(iD, name, price, active)
		{
			this.SeasonStartDate = seasonStartDate;
			this.SeasonEndDate = seasonEndDate;
		}

		public DateTime SeasonStartDate
		{
			get { return _seasonStartDate; }
			set { _seasonStartDate = value; }
		}

		public DateTime SeasonEndDate
		{
			get { return _seasonEndDate; }
			set { _seasonEndDate = value; }
		}
	}
}
