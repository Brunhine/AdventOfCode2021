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
        if (obj == null || GetType() != obj.GetType()) return false;

        var p = (Position) obj;
        return Location.h == p.Location.h && Location.w == p.Location.w;
    }

    protected bool Equals(Position other)
    {
        return Location.Equals(other.Location) && Height == other.Height;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Location, Height);
    }
}
