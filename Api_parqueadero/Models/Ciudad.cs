using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;
using System.Text.Json.Serialization;


namespace Api_parqueadero.Models;

public partial class Ciudad
{
    [Key]    
    public int CiuId { get; set; }

    public string CiuCodigo { get; set; } = null!;

    public string CiuNombre { get; set; } = null!;
    [JsonIgnore]
    public virtual ICollection<Sucursal> Sucursals { get; set; } = new List<Sucursal>();


  
}


