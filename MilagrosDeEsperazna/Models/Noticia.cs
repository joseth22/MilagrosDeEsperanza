using System;
using System.Collections.Generic;

namespace MilagrosDeEsperanza.Models;

public partial class Noticia
{
    public int IdNoticia { get; set; }

    public string? Titulo { get; set; }

    public string? Contenido { get; set; }

    public string? Imagen { get; set; }

    public DateOnly? FechaPublicacion { get; set; }
}
