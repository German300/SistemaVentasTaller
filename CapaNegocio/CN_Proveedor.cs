using CapaDatos;
using CapaEntidad;
using System.Collections.Generic;

namespace CapaNegocio
{
    public class CN_Proveedor
    {
        private CD_Proveedor objcd_proveedor = new CD_Proveedor();

        public List<Proveedor> Listar()
        {
            return objcd_proveedor.Listar();
        }

        public int Registrar(Proveedor obj, out string Mensaje)
        {
            Mensaje = Validar(obj);

            if (Mensaje != string.Empty)
            {
                return 0;
            }

            return objcd_proveedor.Registrar(obj, out Mensaje);
        }

        public bool Editar(Proveedor obj, out string Mensaje)
        {
            Mensaje = Validar(obj);

            if (Mensaje != string.Empty)
            {
                return false;
            }

            return objcd_proveedor.Editar(obj, out Mensaje);
        }

        public bool Eliminar(Proveedor obj, out string Mensaje)
        {
            return objcd_proveedor.Eliminar(obj, out Mensaje);
        }

        // Devuelve los errores encontrados, o "" si está todo bien
        private string Validar(Proveedor obj)
        {
            string Mensaje = string.Empty;

            // CUIT: obligatorio, 11 números sin guiones
            if (obj.Documento == "")
            {
                Mensaje += "El CUIT del proveedor es obligatorio\n";
            }
            else if (!Validacion.SoloNumeros(obj.Documento) || obj.Documento.Length != 11)
            {
                Mensaje += "El CUIT debe tener 11 números, sin guiones\n";
            }

            // la razón social puede tener números y puntos (ej: "Distribuidora 2000 S.A.")
            if (obj.RazonSocial == "")
            {
                Mensaje += "La razón social del proveedor es obligatoria\n";
            }

            // correo: obligatorio, con formato algo@algo.algo
            if (obj.Correo == "")
            {
                Mensaje += "El correo del proveedor es obligatorio\n";
            }
            else if (!Validacion.CorreoValido(obj.Correo))
            {
                Mensaje += "El correo no tiene un formato válido (ejemplo: ventas@empresa.com)\n";
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
