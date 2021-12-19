namespace PacketDecoder;

public class OperatorPacket : Packet
{
    public int LengthTypeId { get; init; }

    public List<Packet> SubPackets { get; set; }

    public OperatorPacket()
    {
        SubPackets = new List<Packet>();
    }

    public override long GetValue()
    {
        return Type switch
        {
            0 => SubPackets.Sum(p => p.GetValue()),
            1 => SubPackets.Aggregate(1L, (total, next) => total * next.GetValue()),
            2 => SubPackets.Min(p => p.GetValue()),
            3 => SubPackets.Max(p => p.GetValue()),
            5 => SubPackets[0].GetValue() > SubPackets[1].GetValue() ? 1 : 0,
            6 => SubPackets[0].GetValue() < SubPackets[1].GetValue() ? 1 : 0,
            7 => SubPackets[0].GetValue() == SubPackets[1].GetValue() ? 1 : 0,
            _ => throw new ArgumentOutOfRangeException(nameof(Type))
        };
    }

    public override int GetVersionSum()
    {
        return Version + SubPackets.Sum(p => p.GetVersionSum());
    }

    public override string ToString()
    {
        var val = LengthTypeId == 0 ? string.Join("", SubPackets).Length : SubPackets.Count;
        var str = LengthTypeId
                  + Convert.ToString(val, 2).PadLeft(LengthTypeId == 0 ? 15 : 11, '0');
        str = SubPackets.Aggregate(str, (current, packet) => current + packet);
        return base.ToString() + str;
    }
}
