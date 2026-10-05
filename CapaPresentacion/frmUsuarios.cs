using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaPresentacion.Utilidades;
using CapaNegocio;
using CapaEntidad;
using System.Diagnostics.Eventing.Reader;

namespace CapaPresentacion
{
    public partial class frmUsuarios : Form
    {
        public frmUsuarios()
        {
            InitializeComponent();
        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;

            Usuario objusuario = new Usuario()
            {
                IdUsuario = Convert.ToInt32(txtid.Text),
                Documento = txtdocumento.Text,
                NombreCompleto = txtnombrecompleto.Text,
                Correo = txtcorreo.Text,
                Clave = txtclave.Text,
                oRol = new Rol() { IdRol = Convert.ToInt32(((OpcionCombo)cborol.SelectedItem).Valor) },
                Estado = Convert.ToInt32(((OpcionCombo)cboestado.SelectedItem).Valor) == 1 ? true : false
            };

            if (objusuario.IdUsuario == 0)
            {
                int idusuariogenerado = new CN_Usuario().Registrar(objusuario, out mensaje);

                if (idusuariogenerado != 0)
                {
                    dgvdata.Rows.Add(new object[] {"", idusuariogenerado, txtdocumento.Text, txtnombrecompleto.Text, txtcorreo.Text, txtclave.Text,
                ((OpcionCombo)cborol.SelectedItem).Valor.ToString(),
                ((OpcionCombo)cborol.SelectedItem).Texto.ToString(),
                ((OpcionCombo)cboestado.SelectedItem).Valor.ToString(),
                ((OpcionCombo)cboestado.SelectedItem).Texto.ToString()
            });

                    Limpiar();
                }
                else
                {
                    MessageBox.Show(mensaje);
                }
            }
            else
            {
                bool resultado = new CN_Usuario().Editar(objusuario, out mensaje);

                if (resultado)
                {
                    // OBTENEMOS LA FILA QUE ESTAMOS EDITANDO USANDO EL TXTINDICE
                    DataGridViewRow row = dgvdata.Rows[Convert.ToInt32(txtindice.Text)];
                    row.Cells["Id"].Value = txtid.Text;
                    row.Cells["Documento"].Value = txtdocumento.Text;
                    row.Cells["NombreCompleto"].Value = txtnombrecompleto.Text;
                    row.Cells["Correo"].Value = txtcorreo.Text;
                    row.Cells["Clave"].Value = txtclave.Text;
                    row.Cells["IdRol"].Value = ((OpcionCombo)cborol.SelectedItem).Valor.ToString();
                    row.Cells["Rol"].Value = ((OpcionCombo)cborol.SelectedItem).Texto.ToString();
                    row.Cells["EstadoValor"].Value = ((OpcionCombo)cboestado.SelectedItem).Valor.ToString();
                    row.Cells["Estado"].Value = ((OpcionCombo)cboestado.SelectedItem).Texto.ToString();


                    Limpiar();
                }
                else
                {
                    MessageBox.Show(mensaje);
                }
            }

        }



        // metodo para limpiar los campos de texto del formulario de usuarios
        private void Limpiar()
        {
            txtindice.Text = "-1";
            txtid.Text = "0";
            txtdocumento.Text = "";
            txtnombrecompleto.Text = "";
            txtcorreo.Text = "";
            txtclave.Text = "";
            txtconfirmarclave.Text = "";
            cborol.SelectedIndex = 0;
            cboestado.SelectedIndex = 0;

            txtdocumento.Select();
        }


        private void frmUsuarios_Load(object sender, EventArgs e)
        {
            cboestado.Items.Add(new OpcionCombo() { Valor = 1, Texto = "Activo" });
            cboestado.Items.Add(new OpcionCombo() { Valor = 0, Texto = "No Activo" });

            cboestado.DisplayMember = "Texto";
            cboestado.ValueMember = "Valor";
            cboestado.SelectedIndex = 0;

            //llenar el combo rol
            List<Rol> listaRol = new CN_Rol().Listar();

            // listo los roles del combo box rol
            foreach (Rol item in listaRol)
            {

                cborol.Items.Add(new OpcionCombo() { Valor = item.IdRol, Texto = item.Descripcion });

            }
            cborol.DisplayMember = "Texto";
            cborol.ValueMember = "Valor";
            cborol.SelectedIndex = 0;

            foreach (DataGridViewColumn columna in dgvdata.Columns)
            {
                if (columna.Visible == true && columna.Name != "btnseleccionar" && columna.Name != "btneliminar")
                {
                    cbobusqueda.Items.Add(new OpcionCombo() { Valor = columna.Name, Texto = columna.HeaderText });
                }
            }
            cbobusqueda.DisplayMember = "Texto";
            cbobusqueda.ValueMember = "Valor";
            cbobusqueda.SelectedIndex = 0;


            // MOSTRAR TODOS LOS USUARIOS
            List<Usuario> listaUsuario = new CN_Usuario().Listar();

            foreach (Usuario item in listaUsuario)
            {
                dgvdata.Rows.Add(new object[] {
        "",
        item.IdUsuario,
        item.Documento,
        item.NombreCompleto,
        item.Correo,
        item.Clave,
        item.oRol.IdRol,
        item.oRol.Descripcion,
        item.Estado == true ? 1 : 0,
        item.Estado == true ? "Activo" : "No Activo"
    });
            }
        }


