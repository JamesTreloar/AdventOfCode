namespace AdventOfCode;

public class Day11 {
	public static long Part1(List<string> input) {
		Dictionary<long, long> numbers = new();
		foreach (string se in input[0].Split(' ')) {
			if (numbers.ContainsKey(long.Parse(se))) {
				numbers[long.Parse(se)]++;
			} else {
				numbers.Add(long.Parse(se), 1);
			}
		}

		for (int i = 0; i < 25; i++) {
			Dictionary<long, long> newNumbers = new();
			foreach (var keyValuePair in numbers) {
				long current = keyValuePair.Key;
				if (current == 0) {
					if (!newNumbers.ContainsKey(1)) {
						newNumbers.Add(1, keyValuePair.Value);
					} else {
						newNumbers[1] += keyValuePair.Value;
					}
				} else if (((long)Math.Abs(Math.Log10(current)) + 1) % 2 == 0) {
					ReadOnlySpan<char> temp = current.ToString().AsSpan();
					long left = long.Parse(temp[..(temp.Length / 2)]);
					long right = long.Parse(temp[(temp.Length / 2)..]);
					
					if (!newNumbers.ContainsKey(left)) {
						newNumbers.Add(left, keyValuePair.Value);
					} else {
						newNumbers[left] += keyValuePair.Value;
					}
					
					if (!newNumbers.ContainsKey(right)) {
						newNumbers.Add(right, keyValuePair.Value);
					} else {
						newNumbers[right] += keyValuePair.Value;
					}
				} else {
					if (!newNumbers.ContainsKey(current * 2024)) {
						newNumbers.Add(current * 2024, keyValuePair.Value);
					} else {
						newNumbers[current * 2024] += keyValuePair.Value;
					}
				}
			}
			numbers = newNumbers;
		}

		return numbers.Sum(keyValuePair => keyValuePair.Value);
	}
	
	public static long Part2(List<string> input) {
		Dictionary<long, long> numbers = new();
		foreach (string se in input[0].Split(' ')) {
			if (numbers.ContainsKey(long.Parse(se))) {
				numbers[long.Parse(se)]++;
			} else {
				numbers.Add(long.Parse(se), 1);
			}
		}

		for (int i = 0; i < 75; i++) {
			Dictionary<long, long> newNumbers = new();
			foreach (var keyValuePair in numbers) {
				long current = keyValuePair.Key;
				if (current == 0) {
					if (!newNumbers.ContainsKey(1)) {
						newNumbers.Add(1, keyValuePair.Value);
					} else {
						newNumbers[1] += keyValuePair.Value;
					}
				} else if (((long)Math.Abs(Math.Log10(current)) + 1) % 2 == 0) {
					ReadOnlySpan<char> temp = current.ToString().AsSpan();
					long left = long.Parse(temp[..(temp.Length / 2)]);
					long right = long.Parse(temp[(temp.Length / 2)..]);
					
					if (!newNumbers.ContainsKey(left)) {
						newNumbers.Add(left, keyValuePair.Value);
					} else {
						newNumbers[left] += keyValuePair.Value;
					}
					
					if (!newNumbers.ContainsKey(right)) {
						newNumbers.Add(right, keyValuePair.Value);
					} else {
						newNumbers[right] += keyValuePair.Value;
					}
				} else {
					if (!newNumbers.ContainsKey(current * 2024)) {
						newNumbers.Add(current * 2024, keyValuePair.Value);
					} else {
						newNumbers[current * 2024] += keyValuePair.Value;
					}
				}
			}
			numbers = newNumbers;
		}

		return numbers.Sum(keyValuePair => keyValuePair.Value);
	}
}