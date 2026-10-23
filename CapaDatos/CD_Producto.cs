using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class CD_Producto
    {
        public List<Producto> Listar()
        {
            List<Producto> lista = new List<Producto>();

            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    // left join: si el producto no tiene categoría igual se lista
                    string query = @"select p.IdProducto, p.Codigo, p.Nombre, p.Descripcion,
                                            c.IdCategoria, c.Descripcion [DescripcionCategoria],
                                            p.Stock, p.PrecioCompra, p.PrecioVenta, p.Estado
                                     from PRODUCTO p
                                     left join CATEGORIA c on c.IdCategoria = p.IdCategoria";

                    SqlCommand cmd = new SqlCommand(query, oconexion);
                    cmd.CommandType = CommandType.Text;

                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            // si una columna viene vacía (NULL) se usa "" o 0
                            lista.Add(new Producto()
                            {
                                IdProducto = Convert.ToInt32(dr["IdProducto"]),
                                Codigo = dr["Codigo"] != DBNull.Value ? dr["Codigo"].ToString() : "",
                                Nombre = dr["Nombre"] != DBNull.Value ? dr["Nombre"].ToString() : "",
                                Descripcion = dr["Descripcion"] != DBNull.Value ? dr["Descripcion"].ToString() : "",
                                Stock = dr["Stock"] != DBNull.Value ? Convert.ToInt32(dr["Stock"]) : 0,
                                PrecioCompra = dr["PrecioCompra"] != DBNull.Value ? Convert.ToDecimal(dr["PrecioCompra"]) : 0,
                                PrecioVenta = dr["PrecioVenta"] != DBNull.Value ? Convert.ToDecimal(dr["PrecioVenta"]) : 0,
                                Estado = dr["Estado"] != DBNull.Value && Convert.ToBoolean(dr["Estado"]),
                                oCategoria = new Categoria()
                                {
                                    IdCategoria = dr["IdCategoria"] != DBNull.Value ? Convert.ToInt32(dr["IdCategoria"]) : 0,
                                    Descripcion = dr["DescripcionCategoria"] != DBNull.Value ? dr["DescripcionCategoria"].ToString() : ""
                                }
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    // se relanza el error para ver exactamente qué falló en la base
                    throw new Exception("Error al consultar productos: " + ex.Message);
                }
            }

            return lista;
        }

        // Devuelve el id del producto nuevo (0 si no se pudo registrar).
        // El código del producto lo genera la base de datos.
        public int Registrar(Producto obj, out string Mensaje)
        {
            int idProductoGenerado = 0;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
                {
                    SqlCommand cmd = new SqlCommand("sp_RegistrarProducto", oconexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("Nombre", obj.Nombre);
                    cmd.Parameters.AddWithValue("Descripcion", obj.Descripcion);
                    cmd.Parameters.AddWithValue("IdCategoria", obj.oCategoria.IdCategoria);
                    cmd.Parameters.AddWithValue("PrecioCompra", obj.PrecioCompra);
                    cmd.Parameters.AddWithValue("PrecioVenta", obj.PrecioVenta);
                    cmd.Parameters.AddWithValue("Stock", obj.Stock);
                    cmd.Parameters.AddWithValue("Estado", obj.Estado);

                    // lo que devuelve el SP
                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                    oconexion.Open();
                    cmd.ExecuteNonQuery();

                    idProductoGenerado = Convert.ToInt32(cmd.Parameters["Resultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                idProductoGenerado = 0;
                Mensaje = ex.Message;
            }

            return idProductoGenerado;
        }

        // El stock no se edita acá: solo cambia con compras y ventas
        public bool Editar(Producto obj, out string Mensaje)
        {
            bool respuesta = false;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
                {
                    SqlCommand cmd = new SqlCommand("sp_ModificarProducto", oconexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("IdProducto", obj.IdProducto);
                    cmd.Parameters.AddWithValue("Nombre", obj.Nombre);
                    cmd.Parameters.AddWithValue("Descripcion", obj.Descripcion);
                    cmd.Parameters.AddWithValue("IdCategoria", obj.oCategoria.IdCategoria);
                    cmd.Parameters.AddWithValue("PrecioCompra", obj.PrecioCompra);
                    cmd.Parameters.AddWithValue("PrecioVenta", obj.PrecioVenta);
                    cmd.Parameters.AddWithValue("Estado", obj.Estado);

                    // lo que devuelve el SP
                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
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

        // No borra el producto: el SP lo marca como inactivo (baja lógica)
        public bool Eliminar(Producto obj, out string Mensaje)
        {
            bool respuesta = false;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
                {
                    SqlCommand cmd = new SqlCommand("SP_EliminarProducto", oconexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("IdProducto", obj.IdProducto);

                    // lo que devuelve el SP
                    cmd.Parameters.Add("Respuesta", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                    oconexion.Open();
                    cmd.ExecuteNonQuery();

                    respuesta = Convert.ToBoolean(cmd.Parameters["Respuesta"].Value);
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
