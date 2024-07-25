using AsciiGames;

namespace AsciiGames
{
	public class CommandImpulseDrive : Command
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
			int direction = InputInteger("Direction", 0, 359);
			if (direction != INVALID_NUMBER)
			{
				int power = InputInteger("Power", 0, 10);
				if (power != INVALID_NUMBER)
				{
					SpecTrek.Instance.Federation.Enterprise.Propulsions!.SetImpulseDrive(direction, power);
				}
			}
		}
	}
}
