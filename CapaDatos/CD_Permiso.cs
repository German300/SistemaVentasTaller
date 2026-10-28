using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class CD_Permiso
    {
        // Menús que puede ver el usuario según su rol
        public List<Permiso> Listar(int idUsuario)
        {
            List<Permiso> lista = new List<Permiso>();

            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    // Consulta corregida basada en tu estructura real de la base de datos
                    string query = @"select p.NombreMenu 
                                     from Permiso p
                                     inner join USUARIO u on u.IdRol = p.IdRol
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
                    lista = new List<Permiso>();
                }
            }

            return lista;
        }
    }
}