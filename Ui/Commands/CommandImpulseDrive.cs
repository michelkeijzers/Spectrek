using AsciiGames;

namespace AsciiGames
{
	public class CommandImpulseDrive : MoveCommand
	{
		public override ConsoleKey Key { get { return ConsoleKey.I; } }

		public override string KeyString {  get { return "I"; } }

		public override string Text {  get { return "Impulse Drive"; } }

		public override bool CanExecute()
		{
			return true;
		}

		public override void Execute()
		{
			int horizontal = InputInteger("Horizontal", -Quadrant.HORIZONTAL_SECTORS, Quadrant.HORIZONTAL_SECTORS);
			if (horizontal != INVALID_NUMBER)
			{
				int vertical = InputInteger("Vertical", -Quadrant.VERTICAL_SECTORS, Quadrant.VERTICAL_SECTORS);
				if (vertical != INVALID_NUMBER)
				{
					Enterprise enterprise = SpecTrek.Instance.Federation.Enterprise;
					enterprise.Propulsions!.SetImpulseDrive(horizontal, vertical);
					enterprise.Propulsions!.CurrentPropulsion.Move(horizontal, vertical);
					HandleBaseShipInEnterpriseSector();
				}
			}
		}
	}
}
