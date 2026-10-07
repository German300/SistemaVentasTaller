using CapaEntidad;
using System;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class CD_Venta
    {
        // Número para la próxima venta: cantidad de ventas + 1
        public int ObtenerCorrelativo()
        {
            int idcorrelativo = 0;

            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("select count(*) + 1 from VENTA", oconexion);
                    cmd.CommandType = CommandType.Text;

                    oconexion.Open();
                    idcorrelativo = Convert.ToInt32(cmd.ExecuteScalar());
                }
                catch (Exception)
                {
                    idcorrelativo = 0;
                }
            }

            return idcorrelativo;
        }

        // Guarda la venta llamando al SP usp_RegistrarVenta.
        // El SP hace todo dentro de una transacción: controla el stock, inserta la venta,
        // inserta el detalle y descuenta el stock. Si algo falla, no se guarda nada.
        public bool Registrar(Venta obj, DataTable DetalleVenta, out string Mensaje)
        {
            bool respuesta = false;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
                {
                    SqlCommand cmd = new SqlCommand("usp_RegistrarVenta", oconexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // datos de la venta (cabecera)
                    cmd.Parameters.AddWithValue("IdUsuario", obj.oUsuario.IdUsuario);
                    cmd.Parameters.AddWithValue("TipoDocumento", obj.TipoDocumento);
                    cmd.Parameters.AddWithValue("NumeroDocumento", obj.NumeroDocumento);
                    cmd.Parameters.AddWithValue("DocumentoCliente", obj.DocumentoCliente);
                    cmd.Parameters.AddWithValue("NombreCliente", obj.NombreCliente);
                    cmd.Parameters.AddWithValue("MontoPago", obj.MontoPago);
                    cmd.Parameters.AddWithValue("MontoCambio", obj.MontoCambio);
                    cmd.Parameters.AddWithValue("MontoTotal", obj.MontoTotal);

                    // los productos vendidos viajan todos juntos como una tabla
                    // (tipo EDetalle_Venta creado en SQL Server)
                    SqlParameter paramDetalle = cmd.Parameters.AddWithValue("DetalleVenta", DetalleVenta);
                    paramDetalle.SqlDbType = SqlDbType.Structured;
                    paramDetalle.TypeName = "EDetalle_Venta";

                    // lo que devuelve el SP
                    cmd.Parameters.Add("Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                    oconexion.Open();
                    cmd.ExecuteNonQuery();

                    respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                respuesta = false;
                Mensaje = ex.Message;
            }

            return respuesta;
        }
    }
}
