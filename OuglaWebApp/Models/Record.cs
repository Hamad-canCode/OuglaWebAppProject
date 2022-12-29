using System;
using System.Collections.Generic;

namespace OuglaWebApp.Models;

public partial class Record
{
    public string? Sitename { get; set; }

    public string Filepath { get; set; } = null!;

    public virtual Info? SitenameNavigation { get; set; }
}
