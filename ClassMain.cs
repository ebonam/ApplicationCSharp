using ApplicationStagez;
using ApplicatioStagez;
using ApplicatioStagez.ReferenceWeb;
using ApplicatioStagez.Script;
using PFSI;
using PFSI.ReferenceWeb;
using PFSI.Script;
using Script;
using System;
using System.Diagnostics;
using System.IO;
using System.Management;
using System.Threading;
using System.Windows;
using System.Windows.Forms;

namespace ApplicationStage
{
    /// <summary>
    /// Classe Principale
    /// </summary>
    class ClassMain
    {
        /// <summary>
        /// Point d'entree du programme
        /// </summary>
        /// <param name="args"></param>
        [STAThread]
        static void Main(string[] args)
        {
             
                        authentification frmAbout = new authentification();
                        frmAbout.ShowDialog();                 
                        App app = new App();
                        app.ShutdownMode = ShutdownMode.OnExplicitShutdown;
                        UserControl2 mainWindow = new UserControl2();
                        app.MainWindow = mainWindow;
                        app.Run(mainWindow);
            Directory.GetCurrentDirectory();
        }



    }

}










