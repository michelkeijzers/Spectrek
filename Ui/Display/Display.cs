using System;
using System.Collections.Generic;
using System.Drawing;
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

			/* Test colors */
			/*
			ConsolePlus.WriteWithColor(ConsoleColor.Yellow, "Yellow ");
			ConsolePlus.WriteWithColor(ConsoleColor.DarkRed, "Dark Red ");
			ConsolePlus.WriteWithColor(ConsoleColor.Red, "Red ");
			ConsolePlus.WriteWithColor(ConsoleColor.DarkBlue, "Dark Blue ");
			ConsolePlus.WriteWithColor(ConsoleColor.Blue, "Blue ");
			ConsolePlus.WriteWithColor(ConsoleColor.DarkGreen, "Dark Green ");
			ConsolePlus.WriteWithColor(ConsoleColor.Green, "Green ");
			ConsolePlus.WriteWithColor(ConsoleColor.DarkCyan, "DarkCyan ");
			ConsolePlus.WriteWithColor(ConsoleColor.Cyan, "Cyan ");
			ConsolePlus.WriteWithColor(ConsoleColor.DarkMagenta, "Dark Magenta ");
			ConsolePlus.WriteWithColor(ConsoleColor.Magenta, "Magenta ");
			ConsolePlus.WriteWithColor(ConsoleColor.DarkGray, "Dark Gray ");
			ConsolePlus.WriteWithColor(ConsoleColor.Gray, "Gray ");
			ConsolePlus.WriteWithColor(ConsoleColor.White, "White ");
			Console.WriteLine("");
			*/
			ConsoleColor color;

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
			Console.WriteLine(", Position: (" + enterprise.XPosition.ToString("N2", englishCulture) + ", " +
			 enterprise.YPosition.ToString("N2", englishCulture) + ")");

			Console.Write($"           | Shields: ");
			if (enterprise.Shields.Enabled)
			{
				ConsolePlus.WriteWithColor(ConsoleColor.Green, "Enabled");
			}
			else
			{
				Console.Write("Disabled");
			}
			Console.Write(", Photons: ");
			int nrOfPhotons = enterprise.Weapons.Photons.NrOfPhotons;
			color = nrOfPhotons < 4 ? (nrOfPhotons == 0 ? ConsoleColor.Red : ConsoleColor.Yellow) : ConsoleColor.Green;
			ConsolePlus.WriteWithColor(color, $"{nrOfPhotons}");
			Console.WriteLine("");

			Sector? sector = enterprise.Sector;
			if (sector != null)
			{
				Quadrant quadrant = sector.Quadrant;
				Console.WriteLine($"Quadrant: ({quadrant.Horizontal + 1}, {quadrant.Vertical + 1}): {quadrant.Name}");
			}
		}

		private static void PrintGraphics()
		{
			Console.Write("   ");
			for (int horizontal = 0; horizontal < Quadrant.HORIZONTAL_SECTORS; horizontal++)
			{
				ConsolePlus.WriteWithColor(System.ConsoleColor.DarkGreen, $" {horizontal + 1:D2}  ");
			}
			Console.WriteLine();

			Console.Write("   ");
			for (int horizontal = 0; horizontal < Quadrant.HORIZONTAL_SECTORS; horizontal++)
			{
				ConsolePlus.WriteWithColor(System.ConsoleColor.DarkGreen, $"---- ");
			}
			Console.WriteLine();

			for (int vertical = 0; vertical < Quadrant.VERTICAL_SECTORS; vertical++)
			{
				ConsolePlus.WriteWithColor(System.ConsoleColor.DarkGreen, $"{vertical + 1} |");
				for (int horizontal = 0; horizontal < Quadrant.HORIZONTAL_SECTORS; horizontal++)
				{
					PrintSectorContent(horizontal, vertical);
				}
				ConsolePlus.WriteWithColor(System.ConsoleColor.DarkGreen, $"| {vertical + 1}");
				Console.WriteLine();
			}

			Console.Write("   ");
			for (int horizontal = 0; horizontal < Quadrant.HORIZONTAL_SECTORS; horizontal++)
			{
				ConsolePlus.WriteWithColor(System.ConsoleColor.DarkGreen, $"---- ");
			}
			Console.WriteLine();

			Console.Write("   ");
			for (int horizontal = 0; horizontal < Quadrant.HORIZONTAL_SECTORS; horizontal++)
			{
				ConsolePlus.WriteWithColor(System.ConsoleColor.DarkGreen, $" {horizontal + 1:D2}  ");
			}
			Console.WriteLine();
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

				BaseShip? baseShip = sector.GetBaseShip();
				if (baseShip != null)
				{
					if (baseShip.Status == Ship.EStatus.Active)
					{
						ConsolePlus.WriteWithColor(System.ConsoleColor.White, "B");
					}
					else
					{
						ConsolePlus.WriteWithColor(System.ConsoleColor.DarkGray, "B");
					}
					nrOfCharactersPrinted++;
				}
				if (specTrek.KlingonShips.HasSectorShip(sector))
				{
					ConsolePlus.WriteWithColor(System.ConsoleColor.Red, "K");
					nrOfCharactersPrinted++;
				}
			}

			Console.Write(new string(' ', 5 - nrOfCharactersPrinted - ((horizontal == Quadrant.HORIZONTAL_SECTORS - 1) ? 1 : 0)));
		}
	}
}
