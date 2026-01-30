namespace PlanAccionComercial.Forms
{
	partial class FrmReporteRetroplanning
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmReporteRetroplanning));
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			this.txt_consecutivo = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.cmb_dinamicas = new System.Windows.Forms.ComboBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.pnl_cab = new System.Windows.Forms.Panel();
			this.label3 = new System.Windows.Forms.Label();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.dtp_fecha_ini = new System.Windows.Forms.DateTimePicker();
			this.dgv_reporte = new System.Windows.Forms.DataGridView();
			this.col_retroplanning = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.col_nomb_dinamica = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.col_dinamica = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.col_fecha_ini_vig = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.col_fecha_fin_vig = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.col_fecha_ent_merc = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.col_fecha_ent_comer = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.col_estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.label8 = new System.Windows.Forms.Label();
			this.dtp_fecha_fin = new System.Windows.Forms.DateTimePicker();
			this.btn_buscar = new System.Windows.Forms.Button();
			this.btn_exportar = new System.Windows.Forms.Button();
			this.btnCerrar = new System.Windows.Forms.Button();
			this.dgv_negociadores = new System.Windows.Forms.DataGridView();
			this._saveFileDialog = new System.Windows.Forms.SaveFileDialog();
			this.txt_filtrar = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.col_negociador = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.col_cargado = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.pnl_cab.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dgv_reporte)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dgv_negociadores)).BeginInit();
			this.SuspendLayout();
			// 
			// txt_consecutivo
			// 
			this.txt_consecutivo.Location = new System.Drawing.Point(530, 86);
			this.txt_consecutivo.Name = "txt_consecutivo";
			this.txt_consecutivo.Size = new System.Drawing.Size(100, 22);
			this.txt_consecutivo.TabIndex = 8;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(532, 68);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(109, 13);
			this.label1.TabIndex = 7;
			this.label1.Text = "Buscar consecutivo: ";
			// 
			// cmb_dinamicas
			// 
			this.cmb_dinamicas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmb_dinamicas.FormattingEnabled = true;
			this.cmb_dinamicas.Location = new System.Drawing.Point(228, 86);
			this.cmb_dinamicas.Name = "cmb_dinamicas";
			this.cmb_dinamicas.Size = new System.Drawing.Size(296, 21);
			this.cmb_dinamicas.TabIndex = 6;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(228, 68);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(98, 13);
			this.label5.TabIndex = 5;
			this.label5.Text = "Tipo de dinámica:";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(16, 65);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(40, 13);
			this.label7.TabIndex = 1;
			this.label7.Text = "Inicial:";
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
			this.pnl_cab.Size = new System.Drawing.Size(1135, 41);
			this.pnl_cab.TabIndex = 0;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.ForeColor = System.Drawing.Color.Black;
			this.label3.Location = new System.Drawing.Point(10, 10);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(146, 17);
			this.label3.TabIndex = 0;
			this.label3.Text = "Reporte Retroplanning";
			// 
			// pictureBox1
			// 
			this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(1017, 5);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(114, 32);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			// 
			// dtp_fecha_ini
			// 
			this.dtp_fecha_ini.CustomFormat = "dd/MM/yyyy";
			this.dtp_fecha_ini.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtp_fecha_ini.Location = new System.Drawing.Point(16, 85);
			this.dtp_fecha_ini.Name = "dtp_fecha_ini";
			this.dtp_fecha_ini.Size = new System.Drawing.Size(98, 22);
			this.dtp_fecha_ini.TabIndex = 2;
			// 
			// dgv_reporte
			// 
			this.dgv_reporte.AllowUserToAddRows = false;
			this.dgv_reporte.AllowUserToDeleteRows = false;
			this.dgv_reporte.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgv_reporte.BackgroundColor = System.Drawing.SystemColors.Window;
			this.dgv_reporte.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgv_reporte.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_retroplanning,
            this.col_nomb_dinamica,
            this.col_dinamica,
            this.col_fecha_ini_vig,
            this.col_fecha_fin_vig,
            this.col_fecha_ent_merc,
            this.col_fecha_ent_comer,
            this.col_estado});
			this.dgv_reporte.Location = new System.Drawing.Point(12, 126);
			this.dgv_reporte.MultiSelect = false;
			this.dgv_reporte.Name = "dgv_reporte";
			this.dgv_reporte.ReadOnly = true;
			this.dgv_reporte.RowHeadersVisible = false;
			this.dgv_reporte.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
			this.dgv_reporte.Size = new System.Drawing.Size(918, 420);
			this.dgv_reporte.TabIndex = 10;
			this.dgv_reporte.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_reporte_CellClick);
			// 
			// col_retroplanning
			// 
			dataGridViewCellStyle1.Format = "0000";
			this.col_retroplanning.DefaultCellStyle = dataGridViewCellStyle1;
			this.col_retroplanning.HeaderText = "Consecutivo retroplanning";
			this.col_retroplanning.Name = "col_retroplanning";
			this.col_retroplanning.ReadOnly = true;
			// 
			// col_nomb_dinamica
			// 
			this.col_nomb_dinamica.HeaderText = "Nombre dinámica";
			this.col_nomb_dinamica.Name = "col_nomb_dinamica";
			this.col_nomb_dinamica.ReadOnly = true;
			this.col_nomb_dinamica.Width = 200;
			// 
			// col_dinamica
			// 
			this.col_dinamica.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.col_dinamica.HeaderText = "Tipo dinámica";
			this.col_dinamica.Name = "col_dinamica";
			this.col_dinamica.ReadOnly = true;
			// 
			// col_fecha_ini_vig
			// 
			this.col_fecha_ini_vig.HeaderText = "Fecha ini. vig.";
			this.col_fecha_ini_vig.Name = "col_fecha_ini_vig";
			this.col_fecha_ini_vig.ReadOnly = true;
			// 
			// col_fecha_fin_vig
			// 
			this.col_fecha_fin_vig.HeaderText = "Fecha fin. vig.";
			this.col_fecha_fin_vig.Name = "col_fecha_fin_vig";
			this.col_fecha_fin_vig.ReadOnly = true;
			// 
			// col_fecha_ent_merc
			// 
			this.col_fecha_ent_merc.HeaderText = "Fecha entrega a mercadeo";
			this.col_fecha_ent_merc.Name = "col_fecha_ent_merc";
			this.col_fecha_ent_merc.ReadOnly = true;
			// 
			// col_fecha_ent_comer
			// 
			this.col_fecha_ent_comer.HeaderText = "Fecha entrega a comercial";
			this.col_fecha_ent_comer.Name = "col_fecha_ent_comer";
			this.col_fecha_ent_comer.ReadOnly = true;
			// 
			// col_estado
			// 
			this.col_estado.HeaderText = "Estado";
			this.col_estado.Name = "col_estado";
			this.col_estado.ReadOnly = true;
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(124, 65);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(35, 13);
			this.label8.TabIndex = 3;
			this.label8.Text = "Final:";
			// 
			// dtp_fecha_fin
			// 
			this.dtp_fecha_fin.CustomFormat = "dd/MM/yyyy";
			this.dtp_fecha_fin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtp_fecha_fin.Location = new System.Drawing.Point(124, 85);
			this.dtp_fecha_fin.Name = "dtp_fecha_fin";
			this.dtp_fecha_fin.Size = new System.Drawing.Size(98, 22);
			this.dtp_fecha_fin.TabIndex = 4;
			// 
			// btn_buscar
			// 
			this.btn_buscar.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_buscar.ImageKey = "diskette25.png";
			this.btn_buscar.Location = new System.Drawing.Point(642, 79);
			this.btn_buscar.Name = "btn_buscar";
			this.btn_buscar.Size = new System.Drawing.Size(92, 32);
			this.btn_buscar.TabIndex = 9;
			this.btn_buscar.Text = "&Buscar";
			this.btn_buscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btn_buscar.UseVisualStyleBackColor = true;
			this.btn_buscar.Click += new System.EventHandler(this.btn_buscar_Click);
			// 
			// btn_exportar
			// 
			this.btn_exportar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btn_exportar.Enabled = false;
			this.btn_exportar.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_exportar.ImageIndex = 2;
			this.btn_exportar.Location = new System.Drawing.Point(953, 552);
			this.btn_exportar.Name = "btn_exportar";
			this.btn_exportar.Size = new System.Drawing.Size(94, 32);
			this.btn_exportar.TabIndex = 12;
			this.btn_exportar.Text = "Exportar...";
			this.btn_exportar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btn_exportar.UseVisualStyleBackColor = true;
			this.btn_exportar.Click += new System.EventHandler(this.btn_exportar_Click);
			// 
			// btnCerrar
			// 
			this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCerrar.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnCerrar.ImageIndex = 2;
			this.btnCerrar.Location = new System.Drawing.Point(1053, 552);
			this.btnCerrar.Name = "btnCerrar";
			this.btnCerrar.Size = new System.Drawing.Size(94, 32);
			this.btnCerrar.TabIndex = 13;
			this.btnCerrar.Text = "Cerrar";
			this.btnCerrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnCerrar.UseVisualStyleBackColor = true;
			this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
			// 
			// dgv_negociadores
			// 
			this.dgv_negociadores.AllowUserToAddRows = false;
			this.dgv_negociadores.AllowUserToDeleteRows = false;
			this.dgv_negociadores.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgv_negociadores.BackgroundColor = System.Drawing.SystemColors.Window;
			this.dgv_negociadores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgv_negociadores.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_negociador,
            this.col_cargado});
			this.dgv_negociadores.Location = new System.Drawing.Point(933, 126);
			this.dgv_negociadores.MultiSelect = false;
			this.dgv_negociadores.Name = "dgv_negociadores";
			this.dgv_negociadores.ReadOnly = true;
			this.dgv_negociadores.RowHeadersVisible = false;
			this.dgv_negociadores.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
			this.dgv_negociadores.Size = new System.Drawing.Size(214, 420);
			this.dgv_negociadores.TabIndex = 11;
			// 
			// _saveFileDialog
			// 
			this._saveFileDialog.Filter = "Excel Files |*.xlsx";
			// 
			// txt_filtrar
			// 
			this.txt_filtrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.txt_filtrar.Location = new System.Drawing.Point(169, 559);
			this.txt_filtrar.Name = "txt_filtrar";
			this.txt_filtrar.Size = new System.Drawing.Size(247, 22);
			this.txt_filtrar.TabIndex = 19;
			this.txt_filtrar.TextChanged += new System.EventHandler(this.txt_filtrar_TextChanged);
			// 
			// label6
			// 
			this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(9, 562);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(154, 13);
			this.label6.TabIndex = 18;
			this.label6.Text = "Filtrar por Nombre dinámica:";
			// 
			// col_negociador
			// 
			this.col_negociador.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			dataGridViewCellStyle2.Format = "0000";
			this.col_negociador.DefaultCellStyle = dataGridViewCellStyle2;
			this.col_negociador.HeaderText = "Negociador";
			this.col_negociador.Name = "col_negociador";
			this.col_negociador.ReadOnly = true;
			// 
			// col_cargado
			// 
			this.col_cargado.FillWeight = 50F;
			this.col_cargado.HeaderText = "Cargó";
			this.col_cargado.Name = "col_cargado";
			this.col_cargado.ReadOnly = true;
			this.col_cargado.Width = 60;
			// 
			// FrmReporteRetroplanning
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(1159, 596);
			this.Controls.Add(this.txt_filtrar);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.dgv_negociadores);
			this.Controls.Add(this.btn_exportar);
			this.Controls.Add(this.btnCerrar);
			this.Controls.Add(this.txt_consecutivo);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.cmb_dinamicas);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.pnl_cab);
			this.Controls.Add(this.dtp_fecha_ini);
			this.Controls.Add(this.dgv_reporte);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.dtp_fecha_fin);
			this.Controls.Add(this.btn_buscar);
			this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Name = "FrmReporteRetroplanning";
			this.Text = "Reporte Retroplanning";
			this.Load += new System.EventHandler(this.FrmReporteRetroplanning_Load);
			this.pnl_cab.ResumeLayout(false);
			this.pnl_cab.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dgv_reporte)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dgv_negociadores)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox txt_consecutivo;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox cmb_dinamicas;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Panel pnl_cab;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.DateTimePicker dtp_fecha_ini;
		private System.Windows.Forms.DataGridView dgv_reporte;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.DateTimePicker dtp_fecha_fin;
		private System.Windows.Forms.Button btn_buscar;
		private System.Windows.Forms.Button btn_exportar;
		private System.Windows.Forms.Button btnCerrar;
		private System.Windows.Forms.DataGridView dgv_negociadores;
		private System.Windows.Forms.DataGridViewTextBoxColumn col_retroplanning;
		private System.Windows.Forms.DataGridViewTextBoxColumn col_nomb_dinamica;
		private System.Windows.Forms.DataGridViewTextBoxColumn col_dinamica;
		private System.Windows.Forms.DataGridViewTextBoxColumn col_fecha_ini_vig;
		private System.Windows.Forms.DataGridViewTextBoxColumn col_fecha_fin_vig;
		private System.Windows.Forms.DataGridViewTextBoxColumn col_fecha_ent_merc;
		private System.Windows.Forms.DataGridViewTextBoxColumn col_fecha_ent_comer;
		private System.Windows.Forms.DataGridViewTextBoxColumn col_estado;
		private System.Windows.Forms.SaveFileDialog _saveFileDialog;
		private System.Windows.Forms.TextBox txt_filtrar;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.DataGridViewTextBoxColumn col_negociador;
		private System.Windows.Forms.DataGridViewCheckBoxColumn col_cargado;
	}
}