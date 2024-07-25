namespace AsciiGames
{
	public class Command(
		Command.EId id, ConsoleKey key, string keyString, string text)
	{
		public enum EId
		{
			None,
			ImpulseDrive,
			HyperDrive,
			Move,
			LongDistanceSensorSweep,
			QuitGame
		};

		public EId Id { get; set; } = id;

		public ConsoleKey Key { get; set; } = key;

		public string KeyString { get; set; } = keyString;

		public string Text { get; set; } = text;
	}
}