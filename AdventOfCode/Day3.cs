using System.Text.RegularExpressions;

namespace AdventOfCode;

public class Day3 {
	public static int Part1(List<string> input) {
		int count = 0;
		foreach (string se in input) {
			MatchCollection matches = Regex.Matches(se, @"mul\(\d+,\d+\)");
			foreach (Match match in matches) {
				string[] nums  = match.Value.Substring(4, match.Value.Length - 5).Split(",");
				count += int.Parse(nums[0]) * int.Parse(nums[1]);
			}
		}
		return count;
	}
	
	public static int Part2(List<string> input) {
		int count = 0;
		bool mul = true;
		foreach (string se in input) {
			MatchCollection matches = Regex.Matches(se, @"(mul\(\d+,\d+\))|(do\(\))|(don't\(\))");
			foreach (Match match in matches) {
				if (match.Value[2] == '(') {
					mul = true;
				} else if (match.Value[2] == 'n') {
					mul = false;
				} else if (mul) {
					string[] nums = match.Value.Substring(4, match.Value.Length - 5).Split(",");
					count += int.Parse(nums[0]) * int.Parse(nums[1]);
				}
			}
		}
		return count;
	}
}