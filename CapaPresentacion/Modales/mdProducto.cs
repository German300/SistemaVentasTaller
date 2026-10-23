using CapaEntidad;
using CapaNegocio;
using CapaPresentacion.Utilidades;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CapaPresentacion.Modales
{
    // Ventana para elegir un producto (se usa en Compras)
    public partial class mdProducto : Form
    {
        // el producto elegido con doble click
        public Producto _Producto { get; set; }

        public mdProducto()
        {
            InitializeComponent();
        }

        private void mdProducto_Load(object sender, EventArgs e)
        {
            // el combo de búsqueda ofrece las columnas visibles de la grilla
            foreach (DataGridViewColumn columna in dgvdata.Columns)
            {
                if (columna.Visible)
                {
                    cbobusqueda.Items.Add(new OpcionCombo() { Valor = columna.Name, Texto = columna.HeaderText });
                }
            }
            cbobusqueda.DisplayMember = "Texto";
            cbobusqueda.ValueMember = "Valor";
            cbobusqueda.SelectedIndex = 0;

            List<Producto> lista = new CN_Producto().Listar();

            foreach (Producto item in lista)
            {
                dgvdata.Rows.Add(new object[] {
                    item.IdProducto,
                    item.Codigo,
                    item.Nombre,
                    item.oCategoria.Descripcion,
                    item.Stock,
                    item.PrecioCompra,
                    item.PrecioVenta
                });
            }
        }

        private void dgvdata_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataGridViewRow row = dgvdata.Rows[e.RowIndex];

            _Producto = new Producto()
            {
                IdProducto = Convert.ToInt32(row.Cells["Id"].Value),
                Codigo = row.Cells["Codigo"].Value.ToString(),
                Nombre = row.Cells["Nombre"].Value.ToString(),
                Stock = Convert.ToInt32(row.Cells["Stock"].Value),
                PrecioCompra = Convert.ToDecimal(row.Cells["PrecioCompra"].Value),
                PrecioVenta = Convert.ToDecimal(row.Cells["PrecioVenta"].Value)
            };

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnbuscar_producto_Click(object sender, EventArgs e)
        {
            string columnaFiltro = ((OpcionCombo)cbobusqueda.SelectedItem).Valor.ToString();
            string texto = txtbusqueda.Text.Trim().ToUpper();

            // no se puede ocultar la fila que tiene la celda actual
            dgvdata.CurrentCell = null;
            foreach (DataGridViewRow row in dgvdata.Rows)
            {
                row.Visible = row.Cells[columnaFiltro].Value.ToString().ToUpper().Contains(texto);
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
    }
}
