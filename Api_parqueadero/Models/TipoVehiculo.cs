using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Api_parqueadero.Models;

public partial class TipoVehiculo
{
    [Key]
    public int TipvehId { get; set; }

    public string TipvehCodigo { get; set; } = null!;

    public string TipvehDescrip { get; set; } = null!;

    public decimal TipvehTarifa { get; set; }

    public virtual ICollection<Vehiculo> Vehiculos { get; set; } = new List<Vehiculo>();
}
