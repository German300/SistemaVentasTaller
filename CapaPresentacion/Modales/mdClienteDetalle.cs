using CapaEntidad;
using CapaNegocio;
using CapaPresentacion.Utilidades;
using System;
using System.Windows.Forms;

namespace CapaPresentacion.Modales
{
    public partial class mdClienteDetalle : Form
    {
        // null = alta de un cliente nuevo; con valor = edición
        private readonly Cliente _clienteEditar;

        // id del cliente guardado, para seleccionarlo en la lista al volver
        public int IdGuardado { get; private set; }

        public mdClienteDetalle() : this(null) { }

        public mdClienteDetalle(Cliente clienteEditar)
        {
            InitializeComponent();
            _clienteEditar = clienteEditar;
        }

        private bool EsEdicion => _clienteEditar != null;

        private void mdClienteDetalle_Load(object sender, EventArgs e)
        {
            cboestado.Items.Add(new OpcionCombo() { Valor = 1, Texto = "Activo" });
            cboestado.Items.Add(new OpcionCombo() { Valor = 0, Texto = "No Activo" });
            cboestado.DisplayMember = "Texto";
            cboestado.ValueMember = "Valor";
            cboestado.SelectedIndex = 0;

            if (EsEdicion)
            {
                this.Text = "Editar cliente";
                lbltitulo.Text = "Editar cliente";
                btnguardar.Text = "Guardar cambios";

                txtdocumento.Text = _clienteEditar.Documento;
                txtnombre.Text = _clienteEditar.NombreCompleto;
                txtcorreo.Text = _clienteEditar.Correo;
                txttelefono.Text = _clienteEditar.Telefono;
                cboestado.SelectedIndex = _clienteEditar.Estado ? 0 : 1;
            }
            else
            {
                // un cliente nuevo siempre se crea activo
                lblestado.Visible = false;
                cboestado.Visible = false;
                int subir = btnguardar.Top - lblestado.Top;
                btnguardar.Top -= subir;
                btncancelar.Top -= subir;
                this.ClientSize = new System.Drawing.Size(this.ClientSize.Width, this.ClientSize.Height - subir);
            }

            txtdocumento.Select();
        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;

            Cliente obj = new Cliente()
            {
                IdCliente = EsEdicion ? _clienteEditar.IdCliente : 0,
                Documento = txtdocumento.Text.Trim(),
                NombreCompleto = txtnombre.Text.Trim(),
                Correo = txtcorreo.Text.Trim(),
                Telefono = txttelefono.Text.Trim(),
                Estado = EsEdicion ? Convert.ToInt32(((OpcionCombo)cboestado.SelectedItem).Valor) == 1 : true
            };

            bool ok;
            if (EsEdicion)
            {
                ok = new CN_Cliente().Editar(obj, out mensaje);
                IdGuardado = obj.IdCliente;
            }
            else
            {
                IdGuardado = new CN_Cliente().Registrar(obj, out mensaje);
                ok = IdGuardado != 0;
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
