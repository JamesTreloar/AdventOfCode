namespace AdventOfCode;

public class Day5 {
	public static int Part1(List<string> input) {
		int count = 0;
		List<(int, int)> orderings = new();
		List<List<int>> pages = new();
		foreach (string line in input) {
			if (line == "") {
				continue;
			}
			if (line[2] == '|') {
				string[] split = line.Split('|');
				orderings.Add((int.Parse(split[0]), int.Parse(split[1])));
			} else {
				string[] split = line.Split(',');
				List<int> temp = split.Select(int.Parse).ToList();
				pages.Add(temp);
			}
		}

		for (int run = 0; run < pages.Count; run++) {
			bool good = true;
			HashSet<int> later = pages[run].ToHashSet();
			for (int j = 0; j < pages[run].Count; j++) {
				later.Remove(pages[run][j]);
				for (int k = 0; k < orderings.Count; k++) {
					if (orderings[k].Item2 == pages[run][j] && later.Contains(orderings[k].Item1)) {
						good = false;
						break;
					}
				}
			}

			if (good) {
				count += pages[run][pages[run].Count/2];
			}
		}

		return count;
	}
	
	public static int Part2(List<string> input) {
		int count = 0;
		List<(int, int)> orderings = new();
		List<List<int>> pages = new();
		
		foreach (string line in input) {
			if (line == "") {
				continue;
			}
			if (line[2] == '|') {
				string[] split = line.Split('|');
				orderings.Add((int.Parse(split[0]), int.Parse(split[1])));
			} else {
				string[] split = line.Split(',');
				List<int> temp = split.Select(int.Parse).ToList();
				pages.Add(temp);
			}
		}
		
		foreach (List<int> run in pages) {
			bool good = true;
			HashSet<int> later = run.ToHashSet();
			for (int j = 0; j < run.Count; j++) {
				later.Remove(run[j]);
				for (int k = 0; k < orderings.Count; k++) {
					if (orderings[k].Item2 == run[j] && later.Contains(orderings[k].Item1)) {
						int a = run.FindIndex(x => x == orderings[k].Item1);
						run.Insert(a+1, run[j]);
						run.RemoveAt(j);

						later.Remove(run[j]);
						later.Add(orderings[k].Item2);
						good = false;
						k = 0;
					}
				}
			}
			if (!good) {
				count += run[run.Count/2];
			}
		}

		return count;
	}
}