using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace CapaPresentacion.Utilidades
{
    // Texto gris de ayuda dentro de un TextBox (en .NET Framework no existe PlaceholderText)
    public static class TextoAyuda
    {
        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wParam, string lParam);
        private const int EM_SETCUEBANNER = 0x1501;

        public static void Poner(TextBox caja, string texto)
        {
            // wParam = 1: se sigue viendo aunque la caja tenga el foco
            SendMessage(caja.Handle, EM_SETCUEBANNER, (IntPtr)1, texto);
        }
    }
}
