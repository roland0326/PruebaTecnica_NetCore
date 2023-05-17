using Api_parqueadero.Models;
using Api_parqueadero.Connection;
using System.Data;
using Microsoft.Data.SqlClient;
using Api_parqueadero.Interface;
using NPOI.SS.Formula.Functions;

namespace Api_parqueadero.Datos
    
{
    public class DCiudad: ICrud<Ciudad>
    {
        ConnectionBd conn = new ConnectionBd();
        public async Task<List<Ciudad>> Listar() {
            var listaCiu= new  List<Ciudad>();
            using (var sql = new SqlConnection(conn.ConnSql())) {
                string Query = "select * from ciudad";
                using (var cmd= new SqlCommand(Query, sql)){
                    await sql.OpenAsync();
                    cmd.CommandType= CommandType.Text;
                    using (var item = await cmd.ExecuteReaderAsync()) {
                        while (await item.ReadAsync()) {
                            var Ciu= new Ciudad();
                            Ciu.CiuId = (int)item["ciu_id"];
                            Ciu.CiuCodigo = (string)item["ciu_codigo"];
                            Ciu.CiuNombre = (string)item["ciu_nombre"];
                            listaCiu.Add(Ciu);
                        }
                    }
                }
            }
            return listaCiu;
        }
        public async Task Insert(Ciudad data) {
            using (var sql = new SqlConnection(conn.ConnSql())) {
                string Insert = "insert into ciudad(ciu_codigo,ciu_nombre) values(@codigo,@nombre);";
                using (var cmd = new SqlCommand(Insert,sql)) { 
                    cmd.CommandType=CommandType.Text;
                    cmd.Parameters.AddWithValue("@codigo", data.CiuCodigo);
                    cmd.Parameters.AddWithValue("@nombre", data.CiuNombre);
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }
        public async Task Update(Ciudad data,int IdCiu)
        {
            using (var sql = new SqlConnection(conn.ConnSql()))
            {
                string Update = "update ciudad set ciu_codigo=@codigo, ciu_nombre=@nombre where ciu_id=@id";
                using (var cmd = new SqlCommand(Update, sql))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@id", IdCiu);
                    cmd.Parameters.AddWithValue("@codigo", data.CiuCodigo);
                    cmd.Parameters.AddWithValue("@nombre", data.CiuNombre);
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }
        public async Task Delete( int IdCiu)
        {
            using (var sql = new SqlConnection(conn.ConnSql()))
            {
                string Delete = "delete from ciudad where ciu_id=@id";
                using (var cmd = new SqlCommand(Delete, sql))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@id", IdCiu);
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }

       
    }//fin clase
}
