using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace CapaDatos
{
    public class CD_Venta
    {
        public int ObtenerCorrelativo()
        {
            int idcorrelativo = 0;

            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("select count(*) + 1 from VENTA");
                    SqlCommand cmd = new SqlCommand(query.ToString(), oconexion);
                    cmd.CommandType = CommandType.Text;

                    oconexion.Open();
                    idcorrelativo = Convert.ToInt32(cmd.ExecuteScalar());
                }
                catch (Exception ex)
                {
                    idcorrelativo = 0;
                }
            }

            return idcorrelativo;
        }

        public bool RestarStock(int idproducto, int cantidad)
        {
            bool respuesta = true;
            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("update PRODUCTO set Stock = Stock - @cantidad where IdProducto = @idproducto");
                    SqlCommand cmd = new SqlCommand(query.ToString(), oconexion);
                    cmd.Parameters.AddWithValue("@cantidad", cantidad);
                    cmd.Parameters.AddWithValue("@idproducto", idproducto);
                    cmd.CommandType = CommandType.Text;

                    oconexion.Open();
                    respuesta = cmd.ExecuteNonQuery() > 0;
                }
                catch (Exception ex)
                {
                    respuesta = false;
                }
            }
            return respuesta;
        }

        public bool SumarStock(int idproducto, int cantidad)
        {
            bool respuesta = true;
            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("update PRODUCTO set Stock = Stock + @cantidad where IdProducto = @idproducto");
                    SqlCommand cmd = new SqlCommand(query.ToString(), oconexion);
                    cmd.Parameters.AddWithValue("@cantidad", cantidad);
                    cmd.Parameters.AddWithValue("@idproducto", idproducto);
                    cmd.CommandType = CommandType.Text;

                    oconexion.Open();
                    respuesta = cmd.ExecuteNonQuery() > 0;
                }
                catch (Exception ex)
                {
                    respuesta = false;
                }
            }
            return respuesta;
        }

        public bool Registrar(Venta obj, DataTable DetalleVenta, out string Mensaje)
        {
            bool Respuesta = false;
            Mensaje = string.Empty;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
                {
                    oconexion.Open();
                    SqlTransaction transaccion = oconexion.BeginTransaction();

                    // Stock de cada producto antes de registrar la venta
                    Dictionary<int, int> stockAntes = new Dictionary<int, int>();
                    foreach (DataRow fila in DetalleVenta.Rows)
                    {
                        int idproducto = Convert.ToInt32(fila["IdProducto"]);
                        stockAntes[idproducto] = ObtenerStock(idproducto, oconexion, transaccion);
                    }

                    SqlCommand cmd = new SqlCommand("usp_RegistrarVenta", oconexion, transaccion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("IdUsuario", obj.oUsuario.IdUsuario);
                    cmd.Parameters.AddWithValue("TipoDocumento", obj.TipoDocumento);
                    cmd.Parameters.AddWithValue("NumeroDocumento", obj.NumeroDocumento);
                    cmd.Parameters.AddWithValue("DocumentoCliente", obj.DocumentoCliente);
                    cmd.Parameters.AddWithValue("NombreCliente", obj.NombreCliente);
                    cmd.Parameters.AddWithValue("MontoPago", obj.MontoPago);
                    cmd.Parameters.AddWithValue("MontoCambio", obj.MontoCambio);
                    cmd.Parameters.AddWithValue("MontoTotal", obj.MontoTotal);

                    // DEFINICIÓN CORRECTA PARA PARÁMETRO DE TIPO TABLA (UDTT):
                    SqlParameter paramDetalle = cmd.Parameters.AddWithValue("DetalleVenta", DetalleVenta);
                    paramDetalle.SqlDbType = SqlDbType.Structured;
                    paramDetalle.TypeName = "EDetalle_Venta"; // Nombre exacto del TYPE en SQL Server

                    cmd.Parameters.Add("Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                    try
                    {
                        cmd.ExecuteNonQuery();

                        Respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                        Mensaje = cmd.Parameters["Mensaje"].Value.ToString();

                        if (Respuesta)
                        {
                            // Descontar el stock vendido. Si el SP ya lo descontó, no se vuelve a restar.
                            foreach (DataRow fila in DetalleVenta.Rows)
                            {
                                int idproducto = Convert.ToInt32(fila["IdProducto"]);
                                int cantidad = Convert.ToInt32(fila["Cantidad"]);

                                if (ObtenerStock(idproducto, oconexion, transaccion) == stockAntes[idproducto])
                                {
                                    SqlCommand cmdStock = new SqlCommand("update PRODUCTO set Stock = isnull(Stock, 0) - @cantidad where IdProducto = @idproducto", oconexion, transaccion);
                                    cmdStock.Parameters.AddWithValue("@cantidad", cantidad);
                                    cmdStock.Parameters.AddWithValue("@idproducto", idproducto);
                                    cmdStock.ExecuteNonQuery();
                                }
                            }
                            transaccion.Commit();
                        }
                        else
                        {
                            DeshacerTransaccion(transaccion);
                        }
                    }
                    catch
                    {
                        DeshacerTransaccion(transaccion);
                        throw;
                    }
                }
            }
            catch (Exception ex)
            {
                Respuesta = false;
                Mensaje = ex.Message;
            }

            return Respuesta;
        }

        private int ObtenerStock(int idproducto, SqlConnection oconexion, SqlTransaction transaccion)
        {
            SqlCommand cmd = new SqlCommand("select Stock from PRODUCTO where IdProducto = @idproducto", oconexion, transaccion);
            cmd.Parameters.AddWithValue("@idproducto", idproducto);
            object resultado = cmd.ExecuteScalar();
            return resultado != null && resultado != DBNull.Value ? Convert.ToInt32(resultado) : 0;
        }

        private void DeshacerTransaccion(SqlTransaction transaccion)
        {
            // Si el SP ya hizo ROLLBACK, la transacción ya no es válida
            try { transaccion.Rollback(); } catch { }
        }
    }
}