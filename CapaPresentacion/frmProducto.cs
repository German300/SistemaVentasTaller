using CapaEntidad;
using CapaNegocio;
using CapaPresentacion.Utilidades;
using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class frmProducto : Form
    {
        private const string TextoCodigoNuevo = "Se genera al guardar";

        public frmProducto()
        {
            InitializeComponent();
        }

        private void frmProducto_Load(object sender, EventArgs e)
        {
            cboestado.Items.Add(new OpcionCombo() { Valor = 1, Texto = "Activo" });
            cboestado.Items.Add(new OpcionCombo() { Valor = 0, Texto = "No Activo" });
            cboestado.DisplayMember = "Texto";
            cboestado.ValueMember = "Valor";
            cboestado.SelectedIndex = 0;

            // Llenar el combo categoria (solo categorías activas)
            List<Categoria> listacategoria = new CN_Categoria().Listar();
            foreach (Categoria item in listacategoria.Where(c => c.Estado))
            {
                cbocategoria.Items.Add(new OpcionCombo() { Valor = item.IdCategoria, Texto = item.Descripcion });
            }
            cbocategoria.DisplayMember = "Texto";
            cbocategoria.ValueMember = "Valor";
            if (cbocategoria.Items.Count > 0) cbocategoria.SelectedIndex = 0;

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

            CargarProductos();
            Limpiar();
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

            dgvdata.ClearSelection();
        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            if (cbocategoria.SelectedItem == null)
            {
                MessageBox.Show("Primero debe crear una categoría activa.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (txtprecioventa.Value > 0 && txtprecioventa.Value < txtpreciocompra.Value)
            {
                var respuesta = MessageBox.Show("El precio de venta es menor al precio de compra.\n¿Desea guardar de todas formas?",
                    "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (respuesta == DialogResult.No) return;
            }

            string mensaje = string.Empty;
            int idproducto = Convert.ToInt32(txtid.Text);

            Producto obj = new Producto()
            {
                IdProducto = idproducto,
                Nombre = txtnombre_producto.Text.Trim(),
                Descripcion = txtproducto_descripcion.Text.Trim(),
                oCategoria = new Categoria() { IdCategoria = Convert.ToInt32(((OpcionCombo)cbocategoria.SelectedItem).Valor) },
                PrecioCompra = txtpreciocompra.Value,
                PrecioVenta = txtprecioventa.Value,
                Stock = Convert.ToInt32(txtcantidad.Value),
                Estado = Convert.ToInt32(((OpcionCombo)cboestado.SelectedItem).Valor) == 1
            };

            bool guardado;
            if (idproducto == 0)
            {
                idproducto = new CN_Producto().Registrar(obj, out mensaje);
                guardado = idproducto != 0;
            }
            else
            {
                guardado = new CN_Producto().Editar(obj, out mensaje);
            }

            if (!guardado)
            {
                MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // Se recarga la lista para mostrar el código generado por la base de datos
            CargarProductos();
            Limpiar();
            SeleccionarFila(idproducto);
        }

        private void SeleccionarFila(int idproducto)
        {
            foreach (DataGridViewRow row in dgvdata.Rows)
            {
                if (Convert.ToInt32(row.Cells["Id"].Value) == idproducto)
                {
                    row.Selected = true;
                    dgvdata.FirstDisplayedScrollingRowIndex = row.Index;
                    break;
                }
            }
        }

        private void Limpiar()
        {
            txtindice.Text = "-1";
            txtid.Text = "0";
            txtcodigo_producto.Text = TextoCodigoNuevo;
            txtnombre_producto.Text = "";
            txtproducto_descripcion.Text = "";
            txtpreciocompra.Value = 0;
            txtprecioventa.Value = 0;
            txtcantidad.Value = 0;
            txtcantidad.Enabled = true;
            lblcantidad.Text = "Cantidad inicial";
            if (cbocategoria.Items.Count > 0) cbocategoria.SelectedIndex = 0;
            if (cboestado.Items.Count > 0) cboestado.SelectedIndex = 0;

            lblmodo.Text = "Nuevo producto";
            lblmodo.ForeColor = Color.SeaGreen;
            btnguardar.Text = "Guardar";
            btneliminar.Enabled = false;
            btneliminar.BackColor = Color.FromArgb(220, 220, 220);

            dgvdata.ClearSelection();
            ActualizarGanancia();
            txtnombre_producto.Select();
        }

        private void dgvdata_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int indice = e.RowIndex;
            if (indice < 0) return;

            DataGridViewRow row = dgvdata.Rows[indice];

            txtindice.Text = indice.ToString();
            txtid.Text = row.Cells["Id"].Value.ToString();
            txtcodigo_producto.Text = row.Cells["Codigo"].Value.ToString();
            txtnombre_producto.Text = row.Cells["Nombre"].Value.ToString();
            txtproducto_descripcion.Text = row.Cells["Descripcion"].Value.ToString();
            txtpreciocompra.Value = Math.Min(Convert.ToDecimal(row.Cells["PrecioCompra"].Value), txtpreciocompra.Maximum);
            txtprecioventa.Value = Math.Min(Convert.ToDecimal(row.Cells["PrecioVenta"].Value), txtprecioventa.Maximum);

            // Después del alta, el stock solo cambia con compras y ventas
            txtcantidad.Value = Math.Max(Math.Min(Convert.ToDecimal(row.Cells["Stock"].Value), txtcantidad.Maximum), 0);
            txtcantidad.Enabled = false;
            lblcantidad.Text = "Stock actual";

            foreach (OpcionCombo oc in cbocategoria.Items)
            {
                if (Convert.ToInt32(oc.Valor) == Convert.ToInt32(row.Cells["IdCategoria"].Value))
                {
                    cbocategoria.SelectedItem = oc;
                    break;
                }
            }

            foreach (OpcionCombo oc in cboestado.Items)
            {
                if (Convert.ToInt32(oc.Valor) == Convert.ToInt32(row.Cells["EstadoValor"].Value))
                {
                    cboestado.SelectedItem = oc;
                    break;
                }
            }

            lblmodo.Text = "Editando " + txtcodigo_producto.Text;
            lblmodo.ForeColor = Color.RoyalBlue;
            btnguardar.Text = "Guardar cambios";

            // Solo se puede dar de baja un producto activo
            bool activo = Convert.ToInt32(row.Cells["EstadoValor"].Value) == 1;
            btneliminar.Enabled = activo;
            btneliminar.BackColor = activo ? Color.Firebrick : Color.FromArgb(220, 220, 220);
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

        private void precio_ValueChanged(object sender, EventArgs e)
        {
            ActualizarGanancia();
        }

        private void ActualizarGanancia()
        {
            decimal compra = txtpreciocompra.Value;
            decimal venta = txtprecioventa.Value;

            if (venta == 0)
            {
                lblganancia.Text = "Ganancia por unidad: —";
                lblganancia.ForeColor = Color.DimGray;
                return;
            }

            decimal ganancia = venta - compra;
            string porcentaje = compra > 0 ? string.Format(" ({0:N0}%)", ganancia / compra * 100) : "";

            lblganancia.Text = string.Format("Ganancia por unidad: {0:N2}{1}", ganancia, porcentaje);
            lblganancia.ForeColor = ganancia < 0 ? Color.Firebrick : Color.SeaGreen;
        }

        // Al entrar a un precio se selecciona todo para poder escribir directamente
        private void numerico_Enter(object sender, EventArgs e)
        {
            NumericUpDown control = (NumericUpDown)sender;
            BeginInvoke((Action)(() => control.Select(0, control.Text.Length)));
        }

        private void btnlimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnbuscar_producto_Click(object sender, EventArgs e)
        {
            string columnaFiltro = ((OpcionCombo)cbobusqueda.SelectedItem).Valor.ToString();
            string texto = txtbusqueda.Text.Trim().ToUpper();

            dgvdata.CurrentCell = null;
            foreach (DataGridViewRow row in dgvdata.Rows)
            {
                object valor = row.Cells[columnaFiltro].Value;
                row.Visible = valor != null && valor.ToString().Trim().ToUpper().Contains(texto);
            }
        }

        private void txtbusqueda_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnbuscar_producto_Click(sender, e);
                e.SuppressKeyPress = true;
            }
        }

        private void btnlimpiarbuscador_Click(object sender, EventArgs e)
        {
            txtbusqueda.Text = "";
            foreach (DataGridViewRow row in dgvdata.Rows)
            {
                row.Visible = true;
            }
        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtid.Text) != 0)
            {
                if (MessageBox.Show("¿Desea dar de baja este producto?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string mensaje = string.Empty;
                    Producto obj = new Producto()
                    {
                        IdProducto = Convert.ToInt32(txtid.Text)
                    };

                    bool respuesta = new CN_Producto().Eliminar(obj, out mensaje);

                    if (respuesta)
                    {
                        MessageBox.Show("Producto dado de baja correctamente.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarProductos();
                        Limpiar();
                    }
                    else
                    {
                        MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
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
