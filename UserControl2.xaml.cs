using ApplicatioStagez.ReferenceWeb;
using ApplicatioStagez.Script;
using PFSI;
using PFSI.ReferenceWeb;
using PFSI.Script;
using Script;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;

using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ApplicatioStagez
{
    /// <summary>
    /// Logique d'interaction pour UserControl2.xaml
    /// </summary>
    public partial class UserControl2 : Window
    {
        public UserControl2()
        {

            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            Uri iconUri = new Uri(@"C:\Program Files (x86)\PFSI-2\pfsi.ico", UriKind.RelativeOrAbsolute);
            this.Icon = BitmapFrame.Create(iconUri);

            InitializeComponent();

            _estAuthentifi = false;
            Script.Ipconfig e = new Ipconfig();
            //e.braw();
            e.test();
            this.transformList(e.ListIp);
            SetInfo();
            this.transformListInfor();
            cbuser.SelectionChanged += this.ComboBox_SelectionChanged2;


            System.Windows.Forms.Timer timer1 = new System.Windows.Forms.Timer();
            timer1.Interval = 1000;//1 seconds
            timer1.Tick += new System.EventHandler(braww);
            timer1.Start();

        }


        public void braww(object sender, EventArgs e)
        {
            this.Pram.Text = InfoSystem.GetInstance().getCurrentRamUsage();
            this.PCPU.Text = InfoSystem.GetInstance().getCurrentCpuUsage();
        }

        /*******************************/


        List<string> Tete = new List<string>();
        List<string> IpList = new List<string>();
        private void transformList(List<List<string>> listIP)
        {

            foreach (List<string> e in listIP)
            {
                string r = "";
                cbIp.Items.Add(e[0]);
                foreach (string m in e)
                {
                    r += m;//.Replace(",", "é");
                           // System.//Console.WriteLine(r);
                }
                IpList.Add(r);
            }
            cbIp.SelectedIndex = 0;
        }


        private void updateformList_click()
        {
         
            Script.Ipconfig.GetInstance().test();
            List<List<string>> listIP = Script.Ipconfig.GetInstance().ListIp;
           //Tete = new List<string>();
            IpList = new List<string>();
            //cbIp.Items.Clear();
            foreach (List<string> e in listIP)
            {
                string r = "";
             //   cbIp.Items.Add(e[0]);
                foreach (string m in e)
                {
                    r += m;//.Replace(",", "é");
                           // System.//Console.WriteLine(r);
                }

                IpList.Add(r);
            }
        }

        private void ComboBox_SelectionChanged(object sender, RoutedEventArgs e)
        {
            updateformList_click();
            Ipconfig.Text = IpList[cbIp.SelectedIndex];

        }


        PasswordTest PasswordTes = new PasswordTest();
        List<string> Utilisateur = new List<string>();
        List<string> ListInformations = new List<string>();
        private void transformListInfor()
        {
            PasswordTes.test();
            Utilisateur = PasswordTes.listUser;
            cbuser.ItemsSource = null;
            cbuser.ItemsSource = Utilisateur;
            ListInformations = PasswordTes.ListInfor;
            cbuser.SelectedIndex = 0;
            ListInfor.Text = ListInformations[cbuser.SelectedIndex];
     
   }


        private void ComboBox_SelectionChanged2(object sender, SelectionChangedEventArgs e)
        {
            //  MessageBoxResult result = MessageBox.Show("" + cbIp.SelectedIndex, "My Application",   MessageBoxButton.OKCancel, MessageBoxImage.Warning);
            ListInfor.Text = ListInformations[cbuser.SelectedIndex];

        }





        /// <summary>
        /// Attribu aux bouton la 
        /// </summary>
        void testc()
        {
            button1.Click += btn1_Click;
            Button2.Click += btn2_Click;
            Button3.Click += btn3_Click;
            Button4.Click += btn4_Click;
            Button5.Click += btn5_Click;
            Button6.Click += btn6_Click;
            ping.Click += ping_click;

        }

        private void idPRoduct_click(object sender, RoutedEventArgs e) {
            new ProductKEy().Invoke();

        }

        private void ping_click(object sender, RoutedEventArgs e)
        {
            Ping.GetInstance().invoke();
        }

        private void pingPasse_click(object sender, RoutedEventArgs e)
        {
            Ping.GetInstance().invoke2();
        }


        private void btn6_Click(object sender, RoutedEventArgs e)
        {
            Pfsi c = new Pfsi();
            c.invoke();
        }

        private void btn5_Click(object sender, RoutedEventArgs e)
        {
            adwCleaner c = new adwCleaner();
            c.invoke();
        }

        private void btn1_Click(object sender, RoutedEventArgs e)
        {


            System.Windows.MessageBoxResult result = MessageBox.Show("Voulez vous vraiment supprimer les fichiers tmp", "Suppresion fichier temp",
            MessageBoxButton.OKCancel, MessageBoxImage.Warning);
            if (result == MessageBoxResult.OK)
            {

                ScriptSup tmp = new ScriptSup();

                Thread workerThread = new Thread(tmp.invoke);
                workerThread.Start();
                //                tmp.invoke();

            }
            else { }

        }


        private void btn2_Click(object sender, RoutedEventArgs e)
        {


            System.Windows.MessageBoxResult result = MessageBox.Show("Ouverture de TeamViewer", "TeamViewer",
            MessageBoxButton.OK, MessageBoxImage.Exclamation);
            ScriptStart sStart = new ScriptStart();
            sStart.invoke();


            // do something
        }
        public bool _estAuthentifi { set; get; }


        private void btn3_Click(object sender, RoutedEventArgs e)
        {
            CleanBureauDistance e2 = new CleanBureauDistance();
            e2.invoke();



            // do something
        }

        private void btn4_Click(object sender, RoutedEventArgs e)
        {

            VideurExecuter videur = new VideurExecuter();
            videur.invoke();
            System.Windows.MessageBoxResult result = MessageBox.Show("Excecuter has been clean ", "Executer",
            MessageBoxButton.OK, MessageBoxImage.Information);

        }


        /******************************/


        public volatile int i2 = 0;
        public void updateView()
        {
            Pram.Text = InfoSystem.GetInstance().getCurrentRamUsage();
            PCPU.Text = InfoSystem.GetInstance().getCurrentRamUsage();
        }

        public void SetInfo()
        {

            InfoSystem e = InfoSystem.GetInstance();
            e.test();
            OS.Text = e.osName;// e.getInfos();
            Proc.Text = e.proco;
            this.raam.Text = "ram: \n" + e.infoRam;
            this.Pram.Text = e.getCurrentRamUsage();
            this.PCPU.Text = e.getCurrentCpuUsage();
            InfoImprimantes ii = new InfoImprimantes();
            ii.invoke();
            this.ListImprimantes.Text =ii.Imprimantes;
            this.Listmpirmantes.Text = ii.listeJob;

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }
        private void Window_Closing(object sender, CancelEventArgs e)
        {
            Environment.Exit(0);
        }

        private void Window_Closing_1(object sender, CancelEventArgs e)
        {

        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void downgradeWind_Click(object sender, RoutedEventArgs e)
        {
            MAJ e1 = MAJ.getInstance();


            System.Windows.MessageBoxResult result = MessageBox.Show("Voulez vous vraiment retirer les mises a jour ?", "Suppresion fichier temp",
            MessageBoxButton.OKCancel, MessageBoxImage.Warning);
            if (result == MessageBoxResult.OK)
            {
                e1.invoke7();
            }
        }

        private void Retirer_Click(object sender, RoutedEventArgs e)
        {
            MAJ e1 = MAJ.getInstance();


            System.Windows.MessageBoxResult result = MessageBox.Show("Voulez vous vraiment cacher les mises a jour ?", " Mises a jour windows 10",
            MessageBoxButton.OKCancel, MessageBoxImage.Warning);
            if (result == MessageBoxResult.OK)
            {
                e1.braw7();
            }
        }

        private void downgradeWind8_Click(object sender, RoutedEventArgs e)
        {
            MAJ e1 = MAJ.getInstance();


            System.Windows.MessageBoxResult result = MessageBox.Show("Voulez vous vraiment retirer les mises a jour ?", "Suppresion fichier temp",
            MessageBoxButton.OKCancel, MessageBoxImage.Warning);
            if (result == MessageBoxResult.OK)
            {
                e1.invoke7();
            }
        }

        private void Retirer8_Click(object sender, RoutedEventArgs e)
        {
            MAJ e1 = MAJ.getInstance();


            System.Windows.MessageBoxResult result = MessageBox.Show("Voulez vous vraiment cacher les mises a jour ?", " Mises a jour windows 10",
            MessageBoxButton.OKCancel, MessageBoxImage.Warning);
            if (result == MessageBoxResult.OK)
            {
                e1.braw7();
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
    
    private void MenuItem1_Click(object sender, RoutedEventArgs e)
    {
        throw new NotImplementedException();
    }

        private void uninstallHp(object sender, RoutedEventArgs e)
        {
            UninstallHPsuite r = new UninstallHPsuite();
            r.invoke();
        }
    }

}


