using System.ComponentModel.DataAnnotations;

namespace Api_parqueadero.Repository
{
    public class AddTipoVehiculo
    {        

        public string TipvehCodigo { get; set; } = null!;

        public string TipvehDescrip { get; set; } = null!;

        public decimal TipvehTarifa { get; set; }
    }
}
