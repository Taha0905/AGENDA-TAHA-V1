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
            try {
            using (var context = new AgendaTahaContext())
            {
                return context.Tasks.ToList();
            }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
        //ajouter une tache
        public void AddTask(Task task)
        {
            using (var context = new AgendaTahaContext())
            {
                context.Tasks.Add(task);
                context.SaveChanges();
            }
        }
        //supprimer une tache
        public void DeleteTask(Task task)
        {
            using (var context = new AgendaTahaContext())
            {
                context.Tasks.Remove(task);
                context.SaveChanges();
            }
        }
        //modifier une tache
        public void UpdateTask(Task task)
        {
            using (var context = new AgendaTahaContext())
            {
                context.Tasks.Update(task);
                context.SaveChanges();
            }
        }
    }
}
