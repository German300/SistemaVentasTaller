using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using CapaPresentacion.Utilidades;
using CapaPresentacion.Modales;
using CapaNegocio;
using CapaEntidad;

namespace CapaPresentacion
{
    public partial class frmUsuarios : Form
    {
        // el usuario logueado no puede darse de baja a sí mismo
        private readonly int _idUsuarioActual;

        public frmUsuarios(int idUsuarioActual = 0)
        {
            InitializeComponent();
            _idUsuarioActual = idUsuarioActual;
        }

        private void frmUsuarios_Load(object sender, EventArgs e)
        {
            TextoAyuda.Poner(txtbusqueda, "Buscar por nombre, apellido, DNI o correo");

            cborolfiltro.Items.Add(new OpcionCombo() { Valor = 0, Texto = "Todos" });
            foreach (Rol item in new CN_Rol().Listar())
            {
                cborolfiltro.Items.Add(new OpcionCombo() { Valor = item.IdRol, Texto = item.Descripcion });
            }
            cborolfiltro.DisplayMember = "Texto";
            cborolfiltro.ValueMember = "Valor";
            cborolfiltro.SelectedIndex = 0;

            cboestadofiltro.Items.Add(new OpcionCombo() { Valor = -1, Texto = "Todos" });
            cboestadofiltro.Items.Add(new OpcionCombo() { Valor = 1, Texto = "Activo" });
            cboestadofiltro.Items.Add(new OpcionCombo() { Valor = 0, Texto = "No Activo" });
            cboestadofiltro.DisplayMember = "Texto";
            cboestadofiltro.ValueMember = "Valor";
            cboestadofiltro.SelectedIndex = 0;

            CargarUsuarios();
        }

        // filtra la grilla al cambiar cualquiera de los filtros
        private void Filtros_Changed(object sender, EventArgs e)
        {
            AplicarFiltros();
        }

        private void AplicarFiltros()
        {
            // los combos se llenan en el Load; antes de eso no hay nada que filtrar
            if (cborolfiltro.SelectedItem == null || cboestadofiltro.SelectedItem == null)
                return;

            int idRol = Convert.ToInt32(((OpcionCombo)cborolfiltro.SelectedItem).Valor);
            int estado = Convert.ToInt32(((OpcionCombo)cboestadofiltro.SelectedItem).Valor);
            string texto = txtbusqueda.Text.Trim().ToUpper();

            // no se puede ocultar la fila que tiene la celda actual
            dgvdata.CurrentCell = null;

            foreach (DataGridViewRow row in dgvdata.Rows)
            {
                bool coincideRol = idRol == 0 || Convert.ToInt32(row.Cells["IdRol"].Value) == idRol;
                bool coincideEstado = estado == -1 || Convert.ToInt32(row.Cells["EstadoValor"].Value) == estado;
                bool coincideTexto = texto == ""
                    || row.Cells["NombreCompleto"].Value.ToString().ToUpper().Contains(texto)
                    || row.Cells["Documento"].Value.ToString().ToUpper().Contains(texto)
                    || row.Cells["Correo"].Value.ToString().ToUpper().Contains(texto);

                row.Visible = coincideRol && coincideEstado && coincideTexto;
            }

            dgvdata.ClearSelection();
            ActualizarBotonBaja();
        }

        private void btnlimpiarbuscador_Click(object sender, EventArgs e)
        {
            txtbusqueda.Text = "";
            cborolfiltro.SelectedIndex = 0;
            cboestadofiltro.SelectedIndex = 0;
        }

        // MOSTRAR TODOS LOS USUARIOS
        private void CargarUsuarios()
        {
            dgvdata.Rows.Clear();

            List<Usuario> listaUsuario = new CN_Usuario().Listar();

            foreach (Usuario item in listaUsuario)
            {
                dgvdata.Rows.Add(new object[] {
                    "",
                    item.IdUsuario,
                    item.Documento,
                    item.NombreCompleto,
                    item.Correo,
                    item.Clave,
                    item.oRol.IdRol,
                    item.oRol.Descripcion,
                    item.Estado == true ? 1 : 0,
                    item.Estado == true ? "Activo" : "No Activo"
                });
            }

            AplicarFiltros();
        }

