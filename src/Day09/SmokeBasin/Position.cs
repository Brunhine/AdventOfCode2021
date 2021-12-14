namespace SmokeBasin;

public class Position
{
    public (int h, int w) Location { get; }

    public int Height { get; }

    public Position((int h, int w) location, int? height)
    {
        Location = location;
        Height = height ?? 0;
    }

    public override bool Equals(object? obj)
    {
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }

        var p = (Position) obj;
        return Location.h == p.Location.h && Location.w == p.Location.w;
    }
}

public class LowPoint : Position
{
    public int DangerLevel => Height + 1;

    public LowPoint((int h, int w) location, int height) : base(location, height)
    {
    }
}
