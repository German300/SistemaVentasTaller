using CapaEntidad;
using CapaNegocio;
using CapaPresentacion.Utilidades;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace CapaPresentacion
{
    // Datos del negocio (nombre, RUC, dirección y logo) que salen en el PDF de compras
    public partial class frmNegocio : Form
    {
        public frmNegocio()
        {
            InitializeComponent();
        }

        // convierte los bytes guardados en la base en una imagen para el PictureBox
        private Image ByteToImage(byte[] imageBytes)
        {
            MemoryStream ms = new MemoryStream(imageBytes);
            return new Bitmap(ms);
        }

        private void frmNegocio_Load(object sender, EventArgs e)
        {
            // en el CUIT solo se pueden escribir números
            txtruc.KeyPress += Teclado.SoloNumeros;

            bool obtenido;
            byte[] byteimage = new CN_Negocio().ObtenerLogo(out obtenido);

            if (obtenido)
            {
                picLogo.Image = ByteToImage(byteimage);
            }

            Negocio datos = new CN_Negocio().ObtenerDatos();
            txtnombrenegocio.Text = datos.Nombre;
            txtdireccion.Text = datos.Direccion;
            txtruc.Text = datos.RUC;
        }

        private void btmSubirLogo_Click(object sender, EventArgs e)
        {
            OpenFileDialog oOpenFileDialog = new OpenFileDialog();
            oOpenFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png"; // solo imágenes

            if (oOpenFileDialog.ShowDialog() != DialogResult.OK)
                return;

            byte[] imageBytes = File.ReadAllBytes(oOpenFileDialog.FileName);
            string mensaje = string.Empty;
            bool respuesta = new CN_Negocio().ActualizarLogo(imageBytes, out mensaje);

            if (respuesta)
            {
                MessageBox.Show("Logo actualizado correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                picLogo.Image = ByteToImage(imageBytes);
            }
            else
            {
                MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnguardarcambios_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;
            Negocio obj = new Negocio()
            {
                Nombre = txtnombrenegocio.Text.Trim(),
                RUC = txtruc.Text.Trim(),
                Direccion = txtdireccion.Text.Trim()
            };

            bool respuesta = new CN_Negocio().GuardarDatos(obj, out mensaje);

            if (respuesta)
            {
                MessageBox.Show("Datos actualizados correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(mensaje, "No se pudo actualizar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
