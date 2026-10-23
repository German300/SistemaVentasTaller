using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class CN_Negocio
    {
        private CD_Negocio objcd_negocio = new CD_Negocio();

        public Negocio ObtenerDatos()
        {
            return objcd_negocio.ObtenerDatos();
        }

        public bool GuardarDatos(Negocio obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.RUC == "")
            {
                Mensaje += "El RUC es obligatorio\n";
            }
            if (obj.Nombre == "")
            {
                Mensaje += "El nombre es obligatorio\n";
            }
            if (obj.Direccion == "")
            {
                Mensaje += "La dirección es obligatoria\n";
            }

            if (Mensaje != string.Empty)
            {
                return false;
            }

            return objcd_negocio.GuardarDatos(obj, out Mensaje);
        }

        public byte[] ObtenerLogo(out bool obtenido)
        {
            return objcd_negocio.ObtenerLogo(out obtenido);
        }

        public bool ActualizarLogo(byte[] imagen, out string Mensaje)
        {
            return objcd_negocio.ActualizarLogo(imagen, out Mensaje);
        }
    }
}
