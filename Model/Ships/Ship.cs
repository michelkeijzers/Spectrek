namespace AsciiGames
{
	public class Ship
	{
		public enum EStatus
		{
			Active,
			DestroyedByFederation,
			DestroyedByKlingons
		}

		public Ship()
		{
		}

		public virtual Sector? Sector { get; set; }

		public double DamagePercentage { get; set; } = 0.0;

		public EStatus Status { get; private set; }

		public bool IsDestroyed { get { return Status == EStatus.Active; } }

	}
}
