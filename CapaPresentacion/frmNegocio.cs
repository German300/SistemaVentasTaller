using CapaEntidad;
using CapaNegocio;
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
    public partial class frmNegocio : Form
    {
        public frmNegocio()
        {
            InitializeComponent();
        }

        // creo un arreglo de bytes para guardar la imagen del logo
        public Image ByteToImage(byte[] imageBytes)
        {
            MemoryStream ms = new MemoryStream();
            ms.Write(imageBytes, 0, imageBytes.Length);
            Image image = new Bitmap(ms);
            return image;
        }



        private void frmNegocio_Load(object sender, EventArgs e)
        {
            bool obtenido = true;
            byte[] byteimage = new CN_Negocio().ObtenerLogo(out obtenido);

            if (obtenido)

                picLogo.Image = ByteToImage(byteimage);


            Negocio datos = new CN_Negocio().ObtenerDatos();
            txtnombrenegocio.Text = datos.Nombre;
            txtdireccion.Text = datos.Direccion;
            txtruc.Text = datos.RUC;

        }

        private void btmSubirLogo_Click(object sender, EventArgs e)
        {
            OpenFileDialog oOpenFileDialog = new OpenFileDialog();

            // Configuro el filtro para mostrar solo archivos de imagen
            oOpenFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png";


            if (oOpenFileDialog.ShowDialog() == DialogResult.OK)
            {
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
        }

        private void btnguardarcambios_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;
            Negocio obj = new Negocio()
            {
                Nombre = txtnombrenegocio.Text,
                RUC = txtruc.Text,
                Direccion = txtdireccion.Text
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
