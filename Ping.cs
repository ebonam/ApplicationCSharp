using ApplicatioStagez.Script;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;

namespace PFSI
{
  public  class Ping
    {
        public string result { set; get; }


        static Ping instance;
        public static Ping GetInstance() {
            if (instance == null)
                instance = new Ping();
            return instance;
        }

        public void invoke2() {
            Ipconfig e = Ipconfig.GetInstance();
            e.test();
            test(e.ListIp);
            if (passerelle == "")
            {
                MessageBox.Show("Echec test Passerelle", "Ok", MessageBoxButton.OK, MessageBoxImage.Exclamation);

                return;

            }


            ProcessStartInfo psi = new ProcessStartInfo("cmd", "/C " + "ping "+passerelle);
            psi.UseShellExecute = false;
            psi.RedirectStandardOutput = true;
            psi.CreateNoWindow = true;
            psi.RedirectStandardError = true;
            psi.StandardOutputEncoding = System.Text.Encoding.GetEncoding(850); ;
            Process proc = Process.Start(psi);
            try
            {
                result = proc.StandardOutput.ReadToEnd();

            }
            catch (Exception e1)
            {

                Console.WriteLine(e1.Message);
            }
            finally
            {
                proc.Dispose();
            }
            string[] str = result.Split(new string[] { "\r\n" }, StringSplitOptions.None);

            if (str.Length < 5)
            {

                MessageBox.Show("Echec test Passerelle", "Ok", MessageBoxButton.OK, MessageBoxImage.Exclamation);

            }
            else
            {
                string percentage = (str[8].Split(new string[] { "(perte ", "%)" }, StringSplitOptions.None)[1]);

                if (float.Parse(percentage) < 51)
                    MessageBox.Show("Test Passerelle OK :" , "Ok", MessageBoxButton.OK, MessageBoxImage.Information);
                else
                {
                    MessageBox.Show("Echec test Passerelle:" , "Ok", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
            }


        }

        string passerelle = "";
        public void test(List<List<string>> arg)
        {

            foreach (List<string> str in arg)
            {
                foreach (string s in str)
                {
                    if (!(s.Split(new string[] { "   Passerelle par défaut. . . . . . . . . : " }, StringSplitOptions.None).Length == 1))
                    {
                        Console.WriteLine(s);
                        string[] str2 = s.Split(new string[] { "   Passerelle par défaut. . . . . . . . . : " }, StringSplitOptions.None);
                        if (!(str2[1] == "::\n"))
                        {
                            passerelle = str2[1].Replace("\n","");
                            Console.WriteLine(passerelle);
                        }

                    }


                }
            }
        }

        public void invoke()
        {
            ProcessStartInfo psi = new ProcessStartInfo("cmd", "/C " + "ping google.fr");
            psi.UseShellExecute = false;
            psi.RedirectStandardOutput = true;
            psi.CreateNoWindow = true;
            psi.RedirectStandardError = true;
            psi.StandardOutputEncoding = System.Text.Encoding.GetEncoding(850); ;
            Process proc = Process.Start(psi);
            try
            {
                result = proc.StandardOutput.ReadToEnd();

            }
            catch (Exception e1)
            {

                Console.WriteLine(e1.Message);
            }
            finally
            {
                proc.Dispose();
            }
            string[] str = result.Split(new string[] { "\r\n" }, StringSplitOptions.None);

            if (str.Length < 3)
            {
                MessageBox.Show("Echec test internet", "Ok", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else
            {
               string percentage=(str[8].Split(new string[] { "(perte ", "%)" }, StringSplitOptions.None)[1]);

                if (float.Parse(percentage) < 51)
                    MessageBox.Show("Test internet ok :" , "Ok", MessageBoxButton.OK, MessageBoxImage.Information);
                else {
                    MessageBox.Show("Echec test internet" , "Ok", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
            }
        }
    }
}

