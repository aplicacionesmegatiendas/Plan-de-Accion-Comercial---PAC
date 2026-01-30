using ClosedXML.Excel;
using PlanAccionComercial.Class;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static PlanAccionComercial.Class.Permisos;

namespace PlanAccionComercial.Forms
{
	public partial class FrmDescuentoDirecto : Form
	{
		bool salida = false;

		DataTable dt_plan1 = null;
		DataTable dt_criterio1 = null;

		DataTable dt_plan2 = null;
		DataTable dt_criterio2 = null;

		DataTable dt_plan3 = null;
		DataTable dt_criterio3 = null;

		DateTime min_date;
		DateTime max_date;

		DataTable dtProveedores1 = null;
		DataTable dtProveedores2 = null;

		public string nombre_dinamica = null;

		public FrmDescuentoDirecto()
		{
			InitializeComponent();
		}

		private int ObtenerConsecutivo(int id)
		{
			Retroplanning retroplanning = new Retroplanning();
			return Convert.ToInt32(retroplanning.ObtenerValorConfiguracion(id));
		}

		private void CrearObservacion()
		{
			if (rdb_plan.Checked)
			{
				string p1 = cmb_plan.SelectedIndex >= 0 ? cmb_plan.Text : "";
				string c1 = cmb_criterio.SelectedIndex >= 0 ? cmb_criterio.Text : "";

				string p2 = cmb_plan2.SelectedIndex >= 0 ? cmb_plan2.Text : "";
				string c2 = cmb_criterio2.SelectedIndex >= 0 ? cmb_criterio2.Text : "";

				string p3 = cmb_plan3.SelectedIndex >= 0 ? cmb_plan3.Text : "";
				string c3 = cmb_criterio3.SelectedIndex >= 0 ? cmb_criterio3.Text : "";

				if (rdb_desc_porc.Checked)
				{
					txt_observacion.Text = $"{txt_descuento.Text}% descuento en la {p2} {c2} de la {p1} {c1}, {p3} {c3} referencias seleccionadas".Trim(',').ToUpper();
				}
				if (rdb_desc_valor.Checked)
				{
					txt_observacion.Text = $"{txt_descuento.Text} descuento en la {p2} {c2} de la {p1} {c1}, {p3} {c3} referencias seleccionadas".Trim(',').ToUpper();
				}
			}
		}
		private void ListarIemsPlanCriterio(string plan1, string criterio1, string plan2, string criterio2, string plan3, string criterio3)
		{
			DescuentoDirecto descuento = new DescuentoDirecto();
			clb_items.DataSource = descuento.ListarItemsPlanCriterio(plan1, criterio1, plan2, criterio2, plan3, criterio3);
			clb_items.DisplayMember = "f120_descripcion";
			clb_items.ValueMember = "f120_id";
		}

		private void LimpiarDescuento()
		{
			txt_consecutivo.Text = string.Empty;
			chk_tipo_com.Checked = false;
			for (int i = 0; i < clb_tipo_comunicacion.Items.Count; i++)
			{
				clb_tipo_comunicacion.SetItemChecked(i, false);
			}
			chk_tipo_exh.Checked = false;
			for (int i = 0; i < clb_tipo_exhibicion.Items.Count; i++)
			{
				clb_tipo_exhibicion.SetItemChecked(i, false);
			}
			cmb_modo_cobro.SelectedIndex = -1;
		}

		private void ListarTiposDinamica()
		{
			TipoDinamica tipo_dinamica = new TipoDinamica();
			Task<DataTable> task = Task.Run(() => tipo_dinamica.ListarTiposDinamica(true));
			task.Wait();
			cmb_dinamicas.DataSource = task.Result;
			cmb_dinamicas.ValueMember = "f08_id";
			cmb_dinamicas.DisplayMember = "f08_descripcion";
			cmb_dinamicas.SelectedIndex = -1;
		}

		private void LimpiarDetalle()
		{
			txt_item.Text = string.Empty;
			txt_ref.Text = string.Empty;
			txt_descripcion.Text = string.Empty;
			txt_marca.Text = string.Empty;
			txt_um.Text = string.Empty;
			txt_precio.Text = string.Empty;
			txt_pum.Text = string.Empty;
			txt_existencia.Text = string.Empty;
			txt_descuento.Text = string.Empty;
			txt_porc_prov.Text = string.Empty;
			txt_porc_mega.Text = string.Empty;
			cmb_cluster.SelectedIndex = -1;
			cmb_co.SelectedIndex = -1;
		}

		private void ListarPlanes()
		{
			DescuentoDirecto descuento = new DescuentoDirecto();
			Task<DataTable> task = Task.Run(() => descuento.ListarPlanes());
			task.Wait();
			dt_plan1 = task.Result;
			DataRow dr = dt_plan1.NewRow();
			dr[0] = -1;
			dr[1] = "";
			dt_plan1.Rows.InsertAt(dr, 0);
			cmb_plan.DataSource = dt_plan1;
			cmb_plan.DisplayMember = "f105_descripcion";
			cmb_plan.ValueMember = "f105_id";
			cmb_plan.SelectedIndex = -1;
			cmb_plan.SelectedIndexChanged += Cmb_plan_SelectedIndexChanged;
		}

		private void Cmb_plan_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				chk_items.Checked = false;
				ListarCriterios(Convert.ToString(cmb_plan.SelectedValue));

				string plan1 = Convert.ToString(cmb_plan.SelectedValue);
				string criterio1 = Convert.ToString(cmb_criterio.SelectedValue);
				string plan2 = Convert.ToString(cmb_plan2.SelectedValue);
				string criterio2 = Convert.ToString(cmb_criterio2.SelectedValue);
				string plan3 = Convert.ToString(cmb_plan3.SelectedValue);
				string criterio3 = Convert.ToString(cmb_criterio3.SelectedValue);
				ListarIemsPlanCriterio(plan1, criterio1, plan2, criterio2, plan3, criterio3);

				CrearObservacion();
				chk_items.Checked = true;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void ListarPlanes2()
		{
			DescuentoDirecto descuento = new DescuentoDirecto();
			Task<DataTable> task = Task.Run(() => descuento.ListarPlanes());
			task.Wait();
			dt_plan2 = task.Result;
			DataRow dr = dt_plan2.NewRow();
			dr[0] = -1;
			dr[1] = "";
			dt_plan2.Rows.InsertAt(dr, 0);
			cmb_plan2.DataSource = dt_plan2;
			cmb_plan2.DisplayMember = "f105_descripcion";
			cmb_plan2.ValueMember = "f105_id";
			cmb_plan2.SelectedIndex = -1;
			cmb_plan2.SelectedIndexChanged += Cmb_plan2_SelectedIndexChanged;
		}

		private void Cmb_plan2_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				chk_items.Checked = false;
				ListarCriterios2(Convert.ToString(cmb_plan2.SelectedValue));

				string plan1 = Convert.ToString(cmb_plan.SelectedValue);
				string criterio1 = Convert.ToString(cmb_criterio.SelectedValue);
				string plan2 = Convert.ToString(cmb_plan2.SelectedValue);
				string criterio2 = Convert.ToString(cmb_criterio2.SelectedValue);
				string plan3 = Convert.ToString(cmb_plan3.SelectedValue);
				string criterio3 = Convert.ToString(cmb_criterio3.SelectedValue);
				ListarIemsPlanCriterio(plan1, criterio1, plan2, criterio2, plan3, criterio3);

				CrearObservacion();
				chk_items.Checked = true;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void ListarPlanes3()
		{
			DescuentoDirecto descuento = new DescuentoDirecto();
			Task<DataTable> task = Task.Run(() => descuento.ListarPlanes());
			task.Wait();
			dt_plan3 = task.Result;
			DataRow dr = dt_plan3.NewRow();
			dr[0] = -1;
			dr[1] = "";
			dt_plan3.Rows.InsertAt(dr, 0);
			cmb_plan3.DataSource = dt_plan3;
			cmb_plan3.DisplayMember = "f105_descripcion";
			cmb_plan3.ValueMember = "f105_id";
			cmb_plan3.SelectedIndex = -1;
			cmb_plan3.SelectedIndexChanged += Cmb_plan3_SelectedIndexChanged;
		}

		private void Cmb_plan3_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				chk_items.Checked = false;
				ListarCriterios3(Convert.ToString(cmb_plan3.SelectedValue));

				string plan1 = Convert.ToString(cmb_plan.SelectedValue);
				string criterio1 = Convert.ToString(cmb_criterio.SelectedValue);
				string plan2 = Convert.ToString(cmb_plan2.SelectedValue);
				string criterio2 = Convert.ToString(cmb_criterio2.SelectedValue);
				string plan3 = Convert.ToString(cmb_plan3.SelectedValue);
				string criterio3 = Convert.ToString(cmb_criterio3.SelectedValue);
				ListarIemsPlanCriterio(plan1, criterio1, plan2, criterio2, plan3, criterio3);

				CrearObservacion();
				chk_items.Checked = true;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void ListarCriterios(string id_plan)
		{
			cmb_criterio.SelectedIndexChanged -= Cmb_criterio_SelectedIndexChanged;
			DescuentoDirecto descuento = new DescuentoDirecto();
			Task<DataTable> task = Task.Run(() => descuento.ListarCriterios(id_plan));
			task.Wait();
			dt_criterio1 = task.Result;
			cmb_criterio.DataSource = null;
			if (dt_criterio1 != null)
			{
				DataRow dr = dt_criterio1.NewRow();
				dr[0] = -1;
				dr[1] = "";
				dt_criterio1.Rows.InsertAt(dr, 0);
				cmb_criterio.DataSource = dt_criterio1;
				cmb_criterio.DisplayMember = "f106_descripcion";
				cmb_criterio.ValueMember = "f106_id";
				cmb_criterio.SelectedIndex = -1;
			}
			cmb_criterio.SelectedIndexChanged += Cmb_criterio_SelectedIndexChanged;
		}

		private void Cmb_criterio_SelectedIndexChanged(object sender, EventArgs e)
		{
			chk_items.Checked = false;
			string plan1 = Convert.ToString(cmb_plan.SelectedValue);
			string criterio1 = Convert.ToString(cmb_criterio.SelectedValue);
			string plan2 = Convert.ToString(cmb_plan2.SelectedValue);
			string criterio2 = Convert.ToString(cmb_criterio2.SelectedValue);
			string plan3 = Convert.ToString(cmb_plan3.SelectedValue);
			string criterio3 = Convert.ToString(cmb_criterio3.SelectedValue);
			ListarIemsPlanCriterio(plan1, criterio1, plan2, criterio2, plan3, criterio3);

			CrearObservacion();
			chk_items.Checked = true;
		}

