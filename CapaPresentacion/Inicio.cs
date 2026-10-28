using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CapaEntidad;
using CapaNegocio;
using FontAwesome.Sharp;

namespace CapaPresentacion
{
    // Menú principal: arriba el menú, abajo el panel "contenedor" donde se abre cada pantalla
    public partial class Inicio : Form
    {
        private static Usuario usuarioActual;
        private static IconMenuItem MenuActivo = null;
        private static Form FormularioActivo = null;
        public Inicio(Usuario objusuario = null)
        {
            if (objusuario == null)
                usuarioActual = new Usuario() { NombreCompleto = "ADMIN PREDEFINIDO", IdUsuario = 1 };
            else
                usuarioActual = objusuario;
            InitializeComponent();
        }

        private void Inicio_Load(object sender, EventArgs e)
        {
            // menús que el rol del usuario tiene permitidos (tablas PERMISO y ROL_PERMISO)
            List<Permiso> ListaPermisos = new CN_Permiso().Listar(usuarioActual.IdUsuario);

            // se muestra cada menú solo si su Name está en la lista de permisos
            foreach (IconMenuItem iconMenu in menu.Items)
            {
                bool encontrado = ListaPermisos.Any(m => m.NombreMenu.Trim().ToLower() == iconMenu.Name.Trim().ToLower());
                iconMenu.Visible = encontrado;
            }

            // La información del sistema está disponible para todos los usuarios.
            menuacercade.Visible = true;

            lblusuario.Text = usuarioActual.NombreCompleto;
        }

        // Abre una pantalla dentro del panel "contenedor" y marca su menú como seleccionado
        private void AbrirFormulario(IconMenuItem menu, Form formulario)
        {
            // el menú elegido queda gris; el anterior vuelve a blanco
            if (MenuActivo != null)
            {
                MenuActivo.BackColor = Color.White;
            }
            menu.BackColor = Color.Silver;
            MenuActivo = menu;

            // se cierra la pantalla que estaba abierta
            if (FormularioActivo != null)
            {
                FormularioActivo.Close();
            }

            // la nueva pantalla se mete adentro del panel, sin borde y ocupando todo
            FormularioActivo = formulario;
            formulario.TopLevel = false;
            formulario.FormBorderStyle = FormBorderStyle.None;
            formulario.Dock = DockStyle.Fill;
            formulario.BackColor = Color.SteelBlue;

            contenedor.Controls.Add(formulario);
            formulario.Show();
        }

        // ---- Un método por cada opción del menú ----

        private void menuusuarios_Click(object sender, EventArgs e)
        {
            AbrirFormulario((IconMenuItem)sender, new frmUsuarios(usuarioActual.IdUsuario));
        }

        private void submenucategoria_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menumantenimiento, new FrmCategoria());
        }

        private void submenuproducto_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menumantenimiento, new frmProducto());
        }

        private void submenunegocio_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menumantenimiento, new frmNegocio());
        }

        private void submenuregistrarventa_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menuventas, new frmVentas(usuarioActual));
        }

        private void submenuverdetalleventa_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menuventas, new frmDetalleVenta());
        }

        private void submenuregistrarcompra_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menucompras, new frmCompras(usuarioActual));
        }

        private void submenuverdetallecompra_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menucompras, new frmDetalleCompra());
        }

        private void menuclientes_Click(object sender, EventArgs e)
        {
            AbrirFormulario((IconMenuItem)sender, new frmClientes());
        }

        private void menuproveedores_Click(object sender, EventArgs e)
        {
            AbrirFormulario((IconMenuItem)sender, new frmProveedores());
        }

        private void menureportes_Click(object sender, EventArgs e)
        {
            AbrirFormulario((IconMenuItem)sender, new frmReportes());
        }

        private void menuacercade_Click(object sender, EventArgs e)
        {
            using (frmAcercaDe formulario = new frmAcercaDe())
            {
                formulario.ShowDialog(this);
            }
        }
    }

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
    }
}
