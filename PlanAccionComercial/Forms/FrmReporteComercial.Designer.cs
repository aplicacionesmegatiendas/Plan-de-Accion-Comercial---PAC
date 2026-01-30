namespace PlanAccionComercial.Forms
{
    partial class FrmReporteComercial
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmReporteComercial));
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle31 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle32 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle33 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle34 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle35 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle36 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle37 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle38 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle39 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle40 = new System.Windows.Forms.DataGridViewCellStyle();
			this.txt_consecutivo = new System.Windows.Forms.TextBox();
			this.chk_descuento = new System.Windows.Forms.CheckBox();
			this.chk_retro = new System.Windows.Forms.CheckBox();
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
			this.col_fecha_ini_vig = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.col_fecha_fin_vig = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.col_consecutivo = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.col_dinamica = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.col_fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.col_negociador = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.col_estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.col_detalle = new System.Windows.Forms.DataGridViewButtonColumn();
			this.col_cargado = new System.Windows.Forms.DataGridViewButtonColumn();
			this.label8 = new System.Windows.Forms.Label();
			this.dtp_fecha_fin = new System.Windows.Forms.DateTimePicker();
			this.btn_buscar = new System.Windows.Forms.Button();
			this.btn_exportar = new System.Windows.Forms.Button();
			this.dgv_detalle = new System.Windows.Forms.DataGridView();
			this.col_item = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.col_referencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.col_desc = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.col_nit = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.col_casa_prov = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.col_fecha_ini = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.col_fecha_fin = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.col_modo_cobro = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.col_descuento = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.col_tipo_desc = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.col_asume_prov = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.col_asume_mega = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.col_precio_antes = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.col_precio_fin = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.col_pum = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.col_existencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.col_cod_co = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.col_co = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.col_regional = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.col_obs = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.col_ind_reg = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.btnCerrar = new System.Windows.Forms.Button();
			this._saveFileDialog = new System.Windows.Forms.SaveFileDialog();
			this.txt_filtrar = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.pnl_cab.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dgv_reporte)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dgv_detalle)).BeginInit();
			this.SuspendLayout();
			// 
			// txt_consecutivo
			// 
			this.txt_consecutivo.Location = new System.Drawing.Point(650, 89);
			this.txt_consecutivo.Name = "txt_consecutivo";
			this.txt_consecutivo.Size = new System.Drawing.Size(100, 22);
			this.txt_consecutivo.TabIndex = 10;
			// 
			// chk_descuento
			// 
			this.chk_descuento.AutoSize = true;
			this.chk_descuento.Location = new System.Drawing.Point(543, 101);
			this.chk_descuento.Name = "chk_descuento";
			this.chk_descuento.Size = new System.Drawing.Size(81, 17);
			this.chk_descuento.TabIndex = 9;
			this.chk_descuento.Text = "Descuento";
			this.chk_descuento.UseVisualStyleBackColor = true;
			this.chk_descuento.CheckedChanged += new System.EventHandler(this.chk_descuento_CheckedChanged);
			// 
			// chk_retro
			// 
			this.chk_retro.AutoSize = true;
			this.chk_retro.Location = new System.Drawing.Point(543, 79);
			this.chk_retro.Name = "chk_retro";
			this.chk_retro.Size = new System.Drawing.Size(101, 17);
			this.chk_retro.TabIndex = 8;
			this.chk_retro.Text = "Retroplanning";
			this.chk_retro.UseVisualStyleBackColor = true;
			this.chk_retro.CheckedChanged += new System.EventHandler(this.chk_retro_CheckedChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(540, 60);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(125, 13);
			this.label1.TabIndex = 7;
			this.label1.Text = "Buscar consecutivo de: ";
			// 
			// cmb_dinamicas
			// 
			this.cmb_dinamicas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmb_dinamicas.FormattingEnabled = true;
			this.cmb_dinamicas.Location = new System.Drawing.Point(224, 86);
			this.cmb_dinamicas.Name = "cmb_dinamicas";
			this.cmb_dinamicas.Size = new System.Drawing.Size(296, 21);
			this.cmb_dinamicas.TabIndex = 6;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(224, 68);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(98, 13);
			this.label5.TabIndex = 5;
			this.label5.Text = "Tipo de dinámica:";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(12, 65);
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
			this.pnl_cab.Location = new System.Drawing.Point(8, 12);
			this.pnl_cab.Name = "pnl_cab";
			this.pnl_cab.Size = new System.Drawing.Size(1000, 41);
			this.pnl_cab.TabIndex = 0;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.ForeColor = System.Drawing.Color.Black;
			this.label3.Location = new System.Drawing.Point(10, 10);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(117, 17);
			this.label3.TabIndex = 0;
			this.label3.Text = "Reporte comercial";
			// 
			// pictureBox1
			// 
			this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(882, 5);
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
			this.dtp_fecha_ini.Location = new System.Drawing.Point(12, 85);
			this.dtp_fecha_ini.Name = "dtp_fecha_ini";
			this.dtp_fecha_ini.Size = new System.Drawing.Size(98, 22);
			this.dtp_fecha_ini.TabIndex = 2;
			// 
			// dgv_reporte
			// 
			this.dgv_reporte.AllowUserToAddRows = false;
			this.dgv_reporte.AllowUserToDeleteRows = false;
			this.dgv_reporte.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgv_reporte.BackgroundColor = System.Drawing.SystemColors.Window;
			this.dgv_reporte.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgv_reporte.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_retroplanning,
            this.col_nomb_dinamica,
            this.col_fecha_ini_vig,
            this.col_fecha_fin_vig,
            this.col_consecutivo,
            this.col_dinamica,
            this.col_fecha,
            this.col_negociador,
            this.col_estado,
            this.col_detalle,
            this.col_cargado});
			this.dgv_reporte.Location = new System.Drawing.Point(8, 126);
			this.dgv_reporte.MultiSelect = false;
			this.dgv_reporte.Name = "dgv_reporte";
			this.dgv_reporte.ReadOnly = true;
			this.dgv_reporte.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
			this.dgv_reporte.Size = new System.Drawing.Size(996, 187);
			this.dgv_reporte.TabIndex = 12;
			this.dgv_reporte.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_reporte_CellContentClick);
			this.dgv_reporte.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgv_reporte_RowPostPaint);
			// 
			// col_retroplanning
			// 
			dataGridViewCellStyle31.Format = "0000";
			this.col_retroplanning.DefaultCellStyle = dataGridViewCellStyle31;
			this.col_retroplanning.HeaderText = "Consecutivo retroplanning";
			this.col_retroplanning.Name = "col_retroplanning";
			this.col_retroplanning.ReadOnly = true;
			// 
			// col_nomb_dinamica
			// 
			this.col_nomb_dinamica.HeaderText = "Nombre dinámica";
			this.col_nomb_dinamica.Name = "col_nomb_dinamica";
			this.col_nomb_dinamica.ReadOnly = true;
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
			// col_consecutivo
			// 
			dataGridViewCellStyle32.Format = "0000";
			this.col_consecutivo.DefaultCellStyle = dataGridViewCellStyle32;
			this.col_consecutivo.HeaderText = "Consecutivo descuento";
			this.col_consecutivo.Name = "col_consecutivo";
			this.col_consecutivo.ReadOnly = true;
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
			this.col_fecha.HeaderText = "Fecha creación";
			this.col_fecha.Name = "col_fecha";
			this.col_fecha.ReadOnly = true;
			// 
			// col_negociador
			// 
			this.col_negociador.HeaderText = "Negociador";
			this.col_negociador.Name = "col_negociador";
			this.col_negociador.ReadOnly = true;
			// 
			// col_estado
			// 
			this.col_estado.HeaderText = "Estado";
			this.col_estado.Name = "col_estado";
			this.col_estado.ReadOnly = true;
			// 
			// col_detalle
			// 
			this.col_detalle.HeaderText = "";
			this.col_detalle.Name = "col_detalle";
			this.col_detalle.ReadOnly = true;
			this.col_detalle.Text = "Detalle";
			this.col_detalle.UseColumnTextForButtonValue = true;
			this.col_detalle.Width = 50;
			// 
			// col_cargado
			// 
			this.col_cargado.HeaderText = "";
			this.col_cargado.Name = "col_cargado";
			this.col_cargado.ReadOnly = true;
			this.col_cargado.Text = "Cargar";
			this.col_cargado.UseColumnTextForButtonValue = true;
			this.col_cargado.Width = 60;
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(120, 65);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(35, 13);
			this.label8.TabIndex = 3;
			this.label8.Text = "Final:";
			// 
			// dtp_fecha_fin
			// 
			this.dtp_fecha_fin.CustomFormat = "dd/MM/yyyy";
			this.dtp_fecha_fin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtp_fecha_fin.Location = new System.Drawing.Point(120, 85);
			this.dtp_fecha_fin.Name = "dtp_fecha_fin";
			this.dtp_fecha_fin.Size = new System.Drawing.Size(98, 22);
			this.dtp_fecha_fin.TabIndex = 4;
			// 
			// btn_buscar
			// 
			this.btn_buscar.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_buscar.ImageKey = "diskette25.png";
			this.btn_buscar.Location = new System.Drawing.Point(767, 82);
			this.btn_buscar.Name = "btn_buscar";
			this.btn_buscar.Size = new System.Drawing.Size(92, 32);
			this.btn_buscar.TabIndex = 11;
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
			this.btn_exportar.Location = new System.Drawing.Point(810, 635);
			this.btn_exportar.Name = "btn_exportar";
			this.btn_exportar.Size = new System.Drawing.Size(94, 32);
			this.btn_exportar.TabIndex = 16;
			this.btn_exportar.Text = "Exportar...";
			this.btn_exportar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btn_exportar.UseVisualStyleBackColor = true;
			this.btn_exportar.Click += new System.EventHandler(this.btn_exportar_Click);
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
            this.col_item,
            this.col_referencia,
            this.col_desc,
            this.col_nit,
            this.col_casa_prov,
            this.col_fecha_ini,
            this.col_fecha_fin,
            this.col_modo_cobro,
            this.col_descuento,
            this.col_tipo_desc,
            this.col_asume_prov,
            this.col_asume_mega,
            this.col_precio_antes,
            this.col_precio_fin,
            this.col_pum,
            this.col_existencia,
            this.col_cod_co,
            this.col_co,
            this.col_regional,
            this.col_obs,
            this.col_ind_reg});
			this.dgv_detalle.Location = new System.Drawing.Point(8, 319);
			this.dgv_detalle.MultiSelect = false;
			this.dgv_detalle.Name = "dgv_detalle";
			this.dgv_detalle.ReadOnly = true;
			this.dgv_detalle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
			this.dgv_detalle.Size = new System.Drawing.Size(996, 310);
			this.dgv_detalle.TabIndex = 13;
			this.dgv_detalle.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_detalle_CellContentClick);
			this.dgv_detalle.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgv_detalle_CellFormatting);
			this.dgv_detalle.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_detalle_CellMouseEnter);
			this.dgv_detalle.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgv_detalle_RowPostPaint);
			// 
			// col_item
			// 
			this.col_item.Frozen = true;
			this.col_item.HeaderText = "Ítem";
			this.col_item.Name = "col_item";
			this.col_item.ReadOnly = true;
			this.col_item.Width = 50;
			// 
			// col_referencia
			// 
			this.col_referencia.Frozen = true;
			this.col_referencia.HeaderText = "Referencia";
			this.col_referencia.Name = "col_referencia";
			this.col_referencia.ReadOnly = true;
			this.col_referencia.Width = 120;
			// 
			// col_desc
			// 
			this.col_desc.Frozen = true;
			this.col_desc.HeaderText = "Descripción";
			this.col_desc.Name = "col_desc";
			this.col_desc.ReadOnly = true;
			this.col_desc.Width = 170;
			// 
			// col_nit
			// 
			this.col_nit.HeaderText = "Nit";
			this.col_nit.Name = "col_nit";
			this.col_nit.ReadOnly = true;
			// 
			// col_casa_prov
			// 
			this.col_casa_prov.HeaderText = "Proveedor";
			this.col_casa_prov.Name = "col_casa_prov";
			this.col_casa_prov.ReadOnly = true;
			this.col_casa_prov.Width = 150;
			// 
			// col_fecha_ini
			// 
			this.col_fecha_ini.HeaderText = "Fecha ini.";
			this.col_fecha_ini.Name = "col_fecha_ini";
			this.col_fecha_ini.ReadOnly = true;
			this.col_fecha_ini.Width = 70;
			// 
			// col_fecha_fin
			// 
			this.col_fecha_fin.HeaderText = "Fecha fin.";
			this.col_fecha_fin.Name = "col_fecha_fin";
			this.col_fecha_fin.ReadOnly = true;
			this.col_fecha_fin.Width = 70;
			// 
			// col_modo_cobro
			// 
			this.col_modo_cobro.HeaderText = "Mod. Cobro";
			this.col_modo_cobro.Name = "col_modo_cobro";
			this.col_modo_cobro.ReadOnly = true;
			this.col_modo_cobro.Width = 80;
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
			this.col_descuento.Width = 70;
			// 
			// col_tipo_desc
			// 
			this.col_tipo_desc.HeaderText = "Tipo descuento";
			this.col_tipo_desc.Name = "col_tipo_desc";
			this.col_tipo_desc.ReadOnly = true;
			this.col_tipo_desc.Width = 80;
			// 
			// col_asume_prov
			// 
			dataGridViewCellStyle34.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			dataGridViewCellStyle34.Format = "N2";
			dataGridViewCellStyle34.NullValue = null;
			this.col_asume_prov.DefaultCellStyle = dataGridViewCellStyle34;
			this.col_asume_prov.HeaderText = "Asume proveedor";
			this.col_asume_prov.Name = "col_asume_prov";
			this.col_asume_prov.ReadOnly = true;
			this.col_asume_prov.Width = 80;
			// 
			// col_asume_mega
			// 
			dataGridViewCellStyle35.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			dataGridViewCellStyle35.Format = "N2";
			dataGridViewCellStyle35.NullValue = null;
			this.col_asume_mega.DefaultCellStyle = dataGridViewCellStyle35;
			this.col_asume_mega.HeaderText = "Asume Megatiendas";
			this.col_asume_mega.Name = "col_asume_mega";
			this.col_asume_mega.ReadOnly = true;
			this.col_asume_mega.Width = 80;
			// 
			// col_precio_antes
			// 
			dataGridViewCellStyle36.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			dataGridViewCellStyle36.Format = "N2";
			dataGridViewCellStyle36.NullValue = null;
			this.col_precio_antes.DefaultCellStyle = dataGridViewCellStyle36;
			this.col_precio_antes.HeaderText = "Precio antes";
			this.col_precio_antes.Name = "col_precio_antes";
			this.col_precio_antes.ReadOnly = true;
			// 
			// col_precio_fin
			// 
			dataGridViewCellStyle37.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			dataGridViewCellStyle37.Format = "N2";
			dataGridViewCellStyle37.NullValue = null;
			this.col_precio_fin.DefaultCellStyle = dataGridViewCellStyle37;
			this.col_precio_fin.HeaderText = "Precio final";
			this.col_precio_fin.Name = "col_precio_fin";
			this.col_precio_fin.ReadOnly = true;
			this.col_precio_fin.Width = 70;
			// 
			// col_pum
			// 
			dataGridViewCellStyle38.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			dataGridViewCellStyle38.Format = "N2";
			dataGridViewCellStyle38.NullValue = null;
			this.col_pum.DefaultCellStyle = dataGridViewCellStyle38;
			this.col_pum.HeaderText = "Pum";
			this.col_pum.Name = "col_pum";
			this.col_pum.ReadOnly = true;
			// 
			// col_existencia
			// 
			dataGridViewCellStyle39.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			dataGridViewCellStyle39.Format = "N2";
			dataGridViewCellStyle39.NullValue = null;
			this.col_existencia.DefaultCellStyle = dataGridViewCellStyle39;
			this.col_existencia.HeaderText = "Existencia";
			this.col_existencia.Name = "col_existencia";
			this.col_existencia.ReadOnly = true;
			// 
			// col_cod_co
			// 
			this.col_cod_co.HeaderText = "Cod. Centro operación";
			this.col_cod_co.Name = "col_cod_co";
			this.col_cod_co.ReadOnly = true;
			// 
			// col_co
			// 
			this.col_co.HeaderText = "Centro operación";
			this.col_co.Name = "col_co";
			this.col_co.ReadOnly = true;
			this.col_co.Width = 150;
			// 
			// col_regional
			// 
			this.col_regional.HeaderText = "Regional/Cluster";
			this.col_regional.Name = "col_regional";
			this.col_regional.ReadOnly = true;
			// 
			// col_obs
			// 
			dataGridViewCellStyle40.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.col_obs.DefaultCellStyle = dataGridViewCellStyle40;
			this.col_obs.HeaderText = "Observación";
			this.col_obs.Name = "col_obs";
			this.col_obs.ReadOnly = true;
			this.col_obs.Width = 300;
			// 
			// col_ind_reg
			// 
			this.col_ind_reg.HeaderText = "IND_REG";
			this.col_ind_reg.Name = "col_ind_reg";
			this.col_ind_reg.ReadOnly = true;
			this.col_ind_reg.Visible = false;
			// 
			// btnCerrar
			// 
			this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCerrar.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnCerrar.ImageIndex = 2;
			this.btnCerrar.Location = new System.Drawing.Point(910, 635);
			this.btnCerrar.Name = "btnCerrar";
			this.btnCerrar.Size = new System.Drawing.Size(94, 32);
			this.btnCerrar.TabIndex = 17;
			this.btnCerrar.Text = "Cerrar";
			this.btnCerrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnCerrar.UseVisualStyleBackColor = true;
			this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
			// 
			// _saveFileDialog
			// 
			this._saveFileDialog.Filter = "Excel Files |*.xlsx";
			// 
			// txt_filtrar
			// 
			this.txt_filtrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.txt_filtrar.Location = new System.Drawing.Point(136, 642);
			this.txt_filtrar.Name = "txt_filtrar";
			this.txt_filtrar.Size = new System.Drawing.Size(247, 22);
			this.txt_filtrar.TabIndex = 15;
			this.txt_filtrar.TextChanged += new System.EventHandler(this.txt_filtrar_TextChanged);
			// 
			// label6
			// 
			this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(5, 645);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(124, 13);
			this.label6.TabIndex = 14;
			this.label6.Text = "Filtrar por Descripción:";
			// 
			// FrmReporteComercial
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(1017, 679);
			this.Controls.Add(this.txt_filtrar);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.btn_exportar);
			this.Controls.Add(this.dgv_detalle);
			this.Controls.Add(this.btnCerrar);
			this.Controls.Add(this.txt_consecutivo);
			this.Controls.Add(this.chk_descuento);
			this.Controls.Add(this.chk_retro);
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
			this.Name = "FrmReporteComercial";
			this.Text = "Reporte comercial";
			this.Load += new System.EventHandler(this.FrmReporteComercial_Load);
			this.pnl_cab.ResumeLayout(false);
			this.pnl_cab.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dgv_reporte)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dgv_detalle)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_consecutivo;
        private System.Windows.Forms.CheckBox chk_descuento;
        private System.Windows.Forms.CheckBox chk_retro;
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
        private System.Windows.Forms.DataGridView dgv_detalle;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.SaveFileDialog _saveFileDialog;
		private System.Windows.Forms.DataGridViewTextBoxColumn col_item;
		private System.Windows.Forms.DataGridViewTextBoxColumn col_referencia;
		private System.Windows.Forms.DataGridViewTextBoxColumn col_desc;
		private System.Windows.Forms.DataGridViewTextBoxColumn col_nit;
		private System.Windows.Forms.DataGridViewTextBoxColumn col_casa_prov;
		private System.Windows.Forms.DataGridViewTextBoxColumn col_fecha_ini;
		private System.Windows.Forms.DataGridViewTextBoxColumn col_fecha_fin;
		private System.Windows.Forms.DataGridViewTextBoxColumn col_modo_cobro;
		private System.Windows.Forms.DataGridViewTextBoxColumn col_descuento;
		private System.Windows.Forms.DataGridViewTextBoxColumn col_tipo_desc;
		private System.Windows.Forms.DataGridViewTextBoxColumn col_asume_prov;
		private System.Windows.Forms.DataGridViewTextBoxColumn col_asume_mega;
		private System.Windows.Forms.DataGridViewTextBoxColumn col_precio_antes;
		private System.Windows.Forms.DataGridViewTextBoxColumn col_precio_fin;
		private System.Windows.Forms.DataGridViewTextBoxColumn col_pum;
		private System.Windows.Forms.DataGridViewTextBoxColumn col_existencia;
		private System.Windows.Forms.DataGridViewTextBoxColumn col_cod_co;
		private System.Windows.Forms.DataGridViewTextBoxColumn col_co;
		private System.Windows.Forms.DataGridViewTextBoxColumn col_regional;
		private System.Windows.Forms.DataGridViewTextBoxColumn col_obs;
		private System.Windows.Forms.DataGridViewTextBoxColumn col_ind_reg;
		private System.Windows.Forms.DataGridViewTextBoxColumn col_retroplanning;
		private System.Windows.Forms.DataGridViewTextBoxColumn col_nomb_dinamica;
		private System.Windows.Forms.DataGridViewTextBoxColumn col_fecha_ini_vig;
		private System.Windows.Forms.DataGridViewTextBoxColumn col_fecha_fin_vig;
		private System.Windows.Forms.DataGridViewTextBoxColumn col_consecutivo;
		private System.Windows.Forms.DataGridViewTextBoxColumn col_dinamica;
		private System.Windows.Forms.DataGridViewTextBoxColumn col_fecha;
		private System.Windows.Forms.DataGridViewTextBoxColumn col_negociador;
		private System.Windows.Forms.DataGridViewTextBoxColumn col_estado;
		private System.Windows.Forms.DataGridViewButtonColumn col_detalle;
		private System.Windows.Forms.DataGridViewButtonColumn col_cargado;
		private System.Windows.Forms.TextBox txt_filtrar;
		private System.Windows.Forms.Label label6;
	}
}