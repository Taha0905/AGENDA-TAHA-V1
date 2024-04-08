using System;
using System.Collections.Generic;

namespace agenda_khelifi.agenda_DB;

public partial class ProfilReseau
{
    public int IdProfilReseau { get; set; }

    public int ContactesId { get; set; }

    public string NomReseaux { get; set; } = null!;

    public string NomDansReseaux { get; set; } = null!;

    public string? Url { get; set; }

    public virtual Contacte Contactes { get; set; } = null!;
}
