using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PlanAccionComercial.Class;

namespace PlanAccionComercial.Forms
{
    public partial class FrmPpal : Form
    {
        public FrmPpal()
        {
            InitializeComponent();
        }

        private void HabilitarPermisos()
        {
            foreach (string permiso in Usuarios.Permisos)
            {
                foreach (ToolStripMenuItem menu in menuStrip1.Items)
                {
                    foreach (ToolStripMenuItem sub in menu.DropDownItems)
                    {
                        if (Convert.ToString(sub.Tag).Equals(permiso.Trim()))
                        {
                            sub.Enabled = true;
                        }

                        foreach (ToolStripMenuItem sub2 in sub.DropDownItems)
                        {
                            if (Convert.ToString(sub2.Tag).Equals(permiso.Trim()))
                            {
                                sub2.Enabled = true;
                            }
                        }
                    }
                }
            }
        }

        private void InhabilitarPermisos()
        {
            foreach (ToolStripMenuItem menu in menuStrip1.Items)
            {
                foreach (ToolStripMenuItem sub in menu.DropDownItems)
                {
                    sub.Enabled = false;
                    foreach (ToolStripMenuItem sub2 in sub.DropDownItems)
                    {
                        sub2.Enabled = false;
                    }
                }
            }
            refrescarToolStripMenuItem.Enabled = true;
        }

        private void CerrarRetroplanning()
        {
            Retroplanning retroplanning = new Retroplanning();
            retroplanning.CerrarRetroplanning();
        }

        private void permisosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form _FrmPermisos = this.MdiChildren.FirstOrDefault(x => x is FrmPermisos);
            if (_FrmPermisos != null)
            {
                _FrmPermisos.BringToFront();
                return;
            }
            _FrmPermisos = new FrmPermisos();
            _FrmPermisos.MdiParent = this;
            _FrmPermisos.Show();
        }

