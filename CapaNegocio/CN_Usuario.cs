using CapaDatos;
using CapaEntidad;
using System.Collections.Generic;

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
            Mensaje = Validar(obj);

            if (Mensaje != string.Empty)
            {
                return 0;
            }

            return objcd_usuario.Registrar(obj, out Mensaje);
        }

        public bool Editar(Usuario obj, out string Mensaje)
        {
            Mensaje = Validar(obj);

            if (Mensaje != string.Empty)
            {
                return false;
            }

            return objcd_usuario.Editar(obj, out Mensaje);
        }

        public bool Eliminar(Usuario obj, out string Mensaje)
        {
            return objcd_usuario.Eliminar(obj, out Mensaje);
        }

        // Devuelve los errores encontrados, o "" si está todo bien
        private string Validar(Usuario obj)
        {
            string Mensaje = string.Empty;

            // DNI: obligatorio, solo números, hasta 8 dígitos
            if (obj.Documento == "")
            {
                Mensaje += "El documento es obligatorio\n";
            }
            else if (!Validacion.SoloNumeros(obj.Documento) || obj.Documento.Length > 8)
            {
                Mensaje += "El documento debe tener solo números (hasta 8 dígitos)\n";
            }

            // nombre: obligatorio, solo letras y espacios
            if (obj.NombreCompleto == "")
            {
                Mensaje += "El nombre completo es obligatorio\n";
            }
            else if (!Validacion.SoloLetras(obj.NombreCompleto))
            {
                Mensaje += "El nombre solo puede tener letras y espacios\n";
            }

            // correo: no es obligatorio, pero si se carga tiene que tener formato válido
            if (!string.IsNullOrEmpty(obj.Correo) && !Validacion.CorreoValido(obj.Correo))
            {
                Mensaje += "El correo no tiene un formato válido (ejemplo: nombre@gmail.com)\n";
            }

            if (obj.Clave == "")
            {
                Mensaje += "La clave es obligatoria\n";
            }

            return Mensaje;
        }
    }
}
