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
			Day = 0;
		}

		public void ElapseTime()
		{
			Day++;
		}

		public void Print()
		{
			Console.WriteLine($"Star Date: {Date}");
		}

		private string Date
		{
			get
			{
				return $"{Year:2}{Day:2}";
			}
		}

		public int Year { get; private set; } // Fixed 24(00)
		
		public int Day { get; private set; } // 100 days in one year
	}
}