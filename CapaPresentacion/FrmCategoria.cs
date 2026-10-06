using CapaEntidad;
using CapaNegocio;
using CapaPresentacion.Modales;
using CapaPresentacion.Utilidades;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class FrmCategoria : Form
    {
        public FrmCategoria()
        {
            InitializeComponent();
        }

        private void FrmCategoria_Load(object sender, EventArgs e)
        {
            TextoAyuda.Poner(txtbusqueda, "Buscar categoría");

            cboestadofiltro.Items.Add(new OpcionCombo() { Valor = -1, Texto = "Todos" });
            cboestadofiltro.Items.Add(new OpcionCombo() { Valor = 1, Texto = "Activo" });
            cboestadofiltro.Items.Add(new OpcionCombo() { Valor = 0, Texto = "No Activo" });
            cboestadofiltro.DisplayMember = "Texto";
            cboestadofiltro.ValueMember = "Valor";
            cboestadofiltro.SelectedIndex = 0;

            CargarCategorias();
        }

        private void CargarCategorias()
        {
            dgvdata.Rows.Clear();

            List<Categoria> lista = new CN_Categoria().Listar();

            foreach (Categoria item in lista)
            {
                dgvdata.Rows.Add(new object[] {
                    item.IdCategoria,
                    item.Descripcion,
                    item.Estado == true ? 1 : 0,
                    item.Estado == true ? "Activo" : "No Activo"
                });
            }

            AplicarBusqueda();
        }

        private void SeleccionarFila(int idcategoria)
        {
            foreach (DataGridViewRow row in dgvdata.Rows)
            {
                if (Convert.ToInt32(row.Cells["Id"].Value) == idcategoria && row.Visible)
                {
                    row.Selected = true;
                    dgvdata.FirstDisplayedScrollingRowIndex = row.Index;
                    break;
                }
            }
        }

        private DataGridViewRow FilaSeleccionada()
        {
            return dgvdata.SelectedRows.Count > 0 ? dgvdata.SelectedRows[0] : null;
        }

        // Editar necesita una fila; Dar de baja además que la categoría esté activa
        private void ActualizarBotones()
        {
            DataGridViewRow row = FilaSeleccionada();
            bool hayFila = row != null;
            bool activa = hayFila && Convert.ToInt32(row.Cells["EstadoValor"].Value) == 1;

            btneditar.Enabled = hayFila;
            btneditar.BackColor = hayFila ? Color.RoyalBlue : Color.FromArgb(220, 220, 220);
            btneliminar.Enabled = activa;
            btneliminar.BackColor = activa ? Color.Firebrick : Color.FromArgb(220, 220, 220);
        }

        private void dgvdata_SelectionChanged(object sender, EventArgs e)
        {
            ActualizarBotones();
        }

        private void btnagregar_Click(object sender, EventArgs e)
        {
            using (mdCategoriaDetalle modal = new mdCategoriaDetalle())
            {
                if (modal.ShowDialog(this) == DialogResult.OK)
                {
                    CargarCategorias();
                    SeleccionarFila(modal.IdGuardado);
                }
            }
        }

        private void btneditar_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = FilaSeleccionada();
            if (row != null) EditarFila(row);
        }

        private void dgvdata_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) EditarFila(dgvdata.Rows[e.RowIndex]);
        }

        private void EditarFila(DataGridViewRow row)
        {
            Categoria categoria = new Categoria()
            {
                IdCategoria = Convert.ToInt32(row.Cells["Id"].Value),
                Descripcion = row.Cells["Descripcion"].Value.ToString(),
                Estado = Convert.ToInt32(row.Cells["EstadoValor"].Value) == 1
            };

            using (mdCategoriaDetalle modal = new mdCategoriaDetalle(categoria))
            {
                if (modal.ShowDialog(this) == DialogResult.OK)
                {
                    CargarCategorias();
                    SeleccionarFila(modal.IdGuardado);
                }
            }
        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = FilaSeleccionada();
            if (row == null) return;

            string pregunta = "¿Desea dar de baja la categoría " + row.Cells["Descripcion"].Value + "?";
            if (MessageBox.Show(pregunta, "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            string mensaje = string.Empty;
            Categoria obj = new Categoria()
            {
                IdCategoria = Convert.ToInt32(row.Cells["Id"].Value)
            };

            bool respuesta = new CN_Categoria().Eliminar(obj, out mensaje);

            if (respuesta)
            {
                // no se borra: se marca como inactiva en la grilla
                row.Cells["EstadoValor"].Value = 0;
                row.Cells["Estado"].Value = "No Activo";
                dgvdata.InvalidateRow(row.Index);
                AplicarBusqueda();

                MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void dgvdata_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            // Categorías dadas de baja en gris
            object estado = dgvdata.Rows[e.RowIndex].Cells["EstadoValor"].Value;
            if (estado != null && estado.ToString() == "0")
            {
                e.CellStyle.ForeColor = Color.DarkGray;
            }
        }

        // filtra la grilla al cambiar el texto o el estado
        private void Filtros_Changed(object sender, EventArgs e)
        {
            AplicarBusqueda();
        }

        private void AplicarBusqueda()
        {
            // el combo se llena en el Load; antes de eso no hay nada que filtrar
            if (cboestadofiltro.SelectedItem == null) return;

            string texto = txtbusqueda.Text.Trim().ToUpper();
            int estado = Convert.ToInt32(((OpcionCombo)cboestadofiltro.SelectedItem).Valor);

            // no se puede ocultar la fila que tiene la celda actual
            dgvdata.CurrentCell = null;
            foreach (DataGridViewRow row in dgvdata.Rows)
            {
                bool coincideTexto = row.Cells["Descripcion"].Value.ToString().ToUpper().Contains(texto);
                bool coincideEstado = estado == -1 || Convert.ToInt32(row.Cells["EstadoValor"].Value) == estado;
                row.Visible = coincideTexto && coincideEstado;
            }

            dgvdata.ClearSelection();
            ActualizarBotones();
        }

        private void btnlimpiarbuscador_Click(object sender, EventArgs e)
        {
            txtbusqueda.Text = "";
            cboestadofiltro.SelectedIndex = 0;
        }
    }
}
