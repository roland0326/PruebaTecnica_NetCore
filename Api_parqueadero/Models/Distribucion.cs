using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Api_parqueadero.Models;

public partial class Distribucion
{
    [Key]
    public int DisId { get; set; }

    public int SucId { get; set; }

    public string DisSigla { get; set; } = null!;

    public int DisSerie { get; set; }

    public bool DisHabilitado { get; set; }
    [JsonIgnore]
    public virtual ICollection<MovPaqueadero> MovPaqueaderos { get; set; } = new List<MovPaqueadero>();
    
    public virtual Sucursal Suc { get; set; } = null!;

 
}
