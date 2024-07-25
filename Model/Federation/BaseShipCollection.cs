using System.Collections.Generic;

namespace AsciiGames
{
	public class BaseShipCollection()
	{
		private readonly int NR_OF_BASE_SHIPS = 5;

		public void Init()
		{
			for (int baseShipIndex = 0; baseShipIndex < NR_OF_BASE_SHIPS; baseShipIndex++) 
			{
				Sector sector = GetRandomSectorWithoutBaseShip();
				BaseShip baseShip = new()
				{
					Sector = sector
				};
				BaseShips.Add(baseShip);
			}
		}

		public bool HasSectorBaseShip(Sector sector)
		{
			return BaseShips.Any(baseShip => baseShip.Sector == sector);
		}

		private Sector GetRandomSectorWithoutBaseShip()
		{
			Quadrant quadrant;
			do
			{
				quadrant = SpecTrek.Instance.MilkyWay.GetRandomQuadrant();
			} while (CountBaseShipsInQuadrant(quadrant) > 0);

			return quadrant.GetRandomSector();
		}

		private int CountBaseShipsInQuadrant(Quadrant quadrant)
		{
			return BaseShips.Count(ship => ship != null && ship.Sector!.Quadrant == quadrant);
		}

		public List<BaseShip> BaseShips { get; private set; } = [];
	}
}
