namespace AsciiGames
{
	public class ImpulseDrive : Propulsion
	{
		public override void Move(ref double xPosition, ref double yPosition)
		{
			xPosition += XSegment * Speed;
			yPosition -= YSegment * Speed;
			SpecTrek.Instance.StarDate.Day += Speed;
			SpecTrek.Instance.Federation.Enterprise.Energy -= Speed;
		}

		public override string Name
		{
			get
			{
				return "Impulse Drive";
			}
		}
	}
}
