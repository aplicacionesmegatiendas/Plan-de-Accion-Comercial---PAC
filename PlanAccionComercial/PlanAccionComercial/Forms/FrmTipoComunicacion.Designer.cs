namespace PlanAccionComercial.Forms
{
    partial class FrmTipoComunicacion
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTipoComunicacion));
			this.btnCerrar = new System.Windows.Forms.Button();
			this.dgv_tipos = new System.Windows.Forms.DataGridView();
			this.btnGuardar = new System.Windows.Forms.Button();
			this.txt_desc = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.pnl_cab = new System.Windows.Forms.Panel();
			this.label3 = new System.Windows.Forms.Label();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.chk_activo = new System.Windows.Forms.CheckBox();
			this.txt_correo = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.col_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.col_desc = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.col_correo = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.col_activo = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.col_editar = new System.Windows.Forms.DataGridViewButtonColumn();
			this.col_eliminar = new System.Windows.Forms.DataGridViewButtonColumn();
			((System.ComponentModel.ISupportInitialize)(this.dgv_tipos)).BeginInit();
			this.pnl_cab.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// btnCerrar
			// 
			this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCerrar.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnCerrar.ImageIndex = 2;
			this.btnCerrar.Location = new System.Drawing.Point(440, 389);
			this.btnCerrar.Name = "btnCerrar";
			this.btnCerrar.Size = new System.Drawing.Size(94, 32);
			this.btnCerrar.TabIndex = 8;
			this.btnCerrar.Text = "Cerrar";
			this.btnCerrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnCerrar.UseVisualStyleBackColor = true;
			this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
			// 
			// dgv_tipos
			// 
			this.dgv_tipos.AllowUserToAddRows = false;
			this.dgv_tipos.AllowUserToDeleteRows = false;
			this.dgv_tipos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgv_tipos.BackgroundColor = System.Drawing.SystemColors.Window;
			this.dgv_tipos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgv_tipos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_id,
            this.col_desc,
            this.col_correo,
            this.col_activo,
            this.col_editar,
            this.col_eliminar});
			this.dgv_tipos.Location = new System.Drawing.Point(12, 160);
			this.dgv_tipos.Name = "dgv_tipos";
			this.dgv_tipos.ReadOnly = true;
			this.dgv_tipos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgv_tipos.Size = new System.Drawing.Size(522, 222);
			this.dgv_tipos.TabIndex = 7;
			this.dgv_tipos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_tipos_CellContentClick);
			this.dgv_tipos.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgv_tipos_RowPostPaint);
			// 
			// btnGuardar
			// 
			this.btnGuardar.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnGuardar.ImageKey = "diskette25.png";
			this.btnGuardar.Location = new System.Drawing.Point(304, 122);
			this.btnGuardar.Name = "btnGuardar";
			this.btnGuardar.Size = new System.Drawing.Size(92, 32);
			this.btnGuardar.TabIndex = 5;
			this.btnGuardar.Text = "Guardar";
			this.btnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnGuardar.UseVisualStyleBackColor = true;
			this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
			// 
			// txt_desc
			// 
			this.txt_desc.Location = new System.Drawing.Point(88, 65);
			this.txt_desc.MaxLength = 150;
			this.txt_desc.Name = "txt_desc";
			this.txt_desc.Size = new System.Drawing.Size(308, 22);
			this.txt_desc.TabIndex = 2;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 70);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(70, 13);
			this.label2.TabIndex = 1;
			this.label2.Text = "Descripción:";
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
			this.pnl_cab.Size = new System.Drawing.Size(522, 41);
			this.pnl_cab.TabIndex = 0;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.ForeColor = System.Drawing.Color.Black;
			this.label3.Location = new System.Drawing.Point(10, 10);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(140, 17);
			this.label3.TabIndex = 0;
			this.label3.Text = "Tipo de comunicación";
			// 
			// pictureBox1
			// 
			this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(404, 5);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(114, 32);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			// 
			// chk_activo
			// 
			this.chk_activo.AutoSize = true;
			this.chk_activo.Checked = true;
			this.chk_activo.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chk_activo.Location = new System.Drawing.Point(15, 137);
			this.chk_activo.Name = "chk_activo";
			this.chk_activo.Size = new System.Drawing.Size(57, 17);
			this.chk_activo.TabIndex = 6;
			this.chk_activo.Text = "Activo";
			this.chk_activo.UseVisualStyleBackColor = true;
			// 
			// txt_correo
			// 
			this.txt_correo.Location = new System.Drawing.Point(88, 93);
			this.txt_correo.MaxLength = 1500;
			this.txt_correo.Name = "txt_correo";
			this.txt_correo.Size = new System.Drawing.Size(308, 22);
			this.txt_correo.TabIndex = 4;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(12, 90);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(70, 28);
			this.label1.TabIndex = 3;
			this.label1.Text = "Correo para notificar:";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(399, 90);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(131, 42);
			this.label4.TabIndex = 9;
			this.label4.Text = "Escriba los correos separados por punto y coma(;)";
			// 
			// col_id
			// 
			this.col_id.HeaderText = "ID";
			this.col_id.Name = "col_id";
			this.col_id.ReadOnly = true;
			this.col_id.Visible = false;
			this.col_id.Width = 70;
			// 
			// col_desc
			// 
			this.col_desc.HeaderText = "Descripción";
			this.col_desc.Name = "col_desc";
			this.col_desc.ReadOnly = true;
			this.col_desc.Width = 250;
			// 
			// col_correo
			// 
			this.col_correo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.col_correo.HeaderText = "Correo";
			this.col_correo.Name = "col_correo";
			this.col_correo.ReadOnly = true;
			// 
			// col_activo
			// 
			this.col_activo.HeaderText = "Activo";
			this.col_activo.Name = "col_activo";
			this.col_activo.ReadOnly = true;
			this.col_activo.Width = 50;
			// 
			// col_editar
			// 
			this.col_editar.HeaderText = "";
			this.col_editar.Name = "col_editar";
			this.col_editar.ReadOnly = true;
			this.col_editar.Text = "Editar";
			this.col_editar.UseColumnTextForButtonValue = true;
			this.col_editar.Width = 50;
			// 
			// col_eliminar
			// 
			this.col_eliminar.HeaderText = "";
			this.col_eliminar.Name = "col_eliminar";
			this.col_eliminar.ReadOnly = true;
			this.col_eliminar.Text = "Eliminar";
			this.col_eliminar.UseColumnTextForButtonValue = true;
			this.col_eliminar.Width = 60;
			// 
			// FrmTipoComunicacion
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(546, 433);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.txt_correo);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.chk_activo);
			this.Controls.Add(this.btnCerrar);
			this.Controls.Add(this.dgv_tipos);
			this.Controls.Add(this.btnGuardar);
			this.Controls.Add(this.txt_desc);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.pnl_cab);
			this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Name = "FrmTipoComunicacion";
			this.Text = "Tipo de comunicación";
			this.Load += new System.EventHandler(this.FrmTipoComunicacion_Load);
			((System.ComponentModel.ISupportInitialize)(this.dgv_tipos)).EndInit();
			this.pnl_cab.ResumeLayout(false);
			this.pnl_cab.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.DataGridView dgv_tipos;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.TextBox txt_desc;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel pnl_cab;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.CheckBox chk_activo;
        private System.Windows.Forms.TextBox txt_correo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
		private System.Windows.Forms.DataGridViewTextBoxColumn col_id;
		private System.Windows.Forms.DataGridViewTextBoxColumn col_desc;
		private System.Windows.Forms.DataGridViewTextBoxColumn col_correo;
		private System.Windows.Forms.DataGridViewCheckBoxColumn col_activo;
		private System.Windows.Forms.DataGridViewButtonColumn col_editar;
		private System.Windows.Forms.DataGridViewButtonColumn col_eliminar;
	}
}