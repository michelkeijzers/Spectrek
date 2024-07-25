namespace AsciiGames
{
	public class LongDistanceSensor() : Sensor()
	{
		public static void GetScanResult(Quadrant quadrant, out bool baseShipInQuadrant, out int nrOfKlingonsInQuadrant)
		{
			baseShipInQuadrant = quadrant.HasBaseShip();
			nrOfKlingonsInQuadrant = quadrant.CountKlingons();
		}
	}
}