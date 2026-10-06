using CapaEntidad;
using CapaNegocio;
using CapaPresentacion.Modales;
using CapaPresentacion.Utilidades;
using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class frmProducto : Form
    {
        public frmProducto()
        {
            InitializeComponent();
        }

        private void frmProducto_Load(object sender, EventArgs e)
        {
            foreach (DataGridViewColumn columna in dgvdata.Columns)
            {
                if (columna.Visible == true)
                {
                    cbobusqueda.Items.Add(new OpcionCombo() { Valor = columna.Name, Texto = columna.HeaderText });
                }
            }
            cbobusqueda.DisplayMember = "Texto";
            cbobusqueda.ValueMember = "Valor";
            if (cbobusqueda.Items.Count > 0) cbobusqueda.SelectedIndex = 1; // Nombre

            cboestadofiltro.Items.Add(new OpcionCombo() { Valor = -1, Texto = "Todos" });
            cboestadofiltro.Items.Add(new OpcionCombo() { Valor = 1, Texto = "Activo" });
            cboestadofiltro.Items.Add(new OpcionCombo() { Valor = 0, Texto = "No Activo" });
            cboestadofiltro.DisplayMember = "Texto";
            cboestadofiltro.ValueMember = "Valor";
            cboestadofiltro.SelectedIndex = 0;

            CargarProductos();
        }

        private void CargarProductos()
        {
            dgvdata.Rows.Clear();

            List<Producto> lista = new CN_Producto().Listar();

            foreach (Producto item in lista)
            {
                dgvdata.Rows.Add(new object[] {
                    item.IdProducto,
                    item.Codigo,
                    item.Nombre,
                    item.Descripcion,
                    item.oCategoria.IdCategoria,
                    item.oCategoria.Descripcion,
                    item.Stock,
                    item.PrecioCompra,
                    item.PrecioVenta,
                    item.Estado == true ? 1 : 0,
                    item.Estado == true ? "Activo" : "No Activo"
                });
            }

            AplicarFiltros();
        }

        private void SeleccionarFila(int idproducto)
        {
            foreach (DataGridViewRow row in dgvdata.Rows)
            {
                if (Convert.ToInt32(row.Cells["Id"].Value) == idproducto && row.Visible)
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

        // Editar necesita una fila; Dar de baja además que el producto esté activo
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
            using (mdProductoDetalle modal = new mdProductoDetalle())
            {
                if (modal.ShowDialog(this) == DialogResult.OK)
                {
                    // se recarga la lista para mostrar el código generado por la base de datos
                    CargarProductos();
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
            Producto producto = new Producto()
            {
                IdProducto = Convert.ToInt32(row.Cells["Id"].Value),
                Codigo = row.Cells["Codigo"].Value.ToString(),
                Nombre = row.Cells["Nombre"].Value.ToString(),
                Descripcion = row.Cells["Descripcion"].Value.ToString(),
                oCategoria = new Categoria() { IdCategoria = Convert.ToInt32(row.Cells["IdCategoria"].Value) },
                Stock = Convert.ToInt32(row.Cells["Stock"].Value),
                PrecioCompra = Convert.ToDecimal(row.Cells["PrecioCompra"].Value),
                PrecioVenta = Convert.ToDecimal(row.Cells["PrecioVenta"].Value),
                Estado = Convert.ToInt32(row.Cells["EstadoValor"].Value) == 1
            };

            using (mdProductoDetalle modal = new mdProductoDetalle(producto))
            {
                if (modal.ShowDialog(this) == DialogResult.OK)
                {
                    CargarProductos();
                    SeleccionarFila(modal.IdGuardado);
                }
            }
        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = FilaSeleccionada();
            if (row == null) return;

            string pregunta = "¿Desea dar de baja el producto " + row.Cells["Nombre"].Value + "?";
            if (MessageBox.Show(pregunta, "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            string mensaje = string.Empty;
            Producto obj = new Producto()
            {
                IdProducto = Convert.ToInt32(row.Cells["Id"].Value)
            };

            bool respuesta = new CN_Producto().Eliminar(obj, out mensaje);

            if (respuesta)
            {
                // no se borra: se marca como inactivo en la grilla
                row.Cells["EstadoValor"].Value = 0;
                row.Cells["Estado"].Value = "No Activo";
                dgvdata.InvalidateRow(row.Index);
                AplicarFiltros();

                MessageBox.Show("Producto dado de baja correctamente.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void dgvdata_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            // Productos dados de baja en gris
            object estado = dgvdata.Rows[e.RowIndex].Cells["EstadoValor"].Value;
            if (estado != null && estado.ToString() == "0")
            {
                e.CellStyle.ForeColor = Color.DarkGray;
            }
        }

        // combina la búsqueda por columna con el filtro de estado
        private void AplicarFiltros()
        {
            // los combos se llenan en el Load; antes de eso no hay nada que filtrar
            if (cbobusqueda.SelectedItem == null || cboestadofiltro.SelectedItem == null) return;

            string columnaFiltro = ((OpcionCombo)cbobusqueda.SelectedItem).Valor.ToString();
            string texto = txtbusqueda.Text.Trim().ToUpper();
            int estado = Convert.ToInt32(((OpcionCombo)cboestadofiltro.SelectedItem).Valor);

            // no se puede ocultar la fila que tiene la celda actual
            dgvdata.CurrentCell = null;
            foreach (DataGridViewRow row in dgvdata.Rows)
            {
                object valor = row.Cells[columnaFiltro].Value;
                bool coincideTexto = valor != null && valor.ToString().Trim().ToUpper().Contains(texto);
                bool coincideEstado = estado == -1 || Convert.ToInt32(row.Cells["EstadoValor"].Value) == estado;
                row.Visible = coincideTexto && coincideEstado;
            }

            dgvdata.ClearSelection();
            ActualizarBotones();
        }

        private void btnbuscar_producto_Click(object sender, EventArgs e)
        {
            AplicarFiltros();
        }

        private void cboestadofiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            AplicarFiltros();
        }

        private void txtbusqueda_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                AplicarFiltros();
                e.SuppressKeyPress = true;
            }
        }

        private void btnlimpiarbuscador_Click(object sender, EventArgs e)
        {
            txtbusqueda.Text = "";
            cboestadofiltro.SelectedIndex = 0;
            AplicarFiltros();
        }

        private void btnexportar_Click(object sender, EventArgs e)
        {
            if (dgvdata.Rows.Count < 1)
            {
                MessageBox.Show("No hay datos para exportar", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                DataTable dt = new DataTable();
                List<DataGridViewColumn> columnas = dgvdata.Columns.Cast<DataGridViewColumn>()
                    .Where(c => c.Visible && c.HeaderText != "")
                    .OrderBy(c => c.DisplayIndex)
                    .ToList();

                foreach (DataGridViewColumn columna in columnas)
                {
                    dt.Columns.Add(columna.HeaderText, typeof(string));
                }

                foreach (DataGridViewRow row in dgvdata.Rows)
                {
                    if (row.Visible)
                    {
                        dt.Rows.Add(columnas.Select(c => (object)Convert.ToString(row.Cells[c.Name].FormattedValue)).ToArray());
                    }
                }

                SaveFileDialog savefile = new SaveFileDialog();
                savefile.FileName = string.Format("ReporteProductos_{0}.xlsx", DateTime.Now.ToString("ddMMyyyyHHmmss"));
                savefile.Filter = "Excel Files|*.xlsx";

                if (savefile.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        XLWorkbook wb = new XLWorkbook();
                        var hoja = wb.Worksheets.Add(dt, "Informe");
                        hoja.ColumnsUsed().AdjustToContents();
                        wb.SaveAs(savefile.FileName);
                        MessageBox.Show("Reporte generado correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al generar el reporte: " + ex.Message, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
