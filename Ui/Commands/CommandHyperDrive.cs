using AsciiGames;

namespace AsciiGames
{
	public class CommandHyperDrive : MoveCommand
	{
		public override ConsoleKey Key { get { return ConsoleKey.H; } }

		public override string KeyString {  get { return "H"; } }

		public override string Text {  get { return "Hyper Drive"; } }

		public override bool CanExecute()
		{
			return true;
		}

		public override void Execute()
		{
			int horizontal = InputInteger("Horizontal Quadrants", -MilkyWay.HORIZONTAL_QUADRANTS, MilkyWay.HORIZONTAL_QUADRANTS);
			if (horizontal != INVALID_NUMBER)
			{
				int vertical = InputInteger("Vertical Quadrants", -MilkyWay.VERTICAL_QUADRANTS, MilkyWay.VERTICAL_QUADRANTS);
				if (vertical != INVALID_NUMBER)
				{
					Enterprise enterprise = SpecTrek.Instance.Federation.Enterprise;
					enterprise.Propulsions!.SetHyperDrive(horizontal, vertical);
					enterprise.Propulsions!.CurrentPropulsion.Move(horizontal, vertical);
					HandleBaseShipInEnterpriseSector();
				}
			}
		}
	}
}
