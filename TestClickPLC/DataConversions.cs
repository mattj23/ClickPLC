using ClickPLC;

namespace TestClickPLC;

public class DataConversions
{
    [Theory]
    [InlineData(0x0004, 4)]
    [InlineData(0x002d, 45)]
    [InlineData(0x7a02, 31234)]
    [InlineData(0x85fe, -31234)]
    [InlineData(0xeaf1, -5391)]
    public void TestToInt(ushort word, short expected)
    {
        var result = DataConverter.ClickWordToInt(word);
        Assert.Equal(expected, result);
    }
    
    [Theory]
    [InlineData(0x0004, 4)]
    [InlineData(0x002d, 45)]
    [InlineData(0x7a02, 31234)]
    [InlineData(0x85fe, -31234)]
    [InlineData(0xeaf1, -5391)]
    public void TestFromInt(ushort word, short value)
    {
        var result = DataConverter.IntToClickWord(value);
        Assert.Equal(word, result);
    }
    
    [Theory]
    [InlineData(0x7912, 0xffc8, -3639022)]
    [InlineData(0xa493, 0x0069, 6923411)]
    [InlineData(0x0041, 0x0000, 65)]
    [InlineData(0xf79f, 0xffff, -2145)]
    public void TestToInt2(ushort word0, ushort word1, int expected)
    {
        var result = DataConverter.ClickWordsToInt2(word0, word1);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(0x7912, 0xffc8, -3639022)]
    [InlineData(0xa493, 0x0069, 6923411)]
    [InlineData(0x0041, 0x0000, 65)]
    [InlineData(0xf79f, 0xffff, -2145)]
    public void TestFromInt2(ushort word0, ushort word1, int value)
    {
        var result = DataConverter.Int2ToClickWords(value);
        Assert.Equal(word0, result.Item1);
        Assert.Equal(word1, result.Item2);
    }
    
    [Theory]
    [InlineData(0x1f95, 0xc1db, -27.39042)]
    [InlineData(0x1294, 0x4476, 984.2903)]
    [InlineData(0x0fd0, 0x4049, 3.14159)]
    [InlineData(0x0000, 0x0000, 0.0)]
    public void TestToFloat(ushort word0, ushort word1, float expected)
    {
        var result = DataConverter.ClickWordsToFloat(word0, word1);
        Assert.Equal(expected, result, 0.0001);
    }
    
    [Theory]
    [InlineData(0x1f95, 0xc1db, -27.39042)]
    [InlineData(0x1294, 0x4476, 984.2903)]
    [InlineData(0x0fd0, 0x4049, 3.14159)]
    [InlineData(0x0000, 0x0000, 0.0)]
    public void TestFromFloat(ushort word0, ushort word1, float value)
    {
        var result = DataConverter.FloatToClickWords(value);
        Assert.Equal(word0, result.Item1);
        Assert.Equal(word1, result.Item2);
    }
}