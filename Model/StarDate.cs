using System;

namespace AsciiGames
{
	public class StarDate
	{
		public StarDate()
		{
		}

		public void Init()
		{
			Year = 24;
			Day = 1;
		}

		public void ElapseTime()
		{
			Day++;
		}

		public int Year { get; private set; } // Fixed 24(00)
		
		public int Day { get; private set; } // 100 days in one year
	}
}