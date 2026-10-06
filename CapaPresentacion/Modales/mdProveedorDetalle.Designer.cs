namespace CapaPresentacion.Modales
{
    partial class mdProveedorDetalle
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
            this.lbldocumento = new System.Windows.Forms.Label();
            this.txtdocumento = new System.Windows.Forms.TextBox();
            this.lblnombre = new System.Windows.Forms.Label();
            this.txtnombre = new System.Windows.Forms.TextBox();
            this.lblcorreo = new System.Windows.Forms.Label();
            this.txtcorreo = new System.Windows.Forms.TextBox();
            this.lbltelefono = new System.Windows.Forms.Label();
            this.txttelefono = new System.Windows.Forms.TextBox();
            this.lblestado = new System.Windows.Forms.Label();
            this.cboestado = new System.Windows.Forms.ComboBox();
            this.btnguardar = new FontAwesome.Sharp.IconButton();
            this.btncancelar = new FontAwesome.Sharp.IconButton();
            this.SuspendLayout();
            //
            // lbltitulo
            //
            this.lbltitulo.AutoSize = true;
            this.lbltitulo.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold);
            this.lbltitulo.Location = new System.Drawing.Point(22, 16);
            this.lbltitulo.Name = "lbltitulo";
            this.lbltitulo.Size = new System.Drawing.Size(160, 32);
            this.lbltitulo.TabIndex = 0;
            this.lbltitulo.Text = "Nuevo proveedor";
            //
            // lbldocumento
            //
            this.lbldocumento.AutoSize = true;
            this.lbldocumento.Location = new System.Drawing.Point(22, 62);
            this.lbldocumento.Name = "lbldocumento";
            this.lbldocumento.Size = new System.Drawing.Size(121, 20);
            this.lbldocumento.TabIndex = 0;
            this.lbldocumento.Text = "Nro documento *";
            //
            // txtdocumento
            //
            this.txtdocumento.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtdocumento.Location = new System.Drawing.Point(24, 84);
            this.txtdocumento.MaxLength = 50;
            this.txtdocumento.Name = "txtdocumento";
            this.txtdocumento.Size = new System.Drawing.Size(352, 30);
            this.txtdocumento.TabIndex = 1;
            //
            // lblnombre
            //
            this.lblnombre.AutoSize = true;
            this.lblnombre.Location = new System.Drawing.Point(22, 122);
            this.lblnombre.Name = "lblnombre";
            this.lblnombre.Size = new System.Drawing.Size(134, 20);
            this.lblnombre.TabIndex = 0;
            this.lblnombre.Text = "Razón social *";
            //
            // txtnombre
            //
            this.txtnombre.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtnombre.Location = new System.Drawing.Point(24, 144);
            this.txtnombre.MaxLength = 100;
            this.txtnombre.Name = "txtnombre";
            this.txtnombre.Size = new System.Drawing.Size(352, 30);
            this.txtnombre.TabIndex = 2;
            //
            // lblcorreo
            //
            this.lblcorreo.AutoSize = true;
            this.lblcorreo.Location = new System.Drawing.Point(22, 182);
            this.lblcorreo.Name = "lblcorreo";
            this.lblcorreo.Size = new System.Drawing.Size(63, 20);
            this.lblcorreo.TabIndex = 0;
            this.lblcorreo.Text = "Correo *";
            //
            // txtcorreo
            //
            this.txtcorreo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtcorreo.Location = new System.Drawing.Point(24, 204);
            this.txtcorreo.MaxLength = 100;
            this.txtcorreo.Name = "txtcorreo";
            this.txtcorreo.Size = new System.Drawing.Size(352, 30);
            this.txtcorreo.TabIndex = 3;
            //
            // lbltelefono
            //
            this.lbltelefono.AutoSize = true;
            this.lbltelefono.Location = new System.Drawing.Point(22, 242);
            this.lbltelefono.Name = "lbltelefono";
            this.lbltelefono.Size = new System.Drawing.Size(67, 20);
            this.lbltelefono.TabIndex = 0;
            this.lbltelefono.Text = "Teléfono";
            //
            // txttelefono
            //
            this.txttelefono.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txttelefono.Location = new System.Drawing.Point(24, 264);
            this.txttelefono.MaxLength = 50;
            this.txttelefono.Name = "txttelefono";
            this.txttelefono.Size = new System.Drawing.Size(352, 30);
            this.txttelefono.TabIndex = 4;
            //
            // lblestado
            //
            this.lblestado.AutoSize = true;
            this.lblestado.Location = new System.Drawing.Point(22, 302);
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
            this.cboestado.Location = new System.Drawing.Point(24, 324);
            this.cboestado.Name = "cboestado";
            this.cboestado.Size = new System.Drawing.Size(352, 31);
            this.cboestado.TabIndex = 5;
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
            this.btnguardar.Location = new System.Drawing.Point(24, 378);
            this.btnguardar.Name = "btnguardar";
            this.btnguardar.Size = new System.Drawing.Size(228, 40);
            this.btnguardar.TabIndex = 6;
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
            this.btncancelar.Location = new System.Drawing.Point(262, 378);
            this.btncancelar.Name = "btncancelar";
            this.btncancelar.Size = new System.Drawing.Size(114, 40);
            this.btncancelar.TabIndex = 7;
            this.btncancelar.Text = "Cancelar";
            this.btncancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btncancelar.UseVisualStyleBackColor = false;
            this.btncancelar.Click += new System.EventHandler(this.btncancelar_Click);
            //
            // mdProveedorDetalle
            //
            this.AcceptButton = this.btnguardar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btncancelar;
            this.ClientSize = new System.Drawing.Size(400, 442);
            this.Controls.Add(this.btncancelar);
            this.Controls.Add(this.btnguardar);
            this.Controls.Add(this.cboestado);
            this.Controls.Add(this.lblestado);
            this.Controls.Add(this.txttelefono);
            this.Controls.Add(this.lbltelefono);
            this.Controls.Add(this.txtcorreo);
            this.Controls.Add(this.lblcorreo);
            this.Controls.Add(this.txtnombre);
            this.Controls.Add(this.lblnombre);
            this.Controls.Add(this.txtdocumento);
            this.Controls.Add(this.lbldocumento);
            this.Controls.Add(this.lbltitulo);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "mdProveedorDetalle";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Agregar proveedor";
            this.Load += new System.EventHandler(this.mdProveedorDetalle_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbltitulo;
        private System.Windows.Forms.Label lbldocumento;
        private System.Windows.Forms.TextBox txtdocumento;
        private System.Windows.Forms.Label lblnombre;
        private System.Windows.Forms.TextBox txtnombre;
        private System.Windows.Forms.Label lblcorreo;
        private System.Windows.Forms.TextBox txtcorreo;
        private System.Windows.Forms.Label lbltelefono;
        private System.Windows.Forms.TextBox txttelefono;
        private System.Windows.Forms.Label lblestado;
        private System.Windows.Forms.ComboBox cboestado;
        private FontAwesome.Sharp.IconButton btnguardar;
        private FontAwesome.Sharp.IconButton btncancelar;
    }
}
