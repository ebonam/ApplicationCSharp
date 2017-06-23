using System;
using System.Diagnostics;
using System.Windows;

namespace PFSI.Script
{
    class ProductKEy
    {
        public void Invoke()
        {
        ; ////CurrentDirectory;
        //    MessageBox.Show(Environment.CurrentDirectory, "Cle windows", MessageBoxButton.OK, MessageBoxImage.Information);

            string result = "";
            ProcessStartInfo psi = new ProcessStartInfo("cmd", "/C " + "cscript.exe \"c:\\Program Files (x86)\\Pfsi-2\\clef.vbs");
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
            string[] esult = result.Split(new string[] { "\r\n" }, StringSplitOptions.None);

            MessageBox.Show("Votre clé est :\n" + esult[3], "Cle windows", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
