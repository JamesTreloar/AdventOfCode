namespace AdventOfCode;

public class Day6 {
	public static int Part1(List<string> input) {
		int count = 1;
		List<List<bool>> positions = new();
		int xpos = 0;
		int ypos = 0;
		int direction = 0;
		for (int i = 0; i < input.Count; i++) {
			positions.Add(new (new bool[input[i].Length]));
			for (int j = 0; j < input[i].Length; j++) {
				if (input[i][j] == '^') {
					positions[i][j] = true;
					xpos = j;
					ypos = i;
				}
			}
		}

		bool end = false;

		while (!end) {
			switch (direction) {
				case 0:
					if (!positions[ypos][xpos]) {
						positions[ypos][xpos] = true;
						count++;
					}

					if (ypos == 0) {
						end = true;
					} else {
						if (input[ypos - 1][xpos] == '#') {
							direction = 1;
						} else {
							ypos--;
						}
					}

					break;
				case 1:
					if (!positions[ypos][xpos]) {
						positions[ypos][xpos] = true;
						count++;
					}
					
					if (xpos == positions[ypos].Count - 1) {
						end = true;
					} else {
						if (input[ypos][xpos + 1] == '#') {
							direction = 2;
						} else {
							xpos++;
						}
					}

					break;
				case 2:
					if (!positions[ypos][xpos]) {
						positions[ypos][xpos] = true;
						count++;
					}

					if (ypos == positions.Count - 1) {
						end = true;
					} else {
						if (input[ypos + 1][xpos] == '#') {
							direction = 3;
						} else {
							ypos++;
						}
					}

					break;
				
				case 3:
					if (!positions[ypos][xpos]) {
						positions[ypos][xpos] = true;
						count++;
					}
					
					if (xpos == 0) {
						end = true;
					} else {
						if (input[ypos][xpos - 1] == '#') {
							direction = 0;
						} else {
							xpos--;
						}
					}

					break;
			}
		}
		
		
		return count;
	}
	
	public static int Part2(List<string> input) {
		int count = 0;
		List<List<bool>> positions = new();
		int xpos = 0;
		int ypos = 0;
		int sxpos = 0;
		int sypos = 0;
		int direction = 0;
		for (int i = 0; i < input.Count; i++) {
			positions.Add(new (new bool[input[i].Length]));
			for (int j = 0; j < input[i].Length; j++) {
				if (input[i][j] == '^') {
					positions[i][j] = true;
					xpos = j;
					ypos = i;
					sxpos = j;
					sypos = i;
				}
			}
		}

		bool end = false;

		while (!end) {
			if (!positions[ypos][xpos]) {
				positions[ypos][xpos] = true;
			}
			switch (direction) {
				case 0:
					if (ypos == 0) {
						end = true;
					} else {
						if (input[ypos - 1][xpos] == '#') {
							direction = 1;
						} else {
							ypos--;
						}
					}

					break;
				case 1:
					if (xpos == positions[ypos].Count - 1) {
						end = true;
					} else {
						if (input[ypos][xpos + 1] == '#') {
							direction = 2;
						} else {
							xpos++;
						}
					}

					break;
				case 2:
					if (ypos == positions.Count - 1) {
						end = true;
					} else {
						if (input[ypos + 1][xpos] == '#') {
							direction = 3;
						} else {
							ypos++;
						}
					}

					break;
				
				case 3:
					if (xpos == 0) {
						end = true;
					} else {
						if (input[ypos][xpos - 1] == '#') {
							direction = 0;
						} else {
							xpos--;
						}
					}
					break;
			}
		}

		for (int i = 0; i < positions.Count; i++) {
			for (int j = 0; j < positions[i].Count; j++) {
				if (positions[i][j]) {
					string temp = input[i];
					string test = input[i][..j] + '#' + input[i][(j+1)..];
					input[i] = test;
					if (HasLoops(input, sxpos, sypos)) {
						count++;
					}
					input[i] = temp;
				}
			}
		}
		
		return count;
	}

	private static bool HasLoops(List<string> input, int xpos, int ypos) {
		List<List<int>> positions = new();
		// using bitwise to store direction
		int direction = 1;
		for (int i = 0; i < input.Count; i++) {
			positions.Add(new (new int[input[i].Length]));
		}

		bool loops = false;
		
		bool end = false;

		while (!end) {
			if ((positions[ypos][xpos] & direction) == 0) {
				positions[ypos][xpos] |= direction;
			} else {
				end = true;
				loops = true;
			}

			switch (direction) {
				case 1:
					if (ypos == 0) {
						end = true;
					} else {
						if (input[ypos - 1][xpos] == '#') {
							direction = 2;
						} else {
							ypos--;
						}
					}

					break;
				case 2:
					if (xpos == positions[ypos].Count - 1) {
						end = true;
					} else {
						if (input[ypos][xpos + 1] == '#') {
							direction = 4;
						} else {
							xpos++;
						}
					}

					break;
				case 4:
					if (ypos == positions.Count - 1) {
						end = true;
					} else {
						if (input[ypos + 1][xpos] == '#') {
							direction = 8;
						} else {
							ypos++;
						}
					}

					break;
				
				case 8:
					if (xpos == 0) {
						end = true;
					} else {
						if (input[ypos][xpos - 1] == '#') {
							direction = 1;
						} else {
							xpos--;
						}
					}
					break;
			}
		}
		
		
		return loops;
	}
}