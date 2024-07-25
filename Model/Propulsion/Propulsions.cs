using System.Numerics;
using static AsciiGames.Propulsions;

namespace AsciiGames
{
	public class Propulsions
	{
		public Propulsions()
		{
			CurrentPropulsion = ImpulseDrive;
		}

		public ImpulseDrive ImpulseDrive { get; private set; } = new ImpulseDrive();

		public HyperDrive HyperDrive { get; private set; } = new HyperDrive();

		public void SetImpulseDrive(int direction, int force)
		{
			CurrentPropulsion = ImpulseDrive;
			CurrentPropulsion.Direction = direction;
			CurrentPropulsion.Speed = force;
		}

		public void SetHyperDrive(int direction, int warp)
		{
			CurrentPropulsion = HyperDrive;
			CurrentPropulsion.Direction = direction;
			CurrentPropulsion.Speed = warp;
		}

		public void Move()
		{
			Enterprise enterprise = SpecTrek.Instance.Federation.Enterprise;
			double xPosition = enterprise.XPosition;
			double yPosition = enterprise.YPosition;

			CurrentPropulsion.Move(ref xPosition, ref yPosition);
			enterprise.SetPosition(xPosition, yPosition);
		}

		public Propulsion CurrentPropulsion { get; private set; }


	}
}
