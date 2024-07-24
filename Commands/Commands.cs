using static AsciiGames.Command;

namespace AsciiGames
{
	public class Commands
	{
		public Commands()
		{
			CommandList =
			[
				// Main menu
				new(Command.EId.ImpulseDrive, Command.EMenu.Main, ConsoleKey.I, "I", "Impulse Drive", Command.EMenu.None),
				new(Command.EId.HyperDrive, Command.EMenu.Main, ConsoleKey.H, "H", "Impulse Drive", Command.EMenu.None),
				new(Command.EId.LongDistanceSensorSweep, Command.EMenu.Main, ConsoleKey.L, "L", "Long Distance Sensor Sweep", Command.EMenu.None),
				new(Command.EId.Move, Command.EMenu.Main, ConsoleKey.M, "M", "Move", Command.EMenu.None),
				new(Command.EId.StayInMainMenu, Command.EMenu.Main, ConsoleKey.Enter, "Enter", "Main Menu", Command.EMenu.Main),

				new(Command.EId.QuitGame, Command.EMenu.Main, ConsoleKey.Q, "Q", "Quit Game"),
			];
		}

		public Command? GetByKeyInMenu(ConsoleKey key, EMenu menu)
		{
			return CommandList.FirstOrDefault(c => c.Key == key && c.Menu == menu);
      }

		public Command GetById(EId id)
		{
			Command? command = CommandList.FirstOrDefault(c => c.Id == id);
			return command ?? throw new ApplicationException("Command ID not found");
		}

		public List<Command> CommandList { get; set; }
	}
}