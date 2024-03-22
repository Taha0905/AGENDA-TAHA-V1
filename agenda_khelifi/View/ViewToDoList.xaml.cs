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

namespace agenda_khelifi.View
{
    /// <summary>
    /// Logique d'interaction pour ViewToDoList.xaml
    /// </summary>
    public partial class ViewToDoList : UserControl
    {
        DAO_Contact contact_DB;

        public ViewToDoList()
        {
            InitializeComponent();
            //afficher la liste des taches
            DG_Tasks.ItemsSource = new DAO_Task().GetTasks();






        }

  
    }
}
