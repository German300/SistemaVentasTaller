using CapaEntidad;
using CapaNegocio;
using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace CapaPresentacion
{
    // Dos solapas: reporte de compras y reporte de ventas, filtrados por rango de fechas
    public partial class frmReportes : Form
    {
        public frmReportes()
        {
            InitializeComponent();
        }

        private void frmReportes_Load(object sender, EventArgs e)
        {
            // las columnas ya están armadas en el diseñador, no se generan solas
            dgvcompras.AutoGenerateColumns = false;
            dgvventas.AutoGenerateColumns = false;

            // por defecto se muestra desde el primer día del mes hasta hoy
            DateTime primerDiaMes = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            dtpiniciocompras.Value = primerDiaMes;
            dtpinicioventas.Value = primerDiaMes;
        }

        private void btnbuscarcompras_Click(object sender, EventArgs e)
        {
            if (dtpiniciocompras.Value.Date > dtpfincompras.Value.Date)
            {
                MessageBox.Show("La fecha de inicio no puede ser mayor a la fecha fin", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            List<ReporteCompra> lista = new CN_Compra().Reporte(dtpiniciocompras.Value, dtpfincompras.Value);

            dgvcompras.DataSource = lista;
            lbltotalcompras.Text = "Total: " + lista.Sum(r => r.SubTotal).ToString("0.00");
        }

        private void btnbuscarventas_Click(object sender, EventArgs e)
        {
            if (dtpinicioventas.Value.Date > dtpfinventas.Value.Date)
            {
                MessageBox.Show("La fecha de inicio no puede ser mayor a la fecha fin", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            List<ReporteVenta> lista = new CN_Venta().Reporte(dtpinicioventas.Value, dtpfinventas.Value);

            dgvventas.DataSource = lista;
            lbltotalventas.Text = "Total: " + lista.Sum(r => r.SubTotal).ToString("0.00");
        }

        private void btnexportarcompras_Click(object sender, EventArgs e)
        {
            ExportarExcel(dgvcompras, "ReporteCompras");
        }

        private void btnexportarventas_Click(object sender, EventArgs e)
        {
            ExportarExcel(dgvventas, "ReporteVentas");
        }

        // Pasa lo que se ve en la grilla a un archivo .xlsx (misma lógica que en Productos)
        private void ExportarExcel(DataGridView grilla, string nombreArchivo)
        {
            if (grilla.Rows.Count < 1)
            {
                MessageBox.Show("No hay datos para exportar", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DataTable dt = new DataTable();

            foreach (DataGridViewColumn columna in grilla.Columns)
            {
                dt.Columns.Add(columna.HeaderText, typeof(string));
            }

            foreach (DataGridViewRow row in grilla.Rows)
            {
                dt.Rows.Add(row.Cells.Cast<DataGridViewCell>().Select(c => (object)Convert.ToString(c.FormattedValue)).ToArray());
            }

            SaveFileDialog savefile = new SaveFileDialog();
            savefile.FileName = string.Format("{0}_{1}.xlsx", nombreArchivo, DateTime.Now.ToString("ddMMyyyyHHmmss"));
            savefile.Filter = "Excel Files|*.xlsx";

            if (savefile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    XLWorkbook wb = new XLWorkbook();
                    var hoja = wb.Worksheets.Add(dt, "Informe");
                    hoja.ColumnsUsed().AdjustToContents();
                    wb.SaveAs(savefile.FileName);
                    MessageBox.Show("Reporte generado correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al generar el reporte: " + ex.Message, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
