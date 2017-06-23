using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;


namespace Script
{/// <summary>
///  script d'ouverture de programme
/// </summary>
    class ScriptStart : InterfaceCommande, ApplicatioStagez.Script.FaitAction
    {

        public string Path { set; get; }
        /// <summary>
        ///  Constructeur avec le chemin du programme
        /// </summary>
        public ScriptStart() {
          //  throw new NotImplementedException();
        }

        public ScriptStart(string str)
        {

            Path = str;

        }


       public  string getCmd()
        {
            Path =Directory.GetCurrentDirectory()+@"TeamViewerQS_fr-PFSI.exe";

            return "\"" +Path+"\"";
        }

        public void invoke()
        {
            Path = "\"" + @"C:\Program Files (x86)\PFSI-2\"+ @"TeamViewerQS_fr-PFSI.exe"+"\"";

            ProcessStartInfo psi = new ProcessStartInfo("cmd", "/C " + Path);
            psi.UseShellExecute = false;
            psi.RedirectStandardOutput = true;
            psi.CreateNoWindow = true;
            Process proc = Process.Start(psi);


            proc.Dispose();
            

        }
    }
}
