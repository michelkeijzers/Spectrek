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
			Enterprise enterprise = SpecTrek.Instance.Federation.Enterprise;
			enterprise.Propulsions!.Move();
			Sector? sector = enterprise.Sector;
			if (sector != null)
			{
				BaseShip? baseShip = SpecTrek.Instance.Federation.BaseShips.BaseShips.FirstOrDefault(
					baseShip => baseShip.Sector == sector);
				if (baseShip != null)
				{
					BaseShipInSector.Execute(baseShip);
					BaseShipInSector.EEvent baseShipEvent = BaseShipInSector.Event;
					switch (baseShipEvent)
					{
						case BaseShipInSector.EEvent.DockingAllowed:
							{
								ConsolePlus.WriteLineWithColor(ConsoleColor.Blue, "The Enterprise is allowed to dock.");
							}
							break;

						case BaseShipInSector.EEvent.EnterpriseHitDestroyedBaseShip:
							ConsolePlus.WriteLineWithColor(ConsoleColor.Blue,
								"The Enterprise is destroyed by flying into the debris of a destroyed base ship.");
							break;

						case BaseShipInSector.EEvent.CannotDockBecauseOfKlingonsAround:
							ConsolePlus.WriteLineWithColor(ConsoleColor.Blue,
								"The Enterprise is not allowed to dock when there are Klingons in the quadrant " +
								"because of safety regulations.");
							break;

						case BaseShipInSector.EEvent.EnterpriseTooHealthy:
							ConsolePlus.WriteLineWithColor(ConsoleColor.Blue,
								"The Enterprise is not allowed to dock because the Enterprise has a healthy state " +
								"and priority is given to other ships instead.");
							break;

						default:
							throw new ApplicationException("Case");
					}

				}
			}
		}
	}
}
