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
            MostrarBienvenida();
        }

        private void MostrarBienvenida()
        {
            Panel bienvenida = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.FromArgb(245, 248, 251),
                Padding = new Padding(55)
            };

            Label titulo = new Label
            {
                Dock = DockStyle.Top,
                Height = 75,
                Text = "Bienvenido al Sistema de Ventas",
                TextAlign = ContentAlignment.MiddleCenter,
                ForeColor = Color.FromArgb(31, 78, 121),
                Font = new Font("Segoe UI", 24F, FontStyle.Bold)
            };

            Label descripcion = new Label
            {
                Dock = DockStyle.Top,
                Height = 55,
                Text = "Administra tus compras y ventas\n\nde forma rápida y sencilla.",
                TextAlign = ContentAlignment.MiddleCenter,
                ForeColor = Color.FromArgb(90, 90, 90),
                Font = new Font("Segoe UI", 11F)
            };

            Label pie = new Label
            {
                Dock = DockStyle.Bottom,
                Height = 35,
                Text = "Administra tus compras y ventas de forma rápida y sencilla.",
                TextAlign = ContentAlignment.MiddleCenter,
                ForeColor = Color.Gray,
                Font = new Font("Segoe UI", 9.5F, FontStyle.Italic)
            };

            bienvenida.Controls.Add(pie);
            bienvenida.Controls.Add(descripcion);
            bienvenida.Controls.Add(titulo);
            contenedor.Controls.Add(bienvenida);
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
            formulario.BringToFront();
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
}
