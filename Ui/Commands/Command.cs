namespace AsciiGames
{
	public class Command(
		Command.EId id, Command.EMenu menu, ConsoleKey key, string keyString, string text, Command.EMenu toMenu = Command.EMenu.None)
	{
		public enum EId
		{
			None,

			// Main Menu
			MainMenu,
			ImpulseDrive,
			HyperDrive,
			Move,
			LongDistanceSensorSweep,
			StayInMainMenu,
			ElapseTime,
			QuitGame

			//  Market Menu
			//ReturnFromMarketMenu,
		};

		public enum EMenu
		{
			None,
			Main,
			//MilkyWay,
		};

		public static string GetMenuName(EMenu menu)
		{
			string name = String.Empty;
			switch (menu)
			{
				case EMenu.Main: name = "Main Menu "; break;
				//case EMenu.MilkyWay: name = "Milky Way Menu "; break;
				default: Console.WriteLine($"ERROR: INVALID menu {menu}"); break;
			}
			return name;
		}

		public EId Id { get; set; } = id;

		public EMenu Menu { get; set; } = menu;

		public ConsoleKey Key { get; set; } = key;

		public string KeyString { get; set; } = keyString;

		public string Text { get; set; } = text;

		public EMenu ToMenu { get; set; } = toMenu;

	}
}