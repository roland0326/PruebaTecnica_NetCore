namespace Api_parqueadero.Repository
{
    public class ReporteParqueadero
    {
        public int Parqueid { get; set; }
        public DateTime HoraEntrada { get; set; }
        public DateTime HoraSalida { get; set; }
        public decimal TiempoParqueo { get; set; }
        public string? DctoDescuento { get; set; }
        public decimal ValorPagado { get; set; }
        public string Placa { get; set; }
        public string TipoVehiculo { get; set; }

        public decimal Tarifa { get; set; }
        public int IdParqueo { get; set; }
        public string NumeroParqueo { get; set; }
    }
}
