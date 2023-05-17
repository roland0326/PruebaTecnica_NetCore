using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Api_parqueadero.Models;

public partial class TipoIdentificacion
{
    [Key]
    public int TipideId { get; set; }

    public string TipideCodigo { get; set; } = null!;

    public string TipideDescrip { get; set; } = null!;
    [JsonIgnore]
    public virtual ICollection<Sucursal> Sucursals { get; set; } = new List<Sucursal>();
}
