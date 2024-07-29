using AsciiGames;
using System.Numerics;

namespace AsciiGames
{
	public class CommandShields : Command
	{
		public override ConsoleKey Key { get { return ConsoleKey.S; } }

		public override string KeyString {  get { return "S"; } }

		public override string Text {  get { return "Shields"; } }

		public override bool CanExecute()
		{
			Enterprise enterprise = SpecTrek.Instance.Federation.Enterprise;
			bool canExecute = true;
			if (!enterprise.Shields.Enabled)
			{
				canExecute = enterprise.Energy >= 100;
				if (!canExecute)
				{
					ConsolePlus.WriteLineWithColor(ConsoleColor.Red, "Not enough energy for shields");
				}
			}
			return canExecute;
		}

		public override void Execute()
		{
			Enterprise enterprise = SpecTrek.Instance.Federation.Enterprise;
			enterprise.Shields.Enabled = !enterprise.Shields.Enabled;
		}
	}
}
