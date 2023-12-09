namespace AdventOfCode2023;

internal class DaySix {
	const string _testSet = "Time: 7 15 30\r\nDistance: 9 40 200";
	const string _dataSet = "Time: 53 83 72 88\r\nDistance: 333 1635 1289 1532"; 

	public DaySix() {
		Console.WriteLine("\n*** Day Six ***\n");
		Console.WriteLine("Number of ways for multiple races: " + PartOne(_dataSet)); 
		Console.WriteLine("Number of ways for the big record: " + PartTwo(_dataSet));
	}

	private static int PartOne(string data) {
		return ValidTimes(MapTimeDistance(data)).Aggregate(1, (value, acc) => value * acc);
	}

	private static Dictionary<int, int> MapTimeDistance(string data) {
		string[] parts = data.Split("\r\n");
		string[] times = parts[0].Split(" ");
		string[] distances = parts[1].Split(" ");
		Dictionary<int, int> res = [];

        for(int i = 1; i < times.Length; i++) {
			res[int.Parse(times[i])] = int.Parse(distances[i]);
		}

        return res;
	}

	private static List<int> ValidTimes(Dictionary<int, int> inputs) {
		List<int> res = [];

		foreach(KeyValuePair<int, int> input in inputs) {
			List<int> ways = [];

			for(int i = 0; i < input.Key; i++) {
				if((input.Key - i) * i > input.Value) {
					ways.Add(i);
				}
			}

			res.Add(ways.Count);
		}

        return res;
	}

	private static int PartTwo(string data) {
		return Ways(data.Replace(" ", ""));
	}

	private static int Ways(string data) {
		List<int> res = [];
		string[] parts = data.Split("\r\n");

		long time = long.Parse(parts[0].Split(":")[1]);
		long distance = long.Parse(parts[1].Split(":")[1]);

		double delta = (time * time) - (4 * -1 * -distance);

		int s1 = (int) (-time + Math.Sqrt(delta)) / (2 * -1);
		int s2 = (int) (-time - Math.Sqrt(delta)) / (2 * -1);

		return Math.Abs(s1 - s2);
	}
}
