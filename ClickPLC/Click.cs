using NModbus;

namespace ClickPLC;


public class Click
{
    private readonly IModbusMaster _master;
    private readonly AddressBook _addressBook = new();

    public Click(IModbusMaster master)
    {
        _master = master;
    }


    public bool ReadX(ushort number)
    {
        var address = _addressBook.X(number);
        var result = _master.ReadInputs(0x0, address, 1);
        return result[0];
    }

    public async Task<bool> ReadXAsync(ushort number)
    {
        var address = _addressBook.X(number);
        var result = await _master.ReadInputsAsync(0x0, address, 1);
        return result[0];
    }


    public bool ReadY(ushort number)
    {
        var address = _addressBook.Y(number);
        var result = _master.ReadCoils(0x0, address, 1);
        return result[0];
    }

    public async Task<bool> ReadYAsync(ushort number)
    {
        var address = _addressBook.Y(number);
        var result = await _master.ReadCoilsAsync(0x0, address, 1);
        return result[0];
    }


    public void WriteY(ushort number, bool value)
    {
        var address = _addressBook.Y(number);
        ;
        _master.WriteSingleCoil(0x0, address, value);
    }

    public async Task WriteYAsync(ushort number, bool value)
    {
        var address = _addressBook.Y(number);
        ;
        await _master.WriteSingleCoilAsync(0x0, address, value);
    }


    public bool ReadC(ushort number)
    {
        var address = _addressBook.C(number);
        var result = _master.ReadCoils(0x0, address, 1);
        return result[0];
    }

    public async Task<bool> ReadCAsync(ushort number)
    {
        var address = _addressBook.C(number);
        var result = await _master.ReadCoilsAsync(0x0, address, 1);
        return result[0];
    }


    public void WriteC(ushort number, bool value)
    {
        var address = _addressBook.C(number);
        ;
        _master.WriteSingleCoil(0x0, address, value);
    }

    public async Task WriteCAsync(ushort number, bool value)
    {
        var address = _addressBook.C(number);
        ;
        await _master.WriteSingleCoilAsync(0x0, address, value);
    }


    public bool ReadT(ushort number)
    {
        var address = _addressBook.T(number);
        var result = _master.ReadInputs(0x0, address, 1);
        return result[0];
    }

    public async Task<bool> ReadTAsync(ushort number)
    {
        var address = _addressBook.T(number);
        var result = await _master.ReadInputsAsync(0x0, address, 1);
        return result[0];
    }


    public bool ReadCt(ushort number)
    {
        var address = _addressBook.Ct(number);
        var result = _master.ReadInputs(0x0, address, 1);
        return result[0];
    }

    public async Task<bool> ReadCtAsync(ushort number)
    {
        var address = _addressBook.Ct(number);
        var result = await _master.ReadInputsAsync(0x0, address, 1);
        return result[0];
    }


    public short ReadDs(ushort number)
    {
        var address = _addressBook.Ds(number);
        var result = _master.ReadHoldingRegisters(0x0, address, 1);
        return DataConverter.ClickWordToInt(result[0]);
    }

    public async Task<short> ReadDsAsync(ushort number)
    {
        var address = _addressBook.Ds(number);
        var result = await _master.ReadHoldingRegistersAsync(0x0, address, 1);
        return DataConverter.ClickWordToInt(result[0]);
    }


    public void WriteDs(ushort number, short value)
    {
        var address = _addressBook.Ds(number);
        var word = DataConverter.IntToClickWord(value);
        _master.WriteSingleRegister(0x0, address, word);
    }

    public async Task WriteDsAsync(ushort number, short value)
    {
        var address = _addressBook.Ds(number);
        var word = DataConverter.IntToClickWord(value);
        await _master.WriteSingleRegisterAsync(0x0, address, word);
    }


    public int ReadDd(ushort number)
    {
        var address = _addressBook.Dd(number);
        var result = _master.ReadHoldingRegisters(0x0, address, 2);
        return DataConverter.ClickWordsToInt2(result[0], result[1]);
    }

    public async Task<int> ReadDdAsync(ushort number)
    {
        var address = _addressBook.Dd(number);
        var result = await _master.ReadHoldingRegistersAsync(0x0, address, 2);
        return DataConverter.ClickWordsToInt2(result[0], result[1]);
    }


    public void WriteDd(ushort number, int value)
    {
        var address = _addressBook.Dd(number);
        var words = DataConverter.Int2ToClickWords(value);
        _master.WriteMultipleRegisters(0x0, address, [words.Item1, words.Item2]);
    }

    public async Task WriteDdAsync(ushort number, int value)
    {
        var address = _addressBook.Dd(number);
        var words = DataConverter.Int2ToClickWords(value);
        await _master.WriteMultipleRegistersAsync(0x0, address, [words.Item1, words.Item2]);
    }


