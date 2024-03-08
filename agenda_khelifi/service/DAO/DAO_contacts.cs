using agenda_khelifi.agenda_DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace agenda_khelifi.service.DAO
{
    public class Contact_DB
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

        public void DeleteContacte(int id)
        {
            using (var context = new AgendaTahaContext())
            {
                var contacte = context.Contactes.Find(id);
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



    }
}
