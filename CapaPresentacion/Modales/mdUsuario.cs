using CapaEntidad;
using CapaNegocio;
using CapaPresentacion.Utilidades;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CapaPresentacion.Modales
{
    public partial class mdUsuario : Form
    {
        // null = alta de un usuario nuevo; con valor = edición
        private readonly Usuario _usuarioEditar;

        public mdUsuario() : this(null) { }

        public mdUsuario(Usuario usuarioEditar)
        {
            InitializeComponent();
            _usuarioEditar = usuarioEditar;
        }

        private bool EsEdicion => _usuarioEditar != null;

        private void mdUsuario_Load(object sender, EventArgs e)
        {
            List<Rol> listaRol = new CN_Rol().Listar();
            foreach (Rol item in listaRol)
            {
                cborol.Items.Add(new OpcionCombo() { Valor = item.IdRol, Texto = item.Descripcion });
            }
            cborol.DisplayMember = "Texto";
            cborol.ValueMember = "Valor";
            if (cborol.Items.Count > 0) cborol.SelectedIndex = 0;

            cboestado.Items.Add(new OpcionCombo() { Valor = 1, Texto = "Activo" });
            cboestado.Items.Add(new OpcionCombo() { Valor = 0, Texto = "No Activo" });
            cboestado.DisplayMember = "Texto";
            cboestado.ValueMember = "Valor";
            cboestado.SelectedIndex = 0;

            if (EsEdicion)
            {
                this.Text = "Editar usuario";
                lbltitulo.Text = "Editar usuario";
                btnguardar.Text = "Guardar cambios";

                txtdocumento.Text = _usuarioEditar.Documento;
                txtnombrecompleto.Text = _usuarioEditar.NombreCompleto;
                txtcorreo.Text = _usuarioEditar.Correo;
                txtclave.Text = _usuarioEditar.Clave;
                txtconfirmarclave.Text = _usuarioEditar.Clave;

                foreach (OpcionCombo oc in cborol.Items)
                {
                    if (Convert.ToInt32(oc.Valor) == _usuarioEditar.oRol.IdRol)
                    {
                        cborol.SelectedItem = oc;
                        break;
                    }
                }
                cboestado.SelectedIndex = _usuarioEditar.Estado ? 0 : 1;
            }
            else
            {
                // un usuario nuevo siempre se crea activo, no se elige el estado
                lblestado.Visible = false;
                cboestado.Visible = false;
                btnguardar.Top = cboestado.Top;
                btncancelar.Top = cboestado.Top;
                this.ClientSize = new System.Drawing.Size(this.ClientSize.Width, this.ClientSize.Height - 58);
            }

            txtdocumento.Select();
        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            if (txtclave.Text != txtconfirmarclave.Text)
            {
                MessageBox.Show("Las contraseñas no coinciden", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtconfirmarclave.Select();
                return;
            }

            string mensaje = string.Empty;

            Usuario objusuario = new Usuario()
            {
                IdUsuario = EsEdicion ? _usuarioEditar.IdUsuario : 0,
                Documento = txtdocumento.Text.Trim(),
                NombreCompleto = txtnombrecompleto.Text.Trim(),
                Correo = txtcorreo.Text.Trim(),
                Clave = txtclave.Text,
                oRol = new Rol() { IdRol = Convert.ToInt32(((OpcionCombo)cborol.SelectedItem).Valor) },
                Estado = EsEdicion ? Convert.ToInt32(((OpcionCombo)cboestado.SelectedItem).Valor) == 1 : true
            };

            bool ok;
            if (EsEdicion)
            {
                ok = new CN_Usuario().Editar(objusuario, out mensaje);
            }
            else
            {
                ok = new CN_Usuario().Registrar(objusuario, out mensaje) != 0;
            }

            if (ok)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btncancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
