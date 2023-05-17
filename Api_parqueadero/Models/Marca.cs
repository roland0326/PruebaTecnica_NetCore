using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Api_parqueadero.Models;

public partial class Marca
{
    [Key]
    public int MarId { get; set; }

    public string MarCodigo { get; set; } = null!;

    public string? MarDescrip { get; set; }
}
