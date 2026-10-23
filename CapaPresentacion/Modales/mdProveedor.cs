using CapaEntidad;
using CapaNegocio;
using CapaPresentacion.Utilidades;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CapaPresentacion.Modales
{
    // Ventana para elegir un proveedor activo (se usa en Compras)
    public partial class mdProveedor : Form
    {
        // el proveedor elegido con doble click
        public Proveedor _Proveedor { get; set; }

        public mdProveedor()
        {
            InitializeComponent();
        }

        private void mdProveedor_Load(object sender, EventArgs e)
        {
            // el combo de búsqueda ofrece las columnas visibles de la grilla
            foreach (DataGridViewColumn columna in dgvdatap.Columns)
            {
                if (columna.Visible)
                {
                    cbobusqueda.Items.Add(new OpcionCombo() { Valor = columna.Name, Texto = columna.HeaderText });
                }
            }
            cbobusqueda.DisplayMember = "Texto";
            cbobusqueda.ValueMember = "Valor";
            cbobusqueda.SelectedIndex = 0;

            List<Proveedor> lista = new CN_Proveedor().Listar();

            foreach (Proveedor item in lista)
            {
                if (item.Estado)
                {
                    dgvdatap.Rows.Add(new object[] { item.IdProveedor, item.Documento, item.RazonSocial });
                }
            }
        }

        private void dgvdatap_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataGridViewRow row = dgvdatap.Rows[e.RowIndex];

            _Proveedor = new Proveedor()
            {
                IdProveedor = Convert.ToInt32(row.Cells["Id"].Value),
                Documento = row.Cells["Documento"].Value.ToString(),
                RazonSocial = row.Cells["RazonSocial"].Value.ToString()
            };

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnbuscar_Click(object sender, EventArgs e)
        {
            string columnaFiltro = ((OpcionCombo)cbobusqueda.SelectedItem).Valor.ToString();
            string texto = txtbusqueda.Text.Trim().ToUpper();

            // no se puede ocultar la fila que tiene la celda actual
            dgvdatap.CurrentCell = null;
            foreach (DataGridViewRow row in dgvdatap.Rows)
            {
                row.Visible = row.Cells[columnaFiltro].Value.ToString().ToUpper().Contains(texto);
            }
        }

        private void btnlimpiarbuscador_Click(object sender, EventArgs e)
        {
            txtbusqueda.Text = "";
            foreach (DataGridViewRow row in dgvdatap.Rows)
            {
                row.Visible = true;
            }
        }
    }
}
