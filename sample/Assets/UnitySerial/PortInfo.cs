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

using System;
using System.Runtime.InteropServices;

namespace UnitySerial
{
    /// <summary>
    /// Serial port data
    /// </summary>
    public struct PortInfo : IEquatable<PortInfo>
    {
        /// <summary>
        /// Address of the serial port
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 200)]
        public string port;

        /// <summary>
        /// Human readable description
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 200)]
        public string description;

        /// <summary>
        /// Hardware ID (e.g. VID:PID of USB serial devices) or "n/a" if not available
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 200)]
        public string hardwareID;

        /// <summary>
        /// Returns true if port is valid or false if port is dummy
        /// </summary>
        public bool IsValid
        {
            get { return !(port.Length == 0 && description.Length == 0 && hardwareID.Length == 0); }
        }

        public override string ToString()
        {
            if (!IsValid)
                return "PortInfo <Invalid>";

            return "PortInfo '" + port + "' '" + description + "' '" + hardwareID + "'";
        }

        public bool Equals(PortInfo other)
        {
            return string.Equals(port, other.port) && string.Equals(description, other.description) && string.Equals(hardwareID, other.hardwareID);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is PortInfo && Equals((PortInfo) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (port != null ? port.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (description != null ? description.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (hardwareID != null ? hardwareID.GetHashCode() : 0);
                return hashCode;
            }
        }

        public static bool operator ==(PortInfo left, PortInfo right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(PortInfo left, PortInfo right)
        {
            return !left.Equals(right);
        }
    }
}