using System.Collections.Generic;

namespace CapaEntidad
{
    public class Venta
    {
        public int IdVenta { get; set; }
        public Usuario oUsuario { get; set; }
        public Cliente oCliente { get; set; } 
        public string TipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public string DocumentoCliente { get; set; } 
        public string NombreCliente { get; set; }   
        public decimal MontoPago { get; set; }
        public decimal MontoCambio { get; set; }
        public decimal MontoTotal { get; set; }
        public string FechaRegistro { get; set; }
        public List<Detalle_Venta> oDetalleVenta { get; set; }
    }
}