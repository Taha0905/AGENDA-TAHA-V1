using System;
using System.Collections.Generic;

namespace agenda_khelifi.agenda_DB;

public partial class ProfilReseau
{
    public int IdProfilReseau { get; set; }

    public int ContactesId { get; set; }

    public string? Pseudo { get; set; }

    public int RéseauxSociauxIdRéseauxSociaux { get; set; }

    public virtual Contacte Contactes { get; set; } = null!;

    public virtual Reseauxsociaux RéseauxSociauxIdRéseauxSociauxNavigation { get; set; } = null!;
}
