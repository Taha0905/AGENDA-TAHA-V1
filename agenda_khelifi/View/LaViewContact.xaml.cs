using agenda_khelifi.agenda_DB;
using agenda_khelifi.service.DAO;
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


namespace agenda_khelifi.View
{
    /// <summary>
    /// Logique d'interaction pour LaViewContact.xaml
    /// </summary>
    public partial class LaViewContact : UserControl
    {
        DAO_Contact contact_DB;
        public LaViewContact()
        {
            InitializeComponent();
            contact_DB = new DAO_Contact();
            DG_Contacte.ItemsSource = contact_DB.GetContactes();
        }
        private void Button_ajouter(object sender, RoutedEventArgs e)
        {
            //afficher la page ajouter_contact quand je clique sur le button ajouter 
            Contact_Container.Children.Clear();
            AjouterContact ajoutercontrol = new AjouterContact();
            Contact_Container.Children.Add(ajoutercontrol);
        }

        private void Button_modifier(object sender, RoutedEventArgs e)
        {
            //sauvegarder un contacte quand je clic sur le button modifier et gestion d'erreur si je n'ai pas selectionner un contacte
            Contacte contacte = DG_Contacte.SelectedItem as Contacte;
            if (contacte != null)
            {
                contact_DB.UpdateContacte(contacte);
                DG_Contacte.ItemsSource = contact_DB.GetContactes();
            }
            else
            {
                MessageBox.Show("Veuillez selectionner un contacte");
            }

        }

        private void Button_supprimer(object sender, RoutedEventArgs e)
        {
            //supprimer un contacte quand je clic sur le button supprimer quand jai selectionner un contacte dans la base de donnee et demander si je suis sur de supprimer et gestion d'erreur si je n'ai pas selectionner un contacte
            Contacte contacte = DG_Contacte.SelectedItem as Contacte;
            if (contacte != null)
            {
                MessageBoxResult result = MessageBox.Show("Etes vous sur de vouloir supprimer ce contacte", "Confirmation", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    contact_DB.DeleteContacte(contacte);
                    DG_Contacte.ItemsSource = contact_DB.GetContactes();
                }
            }
            else
            {
                MessageBox.Show("Veuillez selectionner un contacte");
            }
        }

        private void Button_rechercher(object sender, RoutedEventArgs e)
        {
            //rechercher un contacte par nom quand je clic sur le button rechercher
            DG_Contacte.ItemsSource = contact_DB.GetContactes(TB_Recherche.Text);
        }


        private void Button_click_amis(object sender, RoutedEventArgs e)
        {
            //rechercher un contacte par status "Amis" quand je clic sur le button amis
            DG_Contacte.ItemsSource = contact_DB.GetContactesAmis();

        }

        private void Button_click_Famille(object sender, RoutedEventArgs e)
        {
            //rechercher un contacte par status "Famille" quand je clic sur le button famille
            DG_Contacte.ItemsSource = contact_DB.GetContactesFamille();

        }

        private void Button_click_travail(object sender, RoutedEventArgs e)
        {
            //rechercher un contacte par status "Collègue" quand je clic sur le button travail
            DG_Contacte.ItemsSource = contact_DB.GetContactesCollegue();

        }

        private void Button_details(object sender, RoutedEventArgs e)
        {
            //afficher les reseaux d'un contacte quand je clic sur le button details et gestion d'erreur si je n'ai pas selectionner un contacte
            Contacte contacte = DG_Contacte.SelectedItem as Contacte;
            if (contacte != null)
            {
                DAO_Reseaux reseau_DB = new DAO_Reseaux();
                DG_Contacte.ItemsSource = reseau_DB.GetReseaux(contacte.Id);
            }
            else
            {
                MessageBox.Show("Veuillez selectionner un contacte");
            }



        }
    }
}
