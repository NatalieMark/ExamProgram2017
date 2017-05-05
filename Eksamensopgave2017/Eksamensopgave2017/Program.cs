//20152853_Natalie_Mark

using Stregsystem;

namespace Eksamensopgave2017
{
    /// <summary>
    /// The program where everything begins!
    /// </summary>
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