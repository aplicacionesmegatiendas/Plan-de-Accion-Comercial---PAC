namespace PlanAccionComercial.Forms
{
    partial class FrmReporteOperaciones
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmReporteOperaciones));
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle31 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle32 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle33 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle34 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle35 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle36 = new System.Windows.Forms.DataGridViewCellStyle();
			this.pnl_cab = new System.Windows.Forms.Panel();
			this.label3 = new System.Windows.Forms.Label();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.label1 = new System.Windows.Forms.Label();
			this.dtp_fecha_ini = new System.Windows.Forms.DateTimePicker();
			this.dtp_fecha_fin = new System.Windows.Forms.DateTimePicker();
			this.label2 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.cmb_co = new System.Windows.Forms.ComboBox();
			this.dgv_datos = new System.Windows.Forms.DataGridView();
			this.col_co = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.col_item = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.col_ref = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.col_desc = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.col_plan = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.col_criterio = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.col_fecha_ini = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.col_fecha_fin = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.col_tipo_dinamica = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.col_tipo_exh = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.col_descuento = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.col_precio = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.col_existencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.col_tipo_com = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.btn_buscar = new System.Windows.Forms.Button();
			this.btnCerrar = new System.Windows.Forms.Button();
			this.btn_exportar = new System.Windows.Forms.Button();
			this._saveFileDialog = new System.Windows.Forms.SaveFileDialog();
			this.cmb_dinamicas = new System.Windows.Forms.ComboBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.txt_filtrar = new System.Windows.Forms.TextBox();
			this.pnl_cab.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dgv_datos)).BeginInit();
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
			this.pnl_cab.Size = new System.Drawing.Size(809, 41);
			this.pnl_cab.TabIndex = 0;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.ForeColor = System.Drawing.Color.Black;
			this.label3.Location = new System.Drawing.Point(10, 10);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(133, 17);
			this.label3.TabIndex = 0;
			this.label3.Text = "Reporte operaciones";
			// 
			// pictureBox1
			// 
			this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(691, 5);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(114, 32);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(9, 71);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(77, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Fecha ini. vig.";
			// 
			// dtp_fecha_ini
			// 
			this.dtp_fecha_ini.CustomFormat = "dd/MM/yyyy";
			this.dtp_fecha_ini.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtp_fecha_ini.Location = new System.Drawing.Point(12, 90);
			this.dtp_fecha_ini.Name = "dtp_fecha_ini";
			this.dtp_fecha_ini.Size = new System.Drawing.Size(96, 22);
			this.dtp_fecha_ini.TabIndex = 2;
			// 
			// dtp_fecha_fin
			// 
			this.dtp_fecha_fin.CustomFormat = "dd/MM/yyyy";
			this.dtp_fecha_fin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtp_fecha_fin.Location = new System.Drawing.Point(114, 90);
			this.dtp_fecha_fin.Name = "dtp_fecha_fin";
			this.dtp_fecha_fin.Size = new System.Drawing.Size(96, 22);
			this.dtp_fecha_fin.TabIndex = 4;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(111, 71);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(78, 13);
			this.label2.TabIndex = 3;
			this.label2.Text = "Fecha fin. vig.";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(12, 122);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(100, 13);
			this.label4.TabIndex = 5;
			this.label4.Text = "Centro operación:";
			// 
			// cmb_co
			// 
			this.cmb_co.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmb_co.FormattingEnabled = true;
			this.cmb_co.Location = new System.Drawing.Point(12, 140);
			this.cmb_co.Name = "cmb_co";
			this.cmb_co.Size = new System.Drawing.Size(198, 21);
			this.cmb_co.TabIndex = 6;
			// 
			// dgv_datos
			// 
			this.dgv_datos.AllowUserToAddRows = false;
			this.dgv_datos.AllowUserToDeleteRows = false;
			this.dgv_datos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgv_datos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
			this.dgv_datos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
			this.dgv_datos.BackgroundColor = System.Drawing.SystemColors.Window;
			this.dgv_datos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgv_datos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_co,
            this.col_item,
            this.col_ref,
            this.col_desc,
            this.col_plan,
            this.col_criterio,
            this.col_fecha_ini,
            this.col_fecha_fin,
            this.col_tipo_dinamica,
            this.col_tipo_exh,
            this.col_descuento,
            this.col_precio,
            this.col_existencia,
            this.col_tipo_com});
			this.dgv_datos.Location = new System.Drawing.Point(12, 179);
			this.dgv_datos.Name = "dgv_datos";
			this.dgv_datos.ReadOnly = true;
			this.dgv_datos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgv_datos.Size = new System.Drawing.Size(809, 308);
			this.dgv_datos.TabIndex = 10;
			this.dgv_datos.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgv_datos_RowPostPaint);
			// 
			// col_co
			// 
			this.col_co.HeaderText = "Centro operación";
			this.col_co.Name = "col_co";
			this.col_co.ReadOnly = true;
			this.col_co.Width = 112;
			// 
			// col_item
			// 
			this.col_item.HeaderText = "Ítem";
			this.col_item.Name = "col_item";
			this.col_item.ReadOnly = true;
			this.col_item.Width = 54;
			// 
			// col_ref
			// 
			this.col_ref.HeaderText = "Referencia";
			this.col_ref.Name = "col_ref";
			this.col_ref.ReadOnly = true;
			this.col_ref.Width = 86;
			// 
			// col_desc
			// 
			this.col_desc.HeaderText = "Descripción";
			this.col_desc.Name = "col_desc";
			this.col_desc.ReadOnly = true;
			this.col_desc.Width = 92;
			// 
			// col_plan
			// 
			this.col_plan.HeaderText = "Plan";
			this.col_plan.Name = "col_plan";
			this.col_plan.ReadOnly = true;
			this.col_plan.Width = 54;
			// 
			// col_criterio
			// 
			this.col_criterio.HeaderText = "Criterio";
			this.col_criterio.Name = "col_criterio";
			this.col_criterio.ReadOnly = true;
			this.col_criterio.Width = 70;
			// 
			// col_fecha_ini
			// 
			dataGridViewCellStyle31.Format = "d";
			dataGridViewCellStyle31.NullValue = null;
			this.col_fecha_ini.DefaultCellStyle = dataGridViewCellStyle31;
			this.col_fecha_ini.HeaderText = "Fecha ini.";
			this.col_fecha_ini.Name = "col_fecha_ini";
			this.col_fecha_ini.ReadOnly = true;
			this.col_fecha_ini.Width = 75;
			// 
			// col_fecha_fin
			// 
			dataGridViewCellStyle32.Format = "d";
			dataGridViewCellStyle32.NullValue = null;
			this.col_fecha_fin.DefaultCellStyle = dataGridViewCellStyle32;
			this.col_fecha_fin.HeaderText = "Fecha fin.";
			this.col_fecha_fin.Name = "col_fecha_fin";
			this.col_fecha_fin.ReadOnly = true;
			this.col_fecha_fin.Width = 76;
			// 
			// col_tipo_dinamica
			// 
			this.col_tipo_dinamica.HeaderText = "Tipo dinámica";
			this.col_tipo_dinamica.Name = "col_tipo_dinamica";
			this.col_tipo_dinamica.ReadOnly = true;
			this.col_tipo_dinamica.Width = 96;
			// 
			// col_tipo_exh
			// 
			this.col_tipo_exh.HeaderText = "Tipo exhibición";
			this.col_tipo_exh.Name = "col_tipo_exh";
			this.col_tipo_exh.ReadOnly = true;
			this.col_tipo_exh.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.col_tipo_exh.Width = 83;
			// 
			// col_descuento
			// 
			dataGridViewCellStyle33.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			dataGridViewCellStyle33.Format = "N2";
			dataGridViewCellStyle33.NullValue = null;
			this.col_descuento.DefaultCellStyle = dataGridViewCellStyle33;
			this.col_descuento.HeaderText = "Descuento";
			this.col_descuento.Name = "col_descuento";
			this.col_descuento.ReadOnly = true;
			this.col_descuento.Width = 87;
			// 
			// col_precio
			// 
			dataGridViewCellStyle34.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			dataGridViewCellStyle34.Format = "N2";
			dataGridViewCellStyle34.NullValue = null;
			this.col_precio.DefaultCellStyle = dataGridViewCellStyle34;
			this.col_precio.HeaderText = "Precio";
			this.col_precio.Name = "col_precio";
			this.col_precio.ReadOnly = true;
			this.col_precio.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.col_precio.Width = 44;
			// 
			// col_existencia
			// 
			dataGridViewCellStyle35.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			dataGridViewCellStyle35.Format = "N2";
			dataGridViewCellStyle35.NullValue = null;
			this.col_existencia.DefaultCellStyle = dataGridViewCellStyle35;
			this.col_existencia.HeaderText = "Existencia";
			this.col_existencia.Name = "col_existencia";
			this.col_existencia.ReadOnly = true;
			this.col_existencia.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.col_existencia.Width = 63;
			// 
			// col_tipo_com
			// 
			dataGridViewCellStyle36.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.col_tipo_com.DefaultCellStyle = dataGridViewCellStyle36;
			this.col_tipo_com.HeaderText = "Observación";
			this.col_tipo_com.Name = "col_tipo_com";
			this.col_tipo_com.ReadOnly = true;
			this.col_tipo_com.Visible = false;
			this.col_tipo_com.Width = 96;
			// 
			// btn_buscar
			// 
			this.btn_buscar.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_buscar.ImageIndex = 2;
			this.btn_buscar.Location = new System.Drawing.Point(518, 133);
			this.btn_buscar.Name = "btn_buscar";
			this.btn_buscar.Size = new System.Drawing.Size(94, 32);
			this.btn_buscar.TabIndex = 9;
			this.btn_buscar.Text = "&Buscar";
			this.btn_buscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btn_buscar.UseVisualStyleBackColor = true;
			this.btn_buscar.Click += new System.EventHandler(this.btn_buscar_Click);
			// 
			// btnCerrar
			// 
			this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCerrar.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnCerrar.ImageIndex = 2;
			this.btnCerrar.Location = new System.Drawing.Point(727, 493);
			this.btnCerrar.Name = "btnCerrar";
			this.btnCerrar.Size = new System.Drawing.Size(94, 32);
			this.btnCerrar.TabIndex = 14;
			this.btnCerrar.Text = "Cerrar";
			this.btnCerrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnCerrar.UseVisualStyleBackColor = true;
			this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
			// 
			// btn_exportar
			// 
			this.btn_exportar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btn_exportar.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_exportar.ImageIndex = 2;
			this.btn_exportar.Location = new System.Drawing.Point(625, 493);
			this.btn_exportar.Name = "btn_exportar";
			this.btn_exportar.Size = new System.Drawing.Size(94, 32);
			this.btn_exportar.TabIndex = 13;
			this.btn_exportar.Text = "Exportar...";
			this.btn_exportar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btn_exportar.UseVisualStyleBackColor = true;
			this.btn_exportar.Click += new System.EventHandler(this.btn_exportar_Click);
			// 
			// _saveFileDialog
			// 
			this._saveFileDialog.Filter = "Excel Files |*.xlsx";
			// 
			// cmb_dinamicas
			// 
			this.cmb_dinamicas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmb_dinamicas.FormattingEnabled = true;
			this.cmb_dinamicas.Location = new System.Drawing.Point(216, 140);
			this.cmb_dinamicas.Name = "cmb_dinamicas";
			this.cmb_dinamicas.Size = new System.Drawing.Size(296, 21);
			this.cmb_dinamicas.TabIndex = 8;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(216, 122);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(98, 13);
			this.label5.TabIndex = 7;
			this.label5.Text = "Tipo de dinámica:";
			// 
			// label6
			// 
			this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(15, 508);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(223, 13);
			this.label6.TabIndex = 11;
			this.label6.Text = "Filtrar por Descripción y Tipo de dinámica:";
			// 
			// txt_filtrar
			// 
			this.txt_filtrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.txt_filtrar.Location = new System.Drawing.Point(245, 505);
			this.txt_filtrar.Name = "txt_filtrar";
			this.txt_filtrar.Size = new System.Drawing.Size(247, 22);
			this.txt_filtrar.TabIndex = 12;
			this.txt_filtrar.TextChanged += new System.EventHandler(this.txt_filtrar_TextChanged);
			// 
			// FrmReporteOperaciones
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(833, 533);
			this.Controls.Add(this.txt_filtrar);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.cmb_dinamicas);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.btn_exportar);
			this.Controls.Add(this.btnCerrar);
			this.Controls.Add(this.btn_buscar);
			this.Controls.Add(this.dgv_datos);
			this.Controls.Add(this.cmb_co);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.dtp_fecha_fin);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.dtp_fecha_ini);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.pnl_cab);
			this.DoubleBuffered = true;
			this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Name = "FrmReporteOperaciones";
			this.Text = "Reporte operaciones";
			this.Load += new System.EventHandler(this.FrmReporteOperaciones_Load);
			this.pnl_cab.ResumeLayout(false);
			this.pnl_cab.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dgv_datos)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnl_cab;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtp_fecha_ini;
        private System.Windows.Forms.DateTimePicker dtp_fecha_fin;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmb_co;
        private System.Windows.Forms.DataGridView dgv_datos;
        private System.Windows.Forms.Button btn_buscar;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Button btn_exportar;
        private System.Windows.Forms.SaveFileDialog _saveFileDialog;
        private System.Windows.Forms.ComboBox cmb_dinamicas;
        private System.Windows.Forms.Label label5;
		private System.Windows.Forms.DataGridViewTextBoxColumn col_co;
		private System.Windows.Forms.DataGridViewTextBoxColumn col_item;
		private System.Windows.Forms.DataGridViewTextBoxColumn col_ref;
		private System.Windows.Forms.DataGridViewTextBoxColumn col_desc;
		private System.Windows.Forms.DataGridViewTextBoxColumn col_plan;
		private System.Windows.Forms.DataGridViewTextBoxColumn col_criterio;
		private System.Windows.Forms.DataGridViewTextBoxColumn col_fecha_ini;
		private System.Windows.Forms.DataGridViewTextBoxColumn col_fecha_fin;
		private System.Windows.Forms.DataGridViewTextBoxColumn col_tipo_dinamica;
		private System.Windows.Forms.DataGridViewTextBoxColumn col_tipo_exh;
		private System.Windows.Forms.DataGridViewTextBoxColumn col_descuento;
		private System.Windows.Forms.DataGridViewTextBoxColumn col_precio;
		private System.Windows.Forms.DataGridViewTextBoxColumn col_existencia;
		private System.Windows.Forms.DataGridViewTextBoxColumn col_tipo_com;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox txt_filtrar;
	}
}