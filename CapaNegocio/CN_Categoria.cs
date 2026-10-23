using CapaDatos;
using CapaEntidad;
using System.Collections.Generic;

namespace CapaNegocio
{
    public class CN_Categoria
    {
        private CD_Categoria objcd_categoria = new CD_Categoria();

        public List<Categoria> Listar()
        {
            return objcd_categoria.Listar();
        }

        public int Registrar(Categoria obj, out string Mensaje)
        {
            Mensaje = Validar(obj);

            if (Mensaje != string.Empty)
            {
                return 0;
            }

            return objcd_categoria.Registrar(obj, out Mensaje);
        }

        public bool Editar(Categoria obj, out string Mensaje)
        {
            Mensaje = Validar(obj);

            if (Mensaje != string.Empty)
            {
                return false;
            }

            return objcd_categoria.Editar(obj, out Mensaje);
        }

        public bool Eliminar(Categoria obj, out string Mensaje)
        {
            return objcd_categoria.Eliminar(obj, out Mensaje);
        }

        // Devuelve los errores encontrados, o "" si está todo bien
        private string Validar(Categoria obj)
        {
            string Mensaje = string.Empty;

            if (obj.Descripcion == "")
            {
                Mensaje += "La descripción de la categoría es obligatoria\n";
            }

            return Mensaje;
        }
    }
}
