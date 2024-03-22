# Click PLC

This C# library provides Modbus based connectivity to the low cost *Click* and *Click Plus* lines of programmable logic
controllers made by Koyo Electronics and sold in the United States by Automation Direct. Specifically, it allows for the
reading and writing of data registers on a running PLC.

## Click PLC Data Types and Addressing

The Click PLC has several different types of memory areas which can be accessed. In the *Click Programming Software*,
these are typically referred to by their symbol and/or type with a number specifying which register within that area is
being referred to. They can be browsed in the *Address Picker* feature of the software, and their live values can be
monitored in the *Data View* feature.

Specifications for the Click PLC addressing and data types can be found in [Chapter 2 of the *Click PLC User
Manual*](https://cdn.automationdirect.com/static/manuals/c2userm/ch2.pdf).

The Click PLC data types are summarized at the very beginning of Chapter 2, and map to the following C# types:

| Click PLC Data Type | C# Type  | Description                                                |
|---------------------|----------|------------------------------------------------------------|
| BIT                 | `bool`   | A single binary digit, representing high/low or true/false |
| INT                 | `short`  | A 16-bit signed integer                                    |             
| INT2                | `int`    | A 32-bit signed integer                                    |
| FLOAT               | `float`  | A 32-bit floating point number                             |
| TEXT                | `char`   | A single ASCII character                                   |
| HEX                 | `ushort` | A 16-bit unsigned integer in hexadecimal notation          |

The memory types are also summarized at the beginning of Chapter 2, and map to the following regions of memory:

| Memory Type                 | Symbol | Data  | Named Addresses                 |
|-----------------------------|--------|-------|---------------------------------|
| Input Point                 | `X`    | BIT   | `X#01-X#16` for `#` of `0 to 8` |
| Output Point                | `Y`    | BIT   | `Y#01-Y#16` for `#` of `0 to 8` |
| Control Relay               | `C`    | BIT   | `C1-C2000`                      |
| Timer                       | `T`    | BIT   | `T1-T500`                       |
| Counter                     | `CT`   | BIT   | `CT1-CT250`                     |
| System Control Relay        | `SC`   | BIT   | `SC1-SC1000`                    |
| Data Register (Single Word) | `DS`   | INT   | `DS1-DS4500`                    |
| Data Register (Double Word) | `DD`   | INT2  | `DD1-DD1000`                    |
| Data Register (Hex)         | `DH`   | HEX   | `DH1-DH500`                     |
| Data Register (Float)       | `DF`   | FLOAT | `DF1-DF500`                     |
| Input Register              | `XD`   | HEX   | `XD0-XD8`                       |
| Output Register             | `YD`   | HEX   | `YD0-YD8`                       |
| Timer Register              | `TD`   | INT   | `TD1-TD500`                     |
| Counter Register            | `CTD`  | INT2  | `CTD1-CTD250`                   |
| System Data Register        | `SD`   | INT   | `SD1-SD1000`                    |
| Text                        | `TXT`  | TEXT  | `TXT1-TXT1000`                  |

Refer to the *Click PLC User Manual* for more detailed information on what the memory types mean and what they store,
especially for the non-obvious elements like system data and system control relays. For most use cases, the following
memory types will be the most relevant:

* Input Point (`X`): can be used to read the state of a digital input from the PLC
* Output Point (`Y`): can be used to write a high/low state on a digital output of the PLC
* Control Relay (`C`): these can be thought of as single boolean variables that can be used by the program, not directly
  tied to any physical I/O but effectively the same as a boolean data register
* Data Registers (`DS`, `DD`, `DH`, `DF`): can be used to read or write integer or floating point values, sometimes
  mapped to or from analog I/O or sensor modules

### Named Addresses vs Modbus Addresses

The Click PLC Programming Software will refer to memory areas by their symbol and number, such as `X001` or `DS1`. These
are the named addresses used to identify them in ladder logic programs and the *Data View* feature. They are a
meaningful way to think about the memory areas within the context of the PLC program.

When accessing the memory areas remotely via Modbus, however, we must use the Modbus addressing scheme. Modbus provides
for four different types of addresses, each which can be thought of as having its own memory space:

* Input Coils: these are 1-bit read only values
* Output Coils: these are 1-bit read/write values
* Input Registers: these are 16-bit read only values
* Holding Registers: these are 16-bit read/write values

Single bit values only have two possible states, so they map directly to the `bool` type in C#. On the other hand,
16-bit values come in clusters of one or more, and can end up mapping into many different C# types.

Each Click named address is mapped to a specific Modbus address for its type, and the Modbus address is used
to read and/or write data. The Modbus addresses can be viewed by using the *Address Picker* feature of the Click
Programming Software and selecting the *Display MODBUS Address* checkbox. The Modbus address will be coupled to the
Modbus function codes available for the register, which will also be visible in the *Address Picker*. The first function
code listed will indicate which type of register the address is associated with. Output coils can be identified by the
function code `01`, input coils by `02`, holding registers by `03`, and input registers by `04`.

This library provides a way to map between the named addresses and the Modbus addresses so that client software does not
need to be concerned with the details of the Modbus mapping. The following sections go into more detail on the mappings
and the use of these areas for understanding the implementation.

### Input and Output Points

Input and output points (single bit values) are addressed differently than other memory types. Instead of being
contiguously numbered and mapped to contiguous regions of memory space, they are instead addressed by the module
position and the bit number within that module.

The Click Plus PLCs can have a maximum of 8 external modules, which each may have up to 16 input or output points. They
also may have a zero-th module which has up to 8 input or output points. The numbering system for these modules thus
ranges from 0 to 8, and the points from 1 to 16.

The named address map to Modbus addresses in the following way:

| Named Address    | Modbus Address       |
|------------------|----------------------|
| `X001` to `X016` | `0x0000` to `0x000f` |
| `X021` to `X036` | `0x0010` to `0x001f` |
| `X101` to `X116` | `0x0020` to `0x002f` |
| `X201` to `X216` | `0x0040` to `0x004f` |
| `X301` to `X316` | `0x0060` to `0x006f` |
| `X401` to `X416` | `0x0080` to `0x008f` |
| `X501` to `X516` | `0x00a0` to `0x00af` |
| `X601` to `X616` | `0x00c0` to `0x00cf` |
| `X701` to `X716` | `0x00e0` to `0x00ef` |
| `X801` to `X816` | `0x0100` to `0x010f` |

| Named Address    | Modbus Address       |
|------------------|----------------------|
| `Y001` to `Y016` | `0x2000` to `0x200f` |
| `Y021` to `Y036` | `0x2010` to `0x201f` |
| `Y101` to `Y116` | `0x2020` to `0x202f` |
| `Y201` to `Y216` | `0x2040` to `0x204f` |
| `Y301` to `Y316` | `0x2060` to `0x206f` |
| `Y401` to `Y416` | `0x2080` to `0x208f` |
| `Y501` to `Y516` | `0x20a0` to `0x20af` |
| `Y601` to `Y616` | `0x20c0` to `0x20cf` |
| `Y701` to `Y716` | `0x20e0` to `0x20ef` |
| `Y801` to `Y816` | `0x2100` to `0x210f` |


