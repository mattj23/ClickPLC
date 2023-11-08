using System.Net.Sockets;
using NModbus;
using NModbus.Device;

namespace ClickPLC;

public class ClickConfig
{
    public string Type { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public int Port { get; set; }
}

public class ClickFactory
{
    private readonly ClickConfig _config;

    public ClickFactory(ClickConfig config)
    {
        _config = config;
    }

    public Click Build()
    {
        return _config.Type switch
        {
            "ModbusTCP" => BuildModbusTcp(),
            _ => throw new Exception($"Unknown Click type: {_config.Type}")
        };
        
    }

    private Click BuildModbusTcp()
    {
        var factory = new ModbusFactory();
        var client = new TcpClient(_config.Address, _config.Port);
        var master = factory.CreateMaster(client);
        return new Click(master);
    }
}