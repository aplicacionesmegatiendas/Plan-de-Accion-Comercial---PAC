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
    public partial class FrmEditarTipoDinamica : Form
    {
        TipoDinamica.Tipo tipo = new TipoDinamica.Tipo();
        public FrmEditarTipoDinamica(TipoDinamica.Tipo tipo)
        {
            InitializeComponent();
            this.tipo = tipo;
        }

        private void FrmEditarTipoDinamica_Load(object sender, EventArgs e)
        {
            try
            {
                Icon = Properties.Resources.plan_24;
                txt_desc.Text = tipo.Descripcion;
                chk_activo.Checked = tipo.Activo;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
                TipoDinamica tipo_dinamica = new TipoDinamica();
                tipo.Descripcion = txt_desc.Text.Trim();
                tipo.Activo = chk_activo.Checked;
                tipo_dinamica.EditarTipoDinamica(tipo);
               
                MessageBox.Show("Tipo de dinámica guardado correctamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
