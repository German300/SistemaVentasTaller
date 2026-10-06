namespace CapaPresentacion.Modales
{
    partial class mdUsuario
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
            this.txtnombrecompleto = new System.Windows.Forms.TextBox();
            this.lblcorreo = new System.Windows.Forms.Label();
            this.txtcorreo = new System.Windows.Forms.TextBox();
            this.lblclave = new System.Windows.Forms.Label();
            this.txtclave = new System.Windows.Forms.TextBox();
            this.lblconfirmarclave = new System.Windows.Forms.Label();
            this.txtconfirmarclave = new System.Windows.Forms.TextBox();
            this.lblrol = new System.Windows.Forms.Label();
            this.cborol = new System.Windows.Forms.ComboBox();
            this.lblestado = new System.Windows.Forms.Label();
            this.cboestado = new System.Windows.Forms.ComboBox();
            this.btnguardar = new FontAwesome.Sharp.IconButton();
            this.btncancelar = new FontAwesome.Sharp.IconButton();
            this.SuspendLayout();
            //
            // lbltitulo
            //
            this.lbltitulo.AutoSize = true;
            this.lbltitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltitulo.Location = new System.Drawing.Point(24, 18);
            this.lbltitulo.Name = "lbltitulo";
            this.lbltitulo.Size = new System.Drawing.Size(178, 29);
            this.lbltitulo.TabIndex = 0;
            this.lbltitulo.Text = "Nuevo usuario";
            //
            // lbldocumento
            //
            this.lbldocumento.AutoSize = true;
            this.lbldocumento.Location = new System.Drawing.Point(26, 66);
            this.lbldocumento.Name = "lbldocumento";
            this.lbldocumento.Size = new System.Drawing.Size(110, 16);
            this.lbldocumento.TabIndex = 1;
            this.lbldocumento.Text = "Nro Documento *";
            //
            // txtdocumento
            //
            this.txtdocumento.Location = new System.Drawing.Point(28, 86);
            this.txtdocumento.Name = "txtdocumento";
            this.txtdocumento.Size = new System.Drawing.Size(320, 22);
            this.txtdocumento.TabIndex = 2;
            //
            // lblnombre
            //
            this.lblnombre.AutoSize = true;
            this.lblnombre.Location = new System.Drawing.Point(26, 120);
            this.lblnombre.Name = "lblnombre";
            this.lblnombre.Size = new System.Drawing.Size(126, 16);
            this.lblnombre.TabIndex = 3;
            this.lblnombre.Text = "Nombre Completo *";
            //
            // txtnombrecompleto
            //
            this.txtnombrecompleto.Location = new System.Drawing.Point(28, 140);
            this.txtnombrecompleto.Name = "txtnombrecompleto";
            this.txtnombrecompleto.Size = new System.Drawing.Size(320, 22);
            this.txtnombrecompleto.TabIndex = 4;
            //
            // lblcorreo
            //
            this.lblcorreo.AutoSize = true;
            this.lblcorreo.Location = new System.Drawing.Point(26, 174);
            this.lblcorreo.Name = "lblcorreo";
            this.lblcorreo.Size = new System.Drawing.Size(48, 16);
            this.lblcorreo.TabIndex = 5;
            this.lblcorreo.Text = "Correo";
            //
            // txtcorreo
            //
            this.txtcorreo.Location = new System.Drawing.Point(28, 194);
            this.txtcorreo.Name = "txtcorreo";
            this.txtcorreo.Size = new System.Drawing.Size(320, 22);
            this.txtcorreo.TabIndex = 6;
            //
            // lblclave
            //
            this.lblclave.AutoSize = true;
            this.lblclave.Location = new System.Drawing.Point(26, 228);
            this.lblclave.Name = "lblclave";
            this.lblclave.Size = new System.Drawing.Size(85, 16);
            this.lblclave.TabIndex = 7;
            this.lblclave.Text = "Contraseña *";
            //
            // txtclave
            //
            this.txtclave.Location = new System.Drawing.Point(28, 248);
            this.txtclave.Name = "txtclave";
            this.txtclave.PasswordChar = '*';
            this.txtclave.Size = new System.Drawing.Size(320, 22);
            this.txtclave.TabIndex = 8;
            //
            // lblconfirmarclave
            //
            this.lblconfirmarclave.AutoSize = true;
            this.lblconfirmarclave.Location = new System.Drawing.Point(26, 282);
            this.lblconfirmarclave.Name = "lblconfirmarclave";
            this.lblconfirmarclave.Size = new System.Drawing.Size(145, 16);
            this.lblconfirmarclave.TabIndex = 9;
            this.lblconfirmarclave.Text = "Confirmar Contraseña *";
            //
            // txtconfirmarclave
            //
            this.txtconfirmarclave.Location = new System.Drawing.Point(28, 302);
            this.txtconfirmarclave.Name = "txtconfirmarclave";
            this.txtconfirmarclave.PasswordChar = '*';
            this.txtconfirmarclave.Size = new System.Drawing.Size(320, 22);
            this.txtconfirmarclave.TabIndex = 10;
            //
            // lblrol
            //
            this.lblrol.AutoSize = true;
            this.lblrol.Location = new System.Drawing.Point(26, 336);
            this.lblrol.Name = "lblrol";
            this.lblrol.Size = new System.Drawing.Size(28, 16);
            this.lblrol.TabIndex = 11;
            this.lblrol.Text = "Rol";
            //
            // cborol
            //
            this.cborol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cborol.FormattingEnabled = true;
            this.cborol.Location = new System.Drawing.Point(28, 356);
            this.cborol.Name = "cborol";
            this.cborol.Size = new System.Drawing.Size(320, 24);
            this.cborol.TabIndex = 12;
            //
            // lblestado
            //
            this.lblestado.AutoSize = true;
            this.lblestado.Location = new System.Drawing.Point(26, 394);
            this.lblestado.Name = "lblestado";
            this.lblestado.Size = new System.Drawing.Size(50, 16);
            this.lblestado.TabIndex = 13;
            this.lblestado.Text = "Estado";
            //
            // cboestado
            //
            this.cboestado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboestado.FormattingEnabled = true;
            this.cboestado.Location = new System.Drawing.Point(28, 414);
            this.cboestado.Name = "cboestado";
            this.cboestado.Size = new System.Drawing.Size(320, 24);
            this.cboestado.TabIndex = 14;
            //
            // btnguardar
            //
            this.btnguardar.BackColor = System.Drawing.Color.ForestGreen;
            this.btnguardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnguardar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnguardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnguardar.ForeColor = System.Drawing.Color.White;
            this.btnguardar.IconChar = FontAwesome.Sharp.IconChar.FloppyDisk;
            this.btnguardar.IconColor = System.Drawing.Color.White;
            this.btnguardar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnguardar.IconSize = 16;
            this.btnguardar.Location = new System.Drawing.Point(28, 466);
            this.btnguardar.Name = "btnguardar";
            this.btnguardar.Size = new System.Drawing.Size(155, 34);
            this.btnguardar.TabIndex = 15;
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
            this.btncancelar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btncancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btncancelar.ForeColor = System.Drawing.Color.Black;
            this.btncancelar.IconChar = FontAwesome.Sharp.IconChar.Xmark;
            this.btncancelar.IconColor = System.Drawing.Color.Black;
            this.btncancelar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btncancelar.IconSize = 16;
            this.btncancelar.Location = new System.Drawing.Point(193, 466);
            this.btncancelar.Name = "btncancelar";
            this.btncancelar.Size = new System.Drawing.Size(155, 34);
            this.btncancelar.TabIndex = 16;
            this.btncancelar.Text = "Cancelar";
            this.btncancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btncancelar.UseVisualStyleBackColor = false;
            this.btncancelar.Click += new System.EventHandler(this.btncancelar_Click);
            //
            // mdUsuario
            //
            this.AcceptButton = this.btnguardar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btncancelar;
            this.ClientSize = new System.Drawing.Size(378, 524);
            this.Controls.Add(this.btncancelar);
            this.Controls.Add(this.btnguardar);
            this.Controls.Add(this.cboestado);
            this.Controls.Add(this.lblestado);
            this.Controls.Add(this.cborol);
            this.Controls.Add(this.lblrol);
            this.Controls.Add(this.txtconfirmarclave);
            this.Controls.Add(this.lblconfirmarclave);
            this.Controls.Add(this.txtclave);
            this.Controls.Add(this.lblclave);
            this.Controls.Add(this.txtcorreo);
            this.Controls.Add(this.lblcorreo);
            this.Controls.Add(this.txtnombrecompleto);
            this.Controls.Add(this.lblnombre);
            this.Controls.Add(this.txtdocumento);
            this.Controls.Add(this.lbldocumento);
            this.Controls.Add(this.lbltitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "mdUsuario";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Agregar usuario";
            this.Load += new System.EventHandler(this.mdUsuario_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbltitulo;
        private System.Windows.Forms.Label lbldocumento;
        private System.Windows.Forms.TextBox txtdocumento;
        private System.Windows.Forms.Label lblnombre;
        private System.Windows.Forms.TextBox txtnombrecompleto;
        private System.Windows.Forms.Label lblcorreo;
        private System.Windows.Forms.TextBox txtcorreo;
        private System.Windows.Forms.Label lblclave;
        private System.Windows.Forms.TextBox txtclave;
        private System.Windows.Forms.Label lblconfirmarclave;
        private System.Windows.Forms.TextBox txtconfirmarclave;
        private System.Windows.Forms.Label lblrol;
        private System.Windows.Forms.ComboBox cborol;
        private System.Windows.Forms.Label lblestado;
        private System.Windows.Forms.ComboBox cboestado;
        private FontAwesome.Sharp.IconButton btnguardar;
        private FontAwesome.Sharp.IconButton btncancelar;
    }
}
