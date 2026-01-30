using PlanAccionComercial.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlanAccionComercial.Forms
{
	public partial class FrmRechazarDescuento : Form
	{
		public FrmRechazarDescuento()
		{
			InitializeComponent();
		}

		private void ListarDescuentos(string fecha_ini, string fecha_fin)
		{
			Reportes reporte = new Reportes();
			dgv_descuento.AutoGenerateColumns = false;
			col_retroplanning.DataPropertyName = "f12_consecutivo";
			col_nombre_dinamica.DataPropertyName = "f12_descripcion";
			col_fecha_ini_vig.DataPropertyName = "f12_fecha_ini_vig";
			col_fecha_fin_vig.DataPropertyName = "f12_fecha_fin_vig";
			col_cosecutivo.DataPropertyName = "f17_consecutivo";
			col_dinamica.DataPropertyName = "f08_descripcion";
			col_fecha.DataPropertyName = "f17_fecha";
			col_negociador.DataPropertyName = "f04_nombre";
			col_id_usuario.DataPropertyName = "f04_id";
			dgv_descuento.DataSource = reporte.ListarDescuentoDirecto(fecha_ini, fecha_fin);
		}

		private void VerDetalle(int consecutivo)
		{
			dgv_detalle.AutoGenerateColumns = false;
			col_co.DataPropertyName = "f19_co";
			col_item.DataPropertyName = "f19_item";
			col_desc.DataPropertyName = "f19_descripcion";
			col_plan.DataPropertyName = "f19_plan";
			col_criterio.DataPropertyName = "f19_criterio";
			col_fecha_ini.DataPropertyName = "f19_fecha_ini_desc";
			col_fecha_fin.DataPropertyName = "f19_fecha_fin_desc";
			col_precio.DataPropertyName = "f19_precio";
			col_descuento.DataPropertyName = "f19_descuento";
			col_precio_fin.DataPropertyName = "precio_fin";
			col_obs.DataPropertyName = "f19_observacion";
			col_id.DataPropertyName = "f19_id";
			col_tipo_desc.DataPropertyName = "f19_tipo_descuento";

			Reportes reportes = new Reportes();
			dgv_detalle.DataSource = reportes.VerDetalleDescuento(consecutivo, true);
		}

		private string CrearMensaje(string negociador, string retroplanning, string nombre_dinamica, string fecha_ini, string fecha_fin,
									string tipo_dinamica, string descuento, List<string> rechazados, bool todo)
		{
			string message = $@"<html>
                                <title>Rechazo de descuento</title>
                                <body>      
                                   
                                    <p>Se informa que se ha rechazado un descuento.</p>";
			if (!retroplanning.Equals(""))
			{
				message += $@"<div>
                                <h3 style=margin-bottom:0px>Retroplanning:</h3>
                                <p style=font-size:15px;margin-top:0px;margin-bottom:0px>{retroplanning.PadLeft(4, '0')} - {nombre_dinamica}</p>
                                <p style=margin-top:0px>Vigencia: Desde {fecha_ini} Hasta  {fecha_fin}</p>
                            </div>";
			}
			message += $@"
                         </div>
                            <p style=margin-bottom:0px>Tipo de Dinámica:</p>
                            <h3 style=margin-top:0px>{tipo_dinamica}</h3>
                        </div>
                         <div>
                            <h3 style=margin-bottom:0px>Consecutivo de Descuento:</h3>
                            <h2 style=margin-top:0px>{descuento}</h2>
                         </div>
                        </div>
                            <p style=margin-bottom:0px>Negociador:</p>
                            <h3 style=margin-top:0px>{negociador}</h3>
                        </div>";
			if (todo == false)
			{
				foreach (string item in rechazados)
				{
					string[] rechazo = item.Split(',');
					message += $"<p>Ítem:<b>{rechazo[0]}-{rechazo[1]}</b>, en <b>{rechazo[2]}</b>.";
				}
			}

			message += @"</body>            
						</html>";

			return message;
		}

		private void dgv_descuento_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			Cursor = Cursors.WaitCursor;
			try
			{
				if (e.RowIndex >= 0 && dgv_descuento.Columns[e.ColumnIndex].Name == "col_ver")
				{
					int consecutivo = Convert.ToInt32(dgv_descuento["col_cosecutivo", e.RowIndex].Value);
					VerDetalle(consecutivo);
				}
				if (e.RowIndex >= 0 && dgv_descuento.Columns[e.ColumnIndex].Name == "col_rechazar2")
				{
					if (MessageBox.Show("¿Confirma rechazar todo el descuento?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.Yes))
					{
						int consecutivo = Convert.ToInt32(dgv_descuento["col_cosecutivo", e.RowIndex].Value);
						DescuentoDirecto descuento_directo = new DescuentoDirecto();
						descuento_directo.CambiarEstadoDescuento(consecutivo, 4);
						descuento_directo.RechazarTodoDescuento(consecutivo);

						Usuarios usuarios = new Usuarios();
						TipoComunicacion tipo = new TipoComunicacion();

						int id_usuario = Convert.ToInt32(dgv_descuento["col_id_usuario", dgv_descuento.CurrentRow.Index].Value);
						string[] correos_cc = usuarios.ListarCorreosCCNegociador(id_usuario).Split(';');

						string consecutivo_descuento = Convert.ToInt32(dgv_descuento["col_cosecutivo", dgv_descuento.CurrentRow.Index].Value).ToString("0000");
						string[] correos_tipo_com = tipo.BuscarCorreoTipoComunicacionDescuento(Convert.ToInt32(consecutivo_descuento)).Split(';');

						string negociador = Convert.ToString(dgv_descuento["col_negociador", dgv_descuento.CurrentRow.Index].Value);
						string retroplanning = Convert.ToString(dgv_descuento["col_retroplanning", dgv_descuento.CurrentRow.Index].Value);
						string nombre_dinamica = Convert.ToString(dgv_descuento["col_nombre_dinamica", dgv_descuento.CurrentRow.Index].Value);
						string fecha_ini_vig = Convert.IsDBNull(dgv_descuento["col_fecha_ini_vig", dgv_descuento.CurrentRow.Index].Value) == true ? "" : Convert.ToDateTime(dgv_descuento["col_fecha_ini_vig", dgv_descuento.CurrentRow.Index].Value).ToShortDateString();
						string fecha_fin_vig = Convert.IsDBNull(dgv_descuento["col_fecha_fin_vig", dgv_descuento.CurrentRow.Index].Value) == true ? "" : Convert.ToDateTime(dgv_descuento["col_fecha_fin_vig", dgv_descuento.CurrentRow.Index].Value).ToShortDateString();
						string tipo_dinamica = Convert.ToString(dgv_descuento["col_dinamica", dgv_descuento.CurrentRow.Index].Value);

						string body = CrearMensaje(negociador, retroplanning, nombre_dinamica, fecha_ini_vig, fecha_fin_vig, tipo_dinamica, consecutivo_descuento, null, true);
						string subject = $"Rechazo descuento {negociador}";

						foreach (string correo_tipo in correos_tipo_com)
						{
							string to = correo_tipo;
							if (!to.Equals(""))
							{
								try
								{
									descuento_directo.EnviarCorreo(to, body, subject, null);
								}
								catch (Exception ex)
								{
									MessageBox.Show(ex.Message);
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
								if (!to.Equals(""))
								{
									try
									{
										descuento_directo.EnviarCorreo(to, body, subject, null);
									}
									catch (Exception ex)
									{
										MessageBox.Show(ex.Message);
										descuento_directo.GuardarCorreoPendiente(to, body, subject, "");
										continue;
									}
								}
							}
						MessageBox.Show("Descuento rechazado correctamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
						dgv_detalle.DataSource = null;
						ListarDescuentos(dtp_fecha_desde.Value.Date.ToString("yyyyMMdd"), dtp_fecha_hasta.Value.Date.ToString("yyyyMMdd"));
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			Cursor = Cursors.Default;
		}

		private void btn_buscar_Click(object sender, EventArgs e)
		{
			if (dtp_fecha_desde.Value.Date > dtp_fecha_hasta.Value.Date)
			{
				MessageBox.Show("La fecha final debe ser mayor o igual a la fecha inicial", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
				dtp_fecha_hasta.Focus();
				return;
			}

			try
			{
				ListarDescuentos(dtp_fecha_desde.Value.Date.ToString("yyyyMMdd"), dtp_fecha_hasta.Value.Date.ToString("yyyyMMdd"));
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void FrmRechazarDescuento_Load(object sender, EventArgs e)
		{
			try
			{
				Icon = Properties.Resources.plan_24;
				this.Top = (this.Parent.ClientSize.Height - this.Height) / 2;
				this.Left = (this.Parent.ClientSize.Width - this.Width) / 2;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void btn_cerrar_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void dgv_detalle_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
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

		private void dgv_descuento_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
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

		private void btn_rechazar_Click(object sender, EventArgs e)
		{
			Cursor = Cursors.WaitCursor;
			try
			{
				if (MessageBox.Show("¿Confirma rechazar descuentos?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.Yes))
				{
					string negociador = Convert.ToString(dgv_descuento["col_negociador", dgv_descuento.CurrentRow.Index].Value);
					string retroplanning = Convert.ToString(dgv_descuento["col_retroplanning", dgv_descuento.CurrentRow.Index].Value);
					string nombre_dinamica = Convert.ToString(dgv_descuento["col_nombre_dinamica", dgv_descuento.CurrentRow.Index].Value);
					string fecha_ini_vig = Convert.IsDBNull(dgv_descuento["col_fecha_ini_vig", dgv_descuento.CurrentRow.Index].Value) == true ? "" : Convert.ToDateTime(dgv_descuento["col_fecha_ini_vig", dgv_descuento.CurrentRow.Index].Value).ToShortDateString();
					string fecha_fin_vig = Convert.IsDBNull(dgv_descuento["col_fecha_fin_vig", dgv_descuento.CurrentRow.Index].Value) == true ? "" : Convert.ToDateTime(dgv_descuento["col_fecha_fin_vig", dgv_descuento.CurrentRow.Index].Value).ToShortDateString();
					string tipo_dinamica = Convert.ToString(dgv_descuento["col_dinamica", dgv_descuento.CurrentRow.Index].Value);

					DescuentoDirecto descuento_directo = new DescuentoDirecto();

					List<string> rechazados = new List<string>();
					bool existe_rechazo = false;
					for (int i = 0; i < dgv_detalle.Rows.Count; i++)
					{
						if (Convert.ToBoolean(dgv_detalle["col_rechazar", i].Value) == true)
						{
							int id = Convert.ToInt32(dgv_detalle["col_id", i].Value);
							descuento_directo.RechazarLineaDescuento(id);

							string rechazo = Convert.ToString(dgv_detalle["col_item", i].Value) + "," +
											Convert.ToString(dgv_detalle["col_desc", i].Value) + "," +
											Convert.ToString(dgv_detalle["col_co", i].Value);
							rechazados.Add(rechazo);
							existe_rechazo = true;
						}

					}
					if (existe_rechazo == true)
					{
						Usuarios usuarios = new Usuarios();
						TipoComunicacion tipo = new TipoComunicacion();

						int id_usuario = Convert.ToInt32(dgv_descuento["col_id_usuario", dgv_descuento.CurrentRow.Index].Value);
						string[] correos_cc = usuarios.ListarCorreosCCNegociador(id_usuario).Split(';');

						string consecutivo_descuento = Convert.ToInt32(dgv_descuento["col_cosecutivo", dgv_descuento.CurrentRow.Index].Value).ToString("0000");
						string[] correos_tipo_com = tipo.BuscarCorreoTipoComunicacionDescuento(Convert.ToInt32(consecutivo_descuento)).Split(';');

						string body = CrearMensaje(negociador, retroplanning, nombre_dinamica, fecha_ini_vig, fecha_fin_vig, tipo_dinamica, consecutivo_descuento, rechazados, false);
						string subject = $"Rechazo descuento {negociador}";

						foreach (string correo_tipo in correos_tipo_com)
						{
							string to = correo_tipo;
							if (!to.Equals(""))
							{
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
								if (!to.Equals(""))
								{
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

						int consecutivo = Convert.ToInt32(dgv_descuento["col_cosecutivo", dgv_descuento.CurrentRow.Index].Value);
						if (rechazados.Count == dgv_detalle.Rows.Count)
						{
							descuento_directo.CambiarEstadoDescuento(consecutivo, 4);
							ListarDescuentos(dtp_fecha_desde.Value.Date.ToString("yyyyMMdd"), dtp_fecha_hasta.Value.Date.ToString("yyyyMMdd"));
							dgv_detalle.DataSource = null;
						}
						else
							VerDetalle(consecutivo);
						
						MessageBox.Show("Descuento rechazado correctamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			Cursor = Cursors.Default;
		}
	}
}
