# Serial Communication plugin for Unity3D

Plugin extends C# API `SerialPort.GetPortNames()`

## Main features

- Supports desktop platforms: macOS (+editor) and Windows (+editor)
- List all active serial ports
- Provide port name, description, hardware id

## Compiling

- Plugin: see [README.md](https://github.com/profelis/unity_plugin/blob/master/README.md) from `Unity native plugin` repository
- Sample: Tested in Unity 2018.2.5

## Usage

```c#
var ports = new SerialPorts();
// get ports count
var portsCount = ports.GetPortsCount();
// get first port info
var firstPort = ports.GetPortAt(0);
// search port by name
var arduino = ports.GetPortByName("/dev/cu.usbmodem14C1");
if (arduino.IsValid) {
    Debug.Log(arduino);
} else {
    Debug.Log("arduino not found");
}
```

## Output example

```text
Ports count: 3
Port #0: PortInfo '/dev/cu.serial0' 'n/a' 'n/a'
Port #1: PortInfo '/dev/cu.Bluetooth-Incoming-Port' 'n/a' 'n/a'
Port #2: PortInfo '/dev/cu.usbmodem14C1' 'Arduino (www.arduino.cc) Generic CDC' 'USB VID:PID=2341:0043 SNR=7543932383535160C1C1'
Port #3: PortInfo <Invalid>
```

## More info

- [Cross-platform, Serial Port library written in C++](https://github.com/wjwwood/serial) by wjwwood
- [Unity native plugin (sample)](https://github.com/profelis/unity_plugin)
- [How to integrate Arduino with Unity](https://www.alanzucconi.com/2015/10/07/how-to-integrate-arduino-with-unity/)
- [SerialPort.GetPortNames](https://docs.microsoft.com/en-us/dotnet/api/system.io.ports.serialport.getportnames) documentation
