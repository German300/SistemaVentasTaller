namespace CapaPresentacion
{
    partial class frmUsuarios
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
            this.btnagregar = new FontAwesome.Sharp.IconButton();
            this.btnbaja = new FontAwesome.Sharp.IconButton();
            this.dgvdata = new System.Windows.Forms.DataGridView();
            this.btnseleccionar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Documento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NombreCompleto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Correo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Clave = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdRol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EstadoValor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label10 = new System.Windows.Forms.Label();
            this.lblfiltros = new System.Windows.Forms.Label();
            this.lblrolfiltro = new System.Windows.Forms.Label();
            this.cborolfiltro = new System.Windows.Forms.ComboBox();
            this.lblestadofiltro = new System.Windows.Forms.Label();
            this.cboestadofiltro = new System.Windows.Forms.ComboBox();
            this.txtbusqueda = new System.Windows.Forms.TextBox();
            this.btnlimpiarbuscador = new FontAwesome.Sharp.IconButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvdata)).BeginInit();
            this.SuspendLayout();
            //
            // btnagregar
            //
            this.btnagregar.BackColor = System.Drawing.Color.ForestGreen;
            this.btnagregar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnagregar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnagregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnagregar.ForeColor = System.Drawing.Color.White;
            this.btnagregar.IconChar = FontAwesome.Sharp.IconChar.UserPlus;
            this.btnagregar.IconColor = System.Drawing.Color.White;
            this.btnagregar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnagregar.IconSize = 16;
            this.btnagregar.Location = new System.Drawing.Point(260, 33);
            this.btnagregar.Name = "btnagregar";
            this.btnagregar.Size = new System.Drawing.Size(175, 34);
            this.btnagregar.TabIndex = 1;
            this.btnagregar.Text = "Agregar usuario";
            this.btnagregar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnagregar.UseVisualStyleBackColor = false;
            this.btnagregar.Click += new System.EventHandler(this.btnagregar_Click);
            //
            // btnbaja
            //
            this.btnbaja.BackColor = System.Drawing.Color.Firebrick;
            this.btnbaja.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnbaja.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnbaja.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnbaja.ForeColor = System.Drawing.Color.White;
            this.btnbaja.IconChar = FontAwesome.Sharp.IconChar.UserMinus;
            this.btnbaja.IconColor = System.Drawing.Color.White;
            this.btnbaja.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnbaja.IconSize = 16;
            this.btnbaja.Location = new System.Drawing.Point(445, 33);
            this.btnbaja.Name = "btnbaja";
            this.btnbaja.Size = new System.Drawing.Size(150, 34);
            this.btnbaja.TabIndex = 2;
            this.btnbaja.Text = "Dar de baja";
            this.btnbaja.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnbaja.UseVisualStyleBackColor = false;
            this.btnbaja.Click += new System.EventHandler(this.btnbaja_Click);
            //
            // dgvdata
            //
            this.dgvdata.AllowUserToAddRows = false;
            this.dgvdata.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(2);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvdata.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvdata.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvdata.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.btnseleccionar,
            this.Id,
            this.Documento,
            this.NombreCompleto,
            this.Correo,
            this.Clave,
            this.IdRol,
            this.Rol,
            this.EstadoValor,
            this.Estado});
            this.dgvdata.Location = new System.Drawing.Point(20, 150);
            this.dgvdata.MultiSelect = false;
            this.dgvdata.Name = "dgvdata";
            this.dgvdata.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvdata.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvdata.RowHeadersWidth = 51;
            this.dgvdata.RowTemplate.Height = 28;
            this.dgvdata.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvdata.Size = new System.Drawing.Size(1396, 443);
            this.dgvdata.TabIndex = 3;
            this.dgvdata.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvdata_CellContentClick);
            this.dgvdata.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvdata_CellPainting);
            this.dgvdata.SelectionChanged += new System.EventHandler(this.dgvdata_SelectionChanged);
            //
            // btnseleccionar
            //
            this.btnseleccionar.HeaderText = "";
            this.btnseleccionar.MinimumWidth = 6;
            this.btnseleccionar.Name = "btnseleccionar";
            this.btnseleccionar.ReadOnly = true;
            this.btnseleccionar.ToolTipText = "Editar usuario";
            this.btnseleccionar.Width = 30;
            //
            // Id
            //
            this.Id.HeaderText = "IdUsuario";
            this.Id.MinimumWidth = 6;
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            this.Id.Width = 125;
            //
            // Documento
            //
            this.Documento.HeaderText = "Nro Documento";
            this.Documento.MinimumWidth = 6;
            this.Documento.Name = "Documento";
            this.Documento.ReadOnly = true;
            this.Documento.Width = 150;
            //
            // NombreCompleto
            //
            this.NombreCompleto.HeaderText = "Nombre Completo";
            this.NombreCompleto.MinimumWidth = 6;
            this.NombreCompleto.Name = "NombreCompleto";
            this.NombreCompleto.ReadOnly = true;
            this.NombreCompleto.Width = 180;
            //
            // Correo
            //
            this.Correo.HeaderText = "Correo";
            this.Correo.MinimumWidth = 6;
            this.Correo.Name = "Correo";
            this.Correo.ReadOnly = true;
            this.Correo.Width = 150;
            //
            // Clave
            //
            this.Clave.HeaderText = "Clave";
            this.Clave.MinimumWidth = 6;
            this.Clave.Name = "Clave";
            this.Clave.ReadOnly = true;
            this.Clave.Visible = false;
            this.Clave.Width = 125;
            //
            // IdRol
            //
            this.IdRol.HeaderText = "IdRol";
            this.IdRol.MinimumWidth = 6;
            this.IdRol.Name = "IdRol";
            this.IdRol.ReadOnly = true;
            this.IdRol.Visible = false;
            this.IdRol.Width = 125;
            //
            // Rol
            //
            this.Rol.HeaderText = "Rol";
            this.Rol.MinimumWidth = 6;
            this.Rol.Name = "Rol";
            this.Rol.ReadOnly = true;
            this.Rol.Width = 125;
            //
            // EstadoValor
            //
            this.EstadoValor.HeaderText = "EstadoValor";
            this.EstadoValor.MinimumWidth = 6;
            this.EstadoValor.Name = "EstadoValor";
            this.EstadoValor.ReadOnly = true;
            this.EstadoValor.Visible = false;
            this.EstadoValor.Width = 125;
            //
            // Estado
            //
            this.Estado.HeaderText = "Estado";
            this.Estado.MinimumWidth = 6;
            this.Estado.Name = "Estado";
            this.Estado.ReadOnly = true;
            this.Estado.Width = 125;
            //
            // label10
            //
            this.label10.BackColor = System.Drawing.Color.White;
            this.label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(20, 20);
            this.label10.Name = "label10";
            this.label10.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.label10.Size = new System.Drawing.Size(1396, 60);
            this.label10.TabIndex = 0;
            this.label10.Text = "Lista De Usuarios";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // lblfiltros
            //
            this.lblfiltros.BackColor = System.Drawing.Color.White;
            this.lblfiltros.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblfiltros.Location = new System.Drawing.Point(20, 90);
            this.lblfiltros.Name = "lblfiltros";
            this.lblfiltros.Size = new System.Drawing.Size(1396, 50);
            this.lblfiltros.TabIndex = 4;
            //
            // lblrolfiltro
            //
            this.lblrolfiltro.AutoSize = true;
            this.lblrolfiltro.BackColor = System.Drawing.Color.White;
            this.lblrolfiltro.Location = new System.Drawing.Point(35, 107);
            this.lblrolfiltro.Name = "lblrolfiltro";
            this.lblrolfiltro.Size = new System.Drawing.Size(31, 16);
            this.lblrolfiltro.TabIndex = 5;
            this.lblrolfiltro.Text = "Rol:";
            //
            // cborolfiltro
            //
            this.cborolfiltro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cborolfiltro.FormattingEnabled = true;
            this.cborolfiltro.Location = new System.Drawing.Point(75, 103);
            this.cborolfiltro.Name = "cborolfiltro";
            this.cborolfiltro.Size = new System.Drawing.Size(180, 24);
            this.cborolfiltro.TabIndex = 6;
            this.cborolfiltro.SelectedIndexChanged += new System.EventHandler(this.Filtros_Changed);
            //
            // lblestadofiltro
            //
            this.lblestadofiltro.AutoSize = true;
            this.lblestadofiltro.BackColor = System.Drawing.Color.White;
            this.lblestadofiltro.Location = new System.Drawing.Point(280, 107);
            this.lblestadofiltro.Name = "lblestadofiltro";
            this.lblestadofiltro.Size = new System.Drawing.Size(53, 16);
            this.lblestadofiltro.TabIndex = 7;
            this.lblestadofiltro.Text = "Estado:";
            //
            // cboestadofiltro
            //
            this.cboestadofiltro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboestadofiltro.FormattingEnabled = true;
            this.cboestadofiltro.Location = new System.Drawing.Point(340, 103);
            this.cboestadofiltro.Name = "cboestadofiltro";
            this.cboestadofiltro.Size = new System.Drawing.Size(140, 24);
            this.cboestadofiltro.TabIndex = 8;
            this.cboestadofiltro.SelectedIndexChanged += new System.EventHandler(this.Filtros_Changed);
            //
            // txtbusqueda
            //
            this.txtbusqueda.Location = new System.Drawing.Point(505, 104);
            this.txtbusqueda.Name = "txtbusqueda";
            this.txtbusqueda.Size = new System.Drawing.Size(380, 22);
            this.txtbusqueda.TabIndex = 9;
            this.txtbusqueda.TextChanged += new System.EventHandler(this.Filtros_Changed);
            //
            // btnlimpiarbuscador
            //
            this.btnlimpiarbuscador.BackColor = System.Drawing.Color.White;
            this.btnlimpiarbuscador.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnlimpiarbuscador.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnlimpiarbuscador.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnlimpiarbuscador.ForeColor = System.Drawing.Color.Black;
            this.btnlimpiarbuscador.IconChar = FontAwesome.Sharp.IconChar.Broom;
            this.btnlimpiarbuscador.IconColor = System.Drawing.Color.Black;
            this.btnlimpiarbuscador.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnlimpiarbuscador.IconSize = 16;
            this.btnlimpiarbuscador.Location = new System.Drawing.Point(905, 98);
            this.btnlimpiarbuscador.Name = "btnlimpiarbuscador";
            this.btnlimpiarbuscador.Size = new System.Drawing.Size(150, 34);
            this.btnlimpiarbuscador.TabIndex = 10;
            this.btnlimpiarbuscador.Text = "Limpiar filtros";
            this.btnlimpiarbuscador.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnlimpiarbuscador.UseVisualStyleBackColor = false;
            this.btnlimpiarbuscador.Click += new System.EventHandler(this.btnlimpiarbuscador_Click);
            //
            // frmUsuarios
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1436, 613);
            this.Controls.Add(this.btnbaja);
            this.Controls.Add(this.btnagregar);
            this.Controls.Add(this.btnlimpiarbuscador);
            this.Controls.Add(this.txtbusqueda);
            this.Controls.Add(this.cboestadofiltro);
            this.Controls.Add(this.lblestadofiltro);
            this.Controls.Add(this.cborolfiltro);
            this.Controls.Add(this.lblrolfiltro);
            this.Controls.Add(this.lblfiltros);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.dgvdata);
            this.Name = "frmUsuarios";
            this.Text = "frmUsuarios";
            this.Load += new System.EventHandler(this.frmUsuarios_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvdata)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FontAwesome.Sharp.IconButton btnagregar;
        private FontAwesome.Sharp.IconButton btnbaja;
        private System.Windows.Forms.DataGridView dgvdata;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblfiltros;
        private System.Windows.Forms.Label lblrolfiltro;
        private System.Windows.Forms.ComboBox cborolfiltro;
        private System.Windows.Forms.Label lblestadofiltro;
        private System.Windows.Forms.ComboBox cboestadofiltro;
        private System.Windows.Forms.TextBox txtbusqueda;
        private FontAwesome.Sharp.IconButton btnlimpiarbuscador;
        private System.Windows.Forms.DataGridViewButtonColumn btnseleccionar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Documento;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreCompleto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Correo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Clave;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdRol;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rol;
        private System.Windows.Forms.DataGridViewTextBoxColumn EstadoValor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Estado;
    }
}
