using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace AutoVersion
{
    class Program
    {
        static void UpdateVersion(ref string line)
        {
            var first = line.IndexOf('"');
            var second = line.LastIndexOf('"');
            var sVersion = line.Substring(first + 1, second - first - 1);
            var arrVersion = sVersion.Split('.');
            if (arrVersion.Length < 4) return;
            var major = Convert.ToInt32(arrVersion[0]);
            var minor = Convert.ToInt32(arrVersion[1]);
            var build = Convert.ToInt32(arrVersion[2]);
            var amendment = Convert.ToInt32(arrVersion[3]);
            if (++amendment > 999) ++build;
            if (build > 99) ++minor;
            if (minor > 9) ++major;
            var sNewVersion = $"{major}.{minor}.{build}.{amendment}";
            line = line.Replace(sVersion, sNewVersion);
        }

        static void Main(string[] args)
        {
            if (args.Length != 1 || !File.Exists(args[0])) return;
            var lines = File.ReadAllLines(args[0]);
            for (int i = lines.Length - 1; i >= 0; i--)
            {
                if (lines[i].Contains("assembly: AssemblyFileVersion"))
                {
                    UpdateVersion(ref lines[i]);
                }
                if (lines[i].Contains("assembly: AssemblyVersion") && !lines[i].Contains("*"))
                {
                    UpdateVersion(ref lines[i]);
                    break;
                }
            }
            File.WriteAllLines(args[0], lines);
        }
    }
}
