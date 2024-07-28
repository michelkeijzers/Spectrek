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

		public void SetImpulseDrive(int horizontal, int vertical)
		{
			CurrentPropulsion = ImpulseDrive;
			CurrentPropulsion.Horizontal = horizontal;
			CurrentPropulsion.Vertical = vertical;
		}

		public void SetHyperDrive(int horizontal, int vertical)
		{
			CurrentPropulsion = HyperDrive;
			CurrentPropulsion.Horizontal = horizontal;
			CurrentPropulsion.Vertical = vertical;
		}

		public void Move()
		{
			Enterprise enterprise = SpecTrek.Instance.Federation.Enterprise;
			int xPosition = enterprise.XPosition;
			int yPosition = enterprise.YPosition;

			CurrentPropulsion.Move(CurrentPropulsion.Horizontal, CurrentPropulsion.Vertical);
			enterprise.SetPosition(xPosition, yPosition);
		}

		public Propulsion CurrentPropulsion { get; private set; }


	}
}
