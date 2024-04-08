using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using agenda_khelifi.agenda_DB;

namespace agenda_khelifi.service.DAO
{
    public class DAO_Reseaux
    {
        //recuperer les reseaux d'un contacte
        public List<ProfilReseau> GetReseaux(int idContacte)
        {
            using (var db = new AgendaTahaContext())
            {
                return db.ProfilReseaus.Where(r => r.ContactesId == idContacte).ToList();
            }
        }
        //ajouter un reseau
        public void AddReseau(ProfilReseau reseau)
        {
            using (var db = new AgendaTahaContext())
            {
                db.ProfilReseaus.Add(reseau);
                db.SaveChanges();
            }
        }
        //supprimer un reseau
        public void DeleteReseau(int idReseau)
        {
            using (var db = new AgendaTahaContext())
            {
                ProfilReseau reseau = db.ProfilReseaus.Find(idReseau);
                db.ProfilReseaus.Remove(reseau);
                db.SaveChanges();
            }
        }
        //modifier un reseau
        public void UpdateReseau(ProfilReseau reseau)
        {
            using (var db = new AgendaTahaContext())
            {
                db.ProfilReseaus.Update(reseau);
                db.SaveChanges();
            }
        }
    }
}