    public ushort ReadDh(ushort number)
    {
        var address = _addressBook.Dh(number);
        var result = _master.ReadHoldingRegisters(0x0, address, 1);
        return result[0];
    }

    public async Task<ushort> ReadDhAsync(ushort number)
    {
        var address = _addressBook.Dh(number);
        var result = await _master.ReadHoldingRegistersAsync(0x0, address, 1);
        return result[0];
    }


    public void WriteDh(ushort number, ushort value)
    {
        var address = _addressBook.Dh(number);
        ;
        _master.WriteSingleRegister(0x0, address, value);
    }

    public async Task WriteDhAsync(ushort number, ushort value)
    {
        var address = _addressBook.Dh(number);
        ;
        await _master.WriteSingleRegisterAsync(0x0, address, value);
    }


    public float ReadDf(ushort number)
    {
        var address = _addressBook.Df(number);
        var result = _master.ReadHoldingRegisters(0x0, address, 2);
        return DataConverter.ClickWordsToFloat(result[0], result[1]);
    }

    public async Task<float> ReadDfAsync(ushort number)
    {
        var address = _addressBook.Df(number);
        var result = await _master.ReadHoldingRegistersAsync(0x0, address, 2);
        return DataConverter.ClickWordsToFloat(result[0], result[1]);
    }


    public void WriteDf(ushort number, float value)
    {
        var address = _addressBook.Df(number);
        var words = DataConverter.FloatToClickWords(value);
        _master.WriteMultipleRegisters(0x0, address, [words.Item1, words.Item2]);
    }

    public async Task WriteDfAsync(ushort number, float value)
    {
        var address = _addressBook.Df(number);
        var words = DataConverter.FloatToClickWords(value);
        await _master.WriteMultipleRegistersAsync(0x0, address, [words.Item1, words.Item2]);
    }


    public ushort ReadXd(ushort number)
    {
        var address = _addressBook.Xd(number);
        var result = _master.ReadInputRegisters(0x0, address, 1);
        return result[0];
    }

    public async Task<ushort> ReadXdAsync(ushort number)
    {
        var address = _addressBook.Xd(number);
        var result = await _master.ReadInputRegistersAsync(0x0, address, 1);
        return result[0];
    }


    public ushort ReadYd(ushort number)
    {
        var address = _addressBook.Yd(number);
        var result = _master.ReadHoldingRegisters(0x0, address, 1);
        return result[0];
    }

    public async Task<ushort> ReadYdAsync(ushort number)
    {
        var address = _addressBook.Yd(number);
        var result = await _master.ReadHoldingRegistersAsync(0x0, address, 1);
        return result[0];
    }


    public void WriteYd(ushort number, ushort value)
    {
        var address = _addressBook.Yd(number);
        ;
        _master.WriteSingleRegister(0x0, address, value);
    }

    public async Task WriteYdAsync(ushort number, ushort value)
    {
        var address = _addressBook.Yd(number);
        ;
        await _master.WriteSingleRegisterAsync(0x0, address, value);
    }


    public short ReadTd(ushort number)
    {
        var address = _addressBook.Td(number);
        var result = _master.ReadHoldingRegisters(0x0, address, 1);
        return DataConverter.ClickWordToInt(result[0]);
    }

    public async Task<short> ReadTdAsync(ushort number)
    {
        var address = _addressBook.Td(number);
        var result = await _master.ReadHoldingRegistersAsync(0x0, address, 1);
        return DataConverter.ClickWordToInt(result[0]);
    }


    public void WriteTd(ushort number, short value)
    {
        var address = _addressBook.Td(number);
        var word = DataConverter.IntToClickWord(value);
        _master.WriteSingleRegister(0x0, address, word);
    }

    public async Task WriteTdAsync(ushort number, short value)
    {
        var address = _addressBook.Td(number);
        var word = DataConverter.IntToClickWord(value);
        await _master.WriteSingleRegisterAsync(0x0, address, word);
    }


    public int ReadCtd(ushort number)
    {
        var address = _addressBook.Ctd(number);
        var result = _master.ReadHoldingRegisters(0x0, address, 2);
        return DataConverter.ClickWordsToInt2(result[0], result[1]);
    }

    public async Task<int> ReadCtdAsync(ushort number)
    {
        var address = _addressBook.Ctd(number);
        var result = await _master.ReadHoldingRegistersAsync(0x0, address, 2);
        return DataConverter.ClickWordsToInt2(result[0], result[1]);
    }


    public void WriteCtd(ushort number, int value)
    {
        var address = _addressBook.Ctd(number);
        var words = DataConverter.Int2ToClickWords(value);
        _master.WriteMultipleRegisters(0x0, address, [words.Item1, words.Item2]);
    }

    public async Task WriteCtdAsync(ushort number, int value)
    {
        var address = _addressBook.Ctd(number);
        var words = DataConverter.Int2ToClickWords(value);
        await _master.WriteMultipleRegistersAsync(0x0, address, [words.Item1, words.Item2]);
    }

}