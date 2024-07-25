using System.Numerics;

namespace AsciiGames
{
	public class UserCommandExecuter()
	{
		private static readonly int INVALID_NUMBER = -999;

		private static int InputInteger(string text, int min, int max)
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

		public void Execute(Command.EId command)
		{
			SpecTrek specTrek = SpecTrek.Instance!;

			switch (command)
			{
				case Command.EId.None:break;

				case Command.EId.ImpulseDrive:
					{
						int direction = InputInteger("Direction", 0, 359);
						if (direction != INVALID_NUMBER)
						{
							int power = InputInteger("Power", 0, 10);
							if (power != INVALID_NUMBER)
							{
								SpecTrek.Instance.Federation.Enterprise.Propulsions!.SetImpulseDrive(direction, power);
							}
						}
					}
					break;

				case Command.EId.HyperDrive:
					{
						int direction = InputInteger("Direction", 0, 359);
						if (direction != INVALID_NUMBER)
						{
							int warp = InputInteger("Warp Speed", 0, 10);
							if (warp != INVALID_NUMBER)
							{
								SpecTrek.Instance.Federation.Enterprise.Propulsions!.SetHyperDrive(direction, warp);
							}
						}
					}
					break;

				case Command.EId.Move:
					specTrek.Federation.Enterprise.Propulsions!.Move();
					break;

				case Command.EId.LongDistanceSensorSweep: 
					specTrek.Federation.Enterprise.Sensors.LongDistanceSensor.Sweep(); 
					break;

				case Command.EId.ElapseTime: 
					specTrek.ElapseTime(); 
					break;

				case Command.EId.QuitGame: 
					IsQuitCommandIssued = true; 
					break;

				// Error
				default: 
					Console.WriteLine("INVALID COMMAND");
					break;
			}
		}

		public bool IsQuitCommandIssued { get; private set;  }
	}
}