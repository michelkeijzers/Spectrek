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
		
		public static EEvent Execute(BaseShip baseShip)
		{
			Enterprise enterprise = SpecTrek.Instance.Federation.Enterprise;
			EEvent baseShipEvent = EEvent.DockingAllowed;
			if (baseShip.IsDestroyed)
			{
				enterprise.DamagePercentage = 100.0;
				baseShipEvent = EEvent.EnterpriseHitDestroyedBaseShip;
			}
			else if (baseShip.Sector!.Quadrant.CountKlingons() > 0)
			{
				baseShipEvent = EEvent.CannotDockBecauseOfKlingonsAround;
			}
			else if (enterprise.IsHealthy)
			{
				baseShipEvent = EEvent.EnterpriseTooHealthy;
			}
			return baseShipEvent;
		}
	}
}
