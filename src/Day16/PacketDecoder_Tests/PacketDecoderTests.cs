using NUnit.Framework;
using PacketDecoder;

namespace PacketDecoder_Tests;

public class PacketDecoderTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Part1Tests_LiteralValuePacket()
    {
        var rawPacket = Decoder.Decode("D2FE28");

        Assert.IsInstanceOf<LiteralValuePacket>(rawPacket);

        var packet = (LiteralValuePacket) rawPacket;

        Assert.AreEqual(6, packet.Version);
        Assert.AreEqual(4, packet.Type);
        Assert.AreEqual(2021, packet.NumberValue);
        Assert.AreEqual("110100101111111000101", packet.ToString());
    }

    [Test]
    public void Part1Tests_OperatorPacket_1()
    {
        var rawPacket = Decoder.Decode("38006F45291200");

        Assert.IsInstanceOf<OperatorPacket>(rawPacket);

        var packet = (OperatorPacket) rawPacket;

        Assert.AreEqual(1, packet.Version);
        Assert.AreEqual(6, packet.Type);
        Assert.AreEqual(0, packet.LengthTypeId);
        Assert.AreEqual("0011100000000000011011110100010100101001000100100", packet.ToString());
        Assert.AreEqual(10, ((LiteralValuePacket) packet.SubPackets[0]).NumberValue);
        Assert.AreEqual(20, ((LiteralValuePacket) packet.SubPackets[1]).NumberValue);
    }

    [Test]
    public void Part1Tests_OperatorPacket_2()
    {
        var rawPacket = Decoder.Decode("EE00D40C823060");

        Assert.IsInstanceOf<OperatorPacket>(rawPacket);

        var packet = (OperatorPacket) rawPacket;

        Assert.AreEqual(7, packet.Version);
        Assert.AreEqual(3, packet.Type);
        Assert.AreEqual(1, packet.LengthTypeId);
        Assert.AreEqual("111011100000000011010100000011001000001000110000011", packet.ToString());
        Assert.AreEqual(1, ((LiteralValuePacket) packet.SubPackets[0]).NumberValue);
        Assert.AreEqual(2, ((LiteralValuePacket) packet.SubPackets[1]).NumberValue);
        Assert.AreEqual(3, ((LiteralValuePacket) packet.SubPackets[2]).NumberValue);
    }

    [TestCase("8A004A801A8002F478", ExpectedResult = 16)]
    [TestCase("620080001611562C8802118E34", ExpectedResult = 12)]
    [TestCase("C0015000016115A2E0802F182340", ExpectedResult = 23)]
    [TestCase("A0016C880162017C3686B18A3D4780", ExpectedResult = 31)]
    public int Part1Tests_VersionSums(string hexString)
    {
        var packet = Decoder.Decode(hexString);

        return packet.GetVersionSum();
    }

    [Test]
    public void Part2Tests()
    {
        Assert.Pass();
    }
}
