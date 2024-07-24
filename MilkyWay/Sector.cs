namespace AsciiGames
{
	public class Sector(Quadrant quadrant, int horizontal, int vertical)
	{
		public int Horizontal { get; private set; } = horizontal;

		public int Vertical { get; private set; } = vertical;

		public Quadrant Quadrant { get; private set; } = quadrant;

		public string AsText
		{
			get { return $"({Quadrant.Horizontal + 1},{Quadrant.Vertical + 1})/({Horizontal + 1:D2}/{Vertical + 1})"; }
		}

		public double XPosition
		{
			get { return Quadrant.Horizontal * Quadrant.HORIZONTAL_SECTORS + Horizontal; }
		}

		public double YPosition
		{
			get { return Quadrant.Vertical * Quadrant.VERTICAL_SECTORS + Vertical; }
		}
	}
}