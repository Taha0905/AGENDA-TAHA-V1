using System;
using System.Collections.Generic;

namespace agenda_khelifi.agenda_DB;

public partial class Réseauxsociaux
{
    public int IdRéseauxSociaux { get; set; }

    public string? Nom { get; set; }

    public string? Url { get; set; }

    public virtual ICollection<ProfilReseau> ProfilReseaus { get; set; } = new List<ProfilReseau>();
}
