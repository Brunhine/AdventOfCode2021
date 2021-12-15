using DumboOctopus;

var grid = new OctopusGrid("input.txt");

for (var i = 0; i < 100; i++) grid.DoStep();

Console.WriteLine($"After 100 steps, there were {grid.Flashes} flashes");
