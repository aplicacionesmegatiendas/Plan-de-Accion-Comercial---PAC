namespace PlanAccionComercial.Forms
{
    partial class FrmPrecios
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
			this.btn_aceptar = new System.Windows.Forms.Button();
			this.btnCerrar = new System.Windows.Forms.Button();
			this.dgv_precios = new System.Windows.Forms.DataGridView();
			this.col_item = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.col_precio = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.col_pum = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.col_exist = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.col_id_co = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.col_co = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.col_tipo_desc = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.col_descuento = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.col_porc_prov = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.col_porc_mega = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.col_fecha_ini = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.col_fecha_fin = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.lbl_cluster = new System.Windows.Forms.Label();
			this.label28 = new System.Windows.Forms.Label();
			this.label29 = new System.Windows.Forms.Label();
			this.dtp_fecha_fin_desc = new System.Windows.Forms.DateTimePicker();
			this.dtp_fecha_ini_desc = new System.Windows.Forms.DateTimePicker();
			this.rdb_desc_valor = new System.Windows.Forms.RadioButton();
			this.rdb_desc_porc = new System.Windows.Forms.RadioButton();
			this.label22 = new System.Windows.Forms.Label();
			this.txt_descuento = new System.Windows.Forms.TextBox();
			this.txt_porc_prov = new System.Windows.Forms.TextBox();
			this.label23 = new System.Windows.Forms.Label();
			this.txt_porc_mega = new System.Windows.Forms.TextBox();
			this.label24 = new System.Windows.Forms.Label();
			this.btn_agregar = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dgv_precios)).BeginInit();
			this.SuspendLayout();
			// 
			// btn_aceptar
			// 
			this.btn_aceptar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btn_aceptar.Location = new System.Drawing.Point(809, 435);
			this.btn_aceptar.Name = "btn_aceptar";
			this.btn_aceptar.Size = new System.Drawing.Size(100, 33);
			this.btn_aceptar.TabIndex = 42;
			this.btn_aceptar.Text = "&Aceptar";
			this.btn_aceptar.UseVisualStyleBackColor = true;
			this.btn_aceptar.Click += new System.EventHandler(this.btn_aceptar_Click);
			// 
			// btnCerrar
			// 
			this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCerrar.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnCerrar.ImageIndex = 2;
			this.btnCerrar.Location = new System.Drawing.Point(915, 436);
			this.btnCerrar.Name = "btnCerrar";
			this.btnCerrar.Size = new System.Drawing.Size(94, 32);
			this.btnCerrar.TabIndex = 41;
			this.btnCerrar.Text = "&Cerrar";
			this.btnCerrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnCerrar.UseVisualStyleBackColor = true;
			this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
			// 
			// dgv_precios
			// 
			this.dgv_precios.AllowUserToAddRows = false;
			this.dgv_precios.AllowUserToDeleteRows = false;
			this.dgv_precios.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgv_precios.BackgroundColor = System.Drawing.SystemColors.Window;
			this.dgv_precios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgv_precios.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_item,
            this.col_precio,
            this.col_pum,
            this.col_exist,
            this.col_id_co,
            this.col_co,
            this.col_tipo_desc,
            this.col_descuento,
            this.col_porc_prov,
            this.col_porc_mega,
            this.col_fecha_ini,
            this.col_fecha_fin});
			this.dgv_precios.Location = new System.Drawing.Point(12, 154);
			this.dgv_precios.Name = "dgv_precios";
			this.dgv_precios.ReadOnly = true;
			this.dgv_precios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgv_precios.Size = new System.Drawing.Size(997, 275);
			this.dgv_precios.TabIndex = 40;
			// 
			// col_item
			// 
			this.col_item.HeaderText = "Ítem";
			this.col_item.Name = "col_item";
			this.col_item.ReadOnly = true;
			this.col_item.Width = 50;
			// 
			// col_precio
			// 
			this.col_precio.HeaderText = "Precio";
			this.col_precio.Name = "col_precio";
			this.col_precio.ReadOnly = true;
			this.col_precio.Width = 50;
			// 
			// col_pum
			// 
			this.col_pum.HeaderText = "PUM";
			this.col_pum.Name = "col_pum";
			this.col_pum.ReadOnly = true;
			this.col_pum.Width = 50;
			// 
			// col_exist
			// 
			this.col_exist.HeaderText = "Existencia";
			this.col_exist.Name = "col_exist";
			this.col_exist.ReadOnly = true;
			this.col_exist.Width = 70;
			// 
			// col_id_co
			// 
			this.col_id_co.HeaderText = "ID_CO";
			this.col_id_co.Name = "col_id_co";
			this.col_id_co.ReadOnly = true;
			this.col_id_co.Visible = false;
			// 
			// col_co
			// 
			this.col_co.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.col_co.HeaderText = "Centro Operación";
			this.col_co.Name = "col_co";
			this.col_co.ReadOnly = true;
			// 
			// col_tipo_desc
			// 
			this.col_tipo_desc.HeaderText = "TIPO_DESC";
			this.col_tipo_desc.Name = "col_tipo_desc";
			this.col_tipo_desc.ReadOnly = true;
			// 
			// col_descuento
			// 
			this.col_descuento.HeaderText = "Descuento";
			this.col_descuento.Name = "col_descuento";
			this.col_descuento.ReadOnly = true;
			// 
			// col_porc_prov
			// 
			this.col_porc_prov.HeaderText = "Asume proveedor";
			this.col_porc_prov.Name = "col_porc_prov";
			this.col_porc_prov.ReadOnly = true;
			// 
			// col_porc_mega
			// 
			this.col_porc_mega.HeaderText = "Asume Megatiendas";
			this.col_porc_mega.Name = "col_porc_mega";
			this.col_porc_mega.ReadOnly = true;
			// 
			// col_fecha_ini
			// 
			this.col_fecha_ini.HeaderText = "Fecha ini.";
			this.col_fecha_ini.Name = "col_fecha_ini";
			this.col_fecha_ini.ReadOnly = true;
			// 
			// col_fecha_fin
			// 
			this.col_fecha_fin.HeaderText = "Fecha fin.";
			this.col_fecha_fin.Name = "col_fecha_fin";
			this.col_fecha_fin.ReadOnly = true;
			// 
			// lbl_cluster
			// 
			this.lbl_cluster.AutoSize = true;
			this.lbl_cluster.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbl_cluster.Location = new System.Drawing.Point(13, 13);
			this.lbl_cluster.Name = "lbl_cluster";
			this.lbl_cluster.Size = new System.Drawing.Size(17, 17);
			this.lbl_cluster.TabIndex = 43;
			this.lbl_cluster.Text = "...";
			// 
			// label28
			// 
			this.label28.AutoSize = true;
			this.label28.Location = new System.Drawing.Point(166, 119);
			this.label28.Name = "label28";
			this.label28.Size = new System.Drawing.Size(39, 13);
			this.label28.TabIndex = 54;
			this.label28.Text = "Hasta:";
			// 
			// label29
			// 
			this.label29.AutoSize = true;
			this.label29.Location = new System.Drawing.Point(15, 118);
			this.label29.Name = "label29";
			this.label29.Size = new System.Drawing.Size(42, 13);
			this.label29.TabIndex = 52;
			this.label29.Text = "Desde:";
			// 
			// dtp_fecha_fin_desc
			// 
			this.dtp_fecha_fin_desc.CustomFormat = "dd/MM/yyyy";
			this.dtp_fecha_fin_desc.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtp_fecha_fin_desc.Location = new System.Drawing.Point(211, 114);
			this.dtp_fecha_fin_desc.Name = "dtp_fecha_fin_desc";
			this.dtp_fecha_fin_desc.Size = new System.Drawing.Size(98, 22);
			this.dtp_fecha_fin_desc.TabIndex = 55;
			// 
			// dtp_fecha_ini_desc
			// 
			this.dtp_fecha_ini_desc.CustomFormat = "dd/MM/yyyy";
			this.dtp_fecha_ini_desc.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtp_fecha_ini_desc.Location = new System.Drawing.Point(62, 114);
			this.dtp_fecha_ini_desc.Name = "dtp_fecha_ini_desc";
			this.dtp_fecha_ini_desc.Size = new System.Drawing.Size(98, 22);
			this.dtp_fecha_ini_desc.TabIndex = 53;
			// 
			// rdb_desc_valor
			// 
			this.rdb_desc_valor.AutoSize = true;
			this.rdb_desc_valor.Location = new System.Drawing.Point(95, 77);
			this.rdb_desc_valor.Name = "rdb_desc_valor";
			this.rdb_desc_valor.Size = new System.Drawing.Size(51, 17);
			this.rdb_desc_valor.TabIndex = 46;
			this.rdb_desc_valor.Text = "Valor";
			this.rdb_desc_valor.UseVisualStyleBackColor = true;
			// 
			// rdb_desc_porc
			// 
			this.rdb_desc_porc.AutoSize = true;
			this.rdb_desc_porc.Checked = true;
			this.rdb_desc_porc.Location = new System.Drawing.Point(16, 77);
			this.rdb_desc_porc.Name = "rdb_desc_porc";
			this.rdb_desc_porc.Size = new System.Drawing.Size(79, 17);
			this.rdb_desc_porc.TabIndex = 45;
			this.rdb_desc_porc.TabStop = true;
			this.rdb_desc_porc.Text = "Porcentaje";
			this.rdb_desc_porc.UseVisualStyleBackColor = true;
			// 
			// label22
			// 
			this.label22.AutoSize = true;
			this.label22.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label22.Location = new System.Drawing.Point(12, 50);
			this.label22.Name = "label22";
			this.label22.Size = new System.Drawing.Size(65, 13);
			this.label22.TabIndex = 44;
			this.label22.Text = "Descuento:";
			// 
			// txt_descuento
			// 
			this.txt_descuento.Location = new System.Drawing.Point(150, 75);
			this.txt_descuento.MaxLength = 8;
			this.txt_descuento.Name = "txt_descuento";
			this.txt_descuento.Size = new System.Drawing.Size(57, 22);
			this.txt_descuento.TabIndex = 47;
			// 
			// txt_porc_prov
			// 
			this.txt_porc_prov.Location = new System.Drawing.Point(233, 75);
			this.txt_porc_prov.MaxLength = 8;
			this.txt_porc_prov.Name = "txt_porc_prov";
			this.txt_porc_prov.Size = new System.Drawing.Size(57, 22);
			this.txt_porc_prov.TabIndex = 49;
			// 
			// label23
			// 
			this.label23.AutoSize = true;
			this.label23.Location = new System.Drawing.Point(210, 56);
			this.label23.Name = "label23";
			this.label23.Size = new System.Drawing.Size(100, 13);
			this.label23.TabIndex = 48;
			this.label23.Text = "Asume proveedor:";
			// 
			// txt_porc_mega
			// 
			this.txt_porc_mega.Location = new System.Drawing.Point(340, 75);
			this.txt_porc_mega.MaxLength = 8;
			this.txt_porc_mega.Name = "txt_porc_mega";
			this.txt_porc_mega.Size = new System.Drawing.Size(57, 22);
			this.txt_porc_mega.TabIndex = 51;
			// 
			// label24
			// 
			this.label24.AutoSize = true;
			this.label24.Location = new System.Drawing.Point(315, 56);
			this.label24.Name = "label24";
			this.label24.Size = new System.Drawing.Size(114, 13);
			this.label24.TabIndex = 50;
			this.label24.Text = "Asume Megatiendas:";
			// 
			// btn_agregar
			// 
			this.btn_agregar.Location = new System.Drawing.Point(318, 108);
			this.btn_agregar.Name = "btn_agregar";
			this.btn_agregar.Size = new System.Drawing.Size(100, 33);
			this.btn_agregar.TabIndex = 56;
			this.btn_agregar.Text = "&Agregar";
			this.btn_agregar.UseVisualStyleBackColor = true;
			// 
			// FrmPrecios
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(1021, 480);
			this.ControlBox = false;
			this.Controls.Add(this.btn_agregar);
			this.Controls.Add(this.label28);
			this.Controls.Add(this.label29);
			this.Controls.Add(this.dtp_fecha_fin_desc);
			this.Controls.Add(this.dtp_fecha_ini_desc);
			this.Controls.Add(this.rdb_desc_valor);
			this.Controls.Add(this.rdb_desc_porc);
			this.Controls.Add(this.label22);
			this.Controls.Add(this.txt_descuento);
			this.Controls.Add(this.txt_porc_prov);
			this.Controls.Add(this.label23);
			this.Controls.Add(this.txt_porc_mega);
			this.Controls.Add(this.label24);
			this.Controls.Add(this.lbl_cluster);
			this.Controls.Add(this.btn_aceptar);
			this.Controls.Add(this.btnCerrar);
			this.Controls.Add(this.dgv_precios);
			this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "FrmPrecios";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Precios";
			this.Load += new System.EventHandler(this.FrmPrecios_Load);
			((System.ComponentModel.ISupportInitialize)(this.dgv_precios)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_aceptar;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.DataGridView dgv_precios;
        private System.Windows.Forms.Label lbl_cluster;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label29;
        public System.Windows.Forms.DateTimePicker dtp_fecha_fin_desc;
        public System.Windows.Forms.DateTimePicker dtp_fecha_ini_desc;
        private System.Windows.Forms.RadioButton rdb_desc_valor;
        private System.Windows.Forms.RadioButton rdb_desc_porc;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox txt_descuento;
        private System.Windows.Forms.TextBox txt_porc_prov;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox txt_porc_mega;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Button btn_agregar;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_item;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_precio;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_pum;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_exist;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_id_co;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_co;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_tipo_desc;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_descuento;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_porc_prov;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_porc_mega;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_fecha_ini;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_fecha_fin;
    }
}