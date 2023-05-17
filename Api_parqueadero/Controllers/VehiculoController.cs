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
    public class VehiculoController : Controller
    {
        private readonly ParqueaderoContext _Dbcontext;
        public VehiculoController(ParqueaderoContext context)
        {
            _Dbcontext = context;
        }

        [HttpGet]
        [Route("ListarVehiculo")]
        public async Task<ActionResult<List<Vehiculo>>> GetVehiculo()
        {
            List<Vehiculo> lista= new List<Vehiculo>();

            try
            {

                 lista= _Dbcontext.Vehiculos.Include(t => t.Tipveh).ToList();            
                return StatusCode(StatusCodes.Status200OK,
                        new
                        {
                            message = "Se carga data del vehiculo",
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
        [Route("ListarVehiculo/{IdVeh:int}")]
        public async Task<ActionResult<List<Vehiculo>>> GetVehiculolId(int IdVeh)
        {
            List<Vehiculo> lista = new List<Vehiculo>();
            Vehiculo ObjVeh = _Dbcontext.Vehiculos.Find(IdVeh);
            if (ObjVeh == null)
            {
                return BadRequest("No se encontro el id del vehiculo");
            }
            try
            {
                lista = _Dbcontext.Vehiculos.Include(t => t.Tipveh).Where(v=> v.VehId== IdVeh).ToList();
                return StatusCode(StatusCodes.Status200OK,
                        new
                        {
                            message = "Se carga data del vehiculo",
                            Response = lista
                        }
                    );
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status200OK, new { message = e.Message });
            }
        }

        //[HttpGet]
        //[Route("ListarVehiculoPlaca/{Placa:String}")]
        //public async Task<ActionResult<List<Vehiculo>>> GetVehiculolPlacaId(String Placa)
        //{
        //    List<Vehiculo> lista = new List<Vehiculo>();
        //    Vehiculo ObjVeh = _Dbcontext.Vehiculos.Find(Placa);
        //    if (ObjVeh == null)
        //    {
        //        return BadRequest("No se encontro la placa del vehiculo");
        //    }
        //    try
        //    {
        //        lista = _Dbcontext.Vehiculos.Include(t => t.Tipveh).Where(v => v.VehPlaca == Placa).ToList();
        //        return StatusCode(StatusCodes.Status200OK,
        //                new
        //                {
        //                    message = "Se carga data del vehiculo",
        //                    Response = lista
        //                }
        //            );
        //    }
        //    catch (Exception e)
        //    {
        //        return StatusCode(StatusCodes.Status200OK, new { message = e.Message });
        //    }
        //}

        [HttpPost]
        [Route("AddVehiculo")]
        public async Task<ActionResult> AddVehiculo([FromBody] AddVehiculo Obj)
        {
            var function = new DVehiculo();
            try
            {
                if (Obj.VehPlaca == string.Empty) return BadRequest("El campo placa no puede estar vacio");              

                Vehiculo OVeh = new Vehiculo();
                OVeh.TipvehId = Obj.TipvehId;
                OVeh.MarId = Obj.MarId;
                OVeh.VehPlaca = Obj.VehPlaca;
                await function.Insert(OVeh);
                return StatusCode(StatusCodes.Status200OK, new { message = "Datos almacenados correctamente" });
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status200OK, new { message = e.Message });
            }
        }

        [HttpPut]
        [Route("EditVehiculo/{IdVeh:int}")]
        public async Task<ActionResult> EditVehiculo(int IdVeh, [FromBody] AddVehiculo Obj)
        {
            var function = new DVehiculo();
            try
            {
                if (Obj.VehPlaca == string.Empty) return BadRequest("El campo placa no puede estar vacio");

                Vehiculo OVeh = new Vehiculo();
                OVeh.TipvehId = Obj.TipvehId;
                OVeh.MarId = Obj.MarId;
                OVeh.VehPlaca = Obj.VehPlaca;
                await function.Update(OVeh, IdVeh);
                return StatusCode(StatusCodes.Status200OK, new { message = "Datos se actualizaron correctamente" });
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status200OK, new { message = e.Message });
            }
        }

        [HttpDelete]
        [Route("DeleteIdVehiculo/{IdVeh:int}")]
        public async Task<ActionResult> DeleteVehiculo(int IdVeh)
        {
            var function = new DVehiculo();
            try
            {
                await function.Delete(IdVeh);
                return StatusCode(StatusCodes.Status200OK, new { message = "Se elimino correctamente el id[" + IdVeh + "]" });
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status200OK, new { message = e.Message });
            }
        }
    }//fin clase
}
