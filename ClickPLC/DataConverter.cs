namespace ClickPLC;

/// <summary>
/// This static class contains methods to convert between the ushort word values transferred over the Modbus protocol
/// from the Click PLC and the .NET data types used in the library. Simple types like bool and ushort used by the
/// Click "BIT" and "HEX" types are not included as they are directly compatible with the .NET types.
/// </summary>
public static class DataConverter
{
    /// <summary>
    /// A Click PLC "INT" data type is actually a 16 bit signed integer. The bytes are in little endian order, so
    /// unpacking and repacking them is necessary to convert to and from the .NET short data type.
    /// </summary>
    /// <param name="word">The single ushort value returned by the Modbus protocol</param>
    /// <returns>A converted 16 bit signed integer</returns>
    public static short ClickWordToInt(ushort word)
    {
        var b = ToBytePair(word);
        var bytes = new[] { b.Item1, b.Item2 };
        return BitConverter.ToInt16(bytes, 0);
    }

    /// <summary>
    /// Converts a .NET short to a ushort value that can be sent to the Click PLC. 
    /// </summary>
    /// <param name="value">The signed 16 bit integer to convert</param>
    /// <returns>The unsigned 16 bit word representing the integer value</returns>
    public static ushort IntToClickWord(short value)
    {
        var bytes = BitConverter.GetBytes(value);
        var u = (ushort)((bytes[1] << 8) | bytes[0]);
        return u;
    }

    /// <summary>
    /// Converts two 16 bit words to a 32 bit signed integer. 
    /// </summary>
    /// <param name="word0"></param>
    /// <param name="word1"></param>
    /// <returns></returns>
    public static int ClickWordsToInt2(ushort word0, ushort word1)
    {
        var b0 = ToBytePair(word0);
        var b1 = ToBytePair(word1);
        var bytes = new[] { b0.Item1, b0.Item2, b1.Item1, b1.Item2 };
        var result = BitConverter.ToInt32(bytes, 0);
        return result;
    }

    /// <summary>
    /// Converts a 32 bit signed integer to two 16 bit words that can be sent to the Click PLC.
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static Tuple<ushort, ushort> Int2ToClickWords(int value)
    {
        var bytes = BitConverter.GetBytes(value);
        var u0 = (ushort)((bytes[1] << 8) | bytes[0]);
        var u1 = (ushort)((bytes[3] << 8) | bytes[2]);
        return new Tuple<ushort, ushort>(u0, u1);
    }

    /// <summary>
    /// Converts two 16 bit words to a 32 bit floating point number.
    /// </summary>
    /// <param name="word0"></param>
    /// <param name="word1"></param>
    /// <returns></returns>
    public static float ClickWordsToFloat(ushort word0, ushort word1)
    {
        var b0 = ToBytePair(word0);
        var b1 = ToBytePair(word1);
        var bytes = new[] { b0.Item1, b0.Item2, b1.Item1, b1.Item2 };
        var result = BitConverter.ToSingle(bytes, 0);
        return result;
    }

    /// <summary>
    /// Converts a 32 bit floating point number to two 16 bit words that can be sent to the Click PLC.
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static Tuple<ushort, ushort> FloatToClickWords(float value)
    {
        var bytes = BitConverter.GetBytes(value);
        var u0 = (ushort)((bytes[1] << 8) | bytes[0]);
        var u1 = (ushort)((bytes[3] << 8) | bytes[2]);
        return new Tuple<ushort, ushort>(u0, u1);
    }

    /// <summary>
    ///     Converts a ushort to a pair of bytes. The Click PLC is composed of 16 bit registers in which the bytes are in
    ///     little endian order.  To convert a ushort to a pair of bytes that make sense the bytes need to be reversed.
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

}