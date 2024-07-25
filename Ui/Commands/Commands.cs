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
				new CommandLongDistanceSensor(),
				new CommandImpulseDrive(),
				new CommandHyperDrive(),
				new CommandMove(),
				new CommandDock(),

				new CommandQuitGame()
			];
		}

		public Command? GetByKeyInMenu(ConsoleKey key)
		{
			return CommandList.FirstOrDefault(c => c.Key == key);
      }

		public List<Command> CommandList { get; set; }
	}
}