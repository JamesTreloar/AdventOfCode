namespace AdventOfCode;

public class Day7 {
	public static long Part1(List<string> input) {
		long count = 0;
		List<List<long>> data = new();
		foreach (string se in input) {
			string[] split = se.Split(" ");
			split[0] = split[0].Replace(":", "");
			List<long> n = split.Select(long.Parse).ToList();
			data.Add(n);
		}

		for (int i = 0; i < data.Count; i++) {
			if (HasWay(data[i][0], data[i].Skip(1).ToList())) {
				count += data[i][0];
			}
		}
		
		return count;
	}

	private static bool HasWay(long goal, List<long> ops) {
		if (ops.Count == 1) {
			return ops[0] == goal;
		}

		long first = ops[0] + ops[1];
		long second = ops[0] * ops[1];
		List<long> next = ops.Skip(2).ToList();
		next.Insert(0, first);
		if (HasWay(goal, next)) {
			return true;
		}

		next[0] = second;
		return HasWay(goal, next);
	}

	public static long Part2(List<string> input) {
		long count = 0;
		List<List<long>> data = new();
		foreach (string se in input) {
			string[] split = se.Split(" ");
			split[0] = split[0].Replace(":", "");
			List<long> n = split.Select(long.Parse).ToList();
			data.Add(n);
		}

		for (int i = 0; i < data.Count; i++) {
			if (HasWay2(data[i][0], data[i].Skip(1).ToList())) {
				count += data[i][0];
			}
		}
		
		return count;
	}
	
	private static bool HasWay2(long goal, List<long> ops) {
		if (ops.Count == 1) {
			return ops[0] == goal;
		}

		long first = ops[0] + ops[1];
		long second = ops[0] * ops[1];
		string a = ops[0].ToString();
		string b = ops[1].ToString();
		long third = long.Parse(a + b);
		List<long> next = ops.Skip(2).ToList();
		next.Insert(0, first);
		if (HasWay2(goal, next)) {
			return true;
		}

		next[0] = second;
		
		if (HasWay2(goal, next)) {
			return true;
		}
		
		next[0] = third;
		return HasWay2(goal, next);
	}
}