using System.Windows.Forms;
using CapaEntidad;
using CapaNegocio;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace CapaPresentacion
{
    // Pantalla sin terminar: por ahora está oculta en el menú (ver Inicio_Load)
    public partial class frmDetalleVenta : Form
    {
        public frmDetalleVenta()
        {
            InitializeComponent();
        }

        private void btnborrar_Click(object sender, System.EventArgs e)
        {
            txtbusqueda.Text = "";
            txtnumerodocumento.Text = "";
            txtfecha.Text = "";
            txttipodocumento.Text = "";
            txtusuario.Text = "";
            txtdoccliente.Text = "";
            txtnombrecliente.Text = "";
            txtmontopago.Text = "0.00";
            txtmontocambio.Text = "0.00";
            txtmontototal.Text = "0.00";
            dgvdata.Rows.Clear();
        }

        private void btnbuscar_Click(object sender, System.EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtbusqueda.Text))
            {
                MessageBox.Show("Ingrese el número de venta o el documento del cliente", "Mensaje",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtbusqueda.Focus();
                return;
            }

            Venta venta = new CN_Venta().ObtenerVenta(txtbusqueda.Text.Trim());

            if (venta.IdVenta == 0)
            {
                MessageBox.Show("No se encontró la venta", "Mensaje",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            txtnumerodocumento.Text = venta.NumeroDocumento;
            txtfecha.Text = venta.FechaRegistro;
            txttipodocumento.Text = venta.TipoDocumento;
            txtusuario.Text = venta.oUsuario.NombreCompleto;
            txtdoccliente.Text = venta.DocumentoCliente;
            txtnombrecliente.Text = venta.NombreCliente;
            txtmontopago.Text = venta.MontoPago.ToString("0.00");
            txtmontocambio.Text = venta.MontoCambio.ToString("0.00");
            txtmontototal.Text = venta.MontoTotal.ToString("0.00");

            dgvdata.Rows.Clear();
            foreach (Detalle_Venta detalle in venta.oDetalleVenta)
            {
                dgvdata.Rows.Add(detalle.oProducto.Nombre, detalle.PrecioVenta,
                    detalle.Cantidad, detalle.SubTotal);
            }
        }

        private void btndescargar_Click(object sender, System.EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtnumerodocumento.Text))
            {
                MessageBox.Show("Busque una venta antes de generar el PDF", "Mensaje",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            StringBuilder html = new StringBuilder();
            html.Append("<h1>Detalle de venta</h1>");
            html.Append("<p><b>Número:</b> " + txtnumerodocumento.Text + "</p>");
            html.Append("<p><b>Fecha:</b> " + txtfecha.Text + "</p>");
            html.Append("<p><b>Tipo:</b> " + txttipodocumento.Text + "</p>");
            html.Append("<p><b>Cliente:</b> " + txtnombrecliente.Text + " - " + txtdoccliente.Text + "</p>");
            html.Append("<table border='1' cellpadding='5'><tr><th>Producto</th><th>Precio</th><th>Cantidad</th><th>Subtotal</th></tr>");

            foreach (DataGridViewRow row in dgvdata.Rows)
            {
                html.Append("<tr><td>" + row.Cells["Producto"].Value + "</td><td>" +
                    row.Cells["Precio"].Value + "</td><td>" + row.Cells["Cantidad"].Value +
                    "</td><td>" + row.Cells["SubTotal"].Value + "</td></tr>");
            }

            html.Append("</table><p><b>Total:</b> " + txtmontototal.Text +
                "</p><p><b>Pago:</b> " + txtmontopago.Text + "</p><p><b>Cambio:</b> " +
                txtmontocambio.Text + "</p>");

            using (SaveFileDialog savefile = new SaveFileDialog())
            {
                savefile.FileName = "Venta_" + txtnumerodocumento.Text + ".pdf";
                savefile.Filter = "Pdf Files|*.pdf";

                if (savefile.ShowDialog() != DialogResult.OK) return;

                using (FileStream stream = new FileStream(savefile.FileName, FileMode.Create))
                {
                    iTextSharp.text.Document pdfdoc = new iTextSharp.text.Document(
                        iTextSharp.text.PageSize.A4, 25, 25, 25, 25);
                    PdfWriter writer = PdfWriter.GetInstance(pdfdoc, stream);
                    pdfdoc.Open();
                    using (StringReader reader = new StringReader(html.ToString()))
                    {
                        XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfdoc, reader);
                    }
                    pdfdoc.Close();
                }

                MessageBox.Show("PDF generado correctamente", "Mensaje",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
