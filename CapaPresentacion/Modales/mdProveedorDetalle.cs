using CapaEntidad;
using CapaNegocio;
using CapaPresentacion.Utilidades;
using System;
using System.Windows.Forms;

namespace CapaPresentacion.Modales
{
    public partial class mdProveedorDetalle : Form
    {
        // null = alta de un proveedor nuevo; con valor = edición
        private readonly Proveedor _proveedorEditar;

        // id del proveedor guardado, para seleccionarlo en la lista al volver
        public int IdGuardado { get; private set; }

        public mdProveedorDetalle() : this(null) { }

        public mdProveedorDetalle(Proveedor proveedorEditar)
        {
            InitializeComponent();
            _proveedorEditar = proveedorEditar;
        }

        private bool EsEdicion => _proveedorEditar != null;

        private void mdProveedorDetalle_Load(object sender, EventArgs e)
        {
            cboestado.Items.Add(new OpcionCombo() { Valor = 1, Texto = "Activo" });
            cboestado.Items.Add(new OpcionCombo() { Valor = 0, Texto = "No Activo" });
            cboestado.DisplayMember = "Texto";
            cboestado.ValueMember = "Valor";
            cboestado.SelectedIndex = 0;

            if (EsEdicion)
            {
                this.Text = "Editar proveedor";
                lbltitulo.Text = "Editar proveedor";
                btnguardar.Text = "Guardar cambios";

                txtdocumento.Text = _proveedorEditar.Documento;
                txtnombre.Text = _proveedorEditar.RazonSocial;
                txtcorreo.Text = _proveedorEditar.Correo;
                txttelefono.Text = _proveedorEditar.Telefono;
                cboestado.SelectedIndex = _proveedorEditar.Estado ? 0 : 1;
            }
            else
            {
                // un proveedor nuevo siempre se crea activo
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

            Proveedor obj = new Proveedor()
            {
                IdProveedor = EsEdicion ? _proveedorEditar.IdProveedor : 0,
                Documento = txtdocumento.Text.Trim(),
                RazonSocial = txtnombre.Text.Trim(),
                Correo = txtcorreo.Text.Trim(),
                Telefono = txttelefono.Text.Trim(),
                Estado = EsEdicion ? Convert.ToInt32(((OpcionCombo)cboestado.SelectedItem).Valor) == 1 : true
            };

            bool ok;
            if (EsEdicion)
            {
                ok = new CN_Proveedor().Editar(obj, out mensaje);
                IdGuardado = obj.IdProveedor;
            }
            else
            {
                IdGuardado = new CN_Proveedor().Registrar(obj, out mensaje);
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
