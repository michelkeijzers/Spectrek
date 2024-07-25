using System.Numerics;

namespace AsciiGames
{
	public class Sensors()
	{
		public LongDistanceSensor LongDistanceSensor { get; private set; } = new LongDistanceSensor();

		//public ShortDistanceSensor ShortDistanceSensor { get; private set; } = new ShortDistanceSensor();
	}
}
