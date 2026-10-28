using System.Drawing;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public class frmAcercaDe : Form
    {
        public frmAcercaDe()
        {
            Text = "Acerca de - Sistema de Ventas";
            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            ShowInTaskbar = false;
            ClientSize = new Size(620, 430);
            BackColor = Color.White;

            Panel encabezado = new Panel
            {
                Dock = DockStyle.Top,
                Height = 125,
                BackColor = Color.FromArgb(31, 78, 121)
            };

            encabezado.Controls.Add(new Label
            {
                Dock = DockStyle.Fill,
                Text = "SISTEMA DE VENTAS\n\nInformación del sistema",
                TextAlign = ContentAlignment.MiddleCenter,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 18F, FontStyle.Bold)
            });

            Panel contenido = new Panel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(35, 18, 35, 15),
                BackColor = Color.White
            };

            Button cerrar = new Button
            {
                Text = "Cerrar",
                Dock = DockStyle.Bottom,
                Height = 36,
                DialogResult = DialogResult.OK,
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.FromArgb(41, 128, 185),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            cerrar.FlatAppearance.BorderSize = 0;

            contenido.Controls.Add(cerrar);
            contenido.Controls.Add(CrearEtiqueta("© Todos los derechos reservados", 35, Color.Gray, true));
            contenido.Controls.Add(CrearEtiqueta("Tecnicatura Superior en Desarrollo de Software\nVersión 1.0", 55, Color.FromArgb(70, 70, 70), false));
            contenido.Controls.Add(CrearEtiqueta("Basaury Augusto                  Garnica Germán", 70, Color.FromArgb(31, 78, 121), true));
            contenido.Controls.Add(CrearEtiqueta("Desarrollado por alumnos de la Tecnicatura Superior en Desarrollo de Software", 65, Color.FromArgb(70, 70, 70), false));

            Controls.Add(contenido);
            Controls.Add(encabezado);
            AcceptButton = cerrar;
            CancelButton = cerrar;
        }

        private Label CrearEtiqueta(string texto, int alto, Color color, bool negrita)
        {
            return new Label
            {
                Dock = DockStyle.Top,
                Height = alto,
                Text = texto,
                TextAlign = ContentAlignment.MiddleCenter,
                ForeColor = color,
                Font = new Font("Segoe UI", 10.5F, negrita ? FontStyle.Bold : FontStyle.Regular)
            };
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // frmAcercaDe
            // 
            this.ClientSize = new System.Drawing.Size(947, 516);
            this.Name = "frmAcercaDe";
            this.ResumeLayout(false);

        }
    }
}
