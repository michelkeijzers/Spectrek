using AsciiGames;

namespace AsciiGames
{
	public class CommandDock : Command
	{
		public CommandDock()
		{
			_baseShipToDock = null;
		}

		public override ConsoleKey Key { get { return ConsoleKey.D; } }

		public override string KeyString {  get { return "D"; } }

		public override string Text {  get { return "Dock"; } }

		public override bool CanExecute()
		{
			bool canDock = true;
			Federation federation = SpecTrek.Instance.Federation;
			_baseShipToDock = federation.BaseShips.BaseShips.FirstOrDefault(
				baseShip => !baseShip.IsDestroyed && (baseShip.Sector == federation.Enterprise.Sector));
			canDock = _baseShipToDock != null;
			canDock &= federation.Enterprise.Sector!.Quadrant.CountKlingons() == 0;
			return canDock;
		}

		public override void Execute()
		{
			SpecTrek.Instance.Federation.Enterprise.DockWithBaseShip();
		}

		private BaseShip? _baseShipToDock;
	}
}
