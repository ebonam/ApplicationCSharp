using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PFSI
{
    class ErrorCode
    {
       /* public string availibility(int code) {

            switch (code)
            {

                case 1:
                    return "Autres";
                case 2:
                    return "Unknown";
                case 3:
                    return "Running / Full Power(3)" + "\n" +

"Running or Full Power";
                case 4:

                    return "Attention";

                case 5: return "En Test ";

                case 6: return "Not Applicable";

                case 7: return "Power Off";


                case 8:
                    return " Off Line";

                case 9:
                    return " Off Duty";

                case 10:
                    return "Degraded";
                case 11:
                    return "Pas Installé";

                case 12:
                    return " erreur d'installation";

                case 13:
                    return "Power Save - Unknown \n" +

"    The device is known to be in a power save mode, but its exact status is unknown.";

                case 14:
                    return "Power Save - Low Power Mode\n" +
"The device is in a power save state but is still functioning, and may exhibit degraded performance.";

                case 15:
                    return " Power Save - Standby \n" +

    "The device is not functioning, but could be brought to full power quickly.";

                case 16: return "Power Cycle";

                case 17:
                    return "Power Save - Warning" + "The device is in a warning state, though also in a power save mode."
;
                case 18:

                    return "The device is paused.";

                case 19: return "Not Ready" + "The device is not ready.";

                case 20:
                    return "Not Configured \n " + "The device is not configured."
                   ;
                case 21:
                    return "Quiesced \n" +

            "    The device is quiet";



            }
            return null;
        }

        public string ConfigManagerErrorCode(int code) {

            switch(code){ 
           case 0 :return "This device is working properly." 

+  "  Device is working properly.";


                case 1:return "This device is not configured correctly." +

"    Device is not configured correctly.";

                case 2: return "Windows cannot load the driver for this device. ";

                case 3:return "The driver for this device might be corrupted, or your system may be running low on memory or other resources. " +

"    Driver for this device might be corrupted, or the system may be low on memory or other resources.";

                case 4: return"This device is not working properly.One of its drivers or your registry might be corrupted. (4)"+

    "Device is not working properly.One of its drivers or the registry might be corrupted.";

                case 5:return "The driver for this device needs a resource that Windows cannot manage."

+ "Driver for the device requires a resource that Windows cannot manage.";

                case 6: return "The boot configuration for this device conflicts with other devices. "

+    "Boot configuration for the device conflicts with other devices.";

                case 7: return " Cannot filter.";

                case 8: return "The driver loader for the device is missing." + "Driver loader for the device is missing.";

                case 9:return "This device is not working properly because the controlling firmware is reporting the resources for the device incorrectly."+

                    "Device is not working properly.The controlling firmware is incorrectly reporting the resources for the device.";


                case 10: return "This device cannot start."
+ "Device cannot start.";

                case 11:return "This device failed." +


"Device failed.";

                case 12: return "This device cannot find enough free resources that it can use."


+ " Device cannot find enough free resources to use";

case 13: return "Windows cannot verify this device's resources. " +


"Windows cannot verify the device's resources.";


                case 14:return "This device cannot work properly until you restart your computer."
                        +
"Device cannot work properly until the computer is restarted.";

                case 15:return " This device is not working properly because there is probably a re - enumeration problem. " +


   "Device is not working properly due to a possible re - enumeration problem.";

                case 16: return "Windows cannot identify all the resources this device uses. (16)"+


   "Windows cannot identify all of the resources that the device uses.";

                case 17: return "This device is asking for an unknown resource type." +


   "Device is requesting an unknown resource type.";

                case 18: return "Reinstall the drivers for this device. (18)" +


  " Device drivers must be reinstalled.";

                case 19: return " Failure using the VxD loader. ";

                case 20:return "Your registry might be corrupted." +

    "Registry might be corrupted.";
                case 21:
                    return
"System failure: Try changing the driver for this device.If that does not work, see your hardware documentation.Windows is removing this device. (21)" +

"    System failure.If changing the device driver is ineffective, see the hardware documentation.Windows is removing the device.";

case 22:return "This device is disabled. "
                        +
 "   Device is disabled.";

case 23:return "System failure: Try changing the driver for this device.If that doesn't work, see your hardware documentation. " +

"    System failure.If changing the device driver is ineffective, see the hardware documentation.";
                case 24: return 
                    "This device is not present, is not working properly, or does not have all its drivers installed. " +

                    "    Device is not present, not working properly, or does not have all of its drivers installed.";

                case 25 : return " Windows is still setting up this device." +

"    Windows is still setting up the device.";

                case 26:return "Windows is still setting up this device. " +

    "Windows is still setting up the device.";

                case 27:return "This device does not have valid log configuration." +

"    Device does not have a valid log configuration.";

                case 28:return " The drivers for this device are not installed. (28)"
                        +
"    Device drivers are not installed.";

case 29:return "This device is disabled because the firmware of the device did not give it the required resources." +

    "Device is disabled.The device firmware did not provide the required resources.";

                case 30:return "This device is using an Interrupt Request(IRQ) resource that another device is using. "
                        +
"Device is using an IRQ resource that another device is using.";

                case 31:return "This device is not working properly because Windows cannot load the drivers required for this device. " +

   "Device is not working properly.Windows cannot load the required device drivers";
                

}
            return null;
        }
        public string ExtendedDetectedErrorStateValue(int code)
        {

            switch (code)
            {
                case 0:

                    return "Unknown";
                case 1:

                    return " Autre";
                case 2:

                    return "Pas d'Erreur";
                case 3:

                    return "Papier bas";
                case 4:

                    return "Pas de Papier";
                case 5:

                    return "Toner bas";
                case 6:

                    return "plus de  Toner";
                case 7:

                    return "porte ouverte";
                case 8:

                    return "coincé";
                case 9:

                    return "service Requested";
                case 10:

                    return "Output Bin Full";
                case 11:

                    return "Probleme de papier";
                case 12:

                    return "impossible d'imprimer la page";
                case 13:

                    return "User Intervention Required";
                case 14:

                    return "plus de memoire";
                case 15:
                    return "serveur inconnu";

            }
            return "NOT SUPPORTED";
        }

        public string ExtendedPrinterStatus(int code)
        {

            switch (code)
            {
                case 1:

                    return "Other";
                case 2:

                    return "Unknown";
                case 3:

                    return "Idle";
                case 4:

                    return "Printing";
                case 5:

                    return "Warming Up";
                case 6:

                    return "Stopped Printing";
                case 7:

                    return "Offline";
                case 8:

                    return "Paused";
                case 9:

                    return "Error";
                case 10:

                    return "Busy";
                case 11:


                    return "Not Available";
                case 12:

                    return "Waiting";
                case 13:

                    return "Processing";
                case 14:

                    return "Initialization";
                case 15:

                    return "Power Save";
                case 16:

                    return "Pending Deletion";
                case 17:
                    return "I/O Active";
                case 18:

                    return "Manual Feed";






            }
            return "";
        }
        */
    }
}
