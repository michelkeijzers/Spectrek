namespace AsciiGames
{
	public class ImpulseDrive : Propulsion
	{
		public override void Move(int horizontal, int vertical)
		{
			SpecTrek.Instance.Federation.Enterprise.DeltaPosition(horizontal, vertical);
			SpecTrek.Instance.StarDate.Day += Math.Abs(Horizontal) + Math.Abs(Vertical);
			SpecTrek.Instance.Federation.Enterprise.Energy -= Math.Abs(Horizontal) + Math.Abs(Vertical); // TODO
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
