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
    public partial class FrmEditarPermiso : Form
    {
        Permisos.Permiso permiso;
        public FrmEditarPermiso(Permisos.Permiso permiso)
        {
            InitializeComponent();
            this.permiso = permiso;
        }

        private void FrmEditarPermiso_Load(object sender, EventArgs e)
        {
            txt_codigo.Text = permiso.Codigo;
            txt_descripcion.Text = permiso.Descripcion;
            chk_activo.Checked = permiso.Activo;
            this.Icon = Properties.Resources.plan_24;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txt_descripcion.Text == "")
            {
                MessageBox.Show("Escriba la descripción del permiso", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            try
            {
                Permisos permiso = new Permisos();
                this.permiso.Descripcion = txt_descripcion.Text.Trim();
                this.permiso.Activo = chk_activo.Checked;

                permiso.EditarPermiso(this.permiso);
                MessageBox.Show("permiso guardado correctamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
