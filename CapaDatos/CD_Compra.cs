using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class CD_Compra
    {
        // Número para la próxima compra: cantidad de compras + 1
        public int ObtenerCorrelativo()
        {
            int idcorrelativo = 0;

            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("select count(*) + 1 from COMPRA", oconexion);
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

        // Guarda la compra llamando al SP SP_RegistrarCompra.
        // El detalle (los productos comprados) viaja todo junto como una tabla.
        public bool Registrar(Compra obj, DataTable DetalleCompra, out string Mensaje)
        {
            bool respuesta = false;
            Mensaje = string.Empty;

            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_RegistrarCompra", oconexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // datos de la compra (cabecera)
                    cmd.Parameters.AddWithValue("IdUsuario", obj.oUsuario.IdUsuario);
                    cmd.Parameters.AddWithValue("IdProveedor", obj.oProveedor.IdProveedor);
                    cmd.Parameters.AddWithValue("TipoDocumento", obj.TipoDocumento);
                    cmd.Parameters.AddWithValue("NumeroDocumento", obj.NumeroDocumento);
                    cmd.Parameters.AddWithValue("MontoTotal", obj.MontoTotal);
                    cmd.Parameters.AddWithValue("DetalleCompra", DetalleCompra);

                    // lo que devuelve el SP
                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                    oconexion.Open();
                    cmd.ExecuteNonQuery();

                    respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }
                catch (Exception ex)
                {
                    respuesta = false;
                    Mensaje = ex.Message;
                }
            }

            return respuesta;
        }

        // Busca una compra por su número. Si no existe devuelve una compra con IdCompra = 0.
        public Compra ObtenerCompra(string numero)
        {
            Compra obj = new Compra();

            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    string query = @"select c.IdCompra, u.NombreCompleto, pr.Documento, pr.RazonSocial,
                                            c.TipoDocumento, c.NumeroDocumento, c.MontoTotal,
                                            convert(char(10), c.FechaRegistro, 103) [FechaRegistro]
                                     from COMPRA c
                                     inner join USUARIO u on u.IdUsuario = c.IdUsuario
                                     inner join PROVEEDOR pr on pr.IdProveedor = c.IdProveedor
                                     where c.NumeroDocumento = @numero";

                    SqlCommand cmd = new SqlCommand(query, oconexion);
                    cmd.Parameters.AddWithValue("@numero", numero);
                    cmd.CommandType = CommandType.Text;

                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            obj = new Compra()
                            {
                                IdCompra = Convert.ToInt32(dr["IdCompra"]),
                                oUsuario = new Usuario() { NombreCompleto = dr["NombreCompleto"].ToString() },
                                oProveedor = new Proveedor() { Documento = dr["Documento"].ToString(), RazonSocial = dr["RazonSocial"].ToString() },
                                TipoDocumento = dr["TipoDocumento"].ToString(),
                                NumeroDocumento = dr["NumeroDocumento"].ToString(),
                                MontoTotal = Convert.ToDecimal(dr["MontoTotal"]),
                                FechaRegistro = dr["FechaRegistro"].ToString()
                            };
                        }
                    }
                }
                catch (Exception)
                {
                    obj = new Compra();
                }
            }

            return obj;
        }

        // Productos de una compra
        public List<Detalle_Compra> ObtenerDetalleCompra(int idcompra)
        {
            List<Detalle_Compra> lista = new List<Detalle_Compra>();

            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    string query = @"select p.Nombre, dc.PrecioCompra, dc.Cantidad, dc.MontoTotal
                                     from DETALLE_COMPRA dc
                                     inner join PRODUCTO p on p.IdProducto = dc.IdProducto
                                     where dc.IdCompra = @idcompra";

                    SqlCommand cmd = new SqlCommand(query, oconexion);
                    cmd.Parameters.AddWithValue("@idcompra", idcompra);
                    cmd.CommandType = CommandType.Text;

                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Detalle_Compra()
                            {
                                oProducto = new Producto() { Nombre = dr["Nombre"].ToString() },
                                PrecioCompra = Convert.ToDecimal(dr["PrecioCompra"]),
                                Cantidad = Convert.ToInt32(dr["Cantidad"]),
                                MontoTotal = Convert.ToDecimal(dr["MontoTotal"])
                            });
                        }
                    }
                }
                catch (Exception)
                {
                    lista = new List<Detalle_Compra>();
                }
            }

            return lista;
        }

        // Productos comprados entre dos fechas (se toma solo el día, sin la hora)
        public List<ReporteCompra> Reporte(DateTime fechainicio, DateTime fechafin)
        {
            List<ReporteCompra> lista = new List<ReporteCompra>();

            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    string query = @"select convert(char(10), c.FechaRegistro, 103) [FechaRegistro],
                                            c.TipoDocumento, c.NumeroDocumento, pr.RazonSocial,
                                            u.NombreCompleto, p.Nombre, ca.Descripcion [Categoria],
                                            dc.PrecioCompra, dc.Cantidad, dc.MontoTotal
                                     from COMPRA c
                                     inner join USUARIO u on u.IdUsuario = c.IdUsuario
                                     inner join PROVEEDOR pr on pr.IdProveedor = c.IdProveedor
                                     inner join DETALLE_COMPRA dc on dc.IdCompra = c.IdCompra
                                     inner join PRODUCTO p on p.IdProducto = dc.IdProducto
                                     left join CATEGORIA ca on ca.IdCategoria = p.IdCategoria
                                     where convert(date, c.FechaRegistro) between @fechainicio and @fechafin
                                     order by c.FechaRegistro";

                    SqlCommand cmd = new SqlCommand(query, oconexion);
                    cmd.Parameters.AddWithValue("@fechainicio", fechainicio.Date);
                    cmd.Parameters.AddWithValue("@fechafin", fechafin.Date);
                    cmd.CommandType = CommandType.Text;

                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new ReporteCompra()
                            {
                                FechaRegistro = dr["FechaRegistro"].ToString(),
                                TipoDocumento = dr["TipoDocumento"].ToString(),
                                NumeroDocumento = dr["NumeroDocumento"].ToString(),
                                RazonSocial = dr["RazonSocial"].ToString(),
                                NombreUsuario = dr["NombreCompleto"].ToString(),
                                NombreProducto = dr["Nombre"].ToString(),
                                Categoria = dr["Categoria"].ToString(),
                                PrecioCompra = Convert.ToDecimal(dr["PrecioCompra"]),
                                Cantidad = Convert.ToInt32(dr["Cantidad"]),
                                SubTotal = Convert.ToDecimal(dr["MontoTotal"])
                            });
                        }
                    }
                }
                catch (Exception)
                {
                    lista = new List<ReporteCompra>();
                }
            }

            return lista;
        }
    }
}
