using Api_parqueadero.Models;
using Api_parqueadero.Connection;
using System.Data;
using Microsoft.Data.SqlClient;
using Api_parqueadero.Interface;
using NPOI.SS.Formula.Functions;

namespace Api_parqueadero.Datos
    
{
    public class DDistribucion : ICrud<Distribucion>
    {
        ConnectionBd conn = new ConnectionBd();
      
        public async Task Insert(Distribucion data) {
            using (var sql = new SqlConnection(conn.ConnSql())) {
                string Insert = "insert into distribucion(suc_id,dis_sigla,dis_serie,dis_habilitado) ";
                       Insert += "values(@suc_id,@dis_sigla,@dis_serie,@dis_habilitado);";
                using (var cmd = new SqlCommand(Insert,sql)) { 
                    cmd.CommandType=CommandType.Text;
                    cmd.Parameters.AddWithValue("@suc_id", data.SucId);
                    cmd.Parameters.AddWithValue("@dis_sigla", data.DisSigla);
                    cmd.Parameters.AddWithValue("@dis_serie", data.DisSerie);
                    cmd.Parameters.AddWithValue("@dis_habilitado", data.DisHabilitado);
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }
        public async Task Update(Distribucion data,int IdDis)
        {
            using (var sql = new SqlConnection(conn.ConnSql()))
            {
                string Update = "update distribucion ";
                Update += "set suc_id=@suc_id, ";
                Update += "dis_sigla=@dis_sigla, ";
                Update += "dis_serie=@dis_serie, ";
                Update += "dis_habilitado=@dis_habilitado ";
                Update += "where dis_id=@id";
                using (var cmd = new SqlCommand(Update, sql))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@id", IdDis);
                    cmd.Parameters.AddWithValue("@suc_id", data.SucId);
                    cmd.Parameters.AddWithValue("@dis_sigla", data.DisSigla);
                    cmd.Parameters.AddWithValue("@dis_serie", data.DisSerie);
                    cmd.Parameters.AddWithValue("@dis_habilitado", data.DisHabilitado);
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }
        public async Task Delete( int IdDis)
        {
            using (var sql = new SqlConnection(conn.ConnSql()))
            {
                string Delete = "delete from distribucion where dis_id=@id";
                using (var cmd = new SqlCommand(Delete, sql))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@id", IdDis);
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }

       
    }//fin clase
}
