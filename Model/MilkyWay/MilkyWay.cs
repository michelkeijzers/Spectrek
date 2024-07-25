namespace AsciiGames
{
	public class MilkyWay
	{
		public MilkyWay()
		{
			for (int vertical = 0; vertical < VERTICAL_QUADRANTS; vertical++)
			{
				for (int horizontal = 0; horizontal < HORIZONTAL_QUADRANTS; horizontal++)
				{
					_quadrants[horizontal, vertical] = new(horizontal, vertical);
				}
			}
		}

		public void Init()
		{
			for (int vertical = 0; vertical < VERTICAL_QUADRANTS; vertical++)
			{
				for (int horizontal = 0; horizontal < HORIZONTAL_QUADRANTS; horizontal++)
				{
					_quadrants[horizontal, vertical].Vertical = vertical;
					_quadrants[horizontal, vertical].Horizontal = horizontal;
				}
			}
		}

		public Quadrant GetRandomQuadrant()
		{
			return _quadrants[_random.Next(HORIZONTAL_QUADRANTS - 1), _random.Next(VERTICAL_QUADRANTS - 1)];
		}

		public Sector GetRandomSector()
		{
			Quadrant quadrant = _quadrants[_random.Next(HORIZONTAL_QUADRANTS - 1), _random.Next(VERTICAL_QUADRANTS - 1)];
			return quadrant.GetRandomSector();
		}

		public Quadrant GetQuadrant(int horizontal, int vertical)
		{
			return _quadrants[horizontal, vertical];
		}

		public static bool IsOutOfMilkyWay(int horizontal, int vertical)
		{
			return ((horizontal < 0) || (horizontal >= HORIZONTAL_QUADRANTS) ||
					  (vertical < 0) || (vertical >= VERTICAL_QUADRANTS));
		}

		public Sector? FindSectorWithPosition(double xPosition, double yPosition)
		{
			if ((xPosition < 0.0) || (xPosition > MilkyWay.HORIZONTAL_QUADRANTS * Quadrant.HORIZONTAL_SECTORS) ||
				 (yPosition < 0.0) || (yPosition > MilkyWay.VERTICAL_QUADRANTS * Quadrant.VERTICAL_SECTORS))
			{
				return null;
			}
			else
			{
				Quadrant quadrant = _quadrants[
				(int)xPosition / Quadrant.HORIZONTAL_SECTORS,
				(int)yPosition / Quadrant.VERTICAL_SECTORS];
				return quadrant.GetSector(
					(int)xPosition % Quadrant.HORIZONTAL_SECTORS,
					(int)yPosition % Quadrant.VERTICAL_SECTORS);
			}
		}

		public const int HORIZONTAL_QUADRANTS = 8;
		public const int VERTICAL_QUADRANTS = 8;

		private readonly Quadrant[,] _quadrants = new Quadrant[HORIZONTAL_QUADRANTS, VERTICAL_QUADRANTS];

		readonly private Random _random = new();
	}
}