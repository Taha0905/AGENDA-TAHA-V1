using System;
using System.Collections.Generic;

namespace agenda_khelifi.agenda_DB;

public partial class Task
{
    public int IdTask { get; set; }

    public string TaskName { get; set; } = null!;

    public string TaskDescription { get; set; } = null!;

    public DateOnly? DateDebut { get; set; }

    public DateOnly? DateFin { get; set; }

    public virtual ICollection<Todolist> Todolists { get; set; } = new List<Todolist>();
}
