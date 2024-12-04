namespace AdventOfCode;

public class Day4 {
	public static int Part1(List<string> input) {
		int count = 0;
		for (int i = 0; i < input.Count; i++) {
			for (int j = 0; j < input.Count - 3; j++) {
				if (input[i][j] == 'X' && input[i][j+1] == 'M' && input[i][j+2] == 'A' && input[i][j+3] == 'S') {
					count++;
				}
				if (input[i][j] == 'S' && input[i][j + 1] == 'A' && input[i][j + 2] == 'M' && input[i][j + 3] == 'X') {
					count++;
				}
			}
		}

		for (int i = 0; i < input.Count - 3; i++) {
			for (int j = 0; j < input.Count; j++) {
				if (input[i][j] == 'X' && input[i + 1][j] == 'M' && input[i + 2][j] == 'A' && input[i+3][j] == 'S') {
					count++;
				}
				if (input[i][j] == 'S' && input[i + 1][j] == 'A' && input[i + 2][j] == 'M' && input[i + 3][j] == 'X') {
					count++;
				}
			}
		}

		for (int i = 0; i < input.Count - 3; i++) {
			for (int j = 0; j < input.Count - 3; j++) {
				if (input[i][j] == 'X' && input[i + 1][j + 1] == 'M' && input[i + 2][j + 2] == 'A' &&
				    input[i + 3][j + 3] == 'S') {
					count++;
				}

				if (input[i][j] == 'S' && input[i + 1][j + 1] == 'A' && input[i + 2][j + 2] == 'M' &&
				    input[i + 3][j + 3] == 'X') {
					count++;
				}
			}
		}

		for (int i = 3; i < input.Count; i++) {
			for (int j = 0; j < input.Count - 3; j++) {
				if (input[i][j] == 'X' && input[i - 1][j + 1] == 'M' && input[i - 2][j + 2] == 'A' &&
				    input[i - 3][j + 3] == 'S') {
					count++;
				}
				
				if (input[i][j] == 'S' && input[i - 1][j + 1] == 'A' && input[i - 2][j + 2] == 'M' &&
				    input[i - 3][j + 3] == 'X') {
					count++;
				}
			}
		}
		
		return count;
	}
	
	public static int Part2(List<string> input) {
		int count = 0;
		for (int i = 0; i < input.Count - 2; i++) {
			for (int j = 0; j < input.Count - 2; j++) {
				if (input[i + 1][j + 1] == 'A') {
					if (input[i][j] == 'M' && input[i][j + 2] == 'M' && input[i + 2][j] == 'S' &&
					    input[i + 2][j + 2] == 'S') {
						count++;
					}
					if (input[i][j] == 'S' && input[i][j + 2] == 'S' && input[i + 2][j] == 'M' &&
					    input[i + 2][j + 2] == 'M') {
						count++;
					}
					if (input[i][j] == 'M' && input[i][j + 2] == 'S' && input[i + 2][j] == 'M' &&
					    input[i + 2][j + 2] == 'S') {
						count++;
					}
					if (input[i][j] == 'S' && input[i][j + 2] == 'M' && input[i + 2][j] == 'S' &&
					    input[i + 2][j + 2] == 'M') {
						count++;
					}
				}
			}
		}
		return count;
	}
}