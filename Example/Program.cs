// See https://aka.ms/new-console-template for more information

using System.Runtime.InteropServices;
using ClickPLC;

var config = new ClickConfig()
{
    Type = "ModbusTCP",
    Address = "192.168.1.5",
    Port = 502
};

var factory = new ClickFactory(config);
var click = factory.Build();

var value = await click.ReadDf(0x7012);
Console.WriteLine(value);


