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

            // Llenar el combo categoria
            List<Categoria> listacategoria = new CN_Categoria().Listar();
            foreach (Categoria item in listacategoria)
            {
                cbocategoria.Items.Add(new OpcionCombo() { Valor = item.IdCategoria, Texto = item.Descripcion });
            }
            cbocategoria.DisplayMember = "Texto";
            cbocategoria.ValueMember = "Valor";
            if (cbocategoria.Items.Count > 0) cbocategoria.SelectedIndex = 0;

            foreach (DataGridViewColumn columna in dgvdata.Columns)
            {
                if (columna.Visible == true && columna.Name != "btnseleccionar" && columna.Name != "btneliminar")
                {
                    cbobusqueda.Items.Add(new OpcionCombo() { Valor = columna.Name, Texto = columna.HeaderText });
                }
            }
            cbobusqueda.DisplayMember = "Texto";
            cbobusqueda.ValueMember = "Valor";
            if (cbobusqueda.Items.Count > 0) cbobusqueda.SelectedIndex = 0;

            // MOSTRAR TODOS LOS PRODUCTOS
            List<Producto> lista = new CN_Producto().Listar();

            foreach (Producto item in lista)
            {
                dgvdata.Rows.Add(new object[] {
        "",                          // Botón/Check selección
        item.IdProducto,             // Id
        item.Codigo,                 // Codigo
        item.Nombre,                 // Nombre
        item.Descripcion,            // Descripcion
        item.oCategoria.IdCategoria, // IdCategoria
        item.oCategoria.Descripcion, // Categoria
        item.Stock,                  // Stock
        item.PrecioCompra,           // PrecioCompra
        item.PrecioVenta,            // PrecioVenta
        item.Estado == true ? 1 : 0, // EstadoValor (IMPORTANTE: número 1 o 0)
        item.Estado == true ? "Activo" : "No Activo" // Estado (Texto)
    });
            }
        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;

            Producto obj = new Producto()
            {
                IdProducto = Convert.ToInt32(txtid.Text),
                Codigo = txtcodigo_producto.Text,
                Nombre = txtnombre_producto.Text,
                Descripcion = txtproducto_descripcion.Text,
                oCategoria = new Categoria() { IdCategoria = Convert.ToInt32(((OpcionCombo)cbocategoria.SelectedItem).Valor) },
                Estado = Convert.ToInt32(((OpcionCombo)cboestado.SelectedItem).Valor) == 1 ? true : false
            };

            if (obj.IdProducto == 0)
            {
                int idproductogenerado = new CN_Producto().Registrar(obj, out mensaje);

                if (idproductogenerado != 0)
                {
                    dgvdata.Rows.Add(new object[] {
                        "",
                        idproductogenerado,
                        txtcodigo_producto.Text,
                        txtnombre_producto.Text,
                        txtproducto_descripcion.Text,
                        ((OpcionCombo)cbocategoria.SelectedItem).Valor.ToString(),
                        ((OpcionCombo)cbocategoria.SelectedItem).Texto.ToString(),
                        "0.00",
                        "0.00",
                        ((OpcionCombo)cboestado.SelectedItem).Valor.ToString(),
                        ((OpcionCombo)cboestado.SelectedItem).Texto.ToString()
                    });

                    Limpiar();
                }
                else
                {
                    MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                bool resultado = new CN_Producto().Editar(obj, out mensaje);

                if (resultado)
                {
                    DataGridViewRow row = dgvdata.Rows[Convert.ToInt32(txtindice.Text)];
                    row.Cells["Id"].Value = txtid.Text;
                    row.Cells["Codigo"].Value = txtcodigo_producto.Text;
                    row.Cells["Nombre"].Value = txtnombre_producto.Text;
                    row.Cells["Descripcion"].Value = txtproducto_descripcion.Text;
                    row.Cells["IdCategoria"].Value = ((OpcionCombo)cbocategoria.SelectedItem).Valor.ToString();
                    row.Cells["Categoria"].Value = ((OpcionCombo)cbocategoria.SelectedItem).Texto.ToString();
                    row.Cells["EstadoValor"].Value = ((OpcionCombo)cboestado.SelectedItem).Valor.ToString();
                    row.Cells["Estado"].Value = ((OpcionCombo)cboestado.SelectedItem).Texto.ToString();

                    Limpiar();
                }
                else
                {
                    MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void Limpiar()
        {
            txtindice.Text = "-1";
            txtid.Text = "0";
            txtcodigo_producto.Text = "";
            txtnombre_producto.Text = "";
            txtproducto_descripcion.Text = "";
            if (cbocategoria.Items.Count > 0) cbocategoria.SelectedIndex = 0;
            if (cboestado.Items.Count > 0) cboestado.SelectedIndex = 0;

            btneliminar.Enabled = true;
            btneliminar.BackColor = Color.Firebrick;

            txtcodigo_producto.Select();
        }

        private void dgvdata_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            // Pintar fila gris si el producto está dado de baja (EstadoValor = 0)
            if (dgvdata.Rows[e.RowIndex].Cells["EstadoValor"].Value != null)
            {
                var valor = dgvdata.Rows[e.RowIndex].Cells["EstadoValor"].Value.ToString();

                // Evaluamos si es un entero o un booleano (true/false)
                bool esActivo = valor == "1" || valor.Equals("True", StringComparison.OrdinalIgnoreCase);

                if (!esActivo)
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

        private void dgvdata_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvdata.Columns[e.ColumnIndex].Name == "btnseleccionar")
            {
                int indice = e.RowIndex;
                if (indice >= 0)
                {
                    txtindice.Text = indice.ToString();
                    txtid.Text = dgvdata.Rows[indice].Cells["Id"].Value.ToString();
                    txtcodigo_producto.Text = dgvdata.Rows[indice].Cells["Codigo"].Value.ToString();
                    txtnombre_producto.Text = dgvdata.Rows[indice].Cells["Nombre"].Value.ToString();
                    txtproducto_descripcion.Text = dgvdata.Rows[indice].Cells["Descripcion"].Value.ToString();

                    foreach (OpcionCombo oc in cbocategoria.Items)
                    {
                        if (Convert.ToInt32(oc.Valor) == Convert.ToInt32(dgvdata.Rows[indice].Cells["IdCategoria"].Value))
                        {
                            cbocategoria.SelectedItem = oc;
                            break;
                        }
                    }

                    foreach (OpcionCombo oc in cboestado.Items)
                    {
                        if (Convert.ToInt32(oc.Valor) == Convert.ToInt32(dgvdata.Rows[indice].Cells["EstadoValor"].Value))
                        {
                            cboestado.SelectedItem = oc;
                            break;
                        }
                    }

                    // Bloquear botón Eliminar si el producto está inactivo
                    int estadoValor = Convert.ToInt32(dgvdata.Rows[indice].Cells["EstadoValor"].Value);
                    if (estadoValor == 0)
                    {
                        btneliminar.Enabled = false;
                        btneliminar.BackColor = Color.FromArgb(220, 220, 220);
                    }
                    else
                    {
                        btneliminar.Enabled = true;
                        btneliminar.BackColor = Color.Firebrick;
                    }
                }
            }
        }

        private void btnlimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnbuscar_producto_Click(object sender, EventArgs e)
        {
            string columnaFiltro = ((OpcionCombo)cbobusqueda.SelectedItem).Valor.ToString();

            if (dgvdata.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvdata.Rows)
                {
                    if (row.Cells[columnaFiltro].Value.ToString().Trim().ToUpper().Contains(txtbusqueda.Text.Trim().ToUpper()))
                        row.Visible = true;
                    else
                        row.Visible = false;
                }
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
                        int indice = Convert.ToInt32(txtindice.Text);
                        dgvdata.Rows[indice].Cells["EstadoValor"].Value = 0;
                        dgvdata.Rows[indice].Cells["Estado"].Value = "No Activo";

                        MessageBox.Show("Producto dado de baja correctamente.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Limpiar();
                        dgvdata.InvalidateRow(indice);
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

                foreach (DataGridViewColumn columna in dgvdata.Columns)
                {
                    if (columna.HeaderText != "" && columna.Visible)
                        dt.Columns.Add(columna.HeaderText, typeof(string));
                }

                foreach (DataGridViewRow row in dgvdata.Rows)
                {
                    if (row.Visible)
                    {
                        dt.Rows.Add(new object[] {
                            row.Cells["Codigo"].Value.ToString(),
                            row.Cells["Nombre"].Value.ToString(),
                            row.Cells["Descripcion"].Value.ToString(),
                            row.Cells["Categoria"].Value.ToString(),
                            row.Cells["PrecioCompra"].Value.ToString(),
                            row.Cells["PrecioVenta"].Value.ToString(),
                            row.Cells["Estado"].Value.ToString(),
                        });
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