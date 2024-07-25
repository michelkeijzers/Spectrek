using AsciiGames;

namespace AsciiGames
{
	public class CommandMove : Command
	{
		public override ConsoleKey Key { get { return ConsoleKey.M; } }

		public override string KeyString {  get { return "M"; } }

		public override string Text {  get { return "Move"; } }

		public override bool CanExecute()
		{
			return true;
		}

		public override void Execute()
		{
			SpecTrek.Instance.Federation.Enterprise.Propulsions!.Move();
		}
	}
}
