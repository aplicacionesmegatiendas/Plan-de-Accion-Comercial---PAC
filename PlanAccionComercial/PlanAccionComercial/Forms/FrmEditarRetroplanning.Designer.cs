namespace PlanAccionComercial.Forms
{
    partial class FrmEditarRetroplanning
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
			this.btnGuardar = new System.Windows.Forms.Button();
			this.clb_negociador = new System.Windows.Forms.CheckedListBox();
			this.label11 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.dtp_fecha_comecial = new System.Windows.Forms.DateTimePicker();
			this.label9 = new System.Windows.Forms.Label();
			this.dtp_fecha_mercadeo = new System.Windows.Forms.DateTimePicker();
			this.label8 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.dtp_fecha_fin_vig = new System.Windows.Forms.DateTimePicker();
			this.dtp_fecha_ini_vig = new System.Windows.Forms.DateTimePicker();
			this.label6 = new System.Windows.Forms.Label();
			this.cmb_tipo_dinamica = new System.Windows.Forms.ComboBox();
			this.label4 = new System.Windows.Forms.Label();
			this.txt_nombre = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txt_consecutivo = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.btnCerrar = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// btnGuardar
			// 
			this.btnGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnGuardar.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnGuardar.ImageKey = "diskette25.png";
			this.btnGuardar.Location = new System.Drawing.Point(527, 215);
			this.btnGuardar.Name = "btnGuardar";
			this.btnGuardar.Size = new System.Drawing.Size(92, 32);
			this.btnGuardar.TabIndex = 19;
			this.btnGuardar.Text = "&Guardar";
			this.btnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnGuardar.UseVisualStyleBackColor = true;
			this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
			// 
			// clb_negociador
			// 
			this.clb_negociador.CheckOnClick = true;
			this.clb_negociador.FormattingEnabled = true;
			this.clb_negociador.Location = new System.Drawing.Point(431, 30);
			this.clb_negociador.Name = "clb_negociador";
			this.clb_negociador.Size = new System.Drawing.Size(288, 174);
			this.clb_negociador.TabIndex = 18;
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(428, 11);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(70, 13);
			this.label11.TabIndex = 17;
			this.label11.Text = "Negociador:";
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(324, 148);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(98, 27);
			this.label10.TabIndex = 15;
			this.label10.Text = "Fecha de entrega a comercial:";
			// 
			// dtp_fecha_comecial
			// 
			this.dtp_fecha_comecial.CustomFormat = "dd/MM/yyyy";
			this.dtp_fecha_comecial.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtp_fecha_comecial.Location = new System.Drawing.Point(324, 182);
			this.dtp_fecha_comecial.Name = "dtp_fecha_comecial";
			this.dtp_fecha_comecial.Size = new System.Drawing.Size(98, 22);
			this.dtp_fecha_comecial.TabIndex = 16;
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(216, 148);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(98, 27);
			this.label9.TabIndex = 13;
			this.label9.Text = "Fecha de entrega a mercadeo:";
			// 
			// dtp_fecha_mercadeo
			// 
			this.dtp_fecha_mercadeo.CustomFormat = "dd/MM/yyyy";
			this.dtp_fecha_mercadeo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtp_fecha_mercadeo.Location = new System.Drawing.Point(216, 182);
			this.dtp_fecha_mercadeo.Name = "dtp_fecha_mercadeo";
			this.dtp_fecha_mercadeo.Size = new System.Drawing.Size(98, 22);
			this.dtp_fecha_mercadeo.TabIndex = 14;
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(324, 103);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(39, 13);
			this.label8.TabIndex = 11;
			this.label8.Text = "Hasta:";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(216, 103);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(42, 13);
			this.label7.TabIndex = 9;
			this.label7.Text = "Desde:";
			// 
			// dtp_fecha_fin_vig
			// 
			this.dtp_fecha_fin_vig.CustomFormat = "dd/MM/yyyy";
			this.dtp_fecha_fin_vig.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtp_fecha_fin_vig.Location = new System.Drawing.Point(324, 123);
			this.dtp_fecha_fin_vig.Name = "dtp_fecha_fin_vig";
			this.dtp_fecha_fin_vig.Size = new System.Drawing.Size(98, 22);
			this.dtp_fecha_fin_vig.TabIndex = 12;
			// 
			// dtp_fecha_ini_vig
			// 
			this.dtp_fecha_ini_vig.CustomFormat = "dd/MM/yyyy";
			this.dtp_fecha_ini_vig.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtp_fecha_ini_vig.Location = new System.Drawing.Point(216, 123);
			this.dtp_fecha_ini_vig.Name = "dtp_fecha_ini_vig";
			this.dtp_fecha_ini_vig.Size = new System.Drawing.Size(98, 22);
			this.dtp_fecha_ini_vig.TabIndex = 10;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label6.Location = new System.Drawing.Point(216, 84);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(51, 13);
			this.label6.TabIndex = 8;
			this.label6.Text = "Vigencia";
			// 
			// cmb_tipo_dinamica
			// 
			this.cmb_tipo_dinamica.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmb_tipo_dinamica.FormattingEnabled = true;
			this.cmb_tipo_dinamica.Location = new System.Drawing.Point(12, 125);
			this.cmb_tipo_dinamica.Name = "cmb_tipo_dinamica";
			this.cmb_tipo_dinamica.Size = new System.Drawing.Size(195, 21);
			this.cmb_tipo_dinamica.TabIndex = 5;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(12, 105);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(98, 13);
			this.label4.TabIndex = 4;
			this.label4.Text = "Tipo de dinámica:";
			// 
			// txt_nombre
			// 
			this.txt_nombre.Location = new System.Drawing.Point(119, 51);
			this.txt_nombre.MaxLength = 150;
			this.txt_nombre.Name = "txt_nombre";
			this.txt_nombre.Size = new System.Drawing.Size(303, 22);
			this.txt_nombre.TabIndex = 3;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 55);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "Nombre dinámica:";
			// 
			// txt_consecutivo
			// 
			this.txt_consecutivo.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txt_consecutivo.Location = new System.Drawing.Point(119, 23);
			this.txt_consecutivo.Name = "txt_consecutivo";
			this.txt_consecutivo.ReadOnly = true;
			this.txt_consecutivo.Size = new System.Drawing.Size(100, 22);
			this.txt_consecutivo.TabIndex = 1;
			this.txt_consecutivo.TabStop = false;
			this.txt_consecutivo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 27);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(73, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Consecutivo:";
			// 
			// btnCerrar
			// 
			this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCerrar.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnCerrar.ImageIndex = 2;
			this.btnCerrar.Location = new System.Drawing.Point(625, 215);
			this.btnCerrar.Name = "btnCerrar";
			this.btnCerrar.Size = new System.Drawing.Size(94, 32);
			this.btnCerrar.TabIndex = 20;
			this.btnCerrar.Text = "&Cerrar";
			this.btnCerrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnCerrar.UseVisualStyleBackColor = true;
			this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
			// 
			// FrmEditarRetroplanning
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(732, 254);
			this.Controls.Add(this.btnCerrar);
			this.Controls.Add(this.btnGuardar);
			this.Controls.Add(this.clb_negociador);
			this.Controls.Add(this.label11);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.dtp_fecha_comecial);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.dtp_fecha_mercadeo);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.dtp_fecha_fin_vig);
			this.Controls.Add(this.dtp_fecha_ini_vig);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.cmb_tipo_dinamica);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.txt_nombre);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.txt_consecutivo);
			this.Controls.Add(this.label1);
			this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FrmEditarRetroplanning";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Editar retroplanning";
			this.Load += new System.EventHandler(this.FrmEditarRetroplanning_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.CheckedListBox clb_negociador;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker dtp_fecha_comecial;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker dtp_fecha_mercadeo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dtp_fecha_fin_vig;
        private System.Windows.Forms.DateTimePicker dtp_fecha_ini_vig;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmb_tipo_dinamica;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_nombre;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_consecutivo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCerrar;
    }
}