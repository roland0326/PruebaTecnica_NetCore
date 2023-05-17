using Api_parqueadero.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Api_parqueadero.Repository
{
    public class AddSucursal
    {
        public int TipideId { get; set; }

        public string SucDocumento { get; set; } = null!;

        public int CiuId { get; set; }

        public string? SucDir { get; set; }

        public string SucRazon { get; set; } = null!;

        public bool SucManejaDcto { get; set; }

        public decimal SucDcto { get; set; }

    }//fin clase
}
