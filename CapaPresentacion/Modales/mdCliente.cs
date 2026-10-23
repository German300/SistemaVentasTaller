using CapaEntidad;
using CapaNegocio;
using CapaPresentacion.Utilidades;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CapaPresentacion.Modales
{
    // Ventana para elegir un cliente activo (se usa en Ventas)
    public partial class mdCliente : Form
    {
        // el cliente elegido con doble click
        public Cliente _Cliente { get; set; }

        public mdCliente()
        {
            InitializeComponent();
        }

        private void mdCliente_Load(object sender, EventArgs e)
        {
            // el combo de búsqueda ofrece las columnas visibles de la grilla
            foreach (DataGridViewColumn columna in dgvdata.Columns)
            {
                if (columna.Visible && columna.HeaderText != "")
                {
                    cbobusqueda.Items.Add(new OpcionCombo() { Valor = columna.Name, Texto = columna.HeaderText });
                }
            }
            cbobusqueda.DisplayMember = "Texto";
            cbobusqueda.ValueMember = "Valor";
            cbobusqueda.SelectedIndex = 0;

            List<Cliente> lista = new CN_Cliente().Listar();

            foreach (Cliente item in lista)
            {
                if (item.Estado)
                {
                    // columnas: btnseleccionar, Id, Documento, NombreCompleto
                    dgvdata.Rows.Add(new object[] { "", item.IdCliente, item.Documento, item.NombreCompleto });
                }
            }
        }

        private void dgvdata_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataGridViewRow row = dgvdata.Rows[e.RowIndex];

            _Cliente = new Cliente()
            {
                IdCliente = Convert.ToInt32(row.Cells["Id"].Value),
                Documento = row.Cells["Documento"].Value.ToString(),
                NombreCompleto = row.Cells["NombreCompleto"].Value.ToString()
            };

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnbuscar_Click(object sender, EventArgs e)
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
