using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Ciudad
{
    public int CiuId { get; set; }

    public string CiuCodigo { get; set; } = null!;

    public string CiuNombre { get; set; } = null!;

    public virtual ICollection<Sucursal> Sucursals { get; set; } = new List<Sucursal>();
}
