namespace PlanAccionComercial.Forms
{
    partial class FrmDetalleItemsRegionalCluster
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
			this.dgv_detalle = new System.Windows.Forms.DataGridView();
			this.col_cod_co = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.col_co = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.col_precio_antes = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.col_precio_fin = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.col_pum = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.col_existencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.btnCerrar = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.lbl_item = new System.Windows.Forms.Label();
			this.lbl_referencia = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.lbl_descripcion = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.lbl_regional_cluster = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.btn_exportar = new System.Windows.Forms.Button();
			this._saveFileDialog = new System.Windows.Forms.SaveFileDialog();
			this.label2 = new System.Windows.Forms.Label();
			this.lbl_total = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.dgv_detalle)).BeginInit();
			this.SuspendLayout();
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
            this.col_cod_co,
            this.col_co,
            this.col_precio_antes,
            this.col_precio_fin,
            this.col_pum,
            this.col_existencia});
			this.dgv_detalle.Location = new System.Drawing.Point(12, 127);
			this.dgv_detalle.Name = "dgv_detalle";
			this.dgv_detalle.ReadOnly = true;
			this.dgv_detalle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgv_detalle.Size = new System.Drawing.Size(663, 323);
			this.dgv_detalle.TabIndex = 8;
			// 
			// col_cod_co
			// 
			this.col_cod_co.HeaderText = "Cod. Centro operación";
			this.col_cod_co.Name = "col_cod_co";
			this.col_cod_co.ReadOnly = true;
			this.col_cod_co.Width = 80;
			// 
			// col_co
			// 
			this.col_co.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.col_co.HeaderText = "Centro operación";
			this.col_co.Name = "col_co";
			this.col_co.ReadOnly = true;
			// 
			// col_precio_antes
			// 
			dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			dataGridViewCellStyle1.Format = "N2";
			dataGridViewCellStyle1.NullValue = null;
			this.col_precio_antes.DefaultCellStyle = dataGridViewCellStyle1;
			this.col_precio_antes.HeaderText = "Precio antes";
			this.col_precio_antes.Name = "col_precio_antes";
			this.col_precio_antes.ReadOnly = true;
			// 
			// col_precio_fin
			// 
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			dataGridViewCellStyle2.Format = "N2";
			dataGridViewCellStyle2.NullValue = null;
			this.col_precio_fin.DefaultCellStyle = dataGridViewCellStyle2;
			this.col_precio_fin.HeaderText = "Precio final";
			this.col_precio_fin.Name = "col_precio_fin";
			this.col_precio_fin.ReadOnly = true;
			this.col_precio_fin.Width = 70;
			// 
			// col_pum
			// 
			dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			dataGridViewCellStyle3.Format = "N2";
			dataGridViewCellStyle3.NullValue = null;
			this.col_pum.DefaultCellStyle = dataGridViewCellStyle3;
			this.col_pum.HeaderText = "Pum";
			this.col_pum.Name = "col_pum";
			this.col_pum.ReadOnly = true;
			this.col_pum.Width = 60;
			// 
			// col_existencia
			// 
			dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			dataGridViewCellStyle4.Format = "N2";
			dataGridViewCellStyle4.NullValue = null;
			this.col_existencia.DefaultCellStyle = dataGridViewCellStyle4;
			this.col_existencia.HeaderText = "Existencia";
			this.col_existencia.Name = "col_existencia";
			this.col_existencia.ReadOnly = true;
			this.col_existencia.Width = 70;
			// 
			// btnCerrar
			// 
			this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCerrar.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnCerrar.ImageIndex = 2;
			this.btnCerrar.Location = new System.Drawing.Point(581, 456);
			this.btnCerrar.Name = "btnCerrar";
			this.btnCerrar.Size = new System.Drawing.Size(94, 32);
			this.btnCerrar.TabIndex = 10;
			this.btnCerrar.Text = "Cerrar";
			this.btnCerrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnCerrar.UseVisualStyleBackColor = true;
			this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(13, 13);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(35, 15);
			this.label1.TabIndex = 0;
			this.label1.Text = "Ítem:";
			// 
			// lbl_item
			// 
			this.lbl_item.AutoSize = true;
			this.lbl_item.Location = new System.Drawing.Point(117, 13);
			this.lbl_item.Name = "lbl_item";
			this.lbl_item.Size = new System.Drawing.Size(16, 13);
			this.lbl_item.TabIndex = 1;
			this.lbl_item.Text = "...";
			// 
			// lbl_referencia
			// 
			this.lbl_referencia.AutoSize = true;
			this.lbl_referencia.Location = new System.Drawing.Point(117, 44);
			this.lbl_referencia.Name = "lbl_referencia";
			this.lbl_referencia.Size = new System.Drawing.Size(16, 13);
			this.lbl_referencia.TabIndex = 3;
			this.lbl_referencia.Text = "...";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(13, 43);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(65, 15);
			this.label3.TabIndex = 2;
			this.label3.Text = "Referencia:";
			// 
			// lbl_descripcion
			// 
			this.lbl_descripcion.AutoSize = true;
			this.lbl_descripcion.Location = new System.Drawing.Point(117, 73);
			this.lbl_descripcion.Name = "lbl_descripcion";
			this.lbl_descripcion.Size = new System.Drawing.Size(16, 13);
			this.lbl_descripcion.TabIndex = 5;
			this.lbl_descripcion.Text = "...";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label5.Location = new System.Drawing.Point(13, 73);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(73, 15);
			this.label5.TabIndex = 4;
			this.label5.Text = "Descripción:";
			// 
			// lbl_regional_cluster
			// 
			this.lbl_regional_cluster.AutoSize = true;
			this.lbl_regional_cluster.Location = new System.Drawing.Point(117, 103);
			this.lbl_regional_cluster.Name = "lbl_regional_cluster";
			this.lbl_regional_cluster.Size = new System.Drawing.Size(16, 13);
			this.lbl_regional_cluster.TabIndex = 7;
			this.lbl_regional_cluster.Text = "...";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.Location = new System.Drawing.Point(13, 103);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(97, 15);
			this.label4.TabIndex = 6;
			this.label4.Text = "Regional/Cluster:";
			// 
			// btn_exportar
			// 
			this.btn_exportar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btn_exportar.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_exportar.ImageIndex = 2;
			this.btn_exportar.Location = new System.Drawing.Point(481, 456);
			this.btn_exportar.Name = "btn_exportar";
			this.btn_exportar.Size = new System.Drawing.Size(94, 32);
			this.btn_exportar.TabIndex = 9;
			this.btn_exportar.Text = "Exportar...";
			this.btn_exportar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btn_exportar.UseVisualStyleBackColor = true;
			this.btn_exportar.Click += new System.EventHandler(this.btn_exportar_Click);
			// 
			// _saveFileDialog
			// 
			this._saveFileDialog.Filter = "Excel Files |*.xlsx";
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 461);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(87, 13);
			this.label2.TabIndex = 11;
			this.label2.Text = "Existencia total:";
			// 
			// lbl_total
			// 
			this.lbl_total.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.lbl_total.AutoSize = true;
			this.lbl_total.Location = new System.Drawing.Point(105, 461);
			this.lbl_total.Name = "lbl_total";
			this.lbl_total.Size = new System.Drawing.Size(16, 13);
			this.lbl_total.TabIndex = 12;
			this.lbl_total.Text = "...";
			// 
			// FrmDetalleItemsRegionalCluster
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(687, 500);
			this.Controls.Add(this.lbl_total);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.btn_exportar);
			this.Controls.Add(this.lbl_regional_cluster);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.lbl_descripcion);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.lbl_referencia);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.lbl_item);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btnCerrar);
			this.Controls.Add(this.dgv_detalle);
			this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Name = "FrmDetalleItemsRegionalCluster";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Detalle ítem Regional/Cluster";
			this.Load += new System.EventHandler(this.FrmDetalleItemsRegionalCluster_Load);
			((System.ComponentModel.ISupportInitialize)(this.dgv_detalle)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_detalle;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_item;
        private System.Windows.Forms.Label lbl_referencia;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbl_descripcion;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_cod_co;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_co;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_precio_antes;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_precio_fin;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_pum;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_existencia;
        private System.Windows.Forms.Label lbl_regional_cluster;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_exportar;
        private System.Windows.Forms.SaveFileDialog _saveFileDialog;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbl_total;
    }
}