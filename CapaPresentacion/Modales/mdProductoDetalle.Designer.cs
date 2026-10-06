namespace CapaPresentacion.Modales
{
    partial class mdProductoDetalle
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
            this.lbltitulo = new System.Windows.Forms.Label();
            this.lblcodigo = new System.Windows.Forms.Label();
            this.txtcodigo = new System.Windows.Forms.TextBox();
            this.lblnombre = new System.Windows.Forms.Label();
            this.txtnombre = new System.Windows.Forms.TextBox();
            this.lbldescripcion = new System.Windows.Forms.Label();
            this.txtdescripcion = new System.Windows.Forms.TextBox();
            this.lblcategoria = new System.Windows.Forms.Label();
            this.cbocategoria = new System.Windows.Forms.ComboBox();
            this.lblpreciocompra = new System.Windows.Forms.Label();
            this.txtpreciocompra = new System.Windows.Forms.NumericUpDown();
            this.lblprecioventa = new System.Windows.Forms.Label();
            this.txtprecioventa = new System.Windows.Forms.NumericUpDown();
            this.lblganancia = new System.Windows.Forms.Label();
            this.lblcantidad = new System.Windows.Forms.Label();
            this.txtcantidad = new System.Windows.Forms.NumericUpDown();
            this.lblestado = new System.Windows.Forms.Label();
            this.cboestado = new System.Windows.Forms.ComboBox();
            this.btnguardar = new FontAwesome.Sharp.IconButton();
            this.btncancelar = new FontAwesome.Sharp.IconButton();
            ((System.ComponentModel.ISupportInitialize)(this.txtpreciocompra)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtprecioventa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtcantidad)).BeginInit();
            this.SuspendLayout();
            //
            // lbltitulo
            //
            this.lbltitulo.AutoSize = true;
            this.lbltitulo.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold);
            this.lbltitulo.Location = new System.Drawing.Point(22, 16);
            this.lbltitulo.Name = "lbltitulo";
            this.lbltitulo.Size = new System.Drawing.Size(170, 32);
            this.lbltitulo.TabIndex = 0;
            this.lbltitulo.Text = "Nuevo producto";
            //
            // lblcodigo
            //
            this.lblcodigo.AutoSize = true;
            this.lblcodigo.Location = new System.Drawing.Point(22, 62);
            this.lblcodigo.Name = "lblcodigo";
            this.lblcodigo.Size = new System.Drawing.Size(56, 20);
            this.lblcodigo.TabIndex = 0;
            this.lblcodigo.Text = "Código";
            //
            // txtcodigo
            //
            this.txtcodigo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(244)))), ((int)(((byte)(246)))));
            this.txtcodigo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtcodigo.ForeColor = System.Drawing.Color.DimGray;
            this.txtcodigo.Location = new System.Drawing.Point(24, 84);
            this.txtcodigo.Name = "txtcodigo";
            this.txtcodigo.ReadOnly = true;
            this.txtcodigo.Size = new System.Drawing.Size(352, 30);
            this.txtcodigo.TabIndex = 0;
            this.txtcodigo.TabStop = false;
            this.txtcodigo.Text = "Se genera al guardar";
            //
            // lblnombre
            //
            this.lblnombre.AutoSize = true;
            this.lblnombre.Location = new System.Drawing.Point(22, 122);
            this.lblnombre.Name = "lblnombre";
            this.lblnombre.Size = new System.Drawing.Size(73, 20);
            this.lblnombre.TabIndex = 0;
            this.lblnombre.Text = "Nombre *";
            //
            // txtnombre
            //
            this.txtnombre.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtnombre.Location = new System.Drawing.Point(24, 144);
            this.txtnombre.MaxLength = 50;
            this.txtnombre.Name = "txtnombre";
            this.txtnombre.Size = new System.Drawing.Size(352, 30);
            this.txtnombre.TabIndex = 1;
            //
            // lbldescripcion
            //
            this.lbldescripcion.AutoSize = true;
            this.lbldescripcion.Location = new System.Drawing.Point(22, 182);
            this.lbldescripcion.Name = "lbldescripcion";
            this.lbldescripcion.Size = new System.Drawing.Size(96, 20);
            this.lbldescripcion.TabIndex = 0;
            this.lbldescripcion.Text = "Descripción *";
            //
            // txtdescripcion
            //
            this.txtdescripcion.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtdescripcion.Location = new System.Drawing.Point(24, 204);
            this.txtdescripcion.MaxLength = 50;
            this.txtdescripcion.Name = "txtdescripcion";
            this.txtdescripcion.Size = new System.Drawing.Size(352, 30);
            this.txtdescripcion.TabIndex = 2;
            //
            // lblcategoria
            //
            this.lblcategoria.AutoSize = true;
            this.lblcategoria.Location = new System.Drawing.Point(22, 242);
            this.lblcategoria.Name = "lblcategoria";
            this.lblcategoria.Size = new System.Drawing.Size(82, 20);
            this.lblcategoria.TabIndex = 0;
            this.lblcategoria.Text = "Categoría *";
            //
            // cbocategoria
            //
            this.cbocategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbocategoria.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbocategoria.FormattingEnabled = true;
            this.cbocategoria.Location = new System.Drawing.Point(24, 264);
            this.cbocategoria.Name = "cbocategoria";
            this.cbocategoria.Size = new System.Drawing.Size(352, 31);
            this.cbocategoria.TabIndex = 3;
            //
            // lblpreciocompra
            //
            this.lblpreciocompra.AutoSize = true;
            this.lblpreciocompra.Location = new System.Drawing.Point(22, 304);
            this.lblpreciocompra.Name = "lblpreciocompra";
            this.lblpreciocompra.Size = new System.Drawing.Size(107, 20);
            this.lblpreciocompra.TabIndex = 0;
            this.lblpreciocompra.Text = "Precio compra";
            //
            // txtpreciocompra
            //
            this.txtpreciocompra.DecimalPlaces = 2;
            this.txtpreciocompra.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtpreciocompra.Location = new System.Drawing.Point(24, 326);
            this.txtpreciocompra.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.txtpreciocompra.Name = "txtpreciocompra";
            this.txtpreciocompra.Size = new System.Drawing.Size(170, 30);
            this.txtpreciocompra.TabIndex = 4;
            this.txtpreciocompra.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtpreciocompra.ThousandsSeparator = true;
            this.txtpreciocompra.ValueChanged += new System.EventHandler(this.precio_ValueChanged);
            this.txtpreciocompra.Enter += new System.EventHandler(this.numerico_Enter);
            //
            // lblprecioventa
            //
            this.lblprecioventa.AutoSize = true;
            this.lblprecioventa.Location = new System.Drawing.Point(204, 304);
            this.lblprecioventa.Name = "lblprecioventa";
            this.lblprecioventa.Size = new System.Drawing.Size(105, 20);
            this.lblprecioventa.TabIndex = 0;
            this.lblprecioventa.Text = "Precio venta *";
            //
            // txtprecioventa
            //
            this.txtprecioventa.DecimalPlaces = 2;
            this.txtprecioventa.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtprecioventa.Location = new System.Drawing.Point(206, 326);
            this.txtprecioventa.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.txtprecioventa.Name = "txtprecioventa";
            this.txtprecioventa.Size = new System.Drawing.Size(170, 30);
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
            this.lblganancia.Location = new System.Drawing.Point(22, 360);
            this.lblganancia.Name = "lblganancia";
            this.lblganancia.Size = new System.Drawing.Size(180, 19);
            this.lblganancia.TabIndex = 0;
            this.lblganancia.Text = "Ganancia por unidad: —";
            //
            // lblcantidad
            //
            this.lblcantidad.AutoSize = true;
            this.lblcantidad.Location = new System.Drawing.Point(22, 390);
            this.lblcantidad.Name = "lblcantidad";
            this.lblcantidad.Size = new System.Drawing.Size(119, 20);
            this.lblcantidad.TabIndex = 0;
            this.lblcantidad.Text = "Cantidad inicial";
            //
            // txtcantidad
            //
            this.txtcantidad.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtcantidad.Location = new System.Drawing.Point(24, 412);
            this.txtcantidad.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.txtcantidad.Name = "txtcantidad";
            this.txtcantidad.Size = new System.Drawing.Size(170, 30);
            this.txtcantidad.TabIndex = 6;
            this.txtcantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtcantidad.ThousandsSeparator = true;
            this.txtcantidad.Enter += new System.EventHandler(this.numerico_Enter);
            //
            // lblestado
            //
            this.lblestado.AutoSize = true;
            this.lblestado.Location = new System.Drawing.Point(204, 390);
            this.lblestado.Name = "lblestado";
            this.lblestado.Size = new System.Drawing.Size(54, 20);
            this.lblestado.TabIndex = 0;
            this.lblestado.Text = "Estado";
            //
            // cboestado
            //
            this.cboestado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboestado.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboestado.FormattingEnabled = true;
            this.cboestado.Location = new System.Drawing.Point(206, 412);
            this.cboestado.Name = "cboestado";
            this.cboestado.Size = new System.Drawing.Size(170, 31);
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
            this.btnguardar.Location = new System.Drawing.Point(24, 466);
            this.btnguardar.Name = "btnguardar";
            this.btnguardar.Size = new System.Drawing.Size(228, 40);
            this.btnguardar.TabIndex = 8;
            this.btnguardar.Text = "Guardar";
            this.btnguardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnguardar.UseVisualStyleBackColor = false;
            this.btnguardar.Click += new System.EventHandler(this.btnguardar_Click);
            //
            // btncancelar
            //
            this.btncancelar.BackColor = System.Drawing.Color.White;
            this.btncancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btncancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btncancelar.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btncancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btncancelar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btncancelar.IconChar = FontAwesome.Sharp.IconChar.Xmark;
            this.btncancelar.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btncancelar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btncancelar.IconSize = 16;
            this.btncancelar.Location = new System.Drawing.Point(262, 466);
            this.btncancelar.Name = "btncancelar";
            this.btncancelar.Size = new System.Drawing.Size(114, 40);
            this.btncancelar.TabIndex = 9;
            this.btncancelar.Text = "Cancelar";
            this.btncancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btncancelar.UseVisualStyleBackColor = false;
            this.btncancelar.Click += new System.EventHandler(this.btncancelar_Click);
            //
            // mdProductoDetalle
            //
            this.AcceptButton = this.btnguardar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btncancelar;
            this.ClientSize = new System.Drawing.Size(400, 530);
            this.Controls.Add(this.btncancelar);
            this.Controls.Add(this.btnguardar);
            this.Controls.Add(this.cboestado);
            this.Controls.Add(this.lblestado);
            this.Controls.Add(this.txtcantidad);
            this.Controls.Add(this.lblcantidad);
            this.Controls.Add(this.lblganancia);
            this.Controls.Add(this.txtprecioventa);
            this.Controls.Add(this.lblprecioventa);
            this.Controls.Add(this.txtpreciocompra);
            this.Controls.Add(this.lblpreciocompra);
            this.Controls.Add(this.cbocategoria);
            this.Controls.Add(this.lblcategoria);
            this.Controls.Add(this.txtdescripcion);
            this.Controls.Add(this.lbldescripcion);
            this.Controls.Add(this.txtnombre);
            this.Controls.Add(this.lblnombre);
            this.Controls.Add(this.txtcodigo);
            this.Controls.Add(this.lblcodigo);
            this.Controls.Add(this.lbltitulo);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "mdProductoDetalle";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Agregar producto";
            this.Load += new System.EventHandler(this.mdProductoDetalle_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtpreciocompra)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtprecioventa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtcantidad)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbltitulo;
        private System.Windows.Forms.Label lblcodigo;
        private System.Windows.Forms.TextBox txtcodigo;
        private System.Windows.Forms.Label lblnombre;
        private System.Windows.Forms.TextBox txtnombre;
        private System.Windows.Forms.Label lbldescripcion;
        private System.Windows.Forms.TextBox txtdescripcion;
        private System.Windows.Forms.Label lblcategoria;
        private System.Windows.Forms.ComboBox cbocategoria;
        private System.Windows.Forms.Label lblpreciocompra;
        private System.Windows.Forms.NumericUpDown txtpreciocompra;
        private System.Windows.Forms.Label lblprecioventa;
        private System.Windows.Forms.NumericUpDown txtprecioventa;
        private System.Windows.Forms.Label lblganancia;
        private System.Windows.Forms.Label lblcantidad;
        private System.Windows.Forms.NumericUpDown txtcantidad;
        private System.Windows.Forms.Label lblestado;
        private System.Windows.Forms.ComboBox cboestado;
        private FontAwesome.Sharp.IconButton btnguardar;
        private FontAwesome.Sharp.IconButton btncancelar;
    }
}
