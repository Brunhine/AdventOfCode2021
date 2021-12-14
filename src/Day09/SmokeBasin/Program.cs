using SmokeBasin;

var heightMap = new HeightMap("input.txt");

var lowSpots = heightMap.GetLowSpots();
var sum = lowSpots.Sum(x => x.DangerLevel);
Console.WriteLine($"The sum of risk levels on all low points is: {sum}");

var basins = heightMap.GetBasins();
var topThree = basins.OrderByDescending(x => x.Size).Take(3).ToList();
var largestBasinsProduct = topThree[0].Size * topThree[1].Size * topThree[2].Size;
Console.WriteLine($"The product of the size of the three largest basins is: {largestBasinsProduct}");
