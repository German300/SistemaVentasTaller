using CapaEntidad;
using CapaNegocio;
using CapaPresentacion.Utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace CapaPresentacion.Modales
{
    public partial class mdAgregarProductoVenta : Form
    {
        // cantidad de cada producto que ya está cargada en la venta, para no pasarse del stock
        private readonly Dictionary<int, int> _cantidadesEnVenta;

        private List<Producto> _productos = new List<Producto>();

        public Producto ProductoElegido { get; private set; }
        public int Cantidad { get; private set; }

        public mdAgregarProductoVenta(Dictionary<int, int> cantidadesEnVenta)
        {
            InitializeComponent();
            _cantidadesEnVenta = cantidadesEnVenta ?? new Dictionary<int, int>();
        }

        private void mdAgregarProductoVenta_Load(object sender, EventArgs e)
        {
            TextoAyuda.Poner(txtbusqueda, "Código, nombre o descripción");

            // solo se venden productos activos
            _productos = new CN_Producto().Listar().Where(p => p.Estado).ToList();

            foreach (Producto item in _productos)
            {
                dgvdata.Rows.Add(new object[] {
                    item.IdProducto,
                    item.Codigo,
                    item.Nombre,
                    item.Descripcion,
                    item.oCategoria.Descripcion,
                    item.PrecioVenta
                });
            }

            dgvdata.ClearSelection();
            MostrarSeleccion();
            txtbusqueda.Select();
        }

        private void txtbusqueda_TextChanged(object sender, EventArgs e)
        {
            string texto = txtbusqueda.Text.Trim().ToUpper();

            // no se puede ocultar la fila que tiene la celda actual
            dgvdata.CurrentCell = null;
            foreach (DataGridViewRow row in dgvdata.Rows)
            {
                row.Visible = texto == ""
                    || row.Cells["Codigo"].Value.ToString().ToUpper().Contains(texto)
                    || row.Cells["Nombre"].Value.ToString().ToUpper().Contains(texto)
                    || row.Cells["Descripcion"].Value.ToString().ToUpper().Contains(texto);
            }

            // si queda un solo producto, o el texto es un código exacto, se selecciona solo
            List<DataGridViewRow> visibles = dgvdata.Rows.Cast<DataGridViewRow>().Where(r => r.Visible).ToList();
            DataGridViewRow exacta = visibles.FirstOrDefault(r => r.Cells["Codigo"].Value.ToString().ToUpper() == texto);
            DataGridViewRow elegir = exacta ?? (visibles.Count == 1 ? visibles[0] : null);

            dgvdata.ClearSelection();
            if (elegir != null)
            {
                elegir.Selected = true;
            }
            MostrarSeleccion();
        }

        // Enter en el buscador pasa directo a la cantidad si ya hay un producto elegido
        private void txtbusqueda_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                if (Seleccionado() != null) txtcantidad.Select();
            }
            else if (e.KeyCode == Keys.Down && dgvdata.Rows.Cast<DataGridViewRow>().Any(r => r.Visible))
            {
                e.SuppressKeyPress = true;
                dgvdata.Select();
            }
        }

        private void dgvdata_SelectionChanged(object sender, EventArgs e)
        {
            MostrarSeleccion();
        }

        private void dgvdata_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) txtcantidad.Select();
        }

        private Producto Seleccionado()
        {
            if (dgvdata.SelectedRows.Count == 0 || !dgvdata.SelectedRows[0].Visible) return null;
            int id = Convert.ToInt32(dgvdata.SelectedRows[0].Cells["Id"].Value);
            return _productos.FirstOrDefault(p => p.IdProducto == id);
        }

        private void MostrarSeleccion()
        {
            Producto p = Seleccionado();

            if (p == null)
            {
                lblproducto.Text = "Elegí un producto de la lista";
                lblprecio.Text = "";
                lblsubtotal.Text = "";
                btnagregar.Enabled = false;
                return;
            }

            lblproducto.Text = p.Codigo + " - " + p.Nombre;
            lblprecio.Text = string.Format("Precio: $ {0:N2}", p.PrecioVenta);
            lblsubtotal.Text = string.Format("Subtotal: $ {0:N2}", p.PrecioVenta * CantidadEscrita());
            btnagregar.Enabled = true;
        }

        // lo que está escrito en la cantidad, aunque todavía no se haya confirmado el valor
        private decimal CantidadEscrita()
        {
            decimal valor;
            if (decimal.TryParse(txtcantidad.Text, out valor) && valor >= txtcantidad.Minimum)
                return Math.Min(valor, txtcantidad.Maximum);
            return txtcantidad.Minimum;
        }

        private void txtcantidad_TextChanged(object sender, EventArgs e)
        {
            MostrarSeleccion();
        }

        private void txtcantidad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btnagregar_Click(sender, e);
            }
        }

        // al entrar a la cantidad se selecciona todo para poder escribir directamente
        private void txtcantidad_Enter(object sender, EventArgs e)
        {
            BeginInvoke((Action)(() => txtcantidad.Select(0, txtcantidad.Text.Length)));
        }

        private void btnagregar_Click(object sender, EventArgs e)
        {
            Producto p = Seleccionado();
            if (p == null) return;

            int cantidad = Convert.ToInt32(txtcantidad.Value);
            int yaCargada = _cantidadesEnVenta.ContainsKey(p.IdProducto) ? _cantidadesEnVenta[p.IdProducto] : 0;

            // el stock no se muestra, pero no se puede vender más de lo que hay
            if (cantidad + yaCargada > p.Stock)
            {
                string detalle = yaCargada > 0
                    ? string.Format("Hay {0} en stock y ya cargaste {1} en esta venta.", p.Stock, yaCargada)
                    : string.Format("Hay {0} en stock.", p.Stock);
                MessageBox.Show("No hay stock suficiente de " + p.Nombre + ".\n" + detalle, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtcantidad.Select();
                return;
            }

            ProductoElegido = p;
            Cantidad = cantidad;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btncancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
