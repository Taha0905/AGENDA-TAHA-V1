using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using agenda_khelifi.agenda_DB;

namespace agenda_khelifi.service.DAO
{
    public class DAO_Task
    {
        //chercher tous les taches
        public IEnumerable<Task> GetTasks()
        {
            using (var context = new AgendaTahaContext())
            {
                return context.Tasks.ToList();
            }
        }
    }
}
