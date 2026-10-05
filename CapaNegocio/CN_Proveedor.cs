using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            Mensaje = string.Empty;

            if (obj.Documento == "")
            {
                Mensaje += "El documento del proveedor es obligatorio\n";
            }
            if (obj.RazonSocial == "")
            {
                Mensaje += "La razón social del proveedor es obligatoria\n";
            }
            if (obj.Correo == "")
            {
                Mensaje += "El correo del proveedor es obligatorio\n";
            }
            if (Mensaje != string.Empty)
            {
                return 0;
            }
            else
            {
                return objcd_proveedor.Registrar(obj, out Mensaje);
            }
        }

        public bool Editar(Proveedor obj, out string Mensaje)
        {
            Mensaje = string.Empty;
            if (obj.Documento == "")
            {
                Mensaje += "El documento del proveedor es obligatorio\n";
            }
            if (obj.RazonSocial == "")
            {
                Mensaje += "La razón social del proveedor es obligatoria\n";
            }
            if (obj.Correo == "")
            {
                Mensaje += "El correo del proveedor es obligatorio\n";
            }
            if (Mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return objcd_proveedor.Editar(obj, out Mensaje);
            }
        }


        public bool Eliminar(Proveedor obj, out string Mensaje)
        {
            return objcd_proveedor.Eliminar(obj, out Mensaje);
        }
    }

}

