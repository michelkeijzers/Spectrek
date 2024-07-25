namespace AsciiGames
{
	public class SpecTrek
	{
		public static SpecTrek Instance { get { return _instance ??= new SpecTrek(); } }

		private SpecTrek()
		{
			StarDate = new();
			MilkyWay = new();
			Federation = new();
			KlingonShips = new();
		}

		public void Init()
		{
			//_milkyWay.Init();
			Federation.Init();
			KlingonShips.Init();
			StarDate.Init();
		}


		public enum EEndOfGameStatus
		{
			None,
			ExitedMilkyWay,
			EnergyDepleted,
			NoTimeLeft
		}

		public EEndOfGameStatus CheckEndOfGame()
		{
			EEndOfGameStatus status = EEndOfGameStatus.None;
			if (!Federation.Enterprise.IsWithinMilkyWay)
			{
				status = EEndOfGameStatus.ExitedMilkyWay;
			}
			else if (Federation.Enterprise.Energy < 0)
			{
				status = EEndOfGameStatus.EnergyDepleted;
			}
			else if (StarDate.Year >= 2405)
			{
				status = EEndOfGameStatus.NoTimeLeft;
			}
			return status;
		}

		public MilkyWay MilkyWay { get; private set; }

		public Federation Federation { get; private set; }

		public KlingonShipCollection KlingonShips { get; private set; }

		public StarDate StarDate { get; private set; }	
				
		private static SpecTrek? _instance;
	}
}