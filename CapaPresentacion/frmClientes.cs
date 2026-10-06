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
    public partial class frmClientes : Form
    {
        public frmClientes()
        {
            InitializeComponent();
        }

        private void frmClientes_Load(object sender, EventArgs e)
        {
            TextoAyuda.Poner(txtbusqueda, "Buscar por documento, nombre, correo o teléfono");

            cboestadofiltro.Items.Add(new OpcionCombo() { Valor = -1, Texto = "Todos" });
            cboestadofiltro.Items.Add(new OpcionCombo() { Valor = 1, Texto = "Activo" });
            cboestadofiltro.Items.Add(new OpcionCombo() { Valor = 0, Texto = "No Activo" });
            cboestadofiltro.DisplayMember = "Texto";
            cboestadofiltro.ValueMember = "Valor";
            cboestadofiltro.SelectedIndex = 0;

            CargarClientes();
        }

        private void CargarClientes()
        {
            dgvdata.Rows.Clear();

            List<Cliente> lista = new CN_Cliente().Listar();

            foreach (Cliente item in lista)
            {
                dgvdata.Rows.Add(new object[] {
                    item.IdCliente,
                    item.Documento,
                    item.NombreCompleto,
                    item.Correo,
                    item.Telefono,
                    item.Estado == true ? 1 : 0,
                    item.Estado == true ? "Activo" : "No Activo"
                });
            }

            AplicarFiltros();
        }

        private void SeleccionarFila(int id)
        {
            foreach (DataGridViewRow row in dgvdata.Rows)
            {
                if (Convert.ToInt32(row.Cells["Id"].Value) == id && row.Visible)
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

        // Editar necesita una fila; Dar de baja además que el registro esté activo
        private void ActualizarBotones()
        {
            DataGridViewRow row = FilaSeleccionada();
            bool hayFila = row != null;
            bool activo = hayFila && Convert.ToInt32(row.Cells["EstadoValor"].Value) == 1;

            btneditar.Enabled = hayFila;
            btneditar.BackColor = hayFila ? Color.RoyalBlue : Color.FromArgb(220, 220, 220);
            btneliminar.Enabled = activo;
            btneliminar.BackColor = activo ? Color.Firebrick : Color.FromArgb(220, 220, 220);
        }

        private void dgvdata_SelectionChanged(object sender, EventArgs e)
        {
            ActualizarBotones();
        }

        private void btnagregar_Click(object sender, EventArgs e)
        {
            using (mdClienteDetalle modal = new mdClienteDetalle())
            {
                if (modal.ShowDialog(this) == DialogResult.OK)
                {
                    CargarClientes();
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
            Cliente cliente = new Cliente()
            {
                IdCliente = Convert.ToInt32(row.Cells["Id"].Value),
                Documento = row.Cells["Documento"].Value.ToString(),
                NombreCompleto = row.Cells["NombreCompleto"].Value.ToString(),
                Correo = Convert.ToString(row.Cells["Correo"].Value),
                Telefono = Convert.ToString(row.Cells["Telefono"].Value),
                Estado = Convert.ToInt32(row.Cells["EstadoValor"].Value) == 1
            };

            using (mdClienteDetalle modal = new mdClienteDetalle(cliente))
            {
                if (modal.ShowDialog(this) == DialogResult.OK)
                {
                    CargarClientes();
                    SeleccionarFila(modal.IdGuardado);
                }
            }
        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = FilaSeleccionada();
            if (row == null) return;

            string pregunta = "¿Desea dar de baja al cliente " + row.Cells["NombreCompleto"].Value + "?";
            if (MessageBox.Show(pregunta, "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            string mensaje = string.Empty;
            Cliente obj = new Cliente()
            {
                IdCliente = Convert.ToInt32(row.Cells["Id"].Value)
            };

            bool respuesta = new CN_Cliente().Eliminar(obj, out mensaje);

            if (respuesta)
            {
                // no se borra: se marca como inactivo en la grilla
                row.Cells["EstadoValor"].Value = 0;
                row.Cells["Estado"].Value = "No Activo";
                dgvdata.InvalidateRow(row.Index);
                AplicarFiltros();

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

            // dados de baja en gris
            object estado = dgvdata.Rows[e.RowIndex].Cells["EstadoValor"].Value;
            if (estado != null && estado.ToString() == "0")
            {
                e.CellStyle.ForeColor = Color.DarkGray;
            }
        }

        // filtra la grilla al cambiar el texto o el estado
        private void Filtros_Changed(object sender, EventArgs e)
        {
            AplicarFiltros();
        }

        private void AplicarFiltros()
        {
            // el combo se llena en el Load; antes de eso no hay nada que filtrar
            if (cboestadofiltro.SelectedItem == null) return;

            string texto = txtbusqueda.Text.Trim().ToUpper();
            int estado = Convert.ToInt32(((OpcionCombo)cboestadofiltro.SelectedItem).Valor);

            // no se puede ocultar la fila que tiene la celda actual
            dgvdata.CurrentCell = null;
            foreach (DataGridViewRow row in dgvdata.Rows)
            {
                bool coincideTexto = texto == ""
                    || Convert.ToString(row.Cells["Documento"].Value).ToUpper().Contains(texto)
                    || Convert.ToString(row.Cells["NombreCompleto"].Value).ToUpper().Contains(texto)
                    || Convert.ToString(row.Cells["Correo"].Value).ToUpper().Contains(texto)
                    || Convert.ToString(row.Cells["Telefono"].Value).ToUpper().Contains(texto);
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
