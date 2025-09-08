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
using PlanAccionComercial.Class;

namespace PlanAccionComercial.Forms
{
    public partial class FrmEditarTipoComunicacion : Form
    {
        TipoComunicacion.Tipo tipo;
        public FrmEditarTipoComunicacion(TipoComunicacion.Tipo tipo)
        {
            InitializeComponent();
            this.tipo = tipo;
        }

        private void FrmEditarTipoComunicacion_Load(object sender, EventArgs e)
        {
            this.Icon = Properties.Resources.plan_24;
            txt_desc.Text = tipo.Descripcion;
            txt_correo.Text = tipo.Correo;
            chk_activo.Checked = tipo.Activo;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txt_desc.Text.Trim().Equals("") || txt_correo.Text.Trim().Equals(""))
            {
                MessageBox.Show("Escriba la descripción y el correo", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            string[] correos = txt_correo.Text.Split(';');
            for (int i = 0; i < correos.Length; i++)
            {
                if (!Regex.IsMatch(correos[i], @"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.IgnoreCase))
                {
                    MessageBox.Show($"El correo {correos[i]} no es valido", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txt_correo.Focus();
                    txt_correo.SelectAll();
                    return;
                }
            }
            try
            {
                TipoComunicacion tipo_comunicacion = new TipoComunicacion();
                tipo.Descripcion = txt_desc.Text.Trim();
                tipo.Activo = chk_activo.Checked;
                tipo.Correo = txt_correo.Text.Trim();
                tipo_comunicacion.EditatTipoComunicacion(tipo);
                
                MessageBox.Show("Tipo de comunicación guardado correctamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
