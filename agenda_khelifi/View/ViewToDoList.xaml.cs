using System.Collections.Generic;
using System.Windows.Controls;
using agenda_khelifi.agenda_DB;
using agenda_khelifi.service.DAO;

namespace agenda_khelifi.View
{
    public partial class ViewToDoList : UserControl
    {
        DAO_Task task_DB;

        public ViewToDoList()
        {
            InitializeComponent();
            task_DB = new DAO_Task();

            LoadTasks();
        }

        private void LoadTasks()
        {
            // Utilisez la méthode GetTasks() de votre DAO_Task pour obtenir les tâches depuis la base de données
            IEnumerable<Task> tasks = task_DB.GetTasks();

            // Assurez-vous que la propriété ItemsSource de votre ListView est correctement définie
            LV_Tasks.ItemsSource = tasks;
        }
    }
}
