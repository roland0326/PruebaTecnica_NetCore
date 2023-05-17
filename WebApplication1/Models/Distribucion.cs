using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Distribucion
{
    public int DisId { get; set; }

    public int SucId { get; set; }

    public string DisSigla { get; set; } = null!;

    public int DisSerie { get; set; }

    public bool DisHabilitado { get; set; }

    public virtual ICollection<MovPaqueadero> MovPaqueaderos { get; set; } = new List<MovPaqueadero>();

    public virtual Sucursal Suc { get; set; } = null!;
}
