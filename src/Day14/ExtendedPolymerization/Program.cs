using ExtendedPolymerization;

var lines = File.ReadAllLines("input.txt").ToList();

var polymer = Polymer.BuildPolymer(lines);

for (var i = 0; i < 10; i++) polymer.DoStep();

Console.WriteLine($"The Polymer Score for '{polymer.Template}' after 10 steps is: {polymer.GetPolymerScore()}");
