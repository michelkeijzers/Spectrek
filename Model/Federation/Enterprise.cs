using System.Diagnostics;

namespace AsciiGames
{
	public class Enterprise : Ship
	{
		public Enterprise()
		{
			Sensors = new Sensors();
			Weapons = new Weapons();
			Propulsions = new Propulsions();
			XPosition = 0;
			YPosition = 0;
			Energy = 15000;
		}

		public void Init()
		{
			Sector sector = SpecTrek.Instance.MilkyWay.GetRandomSector();
			XPosition = sector.XPosition;
			YPosition = sector.YPosition;
		}

		public override Sector? Sector 
		{
			get { return SpecTrek.Instance.MilkyWay.FindSectorWithPosition(XPosition, YPosition); }
		}

		public int XPosition { get; private set; }
		public int YPosition { get; private set; }

		public void SetPosition(int xPosition, int yPosition)
		{
			XPosition = xPosition;
			YPosition = yPosition;
			if (SpecTrek.Instance.MilkyWay.FindSectorWithPosition(XPosition, YPosition) == null)
			{
				IsWithinMilkyWay = false;
			}
		}

		public void DeltaPosition(int xPosition, int yPosition)
		{
			XPosition += xPosition;
			YPosition += yPosition;
			if (SpecTrek.Instance.MilkyWay.FindSectorWithPosition(XPosition, YPosition) == null)
			{
				IsWithinMilkyWay = false;
			}
		}

		public void DockWithBaseShip()
		{
			SpecTrek.Instance.StarDate.Day += (int)(DamagePercentage + 0.5);
			Energy = 15000;
			DamagePercentage = 0.0;
		}

		public bool IsWithinMilkyWay { get; set; } = true;

		public Sensors Sensors { get; private set; }

		public Weapons Weapons { get; private set; }	

		public Propulsions? Propulsions { get; private set; }

		public int Energy { get; set;  }

		public bool IsHealthy
		{
			get
			{
				return ((DamagePercentage <= 10.0) && (Energy >= 10000)); // TODO: photons > 10, see page 60
			}
		}
	}
}
