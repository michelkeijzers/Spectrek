using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsciiGames
{
	public class Display(SpecTrek specTrek)
	{
	
		public void Print()
		{
			PrintStatistics();
			PrintGraphics();
		}

		private void PrintStatistics()
		{
			Enterprise enterprise = SpecTrek.Federation.Enterprise;
			Propulsions? propulsions = enterprise.Propulsions;
			Console.Write($"Enterprise | Damage: {enterprise.DamagePercentage,3}%");
			CultureInfo englishCulture = new("en-US");
			Console.Write(", Position: (" + enterprise.XPosition.ToString("N2", englishCulture) + ", " +
			 enterprise.YPosition.ToString("N2", englishCulture) + ")");
			Console.Write($", Drive: {propulsions?.CurrentPropulsionAsText}");
			Console.WriteLine($", Direction: {propulsions?.Direction}º, Speed: {propulsions?.Speed}");
			Sector? sector = enterprise.Sector;
			if (sector != null)
			{
				Quadrant quadrant = sector.Quadrant;
				Console.WriteLine($"Quadrant: ({quadrant.Horizontal + 1}, {quadrant.Vertical + 1}): {quadrant.Name}");
			}
		}

		private void PrintGraphics()
		{
			Console.Write("     ");
			for (int horizontal = 0; horizontal < Quadrant.HORIZONTAL_SECTORS; horizontal++)
			{
				Console.Write($"{horizontal + 1:D2}   ");
			}
			Console.WriteLine();

			for (int vertical = 0; vertical < Quadrant.VERTICAL_SECTORS; vertical++)
			{
				Console.Write($"  {vertical + 1}  ");
				for (int horizontal = 0; horizontal < Quadrant.HORIZONTAL_SECTORS; horizontal++)
				{
					Console.Write($"{GetSectorContent(horizontal, vertical)}");
				}
				Console.WriteLine();
			}
		}

		private string GetSectorContent(int horizontal, int vertical)
		{
			string content = "";
			Enterprise enterprise = SpecTrek.Federation.Enterprise;
			Quadrant? quadrant = enterprise.Sector?.Quadrant;
			Sector? sector = quadrant?.GetSector(horizontal, vertical);
			if (sector != null)
			{
				if (enterprise.Sector == sector)
				{
					content += "E";
				}
				if (SpecTrek.Federation.BaseShips.HasSectorBaseShip(sector))
				{
					content += "B";
				}
				if (SpecTrek.KlingonShips.HasSectorShip(sector))
				{
					content += "K";
				}
			}

			return content.PadRight(5);
		}

		public SpecTrek SpecTrek { get; private set; } = specTrek;
	}
}
