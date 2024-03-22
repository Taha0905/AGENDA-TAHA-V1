using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using agenda_khelifi.agenda_DB;

namespace agenda_khelifi.service.DAO
{
    public class DOA_ToDoList
    {
        //chercher tous les listes
        public IEnumerable<Todolist> GetToDoList()
        {
            using (var context = new AgendaTahaContext())
            {
                return context.Todolists.ToList();
            }
        }
        //ajouter une liste
        public void AddToDoList(Todolist todolist)
        {
            using (var context = new AgendaTahaContext())
            {
                context.Todolists.Add(todolist);
                context.SaveChanges();
            }
        }
        //supprimer une liste
        public void DeleteToDoList(Todolist todolist)
        {
            using (var context = new AgendaTahaContext())
            {
                context.Todolists.Remove(todolist);
                context.SaveChanges();
            }
        }
        //modifier une liste
        public void UpdateToDoList(Todolist todolist)
        {
            using (var context = new AgendaTahaContext())
            {
                context.Todolists.Update(todolist);
                context.SaveChanges();
            }
        }
    }
}
