using CapaEntidad;
using CapaNegocio;
using CapaPresentacion.Modales;
using CapaPresentacion.Utilidades;
using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class frmCompras : Form
    {
        // usuario que inició sesión: queda registrado como el que hizo la compra
        private Usuario _Usuario;

        public frmCompras(Usuario oUsuario)
        {
            _Usuario = oUsuario;
            InitializeComponent();
        }

        private void frmCompras_Load(object sender, EventArgs e)
        {
            cbotipodocumento.Items.Add(new OpcionCombo() { Valor = "Boleta", Texto = "Boleta" });
            cbotipodocumento.Items.Add(new OpcionCombo() { Valor = "Factura", Texto = "Factura" });
            cbotipodocumento.DisplayMember = "Texto";
            cbotipodocumento.ValueMember = "Valor";
            cbotipodocumento.SelectedIndex = 0;

            txtfecha.Text = DateTime.Now.ToString("dd/MM/yyyy");

            // "0" significa que todavía no se eligió producto ni proveedor
            txtidproducto.Text = "0";
            txtidproveedor.Text = "0";
        }

        private void btnbuscarproveedor_Click(object sender, EventArgs e)
        {
            using (mdProveedor modal = new mdProveedor())
            {
                if (modal.ShowDialog() == DialogResult.OK)
                {
                    txtidproveedor.Text = modal._Proveedor.IdProveedor.ToString();
                    txtdocproveedor.Text = modal._Proveedor.Documento;
                    txtnombreproveedor.Text = modal._Proveedor.RazonSocial;
                }
                else
                {
                    txtdocproveedor.Select();
                }
            }
        }

        private void btnbuscarproducto_Click(object sender, EventArgs e)
        {
            using (mdProducto modal = new mdProducto())
            {
                if (modal.ShowDialog() == DialogResult.OK)
                {
                    txtidproducto.Text = modal._Producto.IdProducto.ToString();
                    txtcodproducto.Text = modal._Producto.Codigo;
                    txtproducto.Text = modal._Producto.Nombre;
                    txtpreciocompra.Select();
                }
                else
                {
                    txtcodproducto.Select();
                }
            }
        }

        // Enter en el código: busca un producto activo con ese código
        private void txtcodproducto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData != Keys.Enter)
                return;

            Producto oProducto = new CN_Producto().Listar().FirstOrDefault(p => p.Codigo == txtcodproducto.Text && p.Estado);

            if (oProducto != null)
            {
                txtcodproducto.BackColor = Color.Honeydew;
                txtidproducto.Text = oProducto.IdProducto.ToString();
                txtproducto.Text = oProducto.Nombre;
            }
            else
            {
                txtcodproducto.BackColor = Color.MistyRose;
                txtidproducto.Text = "0";
                txtproducto.Text = "";
            }
        }

        private void btnagregarproducto_Click(object sender, EventArgs e)
        {
            decimal precioCompra;
            decimal precioVenta;

            if (txtidproducto.Text == "0")
            {
                MessageBox.Show("Debe seleccionar un producto", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (!LeerPrecio(txtpreciocompra.Text, out precioCompra) || precioCompra <= 0 || precioCompra > PrecioMaximo)
            {
                MessageBox.Show("El precio de compra debe ser un número mayor a 0 y menor a 99.999.999,99", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtpreciocompra.Select();
                return;
            }

            if (!LeerPrecio(txtprecioventa.Text, out precioVenta) || precioVenta <= 0 || precioVenta > PrecioMaximo)
            {
                MessageBox.Show("El precio de venta debe ser un número mayor a 0 y menor a 99.999.999,99", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtprecioventa.Select();
                return;
            }

            // un mismo producto no se agrega dos veces
            foreach (DataGridViewRow fila in dgvdata.Rows)
            {
                if (fila.Cells["IdProducto"].Value.ToString() == txtidproducto.Text)
                {
                    MessageBox.Show("El producto ya está en la lista de la compra", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }

            dgvdata.Rows.Add(new object[] {
                txtidproducto.Text,
                txtproducto.Text,
                precioCompra.ToString("0.00"),
                precioVenta.ToString("0.00"),
                txtcantidad.Value.ToString(),
                (txtcantidad.Value * precioCompra).ToString("0.00")
            });

            LimpiarProducto();
            CalcularTotal();
            txtcodproducto.Select();
        }

        private void LimpiarProducto()
        {
            txtidproducto.Text = "0";
            txtcodproducto.Text = "";
            txtcodproducto.BackColor = Color.White;
            txtproducto.Text = "";
            txtpreciocompra.Text = "";
            txtprecioventa.Text = "";
            txtcantidad.Value = 1;
        }

        private void CalcularTotal()
        {
            decimal total = 0;
            foreach (DataGridViewRow row in dgvdata.Rows)
            {
                total += Convert.ToDecimal(row.Cells["SubTotal"].Value);
            }
            txttotalpagar.Text = total.ToString("0.00");
        }

        // dibuja el ícono de tacho en la columna "btneliminar"
        private void dgvdata_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            if (dgvdata.Columns[e.ColumnIndex].Name == "btneliminar")
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                Image icono = Properties.Resources.delete32;
                int x = e.CellBounds.Left + (e.CellBounds.Width - icono.Width) / 2;
                int y = e.CellBounds.Top + (e.CellBounds.Height - icono.Height) / 2;
                e.Graphics.DrawImage(icono, new Rectangle(x, y, icono.Width, icono.Height));

                e.Handled = true;
            }
        }

        // click en el tacho: saca el producto de la compra
        private void dgvdata_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvdata.Columns[e.ColumnIndex].Name == "btneliminar")
            {
                dgvdata.Rows.RemoveAt(e.RowIndex);
                CalcularTotal();
            }
        }

        // En los precios solo se pueden escribir números y un separador decimal (punto o coma)
        private void SoloDecimales_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox caja = (TextBox)sender;

            // números y teclas como Borrar se permiten siempre
            if (char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar))
                return;

            // el separador se permite una sola vez y no como primer carácter
            bool esSeparador = e.KeyChar == '.' || e.KeyChar == ',';
            bool yaTieneSeparador = caja.Text.Contains(".") || caja.Text.Contains(",");
            if (esSeparador && caja.Text.Trim() != "" && !yaTieneSeparador)
                return;

            e.Handled = true; // cualquier otra tecla se ignora
        }

        // lo máximo que entra en las columnas decimal(10,2) de la base
        private const decimal PrecioMaximo = 99999999.99m;

        // Convierte el texto a número aceptando "10.50" o "10,50",
        // sin importar la configuración regional de la PC
        private bool LeerPrecio(string texto, out decimal precio)
        {
            return decimal.TryParse(texto.Replace(',', '.'), NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out precio);
        }

        private void btnregistrar_Click(object sender, EventArgs e)
        {
            if (txtidproveedor.Text == "0")
            {
                MessageBox.Show("Debe seleccionar un proveedor", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (dgvdata.Rows.Count < 1)
            {
                MessageBox.Show("Debe agregar productos a la compra", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // los productos se mandan al SP como una tabla con estas columnas
            DataTable detalle_compra = new DataTable();
            detalle_compra.Columns.Add("IdProducto", typeof(int));
            detalle_compra.Columns.Add("PrecioCompra", typeof(decimal));
            detalle_compra.Columns.Add("PrecioVenta", typeof(decimal));
            detalle_compra.Columns.Add("Cantidad", typeof(int));
            detalle_compra.Columns.Add("MontoTotal", typeof(decimal));

            foreach (DataGridViewRow row in dgvdata.Rows)
            {
                detalle_compra.Rows.Add(
                    Convert.ToInt32(row.Cells["IdProducto"].Value),
                    Convert.ToDecimal(row.Cells["PrecioCompra"].Value),
                    Convert.ToDecimal(row.Cells["PrecioVenta"].Value),
                    Convert.ToInt32(row.Cells["Cantidad"].Value),
                    Convert.ToDecimal(row.Cells["SubTotal"].Value)
                );
            }

            int idcorrelativo = new CN_Compra().ObtenerCorrelativo();
            string numeroDocumento = string.Format("{0:00000000}", idcorrelativo);

            Compra oCompra = new Compra()
            {
                oUsuario = new Usuario() { IdUsuario = _Usuario.IdUsuario },
                oProveedor = new Proveedor() { IdProveedor = Convert.ToInt32(txtidproveedor.Text) },
                TipoDocumento = ((OpcionCombo)cbotipodocumento.SelectedItem).Texto,
                NumeroDocumento = numeroDocumento,
                MontoTotal = Convert.ToDecimal(txttotalpagar.Text)
            };

            string mensaje = string.Empty;
            bool respuesta = new CN_Compra().Registrar(oCompra, detalle_compra, out mensaje);

            if (respuesta)
            {
                DialogResult copiar = MessageBox.Show("Número de compra generada:\n" + numeroDocumento + "\n\n¿Desea copiar en el portapapeles?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (copiar == DialogResult.Yes)
                {
                    Clipboard.SetText(numeroDocumento);
                }

                txtdocproveedor.Text = "";
                txtnombreproveedor.Text = "";
                txtidproveedor.Text = "0";
                dgvdata.Rows.Clear();
                CalcularTotal();
            }
            else
            {
                MessageBox.Show(mensaje, "Error al Registrar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
