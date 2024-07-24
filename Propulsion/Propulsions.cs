using System.Numerics;
using static AsciiGames.Propulsions;

namespace AsciiGames
{
	public class Propulsions
	{
		public Propulsions()
		{
			CurrentPropulsion = ImpulseDrive;
			Direction = 0;
			Speed = 0;
		}

		public ImpulseDrive ImpulseDrive { get; private set; } = new ImpulseDrive();

		public HyperDrive HyperDrive { get; private set; } = new HyperDrive();

		public void SetImpulseDrive(int direction, int force)
		{
			CurrentPropulsion = ImpulseDrive;
			Direction = direction;
			Speed = force;
		}

		public void SetHyperDrive(int direction, int warp)
		{
			CurrentPropulsion = HyperDrive;
			Direction = direction;
			Speed = warp;
		}

		public void Move()
		{
			Enterprise enterprise = SpecTrek.Instance.Federation.Enterprise;
			double xPosition = enterprise.XPosition;
			double yPosition = enterprise.YPosition;

			if (CurrentPropulsion == ImpulseDrive)
			{
				xPosition += XSegment * Speed;
				yPosition -= YSegment * Speed;
			}
			else
			{
				xPosition += XSegment * Quadrant.HORIZONTAL_SECTORS * Speed;
				yPosition -= YSegment * Quadrant.VERTICAL_SECTORS * Speed;
			}

			enterprise.SetPosition(xPosition, yPosition);
		}

		private double XSegment
		{
			get
			{
				double angle = Direction * (Math.PI / 180.0);
				return Math.Sin(angle);
			}
		}

		private double YSegment
		{
			get
			{
				double angle = Direction * (Math.PI / 180.0);
				return Math.Cos(angle);
			}
		}

		public string CurrentPropulsionAsText
		{
			get
			{
				return CurrentPropulsion == ImpulseDrive ? "Impulse Drive" : "Hyperdrive";
			}
		}

		public Propulsion CurrentPropulsion { get; private set; }

		public int Direction { get; private set; }

		public int Speed { get; private set; }
	}
}
