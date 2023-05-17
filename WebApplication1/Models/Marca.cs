using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Marca
{
    public int MarId { get; set; }

    public string MarCodigo { get; set; } = null!;

    public string? MarDescrip { get; set; }
}
