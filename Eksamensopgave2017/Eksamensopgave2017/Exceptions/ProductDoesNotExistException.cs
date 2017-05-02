using System;
namespace Eksamensopgave2017
{
	public class ProductDoesNotExistException : Exception
	{
		public ProductDoesNotExistException() { }

		public ProductDoesNotExistException(string message) : base(message) { }

		public ProductDoesNotExistException(string message, Exception inner) : base(message, inner) { }
	}
}