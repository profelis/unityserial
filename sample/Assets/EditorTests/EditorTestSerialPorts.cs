/*
* For more information visit https://github.com/profelis/unityserial
*
* Copyright (c) 2018 Dmitri Granetchi
*
* Permission is hereby granted, free of charge, to any person
* obtaining a copy of this software and associated documentation
* files (the "Software"), to deal in the Software without
* restriction, including without limitation the rights to use,
* copy, modify, merge, publish, distribute, sublicense, and/or sell
* copies of the Software, and to permit persons to whom the
* Software is furnished to do so, subject to the following
* conditions:
*
* The above copyright notice and this permission notice shall be
* included in all copies or substantial portions of the Software.
*
* THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
* EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
* OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
* NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
* HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
* WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
* FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
* OTHER DEALINGS IN THE SOFTWARE.
*/

using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnitySerial;

namespace EditorTests
{
    public class EditorTestSerialPorts
    {
        [Test]
        public void TestSerialPortsList()
        {
            var serialPorts = new SerialPorts();
            var portsCount = serialPorts.GetPortsCount();
            if (portsCount <= 0)
                LogAssert.Expect(LogType.Error, "no ports");

            for (uint i = 0; i < portsCount; i++)
            {
                var portInfo = serialPorts.GetPortAt(i);
                Assert.True(portInfo.IsValid);
            }

            // invalid port index
            {
                var portInfo = serialPorts.GetPortAt(portsCount + 1);
                Assert.True(!portInfo.IsValid);
            }
        }

        [Test]
        public void TestSerialPortsSearch()
        {
            var serialPorts = new SerialPorts();
            var portsCount = serialPorts.GetPortsCount();
            if (portsCount <= 0)
                LogAssert.Expect(LogType.Error, "no ports");

            for (uint i = 0; i < portsCount; i++)
            {
                var portInfo = serialPorts.GetPortAt(i);
                Assert.True(portInfo.IsValid);
                var portInfo2 = serialPorts.GetPortByName(portInfo.port);
                Assert.True(portInfo2.IsValid);
                Assert.True(portInfo == portInfo2);
            }

            // invalid port name
            {
                var portInfo2 = serialPorts.GetPortByName("<invalid port name>");
                Assert.True(!portInfo2.IsValid);
            }
        }
    }
}