using CapaEntidad;
using CapaNegocio;
using CapaPresentacion.Utilidades;
using System;
using System.Windows.Forms;

namespace CapaPresentacion.Modales
{
    public partial class mdCategoriaDetalle : Form
    {
        // null = alta de una categoría nueva; con valor = edición
        private readonly Categoria _categoriaEditar;

        // id de la categoría guardada, para seleccionarla en la lista al volver
        public int IdGuardado { get; private set; }

        public mdCategoriaDetalle() : this(null) { }

        public mdCategoriaDetalle(Categoria categoriaEditar)
        {
            InitializeComponent();
            _categoriaEditar = categoriaEditar;
        }

        private bool EsEdicion => _categoriaEditar != null;

        private void mdCategoriaDetalle_Load(object sender, EventArgs e)
        {
            cboestado.Items.Add(new OpcionCombo() { Valor = 1, Texto = "Activo" });
            cboestado.Items.Add(new OpcionCombo() { Valor = 0, Texto = "No Activo" });
            cboestado.DisplayMember = "Texto";
            cboestado.ValueMember = "Valor";
            cboestado.SelectedIndex = 0;

            if (EsEdicion)
            {
                this.Text = "Editar categoría";
                lbltitulo.Text = "Editar categoría";
                btnguardar.Text = "Guardar cambios";

                txtdescripcion.Text = _categoriaEditar.Descripcion;
                cboestado.SelectedIndex = _categoriaEditar.Estado ? 0 : 1;
            }
            else
            {
                // una categoría nueva siempre se crea activa
                lblestado.Visible = false;
                cboestado.Visible = false;
                int subir = btnguardar.Top - lblestado.Top;
                btnguardar.Top -= subir;
                btncancelar.Top -= subir;
                this.ClientSize = new System.Drawing.Size(this.ClientSize.Width, this.ClientSize.Height - subir);
            }

            txtdescripcion.Select();
        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;

            Categoria obj = new Categoria()
            {
                IdCategoria = EsEdicion ? _categoriaEditar.IdCategoria : 0,
                Descripcion = txtdescripcion.Text.Trim(),
                Estado = EsEdicion ? Convert.ToInt32(((OpcionCombo)cboestado.SelectedItem).Valor) == 1 : true
            };

            bool ok;
            if (EsEdicion)
            {
                ok = new CN_Categoria().Editar(obj, out mensaje);
                IdGuardado = obj.IdCategoria;
            }
            else
            {
                IdGuardado = new CN_Categoria().Registrar(obj, out mensaje);
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
