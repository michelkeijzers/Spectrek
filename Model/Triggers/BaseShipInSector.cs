namespace AsciiGames
{
	public class BaseShipInSector
	{
		public enum EEvent
		{
			DockingAllowed,
			EnterpriseHitDestroyedBaseShip,
			CannotDockBecauseOfKlingonsAround,
			EnterpriseTooHealthy
		}
		
		public static void Execute(BaseShip baseShip)
		{
			Enterprise enterprise = SpecTrek.Instance.Federation.Enterprise;
			Event = EEvent.DockingAllowed;
			if (baseShip.IsDestroyed)
			{
				enterprise.DamagePercentage = 100.0;
				Event = EEvent.EnterpriseHitDestroyedBaseShip;
			}
			else if (baseShip.Sector!.Quadrant.CountKlingons() > 0)
			{
				Event = EEvent.CannotDockBecauseOfKlingonsAround;
			}
			else if (enterprise.IsHealthy)
			{
				Event = EEvent.EnterpriseTooHealthy;
			}
		}

		public static EEvent Event { get; private set; }
	}
}
