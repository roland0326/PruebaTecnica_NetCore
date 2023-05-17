using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class TipoVehiculo
{
    public int TipvehId { get; set; }

    public string TipvehCodigo { get; set; } = null!;

    public string TipvehDescrip { get; set; } = null!;

    public decimal TipvehTarifa { get; set; }

    public virtual ICollection<Vehiculo> Vehiculos { get; set; } = new List<Vehiculo>();
}
