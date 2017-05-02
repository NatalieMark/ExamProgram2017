//20152853_Natalie_Mark

using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;


namespace Eksamensopgave2017
{
	class Program
	{
		static void Main(string[] args)
		{
			IStregsystem stregsystem = new Stregsystem();
			IStregsystemUI ui = new StregsystemCLI(stregsystem);
			StregsystemController sc = new StregsystemController(ui, stregsystem);
            stregsystem.GetUserByID(2);
            ui.Start();
		}
	}
}
/*
            User a = new User(3, "Natalie", "Mark", "natamark", "nata@mail.com", 23900);
            User b = new User(1, "Hadil", "Kaddourah", "hadillo", "hadillo@mail.com", 2378);
            User a1 = new User(3, "Natalie", "Mark", "natamark", "nata@mail.com", 23900);
            User b1 = new User(1, "Hadil", "Kaddourah", "hadillo", "hadillo@mail.com", 2378);
            
            Product c = new Product(3, "IS", 1800, true);
            Product c1 = new Product(4, "Kaffe", 1000, true);
            Product c2 = new Product(5, "BenogJerry", 6000, true);
            
            Stregsystem d = new Stregsystem();
            Transaction t_IS = new BuyTransaction(a, DateTime.Now, c);
            BuyTransaction b_IS = new BuyTransaction(a, DateTime.Now, c);
            BuyTransaction b_Kaffe = new BuyTransaction(a, DateTime.Now, c1);
            InsertCashTransaction i_money = new InsertCashTransaction(a, DateTime.Now, 1200);
            InsertCashTransaction i_moneyz = new InsertCashTransaction(b, DateTime.Now, 1200);
            BuyTransaction b_ISz = new BuyTransaction(b, DateTime.Now, c);
            BuyTransaction b_Kaffez = new BuyTransaction(b, DateTime.Now, c1);
            
            WritingFiles w = new WritingFiles();
            w.Header();
            w.WritingUsersFile(t_IS);
            w.WritingUsersFile(b_IS);
            w.WritingUsersFile(b_Kaffe);
            w.WritingUsersFile(i_money);
            w.WritingUsersFile(i_moneyz);
            w.WritingUsersFile(b_ISz);
            w.WritingUsersFile(b_Kaffez);
            
            ReadingFiles rf = new ReadingFiles();
            rf.ReadProductsFile();
    */
