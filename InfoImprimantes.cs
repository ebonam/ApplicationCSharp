using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;

namespace PFSI
{
    class InfoImprimantes
    {

        public string Imprimantes,listeJob;

        public void invoke()
        {
            
          
            ConnectionOptions connection = new ConnectionOptions();
            connection.Impersonation = ImpersonationLevel.Impersonate;

            ManagementScope scope = new ManagementScope("\\\\.\\root\\CIMV2", connection);
            scope.Connect();

            ObjectQuery query = new ObjectQuery("SELECT * FROM Win32_bios");

            ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, query);
            
            string bios="";
            foreach (ManagementObject queryObj in searcher.Get())
            {

                bios += "\nManufacturer : " + queryObj["Manufacturer"].ToString();
                bios += "\nVersion " + queryObj["Version"].ToString();
                bios += "\nSerial Number:" + queryObj["SerialNumber"].ToString();// + "  \nDate et heure:" + this.parseDate(r).ToString() + " \nFormat : " + queryObj["Papersize"].ToString();


                

            }
            //-------------------------------------------------------PrintJob

            query = new ObjectQuery("SELECT * FROM Win32_Printjob");

            searcher = new ManagementObjectSearcher(scope, query);
            ManagementObjectCollection e = searcher.Get();
            string printjob="";
            foreach (ManagementObject queryObj in searcher.Get())
            {
                string braw = queryObj["timeSubmitted"].ToString();
                string[] tablString = new string[] { "+", "." };
                string streng = braw.Split(tablString, StringSplitOptions.None)[0];
                long r = (long.Parse(streng));
            
                printjob +="\nNom : "+queryObj["Description"].ToString()+"\ncolor "+ queryObj["color"].ToString()+"\nnom du driver:"+queryObj["DriverName"].ToString()+"  \nDate et heure:"+this.parseDate(r).ToString()+" \nFormat : "+queryObj["Papersize"].ToString();
            
                this.listeJob += printjob+ "--------------------";
                Console.WriteLine(printjob);
        
            }


            
            //-------------------------------------------------------BaseBoard

            query = new ObjectQuery("SELECT * FROM Win32_BaseBoard");

            searcher = new ManagementObjectSearcher(scope, query);
           
            string carteMere = "";
            try
            {
                foreach (ManagementObject queryObj in searcher.Get())
                {
                    carteMere += "\nFabricant :" + queryObj["Manufacturer"].ToString() + 
                        "\nProduit  :" + queryObj["Product"].ToString() + 
                        "\nVersion " + queryObj["Version"].ToString() +
                  "\n numero de serie"+  queryObj["serialNumber"].ToString();

                    Console.WriteLine(carteMere);

                    

                }
            }
            catch (Exception er) { Console.WriteLine(er.Message); }
            
        
            query = new ObjectQuery("SELECT * FROM Win32_Printer");

            searcher = new ManagementObjectSearcher(scope, query);

            foreach (ManagementObject queryObj in searcher.Get())
            {
                string printer = "";
            
                printer += queryObj["Name"].ToString()+":";
                printer += "\nImprimante reseau :" + queryObj["Network"].ToString() + "\n";
                printer += "WorkOffline :" + queryObj["WorkOffline"].ToString() + "\n";
                printer += "Partagée :" + queryObj["Shared"].ToString() + "\n";
                printer += "Nom du driver :" + queryObj["DriverName"].ToString() + "\n";
                if (queryObj["ShareName"] != null)
                    printer += "nom partagée :" + queryObj["ShareName"].ToString() + "\n";
                //printer += "  nom du serveur :" + queryObj["ServerName"].ToString();
                if (queryObj["Availability"] != null)
                    printer += queryObj["Availability"].ToString() + "\n";
                if (queryObj["ConfigManagerErrorCode"] != null)
                    printer += queryObj["ConfigManagerErrorCode"].ToString() + "\n";

                printer += "----------------------\n";
                this.Imprimantes += printer;

                Console.WriteLine(printer);


        
               
            }
            
           // System.IO.File.WriteAllText(@"C:\Users\Public\WriteText.txt", tout);


        }




        //Console.WriteLine(infoRam);

        //-------------------------------------------------------Printerconfig
        /*
        query = new ObjectQuery("SELECT * FROM Win32_PrinterConfiguration");

        searcher = new ManagementObjectSearcher(scope, query);
        foreach (ManagementObject queryObj in searcher.Get())
        {
            //memory += (float.Parse(queryObj["Manufacturer"].ToString()) / 1048576);



            infoRamTMP += queryObj["Name"].ToString();


            while (infoRamTMP.Length < 13 * i)
            {
                infoRamTMP += ' ';
            }
            infoRamTMP += "| ";


            //infoRamTMP += queryObj["Color"].ToString();


            while (infoRamTMP.Length < 28 * i + 9)
            {
                infoRamTMP += ' ';
            }
            infoRamTMP += "  | ";
            //      infoRamTMP += queryObj["Version"].ToString();
            infoRam += infoRamTMP;


            //                /paperLength   /PaperSize  /PaperWidth   /Paint quality
        }
        infoRam2 += "\n" + infoRam;
        infoRam = infoRam2;
        infoRam += infoRam3;
        infoRam += infoRam4;
        */
        //-------------------------------------------------------Printer



        public DateTime parseDate(long e = 201603010830)
        {
            int year, month, day, hour, minutes;
            year = (int)(e / 10000000000);
            month = (int)(e / 100000000 - year * 100);
            day = (int)(e / 1000000 - (month * 100 + year * 10000));

            hour = (int)(e / 10000 - (month * 10000 + year * 1000000 + day * 100));
            minutes = (int)(e / 100 - (month * 1000000 + year * 100000000 + day * 10000 + hour * 100));

            DateTime dt = new DateTime(year, month, day, hour, minutes, 0);
            Console.WriteLine(dt.ToLongDateString() + "  " + dt.ToLongTimeString());
            return dt;
        }
    }



}

