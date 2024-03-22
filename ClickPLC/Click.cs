using NModbus;

namespace ClickPLC;


public class Click
{
    private readonly IModbusMaster _master;
    
    public Click(IModbusMaster master)
    {
        _master = master;
    }
    

    public async Task<float> ReadDf(ushort address)
    {
        var result = await _master.ReadHoldingRegistersAsync(0x0, address, 2);
        return DataConverter.ClickWordsToFloat(result[0], result[1]);
    }

    public async Task SetDf(ushort address, float value)
    {
        var words = DataConverter.FloatToClickWords(value);
        await _master.WriteMultipleRegistersAsync(0x0, address, [words.Item1, words.Item2]);
    }
    
}