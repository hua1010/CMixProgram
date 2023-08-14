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
        [DllImport("MonitorLib.dll", EntryPoint = "InitList", CharSet = CharSet.Ansi)]
        public static extern IntPtr InitList();

        [DllImport("MonitorLib.dll", EntryPoint = "listProbe", CharSet = CharSet.Ansi)]
        public static extern IntPtr listProbe(IntPtr ptr);

        [DllImport("MonitorLib.dll", EntryPoint = "getCount", CharSet = CharSet.Ansi)]
        public static extern int getCount(IntPtr ptr);

        [DllImport("MonitorLib.dll", EntryPoint = "getDeviceName", CharSet = CharSet.Ansi)]
        public static extern void getDeviceName(IntPtr ptr, int index, StringBuilder msg);

    }
}
