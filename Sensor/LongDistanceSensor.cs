namespace AsciiGames
{
	public class LongDistanceSensor() : Sensor()
	{
		public override void Sweep()
		{
			Console.WriteLine("Long Distance Sensor");
			Quadrant? enterpriseQuadrant = SpecTrek.Instance.Federation.Enterprise.Sector?.Quadrant;
			if (enterpriseQuadrant != null)
			{
				Console.Write("     ");
				for (int horizontal = Math.Max(0, enterpriseQuadrant.Horizontal - 1);
						horizontal <= Math.Min(MilkyWay.HORIZONTAL_QUADRANTS - 1, enterpriseQuadrant.Horizontal + 1); horizontal++)
				{
					Console.Write($"  {horizontal + 1:D1}  ");
				}
				Console.WriteLine();

				for (int vertical = enterpriseQuadrant.Vertical - 1; vertical <= enterpriseQuadrant.Vertical + 1; vertical++)
				{ 
					Console.Write($"  {vertical + 1:D1}  ");
					for (int horizontal = enterpriseQuadrant.Horizontal - 1; horizontal <= enterpriseQuadrant.Horizontal + 1; horizontal++)
					{
						if ((horizontal < 0) || (horizontal >= MilkyWay.HORIZONTAL_QUADRANTS) ||
							 (vertical < 0) || (vertical >= MilkyWay.VERTICAL_QUADRANTS))
						{
							Console.Write("     ");
						}
						else
						{
							string scanResult = GetScanResult(SpecTrek.Instance.MilkyWay.GetQuadrant(horizontal, vertical));
							Console.Write(scanResult);
						}
					}
					Console.WriteLine();
				}
			}
		}

		private static string GetScanResult(Quadrant quadrant)
		{
			int klingonsInQuadrant = quadrant.CountKlingons();
			string baseShipInQuadrant = quadrant.HasBaseShip() ? "B" : " ";
			
			return $"{baseShipInQuadrant}-{klingonsInQuadrant:D2}  ";
		}
	}
}