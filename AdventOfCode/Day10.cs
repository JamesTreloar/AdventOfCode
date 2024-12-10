namespace AdventOfCode;

public class Day10 {
	public static int Part1(List<string> input) {
		int count = 0;
		List<List<int>> heights = input.Select(se => se.Select(c => c - '0').ToList()).ToList();
		for (int i = 0; i < heights.Count; i++) {
			for (int j = 0; j < heights[i].Count; j++) {
				if (heights[i][j] == 0) {
					count += Search(0, i, j, heights).Count;
				}
			}
		}
		return count;
	}

	private static HashSet<(int y, int x)> Search(int current, int ypos, int xpos, List<List<int>> heights) {
		if (heights[ypos][xpos] == 9) {
			return new([(ypos, xpos)]);
		}

		HashSet<(int y, int x)> result = new();
		if (xpos > 0) {
			if (heights[ypos][xpos - 1] == current + 1) {
				result.UnionWith(Search(current + 1, ypos, xpos - 1, heights));
			}
		}
		
		if (ypos > 0) {
			if (heights[ypos -1][xpos] == current + 1) {
				result.UnionWith(Search(current+1, ypos - 1, xpos, heights));
			}
		}

		if (xpos < heights[ypos].Count - 1) {
			if (heights[ypos][xpos + 1] == current + 1) {
				result.UnionWith(Search(current+1, ypos, xpos + 1, heights));
			}
		}
		
		if (ypos < heights.Count - 1) {
			if (heights[ypos + 1][xpos] == current + 1) {
				result.UnionWith(Search(current+1, ypos + 1, xpos, heights));
			}
		}
		
		return result; 
	}
	
	
	public static int Part2(List<string> input) {
		int count = 0;
		List<List<int>> heights = input.Select(se => se.Select(c => c - '0').ToList()).ToList();
		for (int i = 0; i < heights.Count; i++) {
			for (int j = 0; j < heights[i].Count; j++) {
				if (heights[i][j] == 0) {
					count += Search2(0, i, j, heights);
				}
			}
		}
		return count;
	}
	
	private static int Search2(int current, int ypos, int xpos, List<List<int>> heights) {
		if (heights[ypos][xpos] == 9) {
			return 1;
		}

		int tempSum = 0;
		if (xpos > 0) {
			if (heights[ypos][xpos - 1] == current + 1) {
				tempSum += Search2(current+1, ypos, xpos-1, heights);
			}
		}
		
		if (ypos > 0) {
			if (heights[ypos -1][xpos] == current + 1) {
				tempSum += Search2(current+1, ypos - 1, xpos, heights);
			}
		}

		if (xpos < heights[ypos].Count - 1) {
			if (heights[ypos][xpos + 1] == current + 1) {
				tempSum += Search2(current+1, ypos, xpos + 1, heights);
			}
		}
		
		if (ypos < heights.Count - 1) {
			if (heights[ypos + 1][xpos] == current + 1) {
				tempSum += Search2(current+1, ypos + 1, xpos, heights);
			}
		}
		
		return tempSum; 
	}

}