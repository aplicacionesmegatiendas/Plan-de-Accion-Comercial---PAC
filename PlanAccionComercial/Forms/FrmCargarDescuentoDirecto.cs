using PlanAccionComercial.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlanAccionComercial.Forms
{
    public partial class FrmCargarDescuentoDirecto : Form
    {
        DataTable dt_retro = null;
        FrmEditarDescuentoDirecto frm;
        public FrmCargarDescuentoDirecto(FrmEditarDescuentoDirecto frm)
        {
            InitializeComponent();
            this.frm = frm;
        }

        private void ListarDescuentoDirecto(string fecha_ini, string fecha_fin)
        {
            try
            {
                DescuentoDirecto descuento_directo = new DescuentoDirecto();

                dt_retro = descuento_directo.ListarDescuento(fecha_ini, fecha_fin);

                if (dt_retro != null)
                {
                    _bindingSourceRetro.DataSource = dt_retro;

                    txt_consecutivo.DataBindings.Clear();
                    txt_consecutivo.DataBindings.Add(new Binding("Text", _bindingSourceRetro, "f17_consecutivo"));
                    txt_consecutivo.Text = txt_consecutivo.Text.PadLeft(4, '0');

                    txt_tipo_dinamica.DataBindings.Clear();
                    txt_tipo_dinamica.DataBindings.Add(new Binding("Text", _bindingSourceRetro, "f08_descripcion"));

                    txt_fecha_ent_mercadeo.DataBindings.Clear();
                    txt_fecha_ent_mercadeo.DataBindings.Add(new Binding("Text", _bindingSourceRetro, "f17_fecha"));

                    txt_fecha_ini_vig.DataBindings.Clear();
                    txt_fecha_ini_vig.DataBindings.Add(new Binding("Text", _bindingSourceRetro, "f12_fecha_ini_vig"));

                    txt_fecha_fin_vig.DataBindings.Clear();
                    txt_fecha_fin_vig.DataBindings.Add(new Binding("Text", _bindingSourceRetro, "f12_fecha_fin_vig"));

                    txt_consecutivo_retro.DataBindings.Clear();
                    txt_consecutivo_retro.DataBindings.Add(new Binding("Text", _bindingSourceRetro, "f12_consecutivo"));

                    txt_nombre_retro.DataBindings.Clear();
                    txt_nombre_retro.DataBindings.Add(new Binding("Text", _bindingSourceRetro, "f12_descripcion"));
                }
                else
                {
                    MessageBox.Show("No hay datos disponibles", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_buscar_Click(object sender, EventArgs e)
        {
            try
            {
                ListarDescuentoDirecto(dtp_fecha_ini.Value.Date.ToString("yyyyMMdd"), dtp_fecha_fin.Value.Date.ToString("yyyyMMdd"));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_aceptar_Click(object sender, EventArgs e)
        {
            if (!txt_consecutivo.Text.Equals(""))
            {
                try
                {
                    frm.txt_consecutivo.Text = txt_consecutivo.Text.PadLeft(4, '0');
                    frm.cmb_dinamicas.SelectedValue = txt_tipo_dinamica.Text.Split('-')[0];
                    
                    if (!txt_consecutivo_retro.Text.Equals(""))
                    {
                        frm.retro = true;
                        DateTime min_date = Convert.ToDateTime(txt_fecha_ini_vig.Text);
                        DateTime max_date = Convert.ToDateTime(txt_fecha_fin_vig.Text);
                        frm.dtp_fecha_ini_desc.MinDate = min_date;
                        frm.dtp_fecha_ini_desc.MaxDate = max_date;
                        frm.dtp_fecha_fin_desc.MinDate = min_date;
                        frm.dtp_fecha_fin_desc.MaxDate = max_date;
                        frm.dtp_fecha_ini_desc.Value = min_date;
                        frm.dtp_fecha_fin_desc.Value = max_date;
                        frm.consecutivo_retro = txt_consecutivo_retro.Text;
                        frm.nombre_dinamica=txt_nombre_retro.Text;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                Close();
            }
        }

        private void btn_cerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void _bindingNavigator_RefreshItems(object sender, EventArgs e)
        {
            txt_consecutivo.Text = txt_consecutivo.Text.PadLeft(4, '0');
        }

        private void FrmCargarDescuentoDirecto_Load(object sender, EventArgs e)
        {
            txt_consecutivo.Text = "";
        }
    }
}