        private void rolesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form _FrmRoles = this.MdiChildren.FirstOrDefault(x => x is FrmRoles);
            if (_FrmRoles != null)
            {
                _FrmRoles.BringToFront();
                return;
            }
            _FrmRoles = new FrmRoles();
            _FrmRoles.MdiParent = this;
            _FrmRoles.Show();
        }

        private void usuariosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form _FrmUsuarios = this.MdiChildren.FirstOrDefault(x => x is FrmUsuarios);
            if (_FrmUsuarios != null)
            {
                _FrmUsuarios.BringToFront();
                return;
            }
            _FrmUsuarios = new FrmUsuarios();
            _FrmUsuarios.MdiParent = this;
            _FrmUsuarios.Show();
        }

        private void FrmPpal_Load(object sender, EventArgs e)
        {
            try
            {
                Icon = Properties.Resources.plan_24;
                FrmSesion sesion = new FrmSesion();
                sesion.ShowDialog(this);
                if (Usuarios.Permisos == null)
                    return;
                HabilitarPermisos();
                CerrarRetroplanning();
                Reportes reportes = new Reportes();
                reportes.EliminarDescuentosNoConfirmados();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void refrescarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Usuarios usuario = new Usuarios();
                Task<List<string>> task_permisos = Task.Run(() => usuario.ObtenerPermisosUsuario(Usuarios.Rol));
                task_permisos.Wait();
                List<string> permisos = task_permisos.Result;
                Usuarios.Permisos = permisos;

                InhabilitarPermisos();
                HabilitarPermisos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void clustersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form _FrmClusters = this.MdiChildren.FirstOrDefault(x => x is FrmClusters);
            if (_FrmClusters != null)
            {
                _FrmClusters.BringToFront();
                return;
            }
            _FrmClusters = new FrmClusters();
            _FrmClusters.MdiParent = this;
            _FrmClusters.Show();
        }

        private void tiposDeComunicacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form _FrmTipoComunicacion = this.MdiChildren.FirstOrDefault(x => x is FrmTipoComunicacion);
            if (_FrmTipoComunicacion != null)
            {
                _FrmTipoComunicacion.BringToFront();
                return;
            }
            _FrmTipoComunicacion = new FrmTipoComunicacion();
            _FrmTipoComunicacion.MdiParent = this;
            _FrmTipoComunicacion.Show();
        }

        private void tiposDeDinamicaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form _FrmTipoDinamica = this.MdiChildren.FirstOrDefault(x => x is FrmTipoDinamica);
            if (_FrmTipoDinamica != null)
            {
                _FrmTipoDinamica.BringToFront();
                return;
            }
            _FrmTipoDinamica = new FrmTipoDinamica();
            _FrmTipoDinamica.MdiParent = this;
            _FrmTipoDinamica.Show();
        }

        private void retroplanningToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form _FrmRetroplanning = this.MdiChildren.FirstOrDefault(x => x is FrmRetroplanning);
            if (_FrmRetroplanning != null)
            {
                _FrmRetroplanning.BringToFront();
                return;
            }
            _FrmRetroplanning = new FrmRetroplanning();
            _FrmRetroplanning.MdiParent = this;
            _FrmRetroplanning.Show();
        }

        private void descuentoPorRetroplanningToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            Form _FrmDescuentosRetroplanning = this.MdiChildren.FirstOrDefault(x => x is FrmDescuentosRetroplanning);
            if (_FrmDescuentosRetroplanning != null)
            {
                _FrmDescuentosRetroplanning.BringToFront();
                return;
            }
            _FrmDescuentosRetroplanning = new FrmDescuentosRetroplanning();
            _FrmDescuentosRetroplanning.MdiParent = this;
            _FrmDescuentosRetroplanning.Show();
			Cursor = Cursors.Default;
		}

        private void reporteDeEstadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form _FrmReporteEstado = this.MdiChildren.FirstOrDefault(x => x is FrmReporteEstado);
            if (_FrmReporteEstado != null)
            {
                _FrmReporteEstado.BringToFront();
                return;
            }
            _FrmReporteEstado = new FrmReporteEstado();
            _FrmReporteEstado.MdiParent = this;
            _FrmReporteEstado.Show();
        }

        private void dinámicasComercialesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form _FrmDescuentoDirecto = this.MdiChildren.FirstOrDefault(x => x is FrmDescuentoDirecto);
            if (_FrmDescuentoDirecto != null)
            {
                _FrmDescuentoDirecto.BringToFront();
                return;
            }
            _FrmDescuentoDirecto = new FrmDescuentoDirecto();
            _FrmDescuentoDirecto.MdiParent = this;
            _FrmDescuentoDirecto.Show();
        }

        private void editarDinamicasComercialesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            Form _FrmEditarDescuentoDirecto = this.MdiChildren.FirstOrDefault(x => x is FrmEditarDescuentoDirecto);
            if (_FrmEditarDescuentoDirecto != null)
            {
                _FrmEditarDescuentoDirecto.BringToFront();
                return;
            }
            _FrmEditarDescuentoDirecto = new FrmEditarDescuentoDirecto();
            _FrmEditarDescuentoDirecto.MdiParent = this;
            _FrmEditarDescuentoDirecto.Show();
            Cursor = Cursors.Default;
        }

        private void tiposDeExhibicionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form _FrmTipoExhibicion = this.MdiChildren.FirstOrDefault(x => x is FrmTipoExhibicion);
            if (_FrmTipoExhibicion != null)
            {
                _FrmTipoExhibicion.BringToFront();
                return;
            }
            _FrmTipoExhibicion = new FrmTipoExhibicion();
            _FrmTipoExhibicion.MdiParent = this;
            _FrmTipoExhibicion.Show();
        }

        private void reporteOperacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form _FrmReporteOperaciones = this.MdiChildren.FirstOrDefault(x => x is FrmReporteOperaciones);
            if (_FrmReporteOperaciones != null)
            {
                _FrmReporteOperaciones.BringToFront();
                return;
            }
            _FrmReporteOperaciones = new FrmReporteOperaciones();
            _FrmReporteOperaciones.MdiParent = this;
            _FrmReporteOperaciones.Show();
        }

        private void rechazarDescuentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form _FrmRechazarDescuento = this.MdiChildren.FirstOrDefault(x => x is FrmRechazarDescuento);
            if (_FrmRechazarDescuento != null)
            {
                _FrmRechazarDescuento.BringToFront();
                return;
            }
            _FrmRechazarDescuento = new FrmRechazarDescuento();
            _FrmRechazarDescuento.MdiParent = this;
            _FrmRechazarDescuento.Show();
        }

        private void centrosDeOperaciónYListasDePrecioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form _FrmCentrosOperacionListaPrecios = this.MdiChildren.FirstOrDefault(x => x is FrmCentrosOperacionListaPrecios);
            if (_FrmCentrosOperacionListaPrecios != null)
            {
                _FrmCentrosOperacionListaPrecios.BringToFront();
                return;
            }
            _FrmCentrosOperacionListaPrecios = new FrmCentrosOperacionListaPrecios();
            _FrmCentrosOperacionListaPrecios.MdiParent = this;
            _FrmCentrosOperacionListaPrecios.Show();
        }

        private void reporteComercialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form _FrmReporteComercial = this.MdiChildren.FirstOrDefault(x => x is FrmReporteComercial);
            if (_FrmReporteComercial != null)
            {
                _FrmReporteComercial.BringToFront();
                return;
            }
            _FrmReporteComercial = new FrmReporteComercial();
            _FrmReporteComercial.MdiParent = this;
            _FrmReporteComercial.Show();
        }

		private void reporteMercadeoToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Form _FrmReporteMercadeo = this.MdiChildren.FirstOrDefault(x => x is FrmReporteMercadeo);
			if (_FrmReporteMercadeo != null)
			{
				_FrmReporteMercadeo.BringToFront();
				return;
			}
			_FrmReporteMercadeo = new FrmReporteMercadeo();
			_FrmReporteMercadeo.MdiParent = this;
			_FrmReporteMercadeo.Show();
		}

        private void reporteLiquidaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form _FrmReporteLiquidacion = this.MdiChildren.FirstOrDefault(x => x is FrmReporteLiquidacion);
            if (_FrmReporteLiquidacion != null)
            {
                _FrmReporteLiquidacion.BringToFront();
                return;
            }
            _FrmReporteLiquidacion = new FrmReporteLiquidacion();
            _FrmReporteLiquidacion.MdiParent = this;
            _FrmReporteLiquidacion.Show();
        }

		private void reporteRetroplanningToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Form _FrmReporteRetroplanning = this.MdiChildren.FirstOrDefault(x => x is FrmReporteRetroplanning);
			if (_FrmReporteRetroplanning != null)
			{
				_FrmReporteRetroplanning.BringToFront();
				return;
			}
			_FrmReporteRetroplanning = new FrmReporteRetroplanning();
			_FrmReporteRetroplanning.MdiParent = this;
			_FrmReporteRetroplanning.Show();
		}
	}
}