using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using agenda_khelifi.agenda_DB;
using agenda_khelifi.service.DAO;


namespace agenda_khelifi.View
{
    public partial class ViewToDoList : UserControl
    {
        DAO_Task task_DB;

        public IEnumerable<Task> Tasks { get; set; }

        public ViewToDoList()
        {
            InitializeComponent();
            task_DB = new DAO_Task();

            LoadTasks();
        }

        private void LoadTasks()
        {
            // Utilisez la méthode GetTasks() de votre DAO_Task pour obtenir les tâches depuis la base de données
            Tasks = task_DB.GetTasks();


            // Assurez-vous que la propriété Tasks est correctement définie comme source de données
            DataContext = this;
        }

        private void AjouterTask_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            // Affichez la vue AjouterTask dans le conteneur 
            Task_container.Children.Clear();
            AjouterTask ajouterTask = new AjouterTask();
            Task_container.Children.Add(ajouterTask);

        }

        private void ModifierTask_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            // Mettez à jour la tâche sélectionnée
            Task task = LV_Task.SelectedItem as Task;
            if (task != null)
            {
                task_DB.UpdateTask(task);
                Tasks = task_DB.GetTasks();
                LV_Task.ItemsSource = Tasks;
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner une tâche");
            }

        }


        private void SupprimerTask_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            // Supprimez la tâche sélectionnée
            Task task = LV_Task.SelectedItem as Task;
            if (task != null)
            {
                task_DB.DeleteTask(task);
                Tasks = task_DB.GetTasks();
                LV_Task.ItemsSource = Tasks;
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner une tâche");
            }

        }



        
    }
}
