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
			Year = 2400;
			Day = 1;
		}

		public int Year { get; private set; } // Fixed 24(00)

		private int _day;
		public int Day 
		{
			get
			{
				return _day;
			}
			set
			{
				_day = value;
				while (_day >= 100)
				{
					_day -= 100;
					Year++;
				}
			}
		}
	}
}