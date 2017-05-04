﻿//20152853_Natalie_Mark

using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using Stregsystem;

namespace Eksamensopgave2017
{
	class Program
	{
		static void Main(string[] args)
		{
			IStregsystem stregsystem = new Stregsystem();
			IStregsystemUI ui = new StregsystemCLI(stregsystem);
			StregsystemController sc = new StregsystemController(ui, stregsystem);
            ui.Start();
		}
	}
}