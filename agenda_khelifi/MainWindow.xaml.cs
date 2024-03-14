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
            DG_Contacte.ItemsSource = contact_DB.GetContactes();

        }

        private void Button_ajouter(object sender, RoutedEventArgs e)
        {
            //afficher la page ajouter contact quand je clique sur le button ajouter
            ajouter_contact ajouter_Contact = new ajouter_contact();
            this.Content = ajouter_Contact;



        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //sauvegarder un contacte quand je clic sur le button modifier
            Contacte contacte = DG_Contacte.SelectedItem as Contacte;
            contact_DB.UpdateContacte(contacte);
            DG_Contacte.ItemsSource = contact_DB.GetContactes();




        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            //supprimer un contacte quand je clic sur le button supprimer quand jai selectionner un contacte dans la base de donnee
            Contacte contacte = DG_Contacte.SelectedItem as Contacte;
            contact_DB.DeleteContacte(contacte.Id);
            DG_Contacte.ItemsSource = contact_DB.GetContactes();

        }
    }
}
