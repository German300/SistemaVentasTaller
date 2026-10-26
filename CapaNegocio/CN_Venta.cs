using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;

namespace CapaNegocio
{
    public class CN_Venta
    {
        private CD_Venta objcd_venta = new CD_Venta();

        public int ObtenerCorrelativo()
        {
            return objcd_venta.ObtenerCorrelativo();
        }

        public bool Registrar(Venta obj, DataTable DetalleVenta, out string Mensaje)
        {
            return objcd_venta.Registrar(obj, DetalleVenta, out Mensaje);
        }

        public List<ReporteVenta> Reporte(DateTime fechainicio, DateTime fechafin)
        {
            return objcd_venta.Reporte(fechainicio, fechafin);
        }
    }
}
