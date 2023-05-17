using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class TipoIdentificacion
{
    public int TipideId { get; set; }

    public string TipideCodigo { get; set; } = null!;

    public string TipideDescrip { get; set; } = null!;

    public virtual ICollection<Sucursal> Sucursals { get; set; } = new List<Sucursal>();
}
