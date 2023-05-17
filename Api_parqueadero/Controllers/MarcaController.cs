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
    public class MarcaController : ControllerBase
    {
        [HttpGet]
        [Route("ListarMarca")]
        public async Task<ActionResult<List<Marca>>> GetMarca() {
            try
            {
                var data = new DMarca();
                var lista = await data.Listar();
                return StatusCode(StatusCodes.Status200OK,
                        new { message="Se carga data de la marca",
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
        [Route("ListarMarca/{IdMar:int}")]
        public async Task<ActionResult<List<Marca>>> GetMarcaId(int IdMar)
        {
            try
            {
                var data = new DMarca();
                var lista = await data.Listar();
                var ListId=from datos in lista
                           where datos.MarId == IdMar
                           select datos;
                if (!ListId.Any())
                {
                    return BadRequest("No se encuentra el id de la marca");
                }

                return StatusCode(StatusCodes.Status200OK,
                        new
                        {
                            message = "Se carga data de la marca Filtrada",
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
        [Route("AddMarca")]
        public async Task<ActionResult> AddMarca([FromBody] AddMarca Obj) {
            var function = new DMarca();
            try
            {
                if (Obj.MarCodigo == string.Empty) return BadRequest("El campo codigo no puede ir vacio");


                Marca OMar= new Marca();
                OMar.MarCodigo = Obj.MarCodigo;
                OMar.MarDescrip = Obj.MarDescrip;
                await function.Insert(OMar);
                return StatusCode(StatusCodes.Status200OK, new { message = "Datos almacenados correctamente" });
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status200OK, new { message = e.Message });
            }
        }

        [HttpPut]
        [Route("EditMarca/{IdMar:int}")]
        public async Task<ActionResult> EditMarca(int IdMar, [FromBody] AddMarca Obj)
        {
            var function = new DMarca();
            try
            {
                if (Obj.MarCodigo == string.Empty) return BadRequest("El campo codigo no puede ir vacio");

                Marca OMar = new Marca();
                OMar.MarCodigo = Obj.MarCodigo;
                OMar.MarDescrip = Obj.MarDescrip;
                await function.Update(OMar, IdMar);
                return StatusCode(StatusCodes.Status200OK, new { message = "Datos se actualizaron correctamente" });
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status200OK, new { message = e.Message });
            }
        }

        [HttpDelete]
        [Route("DeleteMarca/{IdMar:int}")]
        public async Task<ActionResult> DeleteMarca(int IdMar)
        {
            var function = new DMarca();
            try
            {            
                await function.Delete(IdMar);
                return StatusCode(StatusCodes.Status200OK, new { message = "Se elimino correctamente el id["+ IdMar + "]" });
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status200OK, new { message = e.Message });
            }
        }

    }//fin class
}
