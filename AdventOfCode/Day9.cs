namespace AdventOfCode;

public class Day9 {
	public static long Part1(List<string> input) {
		long count = 0;
		List<int> blocks = new();
		bool file = true;
		int fileId = 0;
		for (int i = 0; i < input[0].Length; i++) {
			if (file) {
				for (int j = 0; j < input[0][i] - '0'; j++) {
					blocks.Add(fileId);
				}
				fileId++;
				file = false;
			} else {
				for (int j = 0; j < input[0][i] - '0'; j++) {
					blocks.Add(-1);
				}

				file = true;
			}
		}

		int left = 0;
		int right = blocks.Count - 1;

		while (blocks[left] != -1) {
			left++;
		}

		while (blocks[right] == -1) {
			right--;
		}
		
		while (left < right) {
			blocks[left] = blocks[right];
			blocks[right] = -1;
			
			while (blocks[left] != -1) {
				left++;
			}

			while (blocks[right] == -1) {
				right--;
			}
		}

		int k = 0;
		while (blocks[k] != -1 && k < blocks.Count) {
			count += blocks[k] * k;
			k++;
		}
		
		return count;
	}
	
	public static long Part2(List<string> input) {
		long count = 0;
		List<(int length, int id)> files = new();
		bool file = true;
		int fileId = 0;
		for (int i = 0; i < input[0].Length; i++) {
			if (file) {
				files.Add((input[0][i] - '0', fileId));
				fileId++;
				file = false;
			} else {
				files.Add((input[0][i] - '0', -1));

				file = true;
			}
		}

		for (int j = files.Count - 1; j >= 0; j--) {
			if (files[j].id == -1) {
				continue;
			}
			for (int k = 1; k < j; k++) {
				if (files[k].id == -1) {
					if (files[k].length > files[j].length) {
						files[k] = (files[k].length - files[j].length, files[k].id);
						files.Insert(k, files[j]);
						j++;
						files[j] = (files[j].length, -1);
						break;
					} else if (files[k].length == files[j].length) {
						files[k] = files[j];
						files[j] = (files[j].length, -1);
						break;
					}
				}
			}
		}

		int pos = 0;
		for (int i = 0; i < files.Count; i++) {
			if (files[i].id == -1) {
				pos += files[i].length;
			} else {
				for (int j = 0; j < files[i].length; j++) {
					count += pos*files[i].id;
					pos++;
				}
			}
		}
		
		return count;
	}
}