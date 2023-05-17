using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Sucursal
{
    public int SucId { get; set; }

    public int TipideId { get; set; }

    public string SucDocumento { get; set; } = null!;

    public int CiuId { get; set; }

    public string? SucDir { get; set; }

    public string SucRazon { get; set; } = null!;

    public bool SucManejaDcto { get; set; }

    public decimal SucDcto { get; set; }

    public virtual Ciudad Ciu { get; set; } = null!;

    public virtual ICollection<Distribucion> Distribucions { get; set; } = new List<Distribucion>();

    public virtual TipoIdentificacion Tipide { get; set; } = null!;
}
