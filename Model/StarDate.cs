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

		public int Year { get; private set; } // Fixed 24(00)
		
		public int Day { get; set; } // 10000 days in one year
	}
}