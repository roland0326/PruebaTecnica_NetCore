using Api_parqueadero.Models;

namespace Api_parqueadero.Repository
{
    public class AddVehiculo
    {
        public int TipvehId { get; set; }

        public int MarId { get; set; }

        public string VehPlaca { get; set; } = null!;
      
    }
}
