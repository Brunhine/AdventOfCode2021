namespace GiantSquid
{
    public class BoardSpot
    {
        public int Number { get; set; }
        public bool IsMarked { get; set; }

        public BoardSpot(int number)
        {
            Number = number;
            IsMarked = false;
        }

        public override string ToString()
        {
            return $"{Number} - {IsMarked}";
        }
    }
}
