using Api_parqueadero.Models;
using Api_parqueadero.Connection;
using System.Data;
using Microsoft.Data.SqlClient;
using Api_parqueadero.Interface;
using NPOI.SS.Formula.Functions;

namespace Api_parqueadero.Datos
    
{
    public class DTipoIdentificacion 
    {
        ConnectionBd conn = new ConnectionBd();
        public async Task<List<TipoIdentificacion>> Listar() {
            var lista= new  List<TipoIdentificacion>();
            using (var sql = new SqlConnection(conn.ConnSql())) {
                string Query = "select * from tipo_identificacion";
                using (var cmd= new SqlCommand(Query, sql)){
                    await sql.OpenAsync();
                    cmd.CommandType= CommandType.Text;
                    using (var item = await cmd.ExecuteReaderAsync()) {
                        while (await item.ReadAsync()) {
                            var TipIde= new TipoIdentificacion();
                            TipIde.TipideId = (int)item["tipide_id"];
                            TipIde.TipideCodigo = (string)item["tipide_codigo"];
                            TipIde.TipideDescrip = (string)item["tipide_descrip"];
                            lista.Add(TipIde);
                        }
                    }
                }
            }
            return lista;
        }
        

       
    }//fin clase
}
