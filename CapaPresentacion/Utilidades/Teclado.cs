using System.Windows.Forms;

namespace CapaPresentacion.Utilidades
{
    public static class Teclado
    {
        // Para el evento KeyPress de un TextBox: solo deja escribir números.
        // Uso: txtdocumento.KeyPress += Teclado.SoloNumeros;
        public static void SoloNumeros(object sender, KeyPressEventArgs e)
        {
            // números y teclas como Borrar se permiten; cualquier otra tecla se ignora
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
