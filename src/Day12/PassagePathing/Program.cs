using PassagePathing;

var lines = File.ReadAllLines("input.txt").ToList();

var graph = new Graph();

lines.ForEach(line =>
{
    var edge = line.Split('-');
    graph.AddEdge(edge[0], edge[1]);
});

var partOnePaths = graph.GetAllPaths("start", "end", PathingType.VisitOnce);
var partTwoPaths = graph.GetAllPaths("start", "end", PathingType.VisitOneTwice);

Console.WriteLine($"There are {partOnePaths} possible paths if you visit small caves once");
Console.WriteLine($"There are {partTwoPaths} possible paths if you visit one small cave twice");
