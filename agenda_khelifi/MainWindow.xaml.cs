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

using agenda_khelifi.service.DAO;

namespace agenda_khelifi
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Contact_DB contact_DB;
        public MainWindow()
        {
       
            InitializeComponent();
            contact_DB = new Contact_DB();
            DG_Contacte.ItemsSource = contact_DB.GetContactes();
        }



    }
}
