using System;
using System.Collections.Generic;

namespace MilagrosDeEsperanza.Models;

public partial class Usuario
{
    public string Nombre { get; set; } = null!;

    public string PrimerApellido { get; set; } = null!;

    public string SegundoApellido { get; set; } = null!;

    public int Telefono { get; set; }

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Rol { get; set; } = null!;
}
