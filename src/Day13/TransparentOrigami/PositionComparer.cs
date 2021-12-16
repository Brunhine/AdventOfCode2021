namespace TransparentOrigami;

public class PositionComparer : IEqualityComparer<Position>
{
    public bool Equals(Position? lhs, Position? rhs)
    {
        if (ReferenceEquals(lhs, rhs)) return true;

        if (ReferenceEquals(lhs, null) || ReferenceEquals(rhs, null))
            return false;

        return lhs.X == rhs.X && lhs.Y == rhs.Y;
    }

    public int GetHashCode(Position? position)
    {
        if (ReferenceEquals(position, null)) return 0;

        var hashPositionX = position.X.GetHashCode();

        var hashPositionY = position.Y.GetHashCode();

        return hashPositionX ^ hashPositionY;
    }
}
