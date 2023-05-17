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
    public class CiudadController : ControllerBase
    {
        [HttpGet]
        [Route("ListarCiudad")]
        public async Task<ActionResult<List<Ciudad>>> GetCiudad() {
            try
            {
                var data = new DCiudad();
                var lista = await data.Listar();
                return StatusCode(StatusCodes.Status200OK,
                        new { message="Se carga data de la ciudad",
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
        [Route("ListarCiudad/{IdCiu:int}")]
        public async Task<ActionResult<List<Ciudad>>> GetCiudadId(int IdCiu)
        {
            try
            {
                var data = new DCiudad();
                var lista = await data.Listar();
                var ListId=from datos in lista
                           where datos.CiuId == IdCiu
                           select datos;
                if (!ListId.Any())
                {
                    return BadRequest("No se encuentra el id de la ciudad");
                }

                return StatusCode(StatusCodes.Status200OK,
                        new
                        {
                            message = "Se carga data de la ciudad Filtrada",
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
        [Route("AddCiudad")]
        public async Task<ActionResult> AddCiudad([FromBody] AddCiudad Obj) {
            var function = new DCiudad();
            try
            {
                if (Obj.CiuCodigo == string.Empty) return BadRequest("El campo codigo no puede ir vacio");
                if (Obj.CiuNombre == string.Empty) return BadRequest("El campo nombre no puede ir vacio");

                Ciudad Ociu= new Ciudad();
                Ociu.CiuCodigo = Obj.CiuCodigo;
                Ociu.CiuNombre = Obj.CiuNombre;
                await function.Insert(Ociu);
                return StatusCode(StatusCodes.Status200OK, new { message = "Datos almacenados correctamente" });
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status200OK, new { message = e.Message });
            }
        }

        [HttpPut]
        [Route("EditCiudad/{IdCiu:int}")]
        public async Task<ActionResult> EditCiudad(int IdCiu, [FromBody] AddCiudad Obj)
        {
            var function = new DCiudad();
            try
            {
                
                if (Obj.CiuCodigo == string.Empty) return BadRequest("El campo codigo no puede ir vacio");
                if (Obj.CiuNombre == string.Empty) return BadRequest("El campo nombre no puede ir vacio");

                Ciudad Ociu = new Ciudad();
                Ociu.CiuCodigo = Obj.CiuCodigo;
                Ociu.CiuNombre = Obj.CiuNombre;
                await function.Update(Ociu, IdCiu);
                return StatusCode(StatusCodes.Status200OK, new { message = "Datos se actualizaron correctamente" });
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status200OK, new { message = e.Message });
            }
        }

        [HttpDelete]
        [Route("DeleteCiudad/{IdCiu:int}")]
        public async Task<ActionResult> DeleteCiudad(int IdCiu)
        {
            var function = new DCiudad();
            try
            {            
                await function.Delete(IdCiu);
                return StatusCode(StatusCodes.Status200OK, new { message = "Se elimino correctamente el id["+IdCiu+"]" });
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status200OK, new { message = e.Message });
            }
        }

    }//fin class
}
