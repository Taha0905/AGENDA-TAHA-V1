using agenda_khelifi.agenda_DB;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace agenda_khelifi.service.DAO

{
    public class DAO_Contact
    {
        //chercher tous les contactes
        public IEnumerable<Contacte> GetContactes()
        {
            try
            {
                using (var context = new AgendaTahaContext())
                {
                    return context.Contactes.ToList();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
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

        //chercher par Amis
        public IEnumerable<Contacte> GetContactesAmis()
        {
            using (var context = new AgendaTahaContext())
            {
                return context.Contactes.Where(c => c.Status == "Amis").ToList();
            }
        }

        //chercher par Famille
        public IEnumerable<Contacte> GetContactesFamille()
        {
            using (var context = new AgendaTahaContext())
            {
                return context.Contactes.Where(c => c.Status == "Famille").ToList();
            }
        }
        //chercher par Collègue
        public IEnumerable<Contacte> GetContactesCollegue()
        {
            using (var context = new AgendaTahaContext())
            {
                return context.Contactes.Where(c => c.Status == "Collègue").ToList();
            }
        }


    }
}
