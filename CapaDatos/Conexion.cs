using System.Configuration;

namespace CapaDatos
{
    // La cadena de conexión se lee del archivo App.config (nombre "cadena_conexion")
    public class Conexion
    {
        public static string cadena = ConfigurationManager.ConnectionStrings["cadena_conexion"].ToString();
    }
}
