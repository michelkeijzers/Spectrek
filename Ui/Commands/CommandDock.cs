using AsciiGames;

namespace AsciiGames
{
	public class CommandDock : Command
	{
		public override ConsoleKey Key { get { return ConsoleKey.D; } }

		public override string KeyString {  get { return "D"; } }

		public override string Text {  get { return "Dock"; } }

		public override bool CanExecute()
		{
			return false;
		}

		public override void Execute()
		{
			throw new NotImplementedException();
		}
	}
}
