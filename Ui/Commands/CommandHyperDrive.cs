using AsciiGames;

namespace AsciiGames
{
	public class CommandHyperDrive : Command
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
			int direction = InputInteger("Direction", 0, 359);
			if (direction != INVALID_NUMBER)
			{
				int power = InputInteger("Warp Speed", 0, 10);
				if (power != INVALID_NUMBER)
				{
					SpecTrek.Instance.Federation.Enterprise.Propulsions!.SetHyperDrive(direction, power);
				}
			}
		}
	}
}
