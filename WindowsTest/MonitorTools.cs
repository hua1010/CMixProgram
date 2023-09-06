using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace WindowsTest
{
    class MonitorTools
    {
        public enum DeviceCode: byte
        {
            POWER = 0xE1,
            STANDBY = 0xD6,
            INPUT_SOURCE = 0x60,
            OSD = 0xCA,
            VOLUME = 0x62,
            SELECT_COLOR_PRESET = 0x14,
            RED_GAIN = 0x16,
            GREEN_GAIN = 0x18,
            BLUE_GAIN =  0x1A,
        }

        [DllImport("MonitorLib.dll", EntryPoint = "InitList", CharSet = CharSet.Ansi)]
        public static extern IntPtr InitList();

        [DllImport("MonitorLib.dll", EntryPoint = "listProbe", CharSet = CharSet.Ansi)]
        public static extern IntPtr listProbe(IntPtr ptr);

        [DllImport("MonitorLib.dll", EntryPoint = "getCount", CharSet = CharSet.Ansi)]
        public static extern int getCount(IntPtr ptr);

        [DllImport("MonitorLib.dll", EntryPoint = "getDeviceName", CharSet = CharSet.Ansi)]
        public static extern void getDeviceName(IntPtr ptr, int index, StringBuilder msg);

        [DllImport("MonitorLib.dll", EntryPoint = "getRawCapabilities", CharSet = CharSet.Ansi)]
        public static extern void getRawCapabilities(IntPtr ptr, int index, StringBuilder msg);

        [DllImport("MonitorLib.dll", EntryPoint = "getVCPValue", CharSet = CharSet.Ansi)]
        public static extern UInt32 getVCPValue(IntPtr ptr, int index, byte code);

        [DllImport("MonitorLib.dll", EntryPoint = "setVCPValue", CharSet = CharSet.Ansi)]
        public static extern void setVCPValue(IntPtr ptr, int index, byte code, UInt32 value);
    }
}
