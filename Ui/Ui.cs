namespace AsciiGames
{
	public class Ui
	{
		public Ui()
		{
			_userCommandSelector = new();
			_userCommandExecuter = new();

			_display = new();
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
				_display.Print();
				Command.EId command = _userCommandSelector.Select();
				_userCommandExecuter.Execute(command);
			}
			EndGame();
		}

		private bool CheckEndOfGame()
		{
			bool endGame;
			if (_userCommandExecuter.IsQuitCommandIssued)
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
						ConsolePlus.WriteLineWithColor(System.ConsoleColor.Yellow, "Game has ended because the enterprise is lost in space.");
						endGame = true;
						break;

					default:
						throw new ApplicationException("Invalid case");
				}
			}
			return endGame;
		}

		private void PrintMilkyWay()
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
		private readonly UserCommandExecuter _userCommandExecuter;
		private readonly Display _display;
	}
}
