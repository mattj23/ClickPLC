namespace ClickPLC;

public static class DataConverter
{
    /// <summary>
    /// Converts a ushort to a pair of bytes. The Click PLC is composed of 16 bit registers in which the bytes are in
    /// little endian order.  To convert a ushort to a pair of bytes that make sense the bytes need to be reversed.
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    private static Tuple<byte, byte> ToBytePair(ushort data)
    {
        var bytes = new byte[2];
        bytes[0] = (byte)(data >> 8);
        bytes[1] = (byte)(data & 0xFF);
        return new Tuple<byte, byte>(bytes[1], bytes[0]);
    }
    
    public static float ToFloat(ushort[] data)
    {
        var b0 = ToBytePair(data[0]);
        var b1 = ToBytePair(data[1]);
        var bytes = new byte[] { b0.Item1, b0.Item2, b1.Item1, b1.Item2 };
        var result = BitConverter.ToSingle(bytes, 0);

        return result;
    }
    
    public static ushort[] ToUshort(float data)
    {
        var bytes = BitConverter.GetBytes(data);
        var b0 = new Tuple<byte, byte>(bytes[1], bytes[0]);
        var b1 = new Tuple<byte, byte>(bytes[3], bytes[2]);
        var result = new ushort[] { 0, 0 };
        result[0] = (ushort)((b0.Item1 << 8) | b0.Item2);
        result[1] = (ushort)((b1.Item1 << 8) | b1.Item2);
        return result;
    }
    
}