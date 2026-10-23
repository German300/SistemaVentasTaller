using System;
using System.Windows.Forms;
using CapaEntidad;
using CapaNegocio;
using CapaPresentacion.Utilidades;

namespace CapaPresentacion
{
    // Primera pantalla del sistema: pide documento y clave
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();

            // en el DNI solo se pueden escribir números
            txtdocumento.KeyPress += Teclado.SoloNumeros;
        }

        // Botón Cancelar: cierra el programa
        private void btncancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Botón Ingresar: busca en la base un usuario activo con ese documento y esa clave
        private void btningresar_Click(object sender, EventArgs e)
        {
            Usuario oUsuario = new CN_Usuario().Login(txtdocumento.Text.Trim(), txtclave.Text);

            if (oUsuario != null)
            {
                // se abre el menú principal y se oculta el login
                Inicio form = new Inicio(oUsuario);
                form.Show();
                this.Hide();

                // cuando se cierra el menú principal vuelve a aparecer el login
                form.FormClosing += frm_closing;
            }
            else
            {
                MessageBox.Show("Documento, contraseña incorrectos o el usuario se encuentra inactivo.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void frm_closing(object sender, FormClosingEventArgs e)
        {
            // limpio los campos para el próximo ingreso
            txtclave.Text = "";
            txtdocumento.Text = "";

            this.Show();
        }
    }
}
