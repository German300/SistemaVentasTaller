using System.Text.RegularExpressions;

namespace CapaNegocio
{
    // Controles de formato que usan los métodos Validar() de cada clase CN_
    public static class Validacion
    {
        // true si el texto tiene solo números (0 a 9) y no está vacío
        public static bool SoloNumeros(string texto)
        {
            if (texto == "")
            {
                return false;
            }

            foreach (char c in texto)
            {
                if (!char.IsDigit(c))
                {
                    return false;
                }
            }
            return true;
        }

        // true si el texto tiene solo letras y espacios (acepta tildes y ñ)
        public static bool SoloLetras(string texto)
        {
            foreach (char c in texto)
            {
                if (!char.IsLetter(c) && c != ' ')
                {
                    return false;
                }
            }
            return true;
        }

        // true si el correo tiene la forma algo@algo.algo (sin espacios)
        public static bool CorreoValido(string correo)
        {
            return Regex.IsMatch(correo, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }
    }
}
