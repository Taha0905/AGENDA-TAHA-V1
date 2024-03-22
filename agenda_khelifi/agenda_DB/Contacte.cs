using System;
using System.Collections.Generic;

namespace agenda_khelifi.agenda_DB;

public partial class Contacte
{
    public int Id { get; set; }

    public string Nom { get; set; } = null!;

    public string Prenom { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? Phone { get; set; }

    public string? Adresse { get; set; }

    public string? CodePostal { get; set; }

    public string? Ville { get; set; }

    public string? Status { get; set; }

    public virtual ICollection<ProfilReseau> ProfilReseaus { get; set; } = new List<ProfilReseau>();
}
