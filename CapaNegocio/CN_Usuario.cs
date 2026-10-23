using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CapaNegocio
{
    public class CN_Usuario
    {
        private CD_Usuario objcd_usuario = new CD_Usuario();

        public List<Usuario> Listar()
        {
            return objcd_usuario.Listar();
        }

        // Devuelve el usuario si el documento y la clave son correctos y está activo; si no, null
        public Usuario Login(string documento, string clave)
        {
            if (documento == "" || clave == "")
            {
                return null;
            }
            return objcd_usuario.Login(documento, clave);
        }

        public int Registrar(Usuario obj, out string Mensaje)
        {
            Mensaje = string.Empty;
         
            if (obj.Documento == "")
            {
                Mensaje += "El documento es obligatorio\n";
            }
            if (obj.NombreCompleto == "")
            {
                Mensaje += "El nombre completo es obligatorio\n";
            }
            if (obj.Clave == "")
            {
                Mensaje += "La clave es obligatoria\n";
            }
            if (Mensaje != string.Empty)
            {
                return 0;
            }
            else
            {
                return objcd_usuario.Registrar(obj, out Mensaje);
            }
        }

        public bool Editar(Usuario obj, out string Mensaje)
        {
           Mensaje = string.Empty;
            if (obj.Documento == "")
            {
                Mensaje += "El documento es obligatorio\n";
            }
            if (obj.NombreCompleto == "")
            {
                Mensaje += "El nombre completo es obligatorio\n";
            }
            if (obj.Clave == "")
            {
                Mensaje += "La clave es obligatoria\n";
            }
            if (Mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return objcd_usuario.Editar(obj, out Mensaje);
            }
        }


        public bool Eliminar(Usuario obj, out string Mensaje)
            {
                return objcd_usuario.Eliminar(obj, out Mensaje);
        }
    }
}
