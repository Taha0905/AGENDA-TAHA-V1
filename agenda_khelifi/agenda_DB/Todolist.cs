using System;
using System.Collections.Generic;

namespace agenda_khelifi.agenda_DB;

public partial class Todolist
{
    public uint Id { get; set; }

    public string ListName { get; set; } = null!;

    public string Status { get; set; } = null!;

    public int TaskIdTask { get; set; }

    public virtual Task TaskIdTaskNavigation { get; set; } = null!;
}
