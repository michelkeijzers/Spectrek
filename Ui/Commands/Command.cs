namespace AsciiGames
{
	public abstract class Command
	{
		protected static readonly int INVALID_NUMBER = -999;

		//Command.EId id, ConsoleKey key, string keyString, string text)
		//{
		/*
			public enum EId
			{
				LongDistanceSensorSweep,
				ImpulseDrive,
				HyperDrive,
				Move,
				Dock,
				QuitGame
			};
		*/

		public abstract ConsoleKey Key { get; }

		public abstract string KeyString { get; }

		public abstract string Text { get; }

		public abstract bool CanExecute();

		public abstract void Execute();
		
		protected static int InputInteger(string text, int min, int max)
		{
			bool changed = false;
			int outputValue = INVALID_NUMBER;
			Console.Write($"Enter {text} ({min}..{max}): ");
			string? input = Console.ReadLine();
			if (input is not null)
			{
				if (int.TryParse(input, out int value))
				{
					if ((value >= min) && (value <= max))
					{
						outputValue = value;
						changed = true;
					}
				}
			}

			if (!changed)
			{
				Console.WriteLine("Invalid input/range.");
			}
			return outputValue;
		}

	}
}