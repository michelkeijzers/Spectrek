using System.ComponentModel.Design;

namespace AsciiGames
{
	public class UserCommandSelector()
	{
		public Command.EId Select()
		{
			Command command;
			do
			{
				command = SelectCommand();
				if (command.ToMenu != Command.EMenu.None)
				{
					_menu = command.ToMenu;
				}
			} while (command.ToMenu != Command.EMenu.None);
			return command.Id;
		}


		private Command SelectCommand()
		{
			PrintCommands(_menu);
			Console.Write("Select command: ");
			Command? command;
			do
			{
				ConsoleKeyInfo input = Console.ReadKey();
				Console.WriteLine("");

				command = _commands.GetByKeyInMenu(input.Key, _menu);
				if (command == null)
				{
					Console.WriteLine("Invalid command");
					PrintCommands(_menu);
				}
			} while (command == null);
			// command = ProcessDetailCommand(command);
			return command;
		}

		/*
		//private Command ProcessDetailCommand(Command command)
		{ 
			if (command.Id == Command.EId.GoToTruckDetails)
			{
				_menu = command.ToMenu;
				if (_specTrek.SpecTrek == null)
				{
					command = _commands.GetById(Command.EId.SelectTruck);
				}
			}
	
			return command;
		}
		*/

		public void PrintCommands(Command.EMenu menu)
		{
			Console.WriteLine($"===============   {Command.GetMenuName(menu)}   ===============");
			//ProcessDetailText(menu);
			foreach (Command command in _commands.CommandList)
			{
				if (command.Menu == menu)
				{
					Console.Write($"{command.KeyString}: {command.Text}    ");
				}
			}
			Console.WriteLine();
		}

		/*
		private void ProcessDetailText(Command.EMenu menu)
		{
			if (menu == Command.EMenu.TruckDetails)
			{
				Console.WriteLine($"Selected Truck ID: {(_transportGame.SelectedTruck == null ? "-" : _transportGame.SelectedTruck.Id)}");
			}
		}
		*/

		private Command.EMenu _menu = Command.EMenu.Main;

		public Command.EId SelectedCommand { get; set; } = Command.EId.None;

		private readonly Commands _commands = new();
	}
}