using Api_parqueadero.Models;
using Api_parqueadero.Connection;
using System.Data;
using Microsoft.Data.SqlClient;
using Api_parqueadero.Interface;
using NPOI.SS.Formula.Functions;

namespace Api_parqueadero.Datos
    
{
    public class DSucursal : ICrud<Sucursal>
    {
        ConnectionBd conn = new ConnectionBd();       
        public async Task Insert(Sucursal data) {
            using (var sql = new SqlConnection(conn.ConnSql())) {
                string Insert = "insert into sucursal(tipide_id,suc_documento,ciu_id,suc_dir,suc_razon,suc_maneja_dcto,suc_dcto) ";
                Insert += "values(@tipide_id,@suc_documento,@ciu_id,@suc_dir,@suc_razon,@suc_maneja_dcto,@suc_dcto);";
                using (var cmd = new SqlCommand(Insert,sql)) { 
                    cmd.CommandType=CommandType.Text;
                    cmd.Parameters.AddWithValue("@tipide_id", data.TipideId);
                    cmd.Parameters.AddWithValue("@suc_documento", data.SucDocumento);
                    cmd.Parameters.AddWithValue("@ciu_id", data.CiuId);
                    cmd.Parameters.AddWithValue("@suc_dir", data.SucDir);
                    cmd.Parameters.AddWithValue("@suc_razon", data.SucRazon);
                    cmd.Parameters.AddWithValue("@suc_maneja_dcto", data.SucManejaDcto);
                    cmd.Parameters.AddWithValue("@suc_dcto", data.SucDcto);
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }
        public async Task Update(Sucursal data,int IdSuc)
        {
            using (var sql = new SqlConnection(conn.ConnSql()))
            {
                string Update = "update sucursal ";
                        Update += "set tipide_id=@tipide_id, ";
                        Update += "suc_documento=@suc_documento, ";
                        Update += "ciu_id =@ciu_id, ";
                        Update += "suc_dir=@suc_dir, ";
                        Update += "suc_razon=@suc_razon, ";
                        Update += "suc_maneja_dcto=@suc_maneja_dcto, ";
                        Update += "suc_dcto=@suc_dcto  ";
                        Update += "where suc_id=@id";
                using (var cmd = new SqlCommand(Update, sql))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@id", IdSuc);
                    cmd.Parameters.AddWithValue("@tipide_id", data.TipideId);
                    cmd.Parameters.AddWithValue("@suc_documento", data.SucDocumento);
                    cmd.Parameters.AddWithValue("@ciu_id", data.CiuId);
                    cmd.Parameters.AddWithValue("@suc_dir", data.SucDir);
                    cmd.Parameters.AddWithValue("@suc_razon", data.SucRazon);
                    cmd.Parameters.AddWithValue("@suc_maneja_dcto", data.SucManejaDcto);
                    cmd.Parameters.AddWithValue("@suc_dcto", data.SucDcto);
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }
        public async Task Delete( int IdSuc)
        {
            using (var sql = new SqlConnection(conn.ConnSql()))
            {
                string Delete = "delete from sucursal where suc_id=@id";
                using (var cmd = new SqlCommand(Delete, sql))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@id", IdSuc);
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }

       
    }//fin clase
}
