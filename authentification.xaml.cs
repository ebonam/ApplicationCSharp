using System;
using System.Collections.Generic;
using System.ComponentModel;

using System.Text;
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
    /// Logique d'interaction pour authentification.xaml
    /// </summary>
    public partial class authentification : Window
    {

//private        UserControl2 u;
        public authentification()
        {
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            InitializeComponent();

  //          u = uc;
            testc();

        }
        void testc()
        {
            //  task = Task.Factory.StartNew(DoWork);

            this.Valider.Click += Valider_Click;
            Annuler.Click += Annuler_Click;
            
        }
        private void Window_Closing(object sender, CancelEventArgs e)
        {
            Environment.Exit(-1);
               }


        private void Annuler_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(-1);
                
                }

        private void Valider_Click(object sender, RoutedEventArgs e)
        {

            if (Password.Password == "sos")
            {

    //            u._estAuthentifi = true;
                System.Windows.MessageBoxResult result = MessageBox.Show("Voulez etes maintenant authentifié", "Succes",
            MessageBoxButton.OK, MessageBoxImage.Information);
                this.Visibility=System.Windows.Visibility.Collapsed;
            }
            else {
                System.Windows.MessageBoxResult result = MessageBox.Show("Erreur mot de passe.\n Veuillez recommencer", "Erreur",
         MessageBoxButton.OKCancel, MessageBoxImage.Error);
                if (result == MessageBoxResult.Cancel)
                {
                    Environment.Exit(-1);
                }
                else {
                    Password.Password = "";
                }

            }
        }

        private void braw(object sender, KeyEventArgs e)
        {

            if (e.Key == Key.Enter)
            {
                if (Password.Password == "sos")
                {

                    //            u._estAuthentifi = true;
                    System.Windows.MessageBoxResult result = MessageBox.Show("Voulez etes maintenant authentifié", "Succes",
            MessageBoxButton.OK, MessageBoxImage.Information);
                this.Visibility = System.Windows.Visibility.Collapsed;
            }
            else {
                System.Windows.MessageBoxResult result = MessageBox.Show("Erreur mot de passe.\n Veuillez recommencer", "Erreur",
         MessageBoxButton.OKCancel, MessageBoxImage.Error);
                if (result == MessageBoxResult.Cancel)
                {
                    Environment.Exit(-1);
                }
                else {
                    Password.Password = "";
                }

            }
        }

        }
    }
}
