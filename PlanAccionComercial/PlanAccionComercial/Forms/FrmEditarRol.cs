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
    public partial class FrmEditarRol : Form
    {
        Roles.Rol rol;
        List<string> permisos;
        public FrmEditarRol(Roles.Rol rol, List<string> permisos)
        {
            InitializeComponent();

            this.rol = rol;
            this.permisos = permisos;
        }

        private void ListarPermisos()
        {
            Permisos permisos = new Permisos();
            clb_permisos.DataSource = permisos.ListarPermisos(true);
            clb_permisos.DisplayMember = "f01_descripcion";
            clb_permisos.ValueMember = "f01_cod";
        }

        private void FrmEditarRol_Load(object sender, EventArgs e)
        {
            try
            {
                Icon = Properties.Resources.plan_24;
                txt_descripcion.Text = rol.Descripcion;
                chk_activo.Checked = rol.Activo;
                ListarPermisos();
                for (int i = 0; i < clb_permisos.Items.Count; i++)
                {
                    clb_permisos.SelectedIndex = i;
                    for (int j = 0; j < permisos.Count; j++)
                    {
                        if (Convert.ToString(clb_permisos.SelectedValue) == permisos[j])
                        {
                            clb_permisos.SetItemChecked(i, true);
                        }
                    }
                }

                clb_permisos.ClearSelected();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txt_descripcion.Text.Trim().Equals(""))
            {
                MessageBox.Show("Escriba la descripción del rol", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_descripcion.Focus();
                return;
            }
            if (clb_permisos.CheckedItems.Count == 0)
            {
                MessageBox.Show("Seleccione los permisos para el rol", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                clb_permisos.Focus();
                return;
            }

            try
            {
                List<string> permisos = new List<string>();
                foreach (DataRowView item in clb_permisos.CheckedItems)
                {
                    permisos.Add(item[0].ToString());
                }
                Roles roles = new Roles();

                rol.Descripcion = txt_descripcion.Text.Trim();
                rol.Activo = chk_activo.Checked;
                roles.EditarRol(rol, permisos);

                MessageBox.Show("Rol guardado correctamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
