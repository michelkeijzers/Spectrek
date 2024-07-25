using System.ComponentModel.Design;

namespace AsciiGames
{
	public class UserCommandSelector()
	{
		public Command.EId Select()
		{
			Command command;
			command = SelectCommand();
			return command.Id;
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

				command = _commands.GetByKeyInMenu(input.Key);
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
				Console.Write($"{command.KeyString}: {command.Text}    ");
			}
			Console.WriteLine();
		}

		public Command.EId SelectedCommand { get; set; } = Command.EId.None;

		private readonly Commands _commands = new();
	}
}