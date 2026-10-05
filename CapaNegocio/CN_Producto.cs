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
            Mensaje = Validar(obj);

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
            Mensaje = Validar(obj);

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

        // El código no se valida: lo genera la base de datos al registrar
        private string Validar(Producto obj)
        {
            string Mensaje = string.Empty;

            if (obj.Nombre.Trim() == "")
            {
                Mensaje += "El nombre es obligatorio\n";
            }
            if (obj.Descripcion.Trim() == "")
            {
                Mensaje += "La descripción es obligatoria\n";
            }
            if (obj.oCategoria == null || obj.oCategoria.IdCategoria == 0)
            {
                Mensaje += "Debe seleccionar una categoría\n";
            }
            if (obj.PrecioCompra < 0)
            {
                Mensaje += "El precio de compra no puede ser negativo\n";
            }
            if (obj.Stock < 0)
            {
                Mensaje += "La cantidad no puede ser negativa\n";
            }
            if (obj.PrecioVenta <= 0)
            {
                Mensaje += "El precio de venta debe ser mayor a 0\n";
            }

            return Mensaje;
        }
    }
}
