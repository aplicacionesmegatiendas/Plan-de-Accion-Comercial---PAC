namespace PlanAccionComercial.Forms
{
    partial class FrmCargarDescuentoDirecto
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCargarDescuentoDirecto));
			this.txt_fecha_ent_mercadeo = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.btn_aceptar = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.txt_tipo_dinamica = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txt_consecutivo = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.btn_cerrar = new System.Windows.Forms.Button();
			this.btn_buscar = new System.Windows.Forms.Button();
			this.dtp_fecha_fin = new System.Windows.Forms.DateTimePicker();
			this.label15 = new System.Windows.Forms.Label();
			this.dtp_fecha_ini = new System.Windows.Forms.DateTimePicker();
			this.label16 = new System.Windows.Forms.Label();
			this._bindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
			this._bindingSourceRetro = new System.Windows.Forms.BindingSource(this.components);
			this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
			this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
			this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
			this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
			this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
			this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
			this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
			this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.txt_fecha_ini_vig = new System.Windows.Forms.TextBox();
			this.txt_fecha_fin_vig = new System.Windows.Forms.TextBox();
			this.txt_consecutivo_retro = new System.Windows.Forms.TextBox();
			this.panel1 = new System.Windows.Forms.Panel();
			this.txt_nombre_retro = new System.Windows.Forms.TextBox();
			((System.ComponentModel.ISupportInitialize)(this._bindingNavigator)).BeginInit();
			this._bindingNavigator.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this._bindingSourceRetro)).BeginInit();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// txt_fecha_ent_mercadeo
			// 
			this.txt_fecha_ent_mercadeo.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txt_fecha_ent_mercadeo.Location = new System.Drawing.Point(315, 148);
			this.txt_fecha_ent_mercadeo.Name = "txt_fecha_ent_mercadeo";
			this.txt_fecha_ent_mercadeo.ReadOnly = true;
			this.txt_fecha_ent_mercadeo.Size = new System.Drawing.Size(94, 22);
			this.txt_fecha_ent_mercadeo.TabIndex = 12;
			this.txt_fecha_ent_mercadeo.TabStop = false;
			this.txt_fecha_ent_mercadeo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(312, 131);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(40, 13);
			this.label9.TabIndex = 11;
			this.label9.Text = "Fecha:";
			// 
			// btn_aceptar
			// 
			this.btn_aceptar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btn_aceptar.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_aceptar.ImageKey = "diskette25.png";
			this.btn_aceptar.Location = new System.Drawing.Point(217, 176);
			this.btn_aceptar.Name = "btn_aceptar";
			this.btn_aceptar.Size = new System.Drawing.Size(92, 32);
			this.btn_aceptar.TabIndex = 13;
			this.btn_aceptar.Text = "&Aceptar";
			this.btn_aceptar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btn_aceptar.UseVisualStyleBackColor = true;
			this.btn_aceptar.Click += new System.EventHandler(this.btn_aceptar_Click);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(12, 35);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(99, 13);
			this.label3.TabIndex = 1;
			this.label3.Text = "Fecha de creación";
			// 
			// txt_tipo_dinamica
			// 
			this.txt_tipo_dinamica.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txt_tipo_dinamica.Location = new System.Drawing.Point(99, 148);
			this.txt_tipo_dinamica.MaxLength = 150;
			this.txt_tipo_dinamica.Name = "txt_tipo_dinamica";
			this.txt_tipo_dinamica.ReadOnly = true;
			this.txt_tipo_dinamica.Size = new System.Drawing.Size(210, 22);
			this.txt_tipo_dinamica.TabIndex = 10;
			this.txt_tipo_dinamica.TabStop = false;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 152);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(82, 13);
			this.label2.TabIndex = 9;
			this.label2.Text = "Tipo dinámica:";
			// 
			// txt_consecutivo
			// 
			this.txt_consecutivo.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txt_consecutivo.Location = new System.Drawing.Point(99, 120);
			this.txt_consecutivo.Name = "txt_consecutivo";
			this.txt_consecutivo.ReadOnly = true;
			this.txt_consecutivo.Size = new System.Drawing.Size(100, 22);
			this.txt_consecutivo.TabIndex = 8;
			this.txt_consecutivo.TabStop = false;
			this.txt_consecutivo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 124);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(73, 13);
			this.label1.TabIndex = 7;
			this.label1.Text = "Consecutivo:";
			// 
			// btn_cerrar
			// 
			this.btn_cerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btn_cerrar.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_cerrar.ImageIndex = 2;
			this.btn_cerrar.Location = new System.Drawing.Point(315, 176);
			this.btn_cerrar.Name = "btn_cerrar";
			this.btn_cerrar.Size = new System.Drawing.Size(94, 32);
			this.btn_cerrar.TabIndex = 14;
			this.btn_cerrar.Text = "&Cerrar";
			this.btn_cerrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btn_cerrar.UseVisualStyleBackColor = true;
			this.btn_cerrar.Click += new System.EventHandler(this.btn_cerrar_Click);
			// 
			// btn_buscar
			// 
			this.btn_buscar.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_buscar.ImageKey = "diskette25.png";
			this.btn_buscar.Location = new System.Drawing.Point(162, 76);
			this.btn_buscar.Name = "btn_buscar";
			this.btn_buscar.Size = new System.Drawing.Size(92, 32);
			this.btn_buscar.TabIndex = 6;
			this.btn_buscar.Text = "&Buscar";
			this.btn_buscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btn_buscar.UseVisualStyleBackColor = true;
			this.btn_buscar.Click += new System.EventHandler(this.btn_buscar_Click);
			// 
			// dtp_fecha_fin
			// 
			this.dtp_fecha_fin.CustomFormat = "dd/MM/yyyy";
			this.dtp_fecha_fin.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.dtp_fecha_fin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtp_fecha_fin.Location = new System.Drawing.Point(59, 84);
			this.dtp_fecha_fin.Name = "dtp_fecha_fin";
			this.dtp_fecha_fin.Size = new System.Drawing.Size(97, 22);
			this.dtp_fecha_fin.TabIndex = 5;
			// 
			// label15
			// 
			this.label15.AutoSize = true;
			this.label15.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label15.ForeColor = System.Drawing.Color.Black;
			this.label15.Location = new System.Drawing.Point(12, 86);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(39, 13);
			this.label15.TabIndex = 4;
			this.label15.Text = "Hasta:";
			// 
			// dtp_fecha_ini
			// 
			this.dtp_fecha_ini.CalendarFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.dtp_fecha_ini.CustomFormat = "dd/MM/yyyy";
			this.dtp_fecha_ini.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.dtp_fecha_ini.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtp_fecha_ini.Location = new System.Drawing.Point(59, 54);
			this.dtp_fecha_ini.Name = "dtp_fecha_ini";
			this.dtp_fecha_ini.Size = new System.Drawing.Size(97, 22);
			this.dtp_fecha_ini.TabIndex = 3;
			// 
			// label16
			// 
			this.label16.AutoSize = true;
			this.label16.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label16.ForeColor = System.Drawing.Color.Black;
			this.label16.Location = new System.Drawing.Point(12, 58);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(42, 13);
			this.label16.TabIndex = 2;
			this.label16.Text = "Desde:";
			// 
			// _bindingNavigator
			// 
			this._bindingNavigator.AddNewItem = null;
			this._bindingNavigator.BindingSource = this._bindingSourceRetro;
			this._bindingNavigator.CountItem = this.bindingNavigatorCountItem;
			this._bindingNavigator.DeleteItem = null;
			this._bindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2});
			this._bindingNavigator.Location = new System.Drawing.Point(0, 0);
			this._bindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
			this._bindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
			this._bindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
			this._bindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
			this._bindingNavigator.Name = "_bindingNavigator";
			this._bindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
			this._bindingNavigator.Size = new System.Drawing.Size(421, 25);
			this._bindingNavigator.TabIndex = 0;
			this._bindingNavigator.Text = "bindingNavigator1";
			this._bindingNavigator.RefreshItems += new System.EventHandler(this._bindingNavigator_RefreshItems);
			// 
			// bindingNavigatorCountItem
			// 
			this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
			this.bindingNavigatorCountItem.Size = new System.Drawing.Size(37, 22);
			this.bindingNavigatorCountItem.Text = "de {0}";
			this.bindingNavigatorCountItem.ToolTipText = "Número total de elementos";
			// 
			// bindingNavigatorMoveFirstItem
			// 
			this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
			this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
			this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
			this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
			this.bindingNavigatorMoveFirstItem.Text = "Mover primero";
			// 
			// bindingNavigatorMovePreviousItem
			// 
			this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
			this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
			this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
			this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
			this.bindingNavigatorMovePreviousItem.Text = "Mover anterior";
			// 
			// bindingNavigatorSeparator
			// 
			this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
			this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
			// 
			// bindingNavigatorPositionItem
			// 
			this.bindingNavigatorPositionItem.AccessibleName = "Posición";
			this.bindingNavigatorPositionItem.AutoSize = false;
			this.bindingNavigatorPositionItem.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
			this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 23);
			this.bindingNavigatorPositionItem.Text = "0";
			this.bindingNavigatorPositionItem.ToolTipText = "Posición actual";
			// 
			// bindingNavigatorSeparator1
			// 
			this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
			this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 25);
			// 
			// bindingNavigatorMoveNextItem
			// 
			this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
			this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
			this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
			this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 22);
			this.bindingNavigatorMoveNextItem.Text = "Mover siguiente";
			// 
			// bindingNavigatorMoveLastItem
			// 
			this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
			this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
			this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
			this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 22);
			this.bindingNavigatorMoveLastItem.Text = "Mover último";
			// 
			// bindingNavigatorSeparator2
			// 
			this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
			this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
			// 
			// txt_fecha_ini_vig
			// 
			this.txt_fecha_ini_vig.Location = new System.Drawing.Point(3, 3);
			this.txt_fecha_ini_vig.Name = "txt_fecha_ini_vig";
			this.txt_fecha_ini_vig.Size = new System.Drawing.Size(100, 22);
			this.txt_fecha_ini_vig.TabIndex = 17;
			// 
			// txt_fecha_fin_vig
			// 
			this.txt_fecha_fin_vig.Location = new System.Drawing.Point(3, 29);
			this.txt_fecha_fin_vig.Name = "txt_fecha_fin_vig";
			this.txt_fecha_fin_vig.Size = new System.Drawing.Size(100, 22);
			this.txt_fecha_fin_vig.TabIndex = 18;
			// 
			// txt_consecutivo_retro
			// 
			this.txt_consecutivo_retro.Location = new System.Drawing.Point(3, 55);
			this.txt_consecutivo_retro.Name = "txt_consecutivo_retro";
			this.txt_consecutivo_retro.Size = new System.Drawing.Size(100, 22);
			this.txt_consecutivo_retro.TabIndex = 19;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.txt_nombre_retro);
			this.panel1.Controls.Add(this.txt_fecha_ini_vig);
			this.panel1.Controls.Add(this.txt_consecutivo_retro);
			this.panel1.Controls.Add(this.txt_fecha_fin_vig);
			this.panel1.Location = new System.Drawing.Point(421, 29);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(106, 110);
			this.panel1.TabIndex = 20;
			this.panel1.TabStop = true;
			// 
			// txt_nombre_retro
			// 
			this.txt_nombre_retro.Location = new System.Drawing.Point(3, 83);
			this.txt_nombre_retro.Name = "txt_nombre_retro";
			this.txt_nombre_retro.Size = new System.Drawing.Size(100, 22);
			this.txt_nombre_retro.TabIndex = 20;
			// 
			// FrmCargarDescuentoDirecto
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(421, 219);
			this.ControlBox = false;
			this.Controls.Add(this.txt_fecha_ent_mercadeo);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.btn_aceptar);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.txt_tipo_dinamica);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.txt_consecutivo);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btn_cerrar);
			this.Controls.Add(this.btn_buscar);
			this.Controls.Add(this.dtp_fecha_fin);
			this.Controls.Add(this.label15);
			this.Controls.Add(this.dtp_fecha_ini);
			this.Controls.Add(this.label16);
			this.Controls.Add(this._bindingNavigator);
			this.Controls.Add(this.panel1);
			this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FrmCargarDescuentoDirecto";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Cargar Dinámica Comercial";
			this.Load += new System.EventHandler(this.FrmCargarDescuentoDirecto_Load);
			((System.ComponentModel.ISupportInitialize)(this._bindingNavigator)).EndInit();
			this._bindingNavigator.ResumeLayout(false);
			this._bindingNavigator.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this._bindingSourceRetro)).EndInit();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txt_fecha_ent_mercadeo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btn_aceptar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_tipo_dinamica;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_consecutivo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_cerrar;
        private System.Windows.Forms.Button btn_buscar;
        private System.Windows.Forms.DateTimePicker dtp_fecha_fin;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.DateTimePicker dtp_fecha_ini;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.BindingNavigator _bindingNavigator;
        private System.Windows.Forms.BindingSource _bindingSourceRetro;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.TextBox txt_fecha_ini_vig;
        private System.Windows.Forms.TextBox txt_fecha_fin_vig;
        private System.Windows.Forms.TextBox txt_consecutivo_retro;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txt_nombre_retro;
    }
}