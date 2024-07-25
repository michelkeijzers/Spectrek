namespace AsciiGames
{
	public class HyperDrive : Propulsion
	{
		public override void Move(ref double xPosition, ref double yPosition)
		{
			xPosition += XSegment * Quadrant.HORIZONTAL_SECTORS * Speed;
			yPosition -= YSegment * Quadrant.VERTICAL_SECTORS * Speed;
			SpecTrek.Instance.StarDate.Day += Speed;
			SpecTrek.Instance.Federation.Enterprise.Energy -= Speed * 100;
		}

		public override string Name
		{
			get
			{
				return "Hyper Drive";
			}
		}
	}
}