		private void ListarCriterios2(string id_plan)
		{

			cmb_criterio2.SelectedIndexChanged -= Cmb_criterio2_SelectedIndexChanged;
			DescuentoDirecto descuento = new DescuentoDirecto();
			Task<DataTable> task = Task.Run(() => descuento.ListarCriterios(id_plan));
			task.Wait();
			dt_criterio2 = task.Result;
			cmb_criterio2.DataSource = null;
			if (dt_criterio2 != null)
			{
				DataRow dr = dt_criterio2.NewRow();
				dr[0] = -1;
				dr[1] = "";
				dt_criterio2.Rows.InsertAt(dr, 0);
				cmb_criterio2.DataSource = dt_criterio2;
				cmb_criterio2.DisplayMember = "f106_descripcion";
				cmb_criterio2.ValueMember = "f106_id";
				cmb_criterio2.SelectedIndex = -1;
			}
			cmb_criterio2.SelectedIndexChanged += Cmb_criterio2_SelectedIndexChanged;
		}

		private void Cmb_criterio2_SelectedIndexChanged(object sender, EventArgs e)
		{
			chk_items.Checked = false;
			string plan1 = Convert.ToString(cmb_plan.SelectedValue);
			string criterio1 = Convert.ToString(cmb_criterio.SelectedValue);
			string plan2 = Convert.ToString(cmb_plan2.SelectedValue);
			string criterio2 = Convert.ToString(cmb_criterio2.SelectedValue);
			string plan3 = Convert.ToString(cmb_plan3.SelectedValue);
			string criterio3 = Convert.ToString(cmb_criterio3.SelectedValue);
			ListarIemsPlanCriterio(plan1, criterio1, plan2, criterio2, plan3, criterio3);
			CrearObservacion();
			chk_items.Checked = true;
		}

		private void ListarCriterios3(string id_plan)
		{
			cmb_criterio3.SelectedIndexChanged -= Cmb_criterio3_SelectedIndexChanged;
			DescuentoDirecto descuento = new DescuentoDirecto();
			Task<DataTable> task = Task.Run(() => descuento.ListarCriterios(id_plan));
			task.Wait();
			dt_criterio3 = task.Result;
			cmb_criterio3.DataSource = null;
			if (dt_criterio3 != null)
			{
				DataRow dr = dt_criterio3.NewRow();
				dr[0] = -1;
				dr[1] = "";
				dt_criterio3.Rows.InsertAt(dr, 0);
				cmb_criterio3.DataSource = dt_criterio3;
				cmb_criterio3.DisplayMember = "f106_descripcion";
				cmb_criterio3.ValueMember = "f106_id";
				cmb_criterio3.SelectedIndex = -1;
			}
			cmb_criterio3.SelectedIndexChanged += Cmb_criterio3_SelectedIndexChanged;
		}

		private void Cmb_criterio3_SelectedIndexChanged(object sender, EventArgs e)
		{
			chk_items.Checked = false;
			string plan1 = Convert.ToString(cmb_plan.SelectedValue);
			string criterio1 = Convert.ToString(cmb_criterio.SelectedValue);
			string plan2 = Convert.ToString(cmb_plan2.SelectedValue);
			string criterio2 = Convert.ToString(cmb_criterio2.SelectedValue);
			string plan3 = Convert.ToString(cmb_plan3.SelectedValue);
			string criterio3 = Convert.ToString(cmb_criterio3.SelectedValue);
			ListarIemsPlanCriterio(plan1, criterio1, plan2, criterio2, plan3, criterio3);
			CrearObservacion();
			chk_items.Checked = true;
		}

		private void ListarProveedores()
		{
			cmb_proveedores.DisplayMember = "f200_razon_social";
			cmb_proveedores.ValueMember = "f200_nit";

			cmb_proveedores2.DisplayMember = "f200_razon_social";
			cmb_proveedores2.ValueMember = "f200_nit";

			DescuentoDirecto descuento_directo = new DescuentoDirecto();
			dtProveedores1 = descuento_directo.ListarProveedores();
			dtProveedores2 = descuento_directo.ListarProveedores();

			cmb_proveedores.DataSource = dtProveedores1;
			cmb_proveedores.SelectedIndex = -1;

			cmb_proveedores2.DataSource = dtProveedores2;
			cmb_proveedores2.SelectedIndex = -1;
		}

		private string CrearMensajeResponsable(string tipo_comunicacion)
		{
			string message = $@"<html>
                                <title>Nueva Dinámica Comercial {Usuarios.Nombre}</title>
                                <head>";
			message += @"<style>
                                        table {font - family: arial, sans-serif;
                                            border-collapse: collapse;
                                            width: 100%;
                                            font-size: 10px;
                                        }

                                        td, th {border: 1px solid #dddddd;
                                            text-align: left;
                                            padding: 8px;
                                        }

                                        tr:nth-child(even) {background - color: #dddddd;
                                        }
                                    </style>
                                </head>
                            <body>";
			message += $@"<p>Cordial saludo a Todos</p>
                            <p>Sr(a): responsable <b>{tipo_comunicacion}</b>, Se le informa que se ha cargado los descuentos promocionales asociados con:</p>";
			if (!txt_consecutivo_retro.Text.Equals(""))
			{
				message += $@"<div>
                                <h3 style=margin-bottom:0px>Retroplanning:</h3>
                                <p style=font-size:15px;margin-top:0px;margin-bottom:0px>{txt_consecutivo_retro.Text.PadLeft(4, '0')} - {nombre_dinamica}</p>
                                <p style=margin-top:0px>Vigencia: Desde {dtp_fecha_ini_desc.MinDate.ToShortDateString()} Hasta  {dtp_fecha_fin_desc.MaxDate.ToShortDateString()}</p>
                            </div>";
			}
			message += $@"
                            <div>
                                <h3 style=margin-bottom:0px>Tipo de Dinámica:</h3>
                                <p style=font-size:15px;margin-top:0px>{cmb_dinamicas.Text}</p>
                            </div>

                            <div>
                                <h3 style=margin-bottom:0px>Consecutivo de Descuento:</h3>
                                <p style=font-size:15px;margin-top:0px>{txt_consecutivo.Text}</p>
                            </div>
                            
                            <div>
                                 <h3 style=margin-bottom:0px>Negociador:</h3>
                                 <p style=font-size:15px;margin-top:0px>{Usuarios.Nombre}</p>
                            </div>
                            <p>Por favor, consultar el respectivo reporte en el aplicativo <i>Plan de Acción Comercial(PAC)</i> con el <b>Consecutivo de Descuento</b> dado.</p>
                        </body>
                        <html>";

			return message;
		}

		private string CrearMensajeAbastecimiento()
		{
			string message = $@"<html>
                                <title>Nueva Dinámica Comercial</title>
                                <head>";
			message += @"<style>
                                        table {font - family: arial, sans-serif;
                                            border-collapse: collapse;
                                            width: 100%;
                                            font-size: 10px;
                                        }

                                        td, th {border: 1px solid #dddddd;
                                            text-align: left;
                                            padding: 8px;
                                        }

                                        tr:nth-child(even) {background - color: #dddddd;
                                        }
                                    </style>
                                </head>
                            <body>";
			message += $@"<p>Cordial saludo a Todos</p>
                            <p>Se le informa que se ha cargado los descuentos promocionales asociados con:</p>";
			if (!txt_consecutivo_retro.Text.Equals(""))
			{
				message += $@"<div>
                                <h3 style=margin-bottom:0px>Retroplanning:</h3>
                                <p style=font-size:15px;margin-top:0px;margin-bottom:0px>{txt_consecutivo_retro.Text.PadLeft(4, '0')} - {nombre_dinamica}</p>
                                <p style=margin-top:0px>Vigencia: Desde {dtp_fecha_ini_desc.MinDate.ToShortDateString()} Hasta  {dtp_fecha_fin_desc.MaxDate.ToShortDateString()}</p>
                            </div>";
			}
			message += $@"
                            <div>
                                <h3 style=margin-bottom:0px>Tipo de dinámica:</h3>
                                <p style=font-size:15px;margin-top:0px>{cmb_dinamicas.Text}</p>
                            </div>

                            <div>
                                <h3 style=margin-bottom:0px>Consecutivo de Descuento:</h3>
                                <p style=font-size:15px;margin-top:0px>{txt_consecutivo.Text}</p>
                            </div>
                            
                            <div>
                                 <h3 style=margin-bottom:0px>Negociador:</h3>
                                 <p style=font-size:15px;margin-top:0px>{Usuarios.Nombre}</p>
                            </div>
                            <p>Se copia correo al área de abastecimiento.   
                                Por favor, desde el área de aprovisionamiento se solicita su colaboración reforzando los inventarios.
                                Según parámetros   para   que   se  pueda llevar a cabo las dinámicas y las apropiadas exhibiciones.</p>
                            <p>Por favor, consultar el respectivo reporte en el aplicativo <i>Plan de Acción Comercial(PAC)</i> con el <b>Consecutivo de Descuento</b> dado.</p>
                            </body>
                            </html>";
			return message;
		}

		private void ListarTiposComunicacion()
		{
			TipoComunicacion tipo_comunicacion = new TipoComunicacion();
			Task<DataTable> task = Task.Run(() => tipo_comunicacion.ListarTiposComunicacion(true));
			task.Wait();
			clb_tipo_comunicacion.DataSource = task.Result;
			clb_tipo_comunicacion.ValueMember = "f07_id";
			clb_tipo_comunicacion.DisplayMember = "f07_descripcion";
			clb_tipo_comunicacion.SelectedIndex = -1;
		}

		private void ListarTiposExhibicion()
		{
			TipoExhibicion tipo_exhibicion = new TipoExhibicion();
			Task<DataTable> task = Task.Run(() => tipo_exhibicion.ListarTiposExhibicion(true));
			task.Wait();
			clb_tipo_exhibicion.DataSource = task.Result;
			clb_tipo_exhibicion.ValueMember = "f21_id";
			clb_tipo_exhibicion.DisplayMember = "f21_descripcion";
			clb_tipo_exhibicion.SelectedIndex = -1;
		}

		private void ListarClusters()
		{
			Clusters clusters = new Clusters();
			Task<DataTable> task = Task.Run(() => clusters.ListarClusters(true));
			task.Wait();
			cmb_cluster.SelectedIndexChanged -= Cmb_cluster_SelectedIndexChanged;
			cmb_cluster.DataSource = task.Result;
			cmb_cluster.ValueMember = "f05_cod";
			cmb_cluster.DisplayMember = "f05_descripcion";
			cmb_cluster.SelectedIndex = -1;
			cmb_cluster.SelectedIndexChanged += Cmb_cluster_SelectedIndexChanged;
		}

