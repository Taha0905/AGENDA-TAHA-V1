using agenda_khelifi.agenda_DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace agenda_khelifi.service.DAO
{
    public class DAO_Contact
    {
        public IEnumerable<Contacte> GetContactes()
        {
            using (var context = new AgendaTahaContext())
            {
                return context.Contactes.ToList();
            }
        }

        public void AddContacte(Contacte contacte)
        {
            using (var context = new AgendaTahaContext())
            {
                context.Contactes.Add(contacte);
                context.SaveChanges();
            }
        }

        public void DeleteContacte(Contacte contacte)
        {
            using (var context = new AgendaTahaContext())
            {
                //var contacte = context.Contactes.Find(id);
                context.Contactes.Remove(contacte);
                context.SaveChanges();
            }
        }

        public void UpdateContacte(Contacte contacte)
        {
            using (var context = new AgendaTahaContext())
            {
                context.Contactes.Update(contacte);
                context.SaveChanges();
            }
        }

        //chercher par nom
        public IEnumerable<Contacte> GetContactes(string nom)
        {
            using (var context = new AgendaTahaContext())
            {
                return context.Contactes.Where(c => c.Nom.Contains(nom)).ToList();
            }
        }

        //voir si la base de donnee existe
        public bool DBExists()
        {
            using (var context = new AgendaTahaContext())
            {
                return context.Database.CanConnect();
            }
        }
    }
}
