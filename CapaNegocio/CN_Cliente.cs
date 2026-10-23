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

            if (obj.Documento == "")
            {
                Mensaje += "El documento es obligatorio\n";
            }
            if (obj.NombreCompleto == "")
            {
                Mensaje += "El nombre completo es obligatorio\n";
            }
            if (obj.Correo == "")
            {
                Mensaje += "El correo es obligatorio\n";
            }

            return Mensaje;
        }
    }
}
