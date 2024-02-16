using System;
using System.Collections.Generic;

namespace agenda_khelifi.agenda_DB;

public partial class Todolist
{
    public uint Idlist { get; set; }

    public string? ListName { get; set; }

    public DateOnly? DateCreation { get; set; }

    public DateOnly? DateFin { get; set; }

    public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();
}
