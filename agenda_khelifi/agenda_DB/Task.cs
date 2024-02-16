using System;
using System.Collections.Generic;

namespace agenda_khelifi.agenda_DB;

public partial class Task
{
    public int IdTask { get; set; }

    public string? TaskName { get; set; }

    public string? TaskDescription { get; set; }

    public uint ToDoListIdlist { get; set; }

    public virtual Todolist ToDoListIdlistNavigation { get; set; } = null!;
}
