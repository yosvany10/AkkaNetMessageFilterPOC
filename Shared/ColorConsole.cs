using System;
using System.Collections.Generic;
using System.Text;

namespace Shared
{
    public static class ColorConsole
    {
		public static void PrintLine(string text, ConsoleColor color)
		{
			var prevColor = Console.BackgroundColor;
			Console.BackgroundColor = color;
			Console.WriteLine(text);
			Console.BackgroundColor = prevColor;
		}

		public static void Print(string text, ConsoleColor color)
		{
			var prevColor = Console.BackgroundColor;
			Console.BackgroundColor = color;
			Console.Write(text);
			Console.BackgroundColor = prevColor;
		}
    }
}
