using System.Collections.Generic;

namespace AsciiGames
{
	public class BaseShipCollection()
	{
		private readonly int NR_OF_BASE_SHIPS = 10; // TODO: 5; 

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

		public bool HasIntactBaseShipInSector(Sector sector)
		{
			return BaseShips.Any(baseShip => !baseShip.IsDestroyed && baseShip.Sector == sector);
		}

		public BaseShip? GetBaseShipInQuadrant(Quadrant quadrant)
		{
			return BaseShips.FirstOrDefault(baseShip => baseShip.Sector!.Quadrant == quadrant);
		}


		private Sector GetRandomSectorWithoutBaseShip()
		{
			Quadrant quadrant;
			do
			{
				quadrant = SpecTrek.Instance.MilkyWay.GetRandomQuadrant();
			} while (GetBaseShipInQuadrant(quadrant) != null);

			return quadrant.GetRandomSector();
		}

		public List<BaseShip> BaseShips { get; private set; } = [];
	}
}
