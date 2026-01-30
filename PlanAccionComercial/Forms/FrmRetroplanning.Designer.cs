namespace PlanAccionComercial.Forms
{
    partial class FrmRetroplanning
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRetroplanning));
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			this.pnl_cab = new System.Windows.Forms.Panel();
			this.label3 = new System.Windows.Forms.Label();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.label1 = new System.Windows.Forms.Label();
			this.txt_consecutivo = new System.Windows.Forms.TextBox();
			this.txt_nombre = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.cmb_tipo_dinamica = new System.Windows.Forms.ComboBox();
			this.label6 = new System.Windows.Forms.Label();
			this.dtp_fecha_ini_vig = new System.Windows.Forms.DateTimePicker();
			this.dtp_fecha_fin_vig = new System.Windows.Forms.DateTimePicker();
			this.label7 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.dtp_fecha_mercadeo = new System.Windows.Forms.DateTimePicker();
			this.label10 = new System.Windows.Forms.Label();
			this.dtp_fecha_comecial = new System.Windows.Forms.DateTimePicker();
			this.label11 = new System.Windows.Forms.Label();
			this.clb_negociador = new System.Windows.Forms.CheckedListBox();
			this.btnCerrar = new System.Windows.Forms.Button();
			this.btnGuardar = new System.Windows.Forms.Button();
			this.dgv_retroplanning = new System.Windows.Forms.DataGridView();
			this.col_consecutivo = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.col_dinamica = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.col_id_tipo_dinamica = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.col_tipo_dinamica = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.col_fecha_ini_vig = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.col_fecha_fin_vig = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.col_fecha_ent_mercadeo = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.col_fecha_ent_comercial = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.col_id_estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.col_estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.col_editar = new System.Windows.Forms.DataGridViewButtonColumn();
			this.label14 = new System.Windows.Forms.Label();
			this.pnl_cab.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dgv_retroplanning)).BeginInit();
			this.SuspendLayout();
			// 
			// pnl_cab
			// 
			this.pnl_cab.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.pnl_cab.BackColor = System.Drawing.Color.White;
			this.pnl_cab.Controls.Add(this.label3);
			this.pnl_cab.Controls.Add(this.pictureBox1);
			this.pnl_cab.Location = new System.Drawing.Point(12, 12);
			this.pnl_cab.Name = "pnl_cab";
			this.pnl_cab.Size = new System.Drawing.Size(1088, 41);
			this.pnl_cab.TabIndex = 0;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.ForeColor = System.Drawing.Color.Black;
			this.label3.Location = new System.Drawing.Point(10, 10);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(94, 17);
			this.label3.TabIndex = 0;
			this.label3.Text = "Retroplanning";
			// 
			// pictureBox1
			// 
			this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(970, 5);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(114, 32);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 64);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(73, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Consecutivo:";
			// 
			// txt_consecutivo
			// 
			this.txt_consecutivo.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txt_consecutivo.Location = new System.Drawing.Point(119, 60);
			this.txt_consecutivo.Name = "txt_consecutivo";
			this.txt_consecutivo.ReadOnly = true;
			this.txt_consecutivo.Size = new System.Drawing.Size(100, 22);
			this.txt_consecutivo.TabIndex = 2;
			this.txt_consecutivo.TabStop = false;
			this.txt_consecutivo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// txt_nombre
			// 
			this.txt_nombre.Location = new System.Drawing.Point(119, 89);
			this.txt_nombre.MaxLength = 150;
			this.txt_nombre.Name = "txt_nombre";
			this.txt_nombre.Size = new System.Drawing.Size(303, 22);
			this.txt_nombre.TabIndex = 4;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 93);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 13);
			this.label2.TabIndex = 3;
			this.label2.Text = "Nombre dinámica:";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(17, 131);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(98, 13);
			this.label4.TabIndex = 5;
			this.label4.Text = "Tipo de dinámica:";
			// 
			// cmb_tipo_dinamica
			// 
			this.cmb_tipo_dinamica.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmb_tipo_dinamica.FormattingEnabled = true;
			this.cmb_tipo_dinamica.Location = new System.Drawing.Point(17, 151);
			this.cmb_tipo_dinamica.Name = "cmb_tipo_dinamica";
			this.cmb_tipo_dinamica.Size = new System.Drawing.Size(185, 21);
			this.cmb_tipo_dinamica.TabIndex = 6;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label6.Location = new System.Drawing.Point(216, 127);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(51, 13);
			this.label6.TabIndex = 23;
			this.label6.Text = "Vigencia";
			// 
			// dtp_fecha_ini_vig
			// 
			this.dtp_fecha_ini_vig.CustomFormat = "dd/MM/yyyy";
			this.dtp_fecha_ini_vig.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtp_fecha_ini_vig.Location = new System.Drawing.Point(216, 166);
			this.dtp_fecha_ini_vig.Name = "dtp_fecha_ini_vig";
			this.dtp_fecha_ini_vig.Size = new System.Drawing.Size(98, 22);
			this.dtp_fecha_ini_vig.TabIndex = 11;
			// 
			// dtp_fecha_fin_vig
			// 
			this.dtp_fecha_fin_vig.CustomFormat = "dd/MM/yyyy";
			this.dtp_fecha_fin_vig.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtp_fecha_fin_vig.Location = new System.Drawing.Point(324, 166);
			this.dtp_fecha_fin_vig.Name = "dtp_fecha_fin_vig";
			this.dtp_fecha_fin_vig.Size = new System.Drawing.Size(98, 22);
			this.dtp_fecha_fin_vig.TabIndex = 13;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(216, 146);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(42, 13);
			this.label7.TabIndex = 10;
			this.label7.Text = "Desde:";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(324, 146);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(39, 13);
			this.label8.TabIndex = 12;
			this.label8.Text = "Hasta:";
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(216, 206);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(98, 27);
			this.label9.TabIndex = 14;
			this.label9.Text = "Fecha de entrega a mercadeo:";
			// 
			// dtp_fecha_mercadeo
			// 
			this.dtp_fecha_mercadeo.CustomFormat = "dd/MM/yyyy";
			this.dtp_fecha_mercadeo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtp_fecha_mercadeo.Location = new System.Drawing.Point(216, 240);
			this.dtp_fecha_mercadeo.Name = "dtp_fecha_mercadeo";
			this.dtp_fecha_mercadeo.Size = new System.Drawing.Size(98, 22);
			this.dtp_fecha_mercadeo.TabIndex = 15;
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(324, 206);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(98, 27);
			this.label10.TabIndex = 16;
			this.label10.Text = "Fecha de entrega a comercial:";
			// 
			// dtp_fecha_comecial
			// 
			this.dtp_fecha_comecial.CustomFormat = "dd/MM/yyyy";
			this.dtp_fecha_comecial.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtp_fecha_comecial.Location = new System.Drawing.Point(324, 240);
			this.dtp_fecha_comecial.Name = "dtp_fecha_comecial";
			this.dtp_fecha_comecial.Size = new System.Drawing.Size(98, 22);
			this.dtp_fecha_comecial.TabIndex = 17;
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(428, 69);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(81, 13);
			this.label11.TabIndex = 18;
			this.label11.Text = "Negociadores:";
			// 
			// clb_negociador
			// 
			this.clb_negociador.CheckOnClick = true;
			this.clb_negociador.FormattingEnabled = true;
			this.clb_negociador.Location = new System.Drawing.Point(431, 88);
			this.clb_negociador.Name = "clb_negociador";
			this.clb_negociador.Size = new System.Drawing.Size(288, 174);
			this.clb_negociador.TabIndex = 19;
			// 
			// btnCerrar
			// 
			this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCerrar.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnCerrar.ImageIndex = 2;
			this.btnCerrar.Location = new System.Drawing.Point(1006, 625);
			this.btnCerrar.Name = "btnCerrar";
			this.btnCerrar.Size = new System.Drawing.Size(94, 32);
			this.btnCerrar.TabIndex = 22;
			this.btnCerrar.Text = "&Cerrar";
			this.btnCerrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnCerrar.UseVisualStyleBackColor = true;
			this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
			// 
			// btnGuardar
			// 
			this.btnGuardar.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnGuardar.ImageKey = "diskette25.png";
			this.btnGuardar.Location = new System.Drawing.Point(627, 269);
			this.btnGuardar.Name = "btnGuardar";
			this.btnGuardar.Size = new System.Drawing.Size(92, 32);
			this.btnGuardar.TabIndex = 20;
			this.btnGuardar.Text = "&Guardar";
			this.btnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnGuardar.UseVisualStyleBackColor = true;
			this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
			// 
			// dgv_retroplanning
			// 
			this.dgv_retroplanning.AllowUserToAddRows = false;
			this.dgv_retroplanning.AllowUserToDeleteRows = false;
			this.dgv_retroplanning.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgv_retroplanning.BackgroundColor = System.Drawing.SystemColors.Window;
			this.dgv_retroplanning.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgv_retroplanning.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_consecutivo,
            this.col_dinamica,
            this.col_id_tipo_dinamica,
            this.col_tipo_dinamica,
            this.col_fecha_ini_vig,
            this.col_fecha_fin_vig,
            this.col_fecha_ent_mercadeo,
            this.col_fecha_ent_comercial,
            this.col_id_estado,
            this.col_estado,
            this.col_editar});
			this.dgv_retroplanning.Location = new System.Drawing.Point(11, 307);
			this.dgv_retroplanning.Name = "dgv_retroplanning";
			this.dgv_retroplanning.ReadOnly = true;
			this.dgv_retroplanning.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgv_retroplanning.Size = new System.Drawing.Size(1089, 312);
			this.dgv_retroplanning.TabIndex = 21;
			this.dgv_retroplanning.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_retroplanning_CellContentClick);
			this.dgv_retroplanning.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgv_retroplanning_RowPostPaint);
			// 
			// col_consecutivo
			// 
			dataGridViewCellStyle1.Format = "000#";
			dataGridViewCellStyle1.NullValue = null;
			this.col_consecutivo.DefaultCellStyle = dataGridViewCellStyle1;
			this.col_consecutivo.HeaderText = "Consecutivo";
			this.col_consecutivo.Name = "col_consecutivo";
			this.col_consecutivo.ReadOnly = true;
			// 
			// col_dinamica
			// 
			this.col_dinamica.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.col_dinamica.HeaderText = "Nombre dinámica";
			this.col_dinamica.Name = "col_dinamica";
			this.col_dinamica.ReadOnly = true;
			// 
			// col_id_tipo_dinamica
			// 
			this.col_id_tipo_dinamica.HeaderText = "ID_TIPO_DIN";
			this.col_id_tipo_dinamica.Name = "col_id_tipo_dinamica";
			this.col_id_tipo_dinamica.ReadOnly = true;
			this.col_id_tipo_dinamica.Visible = false;
			// 
			// col_tipo_dinamica
			// 
			this.col_tipo_dinamica.HeaderText = "Tipo dinámica";
			this.col_tipo_dinamica.Name = "col_tipo_dinamica";
			this.col_tipo_dinamica.ReadOnly = true;
			// 
			// col_fecha_ini_vig
			// 
			this.col_fecha_ini_vig.HeaderText = "Fecha ini. Vig.";
			this.col_fecha_ini_vig.Name = "col_fecha_ini_vig";
			this.col_fecha_ini_vig.ReadOnly = true;
			this.col_fecha_ini_vig.Width = 80;
			// 
			// col_fecha_fin_vig
			// 
			this.col_fecha_fin_vig.HeaderText = "Fecha fin. Vig.";
			this.col_fecha_fin_vig.Name = "col_fecha_fin_vig";
			this.col_fecha_fin_vig.ReadOnly = true;
			this.col_fecha_fin_vig.Width = 80;
			// 
			// col_fecha_ent_mercadeo
			// 
			this.col_fecha_ent_mercadeo.HeaderText = "Fecha ent. Merc.";
			this.col_fecha_ent_mercadeo.Name = "col_fecha_ent_mercadeo";
			this.col_fecha_ent_mercadeo.ReadOnly = true;
			this.col_fecha_ent_mercadeo.Width = 90;
			// 
			// col_fecha_ent_comercial
			// 
			this.col_fecha_ent_comercial.HeaderText = "Fecha ent. Com.";
			this.col_fecha_ent_comercial.Name = "col_fecha_ent_comercial";
			this.col_fecha_ent_comercial.ReadOnly = true;
			this.col_fecha_ent_comercial.Width = 90;
			// 
			// col_id_estado
			// 
			this.col_id_estado.HeaderText = "ID_ESTADO";
			this.col_id_estado.Name = "col_id_estado";
			this.col_id_estado.ReadOnly = true;
			this.col_id_estado.Visible = false;
			// 
			// col_estado
			// 
			this.col_estado.HeaderText = "Estado";
			this.col_estado.Name = "col_estado";
			this.col_estado.ReadOnly = true;
			// 
			// col_editar
			// 
			this.col_editar.HeaderText = "";
			this.col_editar.Name = "col_editar";
			this.col_editar.ReadOnly = true;
			this.col_editar.Text = "Editar";
			this.col_editar.UseColumnTextForButtonValue = true;
			this.col_editar.Width = 70;
			// 
			// label14
			// 
			this.label14.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label14.Location = new System.Drawing.Point(208, 125);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(1, 140);
			this.label14.TabIndex = 9;
			// 
			// FrmRetroplanning
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(1112, 662);
			this.Controls.Add(this.label14);
			this.Controls.Add(this.dgv_retroplanning);
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
			this.Controls.Add(this.pnl_cab);
			this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Name = "FrmRetroplanning";
			this.Text = "Retroplanning";
			this.Load += new System.EventHandler(this.FrmRetroplanning_Load);
			this.pnl_cab.ResumeLayout(false);
			this.pnl_cab.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dgv_retroplanning)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnl_cab;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_consecutivo;
        private System.Windows.Forms.TextBox txt_nombre;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmb_tipo_dinamica;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtp_fecha_ini_vig;
        private System.Windows.Forms.DateTimePicker dtp_fecha_fin_vig;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker dtp_fecha_mercadeo;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker dtp_fecha_comecial;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.CheckedListBox clb_negociador;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.DataGridView dgv_retroplanning;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_consecutivo;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_dinamica;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_id_tipo_dinamica;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_tipo_dinamica;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_fecha_ini_vig;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_fecha_fin_vig;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_fecha_ent_mercadeo;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_fecha_ent_comercial;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_id_estado;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_estado;
        private System.Windows.Forms.DataGridViewButtonColumn col_editar;
    }
}