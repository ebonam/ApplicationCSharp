using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows;
using WUApiLib;

namespace PFSI.ReferenceWeb
{
 
   public class MAJ
    {
        string WIN7_maj1 = " wusa /uninstall /kb:3035583  /norestart";
        string WIN7_maj2 = " wusa /uninstall /kb:2952664  /norestart";
        string WIN7_maj3 = " wusa /uninstall /kb:3021917  /norestart";
   
        string WIN8_maj1 = " wusa /uninstall /kb:3035583 /norestart";
        string WIN8_maj2 = " wusa /uninstall /kb:2976978 /norestart";
        
        
        string testMAj1 = "wusa /uninstall /kb:3147458 /norestart";
        string testMAj = "wusa /uninstall /kb:3154132 /norestart";
        public bool _isFree { set; get; }

        /*2734786
2734786*/
        private MAJ() {
            _isFree = true;
        }
        static MAJ instance=new MAJ();


 public static MAJ  getInstance()
        { if (instance == null)
                instance = new MAJ();
            return instance;
        }   
/// <summary>
/// Function de test
/// </summary>
        public void invoke() {
            _isFree = false;
           
            ProcessStartInfo psi = new ProcessStartInfo("cmd", "/C" + this.testMAj);
            psi.UseShellExecute = false;
            psi.RedirectStandardOutput = true;
            psi.CreateNoWindow = true;
            Process proc = Process.Start(psi);
            proc.WaitForExit();
           
            psi = new ProcessStartInfo("cmd ", "/C " + this.testMAj1);
            psi.UseShellExecute = false;
            psi.RedirectStandardOutput = true;
            psi.CreateNoWindow = true;
            proc = Process.Start(psi);
            proc.WaitForExit();
           

        }
        public void invoke7() {

            ProcessStartInfo psi = new ProcessStartInfo("cmd", "/C" + WIN7_maj1);
            psi.UseShellExecute = false;
            psi.RedirectStandardOutput = true;
            psi.CreateNoWindow = true;
            Process proc = Process.Start(psi);
            proc.WaitForExit();

            psi = new ProcessStartInfo("cmd", "/C" + WIN7_maj2);
            psi.UseShellExecute = false;
            psi.RedirectStandardOutput = true;
            psi.CreateNoWindow = true;
            proc = Process.Start(psi);
            proc.WaitForExit();

            psi = new ProcessStartInfo("cmd", "/C" + WIN7_maj3);
            psi.UseShellExecute = false;
            psi.RedirectStandardOutput = true;
            psi.CreateNoWindow = true;
            proc = Process.Start(psi);
            proc.WaitForExit();

 MessageBox.Show("Les mises à jours sont retirées, pour les masquer vous devez redemarer, relancer le logiciel, puis cliquer sur le bouton \"retirer mises a jour\"   ", "Redemarage",
MessageBoxButton.OK, MessageBoxImage.Information);


            System.Windows.MessageBoxResult result = MessageBox.Show("Voulez vous redemarer votre ordinateur maintenant? ", "Redemarage",
            MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (result == MessageBoxResult.Yes)
            {
                string d = "shutdown -r ";
                 psi = new ProcessStartInfo("cmd", "/C " + d);
                psi.UseShellExecute = false;
                psi.RedirectStandardOutput = true;
                psi.CreateNoWindow = true;
                proc = Process.Start(psi);
                proc.WaitForExit();


            }
            else {


            }




        }


        public void braw7() {
            List<string> list1 = new List<string>();

            // met les args du programme dans objArgs
                list1.Add("3035583");
                list1.Add("2952664");
                list1.Add("3021917");

            /*
            list1.Add("3154132");
            list1.Add("3147458");
            */
            try
            {
                Type t = Type.GetTypeFromProgID("Microsoft.Update.Session");
                UpdateSession uSession = (UpdateSession)Activator.CreateInstance(t);
                IUpdateSearcher uSearcher = uSession.CreateUpdateSearcher();

                ISearchResult uResult = uSearcher.Search("IsInstalled=0 and Type='Software'");

                foreach (IUpdate update in uResult.Updates)
                {

                    var list = update.KBArticleIDs.Cast<string>().ToList();
                    foreach (string e in list)
                    {
                        Console.Write(e);

                        foreach (string m in list1)
                        {

                            if (m == e)
                            {
                                Console.WriteLine(update.IsHidden);
                                update.IsHidden = true;
                                Console.WriteLine(update.IsHidden);
                            }

                        }

                    }

                    //   Console.WriteLine(update.KBArticleIDs.ToString());


                }
            }
            catch (Exception e1) { Console.WriteLine(e1.Message); }
            finally
            {
                /// Console.ReadKey();
            }
            System.Windows.MessageBoxResult result = MessageBox.Show("Vous devez redemarer votre ordinateur pour que le systeme prenne en compte les modifications  ", "Redemarage",
MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (result == MessageBoxResult.Yes)
            {
                string d = "shutdown -r ";
                ProcessStartInfo psi = new ProcessStartInfo("cmd", "/C " + d);
                psi.UseShellExecute = false;
                psi.RedirectStandardOutput = true;
                psi.CreateNoWindow = true;
                Process proc = Process.Start(psi);
                proc.WaitForExit();


            }
            else {


            }

            _isFree = true;
        }

    public void invoke8()
        {

            ProcessStartInfo psi = new ProcessStartInfo("cmd", "/C" + WIN8_maj1);
            psi.UseShellExecute = false;
            psi.RedirectStandardOutput = true;
            psi.CreateNoWindow = true;
            Process proc = Process.Start(psi);
            proc.WaitForExit();


            psi = new ProcessStartInfo("cmd", "/C" + WIN8_maj2);
            psi.UseShellExecute = false;
            psi.RedirectStandardOutput = true;
            psi.CreateNoWindow = true;
            proc = Process.Start(psi);
            proc.WaitForExit();
        }

        public void test()
        {
            Type t = Type.GetTypeFromProgID("Microsoft.Update.Session");
            UpdateSession uSession = (UpdateSession)Activator.CreateInstance(t);
            IUpdateSearcher uSearcher = uSession.CreateUpdateSearcher();

            ISearchResult uResult = uSearcher.Search("IsInstalled=1 and Type='Software'");
            Console.WriteLine(uResult.Updates.Count); 
            foreach (IUpdate update in uResult.Updates)
            {
                var list = update.KBArticleIDs.Cast<string>().ToList();
                foreach (string e in list)
                {

                    Console.WriteLine(e + "  " + update.Description);
         
                    }

                }

                //   Console.WriteLine(update.KBArticleIDs.ToString());


            }
        }

    }

