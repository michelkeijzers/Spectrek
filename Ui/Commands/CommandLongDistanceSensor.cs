using AsciiGames;

namespace AsciiGames
{
	public class CommandLongDistanceSensor : Command
	{
		public override ConsoleKey Key { get { return ConsoleKey.L; } }

		public override string KeyString {  get { return "L"; } }

		public override string Text {  get { return "Long Distance Sensor"; } }

		public override bool CanExecute()
		{
			return true;
		}

		public override void Execute()
		{
			Console.WriteLine("Long Distance Sensor");
			Enterprise enterprise = SpecTrek.Instance.Federation.Enterprise;
			enterprise.Energy -= 100;
			Quadrant? enterpriseQuadrant = enterprise.Sector?.Quadrant;
			if (enterpriseQuadrant != null)
			{
				ConsolePlus.WriteWithColor(System.ConsoleColor.DarkGreen, "  Q  ");
				for (int horizontal = enterpriseQuadrant.Horizontal - 1; horizontal <= enterpriseQuadrant.Horizontal + 1; horizontal++)
				{
					if (MilkyWay.IsHorizontalQuadrantIndex(horizontal))
					{
						ConsolePlus.WriteWithColor(System.ConsoleColor.DarkGreen, $" {horizontal + 1:D1}   ");
					}
					else
					{
						ConsolePlus.WriteWithColor(System.ConsoleColor.DarkGreen, " -   ");
					}
				}
				Console.WriteLine();

				ConsolePlus.WriteWithColor(System.ConsoleColor.DarkGreen, "     ");
				for (int horizontal = enterpriseQuadrant.Horizontal - 1; horizontal <= enterpriseQuadrant.Horizontal + 1; horizontal++)
				{
					ConsolePlus.WriteWithColor(System.ConsoleColor.DarkGreen, "---- ");
				}
				Console.WriteLine();

				for (int vertical = enterpriseQuadrant.Vertical - 1; vertical <= enterpriseQuadrant.Vertical + 1; vertical++)
				{
					if (MilkyWay.IsVerticalQuadrantIndex(vertical))
					{
						ConsolePlus.WriteWithColor(System.ConsoleColor.DarkGreen, $"  {vertical + 1:D1} |");
						for (int horizontal = enterpriseQuadrant.Horizontal - 1; horizontal <= enterpriseQuadrant.Horizontal + 1; horizontal++)
						{
							if (MilkyWay.IsHorizontalQuadrantIndex(horizontal))
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
									ConsolePlus.WriteWithColor(System.ConsoleColor.Red, $"{nrOfKlingonsInQuadrant:D2} ");
								}
							}
							else
							{
								ConsolePlus.WriteWithColor(System.ConsoleColor.DarkGreen, "  -  ");
							}
						}
					}
					else
					{
						ConsolePlus.WriteWithColor(System.ConsoleColor.DarkGreen, "  -  ");
					}

					Console.WriteLine();
				}
			}
		}
	}
}
