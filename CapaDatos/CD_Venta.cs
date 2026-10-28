using CapaEntidad;
using System;
using System.Collections.Generic;
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

        public Venta ObtenerVenta(string numero)
        {
            Venta obj = new Venta();

            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    string query = @"select v.IdVenta, u.NombreCompleto, v.TipoDocumento,
                                            v.NumeroDocumento, v.DocumentoCliente,
                                            v.NombreCliente, v.MontoPago, v.MontoCambio,
                                            v.MontoTotal,
                                            convert(char(10), v.FechaRegistro, 103) [FechaRegistro]
                                     from VENTA v
                                     inner join USUARIO u on u.IdUsuario = v.IdUsuario
                                     where v.NumeroDocumento = @numero
                                        or v.DocumentoCliente = @numero
                                     order by v.IdVenta desc";

                    SqlCommand cmd = new SqlCommand(query, oconexion);
                    cmd.Parameters.AddWithValue("@numero", numero);
                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            obj = new Venta()
                            {
                                IdVenta = Convert.ToInt32(dr["IdVenta"]),
                                oUsuario = new Usuario() { NombreCompleto = dr["NombreCompleto"].ToString() },
                                TipoDocumento = dr["TipoDocumento"].ToString(),
                                NumeroDocumento = dr["NumeroDocumento"].ToString(),
                                DocumentoCliente = dr["DocumentoCliente"].ToString(),
                                NombreCliente = dr["NombreCliente"].ToString(),
                                MontoPago = Convert.ToDecimal(dr["MontoPago"]),
                                MontoCambio = Convert.ToDecimal(dr["MontoCambio"]),
                                MontoTotal = Convert.ToDecimal(dr["MontoTotal"]),
                                FechaRegistro = dr["FechaRegistro"].ToString()
                            };
                        }
                    }
                }
                catch (Exception)
                {
                    obj = new Venta();
                }
            }

            return obj;
        }

        public List<Detalle_Venta> ObtenerDetalleVenta(int idventa)
        {
            List<Detalle_Venta> lista = new List<Detalle_Venta>();

            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    string query = @"select p.Nombre, dv.PrecioVenta, dv.Cantidad, dv.Subtotal
                                     from DETALLE_VENTA dv
                                     inner join PRODUCTO p on p.IdProducto = dv.IdProducto
                                     where dv.IdVenta = @idventa";

                    SqlCommand cmd = new SqlCommand(query, oconexion);
                    cmd.Parameters.AddWithValue("@idventa", idventa);
                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Detalle_Venta()
                            {
                                oProducto = new Producto() { Nombre = dr["Nombre"].ToString() },
                                PrecioVenta = Convert.ToDecimal(dr["PrecioVenta"]),
                                Cantidad = Convert.ToInt32(dr["Cantidad"]),
                                SubTotal = Convert.ToDecimal(dr["Subtotal"])
                            });
                        }
                    }
                }
                catch (Exception)
                {
                    lista = new List<Detalle_Venta>();
                }
            }

            return lista;
        }

        // Productos vendidos entre dos fechas (se toma solo el día, sin la hora)
        public List<ReporteVenta> Reporte(DateTime fechainicio, DateTime fechafin)
        {
            List<ReporteVenta> lista = new List<ReporteVenta>();

            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    string query = @"select convert(char(10), v.FechaRegistro, 103) [FechaRegistro],
                                            v.TipoDocumento, v.NumeroDocumento, v.NombreCliente,
                                            u.NombreCompleto, p.Nombre, ca.Descripcion [Categoria],
                                            dv.PrecioVenta, dv.Cantidad, dv.Subtotal
                                     from VENTA v
                                     inner join USUARIO u on u.IdUsuario = v.IdUsuario
                                     inner join DETALLE_VENTA dv on dv.IdVenta = v.IdVenta
                                     inner join PRODUCTO p on p.IdProducto = dv.IdProducto
                                     left join CATEGORIA ca on ca.IdCategoria = p.IdCategoria
                                     where convert(date, v.FechaRegistro) between @fechainicio and @fechafin
                                     order by v.FechaRegistro";

                    SqlCommand cmd = new SqlCommand(query, oconexion);
                    cmd.Parameters.AddWithValue("@fechainicio", fechainicio.Date);
                    cmd.Parameters.AddWithValue("@fechafin", fechafin.Date);
                    cmd.CommandType = CommandType.Text;

                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new ReporteVenta()
                            {
                                FechaRegistro = dr["FechaRegistro"].ToString(),
                                TipoDocumento = dr["TipoDocumento"].ToString(),
                                NumeroDocumento = dr["NumeroDocumento"].ToString(),
                                NombreCliente = dr["NombreCliente"].ToString(),
                                NombreUsuario = dr["NombreCompleto"].ToString(),
                                NombreProducto = dr["Nombre"].ToString(),
                                Categoria = dr["Categoria"].ToString(),
                                PrecioVenta = Convert.ToDecimal(dr["PrecioVenta"]),
                                Cantidad = Convert.ToInt32(dr["Cantidad"]),
                                SubTotal = Convert.ToDecimal(dr["Subtotal"])
                            });
                        }
                    }
                }
                catch (Exception)
                {
                    lista = new List<ReporteVenta>();
                }
            }

            return lista;
        }
    }
}
