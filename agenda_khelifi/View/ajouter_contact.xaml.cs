using agenda_khelifi.agenda_DB;
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
    /// Logique d'interaction pour ajouter_contact.xaml
    /// </summary>
    public partial class ajouter_contact : Page
    {
        public ajouter_contact()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Contacte contacte = new Contacte();
            contacte.Nom = TB_Nom.Text;
            contacte.Prenom = TB_Prenom.Text;
            contacte.Phone = TB_Phone.Text;
            contacte.Email = TB_Email.Text;
            contacte.Adresse = TB_Adresse.Text;
            contacte.Ville = TB_Ville.Text;
            contacte.CodePostal = TB_CodePostal.Text;

            using (var context = new AgendaTahaContext())
            {
                context.Contactes.Add(contacte);
                context.SaveChanges();
            }

            MessageBox.Show("Contacte Ajouter avec succée");



        }
    }
}
