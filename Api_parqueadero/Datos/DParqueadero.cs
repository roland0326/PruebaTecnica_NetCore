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

        public async Task<List<ReporteParqueadero>> ReporteFechas(ReporteRangoFechas data)
        {
            var lista = new List<ReporteParqueadero>();
            using (var sql = new SqlConnection(conn.ConnSql()))
            {
                string Query = "select a.parque_id ParqueId, ";
                Query += "a.parque_hora_in HoraEntrada, ";
                Query += "convert(datetime,isnull(a.parque_hora_out,'1900-01-01')) HoraSalida, ";
                Query += "a.parque_tiempo_min TiempoParqueo, ";
                Query += "isnull(a.par_fac_dcto,'N/A') DctoDescuento, ";
                Query += "a.parque_costo ValorPagado, ";
                Query += "b.veh_placa Placa, ";
                Query += "c.tipveh_codigo TipoVehiculo, ";
                Query += "c.tipveh_tarifa Tarifa, ";
                Query += "d.dis_id IdParqueo, ";
                Query += "d.dis_sigla+'-'+CONVERT(varchar,d.dis_serie) NumeroParqueo ";
                Query += "from mov_paqueadero as a ";
                Query += "inner join vehiculo as b on b.veh_id=a.veh_id ";
                Query += "inner join tipo_vehiculo as c on c.tipveh_id=b.tipveh_id ";
                Query += "inner join distribucion as d on d.dis_id=a.dis_id ";
		        Query += "where a.parque_hora_in between convert(datetime,@FecIni) and convert(datetime,@FecFin) ";
                using (var cmd = new SqlCommand(Query, sql))
                {

                    cmd.Parameters.AddWithValue("@FecIni",Convert.ToDateTime(data.Fecini).ToString("yyyy-MM-dd hh:mm:ss"));
                    cmd.Parameters.AddWithValue("@FecFin", Convert.ToDateTime(data.Fecfin).ToString("yyyy-MM-dd hh:mm:ss"));
                    await sql.OpenAsync();
                    cmd.CommandType = CommandType.Text;
                    using (var item = await cmd.ExecuteReaderAsync())
                    {
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
