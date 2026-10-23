using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class CD_Permiso
    {
        // Menús que puede ver el usuario según su rol (tablas PERMISO y ROL_PERMISO)
        public List<Permiso> Listar(int idUsuario)
        {
            List<Permiso> lista = new List<Permiso>();

            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    string query = @"select p.NombreMenu from Rol_Permiso rp
                                     inner join Permiso p on rp.Id_permiso = p.IdPermiso
                                     inner join USUARIO u on u.IdRol = rp.Id_rol
                                     where u.IdUsuario = @idusuario";

                    SqlCommand cmd = new SqlCommand(query, oconexion);
                    cmd.Parameters.AddWithValue("@idusuario", idUsuario);
                    cmd.CommandType = CommandType.Text;

                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Permiso()
                            {
                                NombreMenu = dr["NombreMenu"].ToString()
                            });
                        }
                    }
                }
                catch (Exception)
                {
                    // si hay un error se devuelve la lista vacía (el usuario no ve ningún menú)
                    lista = new List<Permiso>();
                }
            }

            return lista;
        }
    }
}
