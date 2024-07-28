namespace AsciiGames
{
	public class HyperDrive : Propulsion
	{
		public override void Move(int horizontal, int vertical)
		{
			SpecTrek.Instance.Federation.Enterprise.DeltaPosition(
				 horizontal * Quadrant.HORIZONTAL_SECTORS, vertical * Quadrant.VERTICAL_SECTORS);
			SpecTrek.Instance.StarDate.Day += Math.Abs(Horizontal) + Math.Abs(Vertical); // TODO
			SpecTrek.Instance.Federation.Enterprise.Energy -= (Math.Abs(Horizontal) + Math.Abs(Vertical)) * 100;
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
