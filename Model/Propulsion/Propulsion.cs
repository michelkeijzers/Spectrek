using System.Numerics;

namespace AsciiGames
{
	public abstract class Propulsion
	{
		protected Propulsion()
		{
			Horizontal = 0;
			Vertical = 0;
		}

		public abstract void Move(int horizontal, int vertical);

		public abstract string Name { get; }

		public int Horizontal { get; set; }

		public int Vertical { get; set; }
	}
}
