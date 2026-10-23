using System;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;

namespace CapaPresentacion
{
    internal static class Program
    {
        // Punto de entrada de la aplicación
        [STAThread]
        static void Main()
        {
            // idioma español (Argentina) para los textos del sistema
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("es-AR");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // el sistema arranca pidiendo usuario y clave
            Application.Run(new Login());
        }
    }
}
