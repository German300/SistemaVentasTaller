using System;
using System.Drawing;
using System.Windows.Forms;

namespace CapaPresentacion.Modales
{
    public partial class mdCobrarVenta : Form
    {
        private readonly decimal _total;

        public decimal MontoPago { get; private set; }
        public decimal MontoCambio { get; private set; }

        public mdCobrarVenta(decimal total)
        {
            InitializeComponent();
            _total = total;
        }

        private void mdCobrarVenta_Load(object sender, EventArgs e)
        {
            lbltotal.Text = string.Format("$ {0:N2}", _total);
            txtabonado.Maximum = Math.Max(_total * 100, 100000000);
            txtabonado.Value = _total;
            ActualizarVuelto();

            txtabonado.Select();
            txtabonado.Select(0, txtabonado.Text.Length);
        }

        // lo que está escrito en el monto, aunque todavía no se haya confirmado el valor
        private decimal AbonadoEscrito()
        {
            decimal valor;
            if (decimal.TryParse(txtabonado.Text, out valor) && valor >= 0)
                return Math.Min(valor, txtabonado.Maximum);
            return 0;
        }

        private void ActualizarVuelto()
        {
            decimal abonado = AbonadoEscrito();

            if (abonado < _total)
            {
                lblvueltotitulo.Text = "Falta";
                lblvuelto.Text = string.Format("$ {0:N2}", _total - abonado);
                lblvuelto.ForeColor = Color.Firebrick;
                btnok.Enabled = false;
                btnok.BackColor = Color.FromArgb(220, 220, 220);
            }
            else
            {
                lblvueltotitulo.Text = "Vuelto";
                lblvuelto.Text = string.Format("$ {0:N2}", abonado - _total);
                lblvuelto.ForeColor = Color.SeaGreen;
                btnok.Enabled = true;
                btnok.BackColor = Color.ForestGreen;
            }
        }

        private void txtabonado_TextChanged(object sender, EventArgs e)
        {
            ActualizarVuelto();
        }

        private void txtabonado_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                if (btnok.Enabled) btnok_Click(sender, e);
            }
        }

        private void txtabonado_Enter(object sender, EventArgs e)
        {
            BeginInvoke((Action)(() => txtabonado.Select(0, txtabonado.Text.Length)));
        }

        private void btnok_Click(object sender, EventArgs e)
        {
            decimal abonado = AbonadoEscrito();
            if (abonado < _total) return;

            MontoPago = abonado;
            MontoCambio = abonado - _total;
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
