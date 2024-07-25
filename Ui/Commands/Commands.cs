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
				new(Command.EId.ImpulseDrive, ConsoleKey.I, "I", "Impulse Drive"),
				new(Command.EId.HyperDrive, ConsoleKey.H, "H", "Impulse Drive"),
				new(Command.EId.LongDistanceSensorSweep, ConsoleKey.L, "L", "Long Distance Sensor Sweep"),
				new(Command.EId.Move, ConsoleKey.M, "M", "Move"),

				new(Command.EId.QuitGame, ConsoleKey.Q, "Q", "Quit Game"),
			];
		}

		public Command? GetByKeyInMenu(ConsoleKey key)
		{
			return CommandList.FirstOrDefault(c => c.Key == key);
      }

		public Command GetById(EId id)
		{
			Command? command = CommandList.FirstOrDefault(c => c.Id == id);
			return command ?? throw new ApplicationException("Command ID not found");
		}

		public List<Command> CommandList { get; set; }
	}
}