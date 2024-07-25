using System.Diagnostics;

namespace AsciiGames
{
	public class Enterprise
	{
		public Enterprise()
		{
			Sensors = new Sensors();
			Propulsions = new Propulsions();
			XPosition = 0.0;
			YPosition = 0.0;
			Energy = 15000;
		}

		public void Init()
		{
			Sector sector = SpecTrek.Instance.MilkyWay.GetRandomSector();
			XPosition = sector.XPosition;
			YPosition = sector.YPosition;
		}

		public Sector? Sector 
		{
			get { return SpecTrek.Instance.MilkyWay.FindSectorWithPosition(XPosition, YPosition); }
		}

		public double XPosition { get; private set; }
		public double YPosition { get; private set; }

		public void SetPosition(double xPosition, double yPosition)
		{
			XPosition = xPosition;
			YPosition = yPosition;
			if (SpecTrek.Instance.MilkyWay.FindSectorWithPosition(XPosition, YPosition) == null)
			{
				IsWithinMilkyWay = false;
			}
		}

		public bool IsWithinMilkyWay { get; set; } = true;

		public int DamagePercentage { get; private set; } = 0;

		public Sensors Sensors { get; private set; }

		public Propulsions? Propulsions { get; private set; }

		public int Energy { get; set;  }

	}
}
