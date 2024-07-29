using AsciiGames;
using System.Numerics;

namespace AsciiGames
{
	public class CommandPhoton : Command
	{
		public override ConsoleKey Key { get { return ConsoleKey.P; } }

		public override string KeyString {  get { return "P"; } }

		public override string Text {  get { return "Photon"; } }

		public override bool CanExecute()
		{
			Enterprise enterprise = SpecTrek.Instance.Federation.Enterprise;
			return (enterprise.Weapons.Photons.NrOfPhotons > 0);
		}

		public override void Execute()
		{
			int horizontal = InputInteger("Shoot at horizontal", 0, Quadrant.HORIZONTAL_SECTORS - 1);
			if (horizontal != INVALID_NUMBER)
			{
				int vertical = InputInteger("Shoot at vertical", 0, Quadrant.VERTICAL_SECTORS - 1);
				if (vertical != INVALID_NUMBER)
				{
					ShootPhoton(horizontal - 1, vertical - 1);
					//Enterprise enterprise = SpecTrek.Instance.Federation.Enterprise;
					//enterprise.Propulsions!.SetImpulseDrive(horizontal, vertical);
					//enterprise.Propulsions!.CurrentPropulsion.Move(horizontal, vertical);
				}
			}
		}

		private static void ShootPhoton(int horizontal, int vertical)
		{
			Enterprise enterprise = SpecTrek.Instance.Federation.Enterprise;
			int diffHorizontal = horizontal - enterprise.Sector!.Horizontal;
			int diffVertical = vertical - enterprise.Sector!.Vertical;

			Vector2 diffVector = new(diffHorizontal, diffVertical);
			diffVector = Vector2.Normalize(diffVector);
			


			Sector? photonSector;
			int step = 1;
			do
			{
				SpecTrek.Instance.StarDate.Day += 1;

				int photonHorizontal = enterprise.Sector.Horizontal + (int)(Math.Round(step * diffVector.X));
				int photonVertical = enterprise.Sector.Vertical + (int)(Math.Round(step * diffVector.Y));

				
				photonSector = enterprise.Sector.Quadrant.GetSector(photonHorizontal, photonVertical);
				if (photonSector != null)
				{
					BaseShip? baseShip = photonSector.GetBaseShip();
					if (baseShip != null)
					{
						baseShip.DamagePercentage = 100.0;
						baseShip.Status = Ship.EStatus.DestroyedByFederation;
						ConsolePlus.WriteLineWithColor(ConsoleColor.Red, "Federation base ship destroyed by friendly fire.");
						photonSector = null;
					}
					else
					{
						KlingonShip? klingonShip = photonSector.GetKlingonShip();
						if (klingonShip != null)
						{
							klingonShip.DamagePercentage = 100.0;
							klingonShip.Status = Ship.EStatus.DestroyedByFederation;
							SpecTrek.Instance.KlingonShips.Ships.Remove(klingonShip);
							ConsolePlus.WriteLineWithColor(ConsoleColor.Green, "Klingon destroyed by Enterprise.");
							photonSector = null;
						}
					}
					step++;
				}
			} while (photonSector != null);
			enterprise.Weapons.Photons.NrOfPhotons--;
		}
	}
}
