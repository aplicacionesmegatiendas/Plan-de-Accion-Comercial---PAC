namespace PlanAccionComercial.Forms
{
    partial class FrmEditarCluster
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
			this.label4 = new System.Windows.Forms.Label();
			this.clb_co = new System.Windows.Forms.CheckedListBox();
			this.txt_desc = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txt_cod = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.chk_activo = new System.Windows.Forms.CheckBox();
			this.chk_ppal = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// btnGuardar
			// 
			this.btnGuardar.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnGuardar.ImageKey = "diskette25.png";
			this.btnGuardar.Location = new System.Drawing.Point(301, 241);
			this.btnGuardar.Name = "btnGuardar";
			this.btnGuardar.Size = new System.Drawing.Size(92, 32);
			this.btnGuardar.TabIndex = 7;
			this.btnGuardar.Text = "Guardar";
			this.btnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnGuardar.UseVisualStyleBackColor = true;
			this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(12, 107);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(121, 13);
			this.label4.TabIndex = 5;
			this.label4.Text = "Centros de operación:";
			// 
			// clb_co
			// 
			this.clb_co.CheckOnClick = true;
			this.clb_co.FormattingEnabled = true;
			this.clb_co.Location = new System.Drawing.Point(12, 126);
			this.clb_co.Name = "clb_co";
			this.clb_co.Size = new System.Drawing.Size(381, 106);
			this.clb_co.TabIndex = 6;
			// 
			// txt_desc
			// 
			this.txt_desc.Location = new System.Drawing.Point(88, 41);
			this.txt_desc.MaxLength = 150;
			this.txt_desc.Name = "txt_desc";
			this.txt_desc.Size = new System.Drawing.Size(305, 22);
			this.txt_desc.TabIndex = 3;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 46);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(70, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "Descripción:";
			// 
			// txt_cod
			// 
			this.txt_cod.Location = new System.Drawing.Point(88, 11);
			this.txt_cod.MaxLength = 10;
			this.txt_cod.Name = "txt_cod";
			this.txt_cod.ReadOnly = true;
			this.txt_cod.Size = new System.Drawing.Size(73, 22);
			this.txt_cod.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(48, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Código:";
			// 
			// chk_activo
			// 
			this.chk_activo.AutoSize = true;
			this.chk_activo.Location = new System.Drawing.Point(91, 69);
			this.chk_activo.Name = "chk_activo";
			this.chk_activo.Size = new System.Drawing.Size(57, 17);
			this.chk_activo.TabIndex = 4;
			this.chk_activo.Text = "Activo";
			this.chk_activo.UseVisualStyleBackColor = true;
			// 
			// chk_ppal
			// 
			this.chk_ppal.AutoSize = true;
			this.chk_ppal.Location = new System.Drawing.Point(15, 69);
			this.chk_ppal.Name = "chk_ppal";
			this.chk_ppal.Size = new System.Drawing.Size(70, 17);
			this.chk_ppal.TabIndex = 12;
			this.chk_ppal.Text = "Principal";
			this.chk_ppal.UseVisualStyleBackColor = true;
			// 
			// FrmEditarCluster
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(403, 285);
			this.Controls.Add(this.chk_ppal);
			this.Controls.Add(this.chk_activo);
			this.Controls.Add(this.btnGuardar);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.clb_co);
			this.Controls.Add(this.txt_desc);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.txt_cod);
			this.Controls.Add(this.label1);
			this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FrmEditarCluster";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Editar cluster";
			this.Load += new System.EventHandler(this.FrmEditarCluster_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckedListBox clb_co;
        private System.Windows.Forms.TextBox txt_desc;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_cod;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chk_activo;
		private System.Windows.Forms.CheckBox chk_ppal;
	}
}