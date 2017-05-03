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

        User userA;

        Stregsystem stregsystem = new Stregsystem();

        public void getUser()
        {
            userA = stregsystem.GetUserByID(4);
        }

		public void Blabla(string command)
		{
            getUser();

			if (command != null)
			{
				if (string.Compare(command, "user") == 0)
				{
                    _ui.DisplayUserInfo(userA);
				}
			}
		}
	}
}