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
    public class DistribucionController : Controller
    {
        private readonly ParqueaderoContext _Dbcontext;
        public DistribucionController(ParqueaderoContext context)
        {
            _Dbcontext = context;
        }

        [HttpGet]
        [Route("ListarDistribucionParqueadero")]
        public async Task<ActionResult<List<Distribucion>>> GetDistribucion()
        {
            List<Distribucion> lista= new List<Distribucion>();

            try
            {
                 lista= _Dbcontext.Distribucions.Include(s=> s.Suc).ToList();   
                return StatusCode(StatusCodes.Status200OK,
                        new
                        {
                            message = "Se carga data de distribucion por sucursal",
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
        [Route("ListarDistribucionPorSucursal/{IdSuc:int}")]
        public async Task<ActionResult<List<Distribucion>>> GetDistSucursalId(int IdSuc)
        {
            List<Distribucion> lista = new List<Distribucion>();
            Distribucion ObjDis = _Dbcontext.Distribucions.Find(IdSuc);
            if (ObjDis == null)
            {
                return BadRequest("No se encontro el id de la sucursal");
            }
            try
            {
                lista = _Dbcontext.Distribucions.Include(s=> s.Suc).Where(d=> d.SucId==IdSuc).ToList();
                return StatusCode(StatusCodes.Status200OK,
                        new
                        {
                            message = "Se carga data de distribucion por sucursal",
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
        [Route("ListarDistribucionId/{IdDis:int}")]
        public async Task<ActionResult<List<Distribucion>>> GetDistId(int IdDis)
        {
            List<Distribucion> lista = new List<Distribucion>();
            Distribucion ObjDis = _Dbcontext.Distribucions.Find(IdDis);
            if (ObjDis == null)
            {
                return BadRequest("No se encontro el id de distribución");
            }
            try
            {
                lista = _Dbcontext.Distribucions.Include(s => s.Suc).Where(d => d.DisId == IdDis).ToList();
                return StatusCode(StatusCodes.Status200OK,
                        new
                        {
                            message = "Se carga data de distribucionpor id",
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
        [Route("AddDistribucion")]
        public async Task<ActionResult> AddDistribucion([FromBody] AddDistribucion Obj)
        {
            var function = new DDistribucion();
            try
            {
                if (Obj.DisSigla == string.Empty) return BadRequest("El campo sigla no puede estar vacio");

                Distribucion ODis = new Distribucion();
                ODis.SucId = Obj.SucId;
                ODis.DisSigla = Obj.DisSigla;
                ODis.DisSerie = Obj.DisSerie;
                ODis.DisHabilitado = Obj.DisHabilitado;
                await function.Insert(ODis);
                return StatusCode(StatusCodes.Status200OK, new { message = "Datos almacenados correctamente" });
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status200OK, new { message = e.Message });
            }
        }

        [HttpPut]
        [Route("EditDistribucion/{IdDis:int}")]
        public async Task<ActionResult> EditDistribucion(int IdDis, [FromBody] AddDistribucion Obj)
        {
            var function = new DDistribucion();
            try
            {
                if (Obj.DisSigla == string.Empty) return BadRequest("El campo sigla no puede estar vacio");

                Distribucion ODis = new Distribucion();
                ODis.SucId = Obj.SucId;
                ODis.DisSigla = Obj.DisSigla;
                ODis.DisSerie = Obj.DisSerie;
                ODis.DisHabilitado = Obj.DisHabilitado;
                await function.Update(ODis, IdDis);
                return StatusCode(StatusCodes.Status200OK, new { message = "Datos se actualizaron correctamente" });
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status200OK, new { message = e.Message });
            }
        }

        [HttpDelete]
        [Route("DeleteDistribucion/{IdDis:int}")]
        public async Task<ActionResult> DeleteDistribucion(int IdDis)
        {
            var function = new DDistribucion();
            try
            {
                await function.Delete(IdDis);
                return StatusCode(StatusCodes.Status200OK, new { message = "Se elimino correctamente el id[" + IdDis + "]" });
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status200OK, new { message = e.Message });
            }
        }
    }//fin clase
}
