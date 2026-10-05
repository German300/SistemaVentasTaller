using CapaEntidad;

using CapaNegocio;

using DocumentFormat.OpenXml.Wordprocessing;

using iTextSharp.text.pdf;

using iTextSharp.tool.xml;

using System;

using System.Collections.Generic;

using System.ComponentModel;

using System.Data;

using System.Drawing;

using System.IO;

using System.Linq;

using System.Text;

using System.Threading.Tasks;

using System.Windows.Forms;



namespace CapaPresentacion

{

    public partial class frmDetalleCompra : Form

    {

        public frmDetalleCompra()

        {

            InitializeComponent();

        }



        private void label3_Click(object sender, EventArgs e)

        {



        }



        private void btnborrar_Click(object sender, EventArgs e)

        {
            txtfecha.Text = "";
            txttipodocumento.Text = "";
            txtusuario.Text = "";
            txtdocproveedor.Text = "";
            txtnombreproveedor.Text = "";
            dgvdata.Rows.Clear();
            txtmontototal.Text = "0.00";

        }



        private void btnbuscar_Click(object sender, EventArgs e)

        {
            Compra Ocompra = new CN_Compra().ObtenerCompra(txtbusqueda.Text);
            if (Ocompra.IdCompra != 0)

            {

                txtnumerodocumento.Text = Ocompra.NumeroDocumento;
                txtfecha.Text = Ocompra.FechaRegistro;
                txttipodocumento.Text = Ocompra.TipoDocumento;
                txtusuario.Text = Ocompra.oUsuario.NombreCompleto;
                txtdocproveedor.Text = Ocompra.oProveedor.Documento;
                txtnombreproveedor.Text = Ocompra.oProveedor.RazonSocial;


                dgvdata.Rows.Clear();

                foreach (Detalle_Compra dc in Ocompra.oDetalleCompra)

                {

                    dgvdata.Rows.Add(new object[] { dc.oProducto.Nombre, dc.PrecioCompra, dc.Cantidad, dc.MontoTotal });

                }

                txtmontototal.Text = Ocompra.MontoTotal.ToString("0.00");

            }

        }

        private void btndescargarpdf_Click(object sender, EventArgs e)
        {
            if (txttipodocumento.Text == "")
            {
                MessageBox.Show("No hay datos para generar el PDF", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            string Texto_Html = Properties.Resources.PlantillaCompra.ToString();
            Negocio oDatos = new CN_Negocio().ObtenerDatos();

            Texto_Html = Texto_Html.Replace("@nombrenegocio", oDatos.Nombre.ToUpper());
            Texto_Html = Texto_Html.Replace("@docnegocio", oDatos.RUC);
            Texto_Html = Texto_Html.Replace("@direcnegocio", oDatos.Direccion);

            Texto_Html = Texto_Html.Replace("@numerodocumento", txtnumerodocumento.Text);
            Texto_Html = Texto_Html.Replace("@tipodocumento", txttipodocumento.Text);

            Texto_Html = Texto_Html.Replace("@docproveedor", txtdocproveedor.Text);
            Texto_Html = Texto_Html.Replace("@nombreproveedor", txtnombreproveedor.Text);
            Texto_Html = Texto_Html.Replace("@fecharegistro", txtfecha.Text);
            Texto_Html = Texto_Html.Replace("@usuarioregistro", txtusuario.Text);

            string filas = string.Empty;
            foreach (DataGridViewRow row in dgvdata.Rows)
            {
            
                if (row.IsNewRow) continue;

                filas += "<tr>";
                filas += "<td>" + row.Cells["Producto"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["PrecioCompra"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["Cantidad"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["Subtotal"].Value.ToString() + "</td>";
                filas += "</tr>";
            }

            Texto_Html = Texto_Html.Replace("@filas", filas);
            Texto_Html = Texto_Html.Replace("@montototal", txtmontototal.Text);

            SaveFileDialog savefile = new SaveFileDialog();
            savefile.FileName = string.Format("Compra_{0}.pdf", txtnumerodocumento.Text);
            savefile.Filter = "Pdf Files|*.pdf";

            if (savefile.ShowDialog() == DialogResult.OK)
            {
                using (FileStream stream = new FileStream(savefile.FileName, FileMode.Create))
                {
                  
                    iTextSharp.text.Document pdfdoc = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4, 25, 25, 25, 25);

                    PdfWriter writer = PdfWriter.GetInstance(pdfdoc, stream);
                    pdfdoc.Open();

                    byte[] byteimagen = new CN_Negocio().ObtenerLogo(out bool obtenido);
                    if (obtenido)
                    {
                        iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(byteimagen);
                        img.ScaleToFit(60, 60);
                        img.Alignment = iTextSharp.text.Image.UNDERLYING;
                        img.SetAbsolutePosition(pdfdoc.Left, pdfdoc.Top - 51);
                        pdfdoc.Add(img);
                    }

                    using (StringReader sr = new StringReader(Texto_Html))
                    {
                        XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfdoc, sr);
                    }

                    pdfdoc.Close();
                    stream.Close();
                    MessageBox.Show("PDF generado correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

    }

}