        private void iconButton1_Click(object sender, EventArgs e)
        {

        }

        private void iconButton2_Click(object sender, EventArgs e)
        {

        }

        private void dgvdata_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            // --- NUEVO: PINTAR FILA SI ESTÁ INACTIVA ---
            // Evaluamos la columna 'EstadoValor' (0 = Inactivo, 1 = Activo)
            if (dgvdata.Rows[e.RowIndex].Cells["EstadoValor"].Value != null)
            {
                int estadoVal = Convert.ToInt32(dgvdata.Rows[e.RowIndex].Cells["EstadoValor"].Value);
                if (estadoVal == 0)
                {
                    // Pintamos la celda actual de gris claro si el usuario está dado de baja
                    e.CellStyle.BackColor = Color.LightGray;
                    e.CellStyle.ForeColor = Color.DarkGray;
                }
                else
                {
                    // Mantenemos el color por defecto (blanco o el que use tu grilla)
                    e.CellStyle.BackColor = Color.White;
                    e.CellStyle.ForeColor = Color.Black;
                }
            }
            // ------------------------------------------

            if (e.ColumnIndex == 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                var w = Properties.Resources.check20.Width;
                var h = Properties.Resources.check20.Height;
                var x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
                var y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2;

                e.Graphics.DrawImage(Properties.Resources.check20, new Rectangle(x, y, w, h));
                e.Handled = true;
            }
        }

        // muestro en las cajas de texto los datos del usuario seleccionado en el datagridview
        private void dgvdata_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvdata.Columns[e.ColumnIndex].Name == "btnseleccionar")
            {
                int indice = e.RowIndex;
                if (indice >= 0)
                {
                    txtindice.Text = indice.ToString();
                    txtid.Text = dgvdata.Rows[indice].Cells["Id"].Value.ToString();
                    txtdocumento.Text = dgvdata.Rows[indice].Cells["Documento"].Value.ToString();
                    txtnombrecompleto.Text = dgvdata.Rows[indice].Cells["NombreCompleto"].Value.ToString();
                    txtcorreo.Text = dgvdata.Rows[indice].Cells["Correo"].Value.ToString();
                    txtclave.Text = dgvdata.Rows[indice].Cells["Clave"].Value.ToString();
                    txtconfirmarclave.Text = dgvdata.Rows[indice].Cells["Clave"].Value.ToString();

                    foreach (OpcionCombo oc in cborol.Items)
                    {
                        if (Convert.ToInt32(oc.Valor) == Convert.ToInt32(dgvdata.Rows[indice].Cells["IdRol"].Value))
                        {
                            cborol.SelectedItem = oc;
                            break;
                        }
                    }

                    foreach (OpcionCombo oc in cboestado.Items)
                    {
                        if (Convert.ToInt32(oc.Valor) == Convert.ToInt32(dgvdata.Rows[indice].Cells["EstadoValor"].Value))
                        {
                            cboestado.SelectedItem = oc;
                            break;
                        }
                    }

                    // --- NUEVO: CONTROLAR BOTÓN ELIMINAR ---
                    int estadoValor = Convert.ToInt32(dgvdata.Rows[indice].Cells["EstadoValor"].Value);
                    if (estadoValor == 0)
                    {
                        btneliminar.Enabled = false;
                        btneliminar.BackColor = Color.FromArgb(220, 220, 220); // Gris apagado
                    }
                    else
                    {
                        btneliminar.Enabled = true;
                        btneliminar.BackColor = Color.Firebrick; // Tu color original (si no es Firebrick, cambialo acá)
                    }
                    // ----------------------------------------
                }
            }
        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtid.Text) != 0)
            {
                if (MessageBox.Show("¿Desea dar de baja este usuario?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string mensaje = string.Empty;
                    Usuario objusuario = new Usuario()
                    {
                        IdUsuario = Convert.ToInt32(txtid.Text)
                    };

                    bool respuesta = new CN_Usuario().Eliminar(objusuario, out mensaje);

                    if (respuesta)
                    {
                        // --- CAMBIADO: AHORA NO REMOVEMOS, ACTUALIZAMOS LA GRILLA VISUALMENTE ---
                        int indice = Convert.ToInt32(txtindice.Text);

                        // Actualizamos las celdas de la grilla para que reflejen el nuevo estado inactivo
                        dgvdata.Rows[indice].Cells["EstadoValor"].Value = 0;
                        dgvdata.Rows[indice].Cells["Estado"].Value = "No Activo"; // O como muestres el texto en tu columna Estado

                        MessageBox.Show("Usuario dado de baja correctamente.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        Limpiar();

                        // Forzamos a la grilla a repintarse para que aplique el color gris del CellPainting
                        dgvdata.InvalidateRow(indice);
                        // -----------------------------------------------------------------------
                    }
                    else
                    {
                        MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
        }

        private void btnlimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
            // --- NUEVO: REACTIVAR EL BOTÓN AL LIMPIAR ---
            btneliminar.Enabled = true;
            btneliminar.BackColor = Color.Firebrick; // Tu color original
                                                     // --------------------------------------------
        }
    }
}
