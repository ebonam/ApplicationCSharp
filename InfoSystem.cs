using Microsoft.Win32;
using System;
using System.Collections.Generic;

using System.Text;
using System.Management;//ManagementObjectSearcher;
using System.Diagnostics;
using System.Threading;
using ApplicatioStagez.Script;
using System.Windows;

namespace ApplicatioStagez
{
    /// <summary>
    /// retourne des information systemes
    /// </summary>
    public class InfoSystem : RetouneInfo, FaitAction
    {
        /// <summary>
        /// Constructeur par defzult
        /// </summary>
        private InfoSystem()
        {
            this.init_Counter();
        }

        /// <summary>
        /// Fct de test
        /// </summary>
        public void test()
        {
            this.getOperatingSystemInfo();
            this.getProcessorInfo();
            this.ram();
            //  this.tour();


        }

        public string osName { get; set; }
        /// <summary>
        /// Retourne l'os + diverse infos
        /// </summary>
        public void getOperatingSystemInfo()
        {
            string str = "";

            //Console.WriteLine("Displaying operating system info....\n");

            System.Management.ManagementObjectSearcher mos = new ManagementObjectSearcher("select * from Win32_OperatingSystem");
            foreach (ManagementObject managementObject in mos.Get())
            {
                //              
                if (managementObject["Caption"] != null)
                {

                    str += managementObject["Caption"].ToString();
                }
                if (managementObject["OSArchitecture"] != null)
                {

                    //Console.WriteLine("OS Architecture  :  " + managementObject["OSArchitecture"].ToString());   //Display operating system architecture.
                    //                    ListProcesseur.Add();
                    str += " " + managementObject["OSArchitecture"].ToString();
                }
                if (managementObject["CSDVersion"] != null)
                {
                    //Console.WriteLine(" csdVersion ServicePack   :  " + managementObject["CSDVersion"].ToString());     //Display operating system version.
                    str += " " + managementObject["CSDVersion"].ToString();
                }

                this.osName = str;
            }
        }


        /// <summary>
        /// Affiche la ram toutes infos memoire, type, vitesse
        /// </summary>
        public void ram()
        {
            memory = 0;
            ConnectionOptions connection = new ConnectionOptions();
            connection.Impersonation = ImpersonationLevel.Impersonate;

            ManagementScope scope = new ManagementScope("\\\\.\\root\\CIMV2", connection);
            scope.Connect();

            ObjectQuery query = new ObjectQuery("SELECT * FROM Win32_PhysicalMemory");

            ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, query);
            string infoRam2 = "Capacity   |  MemoryType    |  TypeDetail";

            string infoRam3 = "________________________________________________\n" +
                              "Speed       | Label                           \n";
            string infoRam4 = "";
            int i = 1;
            string infoRamTMP="" , infoRam4TMP="" ;
            foreach (ManagementObject queryObj in searcher.Get())
            {

                try
                {
                    infoRamTMP = "";
                    infoRam4TMP = "";
                    memory += (float.Parse(queryObj["Capacity"].ToString()) / 1048576);
                 
                    /*    //Console.WriteLine("-----------------------------------");
                        //Console.WriteLine("Capacity: {0}", queryObj["Capacity"]);
                       //Console.WriteLine("MemoryType: {0}", queryObj["MemoryType"]);
                      */


                    infoRamTMP += (float.Parse(queryObj["Capacity"].ToString()) / 1048576);


                    while (infoRamTMP.Length < 13 * i)
                    {
                        infoRamTMP += ' ';
                    }
                    infoRamTMP += "| ";


                    infoRamTMP += queryObj["MemoryType"].ToString();


                    while (infoRamTMP.Length < 28 * i + 9)
                    {
                        infoRamTMP += ' ';
                    }
                    infoRamTMP += "  | ";



                    infoRamTMP += queryObj["TypeDetail"].ToString();





                    infoRam4TMP += queryObj["Speed"].ToString();


                    while (infoRam4TMP.Length < 14 * i)
                    {
                        infoRam4TMP += ' ';

                    }
                    infoRam4TMP += "| ";

                    infoRam4TMP += queryObj["BankLabel"].ToString();



                    infoRam+= infoRamTMP + "\n";
                    infoRam4 += infoRam4TMP + "\n";
                }
                catch (Exception e)
                {
                    System.Windows.MessageBoxResult result = MessageBox.Show(e.Message, "Suppresion fichier temp",
       MessageBoxButton.OKCancel, MessageBoxImage.Warning);
                    Console.Write(e.Message);
                }

            }
            infoRam2 += "\n"+infoRam;
            infoRam = infoRam2;
            infoRam += infoRam3;
            infoRam += infoRam4;

        

        }

        PerformanceCounter cpuCounter;
        PerformanceCounter ramCounter;
        public string infoRam { get; set; }

        List<string> ListProcesseur { set; get; }
        private float CpuPercentUsed { set; get; }
        private float RamAvailable { set; get; }

        /// <summary>
        ///initialiser les compteur 
        /// </summary>

        public void init_Counter()
        {
            cpuCounter = new PerformanceCounter();
            cpuCounter.CategoryName = "Processor";
            cpuCounter.CounterName = "% Processor Time";
            cpuCounter.InstanceName = "_Total";

            ramCounter = new PerformanceCounter("Memory", "Available MBytes");
        }
        /// <summary>
        /// Fct de test pour les compteurs
        /// </summary>
        public void tour()
        {

            /*    for (int i = 0; i < 3; i++) {
                  //Console.WriteLine(  getCurrentCpuUsage());
                   //Console.WriteLine( getCurrentRamUsage());
                    Thread.Sleep(1000);
                }*/


        }

        /// <summary>
        /// renvoi le pourcentage du cpu
        /// </summary>
        /// <returns></returns>
        public string getCurrentCpuUsage()
        {
            float m=cpuCounter.NextValue();
            return m.ToString(".##") + "%";

        }



        private static InfoSystem instance;
        /// <summary>
        /// Singleton
        /// </summary>
        /// <returns></returns>
        public static InfoSystem GetInstance()
        {

            if (instance == null)
                instance = new InfoSystem();
            return instance;
        }


        /// <summary>
        /// renvoi le pourcentage de Ram
        /// </summary>
        /// <returns>Free ram(mb)</returns>

        public string getCurrentRamUsage()
        {
                  //  long memory = GC.GetTotalMemory(true);

            float m=  (ramCounter.NextValue() / (memory )* 100) ;
           // Console.WriteLine(ramCounter.NextValue());
            return m.ToString(".##")+"%";
        }
        float memory = 0;
        /// <summary>
        /// Stock le nom du processeur 
        /// voir pour l'utilisation processeur
        /// </summary>   
        public string proco { get; set; }
        public void getProcessorInfo()
        {
            //Console.WriteLine("Proco....");
            RegistryKey processor_name = Registry.LocalMachine.OpenSubKey(@"Hardware\Description\System\CentralProcessor\0", RegistryKeyPermissionCheck.ReadSubTree);   
            if (processor_name != null)
            {
                if (processor_name.GetValue("ProcessorNameString") != null)
                {
                    proco = (string)processor_name.GetValue("ProcessorNameString");   //Display processor ingo.
                }
            }
        }

        public void invoke()
        {
            this.tour();
        }

        public string[] getInfos()
        {
            throw new NotImplementedException();
        }


    }
}

