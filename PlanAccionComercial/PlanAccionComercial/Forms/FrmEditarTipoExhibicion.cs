using PlanAccionComercial.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlanAccionComercial.Forms
{
    public partial class FrmEditarTipoExhibicion : Form
    {
        TipoExhibicion.Tipo tipo;
        public FrmEditarTipoExhibicion(TipoExhibicion.Tipo tipo)
        {
            InitializeComponent();
            this.tipo = tipo;
        }

        private void FrmEditarTipoExhibicion_Load(object sender, EventArgs e)
        {
            this.Icon = Properties.Resources.plan_24;
            txt_desc.Text = tipo.Descripcion;
            chk_activo.Checked = tipo.Activo;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txt_desc.Text.Trim().Equals(""))
            {
                MessageBox.Show("Escriba la descripción", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            
            try
            {
                TipoExhibicion tipo_comunicacion = new TipoExhibicion();
                tipo.Descripcion = txt_desc.Text.Trim();
                tipo.Activo = chk_activo.Checked;
                tipo_comunicacion.EditatTipoExhibicion(tipo);

                MessageBox.Show("Tipo de exhibición guardado correctamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
