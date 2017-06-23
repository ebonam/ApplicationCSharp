using System;
using System.Collections.Generic;
using System.Diagnostics;

using System.Text;

namespace ApplicatioStagez.ReferenceWeb
{
    class PasswordTest
    {
                  
        string result;
       public List<string> listUser=new List<string>();
            private static PasswordTest instance;

            public static PasswordTest GetInstance()
            {

                if (instance == null)
                    instance = new PasswordTest();
                return instance;
            }


            public PasswordTest()
            {


            }
            public void test()
            {
                AParser();
           braw();
           Infor();
            }
public        List<string> users=new List<string>();
            public void AParser()
            {

                ProcessStartInfo psi = new ProcessStartInfo("cmd", "/C " + "net user");
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
        public void braw() {
            result = result.Replace("\r\nLa commande s'est terminée correctement.\r\n\r\n", "");
            result = result.Replace("-------------------------------------------------------------------------------\r\n","");
          //  Console.WriteLine(result);
                //result = result.Replace("\r\ncomptes d'utilisateurs de \\\\LEBONAM\r\n\r\n-------------------------------------------------------------------------------\r\n", "");
                string[] result1 = result.Split(new string[] { "\r\n\r\n" },StringSplitOptions.None);
            result = result1[1];
            result = result.Replace("\r\n", "");
          //  Console.Write(result);
            string str = "Administrateur           ";
            int borne = str.Length;
            int b1=0, b2=str.Length;
            while (b1!=result.Length) {
                try
                {
         //           Console.WriteLine(result.Length);
                    this.listUser.Add(result.Substring(b1,borne));
                    b1 += borne;
                }
                catch (Exception e) {
                    Console.WriteLine(e.Message);
                    b1 += borne;

                }
            }
        }
            public List<string> ListInfor { set; get; }
        /// <summary>
        /// Methode de parse pour separer les differentes cartes 
        /// 
        /// </summary>
        public void Infor() {

            ListInfor = new List<string>();
            foreach (string i in this.listUser)
            {
                ProcessStartInfo psi = new ProcessStartInfo("cmd", "/C " + "net user "+i);
                psi.UseShellExecute = false;
                psi.RedirectStandardOutput = true;
                psi.CreateNoWindow = true;
                psi.RedirectStandardError = true;
                psi.StandardOutputEncoding = Encoding.GetEncoding(850); 
                Process proc = Process.Start(psi);
                //proc.WaitForExit();
                try
                {
                    result = proc.StandardOutput.ReadToEnd();
           //         Console.WriteLine(result);
                    this.ListInfor.Add(result);           
                  //  string result2 = proc.StandardError.ReadToEnd(); //on ne sait jamais
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
    }
}





