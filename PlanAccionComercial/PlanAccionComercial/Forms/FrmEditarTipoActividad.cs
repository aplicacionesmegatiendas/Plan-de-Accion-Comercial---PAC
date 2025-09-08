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
    public partial class FrmEditarTipoActividad : Form
    {
        TipoActividad.Tipo tipo;
        public FrmEditarTipoActividad(TipoActividad.Tipo tipo)
        {
            InitializeComponent();
            this.tipo = tipo;
        }

        private void FrmEditarTipoActividad_Load(object sender, EventArgs e)
        {
            try
            {
                Icon = Properties.Resources.plan_24;
                txt_desc.Text = tipo.Descripcion;
                chk_activo.Checked = tipo.Activo;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                tipo.Descripcion = txt_desc.Text.Trim();
                tipo.Activo = chk_activo.Checked;
                tipo_actividad.EditarTipoActividad(tipo);
                MessageBox.Show("Tipo de actividad guardado correctamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
