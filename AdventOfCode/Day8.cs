namespace AdventOfCode;

public class Day8 {
	public static int Part1(List<string> input) {
		int xbound = input[0].Length;
		int ybound = input.Count;
		
		Dictionary<char, List<(int, int)>> nodes = new();
		HashSet<(int, int)> antinodes = new();

		for (int i = 0; i < input.Count; i++) {
			for (int j = 0; j < input[i].Length; j++) {
				if (input[i][j] != '.') {
					if (!nodes.ContainsKey(input[i][j])) {
						nodes.Add(input[i][j], new());
					}

					nodes[input[i][j]].Add((i, j));
				}
			}
		}
		
		foreach (var keyValuePair in nodes) {
			for (int i = 0; i < keyValuePair.Value.Count; i++) {
				for (int j = i+1; j < keyValuePair.Value.Count; j++) {
					(int, int) pos1 = keyValuePair.Value[i];
					(int, int) pos2 = keyValuePair.Value[j];
					int ydif = pos1.Item1 - pos2.Item1;
					int xdif = pos1.Item2 - pos2.Item2;

					int antiNodeTestY = pos1.Item1 + ydif;
					int antiNodeTestX = pos1.Item2 + xdif;
					if (antiNodeTestY < ybound && antiNodeTestX < xbound && antiNodeTestY >= 0&& antiNodeTestX >= 0) {
						antinodes.Add((antiNodeTestY, antiNodeTestX));
					}
					
					antiNodeTestY = pos1.Item1 - 2*ydif;
					antiNodeTestX = pos1.Item2 - 2*xdif;
					if (antiNodeTestY < ybound && antiNodeTestX < xbound && antiNodeTestY >= 0&& antiNodeTestX >= 0) {
						antinodes.Add((antiNodeTestY, antiNodeTestX));
					}
				}	
			}
		}
		
		return antinodes.Count;
	}
	
	public static int Part2(List<string> input) {
		int xbound = input[0].Length;
		int ybound = input.Count;
		
		Dictionary<char, List<(int, int)>> nodes = new();
		HashSet<(int, int)> antinodes = new();

		for (int i = 0; i < input.Count; i++) {
			for (int j = 0; j < input[i].Length; j++) {
				if (input[i][j] != '.') {
					if (!nodes.ContainsKey(input[i][j])) {
						nodes.Add(input[i][j], new());
					}

					nodes[input[i][j]].Add((i, j));
				}
			}
		}
		
		foreach (var keyValuePair in nodes) {
			for (int i = 0; i < keyValuePair.Value.Count; i++) {
				for (int j = i+1; j < keyValuePair.Value.Count; j++) {
					(int, int) pos1 = keyValuePair.Value[i];
					(int, int) pos2 = keyValuePair.Value[j];
					int ydif = pos1.Item1 - pos2.Item1;
					int xdif = pos1.Item2 - pos2.Item2;
					antinodes.Add(pos1);
					antinodes.Add(pos2);

					for (int k = 1; k < ybound; k++) {
						int antiNodeTestY = pos1.Item1 + k*ydif;
						int antiNodeTestX = pos1.Item2 + k*xdif;
						if (antiNodeTestY < ybound && antiNodeTestX < xbound && antiNodeTestY >= 0 &&
						    antiNodeTestX >= 0) {
							antinodes.Add((antiNodeTestY, antiNodeTestX));
						} else {
							break;
						}
					}

					for (int k = 2; k < ybound; k++) {
						int antiNodeTestY = pos1.Item1 - k * ydif;
						int antiNodeTestX = pos1.Item2 - k * xdif;
						if (antiNodeTestY < ybound && antiNodeTestX < xbound && antiNodeTestY >= 0 &&
						    antiNodeTestX >= 0) {
							antinodes.Add((antiNodeTestY, antiNodeTestX));
						} else {
							break;
						}
					}
				}	
			}
		}
		
		return antinodes.Count;
	}
}