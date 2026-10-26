namespace CapaEntidad
{
    // Una fila del reporte de compras: un producto comprado con los datos de su compra
    public class ReporteCompra
    {
        public string FechaRegistro { get; set; }
        public string TipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public string RazonSocial { get; set; }
        public string NombreUsuario { get; set; }
        public string NombreProducto { get; set; }
        public string Categoria { get; set; }
        public decimal PrecioCompra { get; set; }
        public int Cantidad { get; set; }
        public decimal SubTotal { get; set; }
    }
}
