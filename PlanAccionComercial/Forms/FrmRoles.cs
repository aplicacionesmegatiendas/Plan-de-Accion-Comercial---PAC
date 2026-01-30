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
    public partial class FrmRoles : Form
    {
        public FrmRoles()
        {
            InitializeComponent();
        }

        private void ListarPermisos()
        {
            Permisos permisos = new Permisos();
            clb_permisos.DataSource = permisos.ListarPermisos(true);
            clb_permisos.DisplayMember = "f01_descripcion";
            clb_permisos.ValueMember = "f01_cod";
        }

        private void ListarRoles()
        {
            Roles roles = new Roles();
            dgvRoles.AutoGenerateColumns = false;
            col_id.DataPropertyName = "f02_id";
            col_desc.DataPropertyName = "f02_descripcion";
            col_activo.DataPropertyName = "f02_activo";
            dgvRoles.DataSource = roles.ListarRoles(false);
        }


        private void FrmRoles_Load(object sender, EventArgs e)
        {
            try
            {
                this.Top = (this.Parent.ClientSize.Height - this.Height) / 2;
                this.Left = (this.Parent.ClientSize.Width - this.Width) / 2;
                ListarPermisos();
                ListarRoles();
                this.Icon = Properties.Resources.plan_24;
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
                Roles.Rol rol = new Roles.Rol();
                rol.Descripcion = txt_descripcion.Text.Trim();
                rol.Activo = chk_activo.Checked;
                roles.GuardarRol(rol, permisos);
                ListarRoles();
                MessageBox.Show("Rol guardado correctamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void dgvRoles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 3)
                {
                    Roles roles = new Roles();
                    Roles.Rol rol = new Roles.Rol();
                    rol.Id = Convert.ToInt32(dgvRoles["col_id", e.RowIndex].Value);
                    rol.Descripcion = Convert.ToString(dgvRoles["col_desc", e.RowIndex].Value);
                    rol.Activo = Convert.ToBoolean(dgvRoles["col_activo", e.RowIndex].Value);
                    Task<List<string>> task = Task.Run(() => roles.ListarPermisosRol(Convert.ToInt32(dgvRoles["col_id", e.RowIndex].Value)));
                    task.Wait();
                    List<string> permisos = task.Result;
                    new FrmEditarRol(rol, permisos).ShowDialog(this);
                    ListarRoles();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvRoles_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var grid = sender as DataGridView;
            var rowIdx = (e.RowIndex + 1).ToString();

            var centerFormat = new StringFormat()
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };

            var headerBounds = new Rectangle(e.RowBounds.Left, e.RowBounds.Top, grid.RowHeadersWidth, e.RowBounds.Height);
            e.Graphics.DrawString(rowIdx, this.Font, SystemBrushes.ControlDark, headerBounds, centerFormat);
        }
    }
}
