using Api_parqueadero.Models;
using Api_parqueadero.Connection;
using System.Data;
using Microsoft.Data.SqlClient;
using Api_parqueadero.Interface;
using NPOI.SS.Formula.Functions;

namespace Api_parqueadero.Datos
    
{
    public class DVehiculo : ICrud<Vehiculo>
    {
        ConnectionBd conn = new ConnectionBd();
      
        public async Task Insert(Vehiculo data) {
            using (var sql = new SqlConnection(conn.ConnSql())) {
                string Insert = "insert into vehiculo(tipveh_id,mar_id,veh_placa,veh_fec_registro) ";
                Insert += "values(@tipveh_id,@mar_id,@veh_placa,getdate());";
                using (var cmd = new SqlCommand(Insert,sql)) { 
                    cmd.CommandType=CommandType.Text;
                    cmd.Parameters.AddWithValue("@tipveh_id", data.TipvehId);
                    cmd.Parameters.AddWithValue("@mar_id", data.MarId);
                    cmd.Parameters.AddWithValue("@veh_placa", data.VehPlaca);
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }
        public async Task Update(Vehiculo data,int IdVeh)
        {
            using (var sql = new SqlConnection(conn.ConnSql()))
            {
                string Update = "update vehiculo ";
                Update += "set tipveh_id=@tipveh_id, ";
                Update += "mar_id=@mar_id, ";
                Update += "veh_placa=@veh_placa ";
                Update += "where veh_id=@id";
                using (var cmd = new SqlCommand(Update, sql))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@id", IdVeh);
                    cmd.Parameters.AddWithValue("@tipveh_id", data.TipvehId);
                    cmd.Parameters.AddWithValue("@mar_id", data.MarId);
                    cmd.Parameters.AddWithValue("@veh_placa", data.VehPlaca);
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }
        public async Task Delete( int IdVeh)
        {
            using (var sql = new SqlConnection(conn.ConnSql()))
            {
                string Delete = "delete from vehiculo where veh_id=@id";
                using (var cmd = new SqlCommand(Delete, sql))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@id", IdVeh);
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }

       
    }//fin clase
}
