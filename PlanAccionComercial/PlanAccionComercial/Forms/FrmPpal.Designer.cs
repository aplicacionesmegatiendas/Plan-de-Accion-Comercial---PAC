namespace PlanAccionComercial.Forms
{
    partial class FrmPpal
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPpal));
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.usuariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.permisosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.rolesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.usuariosToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.refrescarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.maestrosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.clustersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.tiposDeComunicaciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.tiposDeDinámicaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.tiposDeExhibicionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.centrosDeOperaciónYListasDePrecioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.transaccionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.retroplanningToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.descuentoPorRetroplanningToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.dinámicasComercialesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.editarDinamicasComercialesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.rechazarDescuentoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.reportesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.reporteDeEstadoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.reporteOperacionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.reporteComercialToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.reporteMercadeoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.reporteLiquidaciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.reporteRetroplanningToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.usuariosToolStripMenuItem,
            this.maestrosToolStripMenuItem,
            this.transaccionesToolStripMenuItem,
            this.reportesToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(736, 24);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// usuariosToolStripMenuItem
			// 
			this.usuariosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.permisosToolStripMenuItem,
            this.rolesToolStripMenuItem,
            this.usuariosToolStripMenuItem1,
            this.refrescarToolStripMenuItem});
			this.usuariosToolStripMenuItem.Name = "usuariosToolStripMenuItem";
			this.usuariosToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
			this.usuariosToolStripMenuItem.Tag = "00";
			this.usuariosToolStripMenuItem.Text = "Usuarios";
			// 
			// permisosToolStripMenuItem
			// 
			this.permisosToolStripMenuItem.Enabled = false;
			this.permisosToolStripMenuItem.Name = "permisosToolStripMenuItem";
			this.permisosToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
			this.permisosToolStripMenuItem.Tag = "0001";
			this.permisosToolStripMenuItem.Text = "Permisos";
			this.permisosToolStripMenuItem.Click += new System.EventHandler(this.permisosToolStripMenuItem_Click);
			// 
			// rolesToolStripMenuItem
			// 
			this.rolesToolStripMenuItem.Enabled = false;
			this.rolesToolStripMenuItem.Name = "rolesToolStripMenuItem";
			this.rolesToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
			this.rolesToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
			this.rolesToolStripMenuItem.Tag = "0002";
			this.rolesToolStripMenuItem.Text = "Roles";
			this.rolesToolStripMenuItem.Click += new System.EventHandler(this.rolesToolStripMenuItem_Click);
			// 
			// usuariosToolStripMenuItem1
			// 
			this.usuariosToolStripMenuItem1.Enabled = false;
			this.usuariosToolStripMenuItem1.Name = "usuariosToolStripMenuItem1";
			this.usuariosToolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.U)));
			this.usuariosToolStripMenuItem1.Size = new System.Drawing.Size(161, 22);
			this.usuariosToolStripMenuItem1.Tag = "0003";
			this.usuariosToolStripMenuItem1.Text = "Usuarios";
			this.usuariosToolStripMenuItem1.Click += new System.EventHandler(this.usuariosToolStripMenuItem1_Click);
			// 
			// refrescarToolStripMenuItem
			// 
			this.refrescarToolStripMenuItem.Name = "refrescarToolStripMenuItem";
			this.refrescarToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
			this.refrescarToolStripMenuItem.Text = "Refrescar";
			this.refrescarToolStripMenuItem.Click += new System.EventHandler(this.refrescarToolStripMenuItem_Click);
			// 
			// maestrosToolStripMenuItem
			// 
			this.maestrosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clustersToolStripMenuItem,
            this.tiposDeComunicaciónToolStripMenuItem,
            this.tiposDeDinámicaToolStripMenuItem,
            this.tiposDeExhibicionToolStripMenuItem,
            this.centrosDeOperaciónYListasDePrecioToolStripMenuItem});
			this.maestrosToolStripMenuItem.Name = "maestrosToolStripMenuItem";
			this.maestrosToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
			this.maestrosToolStripMenuItem.Tag = "01";
			this.maestrosToolStripMenuItem.Text = "Maestros";
			// 
			// clustersToolStripMenuItem
			// 
			this.clustersToolStripMenuItem.Enabled = false;
			this.clustersToolStripMenuItem.Name = "clustersToolStripMenuItem";
			this.clustersToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.T)));
			this.clustersToolStripMenuItem.Size = new System.Drawing.Size(280, 22);
			this.clustersToolStripMenuItem.Tag = "0101";
			this.clustersToolStripMenuItem.Text = "Clusters";
			this.clustersToolStripMenuItem.Click += new System.EventHandler(this.clustersToolStripMenuItem_Click);
			// 
			// tiposDeComunicaciónToolStripMenuItem
			// 
			this.tiposDeComunicaciónToolStripMenuItem.Enabled = false;
			this.tiposDeComunicaciónToolStripMenuItem.Name = "tiposDeComunicaciónToolStripMenuItem";
			this.tiposDeComunicaciónToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.M)));
			this.tiposDeComunicaciónToolStripMenuItem.Size = new System.Drawing.Size(280, 22);
			this.tiposDeComunicaciónToolStripMenuItem.Tag = "0102";
			this.tiposDeComunicaciónToolStripMenuItem.Text = "Tipos de comunicación";
			this.tiposDeComunicaciónToolStripMenuItem.Click += new System.EventHandler(this.tiposDeComunicacionToolStripMenuItem_Click);
			// 
			// tiposDeDinámicaToolStripMenuItem
			// 
			this.tiposDeDinámicaToolStripMenuItem.Enabled = false;
			this.tiposDeDinámicaToolStripMenuItem.Name = "tiposDeDinámicaToolStripMenuItem";
			this.tiposDeDinámicaToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
			this.tiposDeDinámicaToolStripMenuItem.Size = new System.Drawing.Size(280, 22);
			this.tiposDeDinámicaToolStripMenuItem.Tag = "0103";
			this.tiposDeDinámicaToolStripMenuItem.Text = "Tipos de dinámica";
			this.tiposDeDinámicaToolStripMenuItem.Click += new System.EventHandler(this.tiposDeDinamicaToolStripMenuItem_Click);
			// 
			// tiposDeExhibicionToolStripMenuItem
			// 
			this.tiposDeExhibicionToolStripMenuItem.Enabled = false;
			this.tiposDeExhibicionToolStripMenuItem.Name = "tiposDeExhibicionToolStripMenuItem";
			this.tiposDeExhibicionToolStripMenuItem.Size = new System.Drawing.Size(280, 22);
			this.tiposDeExhibicionToolStripMenuItem.Tag = "0104";
			this.tiposDeExhibicionToolStripMenuItem.Text = "Tipos de exhibición";
			this.tiposDeExhibicionToolStripMenuItem.Click += new System.EventHandler(this.tiposDeExhibicionToolStripMenuItem_Click);
			// 
			// centrosDeOperaciónYListasDePrecioToolStripMenuItem
			// 
			this.centrosDeOperaciónYListasDePrecioToolStripMenuItem.Enabled = false;
			this.centrosDeOperaciónYListasDePrecioToolStripMenuItem.Name = "centrosDeOperaciónYListasDePrecioToolStripMenuItem";
			this.centrosDeOperaciónYListasDePrecioToolStripMenuItem.Size = new System.Drawing.Size(280, 22);
			this.centrosDeOperaciónYListasDePrecioToolStripMenuItem.Tag = "0105";
			this.centrosDeOperaciónYListasDePrecioToolStripMenuItem.Text = "Centros de operación y Listas de precio";
			this.centrosDeOperaciónYListasDePrecioToolStripMenuItem.Click += new System.EventHandler(this.centrosDeOperaciónYListasDePrecioToolStripMenuItem_Click);
			// 
			// transaccionesToolStripMenuItem
			// 
			this.transaccionesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.retroplanningToolStripMenuItem,
            this.descuentoPorRetroplanningToolStripMenuItem,
            this.dinámicasComercialesToolStripMenuItem,
            this.editarDinamicasComercialesToolStripMenuItem,
            this.rechazarDescuentoToolStripMenuItem});
			this.transaccionesToolStripMenuItem.Name = "transaccionesToolStripMenuItem";
			this.transaccionesToolStripMenuItem.Size = new System.Drawing.Size(92, 20);
			this.transaccionesToolStripMenuItem.Tag = "02";
			this.transaccionesToolStripMenuItem.Text = "Transacciones";
			// 
			// retroplanningToolStripMenuItem
			// 
			this.retroplanningToolStripMenuItem.Enabled = false;
			this.retroplanningToolStripMenuItem.Name = "retroplanningToolStripMenuItem";
			this.retroplanningToolStripMenuItem.Size = new System.Drawing.Size(268, 22);
			this.retroplanningToolStripMenuItem.Tag = "0201";
			this.retroplanningToolStripMenuItem.Text = "Retroplanning";
			this.retroplanningToolStripMenuItem.Click += new System.EventHandler(this.retroplanningToolStripMenuItem_Click);
			// 
			// descuentoPorRetroplanningToolStripMenuItem
			// 
			this.descuentoPorRetroplanningToolStripMenuItem.Enabled = false;
			this.descuentoPorRetroplanningToolStripMenuItem.Name = "descuentoPorRetroplanningToolStripMenuItem";
			this.descuentoPorRetroplanningToolStripMenuItem.Size = new System.Drawing.Size(268, 22);
			this.descuentoPorRetroplanningToolStripMenuItem.Tag = "0202";
			this.descuentoPorRetroplanningToolStripMenuItem.Text = "Descuento por retroplanning";
			this.descuentoPorRetroplanningToolStripMenuItem.Visible = false;
			this.descuentoPorRetroplanningToolStripMenuItem.Click += new System.EventHandler(this.descuentoPorRetroplanningToolStripMenuItem_Click);
			// 
			// dinámicasComercialesToolStripMenuItem
			// 
			this.dinámicasComercialesToolStripMenuItem.Enabled = false;
			this.dinámicasComercialesToolStripMenuItem.Name = "dinámicasComercialesToolStripMenuItem";
			this.dinámicasComercialesToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
			this.dinámicasComercialesToolStripMenuItem.Size = new System.Drawing.Size(268, 22);
			this.dinámicasComercialesToolStripMenuItem.Tag = "0203";
			this.dinámicasComercialesToolStripMenuItem.Text = "Dinámicas comerciales";
			this.dinámicasComercialesToolStripMenuItem.Click += new System.EventHandler(this.dinámicasComercialesToolStripMenuItem_Click);
			// 
			// editarDinamicasComercialesToolStripMenuItem
			// 
			this.editarDinamicasComercialesToolStripMenuItem.Enabled = false;
			this.editarDinamicasComercialesToolStripMenuItem.Name = "editarDinamicasComercialesToolStripMenuItem";
			this.editarDinamicasComercialesToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
			this.editarDinamicasComercialesToolStripMenuItem.Size = new System.Drawing.Size(268, 22);
			this.editarDinamicasComercialesToolStripMenuItem.Tag = "0204";
			this.editarDinamicasComercialesToolStripMenuItem.Text = "Editar Dinamicas comerciales";
			this.editarDinamicasComercialesToolStripMenuItem.Click += new System.EventHandler(this.editarDinamicasComercialesToolStripMenuItem_Click);
			// 
			// rechazarDescuentoToolStripMenuItem
			// 
			this.rechazarDescuentoToolStripMenuItem.Enabled = false;
			this.rechazarDescuentoToolStripMenuItem.Name = "rechazarDescuentoToolStripMenuItem";
			this.rechazarDescuentoToolStripMenuItem.Size = new System.Drawing.Size(268, 22);
			this.rechazarDescuentoToolStripMenuItem.Tag = "0205";
			this.rechazarDescuentoToolStripMenuItem.Text = "Rechazar descuento";
			this.rechazarDescuentoToolStripMenuItem.Click += new System.EventHandler(this.rechazarDescuentoToolStripMenuItem_Click);
			// 
			// reportesToolStripMenuItem
			// 
			this.reportesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reporteDeEstadoToolStripMenuItem,
            this.reporteOperacionesToolStripMenuItem,
            this.reporteComercialToolStripMenuItem,
            this.reporteMercadeoToolStripMenuItem,
            this.reporteLiquidaciónToolStripMenuItem,
            this.reporteRetroplanningToolStripMenuItem});
			this.reportesToolStripMenuItem.Name = "reportesToolStripMenuItem";
			this.reportesToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
			this.reportesToolStripMenuItem.Tag = "03";
			this.reportesToolStripMenuItem.Text = "Reportes";
			// 
			// reporteDeEstadoToolStripMenuItem
			// 
			this.reporteDeEstadoToolStripMenuItem.Enabled = false;
			this.reporteDeEstadoToolStripMenuItem.Name = "reporteDeEstadoToolStripMenuItem";
			this.reporteDeEstadoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
			this.reporteDeEstadoToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
			this.reporteDeEstadoToolStripMenuItem.Tag = "0301";
			this.reporteDeEstadoToolStripMenuItem.Text = "Reporte de estado";
			this.reporteDeEstadoToolStripMenuItem.Click += new System.EventHandler(this.reporteDeEstadoToolStripMenuItem_Click);
			// 
			// reporteOperacionesToolStripMenuItem
			// 
			this.reporteOperacionesToolStripMenuItem.Enabled = false;
			this.reporteOperacionesToolStripMenuItem.Name = "reporteOperacionesToolStripMenuItem";
			this.reporteOperacionesToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
			this.reporteOperacionesToolStripMenuItem.Tag = "0302";
			this.reporteOperacionesToolStripMenuItem.Text = "Reporte operaciones";
			this.reporteOperacionesToolStripMenuItem.Click += new System.EventHandler(this.reporteOperacionesToolStripMenuItem_Click);
			// 
			// reporteComercialToolStripMenuItem
			// 
			this.reporteComercialToolStripMenuItem.Enabled = false;
			this.reporteComercialToolStripMenuItem.Name = "reporteComercialToolStripMenuItem";
			this.reporteComercialToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.I)));
			this.reporteComercialToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
			this.reporteComercialToolStripMenuItem.Tag = "0303";
			this.reporteComercialToolStripMenuItem.Text = "Reporte comercial";
			this.reporteComercialToolStripMenuItem.Click += new System.EventHandler(this.reporteComercialToolStripMenuItem_Click);
			// 
			// reporteMercadeoToolStripMenuItem
			// 
			this.reporteMercadeoToolStripMenuItem.Enabled = false;
			this.reporteMercadeoToolStripMenuItem.Name = "reporteMercadeoToolStripMenuItem";
			this.reporteMercadeoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
			this.reporteMercadeoToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
			this.reporteMercadeoToolStripMenuItem.Tag = "0304";
			this.reporteMercadeoToolStripMenuItem.Text = "Reporte mercadeo";
			this.reporteMercadeoToolStripMenuItem.Click += new System.EventHandler(this.reporteMercadeoToolStripMenuItem_Click);
			// 
			// reporteLiquidaciónToolStripMenuItem
			// 
			this.reporteLiquidaciónToolStripMenuItem.Enabled = false;
			this.reporteLiquidaciónToolStripMenuItem.Name = "reporteLiquidaciónToolStripMenuItem";
			this.reporteLiquidaciónToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.L)));
			this.reporteLiquidaciónToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
			this.reporteLiquidaciónToolStripMenuItem.Tag = "0305";
			this.reporteLiquidaciónToolStripMenuItem.Text = "Reporte liquidación";
			this.reporteLiquidaciónToolStripMenuItem.Click += new System.EventHandler(this.reporteLiquidaciónToolStripMenuItem_Click);
			// 
			// reporteRetroplanningToolStripMenuItem
			// 
			this.reporteRetroplanningToolStripMenuItem.Enabled = false;
			this.reporteRetroplanningToolStripMenuItem.Name = "reporteRetroplanningToolStripMenuItem";
			this.reporteRetroplanningToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.G)));
			this.reporteRetroplanningToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
			this.reporteRetroplanningToolStripMenuItem.Tag = "0306";
			this.reporteRetroplanningToolStripMenuItem.Text = "Reporte Retroplanning";
			this.reporteRetroplanningToolStripMenuItem.Click += new System.EventHandler(this.reporteRetroplanningToolStripMenuItem_Click);
			// 
			// FrmPpal
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(736, 461);
			this.Controls.Add(this.menuStrip1);
			this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.IsMdiContainer = true;
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "FrmPpal";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Plan de Acción Comercial (PAC)";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.FrmPpal_Load);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem usuariosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem permisosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rolesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usuariosToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem refrescarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem maestrosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clustersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tiposDeComunicaciónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tiposDeDinámicaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem transaccionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem retroplanningToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem descuentoPorRetroplanningToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reporteDeEstadoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dinámicasComercialesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editarDinamicasComercialesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tiposDeExhibicionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reporteOperacionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rechazarDescuentoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem centrosDeOperaciónYListasDePrecioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reporteComercialToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem reporteMercadeoToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem reporteLiquidaciónToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem reporteRetroplanningToolStripMenuItem;
	}
}