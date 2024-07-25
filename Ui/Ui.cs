namespace AsciiGames
{
	public class Ui
	{
		public Ui()
		{
			Commands commands = new();
			_userCommandSelector = new(commands);
		}

		public void Play()
		{
			Console.WriteLine("SPECTREK 0.1");

			SpecTrek specTrek = SpecTrek.Instance;
			specTrek.Init();

			Console.WriteLine("Start");
			PrintMilkyWay();

			while (!CheckEndOfGame())
			{
				Display.Print();
				Command command = _userCommandSelector.Select();
				command.Execute();
			}
			EndGame();
		}

		private static bool CheckEndOfGame()
		{
			bool endGame;
			if (UserCommandSelector.IsQuitCommandIssued)
			{
				ConsolePlus.WriteLineWithColor(System.ConsoleColor.Yellow, "Game has ended because you quit. Thanks for playing.");
				endGame = true;
			}
			else
			{
				SpecTrek.EEndOfGameStatus status = SpecTrek.Instance.CheckEndOfGame();
				switch (status)
				{
					case SpecTrek.EEndOfGameStatus.None:
						endGame = false;
						break;

					case SpecTrek.EEndOfGameStatus.ExitedMilkyWay:
						ConsolePlus.WriteLineWithColor(System.ConsoleColor.Yellow, 
							"Game has ended because the enterprise is lost in space.");
						endGame = true;
						break;
					
					case SpecTrek.EEndOfGameStatus.EnergyDepleted:
						ConsolePlus.WriteLineWithColor(System.ConsoleColor.Yellow, 
							"The energy of the Enterprise has depleted, it is wandering in space forever.");
						endGame = true;
						break;

					case SpecTrek.EEndOfGameStatus.NoTimeLeft:
						ConsolePlus.WriteLineWithColor(System.ConsoleColor.Yellow,
							"There is no time left for furter exploration.");
						endGame = true;
						break;

					default:
						throw new ApplicationException("Invalid case");
				}
			}
			return endGame;
		}

		private static void PrintMilkyWay()
		{
			for (int vertical = 0; vertical < MilkyWay.VERTICAL_QUADRANTS; vertical++)
			{
				for (int horizontal = 0; horizontal < MilkyWay.HORIZONTAL_QUADRANTS; horizontal++)
				{
					Console.Write($"{SpecTrek.Instance.MilkyWay.GetQuadrant(horizontal, vertical).Name}".PadRight(15));
				}
				Console.WriteLine();
			}
		}

		private static void EndGame()
		{
			Console.WriteLine("========================================================");
		}

		private readonly UserCommandSelector _userCommandSelector;
	}
}
