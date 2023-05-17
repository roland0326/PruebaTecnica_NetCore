using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Vehiculo
{
    public int VehId { get; set; }

    public int TipvehId { get; set; }

    public int MarId { get; set; }

    public string VehPlaca { get; set; } = null!;

    public DateTime VehFecRegistro { get; set; }

    public virtual ICollection<MovPaqueadero> MovPaqueaderos { get; set; } = new List<MovPaqueadero>();

    public virtual TipoVehiculo Tipveh { get; set; } = null!;
}
