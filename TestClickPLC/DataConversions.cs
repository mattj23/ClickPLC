using ClickPLC;

namespace TestClickPLC;

public class DataConversions
{
    [Fact]
    public void TestDfForward()
    {
        var registers = new ushort[] { 0, 16544 };
        var result = DataConverter.ToFloat(registers);
        
        Assert.Equal(5.0, result, 0.0001);
    }

    [Fact]
    public void TestDfBackwards()
    {
        var result = DataConverter.ToUshort(5.0f);
        var expected = new ushort[] { 0, 16544 };
        Assert.Equal(expected[0], result[0]);
        Assert.Equal(expected[1], result[1]);
    }
}