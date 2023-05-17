using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices.ObjectiveC;
using System.Text.Json.Serialization;

namespace Api_parqueadero.Models;

public partial class Sucursal
{
    [Key]
    public int SucId { get; set; }

    public int TipideId { get; set; }

    public string SucDocumento { get; set; } = null!;

    public int CiuId { get; set; }

    public string? SucDir { get; set; }

    public string SucRazon { get; set; } = null!;

    public bool SucManejaDcto { get; set; }

    public decimal SucDcto { get; set; }
    
    public virtual Ciudad Ciu { get; set; } = null!;
    [JsonIgnore]
    public virtual ICollection<Distribucion> Distribucions { get; set; } = new List<Distribucion>();
    
    public virtual TipoIdentificacion Tipide { get; set; } = null!;


}
