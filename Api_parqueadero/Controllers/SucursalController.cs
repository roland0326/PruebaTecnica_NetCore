using Api_parqueadero.Datos;
using Api_parqueadero.Models;
using Api_parqueadero.Repository;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NPOI.OpenXmlFormats.Wordprocessing;
using WebApplication1.Models;

namespace Api_parqueadero.Controllers
{
    [EnableCors("ReglasCors")]
    [Route("api/[controller]")]
    [ApiController]
    public class SucursalController : Controller
    {
        private readonly ParqueaderoContext _Dbcontext;
        public SucursalController(ParqueaderoContext context)
        {
            _Dbcontext = context;
        }

        [HttpGet]
        [Route("ListarSucursal")]
        public async Task<ActionResult<List<Sucursal>>> GetSucursal()
        {
            List<Sucursal> lista= new List<Sucursal>();

            try
            {
                //var data = new DSucursal();
                //List<Sucursal> lista = await data.Listar();
                 lista= _Dbcontext.Sucursals.Include(c => c.Ciu).Include(tip => tip.Tipide).ToList();
                
                
                
                return StatusCode(StatusCodes.Status200OK,
                        new
                        {
                            message = "Se carga data de la sucursal",
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
        [Route("ListarSucursal/{IdSuc:int}")]
        public async Task<ActionResult<List<Sucursal>>> GetSucursalId(int IdSuc)
        {
            List<Sucursal> lista = new List<Sucursal>();
            Sucursal ObjSuc = _Dbcontext.Sucursals.Find(IdSuc);
            if (ObjSuc == null)
            {
                return BadRequest("No se encontro el id de la sucursal");
            }
            try
            {
                //var data = new DSucursal();
                //List<Sucursal> lista = await data.Listar();
                lista = _Dbcontext.Sucursals.Include(c => c.Ciu).Include(tip => tip.Tipide).Where(s=> s.SucId==IdSuc).ToList();
                return StatusCode(StatusCodes.Status200OK,
                        new
                        {
                            message = "Se carga data de la sucursal",
                            Response = lista
                        }
                    );
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status200OK, new { message = e.Message });
            }
        }

        [HttpPost]
        [Route("AddSucursal")]
        public async Task<ActionResult> AddSucursal([FromBody] AddSucursal Obj)
        {
            var function = new DSucursal();
            try
            {
                if (Obj.SucDocumento == string.Empty) return BadRequest("El campo documento no puede estar vacio");
                if (Obj.SucRazon == string.Empty) return BadRequest("El campo razon social no puede ir vacio");
                if (Obj.SucManejaDcto) {
                    if (Obj.SucDcto == 0) return BadRequest("Si maneja descuento no puede ir el valor en cero en dcto.");
                }

                Sucursal OSuc = new Sucursal();
                OSuc.TipideId = Obj.TipideId;
                OSuc.SucDocumento = Obj.SucDocumento;
                OSuc.CiuId= Obj.CiuId;
                OSuc.SucDir= Obj.SucDir;
                OSuc.SucRazon= Obj.SucRazon;
                OSuc.SucManejaDcto= Obj.SucManejaDcto;
                OSuc.SucDcto= Obj.SucDcto;
                await function.Insert(OSuc);
                return StatusCode(StatusCodes.Status200OK, new { message = "Datos almacenados correctamente" });
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status200OK, new { message = e.Message });
            }
        }

        [HttpPut]
        [Route("EditSucursal/{IdSuc:int}")]
        public async Task<ActionResult> EditSucursal(int IdSuc, [FromBody] AddSucursal Obj)
        {
            var function = new DSucursal();
            try
            {

                if (Obj.SucDocumento == string.Empty) return BadRequest("El campo documento no puede estar vacio");
                if (Obj.SucRazon == string.Empty) return BadRequest("El campo razon social no puede ir vacio");
                if (Obj.SucManejaDcto)
                {
                    if (Obj.SucDcto == 0) return BadRequest("Si maneja descuento no puede ir el valor en cero en dcto.");
                }

                Sucursal OSuc = new Sucursal();
                OSuc.TipideId = Obj.TipideId;
                OSuc.SucDocumento = Obj.SucDocumento;
                OSuc.CiuId = Obj.CiuId;
                OSuc.SucDir = Obj.SucDir;
                OSuc.SucRazon = Obj.SucRazon;
                OSuc.SucManejaDcto = Obj.SucManejaDcto;
                OSuc.SucDcto = Obj.SucDcto;
                await function.Update(OSuc, IdSuc);
                return StatusCode(StatusCodes.Status200OK, new { message = "Datos se actualizaron correctamente" });
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status200OK, new { message = e.Message });
            }
        }

        [HttpDelete]
        [Route("DeleteSucursal/{IdSuc:int}")]
        public async Task<ActionResult> DeleteSucursal(int IdSuc)
        {
            var function = new DSucursal();
            try
            {
                await function.Delete(IdSuc);
                return StatusCode(StatusCodes.Status200OK, new { message = "Se elimino correctamente el id[" + IdSuc + "]" });
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status200OK, new { message = e.Message });
            }
        }
    }//fin clase
}
