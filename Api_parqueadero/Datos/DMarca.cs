using Api_parqueadero.Models;
using Api_parqueadero.Connection;
using System.Data;
using Microsoft.Data.SqlClient;
using Api_parqueadero.Interface;
using NPOI.SS.Formula.Functions;

namespace Api_parqueadero.Datos
    
{
    public class DMarca 
    {
        ConnectionBd conn = new ConnectionBd();
        public async Task<List<Marca>> Listar()
        {
            var lista = new List<Marca>();
            using (var sql = new SqlConnection(conn.ConnSql()))
            {
                string Query = "select * from marca";
                using (var cmd = new SqlCommand(Query, sql))
                {
                    await sql.OpenAsync();
                    cmd.CommandType = CommandType.Text;
                    using (var item = await cmd.ExecuteReaderAsync())
                    {
                        while (await item.ReadAsync())
                        {
                            var Mar = new Marca();
                            Mar.MarId = (int)item["mar_id"];
                            Mar.MarCodigo = (string)item["mar_codigo"];
                            Mar.MarDescrip = (string)item["mar_descrip"];
                            lista.Add(Mar);
                        }
                    }
                }
            }
            return lista;
        }
        public async Task Insert(Marca data)
        {
            using (var sql = new SqlConnection(conn.ConnSql()))
            {
                string Insert = "insert into marca(mar_codigo,mar_descrip) values(@codigo,@descrip);";
                using (var cmd = new SqlCommand(Insert, sql))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@codigo", data.MarCodigo);
                    cmd.Parameters.AddWithValue("@descrip", data.MarDescrip);
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }
        public async Task Update(Marca data, int IdMar)
        {
            using (var sql = new SqlConnection(conn.ConnSql()))
            {
                string Update = "update marca set mar_codigo=@codigo, mar_descrip=@descrip where mar_id=@id";
                using (var cmd = new SqlCommand(Update, sql))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@id", IdMar);
                    cmd.Parameters.AddWithValue("@codigo", data.MarCodigo);
                    cmd.Parameters.AddWithValue("@descrip", data.MarDescrip);
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }
        public async Task Delete(int IdMar)
        {
            using (var sql = new SqlConnection(conn.ConnSql()))
            {
                string Delete = "delete from marca where mar_id=@id";
                using (var cmd = new SqlCommand(Delete, sql))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@id", IdMar);
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }


    }//fin clase
}
