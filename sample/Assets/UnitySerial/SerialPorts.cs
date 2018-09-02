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

using System.Runtime.InteropServices;

namespace UnitySerial
{
    /// <summary>
    /// Class encapsulates the access to serial ports
    /// <seealso cref="PortInfo"/>
    /// </summary>
    public class SerialPorts
    {
#if !UNITY_EDITOR && UNITY_IOS
        const string PLUGIN_NAME = "__Internal";
#else
        const string PLUGIN_NAME = "unityserial";
#endif

#if UNITY_EDITOR || UNITY_STANDALONE_OSX || UNITY_STANDALONE_WIN
        [DllImport(PLUGIN_NAME)]
        private static extern uint getPortsCount();

        [DllImport(PLUGIN_NAME)]
        private static extern PortInfo getPortAt(uint portIdx);

        [DllImport(PLUGIN_NAME)]
        private static extern PortInfo getPortByName([MarshalAs(UnmanagedType.LPStr)] string name);
#endif

        /// <summary>
        /// Get count of available ports
        /// </summary>
        /// <returns></returns>
        public uint GetPortsCount()
        {
            return getPortsCount();
        }

        /// <summary>
        /// Get port by index starts from 0 to <see cref="GetPortsCount"/>
        /// </summary>
        /// <param name="index"></param>
        /// <returns>
        /// Returns valid port if index lower that <see cref="GetPortsCount"/>,
        /// otherwise returns invalid port <see cref="PortInfo.IsValid"/>
        /// </returns>
        public PortInfo GetPortAt(uint index)
        {
            return getPortAt(index);
        }

        /// <summary>
        /// Search and returns <see cref="PortInfo"/> associated with given port name
        /// </summary>
        /// <param name="portName"></param>
        /// <returns>
        /// Returns valid port on search success, otherwise returns invalid port <see cref="PortInfo.IsValid"/>
        /// </returns>
        public PortInfo GetPortByName(string portName)
        {
            return getPortByName(portName);
        }
    }
}