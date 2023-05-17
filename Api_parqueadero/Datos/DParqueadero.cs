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
   
        public async Task ProcesoPq(ProcesoVehiculo data) {
            using (var sql = new SqlConnection(conn.ConnSql())) {
                using (var cmd = new SqlCommand("Sp_liquidacion",sql)) { 
                    cmd.CommandType=CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@placa", data.Placa);
                    cmd.Parameters.AddWithValue("@tipo_veh", data.Tipo_veh);
                    cmd.Parameters.AddWithValue("@marca", data.Mar_id);
                    cmd.Parameters.AddWithValue("@sucursal", data.IdSucursal);
                    cmd.Parameters.AddWithValue("@factura", data.Factura);
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }
       
       
    }//fin clase
}
