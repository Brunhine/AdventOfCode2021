using DumboOctopus;

var grid = new OctopusGrid("input.txt");

for (var i = 0; i < 100; i++) grid.DoStep();

Console.WriteLine($"After 100 steps, there were {grid.TotalFlashes} flashes");

grid = new OctopusGrid("input.txt");
var step = 1;

while (grid.DoStep() != 100) step++;

Console.WriteLine($"All octopuses flash on step: {step}");
