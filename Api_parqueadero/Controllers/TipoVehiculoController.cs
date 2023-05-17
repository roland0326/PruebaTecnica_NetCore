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
    public class TipoVehiculoController : ControllerBase
    {
        [HttpGet]
        [Route("ListarTipVehiculo")]
        public async Task<ActionResult<List<TipoVehiculo>>> GetTipVehiculo() {
            try
            {
                var data = new DTipoVehiculo();
                var lista = await data.Listar();
                return StatusCode(StatusCodes.Status200OK,
                        new { message="Se carga data de tipo de vehiculo",
                                Response= lista
                        } 
                    );
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status200OK,new{message = e.Message});
            }        
        }

        [HttpGet]
        [Route("ListarTipVehiculo/{IdTipVeh:int}")]
        public async Task<ActionResult<List<TipoVehiculo>>> GetTipVehId(int IdTipVeh)
        {
            try
            {
                var data = new DTipoVehiculo();
                var lista = await data.Listar();
                var ListId=from datos in lista
                           where datos.TipvehId == IdTipVeh
                           select datos;
                if (!ListId.Any())
                {
                    return BadRequest("No se encuentra el id del tipo de vehiculo");
                }

                return StatusCode(StatusCodes.Status200OK,
                        new
                        {
                            message = "Se carga data de tipo vehiculo Filtrada",
                            Response = ListId
                        }
                    );
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status200OK,
                       new
                       {
                           message = e.Message

                       }
                   );
            }


        }

        [HttpPost]
        [Route("AddTipoVehiculo")]
        public async Task<ActionResult> AddTipVehiculo([FromBody] AddTipoVehiculo Obj) {
            var function = new DTipoVehiculo();
            try
            {
                if (Obj.TipvehCodigo == string.Empty) return BadRequest("El campo codigo no puede ir vacio");
                if (Obj.TipvehDescrip == string.Empty) return BadRequest("El campo descripcion no puede ir vacio");
                if (Obj.TipvehTarifa == 0) return BadRequest("No se ha asignado el valor de la tarifa");


                TipoVehiculo OTipVeh= new TipoVehiculo();
                OTipVeh.TipvehCodigo = Obj.TipvehCodigo;
                OTipVeh.TipvehDescrip = Obj.TipvehDescrip;
                OTipVeh.TipvehTarifa = Obj.TipvehTarifa;
                await function.Insert(OTipVeh);
                return StatusCode(StatusCodes.Status200OK, new { message = "Datos almacenados correctamente" });
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status200OK, new { message = e.Message });
            }
        }

        [HttpPut]
        [Route("EditTipoVehiculo/{IdTipVeh:int}")]
        public async Task<ActionResult> EditTipVehiculo(int IdTipVeh, [FromBody] AddTipoVehiculo Obj)
        {
            var function = new DTipoVehiculo();
            try
            {
                if (Obj.TipvehCodigo == string.Empty) return BadRequest("El campo codigo no puede ir vacio");
                if (Obj.TipvehDescrip == string.Empty) return BadRequest("El campo descripcion no puede ir vacio");
                if (Obj.TipvehTarifa == 0) return BadRequest("No se ha asignado el valor de la tarifa");


                TipoVehiculo OTipVeh = new TipoVehiculo();
                OTipVeh.TipvehCodigo = Obj.TipvehCodigo;
                OTipVeh.TipvehDescrip = Obj.TipvehDescrip;
                OTipVeh.TipvehTarifa = Obj.TipvehTarifa;
                await function.Update(OTipVeh, IdTipVeh);
                return StatusCode(StatusCodes.Status200OK, new { message = "Datos se actualizaron correctamente" });
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status200OK, new { message = e.Message });
            }
        }

        [HttpDelete]
        [Route("DeleteTipVehiculo/{IdTipVeh:int}")]
        public async Task<ActionResult> DeleteTipVehiculo(int IdTipVeh)
        {
            var function = new DTipoVehiculo();
            try
            {            
                await function.Delete(IdTipVeh);
                return StatusCode(StatusCodes.Status200OK, new { message = "Se elimino correctamente el id["+ IdTipVeh + "]" });
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status200OK, new { message = e.Message });
            }
        }

    }//fin class
}
