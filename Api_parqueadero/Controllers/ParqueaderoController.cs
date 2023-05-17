using Microsoft.AspNetCore.Mvc;
using Api_parqueadero.Models;
using Microsoft.AspNetCore.Cors;
using Api_parqueadero.Datos;
using Api_parqueadero.Repository;
namespace Api_parqueadero.Controllers
{
    [EnableCors("ReglasCors")]
    [Route("api/[controller]")]
    [ApiController]
    public class ParqueaderoController : ControllerBase
    {
      

        [HttpPost]
        [Route("EntradaSalidaVehiculo")]
        public async Task<ActionResult<List<ReporteParqueadero>>> In_Out([FromBody] ProcesoVehiculo Obj) {
            var function = new DParqueadero();
            try
            {
                if (Obj.Placa == string.Empty) return BadRequest("El campo placa no puede ir vacio");
                

                ProcesoVehiculo Opro= new ProcesoVehiculo();
                Opro.Placa = Obj.Placa;
                Opro.Tipo_veh= Obj.Tipo_veh;
                Opro.Mar_id= Obj.Mar_id;
                Opro.IdSucursal= Obj.IdSucursal;
                Opro.Factura= Obj.Factura;
               var lista= await function.ProcesoPq(Opro);

                return StatusCode(StatusCodes.Status200OK, new { message = "Datos almacenados correctamente",lista });
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status200OK, new { message = e.Message });
            }
        }

        [HttpPost]
        [Route("ReporteRangoFechas")]
        public async Task<ActionResult<List<ReporteParqueadero>>> ReporteRango([FromBody] ReporteRangoFechas Obj)
        {
            var function = new DParqueadero();
            try
            {
               


                ReporteRangoFechas Rang = new ReporteRangoFechas();
                Rang.Fecini = Obj.Fecini;
                Rang.Fecfin = Obj.Fecfin;
                var lista = await function.ReporteFechas(Rang);

                return StatusCode(StatusCodes.Status200OK, new { message = "Datos almacenados correctamente", lista });
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status200OK, new { message = e.Message });
            }
        }


    }//fin class
}
