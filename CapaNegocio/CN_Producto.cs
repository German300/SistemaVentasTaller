using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Producto
    {

        private CD_Producto objcd_producto = new CD_Producto();

        public List<Producto> Listar()
        {
            return objcd_producto.Listar();
        }

        public int Registrar(Producto obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.Codigo == "")
            {
                Mensaje += "El código es obligatorio\n";
            }
            if (obj.Nombre == "")
            {
                Mensaje += "El nombre es obligatorio\n";
            }
            if (obj.Descripcion == "")
            {
                Mensaje += "La descripción es obligatoria\n";
            }
            if (Mensaje != string.Empty)
            {
                return 0;
            }
            else
            {
                return objcd_producto.Registrar(obj, out Mensaje);
            }
        }

        public bool Editar(Producto obj, out string Mensaje)
        {
            Mensaje = string.Empty;
            if (obj.Codigo == "")
            {
                Mensaje += "El código es obligatorio\n";
            }
            if (obj.Nombre == "")
            {
                Mensaje += "El nombre es obligatorio\n";
            }
            if (obj.Descripcion == "")
            {
                Mensaje += "La descripción es obligatoria\n";
            }
            if (Mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return objcd_producto.Editar(obj, out Mensaje);
            }
        }

        public bool Eliminar(Producto obj, out string Mensaje)
        {
            return objcd_producto.Eliminar(obj, out Mensaje);
        }
    }
}

