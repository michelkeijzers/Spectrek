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
					SweepLongDistanceSensor();
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


		private void SweepLongDistanceSensor()
		{
			Console.WriteLine("Long Distance Sensor");
			Quadrant? enterpriseQuadrant = SpecTrek.Instance.Federation.Enterprise.Sector?.Quadrant;
			if (enterpriseQuadrant != null)
			{
				Console.Write("     ");
				for (int horizontal = Math.Max(0, enterpriseQuadrant.Horizontal - 1);
						horizontal <= Math.Min(MilkyWay.HORIZONTAL_QUADRANTS - 1, enterpriseQuadrant.Horizontal + 1); horizontal++)
				{
					Console.Write($"  {horizontal + 1:D1}  ");
				}
				Console.WriteLine();

				for (int vertical = enterpriseQuadrant.Vertical - 1; vertical <= enterpriseQuadrant.Vertical + 1; vertical++)
				{
					Console.Write($"  {vertical + 1:D1}  ");
					for (int horizontal = enterpriseQuadrant.Horizontal - 1; horizontal <= enterpriseQuadrant.Horizontal + 1; horizontal++)
					{
						if ((horizontal < 0) || (horizontal >= MilkyWay.HORIZONTAL_QUADRANTS) ||
							 (vertical < 0) || (vertical >= MilkyWay.VERTICAL_QUADRANTS))
						{
							Console.Write("     ");
						}
						else
						{
							LongDistanceSensor.GetScanResult(SpecTrek.Instance.MilkyWay.GetQuadrant(horizontal, vertical), 
								out bool baseShipInQuadrant, out int nrOfKlingonsInQuadrant);
							ConsolePlus.WriteWithColor(ConsoleColor.White, baseShipInQuadrant ? "B" : " ");
							Console.Write("-");
							if (nrOfKlingonsInQuadrant == 0)
							{
								Console.Write($"{nrOfKlingonsInQuadrant:D2} ");
							}
							else
							{
								ConsolePlus.WriteWithColor(ConsoleColor.Red, $"{nrOfKlingonsInQuadrant:D2} ");
							}
						}
					}
					Console.WriteLine();
				}
			}
		}
		public bool IsQuitCommandIssued { get; private set;  }
	}
}