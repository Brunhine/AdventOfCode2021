namespace TransparentOrigami;

public class Position : IEqualityComparer<Position>
{
    public int X { get; set; }
    public int Y { get; set; }

    public bool Equals(Position? lhs, Position? rhs)
    {
        if (lhs == null || rhs == null) return false;

        return lhs.X == rhs.X && lhs.Y == rhs.Y;
    }

    public int GetHashCode(Position obj)
    {
        return HashCode.Combine(obj.X, obj.Y);
    }

    public override string ToString()
    {
        return $"{X},{Y}";
    }
}
