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

// Read X001
bool x001 = click.ReadX(1);
// - or -
bool x001a = await click.ReadXAsync(1);

// Read C12
bool c12 = click.ReadC(12);
// - or -
bool c12a = await click.ReadCAsync(12);

// Read DF100
float df100 = click.ReadDf(100);
// - or -
float df100a = await click.ReadDfAsync(100);

// Write Y001
click.WriteY(1, true);
// - or -
await click.WriteYAsync(1, true);

// Write DF201
click.WriteDf(201, 3.14f);
// - or -
await click.WriteDfAsync(201, 3.14f);


// var value = await click.ReadDf(0x7012);
// Console.WriteLine(value);


