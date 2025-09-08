using ClosedXML.Excel;
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
	public partial class FrmReporteLiquidacion : Form
	{
		DataTable dt_detalle = null;
		public FrmReporteLiquidacion()
		{
			InitializeComponent();
		}

		private void ListarTiposDinamica()
		{
			TipoDinamica tipo_dinamica = new TipoDinamica();
			Task<DataTable> task = Task.Run(() => tipo_dinamica.ListarTiposDinamica(true));
			task.Wait();
			DataTable dt = task.Result;
			DataRow dr = dt.NewRow();
			dr[0] = 0;
			dr[1] = "";
			dt.Rows.InsertAt(dr, 0);
			cmb_dinamicas.DataSource = dt;
			cmb_dinamicas.ValueMember = "f08_id";
			cmb_dinamicas.DisplayMember = "f08_descripcion";
			cmb_dinamicas.SelectedIndex = -1;
		}

		private void ListarProveedoresDescuento()
		{
			Reportes reportes = new Reportes();

			DataTable dt = reportes.ListarProveedoresDescuento();
			DataRow dr = dt.NewRow();
			dr[0] = 0;
			dr[1] = "";
			dt.Rows.InsertAt(dr, 0);
			cmb_proveedores.DataSource = dt;
			cmb_proveedores.ValueMember = "f19_nit";
			cmb_proveedores.DisplayMember = "f19_proveedor";
			cmb_proveedores.SelectedIndex = -1;
		}

		private void CrearReporteLiquidacion(string fecha_ini, string fecha_fin, int tipo_dinamica, string proveedor, bool consecutivo_reto, bool consecutivo_descuento, int consecutivo)
		{
			dgv_reporte.AutoGenerateColumns = false;
			col_retroplanning.DataPropertyName = "f12_consecutivo";
			col_nomb_dinamica.DataPropertyName = "f12_descripcion";
			col_fecha_ini_vig.DataPropertyName = "f12_fecha_ini_vig";
			col_fecha_fin_vig.DataPropertyName = "f12_fecha_fin_vig";
			col_consecutivo.DataPropertyName = "f17_consecutivo";
			col_dinamica.DataPropertyName = "f08_descripcion";
			col_fecha.DataPropertyName = "f17_fecha";
			col_negociador.DataPropertyName = "f04_nombre";
			col_estado.DataPropertyName = "estado";
			Reportes reportes = new Reportes();
			dgv_reporte.DataSource = reportes.CrearReporteLiquidacion(fecha_ini, fecha_fin, tipo_dinamica, proveedor, consecutivo_reto, consecutivo_descuento, consecutivo);
		}

		private void VerDetalleDescuento(int consecutivo, string nit)
		{
			dgv_detalle.AutoGenerateColumns = false;
			col_item.DataPropertyName = "f19_item";
			col_referencia.DataPropertyName = "f19_referencia";
			col_desc.DataPropertyName = "f19_descripcion";
			col_nit.DataPropertyName = "f19_nit";
			col_casa_prov.DataPropertyName = "f19_proveedor";
			col_tipo_desc.DataPropertyName = "tipo_descuento";
			col_descuento.DataPropertyName = "f19_descuento";
			col_porc_proveedor.DataPropertyName = "f19_porc_proveedor";
			col_por_mega.DataPropertyName = "f19_porc_megatiendas";
			col_mod_cobro.DataPropertyName = "f19_modo_cobro";
			col_fecha_ini.DataPropertyName = "f19_fecha_ini_desc";
			col_fecha_fin.DataPropertyName = "f19_fecha_fin_desc";
			col_cod_co.DataPropertyName = "f19_id_co";
			col_regional.DataPropertyName = "f19_regional_cluster";
			col_co.DataPropertyName = "f19_co";
			col_ind_reg.DataPropertyName = "f19_ind_regional_cluster";
			col_obs.DataPropertyName = "f19_observacion";
			Reportes reportes = new Reportes();
			dt_detalle= reportes.VerDetalleReporteLiquidacion(consecutivo, nit);
			dgv_detalle.DataSource = dt_detalle;
			dgv_detalle.Visible = false;
			for (int i = 0; i < dgv_detalle.Rows.Count; i++)
			{
				try
				{
					if (DateTime.Now.Date > Convert.ToDateTime(dgv_detalle["col_fecha_fin",i].Value).Date)
					{
						Application.DoEvents();
						dgv_detalle["col_fecha_fin", i].Style.ForeColor = Color.Red;
					}
				}
				catch (Exception)
				{
					continue;
				}
			}
			dgv_detalle.Visible = true;
		}

		private void FrmReporteLiquidacion_Load(object sender, EventArgs e)
		{
			try
			{
				this.Top = (this.Parent.ClientSize.Height - this.Height) / 2;
				this.Left = (this.Parent.ClientSize.Width - this.Width) / 2;

				this.Icon = Properties.Resources.plan_24;

				ListarTiposDinamica();
				ListarProveedoresDescuento();

				if (Usuarios.Permisos.Contains("030501"))
				{
					btn_exportar.Enabled = true;
				}
				else
				{
					btn_exportar.Enabled = false;
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
				if (dtp_fecha_ini.Value.Date > dtp_fecha_fin.Value.Date)
				{
					MessageBox.Show("La fecha final debe ser mayor ó igual a la fecha inicial", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					return;
				}
				int tipo_dinamica = cmb_dinamicas.SelectedIndex >= 1 ? Convert.ToInt32(cmb_dinamicas.SelectedValue) : 0;
				string proveedor = cmb_proveedores.SelectedIndex >= 1 ? Convert.ToString(cmb_proveedores.SelectedValue) : "";
				dgv_reporte.DataSource = null;
				dgv_detalle.DataSource = null;
				_ = int.TryParse(txt_consecutivo.Text.Trim(), out int consecutivo);
				CrearReporteLiquidacion(dtp_fecha_ini.Value.Date.ToString("yyyyMMdd"), dtp_fecha_fin.Value.Date.ToString("yyyyMMdd"), tipo_dinamica, proveedor, chk_retro.Checked, chk_descuento.Checked, consecutivo);
				if (dgv_reporte.Rows.Count == 0)
				{
					MessageBox.Show("No hay datos que mostrar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void dgv_reporte_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			Cursor = Cursors.WaitCursor;
			try
			{
				if (e.RowIndex >= 0 && dgv_reporte.Columns[e.ColumnIndex].Name == "col_detalle")
				{
					int consecutivo = Convert.ToInt32(dgv_reporte["col_consecutivo", e.RowIndex].Value);
					string nit = "";
					if (cmb_proveedores.Text != "")
						nit = cmb_proveedores.SelectedValue.ToString();
					VerDetalleDescuento(consecutivo, nit);
				}
				if (e.RowIndex >= 0 && dgv_reporte.Columns[e.ColumnIndex].Name == "col_liquidado")
				{
					if (Usuarios.Permisos.Contains("030502"))
					{

						if (MessageBox.Show("¿Confirma marcar como Liquidado este descuento?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.Yes))
						{
							int consecutivo = Convert.ToInt32(dgv_reporte["col_consecutivo", e.RowIndex].Value);
							DescuentoDirecto descuento_directo = new DescuentoDirecto();
							descuento_directo.CambiarEstadoDescuento(consecutivo, 3);
							btn_buscar.PerformClick();
						}
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			Cursor = Cursors.Default;
		}

		private void dgv_reporte_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
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

		private void btnCerrar_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void btn_exportar_Click(object sender, EventArgs e)
		{
			try
			{
				_saveFileDialog.FileName = "Reporte liquidación";
				if (_saveFileDialog.ShowDialog().Equals(DialogResult.OK))
				{
					XLWorkbook libro = new XLWorkbook();
					IXLWorksheet reporte = libro.Worksheets.Add("reporte");

					string consecutivo_retro = Convert.ToString(dgv_reporte["col_retroplanning", dgv_reporte.CurrentRow.Index].Value);
					string nombre_dinamica = Convert.ToString(dgv_reporte["col_nomb_dinamica", dgv_reporte.CurrentRow.Index].Value);
					string fecha_ini_vig = Convert.ToString(dgv_reporte["col_fecha_ini_vig", dgv_reporte.CurrentRow.Index].Value);
					string fecha_fin_vig = Convert.ToString(dgv_reporte["col_fecha_fin_vig", dgv_reporte.CurrentRow.Index].Value);
					string consecutivo_descuento = Convert.ToString(dgv_reporte["col_consecutivo", dgv_reporte.CurrentRow.Index].Value);
					string negociador = Convert.ToString(dgv_reporte["col_negociador", dgv_reporte.CurrentRow.Index].Value);
					if (consecutivo_retro.Equals(""))
					{
						reporte.Cell(1, "A").SetValue<string>("Consecutivo descuento:");
						reporte.Cell(1, "B").SetValue<string>(consecutivo_descuento.PadLeft(4, '0'));

						reporte.Cell(2, "A").SetValue<string>("Negociador:");
						reporte.Cell(2, "B").SetValue<string>(negociador);


						for (int i = 0; i < dgv_detalle.Columns.Count; i++)
						{
							if ((dgv_detalle.Columns[i].Visible == true))
								reporte.Cell(4, i + 1).SetValue<string>(dgv_detalle.Columns[i].HeaderText);
						}
						int c = 5;
						for (int i = 0; i < dgv_detalle.Rows.Count; i++)
						{
							for (int j = 0; j < dgv_detalle.Columns.Count; j++)
							{
								if ((dgv_detalle.Columns[j].Visible == true))
								{
									string dato = Convert.ToString(dgv_detalle[j, i].Value);
									reporte.Cell(c, j + 1).SetValue<string>(Convert.ToString(dgv_detalle[j, i].FormattedValue));
									if (dgv_detalle.Rows[i].DefaultCellStyle.ForeColor == System.Drawing.Color.Blue)
									{
										reporte.Cell(c, j + 1).Style.Font.FontColor = XLColor.Blue;
									}
								}
							}
							c++;
						}
					}
					else
					{
						reporte.Cell(1, "A").SetValue<string>("Consecutivo retroplanning:");
						reporte.Cell(1, "B").SetValue<string>(consecutivo_retro.PadLeft(4, '0'));

						reporte.Cell(2, "A").SetValue<string>("Nombre dinámica:");
						reporte.Cell(2, "B").SetValue<string>(nombre_dinamica);

						reporte.Cell(3, "A").SetValue<string>("Vigencia:");
						reporte.Cell(3, "B").SetValue<string>($"Desde {fecha_ini_vig} Hasta {fecha_fin_vig}");

						reporte.Cell(4, "A").SetValue<string>("Consecutivo descuento:");
						reporte.Cell(4, "B").SetValue<string>(consecutivo_descuento.PadLeft(4, '0'));

						reporte.Cell(5, "A").SetValue<string>("Negociador:");
						reporte.Cell(5, "B").SetValue<string>(negociador);


						for (int i = 0; i < dgv_detalle.Columns.Count; i++)
						{
							if ((dgv_detalle.Columns[i].Visible == true))
								reporte.Cell(7, i + 1).SetValue<string>(dgv_detalle.Columns[i].HeaderText);
						}
						int c = 8;
						for (int i = 0; i < dgv_detalle.Rows.Count; i++)
						{
							for (int j = 0; j < dgv_detalle.Columns.Count; j++)
							{
								if ((dgv_detalle.Columns[j].Visible == true))
								{
									string dato = Convert.ToString(dgv_detalle[j, i].Value);
									reporte.Cell(c, j + 1).SetValue<string>(Convert.ToString(dgv_detalle[j, i].Value));
									if (dgv_detalle.Rows[i].DefaultCellStyle.ForeColor == System.Drawing.Color.Blue)
									{
										reporte.Cell(c, j + 1).Style.Font.FontColor = XLColor.Blue;
									}
								}
							}
							c++;
						}
					}
					libro.SaveAs(_saveFileDialog.FileName);
					MessageBox.Show("Datos exportados correctamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
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

		private void dgv_detalle_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			if (e.ColumnIndex == 0)
			{
				if (Convert.ToString(dgv_detalle.Rows[e.RowIndex].Cells["col_co"].Value) == "")
				{
					dgv_detalle.Rows[e.RowIndex].DefaultCellStyle.ForeColor = System.Drawing.Color.Blue;
				}
				else
				{
					dgv_detalle.Rows[e.RowIndex].DefaultCellStyle.ForeColor = dgv_detalle.DefaultCellStyle.ForeColor;
				}
			}
		}

		private void chk_retro_CheckedChanged(object sender, EventArgs e)
		{
			if (chk_retro.Checked)
			{
				chk_descuento.Checked = false;
				txt_consecutivo.Focus();
				txt_consecutivo.SelectAll();
			}
		}

		private void chk_descuento_CheckedChanged(object sender, EventArgs e)
		{
			if (chk_descuento.Checked)
			{
				chk_retro.Checked = false;
				txt_consecutivo.Focus();
				txt_consecutivo.SelectAll();
			}
		}

		private void txt_filtrar_TextChanged(object sender, EventArgs e)
		{
			Cursor = Cursors.WaitCursor;
			try
			{
				if (dt_detalle!=null)
				{
					dt_detalle.DefaultView.RowFilter = $"f19_descripcion like '%{txt_filtrar.Text.Trim()}%'";
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
			Cursor = Cursors.Default;
		}
	}
}
