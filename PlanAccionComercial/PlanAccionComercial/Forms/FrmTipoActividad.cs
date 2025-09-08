using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PlanAcuerdoComercial.Class;

namespace PlanAcuerdoComercial.Forms
{
    public partial class FrmTipoActividad : Form
    {
        public FrmTipoActividad()
        {
            InitializeComponent();
        }

        private void ListarTiposActividad()
        {
            TipoActividad tipo_actividad = new TipoActividad();
            dgv_tipos.AutoGenerateColumns = false;
            col_id.DataPropertyName = "f10_id";
            col_desc.DataPropertyName = "f10_descripcion";
            col_activo.DataPropertyName = "f10_activo";
            Task<DataTable> task = Task.Run(() => tipo_actividad.ListarTiposActividad());
            task.Wait();
            dgv_tipos.DataSource = task.Result;
        }


        private void FrmTipoActividad_Load(object sender, EventArgs e)
        {
            try
            {
                this.Top = (this.Parent.ClientSize.Height - this.Height) / 2;
                this.Left = (this.Parent.ClientSize.Width - this.Width) / 2;
                this.Icon = Properties.Resources.plan_24;
                ListarTiposActividad();
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

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txt_desc.Text.Trim().Equals(""))
            {
                MessageBox.Show("Escriba la descripción", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_desc.Focus();
                txt_desc.SelectAll();
                return;
            }
            try
            {
                TipoActividad tipo_actividad = new TipoActividad();
                TipoActividad.Tipo tipo = new TipoActividad.Tipo();
                tipo.Descripcion = txt_desc.Text.Trim();
                tipo.Activo = chk_activo.Checked;
                tipo_actividad.GuardarTipoActividad(tipo);
                ListarTiposActividad();
                MessageBox.Show("Tipo de actividad guardado correctamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgv_tipos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3 && e.RowIndex >= 0)
            {
                try
                {
                    TipoActividad.Tipo tipo = new TipoActividad.Tipo();
                    tipo.Id = Convert.ToInt32(dgv_tipos["col_id", e.RowIndex].Value);
                    tipo.Descripcion = Convert.ToString(dgv_tipos["col_desc", e.RowIndex].Value);
                    tipo.Activo = Convert.ToBoolean(dgv_tipos["col_activo", e.RowIndex].Value);
                    new FrmEditarTipoActividad(tipo).ShowDialog(this);
                    ListarTiposActividad();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
