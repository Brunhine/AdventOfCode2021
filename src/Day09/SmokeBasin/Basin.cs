namespace SmokeBasin;

public class Basin
{
    public List<Position> Positions { get; set; }

    public int Size => Positions.Count;
}
