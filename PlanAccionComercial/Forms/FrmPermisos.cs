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
    public partial class FrmPermisos : Form
    {
        public FrmPermisos()
        {
            InitializeComponent();
        }

        private void Limpiar()
        {
            txt_codigo.Text = "";
            txt_descripcion.Text = "";
        }

        private void ListarPermisos()
        {
            Permisos permisos = new Permisos();
            dgvPermisos.AutoGenerateColumns = false;
            col_cod.DataPropertyName = "f01_cod";
            col_desc.DataPropertyName = "f01_descripcion";
            col_activo.DataPropertyName = "f01_activo";
            dgvPermisos.DataSource = permisos.ListarPermisos(false);
        }

        private void FrmPermisos_Load(object sender, EventArgs e)
        {
            try
            {
                this.Top = (this.Parent.ClientSize.Height - this.Height) / 2;
                this.Left = (this.Parent.ClientSize.Width - this.Width) / 2;
                ListarPermisos();
                this.Icon = Properties.Resources.plan_24;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txt_codigo.Text == "" || txt_descripcion.Text == "")
            {
                MessageBox.Show("Escriba el código y la descripción del permiso", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            try
            {
                Permisos permisos = new Permisos();
                Permisos.Permiso permiso = new Permisos.Permiso();
                permiso.Codigo = txt_codigo.Text.Trim();
                permiso.Descripcion = txt_descripcion.Text.Trim();
                permiso.Activo = chk_activo.Checked;

                permisos.GuardarPermiso(permiso);
                MessageBox.Show("permiso guardado correctamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Limpiar();
                ListarPermisos();
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

        private void dgvPermisos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 3 && e.RowIndex >= 0)
                {
                    Permisos.Permiso permiso = new Permisos.Permiso
                    {
                        Codigo = Convert.ToString(dgvPermisos["col_cod", e.RowIndex].Value),
                        Descripcion = Convert.ToString(dgvPermisos["col_desc", e.RowIndex].Value),
                        Activo = Convert.ToBoolean(dgvPermisos["col_activo", e.RowIndex].Value)
                    };
                    new FrmEditarPermiso(permiso).ShowDialog(this);
                    ListarPermisos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvPermisos_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
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
