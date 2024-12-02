namespace AdventOfCode;

public class Day2 {
	public static int Part1(List<string> input) {
		List<List<int>> reports = new();
		foreach (string se in input) {
			string[] split = se.Split(' ');
			List<int> row = split.Select(int.Parse).ToList();
			reports.Add(row);
		}

		return reports.Count(IsSafe);
	}
	
	public static int Part2(List<string> input) {
		int count = 0;
		List<List<int>> reports = new();
		foreach (string se in input) {
			string[] split = se.Split(' ');
			List<int> row = split.Select(int.Parse).ToList();
			reports.Add(row);
		}

		foreach (List<int> row in reports) {
			if (IsSafe(row)) {
				count++;
				continue;
			}

			for (int i = 0; i < row.Count; i++) {
				List<int> t = row.GetRange(0, row.Count);
				t.RemoveAt(i);

				if (IsSafe(t)) {
					count++;
					break;
				}
			}
		}

		return count;
	}


	private static bool IsSafe(List<int> report) {
		bool increasing = report[1] > report[0];
		bool good = true;
		for (int i = 1; i < report.Count; i++) {
			if (increasing) {
				if (report[i] - report[i - 1] is >= 1 and <= 3) {
				} else {
					good = false;
					break;
				}
			} else {
				if ((report[i] - report[i - 1])*-1 is >= 1 and <= 3) {
				} else {
					good = false;
					break;
				}
					
			}
		}
		return good;
	}
}