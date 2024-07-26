using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsciiGames
{
	public class Display()
	{
	
		public static void Print()
		{
			PrintStatistics();
			PrintGraphics();
		}

		private static void PrintStatistics()
		{
			SpecTrek specTrek = SpecTrek.Instance;
			Enterprise enterprise = specTrek.Federation.Enterprise;
			Propulsions propulsions = enterprise.Propulsions!;

			Console.Write("Star Date: ");
			if (SpecTrek.Instance.StarDate.Year >= 2404)
			{
				ConsolePlus.WriteLineWithColor(System.ConsoleColor.Yellow, 
					$"{specTrek.StarDate.Year:D4}.{specTrek.StarDate.Day:D2}");
			}
			else
			{
				Console.WriteLine($"{specTrek.StarDate.Year:D4}.{specTrek.StarDate.Day:D2}");
			}

			CultureInfo englishCulture = new("en-US");
			Console.Write("Enterprise | Energy: ");
			int energy = enterprise.Energy;
			if (energy < 1000)
			{
				ConsolePlus.WriteWithColor(System.ConsoleColor.Red, enterprise.Energy.ToString("N0", englishCulture));
			}
			else
			{
				Console.Write(enterprise.Energy.ToString("N0", englishCulture));
			}
			Console.Write(", Damage: " + enterprise.DamagePercentage.ToString("N1", englishCulture) + "%");
			Console.Write(", Position: (" + enterprise.XPosition.ToString("N2", englishCulture) + ", " +
			 enterprise.YPosition.ToString("N2", englishCulture) + ")");

			Propulsion currentPropulsion = propulsions!.CurrentPropulsion;
			Console.Write($", {currentPropulsion.Name}");
			Console.WriteLine($" (Direction: {currentPropulsion.Direction}º, Speed: {currentPropulsion.Speed})");
			Sector? sector = enterprise.Sector;
			if (sector != null)
			{
				Quadrant quadrant = sector.Quadrant;
				Console.WriteLine($"Quadrant: ({quadrant.Horizontal + 1}, {quadrant.Vertical + 1}): {quadrant.Name}");

				BaseShip? baseShip = SpecTrek.Instance.Federation.BaseShips.GetBaseShipInQuadrant(quadrant);
				if (baseShip != null) 
				{
					if (BaseShipInSector.Event == BaseShipInSector.EEvent.DockingAllowed)
					{
						Quadrant.CalculateDirectionAndDistance(enterprise.Sector!, baseShip.Sector!,
						 out double direction, out double distance);
						ConsolePlus.WriteLineWithColor(ConsoleColor.Blue,
						 $"The base ship is in direction " + direction.ToString("N2", englishCulture) + "º at distance " +
						 distance.ToString("N2", englishCulture) + ".");
					}
				}
			}
		}

		private static void PrintGraphics()
		{
			Console.Write("     ");
			for (int horizontal = 0; horizontal < Quadrant.HORIZONTAL_SECTORS; horizontal++)
			{
				ConsolePlus.WriteWithColor(System.ConsoleColor.DarkGreen, $"{horizontal + 1:D2}   ");
			}
			Console.WriteLine();

			for (int vertical = 0; vertical < Quadrant.VERTICAL_SECTORS; vertical++)
			{
				ConsolePlus.WriteWithColor(System.ConsoleColor.DarkGreen, $"  {vertical + 1}  ");
				for (int horizontal = 0; horizontal < Quadrant.HORIZONTAL_SECTORS; horizontal++)
				{
					PrintSectorContent(horizontal, vertical);
				}
				Console.WriteLine();
			}
		}

		private static void PrintSectorContent(int horizontal, int vertical)
		{
			int nrOfCharactersPrinted = 0;
			SpecTrek specTrek = SpecTrek.Instance;
			Enterprise enterprise = specTrek.Federation.Enterprise;
			Quadrant? quadrant = enterprise.Sector?.Quadrant;
			Sector? sector = quadrant?.GetSector(horizontal, vertical);
			if (sector != null)
			{
				if (enterprise.Sector == sector)
				{
					ConsolePlus.WriteWithColor(System.ConsoleColor.White, "E");
					nrOfCharactersPrinted++;
				}
				if (specTrek.Federation.BaseShips.HasIntactBaseShipInSector(sector))
				{
					ConsolePlus.WriteWithColor(System.ConsoleColor.White, "B");
					nrOfCharactersPrinted++;
				}
				if (specTrek.KlingonShips.HasSectorShip(sector))
				{
					ConsolePlus.WriteWithColor(System.ConsoleColor.Red, "K");
					nrOfCharactersPrinted++;
				}
			}

			Console.Write(new string(' ', 5 - nrOfCharactersPrinted));
		}
	}
}