        private void btnagregar_Click(object sender, EventArgs e)
        {
            using (mdUsuario modal = new mdUsuario())
            {
                if (modal.ShowDialog(this) == DialogResult.OK)
                {
                    CargarUsuarios();
                }
            }
        }

        // el check de cada fila abre la ventana en modo edición
        private void dgvdata_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || dgvdata.Columns[e.ColumnIndex].Name != "btnseleccionar")
                return;

            DataGridViewRow row = dgvdata.Rows[e.RowIndex];

            Usuario usuario = new Usuario()
            {
                IdUsuario = Convert.ToInt32(row.Cells["Id"].Value),
                Documento = row.Cells["Documento"].Value.ToString(),
                NombreCompleto = row.Cells["NombreCompleto"].Value.ToString(),
                Correo = row.Cells["Correo"].Value.ToString(),
                Clave = row.Cells["Clave"].Value.ToString(),
                oRol = new Rol() { IdRol = Convert.ToInt32(row.Cells["IdRol"].Value) },
                Estado = Convert.ToInt32(row.Cells["EstadoValor"].Value) == 1
            };

            using (mdUsuario modal = new mdUsuario(usuario))
            {
                if (modal.ShowDialog(this) == DialogResult.OK)
                {
                    CargarUsuarios();
                }
            }
        }

        private void dgvdata_SelectionChanged(object sender, EventArgs e)
        {
            ActualizarBotonBaja();
        }

        // solo se puede dar de baja un usuario seleccionado, activo y que no sea el logueado
        private void ActualizarBotonBaja()
        {
            bool habilitar = false;

            if (dgvdata.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvdata.SelectedRows[0];
                habilitar = Convert.ToInt32(row.Cells["EstadoValor"].Value) == 1
                    && Convert.ToInt32(row.Cells["Id"].Value) != _idUsuarioActual;
            }

            btnbaja.Enabled = habilitar;
            btnbaja.BackColor = habilitar ? Color.Firebrick : Color.FromArgb(220, 220, 220);
        }

        private void btnbaja_Click(object sender, EventArgs e)
        {
            if (dgvdata.SelectedRows.Count == 0)
                return;

            DataGridViewRow row = dgvdata.SelectedRows[0];

            string pregunta = "¿Desea dar de baja al usuario " + row.Cells["NombreCompleto"].Value + "?";
            if (MessageBox.Show(pregunta, "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            string mensaje = string.Empty;
            Usuario objusuario = new Usuario()
            {
                IdUsuario = Convert.ToInt32(row.Cells["Id"].Value)
            };

            bool respuesta = new CN_Usuario().Eliminar(objusuario, out mensaje);

            if (respuesta)
            {
                // no se borra: se marca como inactivo en la grilla
                row.Cells["EstadoValor"].Value = 0;
                row.Cells["Estado"].Value = "No Activo";
                dgvdata.InvalidateRow(row.Index);
                AplicarFiltros();

                MessageBox.Show("Usuario dado de baja correctamente.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void dgvdata_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            // PINTAR FILA SI ESTÁ INACTIVA (EstadoValor: 0 = Inactivo, 1 = Activo)
            if (dgvdata.Rows[e.RowIndex].Cells["EstadoValor"].Value != null)
            {
                int estadoVal = Convert.ToInt32(dgvdata.Rows[e.RowIndex].Cells["EstadoValor"].Value);
                if (estadoVal == 0)
                {
                    e.CellStyle.BackColor = Color.LightGray;
                    e.CellStyle.ForeColor = Color.DarkGray;
                }
                else
                {
                    e.CellStyle.BackColor = Color.White;
                    e.CellStyle.ForeColor = Color.Black;
                }
            }

            if (e.ColumnIndex == 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                var w = Properties.Resources.check20.Width;
                var h = Properties.Resources.check20.Height;
                var x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
                var y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2;

                e.Graphics.DrawImage(Properties.Resources.check20, new Rectangle(x, y, w, h));
                e.Handled = true;
            }
        }
    }
}
