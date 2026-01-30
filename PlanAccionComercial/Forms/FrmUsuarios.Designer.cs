namespace PlanAccionComercial.Forms
{
    partial class FrmUsuarios
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmUsuarios));
            this.pnl_cab = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.chk_activo = new System.Windows.Forms.CheckBox();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.dgvUsuarios = new System.Windows.Forms.DataGridView();
            this.col_id_usuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_usuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_email_cc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_contra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_id_rol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_rol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_activo = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.col_negociador = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.col_edit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.label6 = new System.Windows.Forms.Label();
            this.cmb_rol = new System.Windows.Forms.ComboBox();
            this.txt_contra = new System.Windows.Forms.TextBox();
            this.lbl_tit_contra = new System.Windows.Forms.Label();
            this.txt_correo = new System.Windows.Forms.TextBox();
            this.lbl_tit_correo = new System.Windows.Forms.Label();
            this.txt_nombre = new System.Windows.Forms.TextBox();
            this.lbl_tit_nomb_apellido = new System.Windows.Forms.Label();
            this.txt_usuario = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.chk_negociador = new System.Windows.Forms.CheckBox();
            this.btn_correos_notificacion = new System.Windows.Forms.Button();
            this.txt_correos_cc = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pnl_cab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).BeginInit();
            this.SuspendLayout();
            // 
            // pnl_cab
            // 
            this.pnl_cab.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnl_cab.BackColor = System.Drawing.Color.White;
            this.pnl_cab.Controls.Add(this.label3);
            this.pnl_cab.Controls.Add(this.pictureBox1);
            this.pnl_cab.Location = new System.Drawing.Point(9, 10);
            this.pnl_cab.Name = "pnl_cab";
            this.pnl_cab.Size = new System.Drawing.Size(1016, 41);
            this.pnl_cab.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(10, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "Usuarios";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(898, 5);
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
            this.chk_activo.Location = new System.Drawing.Point(13, 239);
            this.chk_activo.Name = "chk_activo";
            this.chk_activo.Size = new System.Drawing.Size(57, 17);
            this.chk_activo.TabIndex = 14;
            this.chk_activo.Text = "Activo";
            this.chk_activo.UseVisualStyleBackColor = true;
            // 
            // btnCerrar
            // 
            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrar.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrar.ImageIndex = 2;
            this.btnCerrar.Location = new System.Drawing.Point(937, 548);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(83, 32);
            this.btnCerrar.TabIndex = 18;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.ImageKey = "diskette25.png";
            this.btnGuardar.Location = new System.Drawing.Point(361, 230);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(92, 32);
            this.btnGuardar.TabIndex = 15;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // dgvUsuarios
            // 
            this.dgvUsuarios.AllowUserToAddRows = false;
            this.dgvUsuarios.AllowUserToDeleteRows = false;
            this.dgvUsuarios.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvUsuarios.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsuarios.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_id_usuario,
            this.col_usuario,
            this.col_nombre,
            this.col_email,
            this.col_email_cc,
            this.col_contra,
            this.col_id_rol,
            this.col_rol,
            this.col_activo,
            this.col_negociador,
            this.col_edit});
            this.dgvUsuarios.Location = new System.Drawing.Point(13, 268);
            this.dgvUsuarios.Name = "dgvUsuarios";
            this.dgvUsuarios.ReadOnly = true;
            this.dgvUsuarios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUsuarios.Size = new System.Drawing.Size(1007, 266);
            this.dgvUsuarios.TabIndex = 16;
            this.dgvUsuarios.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUsuarios_CellContentClick);
            this.dgvUsuarios.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvUsuarios_RowPostPaint);
            // 
            // col_id_usuario
            // 
            this.col_id_usuario.HeaderText = "ID_USUARIO";
            this.col_id_usuario.Name = "col_id_usuario";
            this.col_id_usuario.ReadOnly = true;
            this.col_id_usuario.Visible = false;
            // 
            // col_usuario
            // 
            this.col_usuario.HeaderText = "Usuario";
            this.col_usuario.Name = "col_usuario";
            this.col_usuario.ReadOnly = true;
            // 
            // col_nombre
            // 
            this.col_nombre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col_nombre.HeaderText = "Nombre";
            this.col_nombre.Name = "col_nombre";
            this.col_nombre.ReadOnly = true;
            // 
            // col_email
            // 
            this.col_email.HeaderText = "Email";
            this.col_email.Name = "col_email";
            this.col_email.ReadOnly = true;
            this.col_email.Width = 200;
            // 
            // col_email_cc
            // 
            this.col_email_cc.HeaderText = "Email CC";
            this.col_email_cc.Name = "col_email_cc";
            this.col_email_cc.ReadOnly = true;
            this.col_email_cc.Width = 200;
            // 
            // col_contra
            // 
            this.col_contra.HeaderText = "Contraseña";
            this.col_contra.Name = "col_contra";
            this.col_contra.ReadOnly = true;
            // 
            // col_id_rol
            // 
            this.col_id_rol.HeaderText = "ID_ROL";
            this.col_id_rol.Name = "col_id_rol";
            this.col_id_rol.ReadOnly = true;
            this.col_id_rol.Visible = false;
            // 
            // col_rol
            // 
            this.col_rol.HeaderText = "Rol";
            this.col_rol.Name = "col_rol";
            this.col_rol.ReadOnly = true;
            // 
            // col_activo
            // 
            this.col_activo.HeaderText = "Activo";
            this.col_activo.Name = "col_activo";
            this.col_activo.ReadOnly = true;
            this.col_activo.Width = 50;
            // 
            // col_negociador
            // 
            this.col_negociador.HeaderText = "Negociador";
            this.col_negociador.Name = "col_negociador";
            this.col_negociador.ReadOnly = true;
            this.col_negociador.Width = 80;
            // 
            // col_edit
            // 
            this.col_edit.HeaderText = "";
            this.col_edit.Name = "col_edit";
            this.col_edit.ReadOnly = true;
            this.col_edit.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.col_edit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.col_edit.Text = "Editar";
            this.col_edit.UseColumnTextForButtonValue = true;
            this.col_edit.Width = 50;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 152);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(27, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Rol:";
            // 
            // cmb_rol
            // 
            this.cmb_rol.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmb_rol.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmb_rol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_rol.DropDownWidth = 150;
            this.cmb_rol.FormattingEnabled = true;
            this.cmb_rol.Location = new System.Drawing.Point(123, 148);
            this.cmb_rol.Name = "cmb_rol";
            this.cmb_rol.Size = new System.Drawing.Size(330, 21);
            this.cmb_rol.TabIndex = 10;
            // 
            // txt_contra
            // 
            this.txt_contra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_contra.Location = new System.Drawing.Point(374, 90);
            this.txt_contra.MaxLength = 50;
            this.txt_contra.Name = "txt_contra";
            this.txt_contra.Size = new System.Drawing.Size(79, 22);
            this.txt_contra.TabIndex = 6;
            this.txt_contra.Tag = "";
            this.txt_contra.UseSystemPasswordChar = true;
            // 
            // lbl_tit_contra
            // 
            this.lbl_tit_contra.AutoSize = true;
            this.lbl_tit_contra.Location = new System.Drawing.Point(299, 94);
            this.lbl_tit_contra.Name = "lbl_tit_contra";
            this.lbl_tit_contra.Size = new System.Drawing.Size(69, 13);
            this.lbl_tit_contra.TabIndex = 5;
            this.lbl_tit_contra.Text = "Contraseña:";
            // 
            // txt_correo
            // 
            this.txt_correo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_correo.Location = new System.Drawing.Point(123, 120);
            this.txt_correo.MaxLength = 1500;
            this.txt_correo.Name = "txt_correo";
            this.txt_correo.Size = new System.Drawing.Size(330, 22);
            this.txt_correo.TabIndex = 8;
            this.txt_correo.Tag = "";
            // 
            // lbl_tit_correo
            // 
            this.lbl_tit_correo.AutoSize = true;
            this.lbl_tit_correo.Location = new System.Drawing.Point(13, 124);
            this.lbl_tit_correo.Name = "lbl_tit_correo";
            this.lbl_tit_correo.Size = new System.Drawing.Size(37, 13);
            this.lbl_tit_correo.TabIndex = 7;
            this.lbl_tit_correo.Text = "Email:";
            // 
            // txt_nombre
            // 
            this.txt_nombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_nombre.Location = new System.Drawing.Point(123, 63);
            this.txt_nombre.MaxLength = 150;
            this.txt_nombre.Name = "txt_nombre";
            this.txt_nombre.Size = new System.Drawing.Size(330, 22);
            this.txt_nombre.TabIndex = 2;
            this.txt_nombre.Tag = "";
            // 
            // lbl_tit_nomb_apellido
            // 
            this.lbl_tit_nomb_apellido.AutoSize = true;
            this.lbl_tit_nomb_apellido.Location = new System.Drawing.Point(13, 67);
            this.lbl_tit_nomb_apellido.Name = "lbl_tit_nomb_apellido";
            this.lbl_tit_nomb_apellido.Size = new System.Drawing.Size(104, 13);
            this.lbl_tit_nomb_apellido.TabIndex = 1;
            this.lbl_tit_nomb_apellido.Text = "Nombre y apellido:";
            // 
            // txt_usuario
            // 
            this.txt_usuario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_usuario.Location = new System.Drawing.Point(123, 90);
            this.txt_usuario.MaxLength = 50;
            this.txt_usuario.Name = "txt_usuario";
            this.txt_usuario.Size = new System.Drawing.Size(170, 22);
            this.txt_usuario.TabIndex = 4;
            this.txt_usuario.Tag = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Usuario:";
            // 
            // chk_negociador
            // 
            this.chk_negociador.AutoSize = true;
            this.chk_negociador.Location = new System.Drawing.Point(13, 199);
            this.chk_negociador.Name = "chk_negociador";
            this.chk_negociador.Size = new System.Drawing.Size(99, 17);
            this.chk_negociador.TabIndex = 11;
            this.chk_negociador.Text = "Es negociador";
            this.chk_negociador.UseVisualStyleBackColor = true;
            this.chk_negociador.CheckedChanged += new System.EventHandler(this.chk_negociador_CheckedChanged);
            // 
            // btn_correos_notificacion
            // 
            this.btn_correos_notificacion.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_correos_notificacion.ImageKey = "diskette25.png";
            this.btn_correos_notificacion.Location = new System.Drawing.Point(13, 546);
            this.btn_correos_notificacion.Name = "btn_correos_notificacion";
            this.btn_correos_notificacion.Size = new System.Drawing.Size(253, 32);
            this.btn_correos_notificacion.TabIndex = 17;
            this.btn_correos_notificacion.Text = "Correos para notificar registro de descuento";
            this.btn_correos_notificacion.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_correos_notificacion.UseVisualStyleBackColor = true;
            this.btn_correos_notificacion.Visible = false;
            // 
            // txt_correos_cc
            // 
            this.txt_correos_cc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_correos_cc.Enabled = false;
            this.txt_correos_cc.Location = new System.Drawing.Point(123, 197);
            this.txt_correos_cc.MaxLength = 1500;
            this.txt_correos_cc.Name = "txt_correos_cc";
            this.txt_correos_cc.Size = new System.Drawing.Size(330, 22);
            this.txt_correos_cc.TabIndex = 13;
            this.txt_correos_cc.Tag = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(120, 180);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(305, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Email para enviar copia al confirmar ó rechazar descuento:";
            // 
            // FrmUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1034, 590);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_correos_cc);
            this.Controls.Add(this.btn_correos_notificacion);
            this.Controls.Add(this.chk_negociador);
            this.Controls.Add(this.pnl_cab);
            this.Controls.Add(this.chk_activo);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.dgvUsuarios);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmb_rol);
            this.Controls.Add(this.txt_contra);
            this.Controls.Add(this.lbl_tit_contra);
            this.Controls.Add(this.txt_correo);
            this.Controls.Add(this.lbl_tit_correo);
            this.Controls.Add(this.txt_nombre);
            this.Controls.Add(this.lbl_tit_nomb_apellido);
            this.Controls.Add(this.txt_usuario);
            this.Controls.Add(this.label2);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FrmUsuarios";
            this.Text = "Usuarios";
            this.Load += new System.EventHandler(this.FrmUsuarios_Load);
            this.pnl_cab.ResumeLayout(false);
            this.pnl_cab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnl_cab;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.CheckBox chk_activo;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.DataGridView dgvUsuarios;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.ComboBox cmb_rol;
        private System.Windows.Forms.TextBox txt_contra;
        private System.Windows.Forms.Label lbl_tit_contra;
        private System.Windows.Forms.TextBox txt_correo;
        private System.Windows.Forms.Label lbl_tit_correo;
        private System.Windows.Forms.TextBox txt_nombre;
        private System.Windows.Forms.Label lbl_tit_nomb_apellido;
        private System.Windows.Forms.TextBox txt_usuario;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chk_negociador;
        private System.Windows.Forms.Button btn_correos_notificacion;
        private System.Windows.Forms.TextBox txt_correos_cc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_id_usuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_usuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_email;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_email_cc;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_contra;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_id_rol;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_rol;
        private System.Windows.Forms.DataGridViewCheckBoxColumn col_activo;
        private System.Windows.Forms.DataGridViewCheckBoxColumn col_negociador;
        private System.Windows.Forms.DataGridViewButtonColumn col_edit;
    }
}