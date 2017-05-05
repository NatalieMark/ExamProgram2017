using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Stregsystem
{
	/// <summary>
    /// ReadinFiles reads the given files for "users" and "products".
	/// </summary>
	public class ReadingFiles
	{
        // This method returns a list of a stringarray
        // which contains every line of the file, splitted for every ';'
		public List<string[]> ReadingUsersFile()
		{
			StreamReader file = new StreamReader("users.csv");
			List<string[]> users = new List<string[]>();

			file.ReadLine(); //"Header" is read but not saved.

			string line;

			while ((line = file.ReadLine()) != null)
				users.Add(line.Split(';'));

			return users;
		}

		// This method also returns a list of a stringarray
		// which contains every line of the file, splitted for every ';'
		public List<string[]> ReadProductsFile()
		{
			StreamReader file = new StreamReader("products.csv");
			List<string[]> products = new List<string[]>();

			file.ReadLine(); //"Header" is read but not saved.

			string line;
			while ((line = file.ReadLine()) != null)
				products.Add(line.Replace("\"", "").Split(';'));

			return products;
		}

		// This method removes the HTML code in the product names.
		public string RemoveHTMLCode(string input)
		{
			int i = 0;
			int start = 0;
			int end;

			foreach (char c in input)
			{
				if (c == '<')
					start = i;

				if (c == '>')
				{
					end = i;
					if (end == input.Length)
						input = input.Remove(start - 1);
					else
						input = input.Remove(start, end - start + 1);
					i -= end - start;
				}
				else
					i++;
			}
			return input;
		}
	}
}
