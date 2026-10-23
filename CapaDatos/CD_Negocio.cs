using CapaEntidad;
using System;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    // La tabla NEGOCIO tiene una sola fila (IdNegocio = 1) con los datos del negocio
    public class CD_Negocio
    {
        public Negocio ObtenerDatos()
        {
            Negocio obj = new Negocio();

            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    string query = "select IdNegocio, Nombre, RUC, Direccion from NEGOCIO where IdNegocio = 1";

                    SqlCommand cmd = new SqlCommand(query, oconexion);
                    cmd.CommandType = CommandType.Text;

                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            obj.IdNegocio = Convert.ToInt32(dr["IdNegocio"]);
                            obj.Nombre = dr["Nombre"].ToString();
                            obj.RUC = dr["RUC"].ToString();
                            obj.Direccion = dr["Direccion"].ToString();
                        }
                    }
                }
                catch (Exception)
                {
                    obj = new Negocio();
                }
            }

            return obj;
        }

        public bool GuardarDatos(Negocio obj, out string Mensaje)
        {
            bool respuesta = true;
            Mensaje = string.Empty;

            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    string query = "update NEGOCIO set Nombre = @nombre, RUC = @ruc, Direccion = @direccion where IdNegocio = 1";

                    SqlCommand cmd = new SqlCommand(query, oconexion);
                    cmd.Parameters.AddWithValue("@nombre", obj.Nombre);
                    cmd.Parameters.AddWithValue("@ruc", obj.RUC);
                    cmd.Parameters.AddWithValue("@direccion", obj.Direccion);
                    cmd.CommandType = CommandType.Text;

                    oconexion.Open();

                    if (cmd.ExecuteNonQuery() < 1)
                    {
                        respuesta = false;
                        Mensaje = "No se pudo guardar los datos del negocio";
                    }
                }
                catch (Exception ex)
                {
                    respuesta = false;
                    Mensaje = ex.Message;
                }
            }

            return respuesta;
        }

        // Devuelve la imagen del logo en bytes.
        // "obtenido" queda en false si hubo un error o si todavía no se cargó ningún logo.
        public byte[] ObtenerLogo(out bool obtenido)
        {
            obtenido = false;
            byte[] logoBytes = new byte[0];

            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    string query = "select Logo from NEGOCIO where IdNegocio = 1";

                    SqlCommand cmd = new SqlCommand(query, oconexion);
                    cmd.CommandType = CommandType.Text;

                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read() && dr["Logo"] != DBNull.Value)
                        {
                            logoBytes = (byte[])dr["Logo"];
                            obtenido = true;
                        }
                    }
                }
                catch (Exception)
                {
                    obtenido = false;
                    logoBytes = new byte[0];
                }
            }

            return logoBytes;
        }

        public bool ActualizarLogo(byte[] imagen, out string Mensaje)
        {
            bool respuesta = true;
            Mensaje = string.Empty;

            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    string query = "update NEGOCIO set Logo = @imagen where IdNegocio = 1";

                    SqlCommand cmd = new SqlCommand(query, oconexion);
                    cmd.Parameters.AddWithValue("@imagen", imagen);
                    cmd.CommandType = CommandType.Text;

                    oconexion.Open();

                    if (cmd.ExecuteNonQuery() < 1)
                    {
                        respuesta = false;
                        Mensaje = "No se pudo actualizar el logo";
                    }
                }
                catch (Exception ex)
                {
                    respuesta = false;
                    Mensaje = ex.Message;
                }
            }

            return respuesta;
        }
    }
}
