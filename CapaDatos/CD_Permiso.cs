using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using CapaEntidad;

namespace CapaDatos
{
    public class CD_Permiso
    {
        public List<Permiso> Listar(int idUsuario)
        {
            List<Permiso> lista = new List<Permiso>();

            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    // Consulta corregida para usar tus nombres exactos con guion bajo (Id_rol, Id_permiso)
                    string query = @"
                        SELECT p.NombreMenu FROM Rol_Permiso rp
                        INNER JOIN Permiso p ON rp.Id_permiso = p.IdPermiso
                        INNER JOIN USUARIO u ON u.IdRol = rp.Id_rol
                        WHERE u.IdUsuario = @idusuario";

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
                catch (Exception ex)
                {
                    // Si hay un error, devolvemos la lista vacía para que no rompa la app
                    lista = new List<Permiso>();
                }
            }
            return lista;
        }
    }
}