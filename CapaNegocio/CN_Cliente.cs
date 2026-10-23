using CapaDatos;
using CapaEntidad;
using System.Collections.Generic;

namespace CapaNegocio
{
    public class CN_Cliente
    {
        private CD_Cliente objcd_cliente = new CD_Cliente();

        public List<Cliente> Listar()
        {
            return objcd_cliente.Listar();
        }

        public int Registrar(Cliente obj, out string Mensaje)
        {
            Mensaje = Validar(obj);

            if (Mensaje != string.Empty)
            {
                return 0;
            }

            return objcd_cliente.Registrar(obj, out Mensaje);
        }

        public bool Editar(Cliente obj, out string Mensaje)
        {
            Mensaje = Validar(obj);

            if (Mensaje != string.Empty)
            {
                return false;
            }

            return objcd_cliente.Editar(obj, out Mensaje);
        }

        public bool Eliminar(Cliente obj, out string Mensaje)
        {
            return objcd_cliente.Eliminar(obj, out Mensaje);
        }

        // Devuelve los errores encontrados, o "" si está todo bien
        private string Validar(Cliente obj)
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

            // correo: obligatorio, con formato algo@algo.algo
            if (obj.Correo == "")
            {
                Mensaje += "El correo es obligatorio\n";
            }
            else if (!Validacion.CorreoValido(obj.Correo))
            {
                Mensaje += "El correo no tiene un formato válido (ejemplo: nombre@gmail.com)\n";
            }

            // teléfono: no es obligatorio, pero si se carga, solo números de 8 a 15 dígitos
            if (!string.IsNullOrEmpty(obj.Telefono))
            {
                if (!Validacion.SoloNumeros(obj.Telefono) || obj.Telefono.Length < 8 || obj.Telefono.Length > 15)
                {
                    Mensaje += "El teléfono debe tener solo números (entre 8 y 15 dígitos)\n";
                }
            }

            return Mensaje;
        }
    }
}
