namespace CapaPresentacion
{
    partial class frmProducto
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
            this.pnlDetalle = new System.Windows.Forms.Panel();
            this.lbltitulo = new System.Windows.Forms.Label();
            this.lblmodo = new System.Windows.Forms.Label();
            this.lblcodigo = new System.Windows.Forms.Label();
            this.txtcodigo_producto = new System.Windows.Forms.TextBox();
            this.lblnombre = new System.Windows.Forms.Label();
            this.txtnombre_producto = new System.Windows.Forms.TextBox();
            this.lbldescripcion = new System.Windows.Forms.Label();
            this.txtproducto_descripcion = new System.Windows.Forms.TextBox();
            this.lblcategoria = new System.Windows.Forms.Label();
            this.cbocategoria = new System.Windows.Forms.ComboBox();
            this.lblpreciocompra = new System.Windows.Forms.Label();
            this.txtpreciocompra = new System.Windows.Forms.NumericUpDown();
            this.lblprecioventa = new System.Windows.Forms.Label();
            this.txtprecioventa = new System.Windows.Forms.NumericUpDown();
            this.lblganancia = new System.Windows.Forms.Label();
            this.lblestado = new System.Windows.Forms.Label();
            this.cboestado = new System.Windows.Forms.ComboBox();
            this.lblcantidad = new System.Windows.Forms.Label();
            this.txtcantidad = new System.Windows.Forms.NumericUpDown();
            this.btnguardar = new FontAwesome.Sharp.IconButton();
            this.btnlimpiar = new FontAwesome.Sharp.IconButton();
            this.btneliminar = new FontAwesome.Sharp.IconButton();
            this.txtid = new System.Windows.Forms.TextBox();
            this.txtindice = new System.Windows.Forms.TextBox();
            this.pnlLista = new System.Windows.Forms.Panel();
            this.dgvdata = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdCategoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Categoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Stock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrecioCompra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrecioVenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EstadoValor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlSeparador = new System.Windows.Forms.Panel();
            this.pnlCabecera = new System.Windows.Forms.Panel();
            this.lbllista = new System.Windows.Forms.Label();
            this.btnexportar = new FontAwesome.Sharp.IconButton();
            this.lblbuscar = new System.Windows.Forms.Label();
            this.cbobusqueda = new System.Windows.Forms.ComboBox();
            this.txtbusqueda = new System.Windows.Forms.TextBox();
            this.btnbuscar_producto = new FontAwesome.Sharp.IconButton();
            this.btnlimpiarbuscador = new FontAwesome.Sharp.IconButton();
            this.pnlDetalle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtpreciocompra)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtprecioventa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtcantidad)).BeginInit();
            this.pnlLista.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvdata)).BeginInit();
            this.pnlCabecera.SuspendLayout();
            this.SuspendLayout();
            //
            // pnlDetalle
            //
            this.pnlDetalle.BackColor = System.Drawing.Color.White;
            this.pnlDetalle.Controls.Add(this.lbltitulo);
            this.pnlDetalle.Controls.Add(this.lblmodo);
            this.pnlDetalle.Controls.Add(this.lblcodigo);
            this.pnlDetalle.Controls.Add(this.txtcodigo_producto);
            this.pnlDetalle.Controls.Add(this.lblnombre);
            this.pnlDetalle.Controls.Add(this.txtnombre_producto);
            this.pnlDetalle.Controls.Add(this.lbldescripcion);
            this.pnlDetalle.Controls.Add(this.txtproducto_descripcion);
            this.pnlDetalle.Controls.Add(this.lblcategoria);
            this.pnlDetalle.Controls.Add(this.cbocategoria);
            this.pnlDetalle.Controls.Add(this.lblpreciocompra);
            this.pnlDetalle.Controls.Add(this.txtpreciocompra);
            this.pnlDetalle.Controls.Add(this.lblprecioventa);
            this.pnlDetalle.Controls.Add(this.txtprecioventa);
            this.pnlDetalle.Controls.Add(this.lblganancia);
            this.pnlDetalle.Controls.Add(this.lblcantidad);
            this.pnlDetalle.Controls.Add(this.txtcantidad);
            this.pnlDetalle.Controls.Add(this.lblestado);
            this.pnlDetalle.Controls.Add(this.cboestado);
            this.pnlDetalle.Controls.Add(this.btnguardar);
            this.pnlDetalle.Controls.Add(this.btnlimpiar);
            this.pnlDetalle.Controls.Add(this.btneliminar);
            this.pnlDetalle.Controls.Add(this.txtid);
            this.pnlDetalle.Controls.Add(this.txtindice);
            this.pnlDetalle.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlDetalle.Location = new System.Drawing.Point(0, 0);
            this.pnlDetalle.Name = "pnlDetalle";
            this.pnlDetalle.Size = new System.Drawing.Size(320, 592);
            this.pnlDetalle.TabIndex = 0;
            //
            // lbltitulo
            //
            this.lbltitulo.AutoSize = true;
            this.lbltitulo.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltitulo.Location = new System.Drawing.Point(20, 14);
            this.lbltitulo.Name = "lbltitulo";
            this.lbltitulo.Size = new System.Drawing.Size(200, 32);
            this.lbltitulo.TabIndex = 0;
            this.lbltitulo.Text = "Detalle del producto";
            //
            // lblmodo
            //
            this.lblmodo.AutoSize = true;
            this.lblmodo.ForeColor = System.Drawing.Color.SeaGreen;
            this.lblmodo.Location = new System.Drawing.Point(22, 46);
            this.lblmodo.Name = "lblmodo";
            this.lblmodo.Size = new System.Drawing.Size(110, 20);
            this.lblmodo.TabIndex = 0;
            this.lblmodo.Text = "Nuevo producto";
            //
            // lblcodigo
            //
            this.lblcodigo.AutoSize = true;
            this.lblcodigo.Location = new System.Drawing.Point(22, 78);
            this.lblcodigo.Name = "lblcodigo";
            this.lblcodigo.Size = new System.Drawing.Size(56, 20);
            this.lblcodigo.TabIndex = 0;
            this.lblcodigo.Text = "Código";
            //
            // txtcodigo_producto
            //
            this.txtcodigo_producto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(244)))), ((int)(((byte)(246)))));
            this.txtcodigo_producto.ForeColor = System.Drawing.Color.DimGray;
            this.txtcodigo_producto.Location = new System.Drawing.Point(24, 100);
            this.txtcodigo_producto.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtcodigo_producto.Name = "txtcodigo_producto";
            this.txtcodigo_producto.ReadOnly = true;
            this.txtcodigo_producto.Size = new System.Drawing.Size(272, 27);
            this.txtcodigo_producto.TabIndex = 0;
            this.txtcodigo_producto.TabStop = false;
            this.txtcodigo_producto.Text = "Se genera al guardar";
            //
            // lblnombre
            //
            this.lblnombre.AutoSize = true;
            this.lblnombre.Location = new System.Drawing.Point(22, 136);
            this.lblnombre.Name = "lblnombre";
            this.lblnombre.Size = new System.Drawing.Size(73, 20);
            this.lblnombre.TabIndex = 0;
            this.lblnombre.Text = "Nombre *";
            //
            // txtnombre_producto
            //
            this.txtnombre_producto.Location = new System.Drawing.Point(24, 158);
            this.txtnombre_producto.MaxLength = 50;
            this.txtnombre_producto.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtnombre_producto.Name = "txtnombre_producto";
            this.txtnombre_producto.Size = new System.Drawing.Size(272, 27);
            this.txtnombre_producto.TabIndex = 1;
            //
            // lbldescripcion
            //
            this.lbldescripcion.AutoSize = true;
            this.lbldescripcion.Location = new System.Drawing.Point(22, 194);
            this.lbldescripcion.Name = "lbldescripcion";
            this.lbldescripcion.Size = new System.Drawing.Size(96, 20);
            this.lbldescripcion.TabIndex = 0;
            this.lbldescripcion.Text = "Descripción *";
            //
            // txtproducto_descripcion
            //
            this.txtproducto_descripcion.Location = new System.Drawing.Point(24, 216);
            this.txtproducto_descripcion.MaxLength = 50;
            this.txtproducto_descripcion.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtproducto_descripcion.Name = "txtproducto_descripcion";
            this.txtproducto_descripcion.Size = new System.Drawing.Size(272, 27);
            this.txtproducto_descripcion.TabIndex = 2;
            //
            // lblcategoria
            //
            this.lblcategoria.AutoSize = true;
            this.lblcategoria.Location = new System.Drawing.Point(22, 252);
            this.lblcategoria.Name = "lblcategoria";
            this.lblcategoria.Size = new System.Drawing.Size(82, 20);
            this.lblcategoria.TabIndex = 0;
            this.lblcategoria.Text = "Categoría *";
            //
            // cbocategoria
            //
            this.cbocategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbocategoria.FormattingEnabled = true;
            this.cbocategoria.Location = new System.Drawing.Point(24, 274);
            this.cbocategoria.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbocategoria.Name = "cbocategoria";
            this.cbocategoria.Size = new System.Drawing.Size(272, 28);
            this.cbocategoria.TabIndex = 3;
            //
            // lblpreciocompra
            //
            this.lblpreciocompra.AutoSize = true;
            this.lblpreciocompra.Location = new System.Drawing.Point(22, 312);
            this.lblpreciocompra.Name = "lblpreciocompra";
            this.lblpreciocompra.Size = new System.Drawing.Size(107, 20);
            this.lblpreciocompra.TabIndex = 0;
            this.lblpreciocompra.Text = "Precio compra";
            //
            // txtpreciocompra
            //
            this.txtpreciocompra.DecimalPlaces = 2;
            this.txtpreciocompra.Location = new System.Drawing.Point(24, 334);
            this.txtpreciocompra.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.txtpreciocompra.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtpreciocompra.Name = "txtpreciocompra";
            this.txtpreciocompra.Size = new System.Drawing.Size(130, 27);
            this.txtpreciocompra.TabIndex = 4;
            this.txtpreciocompra.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtpreciocompra.ThousandsSeparator = true;
            this.txtpreciocompra.ValueChanged += new System.EventHandler(this.precio_ValueChanged);
            this.txtpreciocompra.Enter += new System.EventHandler(this.numerico_Enter);
            //
            // lblprecioventa
            //
            this.lblprecioventa.AutoSize = true;
            this.lblprecioventa.Location = new System.Drawing.Point(164, 312);
            this.lblprecioventa.Name = "lblprecioventa";
            this.lblprecioventa.Size = new System.Drawing.Size(105, 20);
            this.lblprecioventa.TabIndex = 0;
            this.lblprecioventa.Text = "Precio venta *";
            //
            // txtprecioventa
            //
            this.txtprecioventa.DecimalPlaces = 2;
            this.txtprecioventa.Location = new System.Drawing.Point(166, 334);
            this.txtprecioventa.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.txtprecioventa.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtprecioventa.Name = "txtprecioventa";
            this.txtprecioventa.Size = new System.Drawing.Size(130, 27);
            this.txtprecioventa.TabIndex = 5;
            this.txtprecioventa.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtprecioventa.ThousandsSeparator = true;
            this.txtprecioventa.ValueChanged += new System.EventHandler(this.precio_ValueChanged);
            this.txtprecioventa.Enter += new System.EventHandler(this.numerico_Enter);
            //
            // lblganancia
            //
            this.lblganancia.AutoSize = true;
            this.lblganancia.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblganancia.ForeColor = System.Drawing.Color.DimGray;
            this.lblganancia.Location = new System.Drawing.Point(22, 366);
            this.lblganancia.Name = "lblganancia";
            this.lblganancia.Size = new System.Drawing.Size(180, 19);
            this.lblganancia.TabIndex = 0;
            this.lblganancia.Text = "Ganancia por unidad: —";
            //
            // lblcantidad
            // 
            this.lblcantidad.AutoSize = true;
            this.lblcantidad.Location = new System.Drawing.Point(22, 394);
            this.lblcantidad.Name = "lblcantidad";
            this.lblcantidad.Size = new System.Drawing.Size(119, 20);
            this.lblcantidad.TabIndex = 0;
            this.lblcantidad.Text = "Cantidad inicial";
            // 
            // txtcantidad
            // 
            this.txtcantidad.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtcantidad.Location = new System.Drawing.Point(24, 416);
            this.txtcantidad.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.txtcantidad.Name = "txtcantidad";
            this.txtcantidad.Size = new System.Drawing.Size(130, 30);
            this.txtcantidad.TabIndex = 6;
            this.txtcantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtcantidad.ThousandsSeparator = true;
            this.txtcantidad.Enter += new System.EventHandler(this.numerico_Enter);
            //
            // lblestado
            //
            this.lblestado.AutoSize = true;
            this.lblestado.Location = new System.Drawing.Point(164, 394);
            this.lblestado.Name = "lblestado";
            this.lblestado.Size = new System.Drawing.Size(54, 20);
            this.lblestado.TabIndex = 0;
            this.lblestado.Text = "Estado";
            //
            // cboestado
            //
            this.cboestado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboestado.FormattingEnabled = true;
            this.cboestado.Location = new System.Drawing.Point(166, 416);
            this.cboestado.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboestado.Name = "cboestado";
            this.cboestado.Size = new System.Drawing.Size(130, 28);
            this.cboestado.TabIndex = 7;
            //
            // btnguardar
            //
            this.btnguardar.BackColor = System.Drawing.Color.ForestGreen;
            this.btnguardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnguardar.FlatAppearance.BorderSize = 0;
            this.btnguardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnguardar.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btnguardar.ForeColor = System.Drawing.Color.White;
            this.btnguardar.IconChar = FontAwesome.Sharp.IconChar.FloppyDisk;
            this.btnguardar.IconColor = System.Drawing.Color.White;
            this.btnguardar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnguardar.IconSize = 18;
            this.btnguardar.Location = new System.Drawing.Point(24, 462);
            this.btnguardar.Name = "btnguardar";
            this.btnguardar.Size = new System.Drawing.Size(272, 40);
            this.btnguardar.TabIndex = 8;
            this.btnguardar.Text = "Guardar";
            this.btnguardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnguardar.UseVisualStyleBackColor = false;
            this.btnguardar.Click += new System.EventHandler(this.btnguardar_Click);
            //
            // btnlimpiar
            //
            this.btnlimpiar.BackColor = System.Drawing.Color.White;
            this.btnlimpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnlimpiar.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnlimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnlimpiar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnlimpiar.IconChar = FontAwesome.Sharp.IconChar.Plus;
            this.btnlimpiar.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnlimpiar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnlimpiar.IconSize = 16;
            this.btnlimpiar.Location = new System.Drawing.Point(24, 512);
            this.btnlimpiar.Name = "btnlimpiar";
            this.btnlimpiar.Size = new System.Drawing.Size(131, 36);
            this.btnlimpiar.TabIndex = 9;
            this.btnlimpiar.Text = "Nuevo";
            this.btnlimpiar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnlimpiar.UseVisualStyleBackColor = false;
            this.btnlimpiar.Click += new System.EventHandler(this.btnlimpiar_Click);
            //
            // btneliminar
            //
            this.btneliminar.BackColor = System.Drawing.Color.Firebrick;
            this.btneliminar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btneliminar.Enabled = false;
            this.btneliminar.FlatAppearance.BorderSize = 0;
            this.btneliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btneliminar.ForeColor = System.Drawing.Color.White;
            this.btneliminar.IconChar = FontAwesome.Sharp.IconChar.Ban;
            this.btneliminar.IconColor = System.Drawing.Color.White;
            this.btneliminar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btneliminar.IconSize = 16;
            this.btneliminar.Location = new System.Drawing.Point(165, 512);
            this.btneliminar.Name = "btneliminar";
            this.btneliminar.Size = new System.Drawing.Size(131, 36);
            this.btneliminar.TabIndex = 10;
            this.btneliminar.Text = "Dar de baja";
            this.btneliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btneliminar.UseVisualStyleBackColor = false;
            this.btneliminar.Click += new System.EventHandler(this.btneliminar_Click);
            //
            // txtid
            //
            this.txtid.Location = new System.Drawing.Point(250, 20);
            this.txtid.Name = "txtid";
            this.txtid.Size = new System.Drawing.Size(20, 27);
            this.txtid.TabIndex = 0;
            this.txtid.TabStop = false;
            this.txtid.Text = "0";
            this.txtid.Visible = false;
            //
            // txtindice
            //
            this.txtindice.Location = new System.Drawing.Point(274, 20);
            this.txtindice.Name = "txtindice";
            this.txtindice.Size = new System.Drawing.Size(20, 27);
            this.txtindice.TabIndex = 0;
            this.txtindice.TabStop = false;
            this.txtindice.Text = "-1";
            this.txtindice.Visible = false;
            //
            // pnlLista
            //
            this.pnlLista.Controls.Add(this.dgvdata);
            this.pnlLista.Controls.Add(this.pnlSeparador);
            this.pnlLista.Controls.Add(this.pnlCabecera);
            this.pnlLista.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLista.Location = new System.Drawing.Point(320, 0);
            this.pnlLista.Name = "pnlLista";
            this.pnlLista.Padding = new System.Windows.Forms.Padding(16);
            this.pnlLista.Size = new System.Drawing.Size(1169, 592);
            this.pnlLista.TabIndex = 1;
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
            this.Id,
            this.Codigo,
            this.Nombre,
            this.Descripcion,
            this.IdCategoria,
            this.Categoria,
            this.Stock,
            this.PrecioCompra,
            this.PrecioVenta,
            this.EstadoValor,
            this.Estado});
            this.dgvdata.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(6, 0, 6, 0);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(231)))), ((int)(((byte)(221)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvdata.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvdata.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvdata.EnableHeadersVisualStyles = false;
            this.dgvdata.GridColor = System.Drawing.Color.Gainsboro;
            this.dgvdata.Location = new System.Drawing.Point(16, 90);
            this.dgvdata.MultiSelect = false;
            this.dgvdata.Name = "dgvdata";
            this.dgvdata.ReadOnly = true;
            this.dgvdata.RowHeadersVisible = false;
            this.dgvdata.RowHeadersWidth = 51;
            this.dgvdata.RowTemplate.Height = 32;
            this.dgvdata.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvdata.Size = new System.Drawing.Size(1137, 486);
            this.dgvdata.TabIndex = 2;
            this.dgvdata.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvdata_CellClick);
            this.dgvdata.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvdata_CellFormatting);
            //
            // Id
            //
            this.Id.HeaderText = "Id";
            this.Id.MinimumWidth = 6;
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            //
            // Codigo
            //
            this.Codigo.FillWeight = 70F;
            this.Codigo.HeaderText = "Código";
            this.Codigo.MinimumWidth = 6;
            this.Codigo.Name = "Codigo";
            this.Codigo.ReadOnly = true;
            //
            // Nombre
            //
            this.Nombre.FillWeight = 150F;
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.MinimumWidth = 6;
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            //
            // Descripcion
            //
            this.Descripcion.FillWeight = 160F;
            this.Descripcion.HeaderText = "Descripción";
            this.Descripcion.MinimumWidth = 6;
            this.Descripcion.Name = "Descripcion";
            this.Descripcion.ReadOnly = true;
            //
            // IdCategoria
            //
            this.IdCategoria.HeaderText = "IdCategoria";
            this.IdCategoria.MinimumWidth = 6;
            this.IdCategoria.Name = "IdCategoria";
            this.IdCategoria.ReadOnly = true;
            this.IdCategoria.Visible = false;
            //
            // Categoria
            //
            this.Categoria.HeaderText = "Categoría";
            this.Categoria.MinimumWidth = 6;
            this.Categoria.Name = "Categoria";
            this.Categoria.ReadOnly = true;
            //
            // Stock
            //
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Stock.DefaultCellStyle = dataGridViewCellStyle4;
            this.Stock.FillWeight = 55F;
            this.Stock.HeaderText = "Stock";
            this.Stock.MinimumWidth = 6;
            this.Stock.Name = "Stock";
            this.Stock.ReadOnly = true;
            //
            // PrecioCompra
            //
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N2";
            this.PrecioCompra.DefaultCellStyle = dataGridViewCellStyle5;
            this.PrecioCompra.FillWeight = 85F;
            this.PrecioCompra.HeaderText = "Precio compra";
            this.PrecioCompra.MinimumWidth = 6;
            this.PrecioCompra.Name = "PrecioCompra";
            this.PrecioCompra.ReadOnly = true;
            //
            // PrecioVenta
            //
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N2";
            this.PrecioVenta.DefaultCellStyle = dataGridViewCellStyle6;
            this.PrecioVenta.FillWeight = 85F;
            this.PrecioVenta.HeaderText = "Precio venta";
            this.PrecioVenta.MinimumWidth = 6;
            this.PrecioVenta.Name = "PrecioVenta";
            this.PrecioVenta.ReadOnly = true;
            //
            // EstadoValor
            //
            this.EstadoValor.HeaderText = "EstadoValor";
            this.EstadoValor.MinimumWidth = 6;
            this.EstadoValor.Name = "EstadoValor";
            this.EstadoValor.ReadOnly = true;
            this.EstadoValor.Visible = false;
            //
            // Estado
            //
            this.Estado.FillWeight = 70F;
            this.Estado.HeaderText = "Estado";
            this.Estado.MinimumWidth = 6;
            this.Estado.Name = "Estado";
            this.Estado.ReadOnly = true;
            //
            // pnlSeparador
            //
            this.pnlSeparador.BackColor = System.Drawing.Color.Transparent;
            this.pnlSeparador.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSeparador.Location = new System.Drawing.Point(16, 78);
            this.pnlSeparador.Name = "pnlSeparador";
            this.pnlSeparador.Size = new System.Drawing.Size(1137, 12);
            this.pnlSeparador.TabIndex = 1;
            //
            // pnlCabecera
            //
            this.pnlCabecera.BackColor = System.Drawing.Color.White;
            this.pnlCabecera.Controls.Add(this.lbllista);
            this.pnlCabecera.Controls.Add(this.btnexportar);
            this.pnlCabecera.Controls.Add(this.lblbuscar);
            this.pnlCabecera.Controls.Add(this.cbobusqueda);
            this.pnlCabecera.Controls.Add(this.txtbusqueda);
            this.pnlCabecera.Controls.Add(this.btnbuscar_producto);
            this.pnlCabecera.Controls.Add(this.btnlimpiarbuscador);
            this.pnlCabecera.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCabecera.Location = new System.Drawing.Point(16, 16);
            this.pnlCabecera.Name = "pnlCabecera";
            this.pnlCabecera.Size = new System.Drawing.Size(1137, 62);
            this.pnlCabecera.TabIndex = 0;
            //
            // lbllista
            //
            this.lbllista.AutoSize = true;
            this.lbllista.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold);
            this.lbllista.Location = new System.Drawing.Point(14, 14);
            this.lbllista.Name = "lbllista";
            this.lbllista.Size = new System.Drawing.Size(190, 32);
            this.lbllista.TabIndex = 0;
            this.lbllista.Text = "Lista de productos";
            //
            // btnexportar
            //
            this.btnexportar.BackColor = System.Drawing.Color.White;
            this.btnexportar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnexportar.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnexportar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnexportar.ForeColor = System.Drawing.Color.Black;
            this.btnexportar.IconChar = FontAwesome.Sharp.IconChar.FileExcel;
            this.btnexportar.IconColor = System.Drawing.Color.Green;
            this.btnexportar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnexportar.IconSize = 18;
            this.btnexportar.Location = new System.Drawing.Point(226, 14);
            this.btnexportar.Name = "btnexportar";
            this.btnexportar.Size = new System.Drawing.Size(150, 34);
            this.btnexportar.TabIndex = 0;
            this.btnexportar.Text = "Exportar Excel";
            this.btnexportar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnexportar.UseVisualStyleBackColor = false;
            this.btnexportar.Click += new System.EventHandler(this.btnexportar_Click);
            //
            // lblbuscar
            //
            this.lblbuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblbuscar.AutoSize = true;
            this.lblbuscar.Location = new System.Drawing.Point(626, 21);
            this.lblbuscar.Name = "lblbuscar";
            this.lblbuscar.Size = new System.Drawing.Size(81, 20);
            this.lblbuscar.TabIndex = 0;
            this.lblbuscar.Text = "Buscar por:";
            //
            // cbobusqueda
            //
            this.cbobusqueda.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbobusqueda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbobusqueda.FormattingEnabled = true;
            this.cbobusqueda.Location = new System.Drawing.Point(712, 17);
            this.cbobusqueda.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbobusqueda.Name = "cbobusqueda";
            this.cbobusqueda.Size = new System.Drawing.Size(140, 28);
            this.cbobusqueda.TabIndex = 1;
            //
            // txtbusqueda
            //
            this.txtbusqueda.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtbusqueda.Location = new System.Drawing.Point(860, 18);
            this.txtbusqueda.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtbusqueda.Name = "txtbusqueda";
            this.txtbusqueda.Size = new System.Drawing.Size(180, 27);
            this.txtbusqueda.TabIndex = 2;
            this.txtbusqueda.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtbusqueda_KeyDown);
            //
            // btnbuscar_producto
            //
            this.btnbuscar_producto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnbuscar_producto.BackColor = System.Drawing.Color.White;
            this.btnbuscar_producto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnbuscar_producto.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnbuscar_producto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnbuscar_producto.IconChar = FontAwesome.Sharp.IconChar.MagnifyingGlass;
            this.btnbuscar_producto.IconColor = System.Drawing.Color.Black;
            this.btnbuscar_producto.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnbuscar_producto.IconSize = 18;
            this.btnbuscar_producto.Location = new System.Drawing.Point(1046, 16);
            this.btnbuscar_producto.Name = "btnbuscar_producto";
            this.btnbuscar_producto.Size = new System.Drawing.Size(38, 30);
            this.btnbuscar_producto.TabIndex = 3;
            this.btnbuscar_producto.UseVisualStyleBackColor = false;
            this.btnbuscar_producto.Click += new System.EventHandler(this.btnbuscar_producto_Click);
            //
            // btnlimpiarbuscador
            //
            this.btnlimpiarbuscador.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnlimpiarbuscador.BackColor = System.Drawing.Color.White;
            this.btnlimpiarbuscador.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnlimpiarbuscador.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnlimpiarbuscador.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnlimpiarbuscador.IconChar = FontAwesome.Sharp.IconChar.Broom;
            this.btnlimpiarbuscador.IconColor = System.Drawing.Color.Black;
            this.btnlimpiarbuscador.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnlimpiarbuscador.IconSize = 18;
            this.btnlimpiarbuscador.Location = new System.Drawing.Point(1088, 16);
            this.btnlimpiarbuscador.Name = "btnlimpiarbuscador";
            this.btnlimpiarbuscador.Size = new System.Drawing.Size(38, 30);
            this.btnlimpiarbuscador.TabIndex = 4;
            this.btnlimpiarbuscador.UseVisualStyleBackColor = false;
            this.btnlimpiarbuscador.Click += new System.EventHandler(this.btnlimpiarbuscador_Click);
            //
            // frmProducto
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1489, 592);
            this.Controls.Add(this.pnlLista);
            this.Controls.Add(this.pnlDetalle);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "frmProducto";
            this.Text = "frmProducto";
            this.Load += new System.EventHandler(this.frmProducto_Load);
            this.pnlDetalle.ResumeLayout(false);
            this.pnlDetalle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtpreciocompra)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtprecioventa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtcantidad)).EndInit();
            this.pnlLista.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvdata)).EndInit();
            this.pnlCabecera.ResumeLayout(false);
            this.pnlCabecera.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlDetalle;
        private System.Windows.Forms.Label lbltitulo;
        private System.Windows.Forms.Label lblmodo;
        private System.Windows.Forms.Label lblcodigo;
        private System.Windows.Forms.TextBox txtcodigo_producto;
        private System.Windows.Forms.Label lblnombre;
        private System.Windows.Forms.TextBox txtnombre_producto;
        private System.Windows.Forms.Label lbldescripcion;
        private System.Windows.Forms.TextBox txtproducto_descripcion;
        private System.Windows.Forms.Label lblcategoria;
        private System.Windows.Forms.ComboBox cbocategoria;
        private System.Windows.Forms.Label lblpreciocompra;
        private System.Windows.Forms.NumericUpDown txtpreciocompra;
        private System.Windows.Forms.Label lblprecioventa;
        private System.Windows.Forms.NumericUpDown txtprecioventa;
        private System.Windows.Forms.Label lblcantidad;
        private System.Windows.Forms.NumericUpDown txtcantidad;
        private System.Windows.Forms.Label lblganancia;
        private System.Windows.Forms.Label lblestado;
        private System.Windows.Forms.ComboBox cboestado;
        private FontAwesome.Sharp.IconButton btnguardar;
        private FontAwesome.Sharp.IconButton btnlimpiar;
        private FontAwesome.Sharp.IconButton btneliminar;
        private System.Windows.Forms.TextBox txtid;
        private System.Windows.Forms.TextBox txtindice;
        private System.Windows.Forms.Panel pnlLista;
        private System.Windows.Forms.DataGridView dgvdata;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdCategoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn Categoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn Stock;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrecioCompra;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrecioVenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn EstadoValor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Estado;
        private System.Windows.Forms.Panel pnlSeparador;
        private System.Windows.Forms.Panel pnlCabecera;
        private System.Windows.Forms.Label lbllista;
        private FontAwesome.Sharp.IconButton btnexportar;
        private System.Windows.Forms.Label lblbuscar;
        private System.Windows.Forms.ComboBox cbobusqueda;
        private System.Windows.Forms.TextBox txtbusqueda;
        private FontAwesome.Sharp.IconButton btnbuscar_producto;
        private FontAwesome.Sharp.IconButton btnlimpiarbuscador;
    }
}
