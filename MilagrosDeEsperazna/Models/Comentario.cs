using System;
using System.Collections.Generic;

namespace MilagrosDeEsperanza.Models;

public partial class Comentario
{
    public int IdComentario { get; set; }

    public string Nombre { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Mensaje { get; set; } = null!;

    public DateTime? FechaEnvio { get; set; }
}
