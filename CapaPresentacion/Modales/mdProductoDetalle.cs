using CapaEntidad;
using CapaNegocio;
using CapaPresentacion.Utilidades;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace CapaPresentacion.Modales
{
    public partial class mdProductoDetalle : Form
    {
        // null = alta de un producto nuevo; con valor = edición
        private readonly Producto _productoEditar;

        // id del producto guardado, para seleccionarlo en la lista al volver
        public int IdGuardado { get; private set; }

        public mdProductoDetalle() : this(null) { }

        public mdProductoDetalle(Producto productoEditar)
        {
            InitializeComponent();
            _productoEditar = productoEditar;
        }

        private bool EsEdicion => _productoEditar != null;

        private void mdProductoDetalle_Load(object sender, EventArgs e)
        {
            cboestado.Items.Add(new OpcionCombo() { Valor = 1, Texto = "Activo" });
            cboestado.Items.Add(new OpcionCombo() { Valor = 0, Texto = "No Activo" });
            cboestado.DisplayMember = "Texto";
            cboestado.ValueMember = "Valor";
            cboestado.SelectedIndex = 0;

            // solo categorías activas, salvo la que ya tiene el producto que se edita
            List<Categoria> listacategoria = new CN_Categoria().Listar();
            foreach (Categoria item in listacategoria)
            {
                bool esLaDelProducto = EsEdicion && item.IdCategoria == _productoEditar.oCategoria.IdCategoria;
                if (item.Estado || esLaDelProducto)
                {
                    string texto = item.Estado ? item.Descripcion : item.Descripcion + " (dada de baja)";
                    cbocategoria.Items.Add(new OpcionCombo() { Valor = item.IdCategoria, Texto = texto });
                }
            }
            cbocategoria.DisplayMember = "Texto";
            cbocategoria.ValueMember = "Valor";
            if (cbocategoria.Items.Count > 0) cbocategoria.SelectedIndex = 0;

            if (EsEdicion)
            {
                this.Text = "Editar producto";
                lbltitulo.Text = "Editar producto";
                btnguardar.Text = "Guardar cambios";

                txtcodigo.Text = _productoEditar.Codigo;
                txtnombre.Text = _productoEditar.Nombre;
                txtdescripcion.Text = _productoEditar.Descripcion;
                txtpreciocompra.Value = Math.Min(_productoEditar.PrecioCompra, txtpreciocompra.Maximum);
                txtprecioventa.Value = Math.Min(_productoEditar.PrecioVenta, txtprecioventa.Maximum);

                // después del alta, el stock solo cambia con compras y ventas
                txtcantidad.Value = Math.Max(Math.Min(_productoEditar.Stock, txtcantidad.Maximum), 0);
                txtcantidad.Enabled = false;
                lblcantidad.Text = "Stock actual";

                foreach (OpcionCombo oc in cbocategoria.Items)
                {
                    if (Convert.ToInt32(oc.Valor) == _productoEditar.oCategoria.IdCategoria)
                    {
                        cbocategoria.SelectedItem = oc;
                        break;
                    }
                }
                cboestado.SelectedIndex = _productoEditar.Estado ? 0 : 1;
            }
            else
            {
                // un producto nuevo siempre se crea activo
                lblestado.Visible = false;
                cboestado.Visible = false;
            }

            ActualizarGanancia();
            txtnombre.Select();
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

            Producto obj = new Producto()
            {
                IdProducto = EsEdicion ? _productoEditar.IdProducto : 0,
                Nombre = txtnombre.Text.Trim(),
                Descripcion = txtdescripcion.Text.Trim(),
                oCategoria = new Categoria() { IdCategoria = Convert.ToInt32(((OpcionCombo)cbocategoria.SelectedItem).Valor) },
                PrecioCompra = txtpreciocompra.Value,
                PrecioVenta = txtprecioventa.Value,
                Stock = Convert.ToInt32(txtcantidad.Value),
                Estado = EsEdicion ? Convert.ToInt32(((OpcionCombo)cboestado.SelectedItem).Valor) == 1 : true
            };

            bool ok;
            if (EsEdicion)
            {
                ok = new CN_Producto().Editar(obj, out mensaje);
                IdGuardado = obj.IdProducto;
            }
            else
            {
                IdGuardado = new CN_Producto().Registrar(obj, out mensaje);
                ok = IdGuardado != 0;
            }

            if (ok)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

        // al entrar a un número se selecciona todo para poder escribir directamente
        private void numerico_Enter(object sender, EventArgs e)
        {
            NumericUpDown control = (NumericUpDown)sender;
            BeginInvoke((Action)(() => control.Select(0, control.Text.Length)));
        }

        private void btncancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
