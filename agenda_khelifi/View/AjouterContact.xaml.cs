using System;
using System.Collections.Generic;
using System.ComponentModel;
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


namespace agenda_khelifi.View
{
    /// <summary>
    /// Logique d'interaction pour AjouterContact.xaml
    /// </summary>
    public partial class AjouterContact : UserControl
    {
        public AjouterContact()
        {
            InitializeComponent();


        }

        private void Button_ok(object sender, RoutedEventArgs e)
        {
            //prend les info des TB pour les mettre dans la base de donnee et ensuite les afficher dans la liste des contactes
            Contacte contacte = new Contacte();
            contacte.Nom = TB_Nom.Text;
            contacte.Prenom = TB_Prenom.Text;
            contacte.Phone = TB_Phone.Text;
            contacte.Email = TB_Email.Text;
            contacte.Adresse = TB_Adresse.Text;
            //ville
            contacte.Ville = TB_Ville.Text;
            //code postal
            contacte.CodePostal = TB_CodePostal.Text;
            //status
            contacte.Status = CB_Status.Text;
            //enregistrer dans la base de donnee
            DAO_Contact contact_DB = new DAO_Contact();
            contact_DB.AddContacte(contacte);
            //afficher "contacte ajouter" dans un message box et vider toutes les TB
            MessageBox.Show("Contact ajouter");
            TB_Nom.Text = "";
            TB_Prenom.Text = "";
            TB_Phone.Text = "";
            TB_Email.Text = "";
            TB_Adresse.Text = "";
            TB_Ville.Text = "";
            TB_CodePostal.Text = "";

        }

        private void Button_retour(object sender, RoutedEventArgs e)
        {


        }
    }
}
