namespace Stregsystem
{
	public interface IStregsystemUI
	{
        void PrintDisplay();
		void DisplayUserNotFound(string username);
		void DisplayProductNotFound();
        void DisplayProductNotActive(string product);
		void DisplayTooManyArgumentsError();
		void DisplayAdminCommandNotFoundMessage(string adminCommand);
		void DisplayInsufficientCash(User user, Product product);
		void DisplayGeneralError();
		void Start();
		void Close();
		event StregsystemEvent CommandEntered;
	}
}