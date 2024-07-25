using AsciiGames;

namespace AsciiGames
{
	public class CommandQuitGame : Command
	{
		public override ConsoleKey Key { get { return ConsoleKey.Q; } }

		public override string KeyString {  get { return "Q";  } }

		public override string Text {  get { return "Quit Game"; } }

		public override bool CanExecute()
		{
			return true;
		}

		public override void Execute()
		{
			UserCommandSelector.IsQuitCommandIssued = true;
		}
	}
}
