namespace CapaPresentacion.Modales
{
    partial class mdCobrarVenta
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
            this.lbltotaltitulo = new System.Windows.Forms.Label();
            this.lbltotal = new System.Windows.Forms.Label();
            this.lblabonado = new System.Windows.Forms.Label();
            this.txtabonado = new System.Windows.Forms.NumericUpDown();
            this.lblvueltotitulo = new System.Windows.Forms.Label();
            this.lblvuelto = new System.Windows.Forms.Label();
            this.btnok = new FontAwesome.Sharp.IconButton();
            this.btncancelar = new FontAwesome.Sharp.IconButton();
            ((System.ComponentModel.ISupportInitialize)(this.txtabonado)).BeginInit();
            this.SuspendLayout();
            //
            // lbltitulo
            //
            this.lbltitulo.AutoSize = true;
            this.lbltitulo.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold);
            this.lbltitulo.Location = new System.Drawing.Point(22, 14);
            this.lbltitulo.Name = "lbltitulo";
            this.lbltitulo.Size = new System.Drawing.Size(150, 32);
            this.lbltitulo.TabIndex = 0;
            this.lbltitulo.Text = "Cobrar venta";
            //
            // lbltotaltitulo
            //
            this.lbltotaltitulo.AutoSize = true;
            this.lbltotaltitulo.ForeColor = System.Drawing.Color.DimGray;
            this.lbltotaltitulo.Location = new System.Drawing.Point(24, 62);
            this.lbltotaltitulo.Name = "lbltotaltitulo";
            this.lbltotaltitulo.Size = new System.Drawing.Size(40, 20);
            this.lbltotaltitulo.TabIndex = 0;
            this.lbltotaltitulo.Text = "Total";
            //
            // lbltotal
            //
            this.lbltotal.Font = new System.Drawing.Font("Segoe UI Semibold", 24F, System.Drawing.FontStyle.Bold);
            this.lbltotal.Location = new System.Drawing.Point(20, 82);
            this.lbltotal.Name = "lbltotal";
            this.lbltotal.Size = new System.Drawing.Size(340, 54);
            this.lbltotal.TabIndex = 0;
            this.lbltotal.Text = "$ 0,00";
            //
            // lblabonado
            //
            this.lblabonado.AutoSize = true;
            this.lblabonado.ForeColor = System.Drawing.Color.DimGray;
            this.lblabonado.Location = new System.Drawing.Point(24, 148);
            this.lblabonado.Name = "lblabonado";
            this.lblabonado.Size = new System.Drawing.Size(119, 20);
            this.lblabonado.TabIndex = 0;
            this.lblabonado.Text = "Monto abonado";
            //
            // txtabonado
            //
            this.txtabonado.DecimalPlaces = 2;
            this.txtabonado.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.txtabonado.Location = new System.Drawing.Point(26, 172);
            this.txtabonado.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.txtabonado.Name = "txtabonado";
            this.txtabonado.Size = new System.Drawing.Size(328, 43);
            this.txtabonado.TabIndex = 1;
            this.txtabonado.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtabonado.ThousandsSeparator = true;
            this.txtabonado.TextChanged += new System.EventHandler(this.txtabonado_TextChanged);
            this.txtabonado.Enter += new System.EventHandler(this.txtabonado_Enter);
            this.txtabonado.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtabonado_KeyDown);
            //
            // lblvueltotitulo
            //
            this.lblvueltotitulo.AutoSize = true;
            this.lblvueltotitulo.ForeColor = System.Drawing.Color.DimGray;
            this.lblvueltotitulo.Location = new System.Drawing.Point(24, 230);
            this.lblvueltotitulo.Name = "lblvueltotitulo";
            this.lblvueltotitulo.Size = new System.Drawing.Size(51, 20);
            this.lblvueltotitulo.TabIndex = 0;
            this.lblvueltotitulo.Text = "Vuelto";
            //
            // lblvuelto
            //
            this.lblvuelto.Font = new System.Drawing.Font("Segoe UI Semibold", 20F, System.Drawing.FontStyle.Bold);
            this.lblvuelto.ForeColor = System.Drawing.Color.SeaGreen;
            this.lblvuelto.Location = new System.Drawing.Point(20, 250);
            this.lblvuelto.Name = "lblvuelto";
            this.lblvuelto.Size = new System.Drawing.Size(340, 46);
            this.lblvuelto.TabIndex = 0;
            this.lblvuelto.Text = "$ 0,00";
            //
            // btnok
            //
            this.btnok.BackColor = System.Drawing.Color.ForestGreen;
            this.btnok.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnok.FlatAppearance.BorderSize = 0;
            this.btnok.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnok.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btnok.ForeColor = System.Drawing.Color.White;
            this.btnok.IconChar = FontAwesome.Sharp.IconChar.Check;
            this.btnok.IconColor = System.Drawing.Color.White;
            this.btnok.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnok.IconSize = 18;
            this.btnok.Location = new System.Drawing.Point(26, 316);
            this.btnok.Name = "btnok";
            this.btnok.Size = new System.Drawing.Size(206, 44);
            this.btnok.TabIndex = 2;
            this.btnok.Text = "OK, finalizar venta";
            this.btnok.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnok.UseVisualStyleBackColor = false;
            this.btnok.Click += new System.EventHandler(this.btnok_Click);
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
            this.btncancelar.Location = new System.Drawing.Point(240, 316);
            this.btncancelar.Name = "btncancelar";
            this.btncancelar.Size = new System.Drawing.Size(114, 44);
            this.btncancelar.TabIndex = 3;
            this.btncancelar.Text = "Cancelar";
            this.btncancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btncancelar.UseVisualStyleBackColor = false;
            this.btncancelar.Click += new System.EventHandler(this.btncancelar_Click);
            //
            // mdCobrarVenta
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btncancelar;
            this.ClientSize = new System.Drawing.Size(380, 384);
            this.Controls.Add(this.btncancelar);
            this.Controls.Add(this.btnok);
            this.Controls.Add(this.lblvuelto);
            this.Controls.Add(this.lblvueltotitulo);
            this.Controls.Add(this.txtabonado);
            this.Controls.Add(this.lblabonado);
            this.Controls.Add(this.lbltotal);
            this.Controls.Add(this.lbltotaltitulo);
            this.Controls.Add(this.lbltitulo);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "mdCobrarVenta";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Cobrar venta";
            this.Load += new System.EventHandler(this.mdCobrarVenta_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtabonado)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbltitulo;
        private System.Windows.Forms.Label lbltotaltitulo;
        private System.Windows.Forms.Label lbltotal;
        private System.Windows.Forms.Label lblabonado;
        private System.Windows.Forms.NumericUpDown txtabonado;
        private System.Windows.Forms.Label lblvueltotitulo;
        private System.Windows.Forms.Label lblvuelto;
        private FontAwesome.Sharp.IconButton btnok;
        private FontAwesome.Sharp.IconButton btncancelar;
    }
}
