using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace PFSI
{
    class UninstallHPsuite
    {

        public void funct(string key)
        {
            key = key.ToLower();
            if (key.Contains("msiexec"))
            {

                key = System.Text.RegularExpressions.Regex.Replace(key, "/i", "");
                key = System.Text.RegularExpressions.Regex.Replace(key, "/x", "");

                key = key.Replace("msiexec.exe", "msiexec.exe /uninstall ");
            }
            Console.WriteLine(key);

        
            
            ProcessStartInfo psi = new ProcessStartInfo("cmd", "/C "+ key);

            psi.RedirectStandardOutput = true;
            psi.RedirectStandardError = true;
            psi.RedirectStandardInput = true;
            psi.UseShellExecute = false;
            psi.CreateNoWindow = true;
            
            Process proc = Process.Start(psi);
            proc.WaitForExit();
            proc.Close();

        }
        public void  invoke()
        {

            RegistryKey cleRegistre = Registry.LocalMachine.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Uninstall", RegistryKeyPermissionCheck.ReadSubTree);
            string st = "";
            string[] str = cleRegistre.GetSubKeyNames();
            string[] s=new string[str.Length];
            int m =0;
            foreach (string e in str)
            {
                RegistryKey cle2 = Registry.LocalMachine.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Uninstall\" + e
                  , RegistryKeyPermissionCheck.ReadSubTree);
               string braw=(string)cle2.GetValue("DisplayName");
                if (braw !=null && braw.ToUpper().Contains("TEAM") ) {
                    Console.WriteLine(braw);

                    st += braw; 
                    funct((string)cle2.GetValue("UninstallString"));
                    s[m]=(string)cle2.GetValue("UninstallString");
                    m++;
                }
                s[m] = st;
                File.WriteAllLines(@"c:\Users\public\braw.txt", s );

            }
            string[] tabl = new string[] {"HP client security Manager", "Hp documentation","hp Drive encryption","hp ESV for windows 7","hp hot key","HP Setup","hp software setup","hp supportAssistant","hp downloads Manager"};

            //cleRegistre.DeleteValue("");
/*
            try
            {
                for (int i = 0; i < str.Length; i++)
                {
                    if (str[i] != "MRUList")
                    {

                        this.funct(str[i]);
                    }
                }
            }
            catch (Exception e) { Console.WriteLine(e.Message); }
            // REG DELETE

            /*
            if (cleRegistre.GetValue("ProcessorNameString") != null)
            {
                Console.WriteLine(cleRegistre.GetValue("ProcessorNameString"));   //Display processor ingo.
            }*/

        }

    }

}


