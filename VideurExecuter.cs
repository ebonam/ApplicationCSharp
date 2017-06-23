using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

using System.Text;

namespace ApplicatioStagez
{
    class VideurExecuter
    {
        public VideurExecuter()
        {


        }
        VideurExecuter instance;

        public VideurExecuter GetInstance()
        {

            if (this.instance == null)
                this.instance = new VideurExecuter();
            return instance;
        }

        public void funct(string key)
        {

            ProcessStartInfo psi = new ProcessStartInfo("cmd", "/C REG delete HKEY_CURRENT_USER\\Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\RunMRU /f /v " + key);

            psi.RedirectStandardOutput = true;
            psi.RedirectStandardError = true;
            psi.RedirectStandardInput = true;
            psi.UseShellExecute = false;
            psi.CreateNoWindow = true;

            Process proc = Process.Start(psi);
            proc.Close();

        }
        public void /*bool*/ invoke()
        {

            RegistryKey cleRegistre = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Explorer\RunMRU", RegistryKeyPermissionCheck.ReadSubTree);

            string[] str = cleRegistre.GetValueNames();

            System.IO.File.WriteAllLines(@"C:\Users\Public\WriteLines.txt", str);
            //cleRegistre.DeleteValue("");

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
