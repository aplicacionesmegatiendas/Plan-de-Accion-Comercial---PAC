namespace PlanAccionComercial.Forms
{
    partial class FrmEditarUsuario
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
            this.chk_activo = new System.Windows.Forms.CheckBox();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
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
            this.label1 = new System.Windows.Forms.Label();
            this.txt_correos_cc = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // chk_activo
            // 
            this.chk_activo.AutoSize = true;
            this.chk_activo.Location = new System.Drawing.Point(12, 177);
            this.chk_activo.Name = "chk_activo";
            this.chk_activo.Size = new System.Drawing.Size(57, 17);
            this.chk_activo.TabIndex = 13;
            this.chk_activo.Text = "Activo";
            this.chk_activo.UseVisualStyleBackColor = true;
            // 
            // btnCerrar
            // 
            this.btnCerrar.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrar.ImageIndex = 2;
            this.btnCerrar.Location = new System.Drawing.Point(358, 173);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(92, 32);
            this.btnCerrar.TabIndex = 15;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.ImageKey = "diskette25.png";
            this.btnGuardar.Location = new System.Drawing.Point(260, 173);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(92, 32);
            this.btnGuardar.TabIndex = 14;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 104);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(27, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Rol:";
            // 
            // cmb_rol
            // 
            this.cmb_rol.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmb_rol.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmb_rol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_rol.DropDownWidth = 150;
            this.cmb_rol.FormattingEnabled = true;
            this.cmb_rol.Location = new System.Drawing.Point(122, 100);
            this.cmb_rol.Name = "cmb_rol";
            this.cmb_rol.Size = new System.Drawing.Size(328, 21);
            this.cmb_rol.TabIndex = 9;
            // 
            // txt_contra
            // 
            this.txt_contra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_contra.Location = new System.Drawing.Point(373, 39);
            this.txt_contra.MaxLength = 50;
            this.txt_contra.Name = "txt_contra";
            this.txt_contra.Size = new System.Drawing.Size(77, 22);
            this.txt_contra.TabIndex = 5;
            this.txt_contra.Tag = "";
            this.txt_contra.UseSystemPasswordChar = true;
            // 
            // lbl_tit_contra
            // 
            this.lbl_tit_contra.AutoSize = true;
            this.lbl_tit_contra.Location = new System.Drawing.Point(297, 44);
            this.lbl_tit_contra.Name = "lbl_tit_contra";
            this.lbl_tit_contra.Size = new System.Drawing.Size(69, 13);
            this.lbl_tit_contra.TabIndex = 4;
            this.lbl_tit_contra.Text = "Contraseña:";
            // 
            // txt_correo
            // 
            this.txt_correo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_correo.Location = new System.Drawing.Point(122, 71);
            this.txt_correo.MaxLength = 100;
            this.txt_correo.Name = "txt_correo";
            this.txt_correo.Size = new System.Drawing.Size(328, 22);
            this.txt_correo.TabIndex = 7;
            this.txt_correo.Tag = "";
            // 
            // lbl_tit_correo
            // 
            this.lbl_tit_correo.AutoSize = true;
            this.lbl_tit_correo.Location = new System.Drawing.Point(12, 75);
            this.lbl_tit_correo.Name = "lbl_tit_correo";
            this.lbl_tit_correo.Size = new System.Drawing.Size(105, 13);
            this.lbl_tit_correo.TabIndex = 6;
            this.lbl_tit_correo.Text = "Correo electrónico:";
            // 
            // txt_nombre
            // 
            this.txt_nombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_nombre.Location = new System.Drawing.Point(122, 11);
            this.txt_nombre.MaxLength = 150;
            this.txt_nombre.Name = "txt_nombre";
            this.txt_nombre.Size = new System.Drawing.Size(328, 22);
            this.txt_nombre.TabIndex = 1;
            this.txt_nombre.Tag = "";
            // 
            // lbl_tit_nomb_apellido
            // 
            this.lbl_tit_nomb_apellido.AutoSize = true;
            this.lbl_tit_nomb_apellido.Location = new System.Drawing.Point(12, 15);
            this.lbl_tit_nomb_apellido.Name = "lbl_tit_nomb_apellido";
            this.lbl_tit_nomb_apellido.Size = new System.Drawing.Size(104, 13);
            this.lbl_tit_nomb_apellido.TabIndex = 0;
            this.lbl_tit_nomb_apellido.Text = "Nombre y apellido:";
            // 
            // txt_usuario
            // 
            this.txt_usuario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_usuario.Location = new System.Drawing.Point(122, 39);
            this.txt_usuario.MaxLength = 50;
            this.txt_usuario.Name = "txt_usuario";
            this.txt_usuario.Size = new System.Drawing.Size(170, 22);
            this.txt_usuario.TabIndex = 3;
            this.txt_usuario.Tag = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Usuario:";
            // 
            // chk_negociador
            // 
            this.chk_negociador.AutoSize = true;
            this.chk_negociador.Location = new System.Drawing.Point(12, 145);
            this.chk_negociador.Name = "chk_negociador";
            this.chk_negociador.Size = new System.Drawing.Size(99, 17);
            this.chk_negociador.TabIndex = 10;
            this.chk_negociador.Text = "Es negociador";
            this.chk_negociador.UseVisualStyleBackColor = true;
            this.chk_negociador.CheckedChanged += new System.EventHandler(this.chk_negociador_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(117, 126);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(305, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Email para enviar copia al confirmar ó rechazar descuento:";
            // 
            // txt_correos_cc
            // 
            this.txt_correos_cc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_correos_cc.Enabled = false;
            this.txt_correos_cc.Location = new System.Drawing.Point(120, 143);
            this.txt_correos_cc.MaxLength = 1500;
            this.txt_correos_cc.Name = "txt_correos_cc";
            this.txt_correos_cc.Size = new System.Drawing.Size(330, 22);
            this.txt_correos_cc.TabIndex = 12;
            this.txt_correos_cc.Tag = "";
            // 
            // FrmEditarUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(462, 211);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_correos_cc);
            this.Controls.Add(this.chk_negociador);
            this.Controls.Add(this.chk_activo);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.btnGuardar);
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
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmEditarUsuario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Editar usuario";
            this.Load += new System.EventHandler(this.FrmEditarUsuario_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmEditarUsuario_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FrmEditarUsuario_KeyUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chk_activo;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Button btnGuardar;
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_correos_cc;
    }
}