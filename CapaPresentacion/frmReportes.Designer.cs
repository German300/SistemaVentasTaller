namespace CapaPresentacion
{
    partial class frmReportes
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabReportes = new System.Windows.Forms.TabControl();
            this.tabCompras = new System.Windows.Forms.TabPage();
            this.dgvcompras = new System.Windows.Forms.DataGridView();
            this.cFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cTipoDocumento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cNumeroDocumento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cProveedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cUsuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cCategoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cPrecioCompra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cSubTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlCabeceraCompras = new System.Windows.Forms.Panel();
            this.lbltotalcompras = new System.Windows.Forms.Label();
            this.btnexportarcompras = new FontAwesome.Sharp.IconButton();
            this.btnbuscarcompras = new FontAwesome.Sharp.IconButton();
            this.dtpfincompras = new System.Windows.Forms.DateTimePicker();
            this.lblfincompras = new System.Windows.Forms.Label();
            this.dtpiniciocompras = new System.Windows.Forms.DateTimePicker();
            this.lbliniciocompras = new System.Windows.Forms.Label();
            this.tabVentas = new System.Windows.Forms.TabPage();
            this.dgvventas = new System.Windows.Forms.DataGridView();
            this.vFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vTipoDocumento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vNumeroDocumento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vUsuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vCategoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vPrecioVenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vSubTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlCabeceraVentas = new System.Windows.Forms.Panel();
            this.lbltotalventas = new System.Windows.Forms.Label();
            this.btnexportarventas = new FontAwesome.Sharp.IconButton();
            this.btnbuscarventas = new FontAwesome.Sharp.IconButton();
            this.dtpfinventas = new System.Windows.Forms.DateTimePicker();
            this.lblfinventas = new System.Windows.Forms.Label();
            this.dtpinicioventas = new System.Windows.Forms.DateTimePicker();
            this.lblinicioventas = new System.Windows.Forms.Label();
            this.tabReportes.SuspendLayout();
            this.tabCompras.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvcompras)).BeginInit();
            this.pnlCabeceraCompras.SuspendLayout();
            this.tabVentas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvventas)).BeginInit();
            this.pnlCabeceraVentas.SuspendLayout();
            this.SuspendLayout();
            //
            // tabReportes
            //
            this.tabReportes.Controls.Add(this.tabCompras);
            this.tabReportes.Controls.Add(this.tabVentas);
            this.tabReportes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabReportes.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.tabReportes.Location = new System.Drawing.Point(0, 0);
            this.tabReportes.Name = "tabReportes";
            this.tabReportes.Padding = new System.Drawing.Point(16, 6);
            this.tabReportes.SelectedIndex = 0;
            this.tabReportes.Size = new System.Drawing.Size(1255, 649);
            this.tabReportes.TabIndex = 0;
            //
            // tabCompras
            //
            this.tabCompras.BackColor = System.Drawing.Color.White;
            this.tabCompras.Controls.Add(this.dgvcompras);
            this.tabCompras.Controls.Add(this.pnlCabeceraCompras);
            this.tabCompras.Location = new System.Drawing.Point(4, 35);
            this.tabCompras.Name = "tabCompras";
            this.tabCompras.Padding = new System.Windows.Forms.Padding(10);
            this.tabCompras.Size = new System.Drawing.Size(1247, 610);
            this.tabCompras.TabIndex = 0;
            this.tabCompras.Text = "Reporte de compras";
            //
            // dgvcompras
            //
            this.dgvcompras.AllowUserToAddRows = false;
            this.dgvcompras.AllowUserToDeleteRows = false;
            this.dgvcompras.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.dgvcompras.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvcompras.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvcompras.BackgroundColor = System.Drawing.Color.White;
            this.dgvcompras.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvcompras.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvcompras.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(239)))), ((int)(((byte)(243)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(239)))), ((int)(((byte)(243)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dgvcompras.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvcompras.ColumnHeadersHeight = 38;
            this.dgvcompras.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvcompras.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cFecha,
            this.cTipoDocumento,
            this.cNumeroDocumento,
            this.cProveedor,
            this.cUsuario,
            this.cProducto,
            this.cCategoria,
            this.cPrecioCompra,
            this.cCantidad,
            this.cSubTotal});
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(231)))), ((int)(((byte)(221)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvcompras.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvcompras.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvcompras.EnableHeadersVisualStyles = false;
            this.dgvcompras.Location = new System.Drawing.Point(10, 70);
            this.dgvcompras.MultiSelect = false;
            this.dgvcompras.Name = "dgvcompras";
            this.dgvcompras.ReadOnly = true;
            this.dgvcompras.RowHeadersVisible = false;
            this.dgvcompras.RowTemplate.Height = 30;
            this.dgvcompras.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvcompras.Size = new System.Drawing.Size(1227, 530);
            this.dgvcompras.TabIndex = 1;
            //
            // cFecha
            //
            this.cFecha.DataPropertyName = "FechaRegistro";
            this.cFecha.HeaderText = "Fecha";
            this.cFecha.Name = "cFecha";
            this.cFecha.ReadOnly = true;
            //
            // cTipoDocumento
            //
            this.cTipoDocumento.DataPropertyName = "TipoDocumento";
            this.cTipoDocumento.HeaderText = "Tipo Doc.";
            this.cTipoDocumento.Name = "cTipoDocumento";
            this.cTipoDocumento.ReadOnly = true;
            //
            // cNumeroDocumento
            //
            this.cNumeroDocumento.DataPropertyName = "NumeroDocumento";
            this.cNumeroDocumento.HeaderText = "Nro. Documento";
            this.cNumeroDocumento.Name = "cNumeroDocumento";
            this.cNumeroDocumento.ReadOnly = true;
            //
            // cProveedor
            //
            this.cProveedor.DataPropertyName = "RazonSocial";
            this.cProveedor.HeaderText = "Proveedor";
            this.cProveedor.Name = "cProveedor";
            this.cProveedor.ReadOnly = true;
            //
            // cUsuario
            //
            this.cUsuario.DataPropertyName = "NombreUsuario";
            this.cUsuario.HeaderText = "Usuario";
            this.cUsuario.Name = "cUsuario";
            this.cUsuario.ReadOnly = true;
            //
            // cProducto
            //
            this.cProducto.DataPropertyName = "NombreProducto";
            this.cProducto.HeaderText = "Producto";
            this.cProducto.Name = "cProducto";
            this.cProducto.ReadOnly = true;
            //
            // cCategoria
            //
            this.cCategoria.DataPropertyName = "Categoria";
            this.cCategoria.HeaderText = "Categoría";
            this.cCategoria.Name = "cCategoria";
            this.cCategoria.ReadOnly = true;
            //
            // cPrecioCompra
            //
            this.cPrecioCompra.DataPropertyName = "PrecioCompra";
            dataGridViewCellStyle4.Format = "0.00";
            this.cPrecioCompra.DefaultCellStyle = dataGridViewCellStyle4;
            this.cPrecioCompra.HeaderText = "Precio Compra";
            this.cPrecioCompra.Name = "cPrecioCompra";
            this.cPrecioCompra.ReadOnly = true;
            //
            // cCantidad
            //
            this.cCantidad.DataPropertyName = "Cantidad";
            this.cCantidad.HeaderText = "Cantidad";
            this.cCantidad.Name = "cCantidad";
            this.cCantidad.ReadOnly = true;
            //
            // cSubTotal
            //
            this.cSubTotal.DataPropertyName = "SubTotal";
            this.cSubTotal.DefaultCellStyle = dataGridViewCellStyle4;
            this.cSubTotal.HeaderText = "Subtotal";
            this.cSubTotal.Name = "cSubTotal";
            this.cSubTotal.ReadOnly = true;
            //
            // pnlCabeceraCompras
            //
            this.pnlCabeceraCompras.BackColor = System.Drawing.Color.White;
            this.pnlCabeceraCompras.Controls.Add(this.lbltotalcompras);
            this.pnlCabeceraCompras.Controls.Add(this.btnexportarcompras);
            this.pnlCabeceraCompras.Controls.Add(this.btnbuscarcompras);
            this.pnlCabeceraCompras.Controls.Add(this.dtpfincompras);
            this.pnlCabeceraCompras.Controls.Add(this.lblfincompras);
            this.pnlCabeceraCompras.Controls.Add(this.dtpiniciocompras);
            this.pnlCabeceraCompras.Controls.Add(this.lbliniciocompras);
            this.pnlCabeceraCompras.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCabeceraCompras.Location = new System.Drawing.Point(10, 10);
            this.pnlCabeceraCompras.Name = "pnlCabeceraCompras";
            this.pnlCabeceraCompras.Size = new System.Drawing.Size(1227, 60);
            this.pnlCabeceraCompras.TabIndex = 0;
            //
            // lbltotalcompras
            //
            this.lbltotalcompras.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbltotalcompras.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.lbltotalcompras.Location = new System.Drawing.Point(927, 16);
            this.lbltotalcompras.Name = "lbltotalcompras";
            this.lbltotalcompras.Size = new System.Drawing.Size(290, 28);
            this.lbltotalcompras.TabIndex = 6;
            this.lbltotalcompras.Text = "Total: 0.00";
            this.lbltotalcompras.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // btnexportarcompras
            //
            this.btnexportarcompras.BackColor = System.Drawing.Color.White;
            this.btnexportarcompras.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnexportarcompras.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnexportarcompras.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnexportarcompras.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnexportarcompras.ForeColor = System.Drawing.Color.Black;
            this.btnexportarcompras.IconChar = FontAwesome.Sharp.IconChar.FileExcel;
            this.btnexportarcompras.IconColor = System.Drawing.Color.Green;
            this.btnexportarcompras.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnexportarcompras.IconSize = 18;
            this.btnexportarcompras.Location = new System.Drawing.Point(620, 13);
            this.btnexportarcompras.Name = "btnexportarcompras";
            this.btnexportarcompras.Size = new System.Drawing.Size(140, 34);
            this.btnexportarcompras.TabIndex = 5;
            this.btnexportarcompras.Text = "Exportar Excel";
            this.btnexportarcompras.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnexportarcompras.UseVisualStyleBackColor = false;
            this.btnexportarcompras.Click += new System.EventHandler(this.btnexportarcompras_Click);
            //
            // btnbuscarcompras
            //
            this.btnbuscarcompras.BackColor = System.Drawing.Color.ForestGreen;
            this.btnbuscarcompras.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnbuscarcompras.FlatAppearance.BorderSize = 0;
            this.btnbuscarcompras.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnbuscarcompras.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnbuscarcompras.ForeColor = System.Drawing.Color.White;
            this.btnbuscarcompras.IconChar = FontAwesome.Sharp.IconChar.MagnifyingGlass;
            this.btnbuscarcompras.IconColor = System.Drawing.Color.White;
            this.btnbuscarcompras.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnbuscarcompras.IconSize = 18;
            this.btnbuscarcompras.Location = new System.Drawing.Point(500, 13);
            this.btnbuscarcompras.Name = "btnbuscarcompras";
            this.btnbuscarcompras.Size = new System.Drawing.Size(110, 34);
            this.btnbuscarcompras.TabIndex = 4;
            this.btnbuscarcompras.Text = "Buscar";
            this.btnbuscarcompras.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnbuscarcompras.UseVisualStyleBackColor = false;
            this.btnbuscarcompras.Click += new System.EventHandler(this.btnbuscarcompras_Click);
            //
            // dtpfincompras
            //
            this.dtpfincompras.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpfincompras.Location = new System.Drawing.Point(340, 15);
            this.dtpfincompras.Name = "dtpfincompras";
            this.dtpfincompras.Size = new System.Drawing.Size(140, 30);
            this.dtpfincompras.TabIndex = 3;
            //
            // lblfincompras
            //
            this.lblfincompras.AutoSize = true;
            this.lblfincompras.Location = new System.Drawing.Point(255, 19);
            this.lblfincompras.Name = "lblfincompras";
            this.lblfincompras.Size = new System.Drawing.Size(79, 23);
            this.lblfincompras.TabIndex = 2;
            this.lblfincompras.Text = "Fecha fin:";
            //
            // dtpiniciocompras
            //
            this.dtpiniciocompras.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpiniciocompras.Location = new System.Drawing.Point(100, 15);
            this.dtpiniciocompras.Name = "dtpiniciocompras";
            this.dtpiniciocompras.Size = new System.Drawing.Size(140, 30);
            this.dtpiniciocompras.TabIndex = 1;
            //
            // lbliniciocompras
            //
            this.lbliniciocompras.AutoSize = true;
            this.lbliniciocompras.Location = new System.Drawing.Point(0, 19);
            this.lbliniciocompras.Name = "lbliniciocompras";
            this.lbliniciocompras.Size = new System.Drawing.Size(98, 23);
            this.lbliniciocompras.TabIndex = 0;
            this.lbliniciocompras.Text = "Fecha inicio:";
            //
            // tabVentas
            //
            this.tabVentas.BackColor = System.Drawing.Color.White;
            this.tabVentas.Controls.Add(this.dgvventas);
            this.tabVentas.Controls.Add(this.pnlCabeceraVentas);
            this.tabVentas.Location = new System.Drawing.Point(4, 35);
            this.tabVentas.Name = "tabVentas";
            this.tabVentas.Padding = new System.Windows.Forms.Padding(10);
            this.tabVentas.Size = new System.Drawing.Size(1247, 610);
            this.tabVentas.TabIndex = 1;
            this.tabVentas.Text = "Reporte de ventas";
            //
            // dgvventas
            //
            this.dgvventas.AllowUserToAddRows = false;
            this.dgvventas.AllowUserToDeleteRows = false;
            this.dgvventas.AllowUserToResizeRows = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.dgvventas.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvventas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvventas.BackgroundColor = System.Drawing.Color.White;
            this.dgvventas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvventas.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvventas.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(239)))), ((int)(((byte)(243)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(239)))), ((int)(((byte)(243)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dgvventas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvventas.ColumnHeadersHeight = 38;
            this.dgvventas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvventas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.vFecha,
            this.vTipoDocumento,
            this.vNumeroDocumento,
            this.vCliente,
            this.vUsuario,
            this.vProducto,
            this.vCategoria,
            this.vPrecioVenta,
            this.vCantidad,
            this.vSubTotal});
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(231)))), ((int)(((byte)(221)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvventas.DefaultCellStyle = dataGridViewCellStyle7;
            this.dgvventas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvventas.EnableHeadersVisualStyles = false;
            this.dgvventas.Location = new System.Drawing.Point(10, 70);
            this.dgvventas.MultiSelect = false;
            this.dgvventas.Name = "dgvventas";
            this.dgvventas.ReadOnly = true;
            this.dgvventas.RowHeadersVisible = false;
            this.dgvventas.RowTemplate.Height = 30;
            this.dgvventas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvventas.Size = new System.Drawing.Size(1227, 530);
            this.dgvventas.TabIndex = 1;
            //
            // vFecha
            //
            this.vFecha.DataPropertyName = "FechaRegistro";
            this.vFecha.HeaderText = "Fecha";
            this.vFecha.Name = "vFecha";
            this.vFecha.ReadOnly = true;
            //
            // vTipoDocumento
            //
            this.vTipoDocumento.DataPropertyName = "TipoDocumento";
            this.vTipoDocumento.HeaderText = "Tipo Doc.";
            this.vTipoDocumento.Name = "vTipoDocumento";
            this.vTipoDocumento.ReadOnly = true;
            //
            // vNumeroDocumento
            //
            this.vNumeroDocumento.DataPropertyName = "NumeroDocumento";
            this.vNumeroDocumento.HeaderText = "Nro. Documento";
            this.vNumeroDocumento.Name = "vNumeroDocumento";
            this.vNumeroDocumento.ReadOnly = true;
            //
            // vCliente
            //
            this.vCliente.DataPropertyName = "NombreCliente";
            this.vCliente.HeaderText = "Cliente";
            this.vCliente.Name = "vCliente";
            this.vCliente.ReadOnly = true;
            //
            // vUsuario
            //
            this.vUsuario.DataPropertyName = "NombreUsuario";
            this.vUsuario.HeaderText = "Usuario";
            this.vUsuario.Name = "vUsuario";
            this.vUsuario.ReadOnly = true;
            //
            // vProducto
            //
            this.vProducto.DataPropertyName = "NombreProducto";
            this.vProducto.HeaderText = "Producto";
            this.vProducto.Name = "vProducto";
            this.vProducto.ReadOnly = true;
            //
            // vCategoria
            //
            this.vCategoria.DataPropertyName = "Categoria";
            this.vCategoria.HeaderText = "Categoría";
            this.vCategoria.Name = "vCategoria";
            this.vCategoria.ReadOnly = true;
            //
            // vPrecioVenta
            //
            this.vPrecioVenta.DataPropertyName = "PrecioVenta";
            dataGridViewCellStyle8.Format = "0.00";
            this.vPrecioVenta.DefaultCellStyle = dataGridViewCellStyle8;
            this.vPrecioVenta.HeaderText = "Precio Venta";
            this.vPrecioVenta.Name = "vPrecioVenta";
            this.vPrecioVenta.ReadOnly = true;
            //
            // vCantidad
            //
            this.vCantidad.DataPropertyName = "Cantidad";
            this.vCantidad.HeaderText = "Cantidad";
            this.vCantidad.Name = "vCantidad";
            this.vCantidad.ReadOnly = true;
            //
            // vSubTotal
            //
            this.vSubTotal.DataPropertyName = "SubTotal";
            this.vSubTotal.DefaultCellStyle = dataGridViewCellStyle8;
            this.vSubTotal.HeaderText = "Subtotal";
            this.vSubTotal.Name = "vSubTotal";
            this.vSubTotal.ReadOnly = true;
            //
            // pnlCabeceraVentas
            //
            this.pnlCabeceraVentas.BackColor = System.Drawing.Color.White;
            this.pnlCabeceraVentas.Controls.Add(this.lbltotalventas);
            this.pnlCabeceraVentas.Controls.Add(this.btnexportarventas);
            this.pnlCabeceraVentas.Controls.Add(this.btnbuscarventas);
            this.pnlCabeceraVentas.Controls.Add(this.dtpfinventas);
            this.pnlCabeceraVentas.Controls.Add(this.lblfinventas);
            this.pnlCabeceraVentas.Controls.Add(this.dtpinicioventas);
            this.pnlCabeceraVentas.Controls.Add(this.lblinicioventas);
            this.pnlCabeceraVentas.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCabeceraVentas.Location = new System.Drawing.Point(10, 10);
            this.pnlCabeceraVentas.Name = "pnlCabeceraVentas";
            this.pnlCabeceraVentas.Size = new System.Drawing.Size(1227, 60);
            this.pnlCabeceraVentas.TabIndex = 0;
            //
            // lbltotalventas
            //
            this.lbltotalventas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbltotalventas.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.lbltotalventas.Location = new System.Drawing.Point(927, 16);
            this.lbltotalventas.Name = "lbltotalventas";
            this.lbltotalventas.Size = new System.Drawing.Size(290, 28);
            this.lbltotalventas.TabIndex = 6;
            this.lbltotalventas.Text = "Total: 0.00";
            this.lbltotalventas.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // btnexportarventas
            //
            this.btnexportarventas.BackColor = System.Drawing.Color.White;
            this.btnexportarventas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnexportarventas.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnexportarventas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnexportarventas.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnexportarventas.ForeColor = System.Drawing.Color.Black;
            this.btnexportarventas.IconChar = FontAwesome.Sharp.IconChar.FileExcel;
            this.btnexportarventas.IconColor = System.Drawing.Color.Green;
            this.btnexportarventas.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnexportarventas.IconSize = 18;
            this.btnexportarventas.Location = new System.Drawing.Point(620, 13);
            this.btnexportarventas.Name = "btnexportarventas";
            this.btnexportarventas.Size = new System.Drawing.Size(140, 34);
            this.btnexportarventas.TabIndex = 5;
            this.btnexportarventas.Text = "Exportar Excel";
            this.btnexportarventas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnexportarventas.UseVisualStyleBackColor = false;
            this.btnexportarventas.Click += new System.EventHandler(this.btnexportarventas_Click);
            //
            // btnbuscarventas
            //
            this.btnbuscarventas.BackColor = System.Drawing.Color.ForestGreen;
            this.btnbuscarventas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnbuscarventas.FlatAppearance.BorderSize = 0;
            this.btnbuscarventas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnbuscarventas.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnbuscarventas.ForeColor = System.Drawing.Color.White;
            this.btnbuscarventas.IconChar = FontAwesome.Sharp.IconChar.MagnifyingGlass;
            this.btnbuscarventas.IconColor = System.Drawing.Color.White;
            this.btnbuscarventas.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnbuscarventas.IconSize = 18;
            this.btnbuscarventas.Location = new System.Drawing.Point(500, 13);
            this.btnbuscarventas.Name = "btnbuscarventas";
            this.btnbuscarventas.Size = new System.Drawing.Size(110, 34);
            this.btnbuscarventas.TabIndex = 4;
            this.btnbuscarventas.Text = "Buscar";
            this.btnbuscarventas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnbuscarventas.UseVisualStyleBackColor = false;
            this.btnbuscarventas.Click += new System.EventHandler(this.btnbuscarventas_Click);
            //
            // dtpfinventas
            //
            this.dtpfinventas.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpfinventas.Location = new System.Drawing.Point(340, 15);
            this.dtpfinventas.Name = "dtpfinventas";
            this.dtpfinventas.Size = new System.Drawing.Size(140, 30);
            this.dtpfinventas.TabIndex = 3;
            //
            // lblfinventas
            //
            this.lblfinventas.AutoSize = true;
            this.lblfinventas.Location = new System.Drawing.Point(255, 19);
            this.lblfinventas.Name = "lblfinventas";
            this.lblfinventas.Size = new System.Drawing.Size(79, 23);
            this.lblfinventas.TabIndex = 2;
            this.lblfinventas.Text = "Fecha fin:";
            //
            // dtpinicioventas
            //
            this.dtpinicioventas.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpinicioventas.Location = new System.Drawing.Point(100, 15);
            this.dtpinicioventas.Name = "dtpinicioventas";
            this.dtpinicioventas.Size = new System.Drawing.Size(140, 30);
            this.dtpinicioventas.TabIndex = 1;
            //
            // lblinicioventas
            //
            this.lblinicioventas.AutoSize = true;
            this.lblinicioventas.Location = new System.Drawing.Point(0, 19);
            this.lblinicioventas.Name = "lblinicioventas";
            this.lblinicioventas.Size = new System.Drawing.Size(98, 23);
            this.lblinicioventas.TabIndex = 0;
            this.lblinicioventas.Text = "Fecha inicio:";
            //
            // frmReportes
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1255, 649);
            this.Controls.Add(this.tabReportes);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "frmReportes";
            this.Text = "frmReportes";
            this.Load += new System.EventHandler(this.frmReportes_Load);
            this.tabReportes.ResumeLayout(false);
            this.tabCompras.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvcompras)).EndInit();
            this.pnlCabeceraCompras.ResumeLayout(false);
            this.pnlCabeceraCompras.PerformLayout();
            this.tabVentas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvventas)).EndInit();
            this.pnlCabeceraVentas.ResumeLayout(false);
            this.pnlCabeceraVentas.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabReportes;
        private System.Windows.Forms.TabPage tabCompras;
        private System.Windows.Forms.TabPage tabVentas;
        private System.Windows.Forms.Panel pnlCabeceraCompras;
        private System.Windows.Forms.Label lbliniciocompras;
        private System.Windows.Forms.DateTimePicker dtpiniciocompras;
        private System.Windows.Forms.Label lblfincompras;
        private System.Windows.Forms.DateTimePicker dtpfincompras;
        private FontAwesome.Sharp.IconButton btnbuscarcompras;
        private FontAwesome.Sharp.IconButton btnexportarcompras;
        private System.Windows.Forms.Label lbltotalcompras;
        private System.Windows.Forms.DataGridView dgvcompras;
        private System.Windows.Forms.DataGridViewTextBoxColumn cFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn cTipoDocumento;
        private System.Windows.Forms.DataGridViewTextBoxColumn cNumeroDocumento;
        private System.Windows.Forms.DataGridViewTextBoxColumn cProveedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn cUsuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn cProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn cCategoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn cPrecioCompra;
        private System.Windows.Forms.DataGridViewTextBoxColumn cCantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn cSubTotal;
        private System.Windows.Forms.Panel pnlCabeceraVentas;
        private System.Windows.Forms.Label lblinicioventas;
        private System.Windows.Forms.DateTimePicker dtpinicioventas;
        private System.Windows.Forms.Label lblfinventas;
        private System.Windows.Forms.DateTimePicker dtpfinventas;
        private FontAwesome.Sharp.IconButton btnbuscarventas;
        private FontAwesome.Sharp.IconButton btnexportarventas;
        private System.Windows.Forms.Label lbltotalventas;
        private System.Windows.Forms.DataGridView dgvventas;
        private System.Windows.Forms.DataGridViewTextBoxColumn vFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn vTipoDocumento;
        private System.Windows.Forms.DataGridViewTextBoxColumn vNumeroDocumento;
        private System.Windows.Forms.DataGridViewTextBoxColumn vCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn vUsuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn vProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn vCategoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn vPrecioVenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn vCantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn vSubTotal;
    }
}
