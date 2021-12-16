using TransparentOrigami;

var input = File.ReadAllLines("input.txt");
var paper = new Paper(input);
paper.DoFolds(1);

Console.WriteLine($"After 1 Fold, there are {paper.VisibleDots.Count} visible dots.");
Console.WriteLine();
Console.WriteLine("After doing all of the folds as instructed, the following code appears:");

paper = new Paper(input);
paper.DoFolds();

var dots = paper.VisibleDots;
var width = dots.Max(d => d.X);
var height = dots.Max(d => d.Y);

var comp = new PositionComparer();

for (var h = 0; h <= height; h++)
{
    for (var w = 0; w <= width; w++) Console.Write(dots.Contains(new Position(w, h), comp) ? "#" : " ");
    Console.WriteLine();
}
