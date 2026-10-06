namespace CapaPresentacion
{
    partial class frmVentas
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlVenta = new System.Windows.Forms.Panel();
            this.dgvdata = new System.Windows.Forms.DataGridView();
            this.IdProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Producto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrecioVenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btneliminar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.pnlBarra = new System.Windows.Forms.Panel();
            this.btnagregarproducto = new FontAwesome.Sharp.IconButton();
            this.pnlSeparador1 = new System.Windows.Forms.Panel();
            this.pnlCabecera = new System.Windows.Forms.Panel();
            this.lbltitulo = new System.Windows.Forms.Label();
            this.lblfecha = new System.Windows.Forms.Label();
            this.txtfecha = new System.Windows.Forms.TextBox();
            this.lbltipodocumento = new System.Windows.Forms.Label();
            this.cbotipodocumento = new System.Windows.Forms.ComboBox();
            this.lbldocumentocliente = new System.Windows.Forms.Label();
            this.txtdocumentocliente = new System.Windows.Forms.TextBox();
            this.btnbuscarcliente = new FontAwesome.Sharp.IconButton();
            this.lblnombrecliente = new System.Windows.Forms.Label();
            this.txtnombrecliente = new System.Windows.Forms.TextBox();
            this.pnlSeparador2 = new System.Windows.Forms.Panel();
            this.pnlPie = new System.Windows.Forms.Panel();
            this.lbltotal = new System.Windows.Forms.Label();
            this.btncrearventa = new FontAwesome.Sharp.IconButton();
            this.pnlVenta.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvdata)).BeginInit();
            this.pnlBarra.SuspendLayout();
            this.pnlCabecera.SuspendLayout();
            this.pnlPie.SuspendLayout();
            this.SuspendLayout();
            //
            // pnlVenta
            //
            this.pnlVenta.Controls.Add(this.dgvdata);
            this.pnlVenta.Controls.Add(this.pnlBarra);
            this.pnlVenta.Controls.Add(this.pnlSeparador1);
            this.pnlVenta.Controls.Add(this.pnlCabecera);
            this.pnlVenta.Controls.Add(this.pnlSeparador2);
            this.pnlVenta.Controls.Add(this.pnlPie);
            this.pnlVenta.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlVenta.Location = new System.Drawing.Point(0, 0);
            this.pnlVenta.Name = "pnlVenta";
            this.pnlVenta.Padding = new System.Windows.Forms.Padding(16);
            this.pnlVenta.Size = new System.Drawing.Size(1489, 650);
            this.pnlVenta.TabIndex = 0;
            //
            // dgvdata
            //
            this.dgvdata.AllowUserToAddRows = false;
            this.dgvdata.AllowUserToDeleteRows = false;
            this.dgvdata.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.dgvdata.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvdata.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvdata.BackgroundColor = System.Drawing.Color.White;
            this.dgvdata.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvdata.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvdata.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(239)))), ((int)(((byte)(243)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(6, 0, 0, 0);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(239)))), ((int)(((byte)(243)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvdata.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvdata.ColumnHeadersHeight = 38;
            this.dgvdata.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvdata.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdProducto,
            this.Codigo,
            this.Producto,
            this.PrecioVenta,
            this.Cantidad,
            this.SubTotal,
            this.btneliminar});
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.Padding = new System.Windows.Forms.Padding(6, 0, 6, 0);
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(231)))), ((int)(((byte)(221)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvdata.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvdata.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvdata.EnableHeadersVisualStyles = false;
            this.dgvdata.GridColor = System.Drawing.Color.Gainsboro;
            this.dgvdata.Location = new System.Drawing.Point(16, 206);
            this.dgvdata.MultiSelect = false;
            this.dgvdata.Name = "dgvdata";
            this.dgvdata.ReadOnly = true;
            this.dgvdata.RowHeadersVisible = false;
            this.dgvdata.RowHeadersWidth = 51;
            this.dgvdata.RowTemplate.Height = 34;
            this.dgvdata.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvdata.Size = new System.Drawing.Size(1457, 340);
            this.dgvdata.TabIndex = 2;
            this.dgvdata.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvdata_CellContentClick);
            //
            // IdProducto
            //
            this.IdProducto.HeaderText = "IdProducto";
            this.IdProducto.MinimumWidth = 6;
            this.IdProducto.Name = "IdProducto";
            this.IdProducto.ReadOnly = true;
            this.IdProducto.Visible = false;
            //
            // Codigo
            //
            this.Codigo.FillWeight = 60F;
            this.Codigo.HeaderText = "Código";
            this.Codigo.MinimumWidth = 6;
            this.Codigo.Name = "Codigo";
            this.Codigo.ReadOnly = true;
            //
            // Producto
            //
            this.Producto.FillWeight = 220F;
            this.Producto.HeaderText = "Producto";
            this.Producto.MinimumWidth = 6;
            this.Producto.Name = "Producto";
            this.Producto.ReadOnly = true;
            //
            // PrecioVenta
            //
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            this.PrecioVenta.DefaultCellStyle = dataGridViewCellStyle3;
            this.PrecioVenta.FillWeight = 80F;
            this.PrecioVenta.HeaderText = "Precio";
            this.PrecioVenta.MinimumWidth = 6;
            this.PrecioVenta.Name = "PrecioVenta";
            this.PrecioVenta.ReadOnly = true;
            //
            // Cantidad
            //
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Cantidad.DefaultCellStyle = dataGridViewCellStyle4;
            this.Cantidad.FillWeight = 60F;
            this.Cantidad.HeaderText = "Cantidad";
            this.Cantidad.MinimumWidth = 6;
            this.Cantidad.Name = "Cantidad";
            this.Cantidad.ReadOnly = true;
            //
            // SubTotal
            //
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N2";
            this.SubTotal.DefaultCellStyle = dataGridViewCellStyle5;
            this.SubTotal.FillWeight = 80F;
            this.SubTotal.HeaderText = "Subtotal";
            this.SubTotal.MinimumWidth = 6;
            this.SubTotal.Name = "SubTotal";
            this.SubTotal.ReadOnly = true;
            //
            // btneliminar
            //
            this.btneliminar.FillWeight = 40F;
            this.btneliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btneliminar.HeaderText = "";
            this.btneliminar.MinimumWidth = 6;
            this.btneliminar.Name = "btneliminar";
            this.btneliminar.ReadOnly = true;
            this.btneliminar.Text = "Quitar";
            this.btneliminar.UseColumnTextForButtonValue = true;
            //
            // pnlBarra
            //
            this.pnlBarra.BackColor = System.Drawing.Color.White;
            this.pnlBarra.Controls.Add(this.btnagregarproducto);
            this.pnlBarra.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBarra.Location = new System.Drawing.Point(16, 152);
            this.pnlBarra.Name = "pnlBarra";
            this.pnlBarra.Size = new System.Drawing.Size(1457, 54);
            this.pnlBarra.TabIndex = 1;
            //
            // btnagregarproducto
            //
            this.btnagregarproducto.BackColor = System.Drawing.Color.ForestGreen;
            this.btnagregarproducto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnagregarproducto.FlatAppearance.BorderSize = 0;
            this.btnagregarproducto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnagregarproducto.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btnagregarproducto.ForeColor = System.Drawing.Color.White;
            this.btnagregarproducto.IconChar = FontAwesome.Sharp.IconChar.Plus;
            this.btnagregarproducto.IconColor = System.Drawing.Color.White;
            this.btnagregarproducto.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnagregarproducto.IconSize = 18;
            this.btnagregarproducto.Location = new System.Drawing.Point(14, 9);
            this.btnagregarproducto.Name = "btnagregarproducto";
            this.btnagregarproducto.Size = new System.Drawing.Size(200, 36);
            this.btnagregarproducto.TabIndex = 0;
            this.btnagregarproducto.Text = "Agregar producto";
            this.btnagregarproducto.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnagregarproducto.UseVisualStyleBackColor = false;
            this.btnagregarproducto.Click += new System.EventHandler(this.btnagregarproducto_Click);
            //
            // pnlSeparador1
            //
            this.pnlSeparador1.BackColor = System.Drawing.Color.Transparent;
            this.pnlSeparador1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSeparador1.Location = new System.Drawing.Point(16, 140);
            this.pnlSeparador1.Name = "pnlSeparador1";
            this.pnlSeparador1.Size = new System.Drawing.Size(1457, 12);
            this.pnlSeparador1.TabIndex = 0;
            //
            // pnlCabecera
            //
            this.pnlCabecera.BackColor = System.Drawing.Color.White;
            this.pnlCabecera.Controls.Add(this.lbltitulo);
            this.pnlCabecera.Controls.Add(this.lblfecha);
            this.pnlCabecera.Controls.Add(this.txtfecha);
            this.pnlCabecera.Controls.Add(this.lbltipodocumento);
            this.pnlCabecera.Controls.Add(this.cbotipodocumento);
            this.pnlCabecera.Controls.Add(this.lbldocumentocliente);
            this.pnlCabecera.Controls.Add(this.txtdocumentocliente);
            this.pnlCabecera.Controls.Add(this.btnbuscarcliente);
            this.pnlCabecera.Controls.Add(this.lblnombrecliente);
            this.pnlCabecera.Controls.Add(this.txtnombrecliente);
            this.pnlCabecera.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCabecera.Location = new System.Drawing.Point(16, 16);
            this.pnlCabecera.Name = "pnlCabecera";
            this.pnlCabecera.Size = new System.Drawing.Size(1457, 124);
            this.pnlCabecera.TabIndex = 0;
            //
            // lbltitulo
            //
            this.lbltitulo.AutoSize = true;
            this.lbltitulo.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold);
            this.lbltitulo.Location = new System.Drawing.Point(14, 10);
            this.lbltitulo.Name = "lbltitulo";
            this.lbltitulo.Size = new System.Drawing.Size(175, 32);
            this.lbltitulo.TabIndex = 0;
            this.lbltitulo.Text = "Registrar venta";
            //
            // lblfecha
            //
            this.lblfecha.AutoSize = true;
            this.lblfecha.Location = new System.Drawing.Point(16, 56);
            this.lblfecha.Name = "lblfecha";
            this.lblfecha.Size = new System.Drawing.Size(47, 20);
            this.lblfecha.TabIndex = 0;
            this.lblfecha.Text = "Fecha";
            //
            // txtfecha
            //
            this.txtfecha.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(244)))), ((int)(((byte)(246)))));
            this.txtfecha.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtfecha.Location = new System.Drawing.Point(18, 78);
            this.txtfecha.Name = "txtfecha";
            this.txtfecha.ReadOnly = true;
            this.txtfecha.Size = new System.Drawing.Size(120, 30);
            this.txtfecha.TabIndex = 0;
            this.txtfecha.TabStop = false;
            //
            // lbltipodocumento
            //
            this.lbltipodocumento.AutoSize = true;
            this.lbltipodocumento.Location = new System.Drawing.Point(156, 56);
            this.lbltipodocumento.Name = "lbltipodocumento";
            this.lbltipodocumento.Size = new System.Drawing.Size(137, 20);
            this.lbltipodocumento.TabIndex = 0;
            this.lbltipodocumento.Text = "Tipo de documento";
            //
            // cbotipodocumento
            //
            this.cbotipodocumento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbotipodocumento.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbotipodocumento.FormattingEnabled = true;
            this.cbotipodocumento.Location = new System.Drawing.Point(158, 78);
            this.cbotipodocumento.Name = "cbotipodocumento";
            this.cbotipodocumento.Size = new System.Drawing.Size(170, 31);
            this.cbotipodocumento.TabIndex = 1;
            //
            // lbldocumentocliente
            //
            this.lbldocumentocliente.AutoSize = true;
            this.lbldocumentocliente.Location = new System.Drawing.Point(348, 56);
            this.lbldocumentocliente.Name = "lbldocumentocliente";
            this.lbldocumentocliente.Size = new System.Drawing.Size(150, 20);
            this.lbldocumentocliente.TabIndex = 0;
            this.lbldocumentocliente.Text = "Documento cliente *";
            //
            // txtdocumentocliente
            //
            this.txtdocumentocliente.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtdocumentocliente.Location = new System.Drawing.Point(350, 78);
            this.txtdocumentocliente.Name = "txtdocumentocliente";
            this.txtdocumentocliente.Size = new System.Drawing.Size(170, 30);
            this.txtdocumentocliente.TabIndex = 2;
            //
            // btnbuscarcliente
            //
            this.btnbuscarcliente.BackColor = System.Drawing.Color.White;
            this.btnbuscarcliente.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnbuscarcliente.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnbuscarcliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnbuscarcliente.IconChar = FontAwesome.Sharp.IconChar.MagnifyingGlass;
            this.btnbuscarcliente.IconColor = System.Drawing.Color.Black;
            this.btnbuscarcliente.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnbuscarcliente.IconSize = 18;
            this.btnbuscarcliente.Location = new System.Drawing.Point(526, 78);
            this.btnbuscarcliente.Name = "btnbuscarcliente";
            this.btnbuscarcliente.Size = new System.Drawing.Size(38, 30);
            this.btnbuscarcliente.TabIndex = 3;
            this.btnbuscarcliente.UseVisualStyleBackColor = false;
            this.btnbuscarcliente.Click += new System.EventHandler(this.btnbuscarcliente_Click);
            //
            // lblnombrecliente
            //
            this.lblnombrecliente.AutoSize = true;
            this.lblnombrecliente.Location = new System.Drawing.Point(582, 56);
            this.lblnombrecliente.Name = "lblnombrecliente";
            this.lblnombrecliente.Size = new System.Drawing.Size(126, 20);
            this.lblnombrecliente.TabIndex = 0;
            this.lblnombrecliente.Text = "Nombre cliente *";
            //
            // txtnombrecliente
            //
            this.txtnombrecliente.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtnombrecliente.Location = new System.Drawing.Point(584, 78);
            this.txtnombrecliente.Name = "txtnombrecliente";
            this.txtnombrecliente.Size = new System.Drawing.Size(340, 30);
            this.txtnombrecliente.TabIndex = 4;
            //
            // pnlSeparador2
            //
            this.pnlSeparador2.BackColor = System.Drawing.Color.Transparent;
            this.pnlSeparador2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlSeparador2.Location = new System.Drawing.Point(16, 546);
            this.pnlSeparador2.Name = "pnlSeparador2";
            this.pnlSeparador2.Size = new System.Drawing.Size(1457, 12);
            this.pnlSeparador2.TabIndex = 0;
            //
            // pnlPie
            //
            this.pnlPie.BackColor = System.Drawing.Color.White;
            this.pnlPie.Controls.Add(this.lbltotal);
            this.pnlPie.Controls.Add(this.btncrearventa);
            this.pnlPie.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlPie.Location = new System.Drawing.Point(16, 558);
            this.pnlPie.Name = "pnlPie";
            this.pnlPie.Size = new System.Drawing.Size(1457, 76);
            this.pnlPie.TabIndex = 3;
            //
            // lbltotal
            //
            this.lbltotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbltotal.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold);
            this.lbltotal.Location = new System.Drawing.Point(760, 14);
            this.lbltotal.Name = "lbltotal";
            this.lbltotal.Size = new System.Drawing.Size(490, 48);
            this.lbltotal.TabIndex = 0;
            this.lbltotal.Text = "Total: $ 0,00";
            this.lbltotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // btncrearventa
            //
            this.btncrearventa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btncrearventa.BackColor = System.Drawing.Color.RoyalBlue;
            this.btncrearventa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btncrearventa.FlatAppearance.BorderSize = 0;
            this.btncrearventa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btncrearventa.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.btncrearventa.ForeColor = System.Drawing.Color.White;
            this.btncrearventa.IconChar = FontAwesome.Sharp.IconChar.CashRegister;
            this.btncrearventa.IconColor = System.Drawing.Color.White;
            this.btncrearventa.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btncrearventa.IconSize = 22;
            this.btncrearventa.Location = new System.Drawing.Point(1266, 14);
            this.btncrearventa.Name = "btncrearventa";
            this.btncrearventa.Size = new System.Drawing.Size(176, 48);
            this.btncrearventa.TabIndex = 1;
            this.btncrearventa.Text = "Crear venta";
            this.btncrearventa.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btncrearventa.UseVisualStyleBackColor = false;
            this.btncrearventa.Click += new System.EventHandler(this.btncrearventa_Click);
            //
            // frmVentas
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1489, 650);
            this.Controls.Add(this.pnlVenta);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "frmVentas";
            this.Text = "frmVentas";
            this.Load += new System.EventHandler(this.frmVentas_Load);
            this.pnlVenta.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvdata)).EndInit();
            this.pnlBarra.ResumeLayout(false);
            this.pnlCabecera.ResumeLayout(false);
            this.pnlCabecera.PerformLayout();
            this.pnlPie.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlVenta;
        private System.Windows.Forms.DataGridView dgvdata;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Producto;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrecioVenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubTotal;
        private System.Windows.Forms.DataGridViewButtonColumn btneliminar;
        private System.Windows.Forms.Panel pnlBarra;
        private FontAwesome.Sharp.IconButton btnagregarproducto;
        private System.Windows.Forms.Panel pnlSeparador1;
        private System.Windows.Forms.Panel pnlCabecera;
        private System.Windows.Forms.Label lbltitulo;
        private System.Windows.Forms.Label lblfecha;
        private System.Windows.Forms.TextBox txtfecha;
        private System.Windows.Forms.Label lbltipodocumento;
        private System.Windows.Forms.ComboBox cbotipodocumento;
        private System.Windows.Forms.Label lbldocumentocliente;
        private System.Windows.Forms.TextBox txtdocumentocliente;
        private FontAwesome.Sharp.IconButton btnbuscarcliente;
        private System.Windows.Forms.Label lblnombrecliente;
        private System.Windows.Forms.TextBox txtnombrecliente;
        private System.Windows.Forms.Panel pnlSeparador2;
        private System.Windows.Forms.Panel pnlPie;
        private System.Windows.Forms.Label lbltotal;
        private FontAwesome.Sharp.IconButton btncrearventa;
    }
}
