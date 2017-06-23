using System;
using System.Collections.Generic;
using System.Diagnostics;

using System.Text;

namespace ApplicatioStagez.Script
{ 
    class CleanBureauDistance:FaitAction
    {

private  static  CleanBureauDistance instance;

        public static CleanBureauDistance Instance()
        {

            if (instance == null)
                instance = new CleanBureauDistance();
            return instance;
        }

          //  string str = "regedit /s ";
        string file = "REGEDIT4 \n "+@" [-HKEY_CURRENT_USER\Software\Microsoft\Terminal Server Client\Default]";

        public CleanBureauDistance() {
        }
        public void CreateFile() {
            System.IO.File.WriteAllLines(@"C:\Users\Public\test.reg", new string[] { file });
        } 

        public void invoke() {

            ProcessStartInfo psi = new ProcessStartInfo("cmd", "/C " + @"DEL /F /S /Q /A %UserProfile%\Documents\Default.rdp");
            psi.UseShellExecute = false;
            psi.RedirectStandardOutput = true;
            psi.CreateNoWindow = true;
            Process proc = Process.Start(psi);
                proc.Dispose();
        }


    }
}
