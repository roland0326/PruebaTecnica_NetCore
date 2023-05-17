using Api_parqueadero.Models;
using Api_parqueadero.Repository;
using Api_parqueadero.Connection;
using System.Data;
using Microsoft.Data.SqlClient;
using Api_parqueadero.Interface;
using NPOI.SS.Formula.Functions;

namespace Api_parqueadero.Datos
    
{
    public class DParqueadero
    {
        ConnectionBd conn = new ConnectionBd();
   
        public async Task<List<ReporteParqueadero>> ProcesoPq(ProcesoVehiculo data) {
            var lista= new List<ReporteParqueadero>();
            using (var sql = new SqlConnection(conn.ConnSql())) {
                using (var cmd = new SqlCommand("Sp_liquidacion",sql)) { 
                    
                    cmd.Parameters.AddWithValue("@placa", data.Placa);
                    cmd.Parameters.AddWithValue("@tipo_veh", data.Tipo_veh);
                    cmd.Parameters.AddWithValue("@marca", data.Mar_id);
                    cmd.Parameters.AddWithValue("@sucursal", data.IdSucursal);
                    cmd.Parameters.AddWithValue("@factura", data.Factura);
                    await sql.OpenAsync();
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (var item=await cmd.ExecuteReaderAsync()) {
                        while (await item.ReadAsync())
                        {
                            var Repor = new ReporteParqueadero();
                            Repor.Parqueid = (int)item["ParqueId"];
                            Repor.HoraEntrada = (DateTime)item["HoraEntrada"];
                            Repor.HoraSalida = (DateTime)item["HoraSalida"];
                            Repor.TiempoParqueo = (decimal)item["TiempoParqueo"];
                            Repor.DctoDescuento = (string)item["DctoDescuento"];
                            Repor.ValorPagado = (decimal)item["ValorPagado"];
                            Repor.Placa = (string)item["Placa"];
                            Repor.TipoVehiculo = (string)item["TipoVehiculo"];
                            Repor.Tarifa = (decimal)item["Tarifa"]; 
                            Repor.IdParqueo = (int)item["Idparqueo"];
                            Repor.NumeroParqueo = (string)item["NumeroParqueo"];
                            lista.Add(Repor);
                        }
                    }
                        
                }
            }
            return lista;
        }
       
       
    }//fin clase
}
