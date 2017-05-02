using System;

namespace Eksamensopgave2017
{
	class StregsystemController
	{
		private IStregsystemUI _ui;
		private IStregsystem _stregsystem;

		public StregsystemController(IStregsystemUI ui, IStregsystem stregsystem)
		{
			this._ui = ui;
			this._stregsystem = stregsystem;
			ui.CommandEntered += Blabla;
		}
		User a = new User(3, "Natalie", "Mark", "natamark", "nata@mail.com", 23900);


		public void Blabla(string command)
		{
			if (command != null)
			{
				if (string.Compare(command, "user") == 0)
				{
					_ui.DisplayUserInfo(a);
				}
			}
		}
	}
}