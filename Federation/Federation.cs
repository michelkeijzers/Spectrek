namespace AsciiGames
{
	public class Federation
	{
		public Federation()
		{
			Enterprise = new Enterprise();
			BaseShips = new BaseShipCollection();
		}
		public void Init()
		{
			Enterprise.Init();
			BaseShips.Init();
		}

		public Enterprise Enterprise { get; private set; }

		public BaseShipCollection BaseShips { get; private set; }
	}
}