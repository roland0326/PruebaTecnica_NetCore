using Api_parqueadero.Models;
using Api_parqueadero.Connection;
using System.Data;
using Microsoft.Data.SqlClient;
using Api_parqueadero.Interface;
using NPOI.SS.Formula.Functions;

namespace Api_parqueadero.Datos
    
{
    public class DTipoVehiculo : ICrud<TipoVehiculo>
    {
        ConnectionBd conn = new ConnectionBd();
        public async Task<List<TipoVehiculo>> Listar() {
            var lista= new  List<TipoVehiculo>();
            using (var sql = new SqlConnection(conn.ConnSql())) {
                string Query = "select * from tipo_vehiculo";
                using (var cmd= new SqlCommand(Query, sql)){
                    await sql.OpenAsync();
                    cmd.CommandType= CommandType.Text;
                    using (var item = await cmd.ExecuteReaderAsync()) {
                        while (await item.ReadAsync()) {
                            var TipVeh= new TipoVehiculo();
                            TipVeh.TipvehId = (int)item["tipveh_id"];
                            TipVeh.TipvehCodigo = (string)item["tipveh_codigo"];
                            TipVeh.TipvehDescrip = (string)item["tipveh_descrip"];
                            TipVeh.TipvehTarifa = (decimal)item["tipveh_tarifa"];
                            lista.Add(TipVeh);
                        }
                    }
                }
            }
            return lista;
        }
        public async Task Insert(TipoVehiculo data) {
            using (var sql = new SqlConnection(conn.ConnSql())) {
                string Insert = "insert into tipo_vehiculo(tipveh_codigo,tipveh_descrip,tipveh_tarifa) ";
                Insert += "values(@tipveh_codigo,@tipveh_descrip,@tipveh_tarifa);";
                using (var cmd = new SqlCommand(Insert,sql)) { 
                    cmd.CommandType=CommandType.Text;
                    cmd.Parameters.AddWithValue("@tipveh_codigo", data.TipvehCodigo);
                    cmd.Parameters.AddWithValue("@tipveh_descrip", data.TipvehDescrip);
                    cmd.Parameters.AddWithValue("@tipveh_tarifa", data.TipvehTarifa);
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }
        public async Task Update(TipoVehiculo data,int IdTipVeh)
        {
            using (var sql = new SqlConnection(conn.ConnSql()))
            {
                string Update = "update tipo_vehiculo ";
                Update += "set tipveh_codigo=@tipveh_codigo, ";
                Update += "tipveh_descrip=@tipveh_descrip, ";
                Update += "tipveh_tarifa=@tipveh_tarifa ";
                Update += "where tipveh_id=@id";
                using (var cmd = new SqlCommand(Update, sql))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@id", IdTipVeh);
                    cmd.Parameters.AddWithValue("@tipveh_codigo", data.TipvehCodigo);
                    cmd.Parameters.AddWithValue("@tipveh_descrip", data.TipvehDescrip);
                    cmd.Parameters.AddWithValue("@tipveh_tarifa", data.TipvehTarifa);
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }
        public async Task Delete( int IdTipVeh)
        {
            using (var sql = new SqlConnection(conn.ConnSql()))
            {
                string Delete = "delete from tipo_vehiculo where tipveh_id=@id";
                using (var cmd = new SqlCommand(Delete, sql))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@id", IdTipVeh);
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }

       
    }//fin clase
}
