using CapaEntidad;
using CapaNegocio;
using CapaPresentacion.Utilidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace CapaPresentacion.Modales
{
    public partial class mdCliente : Form
    {
        public Cliente _Cliente { get; set; }

        public mdCliente()
        {
            InitializeComponent();
        }

        private void mdCliente_Load(object sender, EventArgs e)
        {
            cbobusqueda.Items.Clear();
            dgvdata.Rows.Clear();

            // Cargar combo de búsqueda
            foreach (DataGridViewColumn columna in dgvdata.Columns)
            {
                if (columna.Visible)
                {
                    cbobusqueda.Items.Add(new OpcionCombo() { Valor = columna.Name, Texto = columna.HeaderText });
                }
            }
            cbobusqueda.DisplayMember = "Texto";
            cbobusqueda.ValueMember = "Valor";
            if (cbobusqueda.Items.Count > 0) cbobusqueda.SelectedIndex = 0;

            // Cargar datos
            List<Cliente> lista = new CN_Cliente().Listar();

            foreach (Cliente item in lista)
            {
                if (item.Estado)
                {
                    // SI TU GRILLA TIENE COLUMNA DE SELECCIÓN O BOTÓN EN EL ÍNDICE 0:
                    // Descomenta la opción A. Si solo tiene 2 columnas, usa la opción B.

                    // OPCIÓN A (Si la primera columna es un botón/vacía):
                    dgvdata.Rows.Add(new object[] { "", item.Documento, item.NombreCompleto });

                    // OPCIÓN B (Si NO hay columna vacía):
                    // dgvdata.Rows.Add(new object[] { item.Documento, item.NombreCompleto });
                }
            }
        }

        private void dgvdata_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int iRow = e.RowIndex;
            int iColumn = e.ColumnIndex;

            if (iRow >= 0 && iColumn >= 0)
            {
                // Leemos por el Name explícito asignado en el Diseñador
                var docVal = dgvdata.Rows[iRow].Cells["Documento"].Value;
                var nomVal = dgvdata.Rows[iRow].Cells["NombreCompleto"].Value;

                // Si por alguna razón el Name no está configurado, usamos los índices según tu vista:
                if (docVal == null) docVal = dgvdata.Rows[iRow].Cells[0].Value; // o Cells[1]
                if (nomVal == null) nomVal = dgvdata.Rows[iRow].Cells[1].Value; // o Cells[2]

                _Cliente = new Cliente()
                {
                    Documento = docVal != null ? docVal.ToString() : "",
                    NombreCompleto = nomVal != null ? nomVal.ToString() : ""
                };

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnbuscar_Click(object sender, EventArgs e)
        {
            if (cbobusqueda.SelectedItem == null) return;

            string columnaFiltro = ((OpcionCombo)cbobusqueda.SelectedItem).Valor.ToString();

            if (dgvdata.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvdata.Rows)
                {
                    if (row.Cells[columnaFiltro].Value != null &&
                        row.Cells[columnaFiltro].Value.ToString().Trim().ToUpper().Contains(txtbusqueda.Text.Trim().ToUpper()))
                    {
                        row.Visible = true;
                    }
                    else
                    {
                        row.Visible = false;
                    }
                }
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