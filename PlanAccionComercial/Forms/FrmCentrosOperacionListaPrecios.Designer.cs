namespace PlanAccionComercial.Forms
{
    partial class FrmCentrosOperacionListaPrecios
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCentrosOperacionListaPrecios));
            this.pnl_cab = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmb_co = new System.Windows.Forms.ComboBox();
            this.cmb_lp = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_guardar = new System.Windows.Forms.Button();
            this.dgv_centro_lista = new System.Windows.Forms.DataGridView();
            this.col_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_id_co = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_co = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_lp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_quitar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.pnl_cab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_centro_lista)).BeginInit();
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
            this.pnl_cab.Size = new System.Drawing.Size(417, 41);
            this.pnl_cab.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(10, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(246, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "Centros de operación y Listas de precio";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(299, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(114, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Centro de operación:";
            // 
            // cmb_co
            // 
            this.cmb_co.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_co.DropDownWidth = 300;
            this.cmb_co.FormattingEnabled = true;
            this.cmb_co.Location = new System.Drawing.Point(23, 86);
            this.cmb_co.Name = "cmb_co";
            this.cmb_co.Size = new System.Drawing.Size(217, 21);
            this.cmb_co.TabIndex = 2;
            // 
            // cmb_lp
            // 
            this.cmb_lp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_lp.DropDownWidth = 300;
            this.cmb_lp.FormattingEnabled = true;
            this.cmb_lp.Location = new System.Drawing.Point(25, 131);
            this.cmb_lp.Name = "cmb_lp";
            this.cmb_lp.Size = new System.Drawing.Size(220, 21);
            this.cmb_lp.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Lista de precios:";
            // 
            // btn_guardar
            // 
            this.btn_guardar.Location = new System.Drawing.Point(251, 121);
            this.btn_guardar.Name = "btn_guardar";
            this.btn_guardar.Size = new System.Drawing.Size(100, 33);
            this.btn_guardar.TabIndex = 5;
            this.btn_guardar.Text = "&Guardar";
            this.btn_guardar.UseVisualStyleBackColor = true;
            this.btn_guardar.Click += new System.EventHandler(this.btn_guardar_Click);
            // 
            // dgv_centro_lista
            // 
            this.dgv_centro_lista.AllowUserToAddRows = false;
            this.dgv_centro_lista.AllowUserToDeleteRows = false;
            this.dgv_centro_lista.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_centro_lista.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgv_centro_lista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_centro_lista.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_id,
            this.col_id_co,
            this.col_co,
            this.col_lp,
            this.col_quitar});
            this.dgv_centro_lista.Location = new System.Drawing.Point(12, 192);
            this.dgv_centro_lista.Name = "dgv_centro_lista";
            this.dgv_centro_lista.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_centro_lista.Size = new System.Drawing.Size(417, 396);
            this.dgv_centro_lista.TabIndex = 6;
            this.dgv_centro_lista.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_centro_lista_CellContentClick);
            this.dgv_centro_lista.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgv_centro_lista_RowPostPaint);
            // 
            // col_id
            // 
            this.col_id.HeaderText = "ID";
            this.col_id.Name = "col_id";
            this.col_id.Visible = false;
            // 
            // col_id_co
            // 
            this.col_id_co.HeaderText = "ID_CO";
            this.col_id_co.Name = "col_id_co";
            this.col_id_co.Visible = false;
            // 
            // col_co
            // 
            this.col_co.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col_co.HeaderText = "Centro operación";
            this.col_co.Name = "col_co";
            this.col_co.ReadOnly = true;
            // 
            // col_lp
            // 
            this.col_lp.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.col_lp.HeaderText = "Lista precios";
            this.col_lp.Name = "col_lp";
            this.col_lp.ReadOnly = true;
            // 
            // col_quitar
            // 
            this.col_quitar.HeaderText = "";
            this.col_quitar.Name = "col_quitar";
            this.col_quitar.Text = "Quitar";
            this.col_quitar.UseColumnTextForButtonValue = true;
            this.col_quitar.Width = 50;
            // 
            // btnCerrar
            // 
            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrar.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrar.ImageIndex = 2;
            this.btnCerrar.Location = new System.Drawing.Point(336, 594);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(94, 32);
            this.btnCerrar.TabIndex = 7;
            this.btnCerrar.Text = "&Cerrar";
            this.btnCerrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // FrmCentrosOperacionListaPrecios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(441, 638);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.dgv_centro_lista);
            this.Controls.Add(this.btn_guardar);
            this.Controls.Add(this.cmb_lp);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmb_co);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pnl_cab);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmCentrosOperacionListaPrecios";
            this.Text = "Centros de operación y Listas de precio";
            this.Load += new System.EventHandler(this.FrmCentrosOperacionListaPrecios_Load);
            this.pnl_cab.ResumeLayout(false);
            this.pnl_cab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_centro_lista)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnl_cab;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmb_co;
        private System.Windows.Forms.ComboBox cmb_lp;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_guardar;
        private System.Windows.Forms.DataGridView dgv_centro_lista;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_id_co;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_co;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_lp;
        private System.Windows.Forms.DataGridViewButtonColumn col_quitar;
    }
}