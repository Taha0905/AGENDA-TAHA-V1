using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using agenda_khelifi.agenda_DB;
using agenda_khelifi.service.DAO;
using agenda_khelifi.View;

namespace agenda_khelifi
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        DAO_Contact contact_DB;
        public MainWindow()
        {

            InitializeComponent();
            contact_DB = new DAO_Contact();

            //voir si la base de donnee existe sinon rendre innactif le button contacte et affichr un message "base de donnee n'existe pas"
            if (!contact_DB.DBExists())
            {
                Button_Contacte.IsEnabled = false;
                MessageBox.Show("La base de donnee n'existe pas");
            }
            else
            {
                Button_Contacte.IsEnabled = true;
            }

        }



        private void Button_contacte(object sender, RoutedEventArgs e)
        {
            //afficher la page contacte "LaViewContact quand je clique sur le button contacte
            Container.Children.Clear();
            LaViewContact laviewcontrol = new LaViewContact();
            Container.Children.Add(laviewcontrol);
        }

        private void Button_liste(object sender, RoutedEventArgs e)
        {
            //afficher la page liste des taches "ViewToDoList" quand je clique sur le button liste
            Container.Children.Clear();
            ViewToDoList viewtodolistcontrol = new ViewToDoList();
            Container.Children.Add(viewtodolistcontrol);

        }

        private void Button_Calendrier(object sender, RoutedEventArgs e)
        {

        }

        private void Button_menu(object sender, RoutedEventArgs e)
        {

        }
    }
}
