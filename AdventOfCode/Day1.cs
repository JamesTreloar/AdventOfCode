namespace AdventOfCode;

public class Day1 {
	public static int Part1(List<string> input) {
		List<int> left = new();
		List<int> right = new();
		foreach (string se in input) {
			string[] s = se.Split(" ").Where(x => x != "").ToArray();
			left.Add(int.Parse(s[0]));
			right.Add(int.Parse(s[1]));
		}

		left.Sort();
		right.Sort();
		int count = 0;
		for (int i = 0; i < left.Count; i++) {
			count += Math.Abs(left[i] - right[i]);
		}
		return count;
	}
	
	public static int Part2(List<string> input) {
		List<int> left = new();
		List<int> right = new();
		foreach (string se in input) {
			string[] s = se.Split(" ").Where(x => x != "").ToArray();
			left.Add(int.Parse(s[0]));
			right.Add(int.Parse(s[1]));
		}

		
		int count = 0;
		foreach (int i in left) {
			count += i* right.Count(x => x == i);
			
		}
		
		
		return count;
	}
}