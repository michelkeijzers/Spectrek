namespace AsciiGames
{
	public class BaseShip : Ship
	{
		public double DamagePercentage { get; set; } = 0.0;

		public bool IsDestroyed {  get { return DamagePercentage >= 99.95;  } }
	}
}
