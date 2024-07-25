using System;

namespace AsciiGames
{

	public class ConsolePlus
	{
		public static void WriteWithColor(System.ConsoleColor color, string text)
		{
			StoreColors();
			Console.ForegroundColor = color;
			Console.Write(text);
			RestoreColors();
		}

		public static void WriteLineWithColor(System.ConsoleColor color, string text)
		{
			StoreColors();
			Console.ForegroundColor = color;
			Console.WriteLine(text);
			RestoreColors();
		}

		private static void StoreColors()
		{
			_foregroundColor = Console.ForegroundColor;
			_backgroundColor = Console.BackgroundColor;
		}

		private static void RestoreColors()
		{
			Console.ForegroundColor = _foregroundColor;
			Console.BackgroundColor = _backgroundColor;
		}

		private static System.ConsoleColor _foregroundColor;
		private static System.ConsoleColor _backgroundColor;
	}
}