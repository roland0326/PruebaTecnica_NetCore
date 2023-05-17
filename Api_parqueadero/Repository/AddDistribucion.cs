using Api_parqueadero.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Api_parqueadero.Repository
{
    public class AddDistribucion
    {

        public int SucId { get; set; }

        public string DisSigla { get; set; } = null!;

        public int DisSerie { get; set; }

        public bool DisHabilitado { get; set; }
     
    }
}
