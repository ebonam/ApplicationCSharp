using System;
using System.Collections.Generic;
using System.Diagnostics;

using System.Text;
using System.Windows;

namespace ApplicatioStagez.Script
{
    class Ipconfig
    {
        string result;

      private static  Ipconfig instance;

        public static Ipconfig GetInstance()
        {

            if (instance == null)
                instance = new Ipconfig();
            return instance;
        }


        public  Ipconfig()
        {
            test();

        }
        public void test() {
            AParser();
            this.ListIpconfig();
            this.displayIp();
        }

        public void AParser()
        {
        
        
            ProcessStartInfo psi = new ProcessStartInfo("cmd", "/C " + "ipconfig /all");
            psi.UseShellExecute = false;
            psi.RedirectStandardOutput = true;
            psi.CreateNoWindow = true;
            psi.RedirectStandardError = true;

            psi.StandardOutputEncoding = Encoding.GetEncoding(850); ;

           


            Process proc = Process.Start(psi);
            //proc.WaitForExit();
        
            try
            {
                 result = proc.StandardOutput.ReadToEnd();
             //   Console.Write(result);
                //                System.IO.File.WriteAllLines(@"C:\Users\Public\WriteLines.txt", result); //pour voir comportement fichier
                string result2 = proc.StandardError.ReadToEnd(); //on ne sait jamais
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

        public List<List<string>> ListIp { set; get; }
        public List<List<string>> braw() {
            ListIp = new List<List<string>>();
            List<string> r = new List<string>() { "jeu", "heu ", "hue" };
            List<string> r1 = new List<string>() { "braw", "braww", "braaww" };
            

            ListIp.Add(r);
            ListIp.Add(r1);


            return ListIp;
        }
        /// <summary>
        /// Fonction d'affichage pour tester
        /// </summary>
        public void displayIp()
        {
            
            foreach (List<string> element in ListIp)
            {
              //  Console.WriteLine();
               // Console.WriteLine();
                foreach (string r in element)
                {
                 //   System.Console.WriteLine(r);
                }

                //Console.WriteLine("un autre");
            }
        }


      
        /// <summary>
        /// Methode de parse pour separer les differentes cartes 
        /// 
        /// </summary>
        public void ListIpconfig()
        {
            ListIp = new List<List<string>>();
            result = result.Trim(new Char[] { '\r' });//TODO: inutile 
            result = result.Replace("\nConfiguration IP", "Configuration IP");
            string[] line = result.Split(new string[] { "\r\n" }, StringSplitOptions.None);
            

            //Todo: mettre une comboBox dynamique 
            
            int parcour = 0;
           List<string> str=new List<string>() ;
            while (parcour < line.Length - 1)
            {
//                Console.WriteLine(line[parcour]);

                if (line[parcour] != "")
                {
                    str.Add(line[parcour]+"\n");
                    parcour += 2;
                    //                    Console.WriteLine("Here"+line[parcour]);
                    while (parcour < line.Length - 1 && line[parcour] != "")
                    {
                        str.Add(line[parcour]+"\n");
                        parcour++;
                    }
                                        parcour++;
                    ListIp.Add(str);
                    str = new List<string>();
                }
                else
                    break;

            }
        }
    }
}
