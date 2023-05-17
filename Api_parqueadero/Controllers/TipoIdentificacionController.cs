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
    public class TipoIdentificacionController : Controller
    {
        [HttpGet]
        [Route("ListarTipoIdentifica")]
        public async Task<ActionResult<List<TipoIdentificacion>>> GetTipIde()
        {
            try
            {
                var data = new DTipoIdentificacion();
                var lista = await data.Listar();
                return StatusCode(StatusCodes.Status200OK,
                        new
                        {
                            message = "Se carga data de tipo identificación",
                            Response = lista
                        }
                    );
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status200OK, new { message = e.Message });
            }
        }

        [HttpGet]
        [Route("ListarTipoIdentifica/{IdTipIde:int}")]
        public async Task<ActionResult<List<TipoIdentificacion>>> GetTipIdeId(int IdTipIde)
        {
            try
            {
                var data = new DTipoIdentificacion();
                var lista = await data.Listar();
                var ListId = from datos in lista
                             where datos.TipideId == IdTipIde
                             select datos;
                if (!ListId.Any())
                {
                    return BadRequest("No se encuentra el id del tipo de identificación");
                }

                return StatusCode(StatusCodes.Status200OK,
                        new
                        {
                            message = "Se carga data del tipo identificación  Filtrada",
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
    }
}
