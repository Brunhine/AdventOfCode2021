using SmokeBasin;

var heightMap = new HeightMap("input.txt");

var lowSpots = heightMap.GetLowSpots();

var sum = lowSpots.Sum(x => x + 1);

Console.WriteLine($"The sum of risk levels on all low points is: {sum}");