namespace AsciiGames
{
	public class LongDistanceSensor() : Sensor()
	{
		public static void GetScanResult(Quadrant quadrant, out bool baseShipInQuadrant, out int nrOfKlingonsInQuadrant)
		{
			baseShipInQuadrant = (quadrant.GetBaseShip() != null);
			nrOfKlingonsInQuadrant = quadrant.CountKlingons();
		}
	}
}