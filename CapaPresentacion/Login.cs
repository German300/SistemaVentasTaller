using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaEntidad;
using CapaNegocio;

namespace CapaPresentacion
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btncancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btningresar_Click(object sender, EventArgs e)
        {
            
            Usuario oUsuario = new CN_Usuario().Listar()
                .Where(u => u.Documento == txtdocumento.Text && u.Clave == txtclave.Text && u.Estado == true)
                .FirstOrDefault();

            // Si el usuario es diferente de null, es decir, si se encontró y está activo, muestro el formulario de inicio
            if (oUsuario != null)
            {
                // muestro y oculto el formulario de login
                Inicio form = new Inicio(oUsuario);
                form.Show();
                this.Hide();

                // evento para mostrar el formulario de login cuando cierro el formulario de inicio
                form.FormClosing += frm_closing;
            }
            else
            {
               
                MessageBox.Show("Documento, contraseña incorrectos o el usuario se encuentra inactivo.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void frm_closing(object sender, FormClosingEventArgs e)
        {
            //limpio los campos de texto del formulario de login
            txtclave.Text = "";
            txtdocumento.Text = "";

            this.Show();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            
        }
    }
}

