using CapaEntidad;
using CapaNegocio;
using CapaPresentacion.Modales;
using CapaPresentacion.Utilidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class frmVentas : Form
    {
        private Usuario _Usuario;

        public frmVentas(Usuario oUsuario = null)
        {
            InitializeComponent();
            _Usuario = oUsuario;
        }

        private void frmVentas_Load(object sender, EventArgs e)
        {
            cbotipodocumento.Items.Add(new OpcionCombo() { Valor = "Boleta", Texto = "Boleta" });
            cbotipodocumento.Items.Add(new OpcionCombo() { Valor = "Factura", Texto = "Factura" });
            cbotipodocumento.DisplayMember = "Texto";
            cbotipodocumento.ValueMember = "Valor";
            cbotipodocumento.SelectedIndex = 0;

            txtfecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
            calcularTotal();
        }

        private void btnbuscarcliente_Click(object sender, EventArgs e)
        {
            using (var modal = new mdCliente())
            {
                if (modal.ShowDialog() == DialogResult.OK)
                {
                    txtdocumentocliente.Text = modal._Cliente.Documento;
                    txtnombrecliente.Text = modal._Cliente.NombreCompleto;
                }
            }
        }

        private void btnagregarproducto_Click(object sender, EventArgs e)
        {
            // cuánto de cada producto ya está cargado, para que el modal controle el stock
            Dictionary<int, int> cargados = new Dictionary<int, int>();
            foreach (DataGridViewRow row in dgvdata.Rows)
            {
                cargados[Convert.ToInt32(row.Cells["IdProducto"].Value)] = Convert.ToInt32(row.Cells["Cantidad"].Value);
            }

            using (var modal = new mdAgregarProductoVenta(cargados))
            {
                if (modal.ShowDialog(this) != DialogResult.OK) return;

                Producto p = modal.ProductoElegido;

                // si el producto ya está en la venta, se suma la cantidad
                foreach (DataGridViewRow row in dgvdata.Rows)
                {
                    if (Convert.ToInt32(row.Cells["IdProducto"].Value) == p.IdProducto)
                    {
                        int cantidad = Convert.ToInt32(row.Cells["Cantidad"].Value) + modal.Cantidad;
                        row.Cells["Cantidad"].Value = cantidad;
                        row.Cells["SubTotal"].Value = p.PrecioVenta * cantidad;
                        calcularTotal();
                        return;
                    }
                }

                // el precio sale siempre de la base de datos
                dgvdata.Rows.Add(new object[] {
                    p.IdProducto,
                    p.Codigo,
                    p.Nombre,
                    p.PrecioVenta,
                    modal.Cantidad,
                    p.PrecioVenta * modal.Cantidad
                });
                calcularTotal();
            }
        }

        private decimal TotalVenta()
        {
            decimal total = 0;
            foreach (DataGridViewRow row in dgvdata.Rows)
            {
                total += Convert.ToDecimal(row.Cells["SubTotal"].Value);
            }
            return total;
        }

        private void calcularTotal()
        {
            lbltotal.Text = string.Format("Total: $ {0:N2}", TotalVenta());
            btncrearventa.Enabled = dgvdata.Rows.Count > 0;
        }

        private void dgvdata_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvdata.Columns[e.ColumnIndex].Name == "btneliminar")
            {
                dgvdata.Rows.RemoveAt(e.RowIndex);
                calcularTotal();
            }
        }

        // =========================================================================
        // REGISTRAR LA VENTA: primero se cobra, después se envía al stored procedure
        // =========================================================================
        private void btncrearventa_Click(object sender, EventArgs e)
        {
            if (txtdocumentocliente.Text.Trim() == "")
            {
                MessageBox.Show("Debe ingresar el documento del cliente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtdocumentocliente.Select();
                return;
            }

            if (txtnombrecliente.Text.Trim() == "")
            {
                MessageBox.Show("Debe ingresar el nombre del cliente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtnombrecliente.Select();
                return;
            }

            if (dgvdata.Rows.Count < 1)
            {
                MessageBox.Show("Debe ingresar al menos un producto en la venta", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            decimal total = TotalVenta();
            decimal montoPago;
            decimal montoCambio;

            using (var cobro = new mdCobrarVenta(total))
            {
                if (cobro.ShowDialog(this) != DialogResult.OK) return;
                montoPago = cobro.MontoPago;
                montoCambio = cobro.MontoCambio;
            }

            DataTable detalle_venta = new DataTable();
            detalle_venta.Columns.Add("IdProducto", typeof(int));
            detalle_venta.Columns.Add("PrecioVenta", typeof(decimal));
            detalle_venta.Columns.Add("Cantidad", typeof(int));
            detalle_venta.Columns.Add("Subtotal", typeof(decimal)); // "Subtotal" todo junto, igual que en SQL

            foreach (DataGridViewRow row in dgvdata.Rows)
            {
                detalle_venta.Rows.Add(
                    Convert.ToInt32(row.Cells["IdProducto"].Value),
                    Convert.ToDecimal(row.Cells["PrecioVenta"].Value),
                    Convert.ToInt32(row.Cells["Cantidad"].Value),
                    Convert.ToDecimal(row.Cells["SubTotal"].Value)
                );
            }

            int idcorrelativo = new CN_Venta().ObtenerCorrelativo();
            string numeroDocumento = string.Format("{0:00000}", idcorrelativo);

            Venta oVenta = new Venta()
            {
                oUsuario = new Usuario() { IdUsuario = _Usuario != null ? _Usuario.IdUsuario : 1 },
                TipoDocumento = ((OpcionCombo)cbotipodocumento.SelectedItem).Valor.ToString(),
                NumeroDocumento = numeroDocumento,
                DocumentoCliente = txtdocumentocliente.Text.Trim(),
                NombreCliente = txtnombrecliente.Text.Trim(),
                MontoPago = montoPago,
                MontoCambio = montoCambio,
                MontoTotal = total
            };

            string mensaje = string.Empty;
            bool respuesta = new CN_Venta().Registrar(oVenta, detalle_venta, out mensaje);

            if (respuesta)
            {
                MessageBox.Show(string.Format("Venta registrada. Número de venta: {0}\nVuelto: $ {1:N2}", numeroDocumento, montoCambio),
                    "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtdocumentocliente.Text = "";
                txtnombrecliente.Text = "";
                dgvdata.Rows.Clear();
                calcularTotal();
            }
            else
            {
                MessageBox.Show("Error al registrar la venta: " + mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
