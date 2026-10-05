using CapaEntidad;
using CapaNegocio;
using CapaPresentacion.Utilidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion.Modales
{
    public partial class mdProveedor : Form
    {
        public Proveedor _Proveedor { get; set; }
        public mdProveedor()
        {
            InitializeComponent();
        }



        private void mdProveedor_Load(object sender, EventArgs e)
        {
            foreach (DataGridViewColumn columna in dgvdatap.Columns)
            {
                if (columna.Visible == true)
                {
                    cbobusqueda.Items.Add(new OpcionCombo() { Valor = columna.Name, Texto = columna.HeaderText });
                }
            }
            cbobusqueda.DisplayMember = "Texto";
            cbobusqueda.ValueMember = "Valor";
            cbobusqueda.SelectedIndex = 0;

           
            dgvdatap.Rows.Clear();
            List<Proveedor> lista = new CN_Proveedor().Listar();

            foreach (Proveedor item in lista)
            {
                if (item.Estado)
                {
                    dgvdatap.Rows.Add(new object[] {
                item.IdProveedor, 
                item.Documento,   
                item.RazonSocial  
            });
                }
            }
        }

        private void dgvdatap_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int IRow = e.RowIndex;
            int IColum = e.ColumnIndex;

            if (IRow >= 0 && IColum >= 0)
            {
                _Proveedor = new Proveedor()
                {
                    IdProveedor = Convert.ToInt32(dgvdatap.Rows[IRow].Cells["Id"].Value),
                    Documento = dgvdatap.Rows[IRow].Cells["Documento"].Value.ToString(),
                    RazonSocial = dgvdatap.Rows[IRow].Cells["RazonSocial"].Value.ToString(),
                };
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnbuscar_Click(object sender, EventArgs e)
        {
            string columnaFiltro = ((OpcionCombo)cbobusqueda.SelectedItem).Valor.ToString();

            if (dgvdatap.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvdatap.Rows)
                {
                    if (row.Cells[columnaFiltro].Value.ToString().Trim().ToUpper().Contains(txtbusqueda.Text.Trim().ToUpper()))
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
            foreach (DataGridViewRow row in dgvdatap.Rows)
            {
                row.Visible = true;
            }
        }
    }
}
