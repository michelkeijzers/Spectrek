using System.Numerics;

namespace AsciiGames
{
	public abstract class Propulsion
	{
		protected Propulsion()
		{ 
			Direction = 0;
			Speed = 0;
		}

		public abstract void Move(ref double xPosition, ref double yPosition);

		public abstract string Name { get; }

		public int Direction { get; set; }

		protected double XSegment
		{
			get
			{
				double angle = Direction * (Math.PI / 180.0);
				return Math.Sin(angle);
			}
		}

		protected double YSegment
		{
			get
			{
				double angle = Direction * (Math.PI / 180.0);
				return Math.Cos(angle);
			}
		}

		public int Speed { get; set; }
	}
}
