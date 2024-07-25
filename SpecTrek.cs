namespace AsciiGames
{
	public class SpecTrek
	{
		public static SpecTrek Instance { get { return _instance ??= new SpecTrek(); } }

		private SpecTrek()
		{
			StarDate = new();
			MilkyWay = new();
			Federation = new();
			KlingonShips = new();

			_userCommandSelector = new();
			_userCommandExecuter = new();
			_display = new(this);
		}

		public void Init()
		{
			//_milkyWay.Init();
			Federation.Init();
			KlingonShips.Init();
			StarDate.Init();
		}

		public void Play()
		{
			Console.WriteLine("Start");
			MilkyWay.Print();

			while (!CheckEndOfGame())
			{
				_display.Print();
				Command.EId command = _userCommandSelector.Select();
				_userCommandExecuter.Execute(command);
			}

			EndGame();
		}

		public void ElapseTime()
		{
			StarDate.ElapseTime();
		}

		private bool CheckEndOfGame()
		{
			bool endGame = false;
			if (_userCommandExecuter.IsQuitCommandIssued)
			{
				ConsolePlus.WriteLineWithColor(System.ConsoleColor.Yellow, "Game has ended because you quit. Thanks for playing.");
				endGame = true;
			}
			else if (!Federation.Enterprise.IsWithinMilkyWay)
			{
				ConsolePlus.WriteLineWithColor(System.ConsoleColor.Yellow, "Game has ended because the enterprise is lost in space.");

				endGame = true;
			}
			return endGame;
		}

		private static void EndGame()
		{
			Console.WriteLine("========================================================");
		}

		public MilkyWay MilkyWay { get; private set; }

		public Federation Federation { get; private set; }
		public KlingonShipCollection KlingonShips { get; private set; }

		public StarDate StarDate { get; private set; }	
				
		private readonly UserCommandSelector _userCommandSelector;
		private readonly UserCommandExecuter _userCommandExecuter;

		private readonly Display _display;

		private static SpecTrek? _instance;
	}
}