		private void Cmb_cluster_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				if (cmb_cluster.SelectedIndex >= 0)
				{
					Cursor = Cursors.WaitCursor;
					cmb_co.SelectedIndex = -1;
					txt_precio.Text = "";
					txt_pum.Text = "";
					txt_existencia.Text = "";

					DescuentoDirecto descuento = new DescuentoDirecto();
					DataTable res = descuento.ObtenerCoCluster(cmb_cluster.SelectedValue.ToString());
					if (res != null)
					{
						cmb_co.SelectedIndexChanged -= Cmb_co_SelectedIndexChanged;
						cmb_co.DataSource = res;
						cmb_co.ValueMember = "f06_id_co";
						cmb_co.DisplayMember = "f06_desc_co";
						cmb_co.SelectedIndex = -1;
						cmb_co.SelectedIndexChanged += Cmb_co_SelectedIndexChanged;
						//cmb_co.Enabled = true;
					}
					Cursor = Cursors.Default;
				}
			}
			catch (Exception ex)
			{
				Cursor = Cursors.Default;
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void ListarCentrosOperacion()
		{
			try
			{
				CentrosOperacionListasPrecio clusters = new CentrosOperacionListasPrecio();
				Task<DataTable> task = Task.Run(() => clusters.ListarCentroListaDescuento());
				task.Wait();
				cmb_co.DataSource = task.Result;
				cmb_co.ValueMember = "f23_id_co";
				cmb_co.DisplayMember = "f23_co";
				cmb_co.SelectedIndex = -1;
				cmb_co.SelectedIndexChanged += Cmb_co_SelectedIndexChanged;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void ObtenerDatosItem(string item_ref)
		{
			try
			{
				DescuentoDirecto descuento = new DescuentoDirecto();
				string[] data = descuento.ObtenerDatosItem(item_ref);
				if (data != null)
				{
					txt_item.Text = data[0].Trim();
					txt_ref.Text = data[1].Trim();
					txt_descripcion.Text = data[2].Trim();
					txt_marca.Text = data[3].Trim();
					txt_um.Text = data[4].Trim();
					txt_casa_prov.Text = data[5].Trim();
					txt_id_casa_prov.Text = Convert.ToInt32(data[6].Trim()).ToString();
				}
				else
				{
					if (salida == false)
					{
						MessageBox.Show("El ítem no existe", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
						txt_item.Focus();
						txt_item.SelectAll();
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void Cmb_co_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				if (cmb_co.SelectedIndex >= 0)
				{
					Cursor = Cursors.WaitCursor;
					txt_precio.Text = "";
					txt_pum.Text = "";
					txt_existencia.Text = "";
					txt_factor.Text = "";

					DescuentoDirecto descuento = new DescuentoDirecto();
					List<object[]> data = descuento.ObtenerDatosItemCo(txt_item.Text.Trim(), $"{cmb_co.SelectedValue.ToString()}");
					if (data != null)
					{
						txt_precio.Text = (Math.Truncate(100 * Convert.ToDecimal(data[0][1])) / 100).ToString();
						txt_pum.Text = data[0][2].ToString();
						txt_existencia.Text = (Math.Truncate(100 * Convert.ToDecimal(data[0][3])) / 100).ToString();
						txt_factor.Text = (Math.Truncate(100 * Convert.ToDecimal(data[0][4])) / 100).ToString();
					}
					Cursor = Cursors.Default;
				}
			}
			catch (Exception ex)
			{
				Cursor = Cursors.Default;
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void FrmDescuentoDirecto_Load(object sender, EventArgs e)
		{
			Cursor = Cursors.WaitCursor;
			try
			{
				Icon = Properties.Resources.plan_24;
				this.Top = (this.Parent.ClientSize.Height - this.Height) / 2;
				this.Left = (this.Parent.ClientSize.Width - this.Width) / 2;
				txt_consecutivo.Text = ObtenerConsecutivo(2).ToString().PadLeft(4, '0');

				ListarTiposDinamica();
				ListarTiposComunicacion();
				ListarTiposExhibicion();
				ListarPlanes();
				ListarPlanes2();
				ListarPlanes3();
				ListarProveedores();
				ListarCentrosOperacion();

				min_date = dtp_fecha_ini_desc.MinDate;
				max_date = dtp_fecha_ini_desc.MaxDate;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Erorr", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			Cursor = Cursors.Default;
		}

		private void chk_tipo_com_CheckedChanged(object sender, EventArgs e)
		{
			for (int i = 0; i < clb_tipo_comunicacion.Items.Count; i++)
			{
				clb_tipo_comunicacion.SetItemChecked(i, chk_tipo_com.Checked);
			}
		}

		private void rdb_item_CheckedChanged(object sender, EventArgs e)
		{
			Cursor = Cursors.WaitCursor;
			if (rdb_item.Checked)
			{
				pnl_item.Visible = true;
				pnl_plan.Visible = false;
			}
			Cursor = Cursors.Default;
		}

		private void rdb_plan_CheckedChanged(object sender, EventArgs e)
		{
			Cursor = Cursors.WaitCursor;
			if (rdb_plan.Checked)
			{
				pnl_item.Visible = false;
				pnl_plan.Visible = true;
			}
			Cursor = Cursors.Default;
		}

		private void btn_agregar_Click(object sender, EventArgs e)
		{
			try
			{
				if (cmb_co.SelectedIndex == -1)
				{
					MessageBox.Show("Seleccione el Centro de operación", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					cmb_co.Focus();
					return;
				}

				int tipo = 0;

				string id_co = null;
				string co = null;

				id_co = cmb_co.SelectedValue.ToString();
				co = rdb_cluster.Checked == true ? cmb_co.Text : cmb_co.Text.Split('-')[1];

				decimal descuento = txt_descuento.Text == "" ? 0 : Convert.ToDecimal(txt_descuento.Text);

				char tipo_desc = ' ';
				if (rdb_desc_porc.Checked)
				{
					tipo_desc = 'P';
				}
				if (rdb_desc_valor.Checked)
				{
					tipo_desc = 'V';
				}
				if (rdb_precio_oferta.Checked)
				{
					tipo_desc = 'O';
				}

				if (tipo_desc == 'P')
				{
					if (txt_descuento.Text.Equals("") || txt_porc_prov.Text.Equals("") || txt_porc_mega.Text.Equals(""))
					{
						MessageBox.Show("Escriba los valores de descuento", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						return;
					}
					if (Convert.ToDecimal(txt_porc_prov.Text) + Convert.ToDecimal(txt_porc_mega.Text) > Convert.ToDecimal(txt_descuento.Text))
					{
						MessageBox.Show($"Los valores de porcentaje asumido por el proveedor y Megatiendas suman mas del {txt_descuento.Text}%", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						return;
					}
					if (Convert.ToDecimal(txt_porc_prov.Text) + Convert.ToDecimal(txt_porc_mega.Text) < Convert.ToDecimal(txt_descuento.Text))
					{
						MessageBox.Show($"Los valores de porcentaje asumido por el proveedor y Megatiendas suman menos del {txt_descuento.Text}%", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						return;
					}
				}

				if (tipo_desc == 'V')
				{
					if (txt_descuento.Text.Equals("") || txt_porc_prov.Text.Equals("") || txt_porc_mega.Text.Equals(""))
					{
						MessageBox.Show("Escriba los valores de descuento", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						return;
					}
					if (Convert.ToDecimal(txt_porc_prov.Text) + Convert.ToDecimal(txt_porc_mega.Text) > Convert.ToDecimal(txt_descuento.Text))
					{
						MessageBox.Show($"Los valores asumido por el proveedor y Megatiendas suman mas de {txt_descuento.Text}", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						return;
					}
					if (Convert.ToDecimal(txt_porc_prov.Text) + Convert.ToDecimal(txt_porc_mega.Text) < Convert.ToDecimal(txt_descuento.Text))
					{
						MessageBox.Show($"Los valores asumido por el proveedor y Megatiendas suman menos de {txt_descuento.Text}", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						return;
					}
				}

				if (tipo_desc == 'O')
				{
					if (txt_precio_oferta.Text.Equals(""))
					{
						MessageBox.Show("Escriba el Precio oferta", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						txt_precio_oferta.Focus();
						return;
					}
				}

				if (cmb_modo_cobro.SelectedIndex == -1)
				{
					MessageBox.Show("Seleccione el Modo de cobro", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					cmb_modo_cobro.Focus();
					return;
				}

				if (dtp_fecha_fin_desc.Value.Date < dtp_fecha_ini_desc.Value.Date)
				{
					MessageBox.Show("la fecha final del descuento debe ser mayor o igual a la fecha inicial", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					return;
				}

				if (rdb_item.Checked)
				{
					if (cmb_proveedores.SelectedIndex == -1)
					{
						MessageBox.Show("Seleccione el proveedor", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						cmb_proveedores.Focus();
						return;
					}

					if (txt_descripcion.Text.Equals(""))
					{
						MessageBox.Show("Busque la información del ítem", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						return;
					}

					Cursor = Cursors.WaitCursor;
					tipo = 1;
					string item = null;
					string referencia = null;

					item = txt_item.Text;
					referencia = txt_ref.Text;

					decimal precio = txt_precio.Text.Equals("") ? 0 : Convert.ToDecimal(txt_precio.Text);
					decimal factor = txt_factor.Text.Equals("") ? 1 : Convert.ToDecimal(txt_factor.Text);
					decimal pum = txt_pum.Text.Equals("") ? 1 : Convert.ToDecimal(txt_pum.Text);
					decimal existencia = txt_existencia.Text.Equals("") ? 1 : Convert.ToDecimal(txt_existencia.Text);

					decimal precio_fin = 0;
					decimal pum2 = 0;

					if (tipo_desc == 'P')
						//precio_fin = precio - ((precio * descuento) / 100);
						precio_fin = precio * (1 - descuento / 100);
					if (tipo_desc == 'V')
						precio_fin = precio - descuento;
					if (tipo_desc == 'O')
						precio_fin = Convert.ToDecimal(txt_precio_oferta.Text);

					pum2 = precio_fin / factor;

					bool existe = false;
					for (int i = 0; i < dgv_descuentos.RowCount; i++)
					{
						if (Convert.ToString(dgv_descuentos.Rows[i].Cells["col_item"].Value) == item &&
							dtp_fecha_ini_desc.Value.Date == Convert.ToDateTime(dgv_descuentos.Rows[i].Cells["col_fecha_ini"].Value).Date &&
							id_co == Convert.ToString(dgv_descuentos.Rows[i].Cells["col_id_co"].Value))
						{
							existe = true;
							break;
						}
					}
					if (existe == false)
					{
						Clusters clusters = new Clusters();
						string reg_cluster = rdb_cluster.Checked ? cmb_cluster.Text : clusters.ObtenerClusterCentrosOperacion(id_co);
						int ind_reg_cluster = rdb_cluster.Checked ? 1 : 0;
						string cod_cluster = rdb_cluster.Checked ? Convert.ToString(cmb_cluster.SelectedValue) : "";
						dgv_descuentos.Rows.Add(tipo, item, referencia, txt_descripcion.Text, Convert.ToString(cmb_proveedores.SelectedValue), cmb_proveedores.Text,
												txt_id_casa_prov.Text.Trim().PadLeft(4, '0'), txt_casa_prov.Text.Trim(), txt_marca.Text, txt_um.Text, precio,
												factor, pum, existencia, null, null, null, null, null, null, null, null, null, null, null, null,
												tipo_desc, txt_descuento.Text, txt_porc_prov.Text, txt_porc_mega.Text, precio_fin, pum2, dtp_fecha_ini_desc.Value.Date.ToString("yyyy-MM-dd"), dtp_fecha_fin_desc.Value.Date.ToString("yyyy-MM-dd"), cmb_modo_cobro.Text,
												 id_co, co, reg_cluster, ind_reg_cluster, cod_cluster, txt_observacion.Text.Trim());
						if (precio == 0)
						{
							dgv_descuentos.Rows[dgv_descuentos.Rows.Count - 1].DefaultCellStyle.ForeColor = Color.Red;
							dgv_descuentos.Rows[dgv_descuentos.Rows.Count - 1].DefaultCellStyle.SelectionForeColor = Color.Red;
						}
					}
					Cursor = Cursors.Default;
				}

				if (rdb_plan.Checked)
				{
					if (cmb_proveedores2.SelectedIndex == -1)
					{
						MessageBox.Show("Seleccione el proveedor", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						cmb_proveedores2.Focus();
						return;
					}

					if (cmb_plan.SelectedIndex == -1 || cmb_criterio.SelectedIndex == -1)
					{
						MessageBox.Show("Seleccione el Plan y el Criterio", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						return;
					}

					if (clb_items.CheckedItems.Count == 0)
					{
						MessageBox.Show("Seleccione los ítems", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						clb_items.Focus();
						return;
					}
					Cursor = Cursors.WaitCursor;
					tipo = 2;

					string id_plan = cmb_plan.SelectedValue.ToString();
					string plan = cmb_plan.Text;
					string id_criterio = cmb_criterio.SelectedValue.ToString();
					string criterio = cmb_criterio.Text;

					string id_plan2 = cmb_plan2.SelectedIndex >= 0 ? cmb_plan2.SelectedValue.ToString() : null;
					string plan2 = cmb_plan2.SelectedIndex >= 0 ? cmb_plan2.Text : null;
					string id_criterio2 = cmb_criterio2.SelectedIndex >= 0 ? cmb_criterio2.SelectedValue.ToString() : null;
					string criterio2 = cmb_criterio2.SelectedIndex >= 0 ? cmb_criterio2.Text : null;

					string id_plan3 = cmb_plan3.SelectedIndex >= 0 ? cmb_plan3.SelectedValue.ToString() : null;
					string plan3 = cmb_plan3.SelectedIndex >= 0 ? cmb_plan3.Text : null;
					string id_criterio3 = cmb_criterio3.SelectedIndex >= 0 ? cmb_criterio3.SelectedValue.ToString() : null;
					string criterio3 = cmb_criterio3.SelectedIndex >= 0 ? cmb_criterio3.Text : null;

					DescuentoDirecto descuento_directo = new DescuentoDirecto();

					foreach (DataRowView item in clb_items.CheckedItems)
					{
						bool existe = false;
						for (int j = 0; j < dgv_descuentos.RowCount; j++)
						{
							string it = Convert.ToString(item[0]).Trim();
							if (Convert.ToString(dgv_descuentos.Rows[j].Cells["col_id_plan"].Value).Trim() == id_plan &&
								Convert.ToString(dgv_descuentos.Rows[j].Cells["col_id_criterio"].Value).Trim() == id_criterio &&

								Convert.ToString(dgv_descuentos.Rows[j].Cells["col_id_plan2"].Value).Trim() == (id_plan2 == null ? "" : id_plan2) &&
								Convert.ToString(dgv_descuentos.Rows[j].Cells["col_id_criterio2"].Value).Trim() == (id_criterio2 == null ? "" : id_criterio2) &&

								Convert.ToString(dgv_descuentos.Rows[j].Cells["col_id_plan3"].Value).Trim() == (id_plan3 == null ? "" : id_plan3) &&
								Convert.ToString(dgv_descuentos.Rows[j].Cells["col_id_criterio3"].Value).Trim() == (id_criterio3 == null ? "" : id_criterio3) &&

								dtp_fecha_ini_desc.Value.Date == Convert.ToDateTime(dgv_descuentos.Rows[j].Cells["col_fecha_ini"].Value).Date &&
								id_co == Convert.ToString(dgv_descuentos.Rows[j].Cells["col_id_co"].Value) &&
								it == Convert.ToString(dgv_descuentos.Rows[j].Cells["col_item"].Value).Trim())
							{
								existe = true;
								break;
							}
						}
						if (existe == false)
						{
							string[] datos_item = descuento_directo.ObtenerDatosItem(item[0].ToString());
							if (datos_item != null)
							{
								List<object[]> datos_item_co = descuento_directo.ObtenerDatosItemCo(item[0].ToString(), cmb_co.SelectedValue.ToString());
								if (datos_item_co != null)
								{
									decimal precio_plan = Convert.ToDecimal(datos_item_co[0][1]);
									decimal factor_plan = Convert.ToDecimal(datos_item_co[0][4]);
									decimal pum = Convert.ToDecimal(datos_item_co[0][2]);
									decimal existencia = Convert.ToDecimal(datos_item_co[0][3]);

									decimal precio_fin_plan = 0;
									decimal pum2_plan = 0;

									if (tipo_desc == 'P')
										//precio_fin_plan = precio_plan - ((precio_plan * descuento) / 100);
										precio_fin_plan = precio_plan - ((precio_plan * descuento) / 100);
									if (tipo_desc == 'V')
										precio_fin_plan = precio_plan - descuento;
									if (tipo_desc == 'O')
										precio_fin_plan = Convert.ToDecimal(txt_precio_oferta.Text);

									pum2_plan = precio_fin_plan / factor_plan;

									Clusters clusters = new Clusters();
									int ind_reg_cluster = rdb_cluster.Checked ? 1 : 0;
									string reg_cluster = rdb_cluster.Checked ? cmb_cluster.Text : clusters.ObtenerClusterCentrosOperacion(id_co);
									string cod_cluster = rdb_cluster.Checked ? Convert.ToString(cmb_cluster.SelectedValue) : "";

									dgv_descuentos.Rows.Add(tipo, datos_item[0], datos_item[1], datos_item[2], Convert.ToString(cmb_proveedores2.SelectedValue), cmb_proveedores2.Text, datos_item[6], datos_item[5], datos_item[3], datos_item[4], precio_plan, factor_plan,
														pum, existencia, id_plan, plan, id_criterio, criterio, id_plan2, plan2, id_criterio2, criterio2, id_plan3, plan3, id_criterio3, criterio3, tipo_desc, txt_descuento.Text, txt_porc_prov.Text,
														txt_porc_mega.Text, precio_fin_plan, pum2_plan, dtp_fecha_ini_desc.Value.Date.ToString("yyyy-MM-dd"), dtp_fecha_fin_desc.Value.Date.ToString("yyyy-MM-dd"), cmb_modo_cobro.Text,
														 id_co, co, reg_cluster, ind_reg_cluster, cod_cluster, txt_observacion.Text.Trim());
									if (precio_plan == 0)
									{
										dgv_descuentos.Rows[dgv_descuentos.Rows.Count - 1].DefaultCellStyle.ForeColor = Color.Red;
										dgv_descuentos.Rows[dgv_descuentos.Rows.Count - 1].DefaultCellStyle.SelectionForeColor = Color.Red;
									}
								}
							}
						}
					}
					Cursor = Cursors.Default;
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				Cursor = Cursors.Default;
			}
			Cursor = Cursors.Default;
			MessageBox.Show("Listo", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void btnCerrar_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void btn_guardar_Click(object sender, EventArgs e)
		{
			if (cmb_dinamicas.SelectedIndex == -1 /*|| clb_tipo_comunicacion.CheckedItems.Count == 0 || clb_tipo_exhibicion.CheckedItems.Count == 0*/)
			{
				MessageBox.Show("Seleccione el Tipo de dinámica", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}

			if (dgv_descuentos.Rows.Count == 0)
			{
				MessageBox.Show("No hay información para guardar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			Cursor = Cursors.WaitCursor;

			try
			{
				DescuentoDirecto descuento_directo = new DescuentoDirecto();
				DescuentoDirecto.Descuento descuento = new DescuentoDirecto.Descuento();
				List<DescuentoDirecto.Descuento.Detalle> detalles = new List<DescuentoDirecto.Descuento.Detalle>();

				txt_consecutivo.Text = ObtenerConsecutivo(2).ToString().PadLeft(4, '0');

				descuento.Consecutivo = Convert.ToInt32(txt_consecutivo.Text);
				descuento.ConsecutivoRetroplanning = txt_consecutivo_retro.Text == "" ? -1 : Convert.ToInt32(txt_consecutivo_retro.Text);
				descuento.TipoDinamica = Convert.ToInt32(cmb_dinamicas.SelectedValue);
				descuento.Estado = 0;

				List<int> tipos_com = null;
				if (clb_tipo_comunicacion.CheckedItems.Count > 0)
				{
					tipos_com = new List<int>();
					foreach (DataRowView item in clb_tipo_comunicacion.CheckedItems)
					{
						tipos_com.Add((int)item[0]);
					}
				}
				descuento.TipoComunicacion = tipos_com;

				List<int> tipos_exh = null;
				if (clb_tipo_exhibicion.CheckedItems.Count > 0)
				{
					tipos_exh = new List<int>();
					foreach (DataRowView item in clb_tipo_exhibicion.CheckedItems)
					{
						tipos_exh.Add((int)item[0]);
					}
				}
				descuento.TipoExhibicion = tipos_exh;

				foreach (DataGridViewRow item in dgv_descuentos.Rows)
				{
					DescuentoDirecto.Descuento.Detalle detalle = new DescuentoDirecto.Descuento.Detalle();
					detalle.Tipo = Convert.ToInt32(item.Cells["col_tipo"].Value);
					detalle.Item = Convert.ToString(item.Cells["col_item"].Value);
					detalle.Referencia = Convert.ToString(item.Cells["col_ref"].Value);
					detalle.Descripcion = Convert.ToString(item.Cells["col_desc"].Value);
					detalle.Nit = Convert.ToString(item.Cells["col_nit"].Value);
					detalle.Proveedor = Convert.ToString(item.Cells["col_proveedor"].Value);
					detalle.IdCasaProveedor = Convert.ToString(item.Cells["col_id_casa_prov"].Value);
					detalle.CasaProveedor = Convert.ToString(item.Cells["col_casa_prov"].Value);
					detalle.MarcaItem = Convert.ToString(item.Cells["col_marca_item"].Value);
					detalle.UndMedida = Convert.ToString(item.Cells["col_um"].Value);
					decimal.TryParse(Convert.ToString(item.Cells["col_precio"].Value), out decimal precio);
					detalle.PrecioInicial = precio;
					decimal.TryParse(Convert.ToString(item.Cells["col_factor"].Value), out decimal factor);
					detalle.Factor = factor;
					decimal.TryParse(Convert.ToString(item.Cells["col_pum"].Value), out decimal pum);
					detalle.PumInicial = pum;
					decimal.TryParse(Convert.ToString(item.Cells["col_existencia"].Value), out decimal existencia);
					detalle.Existencia = existencia;
					detalle.IdPlan = Convert.ToString(item.Cells["col_id_plan"].Value);
					detalle.Plan = Convert.ToString(item.Cells["col_plan"].Value);
					detalle.IdCriterio = Convert.ToString(item.Cells["col_id_criterio"].Value);
					detalle.Criterio = Convert.ToString(item.Cells["col_criterio"].Value);
					detalle.IdPlan2 = Convert.ToString(item.Cells["col_id_plan2"].Value);
					detalle.Plan2 = Convert.ToString(item.Cells["col_plan2"].Value);
					detalle.IdCriterio2 = Convert.ToString(item.Cells["col_id_criterio2"].Value);
					detalle.Criterio2 = Convert.ToString(item.Cells["col_criterio2"].Value);
					detalle.IdPlan3 = Convert.ToString(item.Cells["col_id_plan3"].Value);
					detalle.Plan3 = Convert.ToString(item.Cells["col_plan3"].Value);
					detalle.IdCriterio3 = Convert.ToString(item.Cells["col_id_criterio3"].Value);
					detalle.Criterio3 = Convert.ToString(item.Cells["col_criterio3"].Value);
					detalle.TipoDescuento = Convert.ToString(item.Cells["col_tipo_desc"].Value);
					decimal.TryParse(Convert.ToString(item.Cells["col_descuento"].Value), out decimal dscto);
					detalle.Descuento = dscto;
					decimal.TryParse(Convert.ToString(item.Cells["col_porc_prov"].Value), out decimal asume_prov);
					detalle.AsumeProveedor = asume_prov;
					decimal.TryParse(Convert.ToString(item.Cells["col_porc_mega"].Value), out decimal asume_mega);
					detalle.AsumeMegatiendas = asume_mega;
					detalle.PrecioFinal = Convert.ToDecimal(item.Cells["col_precio_fin"].Value);
					decimal.TryParse(Convert.ToString(item.Cells["col_pum2"].Value), out decimal pum2);
					detalle.PumFinal = pum2;
					detalle.FechaInicialDescuento = Convert.ToDateTime(item.Cells["col_fecha_ini"].Value).ToString("yyyyMMdd");
					detalle.FechaFinalDescuento = Convert.ToDateTime(item.Cells["col_fecha_fin"].Value).ToString("yyyyMMdd");
					detalle.ModoCobro = Convert.ToString(item.Cells["col_mod_cobro"].Value); ;
					detalle.IdCentroOperacion = Convert.ToString(item.Cells["col_id_co"].Value);
					detalle.CentroOperacion = Convert.ToString(item.Cells["col_co"].Value);
					detalle.RegionalCluster = Convert.ToString(item.Cells["col_regional"].Value);
					detalle.IndRegionalCluster = Convert.ToInt32(item.Cells["col_ind_regional"].Value) == 1 ? true : false;
					detalle.CodCluster = Convert.ToString(item.Cells["col_cod_cluster"].Value);
					detalle.Observacion = Convert.ToString(item.Cells["col_obs"].Value);
					detalles.Add(detalle);
				}
				descuento_directo.GuardarDescuento(descuento, detalles);
				MessageBox.Show("Descuento guardado correctamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
				btn_confirmar.Enabled = true;
				btn_guardar.Enabled = false;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			Cursor = Cursors.Default;
		}

		private void txt_buscar_plan_TextChanged(object sender, EventArgs e)
		{
			Cursor.Current = Cursors.WaitCursor;
			if (dt_plan1 != null)
				try
				{
					dt_plan1.DefaultView.RowFilter = "f105_descripcion Like'%" + txt_buscar_plan.Text + "%'";
					cmb_plan.DroppedDown = true;
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			Cursor.Current = Cursors.Default;
		}

		private void txt_buscar_criterio_TextChanged(object sender, EventArgs e)
		{
			Cursor.Current = Cursors.WaitCursor;
			if (dt_criterio1 != null)
				try
				{
					dt_criterio1.DefaultView.RowFilter = "f106_descripcion Like'%" + txt_buscar_criterio.Text + "%'";
					cmb_criterio.DroppedDown = true;
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			Cursor.Current = Cursors.Default;
		}

		private void dgv_descuentos_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			if (dgv_descuentos.Columns[e.ColumnIndex].Name == "col_quitar" && e.RowIndex >= 0)
			{
				try
				{
					dgv_descuentos.Rows.RemoveAt(e.RowIndex);
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}

		private void btn_confirmar_Click(object sender, EventArgs e)
		{
			Cursor = Cursors.WaitCursor;
			try
			{
				if (MessageBox.Show("¿Confirmar ahora?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.Yes))
				{
					DescuentoDirecto descuento_directo = new DescuentoDirecto();
					TipoComunicacion tipo = new TipoComunicacion();
					Usuarios usuarios = new Usuarios();
					string[] correos_cc = usuarios.ListarCorreosCCNegociador(Usuarios.Id).Split(';');

					foreach (DataRowView item in clb_tipo_comunicacion.CheckedItems)
					{
						string[] correo = tipo.BuscarCorreoTipoComunicacion((int)item[0]).Split(';');

						if (!correo.Equals(""))
							for (int i = 0; i < correo.Length; i++)
							{
								string to = correo[i];

								string subject = $"Nueva Dinámica Comercial {Usuarios.NombreUsuario}";
								string body = CrearMensajeResponsable(Convert.ToString(item[1]));
								try
								{
									descuento_directo.EnviarCorreo(to, body, subject, null);
								}
								catch (Exception)
								{
									descuento_directo.GuardarCorreoPendiente(to, body, subject, "");
									continue;
								}
							}
					}

					//PARA NOTIFICAR A ABASTECIMIENTO.
					if (correos_cc != null)
						for (int i = 0; i < correos_cc.Length; i++)
						{
							string to = correos_cc[i];

							string subject = $"Nueva Dinámica Comercial {Usuarios.NombreUsuario}";
							string body = CrearMensajeAbastecimiento();
							try
							{
								descuento_directo.EnviarCorreo(to, body, subject, null);
							}
							catch (Exception)
							{
								descuento_directo.GuardarCorreoPendiente(to, body, subject, "");
								continue;
							}
						}

					descuento_directo.CambiarEstadoDescuento(Convert.ToInt32(txt_consecutivo.Text), 1);
					MessageBox.Show("La dinámica se confirmo correctamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				LimpiarDescuento();
				LimpiarDetalle();
				txt_consecutivo.Text = ObtenerConsecutivo(2).ToString().PadLeft(4, '0');
				dgv_descuentos.DataSource = null;
				dgv_descuentos.Rows.Clear();

				btn_confirmar.Enabled = false;
				btn_guardar.Enabled = true;
				btn_limpiar_retro.PerformClick();
				nombre_dinamica = null;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			Cursor = Cursors.Default;
		}

		private void rdb_cluster_CheckedChanged(object sender, EventArgs e)
		{
			try
			{
				if (rdb_cluster.Checked == true)
				{
					cmb_co.Enabled = false;
					cmb_co.DataSource = null;
					cmb_cluster.Enabled = true;
					btn_agregar.Enabled = false;
					ListarClusters();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void rdb_co_CheckedChanged(object sender, EventArgs e)
		{
			try
			{
				if (rdb_co.Checked == true)
				{
					cmb_cluster.Enabled = false;
					cmb_cluster.DataSource = null;
					cmb_co.Enabled = true;
					btn_agregar.Enabled = true;
					ListarCentrosOperacion();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void btn_todos_Click(object sender, EventArgs e)
		{
			try
			{
				if (rdb_cluster.Checked)
				{
					if (cmb_cluster.SelectedIndex == -1)
					{
						MessageBox.Show("Seleccione el Cluster", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						cmb_cluster.Focus();
						return;
					}
				}

				int tipo = 0;

				string item = null;
				string referencia = null;

				string id_plan = null;
				string plan = null;
				string id_criterio = null;
				string criterio = null;

				string id_plan2 = null;
				string plan2 = null;
				string id_criterio2 = null;
				string criterio2 = null;

				string id_plan3 = null;
				string plan3 = null;
				string id_criterio3 = null;
				string criterio3 = null;

				string id_co = null;
				string co = null;

				char tipo_desc = ' ';

				if (rdb_desc_porc.Checked)
				{
					tipo_desc = 'P';
				}
				if (rdb_desc_valor.Checked)
				{
					tipo_desc = 'V';
				}
				if (rdb_precio_oferta.Checked)
				{
					tipo_desc = 'O';
				}
				if (tipo_desc == 'P')
				{
					if (txt_descuento.Text.Equals("") || txt_porc_prov.Text.Equals("") || txt_porc_mega.Text.Equals(""))
					{
						MessageBox.Show("Escriba los valores de descuento", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						return;
					}
					if (Convert.ToDecimal(txt_porc_prov.Text) + Convert.ToDecimal(txt_porc_mega.Text) > Convert.ToDecimal(txt_descuento.Text))
					{
						MessageBox.Show($"Los valores de porcentaje asumido por el proveedor y Megatiendas suman mas del {txt_descuento.Text}%", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						return;
					}
					if (Convert.ToDecimal(txt_porc_prov.Text) + Convert.ToDecimal(txt_porc_mega.Text) < Convert.ToDecimal(txt_descuento.Text))
					{
						MessageBox.Show($"Los valores de porcentaje asumido por el proveedor y Megatiendas suman menos del {txt_descuento.Text}%", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						return;
					}
				}

				if (tipo_desc == 'V')
				{
					if (txt_descuento.Text.Equals("") || txt_porc_prov.Text.Equals("") || txt_porc_mega.Text.Equals(""))
					{
						MessageBox.Show("Escriba los valores de descuento", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						return;
					}
					if (Convert.ToDecimal(txt_porc_prov.Text) + Convert.ToDecimal(txt_porc_mega.Text) > Convert.ToDecimal(txt_descuento.Text))
					{
						MessageBox.Show($"Los valores asumido por el proveedor y Megatiendas suman mas de {txt_descuento.Text}", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						return;
					}
					if (Convert.ToDecimal(txt_porc_prov.Text) + Convert.ToDecimal(txt_porc_mega.Text) < Convert.ToDecimal(txt_descuento.Text))
					{
						MessageBox.Show($"Los valores asumido por el proveedor y Megatiendas suman menos de {txt_descuento.Text}", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						return;
					}
				}
				if (tipo_desc == 'O')
				{
					if (txt_precio_oferta.Text.Equals(""))
					{
						MessageBox.Show("Escriba el Precio oferta", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						txt_precio_oferta.Focus();
						return;
					}
				}

				if (cmb_modo_cobro.SelectedIndex == -1)
				{
					MessageBox.Show("Seleccione el Modo de cobro", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					cmb_modo_cobro.Focus();
					return;
				}

				if (dtp_fecha_fin_desc.Value.Date < dtp_fecha_ini_desc.Value.Date)
				{
					MessageBox.Show("la fecha final del descuento debe ser mayor o igual a la fecha inicial", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					return;
				}

				if (rdb_item.Checked)
				{
					if (cmb_proveedores.SelectedIndex == -1)
					{
						MessageBox.Show("Seleccione el proveedor", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						cmb_proveedores.Focus();
						return;
					}

					if (txt_descripcion.Text.Equals(""))
					{
						MessageBox.Show("Busque la información del ítem", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						return;
					}
					tipo = 1;

					item = txt_item.Text;
					referencia = txt_ref.Text;
				}

				if (rdb_plan.Checked)
				{
					if (cmb_proveedores2.SelectedIndex == -1)
					{
						MessageBox.Show("Seleccione el proveedor", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						cmb_proveedores2.Focus();
						return;
					}

					if (cmb_plan.SelectedIndex == -1 || cmb_criterio.SelectedIndex == -1)
					{
						MessageBox.Show("Seleccione el Plan1 y el Criterio1", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						return;
					}

					if (clb_items.CheckedItems.Count == 0)
					{
						MessageBox.Show("Seleccione los ítems", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						clb_items.Focus();
						return;
					}

					tipo = 2;

					id_plan = cmb_plan.SelectedValue.ToString().Trim();
					plan = cmb_plan.Text.Trim();
					id_criterio = cmb_criterio.SelectedValue.ToString().Trim();
					criterio = cmb_criterio.Text.Trim();

					id_plan2 = cmb_plan2.SelectedIndex >= 0 ? cmb_plan2.SelectedValue.ToString().Trim() : null;
					plan2 = cmb_plan2.SelectedIndex >= 0 ? cmb_plan2.Text.Trim() : null;
					id_criterio2 = cmb_criterio2.SelectedIndex >= 0 ? cmb_criterio2.SelectedValue.ToString().Trim() : null;
					criterio2 = cmb_criterio2.SelectedIndex >= 0 ? cmb_criterio2.Text.Trim() : null;

					id_plan3 = cmb_plan3.SelectedIndex >= 0 ? cmb_plan3.SelectedValue.ToString().Trim() : null;
					plan3 = cmb_plan3.SelectedIndex >= 0 ? cmb_plan3.Text.Trim() : null;
					id_criterio3 = cmb_criterio3.SelectedIndex >= 0 ? cmb_criterio3.SelectedValue.ToString().Trim() : null;
					criterio3 = cmb_criterio3.SelectedIndex >= 0 ? cmb_criterio3.Text.Trim() : null;
				}

				decimal descuento = txt_descuento.Text == "" ? 0 : Convert.ToDecimal(txt_descuento.Text);
				Cursor = Cursors.WaitCursor;
				for (int i = 0; i < cmb_co.Items.Count; i++)
				{
					Application.DoEvents();
					cmb_co.SelectedIndex = i;
					id_co = cmb_co.SelectedValue.ToString();
					co = rdb_cluster.Checked == true ? cmb_co.Text : cmb_co.Text.Split('-')[1];

					if (rdb_item.Checked)
					{
						bool existe = false;
						for (int j = 0; j < dgv_descuentos.RowCount; j++)
						{
							if (Convert.ToString(dgv_descuentos.Rows[j].Cells["col_item"].Value) == item &&
								dtp_fecha_ini_desc.Value.Date == Convert.ToDateTime(dgv_descuentos.Rows[j].Cells["col_fecha_ini"].Value).Date &&
								id_co == Convert.ToString(dgv_descuentos.Rows[j].Cells["col_id_co"].Value))
							{
								existe = true;
								break;
							}
						}
						if (existe == false)
						{
							decimal precio = txt_precio.Text.Equals("") ? 0 : Convert.ToDecimal(txt_precio.Text);
							decimal factor = txt_factor.Text.Equals("") ? 1 : Convert.ToDecimal(txt_factor.Text);
							decimal pum = txt_pum.Text.Equals("") ? 1 : Convert.ToDecimal(txt_pum.Text);
							decimal existencia = txt_existencia.Text.Equals("") ? 1 : Convert.ToDecimal(txt_existencia.Text);

							decimal precio_fin = 0;
							decimal pum2 = 0;

							if (tipo_desc == 'P')
							{
								//precio_fin = precio - ((precio * descuento) / 100);
								precio_fin = precio * (1 - descuento / 100);
							}
							if (tipo_desc == 'V')
							{
								precio_fin = precio - descuento;
							}
							if (tipo_desc == 'O')
							{
								precio_fin = Convert.ToDecimal(txt_precio_oferta.Text);
							}
							pum2 = precio_fin / factor;

							Clusters clusters = new Clusters();
							string reg_cluster = rdb_cluster.Checked ? cmb_cluster.Text : clusters.ObtenerClusterCentrosOperacion(id_co);
							int ind_reg_cluster = rdb_cluster.Checked ? 1 : 0;
							string cod_cluster = rdb_cluster.Checked ? Convert.ToString(cmb_cluster.SelectedValue) : "";
							dgv_descuentos.Rows.Add(tipo, item, referencia, txt_descripcion.Text, Convert.ToString(cmb_proveedores.SelectedValue), cmb_proveedores.Text,
													txt_id_casa_prov.Text.Trim().PadLeft(4, '0'), txt_casa_prov.Text.Trim(), txt_marca.Text, txt_um.Text, precio, factor,
												pum, existencia, null, null, null, null, null, null, null, null, null, null, null, null, tipo_desc, txt_descuento.Text,
												txt_porc_prov.Text, txt_porc_mega.Text, precio_fin, pum2, dtp_fecha_ini_desc.Value.Date.ToString("yyyy-MM-dd"), dtp_fecha_fin_desc.Value.Date.ToString("yyyy-MM-dd"),
												cmb_modo_cobro.Text, id_co, co, reg_cluster, ind_reg_cluster, cod_cluster, txt_observacion.Text.Trim());
							if (precio == 0)
							{
								dgv_descuentos.Rows[dgv_descuentos.Rows.Count - 1].DefaultCellStyle.ForeColor = Color.Red;
								dgv_descuentos.Rows[dgv_descuentos.Rows.Count - 1].DefaultCellStyle.SelectionForeColor = Color.Red;
							}
						}
					}

					if (rdb_plan.Checked)
					{
						DescuentoDirecto descuento_directo = new DescuentoDirecto();
						foreach (DataRowView item_plan in clb_items.CheckedItems)
						{
							bool existe = false;
							for (int j = 0; j < dgv_descuentos.RowCount; j++)
							{
								string it = Convert.ToString(item_plan[0]).Trim();
								if (Convert.ToString(dgv_descuentos.Rows[j].Cells["col_id_plan"].Value).Trim() == id_plan &&
									Convert.ToString(dgv_descuentos.Rows[j].Cells["col_id_criterio"].Value).Trim() == id_criterio &&

									Convert.ToString(dgv_descuentos.Rows[j].Cells["col_id_plan2"].Value).Trim() == (id_plan2 == null ? "" : id_plan2) &&
									Convert.ToString(dgv_descuentos.Rows[j].Cells["col_id_criterio2"].Value).Trim() == (id_criterio2 == null ? "" : id_criterio2) &&

									Convert.ToString(dgv_descuentos.Rows[j].Cells["col_id_plan3"].Value).Trim() == (id_plan3 == null ? "" : id_plan3) &&
									Convert.ToString(dgv_descuentos.Rows[j].Cells["col_id_criterio3"].Value).Trim() == (id_criterio3 == null ? "" : id_criterio3) &&

									dtp_fecha_ini_desc.Value.Date == Convert.ToDateTime(dgv_descuentos.Rows[j].Cells["col_fecha_ini"].Value).Date &&
									id_co == Convert.ToString(dgv_descuentos.Rows[j].Cells["col_id_co"].Value) &&
									it == Convert.ToString(dgv_descuentos.Rows[j].Cells["col_item"].Value).Trim())
								{
									existe = true;
									break;
								}
							}
							if (existe == false)
							{
								string[] datos_item = descuento_directo.ObtenerDatosItem(item_plan[0].ToString());

								if (datos_item != null)
								{
									List<object[]> datos_item_co = descuento_directo.ObtenerDatosItemCo(item_plan[0].ToString(), cmb_co.SelectedValue.ToString());
									if (datos_item_co != null)
									{
										decimal precio_plan = Convert.ToDecimal(datos_item_co[0][1]);
										decimal factor_plan = Convert.ToDecimal(datos_item_co[0][4]);
										decimal pum = Convert.ToDecimal(datos_item_co[0][2]);
										decimal existencia = Convert.ToDecimal(datos_item_co[0][3]);

										decimal precio_fin_plan = 0;
										decimal pum2_plan = 0;

										if (tipo_desc == 'P')
											//precio_fin_plan = precio_plan - ((precio_plan * descuento) / 100);
											precio_fin_plan = precio_plan * (1 - descuento / 100);
										if (tipo_desc == 'V')
											precio_fin_plan = precio_plan - descuento;
										if (tipo_desc == 'O')
											precio_fin_plan = Convert.ToDecimal(txt_precio_oferta.Text);

										pum2_plan = precio_fin_plan / factor_plan;

										Clusters clusters = new Clusters();
										int ind_reg_cluster = rdb_cluster.Checked ? 1 : 0;
										string reg_cluster = rdb_cluster.Checked ? cmb_cluster.Text : clusters.ObtenerClusterCentrosOperacion(id_co);
										string cod_cluster = rdb_cluster.Checked ? Convert.ToString(cmb_cluster.SelectedValue) : "";

										dgv_descuentos.Rows.Add(tipo, datos_item[0], datos_item[1], datos_item[2], Convert.ToString(cmb_proveedores2.SelectedValue), cmb_proveedores2.Text, datos_item[6], datos_item[5], datos_item[3], datos_item[4], precio_plan, factor_plan,
															pum, existencia, id_plan, plan, id_criterio, criterio, id_plan2, plan2, id_criterio2, criterio2, id_plan3, plan3, id_criterio3, criterio3, tipo_desc, txt_descuento.Text, txt_porc_prov.Text,
															txt_porc_mega.Text, precio_fin_plan, pum2_plan, dtp_fecha_ini_desc.Value.Date.ToString("yyyy-MM-dd"), dtp_fecha_fin_desc.Value.Date.ToString("yyyy-MM-dd"), cmb_modo_cobro.Text,
															 id_co, co, reg_cluster, ind_reg_cluster, cod_cluster, txt_observacion.Text.Trim());
										if (precio_plan == 0)
										{
											dgv_descuentos.Rows[dgv_descuentos.Rows.Count - 1].DefaultCellStyle.ForeColor = Color.Red;
											dgv_descuentos.Rows[dgv_descuentos.Rows.Count - 1].DefaultCellStyle.SelectionForeColor = Color.Red;
										}
									}
								}
							}
						}
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				Cursor = Cursors.Default;
			}
			Cursor = Cursors.Default;
			MessageBox.Show("Listo", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void chk_tipo_exh_CheckedChanged(object sender, EventArgs e)
		{
			for (int i = 0; i < clb_tipo_exhibicion.Items.Count; i++)
			{
				clb_tipo_exhibicion.SetItemChecked(i, chk_tipo_exh.Checked);
			}
		}

		private void txt_item_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
		{
			if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
			{
				e.IsInputKey = true;
				try
				{
					if (!txt_item.Text.Trim().Equals(""))
					{
						txt_ref.Text = "";
						txt_descripcion.Text = "";
						txt_marca.Text = "";
						txt_casa_prov.Text = "";
						txt_id_casa_prov.Text = "";
						txt_um.Text = "";
						txt_precio.Text = "";
						txt_pum.Text = "";
						txt_existencia.Text = "";
						cmb_cluster.SelectedIndex = -1;
						cmb_co.SelectedIndex = -1;

						ObtenerDatosItem(txt_item.Text);
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}

		private void cargarArchivoToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Cursor = Cursors.WaitCursor;
			try
			{
				OpenFileDialog openfile = new OpenFileDialog();
				openfile.Filter = "Excel Files |*.xlsx";
				openfile.Title = "Seleccione el archivo de Excel";
				if (openfile.ShowDialog() == DialogResult.OK)
				{
					Configuration config = ConfigurationManager.OpenExeConfiguration(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\" + System.Reflection.Assembly.GetExecutingAssembly().GetName().Name + ".exe");
					AppSettingsSection section = config.AppSettings;
					string[] regional_appconfig = section.Settings["regional"].Value.Split(',');//LISTA DE REGIONALES QUE ESTAN EN EL ARCHIVO DE CONFIGURACION.
					string[] co_appconfig = section.Settings["co"].Value.Split(',');//LISTA DE CO QUE ESTAN EN EL ARCHIVO DE CONFIGURACION.

					//if (openfile.FileName.Equals("") == false)
					//{
					List<string> novedades = new List<string>();

					XLWorkbook libro = new XLWorkbook(openfile.FileName);
					IXLWorksheet hoja_items = libro.Worksheet(1);

					IXLWorksheet hoja_cos = libro.Worksheet(2);
					IEnumerable<IXLRangeRow> rows_co = hoja_cos.RangeUsed().RowsUsed().Skip(1);//FILAS DE LA HOJA 2 DONDE ESTAN LOS CO.

					//IXLRangeRows rows = items.RangeUsed().RowsUsed();//FILAS DE LA HOJA 1 DONDE ESTAN LOS ITEMS.
					IXLRows filas_hoja_items = hoja_items.Rows();//.RangeUsed().Rows();//FILAS DE LA HOJA 1 DONDE ESTAN LOS ITEMS.

					DescuentoDirecto descuento = new DescuentoDirecto();
					string nit = Convert.ToString(hoja_items.Row(9).Cell("C").Value).Trim();

					if (rdb_item.Checked)
						cmb_proveedores.SelectedValue = nit.Trim();
					if (rdb_plan.Checked)
						cmb_proveedores2.SelectedValue = nit.Trim();

					//string razon_soc = descuento.ObtenerRazonSocial(nit);
					//if (razon_soc.Equals(string.Empty))
					//{
					//	novedades.Add($"el Nit del proveedor no existe");
					//	new FrmNovedadesCargaArchivo(novedades).ShowDialog(this);
					//	Cursor = Cursors.Default;
					//	return;
					//}

					string res = descuento.ObtenerRazonSocial(nit);
					string razon_soc = res == "" ? Convert.ToString(hoja_items.Row(8).Cell("C").Value).Trim() : res;

					int c = 0;
					foreach (var fila_hoja_items in filas_hoja_items)
					{
						c++;
						if (c <= 12)
						{
							continue;
						}

						Application.DoEvents();

						string plu = Convert.ToString(fila_hoja_items.Cell("B").Value).Trim();
						if (plu.Equals(""))
						{
							continue;
						}
						string referencia = Convert.ToString(fila_hoja_items.Cell("C").Value).Trim();
						string mod_cobro = Convert.ToString(fila_hoja_items.Cell("N").Value).Trim();
						if (!cmb_modo_cobro.Items.Contains(mod_cobro.ToUpper()))
							mod_cobro = "N/A";
						_ = decimal.TryParse(Convert.ToString(fila_hoja_items.Cell("H").Value), out decimal d1);
						_ = decimal.TryParse(Convert.ToString(fila_hoja_items.Cell("I").Value), out decimal d2);

						_ = decimal.TryParse(Convert.ToString(fila_hoja_items.Cell("J").Value), out decimal d3);
						_ = decimal.TryParse(Convert.ToString(fila_hoja_items.Cell("K").Value), out decimal d4);

						string tipo_descuento = "";
						if (d1 > 0 || d2 > 0)
						{
							tipo_descuento = "P";
						}
						if (d3 > 0 || d4 > 0)
						{
							tipo_descuento = "V";
						}

						decimal asume_prov;
						decimal asume_mega;
						decimal val_desc;

						if (tipo_descuento == "P")
						{
							asume_prov = d1;
							asume_mega = d2;
							val_desc = asume_prov + asume_mega;
						}
						else
						{
							asume_prov = d3;
							asume_mega = d4;
							val_desc = asume_prov + asume_mega;
						}
						//if (val_desc == 0)
						//{
						//	novedades.Add($"Valor de descuento ítem {plu} no valido");
						//	continue;
						//}

						if (!DateTime.TryParse(Convert.ToString(fila_hoja_items.Cell("L").Value), out DateTime fecha_ini))
						{
							novedades.Add($"Fecha inicial ítem {plu} no valida");
							continue;
						}
						else
						{
							if (fecha_ini.Date.Year < DateTime.Now.Date.Year)
							{
								novedades.Add($"Fecha inicial ítem {plu} no valida");
								continue;
							}
						}
						if (!DateTime.TryParse(Convert.ToString(fila_hoja_items.Cell("M").Value), out DateTime fecha_fin))
						{
							novedades.Add($"Fecha final ítem {plu} no valida");
							continue;
						}
						else
						{
							if (fecha_fin.Date.Year < DateTime.Now.Date.Year)
							{
								novedades.Add($"Fecha final ítem {plu} no valida");
								continue;
							}
						}
						if (fecha_fin.Date < fecha_ini.Date)
						{
							novedades.Add($"Fecha final ítem {plu} no valida");
							continue;
						}

						string obs = Convert.ToString(fila_hoja_items.Cell("O").Value);

						int tipo;
						string[] co_regional = Convert.ToString(fila_hoja_items.Cell("G").Value).ToUpper().Split(',');//TRAE EL CONTENIDO DE LA CELDA CON LOS CO Y REGIONALES ESCRITOS.

						List<string> list_regional = new List<string>();//AQUI SE GUARDAN LAS REGIONALES QUE ENCONTRO EN LA CELDA.
						for (int i = 0; i < regional_appconfig.Length; i++)
						{
							for (int j = 0; j < co_regional.Length; j++)
							{
								if (co_regional[j].ToUpper().Trim().Equals(regional_appconfig[i].Trim()))
								{
									list_regional.Add(regional_appconfig[i]);
								}
							}
						}

						List<string> list_co = new List<string>();//AQUI SE GUARDAN LOS CO QUE ENCONTRO EN LA CELDA.
						for (int i = 0; i < co_appconfig.Length; i++)
						{
							for (int j = 0; j < co_regional.Length; j++)//REVISAR
							{
								if (co_regional[j].ToUpper().Trim().Equals(co_appconfig[i].Trim()))
								{
									list_co.Add(co_appconfig[i]);
								}
							}
						}

						//POR REGIONAL
						foreach (string r in list_regional)
						{
							List<string[]> list_co_regional = new List<string[]>();
							foreach (var row_co in rows_co)
							{
								string x = Convert.ToString(row_co.Cell("A").Value).Trim();//LA REGIONAL.
								string id_co = Convert.ToString(row_co.Cell("B").Value).Trim();//EL ID DEL CO.
								string desc_co = Convert.ToString(row_co.Cell("C").Value).Trim();//LA DESCRIPCION DEL CO.
								if (x.ToUpper().Equals(r.ToUpper().Trim()))
								{
									string[] y = new string[2];
									y[0] = id_co;
									y[1] = desc_co;
									list_co_regional.Add(y);//SE TRAE EL LISTADO DE LOS CO DE LA REGIONAL.
								}
							}
							string[] data = descuento.ObtenerDatosItem(plu);
							foreach (string[] item in list_co_regional)
							{
								tipo = 1;

								if (data == null)
								{
									if (!plu.Equals(""))
									{
										novedades.Add($"El ítem {plu} no esta registrado en la base de datos unoee");
									}

									continue;
								}

								bool existe = false;
								for (int i = 0; i < dgv_descuentos.Rows.Count; i++)
								{
									if (Convert.ToString(dgv_descuentos.Rows[i].Cells["col_item"].Value) == data[0] &&
										dtp_fecha_ini_desc.Value.Date == Convert.ToDateTime(dgv_descuentos.Rows[i].Cells["col_fecha_ini"].Value).Date &&
										item[0] == Convert.ToString(dgv_descuentos.Rows[i].Cells["col_id_co"].Value))
									{
										existe = true;
										break;
									}
								}

								if (existe == false)
								{
									List<object[]> list = descuento.ObtenerDatosItemCo(data[0].Trim(), item[0]);
									if (list == null)
									{
										dgv_descuentos.Rows.Add(tipo, data[0].Trim(), data[1].Trim(), data[2], nit, razon_soc, data[6].Trim(), data[5].Trim(), data[3].Trim(), data[4].Trim(), null, null, null, null, null, null,
																null, null, null, null, null, null, null, null, null, null, tipo_descuento, val_desc, asume_prov, asume_mega, null, null, fecha_ini.ToString("yyyy-MM-dd"), fecha_fin.ToString("yyyy-MM-dd"), mod_cobro, item[0], item[1], r, 1, "", obs);
										dgv_descuentos.Rows[dgv_descuentos.Rows.Count - 1].DefaultCellStyle.ForeColor = System.Drawing.Color.Red;
									}
									else
									{
										decimal precio = Convert.ToDecimal(list[0][1]);
										decimal factor = Convert.ToDecimal(list[0][4]);

										decimal precio_fin = 0;
										decimal pum2 = 0;

										if (tipo_descuento.Equals("P"))
										{
											//precio_fin = precio - ((precio * val_desc) / 100);
											precio_fin = precio * (1 - val_desc / 100);
										}
										if (tipo_descuento.Equals("V"))
										{
											precio_fin = precio - val_desc;
										}
										pum2 = precio_fin / factor;

										dgv_descuentos.Rows.Add(tipo, data[0].Trim(), data[1].Trim(), data[2], nit, razon_soc, data[6].Trim(), data[5].Trim(), data[3].Trim(), data[4].Trim(), list[0][1], list[0][4], list[0][2], list[0][3], null, null,
																null, null, null, null, null, null, null, null, null, null, tipo_descuento, val_desc, asume_prov, asume_mega, precio_fin, pum2, fecha_ini.ToString("yyyy-MM-dd"), fecha_fin.ToString("yyyy-MM-dd"), mod_cobro, item[0], item[1], r, 1, "", obs);
									}
								}
							}
						}
						//POR CO
						foreach (string r in list_co)
						{
							List<string[]> list_co_regional = new List<string[]>();
							foreach (var row_co in rows_co)
							{
								string id_co = Convert.ToString(row_co.Cell("B").Value).Trim();//EL ID DEL CO.
								string desc_co = Convert.ToString(row_co.Cell("C").Value).Trim();//LA DESCRIPCION DEL CO.
								string regional = Convert.ToString(row_co.Cell("A").Value).Trim();//LA REGIONAL
								if (desc_co.Equals(r))
								{
									string[] y = new string[3];
									y[0] = id_co;
									y[1] = desc_co;
									y[2] = regional;
									list_co_regional.Add(y);
								}
							}

							foreach (string[] item in list_co_regional)
							{
								tipo = 1;

								string[] data = descuento.ObtenerDatosItem(plu);
								if (data == null)
								{
									if (!plu.Equals(""))
									{
										novedades.Add($"El ítem {plu.Trim()} no esta registrado en la base de datos unoee");
									}
									continue;
								}

								bool existe = false;
								for (int i = 0; i < dgv_descuentos.Rows.Count; i++)
								{
									if (Convert.ToString(dgv_descuentos.Rows[i].Cells["col_item"].Value) == data[0] &&
										dtp_fecha_ini_desc.Value.Date == Convert.ToDateTime(dgv_descuentos.Rows[i].Cells["col_fecha_ini"].Value).Date &&
										item[0] == Convert.ToString(dgv_descuentos.Rows[i].Cells["col_id_co"].Value))
									{
										existe = true;
										break;
									}
								}

								if (existe == false)
								{
									List<object[]> list = descuento.ObtenerDatosItemCo(data[0].Trim(), item[0]);
									if (list == null)
									{
										dgv_descuentos.Rows.Add(tipo, data[0].Trim(), data[1].Trim(), data[2], nit, razon_soc, data[6].Trim(), data[5].Trim(), data[3].Trim(), data[4].Trim(), null, null, null, null, null, null,
																null, null, null, null, null, null, null, null, null, null, tipo_descuento, val_desc, asume_prov, asume_mega, null, null, fecha_ini.ToString("yyyy-MM-dd"), fecha_fin.ToString("yyyy-MM-dd"), mod_cobro, item[0], item[1], item[2], 0, "", obs);
										dgv_descuentos.Rows[dgv_descuentos.Rows.Count - 1].DefaultCellStyle.ForeColor = System.Drawing.Color.Red;
									}
									else
									{
										decimal precio = Convert.ToDecimal(list[0][1]);
										decimal factor = Convert.ToDecimal(list[0][4]);

										decimal precio_fin = 0;
										decimal pum2 = 0;

										if (tipo_descuento.Equals("P"))
										{
											//precio_fin = precio - ((precio * val_desc) / 100);
											precio_fin = precio * (1 - val_desc / 100);
										}
										if (tipo_descuento.Equals("V"))
										{
											precio_fin = precio - val_desc;
										}
										pum2 = precio_fin / factor;

										dgv_descuentos.Rows.Add(tipo, data[0].Trim(), data[1].Trim(), data[2], nit, razon_soc, data[6].Trim(), data[5].Trim(), data[3].Trim(), data[4].Trim(), list[0][1], list[0][4], list[0][2], list[0][3], null, null,
																null, null, null, null, null, null, null, null, null, null, tipo_descuento, val_desc, asume_prov, asume_mega, precio_fin, pum2, fecha_ini.ToString("yyyy-MM-dd"), fecha_fin.ToString("yyyy-MM-dd"), mod_cobro, item[0], item[1], item[2], 0, "", obs);
									}
								}
							}
						}
					}
					if (novedades.Count > 0)
					{
						new FrmNovedadesCargaArchivo(novedades).ShowDialog(this);
					}
					else
					{
						MessageBox.Show("El archivo se cargo correctamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
					}
					//}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			Cursor = Cursors.Default;
		}

		private void descuento_Leave(object sender, EventArgs e)
		{
			try
			{
				TextBox txt = (TextBox)sender;
				string sep = Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator;
				if (!txt.Text.Equals(string.Empty))
				{
					txt.Text = txt.Text.Replace(".", sep).Replace(",", sep);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void btn_cargar_retro_Click(object sender, EventArgs e)
		{
			try
			{
				new FrmCargarRetroplanning(this).ShowDialog(this);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void btn_limpiar_retro_Click(object sender, EventArgs e)
		{
			txt_consecutivo_retro.Text = "";
			cmb_dinamicas.Enabled = true;
			cmb_dinamicas.SelectedIndex = -1;
			dtp_fecha_ini_desc.MinDate = min_date;
			dtp_fecha_ini_desc.MaxDate = max_date;
			dtp_fecha_fin_desc.MinDate = min_date;
			dtp_fecha_fin_desc.MaxDate = max_date;
		}

		private void btn_tamaño_Click(object sender, EventArgs e)
		{
			if (btn_tamaño.ImageIndex == 0)
			{
				btn_tamaño.ImageIndex = 1;
				_splitContainer.Panel1Collapsed = true;
				return;
			}
			else
			{
				_splitContainer.Panel1Collapsed = false;
				btn_tamaño.ImageIndex = 0;
			}
		}

		private void dgv_descuentos_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
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

		private void txt_buscar_prov_TextChanged(object sender, EventArgs e)
		{
			Cursor.Current = Cursors.Default;
			if (dtProveedores1 != null)
				try
				{
					dtProveedores1.DefaultView.RowFilter = "f200_razon_social Like'%" + txt_buscar_prov.Text + "%'";
					cmb_proveedores.DroppedDown = true;
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			Cursor.Current = Cursors.Default;
		}

		private void txt_buscar_prov2_TextChanged(object sender, EventArgs e)
		{
			Cursor.Current = Cursors.WaitCursor;
			if (dtProveedores2 != null)
				try
				{
					dtProveedores2.DefaultView.RowFilter = "f200_razon_social Like'%" + txt_buscar_prov2.Text + "%'";
					cmb_proveedores2.DroppedDown = true;
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			Cursor.Current = Cursors.Default;
		}

		private void txt_buscar_plan2_TextChanged(object sender, EventArgs e)
		{
			Cursor.Current = Cursors.WaitCursor;
			if (dt_plan2 != null)
				try
				{
					dt_plan2.DefaultView.RowFilter = "f105_descripcion Like'%" + txt_buscar_plan2.Text + "%'";
					cmb_plan2.DroppedDown = true;
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			Cursor.Current = Cursors.Default;
		}

		private void txt_buscar_criterio2_TextChanged(object sender, EventArgs e)
		{
			Cursor.Current = Cursors.WaitCursor;
			if (dt_criterio2 != null)
				try
				{
					dt_criterio2.DefaultView.RowFilter = "f106_descripcion Like'%" + txt_buscar_criterio2.Text + "%'";
					cmb_criterio2.DroppedDown = true;
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			Cursor.Current = Cursors.Default;
		}

		private void txt_descuento_TextChanged(object sender, EventArgs e)
		{
			CrearObservacion();
		}

		private void rdb_desc_CheckedChanged(object sender, EventArgs e)
		{
			CrearObservacion();
			txt_descuento.Enabled = true;
			txt_descuento.Text = "";
			txt_porc_prov.Enabled = true;
			txt_porc_prov.Text = "";
			txt_porc_mega.Enabled = true;
			txt_porc_mega.Text = "";

			txt_descuento.Focus();

			txt_precio_oferta.Enabled = false;
			txt_precio_oferta.Text = "";
			txt_precio_oferta.Focus();
		}

		private void txt_buscar_plan3_TextChanged(object sender, EventArgs e)
		{
			Cursor.Current = Cursors.WaitCursor;
			if (dt_plan3 != null)
				try
				{
					dt_plan3.DefaultView.RowFilter = "f105_descripcion Like'%" + txt_buscar_plan3.Text + "%'";
					cmb_plan3.DroppedDown = true;
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			Cursor.Current = Cursors.Default;
		}

		private void txt_buscar_criterio3_TextChanged(object sender, EventArgs e)
		{
			Cursor.Current = Cursors.WaitCursor;
			if (dt_criterio3 != null)
				try
				{
					dt_criterio3.DefaultView.RowFilter = "f106_descripcion Like'%" + txt_buscar_criterio3.Text + "%'";
					cmb_criterio3.DroppedDown = true;
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			Cursor.Current = Cursors.Default;
		}

		private void rdb_precio_oferta_CheckedChanged(object sender, EventArgs e)
		{
			txt_descuento.Enabled = false;
			txt_porc_prov.Enabled = false;
			txt_porc_mega.Enabled = false;

			txt_precio_oferta.Enabled = true;
			txt_precio_oferta.Focus();
			txt_precio_oferta.Text = "";
		}

		private void chk_items_CheckedChanged(object sender, EventArgs e)
		{
			for (int i = 0; i < clb_items.Items.Count; i++)
			{
				clb_items.SetItemChecked(i, chk_items.Checked);
			}
		}
	}
}
