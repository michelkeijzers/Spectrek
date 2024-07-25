using System.ComponentModel.Design;

namespace AsciiGames
{
	public class UserCommandSelector(Commands commands)
	{
		public Command Select()
		{
			Command command = SelectCommand();
			return command;
		}

		private Command SelectCommand()
		{
			PrintCommands();
			Console.Write("Select command: ");
			Command? command;
			do
			{
				ConsoleKeyInfo input = Console.ReadKey();
				Console.WriteLine("");

				command = _commands.CommandList.FirstOrDefault(com => (com.Key == input.Key) && com.CanExecute());
				if (command == null)
				{
					Console.WriteLine("Invalid command");
					PrintCommands();
				}
			} while (command == null);
			return command;
		}


		public void PrintCommands()
		{
			Console.Write("Commands: ");
			foreach (Command command in _commands.CommandList)
			{
				if (command.CanExecute())
				{
					Console.Write($"{command.KeyString}: {command.Text}    ");
				}
			}
			Console.WriteLine();
		}

		private readonly Commands _commands = commands;

		public static bool IsQuitCommandIssued { get; set; }
	}
}