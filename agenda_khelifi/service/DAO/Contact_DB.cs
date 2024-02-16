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
    }
}
