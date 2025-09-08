using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PlanAccionComercial.Class;
using static PlanAccionComercial.Class.Retroplanning;

namespace PlanAccionComercial.Forms
{
	public partial class FrmCargarRetroplanning : Form
	{
		DataTable dt_retro = null;
		FrmDescuentosRetroplanning frm_descuento_retro = null;
		FrmDescuentoDirecto frm_descuento_directo = null;

		public FrmCargarRetroplanning(FrmDescuentosRetroplanning frm)
		{
			InitializeComponent();
			this.frm_descuento_retro = frm;
		}

		public FrmCargarRetroplanning(FrmDescuentoDirecto frm)
		{
			InitializeComponent();
			this.frm_descuento_directo = frm;
		}

		private void ListarRetroplanning(string fecha_ini, string fecha_fin)
		{
			try
			{
				Retroplanning retroplanning = new Retroplanning();

				dt_retro = retroplanning.ListarRetroplanning(fecha_ini, fecha_fin);

				if (dt_retro != null)
				{
					_bindingSourceRetro.DataSource = dt_retro;

					txt_consecutivo.DataBindings.Clear();
					txt_consecutivo.DataBindings.Add(new Binding("Text", _bindingSourceRetro, "f12_consecutivo"));
					txt_consecutivo.Text = txt_consecutivo.Text.PadLeft(4, '0');

					txt_nombre.DataBindings.Clear();
					txt_nombre.DataBindings.Add(new Binding("Text", _bindingSourceRetro, "f12_descripcion"));

					txt_tipo_dinamica.DataBindings.Clear();
					txt_tipo_dinamica.DataBindings.Add(new Binding("Text", _bindingSourceRetro, "f08_descripcion"));

					txt_fecha_ini_vig.DataBindings.Clear();
					txt_fecha_ini_vig.DataBindings.Add(new Binding("Text", _bindingSourceRetro, "f12_fecha_ini_vig"));

					txt_fecha_fin_vig.DataBindings.Clear();
					txt_fecha_fin_vig.DataBindings.Add(new Binding("Text", _bindingSourceRetro, "f12_fecha_fin_vig"));

					txt_fecha_ent_mercadeo.DataBindings.Clear();
					txt_fecha_ent_mercadeo.DataBindings.Add(new Binding("Text", _bindingSourceRetro, "f12_fecha_entrega_mercadeo"));

					txt_fecha_ent_comercial.DataBindings.Clear();
					txt_fecha_ent_comercial.DataBindings.Add(new Binding("Text", _bindingSourceRetro, "f12_fecha_entrega_comercial"));

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

		private void FrmCargarRetroplanning_Load(object sender, EventArgs e)
		{
			Icon = Properties.Resources.plan_24;
			txt_consecutivo.Text = "";
		}

		private void btn_cerrar_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void btn_buscar_Click(object sender, EventArgs e)
		{
			try
			{
				ListarRetroplanning(dtp_fecha_ini.Value.Date.ToString("yyyyMMdd"), dtp_fecha_fin.Value.Date.ToString("yyyyMMdd"));
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void btn_aceptar_Click(object sender, EventArgs e)
		{
			if (frm_descuento_retro != null)
			{
				if (!txt_consecutivo.Text.Equals(""))
				{
					try
					{
						Retroplanning retroplanning = new Retroplanning();
						string consecutivo = retroplanning.ObtenerDescuentoAsociadoRetroplanning(Usuarios.Id, Convert.ToInt32(txt_consecutivo.Text));
						if (consecutivo.Equals(""))
						{
							frm_descuento_retro.txt_consecutivo.Text = txt_consecutivo.Text.PadLeft(4, '0');
							frm_descuento_retro.txt_nombre.Text = txt_nombre.Text;
							frm_descuento_retro.txt_tipo_dinamica.Text = txt_tipo_dinamica.Text;

							frm_descuento_retro.dtp_fecha_ini_desc.MinDate = Convert.ToDateTime(txt_fecha_ini_vig.Text);
							frm_descuento_retro.dtp_fecha_ini_desc.MaxDate = Convert.ToDateTime(txt_fecha_fin_vig.Text);
							frm_descuento_retro.dtp_fecha_ini_desc.Value = Convert.ToDateTime(txt_fecha_ini_vig.Text);
							frm_descuento_retro.dtp_fecha_fin_desc.MinDate = Convert.ToDateTime(txt_fecha_ini_vig.Text);
							frm_descuento_retro.dtp_fecha_fin_desc.MaxDate = Convert.ToDateTime(txt_fecha_fin_vig.Text);
							frm_descuento_retro.dtp_fecha_fin_desc.Value = Convert.ToDateTime(txt_fecha_fin_vig.Text);
							Close();
						}
						else
						{
							MessageBox.Show($"Ya existe el consecutivo de descuento número {consecutivo} que esta asociado al Retroplannig {txt_consecutivo.Text}. Carguelo desde el módulo Editar Dinámicas Comerciales", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
						}
					}
					catch (Exception ex)
					{
						MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				}
			}
			if (frm_descuento_directo != null)
			{
				if (!txt_consecutivo.Text.Equals(""))
				{
					try
					{
						Retroplanning retroplanning = new Retroplanning();
						string consecutivo = retroplanning.ObtenerDescuentoAsociadoRetroplanning(Usuarios.Id, Convert.ToInt32(txt_consecutivo.Text));
						if (consecutivo.Equals(""))
						{
							frm_descuento_directo.txt_consecutivo_retro.Text = txt_consecutivo.Text.PadLeft(3, '0');
							frm_descuento_directo.cmb_dinamicas.Text = txt_tipo_dinamica.Text;
							frm_descuento_directo.cmb_dinamicas.Enabled = false;
							frm_descuento_directo.dtp_fecha_ini_desc.MinDate = Convert.ToDateTime(txt_fecha_ini_vig.Text);
							frm_descuento_directo.dtp_fecha_ini_desc.MaxDate = Convert.ToDateTime(txt_fecha_fin_vig.Text);
							frm_descuento_directo.dtp_fecha_ini_desc.Value = Convert.ToDateTime(txt_fecha_ini_vig.Text);
							frm_descuento_directo.dtp_fecha_fin_desc.MinDate = Convert.ToDateTime(txt_fecha_ini_vig.Text);
							frm_descuento_directo.dtp_fecha_fin_desc.MaxDate = Convert.ToDateTime(txt_fecha_fin_vig.Text);
							frm_descuento_directo.dtp_fecha_fin_desc.Value = Convert.ToDateTime(txt_fecha_fin_vig.Text);
							frm_descuento_directo.nombre_dinamica = txt_nombre.Text;
							Close();
						}
						else
						{
							MessageBox.Show($"Ya existe el consecutivo de descuento número {consecutivo} que esta asociado a Retroplannig {txt_consecutivo.Text}. Carguelo desde el módulo Editar Dinámicas Comerciales", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
						}

					}
					catch (Exception ex)
					{
						MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				}
			}
		}

		private void _bindingNavigator_RefreshItems(object sender, EventArgs e)
		{
			txt_consecutivo.Text = txt_consecutivo.Text.PadLeft(4, '0');
		}
	}
}
