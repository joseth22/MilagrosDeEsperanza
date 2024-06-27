using System;
using System.Collections.Generic;

namespace MilagrosDeEsperanza.Models;

public partial class Proyecto
{
    public int IdProyecto { get; set; }

    public string? Titulo { get; set; }

    public string? Imagen { get; set; }

    public virtual ICollection<VoluntariosProyecto> VoluntariosProyectos { get; set; } = new List<VoluntariosProyecto>();
}
