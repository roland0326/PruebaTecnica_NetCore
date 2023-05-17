using System.ComponentModel.DataAnnotations;

namespace Api_parqueadero.Repository
{
    public class AddMarca
    {
       
        public string MarCodigo { get; set; } = null!;

        public string? MarDescrip { get; set; }
    }
}
