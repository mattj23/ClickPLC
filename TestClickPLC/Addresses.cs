using ClickPLC;
using TestClickPLC.Data;

namespace TestClickPLC;

/// <summary>
/// Address tests are based on the registers.data file, which was built by opening the "Address Picker" in a live,
/// running Click Plus PLC and exporting all addresses to a CSV.  I used a python script to read the CSV and extract
/// symbols, numbers, data types, modbus addresses, and modbus function codes.  The data file contains over 13k rows:
/// one for each memory address in the PLC.
///
/// These tests will go through all 13k addresses and individually verify that they are mapped correctly. The
/// AddressBook class does the mapping using a simpler set of rules than maintaining a large dictionary of addresses,
/// and these tests exist to verify that the rules are correct.
/// </summary>
public class Addresses
{
    private record Fixture(Register[] Registers, AddressBook AddressBook);
    
    private Fixture LoadFixture(string symbol)
    {
        var registers = Register.Load("Data/registers.data").Where(r => r.Symbol == symbol).ToArray();
        var addressBook = new AddressBook();
        return new Fixture(registers, addressBook);
    }
    
    [Fact]
    public void TestAllAddressesForX()
    {
        var fixture = LoadFixture("X");
        foreach (var register in fixture.Registers)
        {
            var address = fixture.AddressBook.X(register.Number);
            Assert.Equal(register.Address, address);
        }
    }
    
    [Fact]
    public void TestAllAddressesForY()
    {
        var fixture = LoadFixture("Y");
        foreach (var register in fixture.Registers)
        {
            var address = fixture.AddressBook.Y(register.Number);
            Assert.Equal(register.Address, address);
        }
    }

    [Fact]
    public void TestAllAddressesForC()
    {
        var fixture = LoadFixture("C");
        foreach (var register in fixture.Registers)
        {
            var address = fixture.AddressBook.C(register.Number);
            Assert.Equal(register.Address, address);
        }
    }
    
    [Fact]
    public void TestAllAddressesForT()
    {
        var fixture = LoadFixture("T");
        foreach (var register in fixture.Registers)
        {
            var address = fixture.AddressBook.T(register.Number);
            Assert.Equal(register.Address, address);
        }
    }
    
    [Fact]
    public void TestAllAddressesForCt()
    {
        var fixture = LoadFixture("CT");
        foreach (var register in fixture.Registers)
        {
            var address = fixture.AddressBook.Ct(register.Number);
            Assert.Equal(register.Address, address);
        }
    }   
    
    [Fact]
    public void TestAllAddressesForSc()
    {
        var fixture = LoadFixture("SC");
        foreach (var register in fixture.Registers)
        {
            var address = fixture.AddressBook.Sc(register.Number);
            Assert.Equal(register.Address, address);
        }
    }
    
    [Fact]
    public void TestAllAddressesForDs()
    {
        var fixture = LoadFixture("DS");
        foreach (var register in fixture.Registers)
        {
            var address = fixture.AddressBook.Ds(register.Number);
            Assert.Equal(register.Address, address);
        }
    }
    
    [Fact]
    public void TestAllAddressesForDd()
    {
        var fixture = LoadFixture("DD");
        foreach (var register in fixture.Registers)
        {
            var address = fixture.AddressBook.Dd(register.Number);
            Assert.Equal(register.Address, address);
        }
    }
    
    [Fact]
    public void TestAllAddressesForDh()
    {
        var fixture = LoadFixture("DH");
        foreach (var register in fixture.Registers)
        {
            var address = fixture.AddressBook.Dh(register.Number);
            Assert.Equal(register.Address, address);
        }
    }
    
    [Fact]
    public void TestAllAddressesForDf()
    {
        var fixture = LoadFixture("DF");
        foreach (var register in fixture.Registers)
        {
            var address = fixture.AddressBook.Df(register.Number);
            Assert.Equal(register.Address, address);
        }
    }
    
    [Fact]
    public void TestAllAddressesForXd()
    {
        var fixture = LoadFixture("XD");
        foreach (var register in fixture.Registers)
        {
            var address = fixture.AddressBook.Xd(register.Number);
            Assert.Equal(register.Address, address);
        }
    }
    
    [Fact]
    public void TestAllAddressesForYd()
    {
        var fixture = LoadFixture("YD");
        foreach (var register in fixture.Registers)
        {
            var address = fixture.AddressBook.Yd(register.Number);
            Assert.Equal(register.Address, address);
        }
    }
    
    [Fact]
    public void TestAllAddressesForTd()
    {
        var fixture = LoadFixture("TD");
        foreach (var register in fixture.Registers)
        {
            var address = fixture.AddressBook.Td(register.Number);
            Assert.Equal(register.Address, address);
        }
    }
    
    [Fact]
    public void TestAllAddressesForCtd()
    {
        var fixture = LoadFixture("CTD");
        foreach (var register in fixture.Registers)
        {
            var address = fixture.AddressBook.Ctd(register.Number);
            Assert.Equal(register.Address, address);
        }
    }
    
    [Fact]
    public void TestAllAddressesForSd()
    {
        var fixture = LoadFixture("SD");
        foreach (var register in fixture.Registers)
        {
            var address = fixture.AddressBook.Sd(register.Number);
            Assert.Equal(register.Address, address);
        }
    }
    
    [Fact]
    public void TestAllAddressesForTxt()
    {
        var fixture = LoadFixture("TXT");
        foreach (var register in fixture.Registers)
        {
            var address = fixture.AddressBook.Txt(register.Number);
            Assert.Equal(register.Address, address);
        }
    }
    

}