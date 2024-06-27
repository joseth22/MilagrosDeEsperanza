using System;
using System.Collections.Generic;

namespace MilagrosDeEsperanza.Models;

public partial class VoluntariosProyecto
{
    public int IdAsociacion { get; set; }

    public string? Email { get; set; }

    public int? IdProyecto { get; set; }

    public virtual Voluntario? EmailNavigation { get; set; }

    public virtual Proyecto? IdProyectoNavigation { get; set; }
}
