namespace AsciiGames
{
	public abstract class MoveCommand : Command
	{
		public static void HandleBaseShipInEnterpriseSector()
		{
			Enterprise enterprise = SpecTrek.Instance.Federation.Enterprise;
			if (enterprise.IsWithinMilkyWay)
			{
				BaseShip? baseShip = SpecTrek.Instance.Federation.BaseShips.GetBaseShipInQuadrant(
					enterprise.Sector!.Quadrant);
				if (baseShip != null)
				{
					BaseShipInSector.Execute(baseShip);
					ConsoleColor color = ConsoleColor.Blue;
					string message;
					switch (BaseShipInSector.Event)
					{
						case BaseShipInSector.EEvent.DockingAllowed:
							message = "The Enterprise is allowed to dock at the federation base ship.";
							break;

						case BaseShipInSector.EEvent.EnterpriseHitDestroyedBaseShip:
							color = ConsoleColor.Red;
							message = "The Enterprise hit a destroyed federation baseship, destroying the Enterprise.";
							break;

						case BaseShipInSector.EEvent.CannotDockBecauseOfKlingonsAround:
							message = "The Enterprise cannot dock because of Klingons present in the quadrant.";
							break;

						case BaseShipInSector.EEvent.EnterpriseTooHealthy:
							ConsolePlus.WriteLineWithColor(ConsoleColor.Blue,
							message = "federation ships will get priority.");
							break;

						default:
							throw new ApplicationException("Case");
					}

					ConsolePlus.WriteLineWithColor(color, message);
				}
			}
		}
	}
}
