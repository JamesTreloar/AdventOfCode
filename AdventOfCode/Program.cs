using System.Diagnostics;

namespace AdventOfCode;

internal static class Program {
	public static void Main(string[] args) {
		string day = "day1";
		List<string> input = GeneralFuncs.ReadFile(day);
		
		// Console.WriteLine(Day1.Part1(input));
		Console.WriteLine(Day1.Part2(input));
	}
}