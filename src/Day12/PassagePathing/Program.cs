using PassagePathing;

var lines = File.ReadAllLines("input.txt").ToList();

var graph = new Graph();

lines.ForEach(line =>
{
    var edge = line.Split('-');
    graph.AddEdge(edge[0], edge[1]);
});

var paths = graph.GetAllPaths("start", "end");

Console.WriteLine($"There are {paths} possible paths");
