namespace AsciiGames
{
	public class Quadrant()
	{
		public const int HORIZONTAL_SECTORS = 16;
		public const int VERTICAL_SECTORS = 8;

		public Quadrant(int horizontal, int vertical) : this()
		{
			Horizontal = horizontal;	
			Vertical = vertical;

			for (int verticalSector = 0; verticalSector < VERTICAL_SECTORS; verticalSector++)
			{
				for (int horizontalSector = 0; horizontalSector < HORIZONTAL_SECTORS; horizontalSector++)
				{
					_sectors[horizontalSector, verticalSector] = new(this, horizontalSector, verticalSector);
				}
			}
		}

		public Sector GetSector(int horizontal, int vertical)
		{
			return _sectors[horizontal, vertical];
		}

		public int Horizontal { get; set; }

		public int Vertical { get; set; } 

		private readonly string[] QUADRANT_NAMES = 
		[
			"ANTARES", "SIRIUS", "RIGEL", "DENEB", "PROCYON", "CAPELLA", "VEGA", "BETELGEUSE",
			"CANOPUS", "ALDEBARAN", "ALTAIR", "REGULUS", "SAGITTARIUS", "ACTURUS", "POLLUX", "SPICA"
		];

		private readonly string[] QUADRANT_INDICES = ["I", "II", "III", "IV"];

		public string Name
		{
			get
			{
				return $"{QUADRANT_NAMES[Vertical * 2 + (Horizontal < 4 ? 0 : 1)]} {QUADRANT_INDICES[Horizontal % 4]}";
			}
		}
		public Sector GetRandomSector()
		{
			return _sectors[_random.Next(HORIZONTAL_SECTORS - 1), _random.Next(VERTICAL_SECTORS - 1)];
		}

		public int CountKlingons()
		{
			return SpecTrek.Instance.KlingonShips.Ships.Count(ship => ship.Sector!.Quadrant == this);
		}

		public bool HasBaseShip()
		{
			return SpecTrek.Instance.Federation.BaseShips.BaseShips.Exists(ship => ship.Sector!.Quadrant == this);
		}

		public static bool IsOutOfQuadrant(int horizontal, int vertical)
		{
			return ((horizontal < 0) || (horizontal >= HORIZONTAL_SECTORS) ||
			        (vertical < 0) || (vertical >= VERTICAL_SECTORS));
		}

		private readonly Sector[,] _sectors = new Sector[HORIZONTAL_SECTORS, VERTICAL_SECTORS];

		readonly private Random _random = new();
	}
}