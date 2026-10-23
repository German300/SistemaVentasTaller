using CapaDatos;
using CapaEntidad;
using System.Data;

namespace CapaNegocio
{
    public class CN_Compra
    {
        private CD_Compra objcd_compra = new CD_Compra();

        public int ObtenerCorrelativo()
        {
            return objcd_compra.ObtenerCorrelativo();
        }

        public bool Registrar(Compra obj, DataTable DetalleCompra, out string Mensaje)
        {
            return objcd_compra.Registrar(obj, DetalleCompra, out Mensaje);
        }

        // Trae la compra y, si existe, también sus productos
        public Compra ObtenerCompra(string numero)
        {
            Compra oCompra = objcd_compra.ObtenerCompra(numero);

            if (oCompra.IdCompra != 0)
            {
                oCompra.oDetalleCompra = objcd_compra.ObtenerDetalleCompra(oCompra.IdCompra);
            }

            return oCompra;
        }
    }
}
