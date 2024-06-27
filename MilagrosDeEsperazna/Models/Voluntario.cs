using System;
using System.Collections.Generic;

namespace MilagrosDeEsperanza.Models;

public partial class Voluntario
{
    public int IdVoluntario { get; set; }

    public string? Nombre { get; set; }

    public string PrimerApellido { get; set; } = null!;

    public string SegundoApellido { get; set; } = null!;

    public int Telefono { get; set; }

    public string Email { get; set; } = null!;

    public virtual ICollection<VoluntariosProyecto> VoluntariosProyectos { get; set; } = new List<VoluntariosProyecto>();
}
