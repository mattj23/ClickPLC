namespace TestClickPLC.Data;

public record Register(string Name, string Symbol, ushort Number, string DataType, ushort Address, List<ushort> Functions)
{
    public static Register[] Load(string path)
    {
        var registers = new List<Register>();
        var lines = File.ReadAllLines(path);
        foreach (var line in lines)
        {
            var parts = line.Split(';');
            var name = parts[0];
            var symbol = parts[1];
            var number = ushort.Parse(parts[2]);
            var dataType = parts[3];
            var address = ushort.Parse(parts[4]);
            var functions = parts[5].Split(',').Select(ushort.Parse).ToList();
            var register = new Register(name, symbol, number, dataType, address, functions);
            registers.Add(register);
        }
        return registers.ToArray();
    }
}


