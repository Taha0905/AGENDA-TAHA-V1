using System;
using System.Collections.Generic;
using System.Linq;
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
using agenda_khelifi.agenda_DB;
using agenda_khelifi.service.DAO;

namespace agenda_khelifi.View
{
    /// <summary>
    /// Logique d'interaction pour AjouterTask.xaml
    /// </summary>
    public partial class AjouterTask : UserControl
    {
        public AjouterTask()
        {
            InitializeComponent();


        }

        private void Button_AddTask(object sender, RoutedEventArgs e)
        {
            //prend les info des TB pour les mettre dans la base de donnee et ensuite les afficher dans la liste des taches et gestion d'erreur si aucune TB est remplie
            Task task = new Task();
            task.TaskName = TB_Task.Text;
            task.TaskDescription = TB_Description.Text;
            //enregistrer dans la base de donnee
            DAO_Task task_DB = new DAO_Task();
            task_DB.AddTask(task);
            //afficher "tache ajouter" dans un message box et vider toutes les TB
            MessageBox.Show("Tache ajouter");
            TB_Task.Text = "";
            TB_Description.Text = "";


        }

        private void Button_DetailTask(object sender, RoutedEventArgs e)
        {


        }
    }
}
