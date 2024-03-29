﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Api_parqueadero.Models;

public partial class MovPaqueadero
{
    [Key]
    public int ParqueId { get; set; }

    public int VehId { get; set; }

    public int DisId { get; set; }

    public DateTime ParqueHoraIn { get; set; }

    public DateTime? ParqueHoraOut { get; set; }

    public decimal? ParqueTiempoMin { get; set; }

    public decimal? ParqueCosto { get; set; }

    public string? ParFacDcto { get; set; }

    public virtual Distribucion Dis { get; set; } = null!;

    public virtual Vehiculo Veh { get; set; } = null!;
}
