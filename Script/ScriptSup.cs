using ApplicatioStagez.Script;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

using System.Text;
using System.Threading;

namespace Script
{
    class ScriptSup : InterfaceCommande, FaitAction
    {
        /// <summary>
        /// Path du fichier a vider 
        /// </summary>
        private string path { set; get; }
        /// <summary>
        /// Ligne de commande
        /// </summary>
        private string cmd { set; get; } = null;


        ScriptSup instance;

        public ScriptSup GetInstance()
        {

            if (this.instance == null)
                this.instance = new ScriptSup();
            return instance;


        }



        /// <summary>
        /// Constructeur par default
        /// </summary>
        public ScriptSup()
        {
            getTMP();

        }


        public ScriptSup(String str)
        {
            path = str;

        }
        /// <summary>
        /// Cree la ligne de commande
        /// </summary>
        /// <returns>la ligne de commande</returns> 
        //TODO: voir le mieux entre le return ou accesseur de cmd
        public string getCmd()
        {
            cmd = "DEL \"" + path + "\"";

            return cmd;
        }

        /// <summary>
        /// recup le repertoire %tmp%
        /// </summary>
        public void getTMP()
        {
            ProcessStartInfo psi = new ProcessStartInfo("cmd", "/C echo %tmp%");
            psi.UseShellExecute = false;
            psi.RedirectStandardOutput = true;
            psi.CreateNoWindow = true;
            Process proc = Process.Start(psi);
            proc.WaitForExit();
            try
            {

                string result = proc.StandardOutput.ReadToEnd();


                this.path = result.Split(new string[] { "\r\n" }, StringSplitOptions.None)[0];
                //Console.WriteLine(path);
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
        }


     
        public void invoke_Aux()
        {
            this.getTMP();
            DirectoryInfo di = new DirectoryInfo(path);
            DirectoryInfo[] e = di.GetDirectories();

            for (int i = 0; i < e.Length; i++)
            {
                path = e[i].FullName;
                Console.WriteLine(path);
                ProcessStartInfo psi = new ProcessStartInfo("cmd", "/C rmdir /S /Q \"" + path + "\"");
                psi.UseShellExecute = false;
                psi.RedirectStandardOutput = true;
                psi.CreateNoWindow = true;
                Process proc = Process.Start(psi);
                proc.WaitForExit();

                string result = proc.StandardOutput.ReadToEnd();

                //   //Console.WriteLine(result + "   " + result2);


            }
            FileInfo[] Fichiers = di.GetFiles();// di.GetFiles("*.txt");

            for (int i = 0; i < Fichiers.Length; i++)
            {
                //Console.WriteLine(Fichiers[i].FullName);//test
                this.path = Fichiers[i].FullName;
                ProcessStartInfo psi = new ProcessStartInfo("cmd", "/C " + getCmd());
                psi.UseShellExecute = false;
                psi.RedirectStandardOutput = true;
                psi.CreateNoWindow = true;
                Process proc = Process.Start(psi);
                proc.WaitForExit();
                try
                {
                    string result = proc.StandardOutput.ReadToEnd();
                    string result2 = proc.StandardError.ReadToEnd();
                    //      //Console.WriteLine(result + "   " + result2);
                }
                catch (Exception e1)
                {
                    Console.WriteLine(e1.Message);
                }
                finally
                {
                    proc.Dispose();
                }
            }


        }
        static Semaphore semaphoreObject = new Semaphore(1,1000);
        public void invoke()
        {
            try {
                semaphoreObject.WaitOne();

                for (int i = 0; i < 10; i++)
                {

                    this.invoke_Aux();

                }
                semaphoreObject.Release();

            }
            catch (Exception e) { Console.WriteLine(e.Message); }
            //todo: supprimer tout les fichier temp
           }
        }
    }