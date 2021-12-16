namespace TransparentOrigami;

public class Paper
{
    private List<Position> Dots { get; }
    private List<FoldInstruction> FoldInstructions { get; }

    public List<Position> VisibleDots
    {
        get { return Dots.DistinctBy(d => new {d.X, d.Y}).ToList(); }
    }

    public Paper(IEnumerable<string> input)
    {
        Dots = new List<Position>();
        FoldInstructions = new List<FoldInstruction>();

        foreach (var line in input)
        {
            if (string.IsNullOrEmpty(line)) continue;

            if (line.StartsWith("fold along "))
            {
                var ins = line.Split(' ')[2].Split('=');
                FoldInstructions.Add(new FoldInstruction {Axis = char.Parse(ins[0]), Line = int.Parse(ins[1])});
            }
            else
            {
                var pos = line.Split(',');
                Dots.Add(new Position {X = int.Parse(pos[0]), Y = int.Parse(pos[1])});
            }
        }
    }

    public void DoFolds(int count)
    {
        for (var i = 0; i < count; i++)
        {
            var instruction = FoldInstructions[i];
            if (instruction.Axis == 'y')
                FoldUp(instruction.Line);
            else
                FoldLeft(instruction.Line);
        }
    }

    private void FoldLeft(int line)
    {
        var dotsToMove = Dots.Where(d => d.X > line);

        foreach (var dot in dotsToMove) dot.X = line - (dot.X - line);
    }

    private void FoldUp(int line)
    {
        var dotsToMove = Dots.Where(d => d.Y > line);

        foreach (var dot in dotsToMove) dot.Y = line - (dot.Y - line);
    }
}
