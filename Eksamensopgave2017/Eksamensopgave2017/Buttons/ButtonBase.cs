using System;
using System.Collections.Generic;
using Stregsystem;

namespace Eksamensopgave2017
{
    public class ButtonBase
    {
        private const ConsoleColor inactiveColor = ConsoleColor.Black;
        private const ConsoleColor activeColor = ConsoleColor.Gray;
        private List<Button> _buttonList = new List<Button>();
        private int _SelectIndex = 0;
        private bool _running;

        public ButtonBase(BuyTransaction transaction, string name, params Button[] buttons)
        {
            this.Transaction = transaction;
            this.Name = name;
            foreach (Button button in buttons)
                this._buttonList.Add(button);
        }

        public BuyTransaction Transaction { get; set; }

        public string Name { get; set; }

        private void MakeMenu()
        {
			string write = "Previous";
			Console.SetCursorPosition(Console.WindowWidth / 2 - write.Length, Console.CursorTop);
			Console.Write(write);

			string write1 = "Next";
			Console.SetCursorPosition(Console.WindowWidth / 2 + write1.Length, Console.CursorTop);
			Console.Write(write1);

            for (int i = 0; i < _buttonList.Count; i++)
            {
                ConsoleColor color = _SelectIndex == i ? activeColor : inactiveColor;
            }
        }

        public void AddButtons(params Button[] buttons)
        {
            foreach (Button button in buttons)
            {
                _buttonList.Add(button);
            }
        }

        public void Start()
        {
            _running = true;
            do
            {
                MakeMenu();
                Arrow();
            } while (_running);
        }

		private void Arrow()
		{
			ConsoleKeyInfo arrow = Console.ReadKey();
            switch (arrow.Key)
			{
                case ConsoleKey.LeftArrow:
					MoveLeft();
					break;
                case ConsoleKey.RightArrow:
					MoveRight();
					break;
				case ConsoleKey.Enter:
					CurrentButton.Select();
					break;
				default:
					break;
			}
		}

        public Button CurrentButton => _buttonList[_SelectIndex];

        private void MoveLeft()
        {
            _SelectIndex = (_SelectIndex + 1) % _buttonList.Count;
        }

        private void MoveRight()
        {
            _SelectIndex = (_SelectIndex - 1 + _buttonList.Count) % _buttonList.Count;
        }
    }
}
