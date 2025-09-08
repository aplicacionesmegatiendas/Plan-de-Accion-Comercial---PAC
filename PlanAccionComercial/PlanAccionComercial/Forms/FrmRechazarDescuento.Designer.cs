namespace PlanAccionComercial.Forms
{
    partial class FrmRechazarDescuento
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRechazarDescuento));
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
			this.pnl_cab = new System.Windows.Forms.Panel();
			this.label3 = new System.Windows.Forms.Label();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.label2 = new System.Windows.Forms.Label();
			this.dtp_fecha_desde = new System.Windows.Forms.DateTimePicker();
			this.dtp_fecha_hasta = new System.Windows.Forms.DateTimePicker();
			this.label4 = new System.Windows.Forms.Label();
			this.dgv_descuento = new System.Windows.Forms.DataGridView();
			this.col_retroplanning = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.col_nombre_dinamica = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.col_fecha_ini_vig = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.col_fecha_fin_vig = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.col_cosecutivo = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.col_dinamica = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.col_fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.col_negociador = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.col_id_usuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.col_ver = new System.Windows.Forms.DataGridViewButtonColumn();
			this.col_rechazar2 = new System.Windows.Forms.DataGridViewButtonColumn();
			this.btn_buscar = new System.Windows.Forms.Button();
			this.dgv_detalle = new System.Windows.Forms.DataGridView();
			this.col_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.col_co = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.col_item = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.col_desc = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.col_plan = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.col_criterio = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.col_fecha_ini = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.col_fecha_fin = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.col_precio = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.col_tipo_desc = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.col_descuento = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.col_precio_fin = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.col_obs = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.col_rechazar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.label5 = new System.Windows.Forms.Label();
			this.btn_cerrar = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.btn_rechazar = new System.Windows.Forms.Button();
			this.pnl_cab.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dgv_descuento)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dgv_detalle)).BeginInit();
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
			this.pnl_cab.Size = new System.Drawing.Size(1208, 41);
			this.pnl_cab.TabIndex = 0;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.ForeColor = System.Drawing.Color.Black;
			this.label3.Location = new System.Drawing.Point(10, 10);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(129, 17);
			this.label3.TabIndex = 0;
			this.label3.Text = "Rechazar descuento";
			// 
			// pictureBox1
			// 
			this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(1090, 5);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(114, 32);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 85);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(40, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "Inicial:";
			// 
			// dtp_fecha_desde
			// 
			this.dtp_fecha_desde.CustomFormat = "dd/MM/yyyy";
			this.dtp_fecha_desde.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtp_fecha_desde.Location = new System.Drawing.Point(12, 101);
			this.dtp_fecha_desde.Name = "dtp_fecha_desde";
			this.dtp_fecha_desde.Size = new System.Drawing.Size(96, 22);
			this.dtp_fecha_desde.TabIndex = 3;
			// 
			// dtp_fecha_hasta
			// 
			this.dtp_fecha_hasta.CustomFormat = "dd/MM/yyyy";
			this.dtp_fecha_hasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtp_fecha_hasta.Location = new System.Drawing.Point(114, 101);
			this.dtp_fecha_hasta.Name = "dtp_fecha_hasta";
			this.dtp_fecha_hasta.Size = new System.Drawing.Size(96, 22);
			this.dtp_fecha_hasta.TabIndex = 5;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(114, 85);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(35, 13);
			this.label4.TabIndex = 4;
			this.label4.Text = "Final:";
			// 
			// dgv_descuento
			// 
			this.dgv_descuento.AllowUserToAddRows = false;
			this.dgv_descuento.AllowUserToDeleteRows = false;
			this.dgv_descuento.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgv_descuento.BackgroundColor = System.Drawing.SystemColors.Window;
			this.dgv_descuento.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgv_descuento.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_retroplanning,
            this.col_nombre_dinamica,
            this.col_fecha_ini_vig,
            this.col_fecha_fin_vig,
            this.col_cosecutivo,
            this.col_dinamica,
            this.col_fecha,
            this.col_negociador,
            this.col_id_usuario,
            this.col_ver,
            this.col_rechazar2});
			this.dgv_descuento.Location = new System.Drawing.Point(12, 135);
			this.dgv_descuento.Name = "dgv_descuento";
			this.dgv_descuento.ReadOnly = true;
			this.dgv_descuento.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgv_descuento.Size = new System.Drawing.Size(1204, 153);
			this.dgv_descuento.TabIndex = 7;
			this.dgv_descuento.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_descuento_CellContentClick);
			this.dgv_descuento.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgv_descuento_RowPostPaint);
			// 
			// col_retroplanning
			// 
			dataGridViewCellStyle1.Format = "0000";
			this.col_retroplanning.DefaultCellStyle = dataGridViewCellStyle1;
			this.col_retroplanning.HeaderText = "Retroplanning";
			this.col_retroplanning.Name = "col_retroplanning";
			this.col_retroplanning.ReadOnly = true;
			// 
			// col_nombre_dinamica
			// 
			this.col_nombre_dinamica.HeaderText = "Nombre dinámica";
			this.col_nombre_dinamica.Name = "col_nombre_dinamica";
			this.col_nombre_dinamica.ReadOnly = true;
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
			// col_cosecutivo
			// 
			dataGridViewCellStyle2.Format = "0000";
			dataGridViewCellStyle2.NullValue = null;
			this.col_cosecutivo.DefaultCellStyle = dataGridViewCellStyle2;
			this.col_cosecutivo.HeaderText = "Descuento";
			this.col_cosecutivo.Name = "col_cosecutivo";
			this.col_cosecutivo.ReadOnly = true;
			// 
			// col_dinamica
			// 
			this.col_dinamica.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.col_dinamica.HeaderText = "Tipo dinámica";
			this.col_dinamica.Name = "col_dinamica";
			this.col_dinamica.ReadOnly = true;
			// 
			// col_fecha
			// 
			this.col_fecha.HeaderText = "Fecha";
			this.col_fecha.Name = "col_fecha";
			this.col_fecha.ReadOnly = true;
			this.col_fecha.Width = 120;
			// 
			// col_negociador
			// 
			this.col_negociador.HeaderText = "Negociador";
			this.col_negociador.Name = "col_negociador";
			this.col_negociador.ReadOnly = true;
			// 
			// col_id_usuario
			// 
			this.col_id_usuario.HeaderText = "ID_USUARIO";
			this.col_id_usuario.Name = "col_id_usuario";
			this.col_id_usuario.ReadOnly = true;
			this.col_id_usuario.Visible = false;
			// 
			// col_ver
			// 
			this.col_ver.HeaderText = "";
			this.col_ver.Name = "col_ver";
			this.col_ver.ReadOnly = true;
			this.col_ver.Text = "Detalle";
			this.col_ver.UseColumnTextForButtonValue = true;
			this.col_ver.Width = 55;
			// 
			// col_rechazar2
			// 
			this.col_rechazar2.HeaderText = "";
			this.col_rechazar2.Name = "col_rechazar2";
			this.col_rechazar2.ReadOnly = true;
			this.col_rechazar2.Text = "Rechazar";
			this.col_rechazar2.UseColumnTextForButtonValue = true;
			this.col_rechazar2.Width = 60;
			// 
			// btn_buscar
			// 
			this.btn_buscar.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_buscar.ImageIndex = 2;
			this.btn_buscar.Location = new System.Drawing.Point(216, 94);
			this.btn_buscar.Name = "btn_buscar";
			this.btn_buscar.Size = new System.Drawing.Size(94, 32);
			this.btn_buscar.TabIndex = 6;
			this.btn_buscar.Text = "&Buscar";
			this.btn_buscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btn_buscar.UseVisualStyleBackColor = true;
			this.btn_buscar.Click += new System.EventHandler(this.btn_buscar_Click);
			// 
			// dgv_detalle
			// 
			this.dgv_detalle.AllowUserToAddRows = false;
			this.dgv_detalle.AllowUserToDeleteRows = false;
			this.dgv_detalle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgv_detalle.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
			this.dgv_detalle.BackgroundColor = System.Drawing.SystemColors.Window;
			this.dgv_detalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgv_detalle.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_id,
            this.col_co,
            this.col_item,
            this.col_desc,
            this.col_plan,
            this.col_criterio,
            this.col_fecha_ini,
            this.col_fecha_fin,
            this.col_precio,
            this.col_tipo_desc,
            this.col_descuento,
            this.col_precio_fin,
            this.col_obs,
            this.col_rechazar});
			this.dgv_detalle.Location = new System.Drawing.Point(12, 310);
			this.dgv_detalle.Name = "dgv_detalle";
			this.dgv_detalle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgv_detalle.Size = new System.Drawing.Size(1204, 295);
			this.dgv_detalle.TabIndex = 9;
			this.dgv_detalle.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgv_detalle_RowPostPaint);
			// 
			// col_id
			// 
			this.col_id.HeaderText = "ID";
			this.col_id.Name = "col_id";
			this.col_id.Visible = false;
			// 
			// col_co
			// 
			this.col_co.HeaderText = "Centro operación";
			this.col_co.Name = "col_co";
			// 
			// col_item
			// 
			this.col_item.HeaderText = "Ítem";
			this.col_item.Name = "col_item";
			// 
			// col_desc
			// 
			this.col_desc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.col_desc.HeaderText = "Descripción";
			this.col_desc.Name = "col_desc";
			// 
			// col_plan
			// 
			this.col_plan.HeaderText = "Plan";
			this.col_plan.Name = "col_plan";
			this.col_plan.Width = 50;
			// 
			// col_criterio
			// 
			this.col_criterio.HeaderText = "Criterio";
			this.col_criterio.Name = "col_criterio";
			this.col_criterio.Width = 50;
			// 
			// col_fecha_ini
			// 
			this.col_fecha_ini.HeaderText = "Fecha ini.";
			this.col_fecha_ini.Name = "col_fecha_ini";
			// 
			// col_fecha_fin
			// 
			this.col_fecha_fin.HeaderText = "Fecha fin.";
			this.col_fecha_fin.Name = "col_fecha_fin";
			// 
			// col_precio
			// 
			dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			dataGridViewCellStyle3.Format = "N2";
			dataGridViewCellStyle3.NullValue = null;
			this.col_precio.DefaultCellStyle = dataGridViewCellStyle3;
			this.col_precio.HeaderText = "Precio";
			this.col_precio.Name = "col_precio";
			// 
			// col_tipo_desc
			// 
			this.col_tipo_desc.HeaderText = "TIPO_DESC";
			this.col_tipo_desc.Name = "col_tipo_desc";
			this.col_tipo_desc.Visible = false;
			// 
			// col_descuento
			// 
			dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			dataGridViewCellStyle4.Format = "N2";
			dataGridViewCellStyle4.NullValue = null;
			this.col_descuento.DefaultCellStyle = dataGridViewCellStyle4;
			this.col_descuento.HeaderText = "Descuento";
			this.col_descuento.Name = "col_descuento";
			this.col_descuento.Width = 70;
			// 
			// col_precio_fin
			// 
			dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			dataGridViewCellStyle5.Format = "N2";
			dataGridViewCellStyle5.NullValue = null;
			this.col_precio_fin.DefaultCellStyle = dataGridViewCellStyle5;
			this.col_precio_fin.HeaderText = "Precio final";
			this.col_precio_fin.Name = "col_precio_fin";
			// 
			// col_obs
			// 
			dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.col_obs.DefaultCellStyle = dataGridViewCellStyle6;
			this.col_obs.HeaderText = "Observación";
			this.col_obs.Name = "col_obs";
			this.col_obs.Width = 150;
			// 
			// col_rechazar
			// 
			this.col_rechazar.HeaderText = "";
			this.col_rechazar.Name = "col_rechazar";
			this.col_rechazar.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.col_rechazar.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.col_rechazar.Width = 70;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(12, 294);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(43, 13);
			this.label5.TabIndex = 8;
			this.label5.Text = "Detalle";
			// 
			// btn_cerrar
			// 
			this.btn_cerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btn_cerrar.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_cerrar.ImageIndex = 2;
			this.btn_cerrar.Location = new System.Drawing.Point(1125, 609);
			this.btn_cerrar.Name = "btn_cerrar";
			this.btn_cerrar.Size = new System.Drawing.Size(94, 32);
			this.btn_cerrar.TabIndex = 11;
			this.btn_cerrar.Text = "&Cerrar";
			this.btn_cerrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btn_cerrar.UseVisualStyleBackColor = true;
			this.btn_cerrar.Click += new System.EventHandler(this.btn_cerrar_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(13, 63);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Fecha de creación:";
			// 
			// btn_rechazar
			// 
			this.btn_rechazar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btn_rechazar.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_rechazar.ImageIndex = 2;
			this.btn_rechazar.Location = new System.Drawing.Point(1023, 609);
			this.btn_rechazar.Name = "btn_rechazar";
			this.btn_rechazar.Size = new System.Drawing.Size(94, 32);
			this.btn_rechazar.TabIndex = 10;
			this.btn_rechazar.Text = "&Rechazar";
			this.btn_rechazar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btn_rechazar.UseVisualStyleBackColor = true;
			this.btn_rechazar.Click += new System.EventHandler(this.btn_rechazar_Click);
			// 
			// FrmRechazarDescuento
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(1232, 655);
			this.Controls.Add(this.btn_rechazar);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btn_cerrar);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.dgv_detalle);
			this.Controls.Add(this.btn_buscar);
			this.Controls.Add(this.dgv_descuento);
			this.Controls.Add(this.dtp_fecha_hasta);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.dtp_fecha_desde);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.pnl_cab);
			this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Name = "FrmRechazarDescuento";
			this.Text = "Rechazar descuento";
			this.Load += new System.EventHandler(this.FrmRechazarDescuento_Load);
			this.pnl_cab.ResumeLayout(false);
			this.pnl_cab.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dgv_descuento)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dgv_detalle)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnl_cab;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtp_fecha_desde;
        private System.Windows.Forms.DateTimePicker dtp_fecha_hasta;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgv_descuento;
        private System.Windows.Forms.Button btn_buscar;
        private System.Windows.Forms.DataGridView dgv_detalle;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btn_cerrar;
        private System.Windows.Forms.Label label1;
		private System.Windows.Forms.DataGridViewTextBoxColumn col_retroplanning;
		private System.Windows.Forms.DataGridViewTextBoxColumn col_nombre_dinamica;
		private System.Windows.Forms.DataGridViewTextBoxColumn col_fecha_ini_vig;
		private System.Windows.Forms.DataGridViewTextBoxColumn col_fecha_fin_vig;
		private System.Windows.Forms.DataGridViewTextBoxColumn col_cosecutivo;
		private System.Windows.Forms.DataGridViewTextBoxColumn col_dinamica;
		private System.Windows.Forms.DataGridViewTextBoxColumn col_fecha;
		private System.Windows.Forms.DataGridViewTextBoxColumn col_negociador;
		private System.Windows.Forms.DataGridViewTextBoxColumn col_id_usuario;
		private System.Windows.Forms.DataGridViewButtonColumn col_ver;
		private System.Windows.Forms.DataGridViewButtonColumn col_rechazar2;
		private System.Windows.Forms.Button btn_rechazar;
		private System.Windows.Forms.DataGridViewTextBoxColumn col_id;
		private System.Windows.Forms.DataGridViewTextBoxColumn col_co;
		private System.Windows.Forms.DataGridViewTextBoxColumn col_item;
		private System.Windows.Forms.DataGridViewTextBoxColumn col_desc;
		private System.Windows.Forms.DataGridViewTextBoxColumn col_plan;
		private System.Windows.Forms.DataGridViewTextBoxColumn col_criterio;
		private System.Windows.Forms.DataGridViewTextBoxColumn col_fecha_ini;
		private System.Windows.Forms.DataGridViewTextBoxColumn col_fecha_fin;
		private System.Windows.Forms.DataGridViewTextBoxColumn col_precio;
		private System.Windows.Forms.DataGridViewTextBoxColumn col_tipo_desc;
		private System.Windows.Forms.DataGridViewTextBoxColumn col_descuento;
		private System.Windows.Forms.DataGridViewTextBoxColumn col_precio_fin;
		private System.Windows.Forms.DataGridViewTextBoxColumn col_obs;
		private System.Windows.Forms.DataGridViewCheckBoxColumn col_rechazar;
	}
}