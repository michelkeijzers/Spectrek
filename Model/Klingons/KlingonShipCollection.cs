using System.Collections.Generic;

namespace AsciiGames
{
	public class KlingonShipCollection()
	{
		private readonly int NR_OF_KLINGON_SHIPS = 10; //TODO: 6;

		public void Init()
		{
			for (int shipIndex = 0; shipIndex < NR_OF_KLINGON_SHIPS; shipIndex++) 
			{
				Sector sector = GetRandomSectorWithoutKlingonShip();
				KlingonShip ship = new()
				{
					Sector = sector
				};
				Ships.Add(ship);
			}
		}

		public bool HasSectorShip(Sector sector)
		{
			return Ships.Any(ship => ship.Sector == sector);
		}

		private Sector GetRandomSectorWithoutKlingonShip()
		{
			Quadrant quadrant;
			do
			{
				quadrant = SpecTrek.Instance.MilkyWay.GetRandomQuadrant();
			} while (CountKlingonShipsInQuadrant(quadrant) > 0);

			return quadrant.GetRandomSector();
		}

		private int CountKlingonShipsInQuadrant(Quadrant quadrant)
		{
			return Ships.Count(ship => ship != null && ship.Sector!.Quadrant == quadrant);
		}

		public List<KlingonShip> Ships { get; private set; } = [];
	}
}
