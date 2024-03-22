namespace ClickPLC;

/// <summary>
/// This class functions as an address book for the Click PLC. It is used to convert the named address number of
/// different memory area types to the actual Modbus address that is used to communicate with the PLC.
/// </summary>
public class AddressBook
{
    private static readonly ushort[] XStarts = [ 0x10, 0x20, 0x40, 0x60, 0x80, 0xA0, 0xC0, 0xE0, 0x100 ];
    private static readonly ushort[] YStarts = [ 0x2010, 0x2020, 0x2040, 0x2060, 0x2080, 0x20A0, 0x20C0, 0x20E0, 0x2100 ];
    public ushort X(ushort number)
    {
        var tail = number % 100;
        var head = number / 100;

        if (head == 0)
        {
            if (tail is <= 16 and >= 1) return (ushort)(number - 1);

            tail -= 20;
        }

        return (ushort)(XStarts[head] + tail - 1);
    }
    
    public ushort Y(ushort number)
    {
        var tail = number % 100;
        var head = number / 100;

        if (head == 0)
        {
            if (tail is <= 16 and >= 1) return (ushort)(number - 1 + 0x2000);

            tail -= 20;
        }

        return (ushort)(YStarts[head] + tail - 1);
    }
    
    public ushort C(ushort number)
    {
        return (ushort)(0x4000 + number - 1);
    }
    
    public ushort T(ushort number)
    {
        return (ushort)(0xb000 + number - 1);
    }
    
    public ushort Ct(ushort number)
    {
        return (ushort)(0xc000 + number - 1);
    }
    
    public ushort Sc(ushort number)
    {
        return (ushort)(0xf000 + number - 1);
    }

    public ushort Ds(ushort number)
    {
        return (ushort)(0x0000 + number - 1);
    }

    public ushort Dd(ushort number)
    {
        return (ushort)(0x4000 + (number - 1) * 2);
    }

    public ushort Dh(ushort number)
    {
        return (ushort)(0x6000 + number - 1);
    }

    public ushort Df(ushort number)
    {
        return (ushort)(0x7000 + (number - 1) * 2);
    }

    public ushort Xd(ushort number)
    {
        return (ushort)(0xe000 + number * 2);
    }

    public ushort Yd(ushort number)
    {
        return (ushort)(0xe200 + number * 2);
    }

    public ushort Td(ushort number)
    {
        return (ushort)(0xb000 + number - 1);
    }

    public ushort Ctd(ushort number)
    {
        return (ushort)(0xc000 + (number - 1) * 2);
    }

    public ushort Sd(ushort number)
    {
        return (ushort)(0xf000 + number - 1);
    }

    public ushort Txt(ushort number)
    {
        return (ushort)(0x9000 + (number - 1) / 2 );
    }
}