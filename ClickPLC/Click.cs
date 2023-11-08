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
        return DataConverter.ToFloat(result);
    }
    
}