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
	public partial class FrmReporteEstado : Form
	{
		DataTable dt_detalle = null;
		public FrmReporteEstado()
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

		private void CrearReporteEstado(string fecha_ini, string fecha_fin, int tipo_dinamica, bool consecutivo_retro, bool consecutivo_descuento, int consecutivo)
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
			if (Usuarios.Rol == 2)
				dgv_reporte.DataSource = reportes.CrearReporteEstado(fecha_ini, fecha_fin, tipo_dinamica, consecutivo_retro, consecutivo_descuento, consecutivo, 0);
			else
				dgv_reporte.DataSource = reportes.CrearReporteEstado(fecha_ini, fecha_fin, tipo_dinamica, consecutivo_retro, consecutivo_descuento, consecutivo, Usuarios.Id);
		}

		private void VerDetalle(int consecutivo)
		{
			dgv_detalle.AutoGenerateColumns = false;
			col_co.DataPropertyName = "f19_co";
			col_item.DataPropertyName = "f19_item";
			col_desc.DataPropertyName = "f19_descripcion";
			col_casa_prov.DataPropertyName = "f19_casa_prov";
			col_plan.DataPropertyName = "f19_plan";
			col_criterio.DataPropertyName = "f19_criterio";
			col_fecha_ini.DataPropertyName = "f19_fecha_ini_desc";
			col_fecha_fin.DataPropertyName = "f19_fecha_fin_desc";
			col_precio.DataPropertyName = "f19_precio";
			col_descuento.DataPropertyName = "f19_descuento";
			col_precio_fin.DataPropertyName = "precio_fin";
			col_obs.DataPropertyName = "f19_observacion";
			col_rechazado.DataPropertyName = "f19_rechazado";
			Reportes reportes = new Reportes();
			dt_detalle=reportes.VerDetalleDescuento(consecutivo, false);
			dgv_detalle.DataSource = dt_detalle;
		}

		private void FrmReporteEstado_Load(object sender, EventArgs e)
		{
			try
			{
				this.Top = (this.Parent.ClientSize.Height - this.Height) / 2;
				this.Left = (this.Parent.ClientSize.Width - this.Width) / 2;

				this.Icon = Properties.Resources.plan_24;

				ListarTiposDinamica();

				if (Usuarios.Permisos.Contains("030101"))
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
			Cursor = Cursors.WaitCursor;
			try
			{
				if (dtp_fecha_ini.Value.Date > dtp_fecha_fin.Value.Date)
				{
					MessageBox.Show("La fecha final debe ser mayor ó igual a la fecha inicial", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					Cursor = Cursors.Default;
					return;
				}
				int tipo_dinamica = cmb_dinamicas.SelectedIndex >= 1 ? Convert.ToInt32(cmb_dinamicas.SelectedValue) : 0;
				_ = int.TryParse(txt_consecutivo.Text.Trim(), out int consecutivo);
				dgv_reporte.DataSource = null;
				dgv_detalle.DataSource = null;
				CrearReporteEstado(dtp_fecha_ini.Value.Date.ToString("yyyyMMdd"), dtp_fecha_fin.Value.Date.ToString("yyyyMMdd"), tipo_dinamica, chk_retro.Checked, chk_descuento.Checked, consecutivo);
				if (dgv_reporte.Rows.Count == 0)
				{
					MessageBox.Show("No hay datos que mostrar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			Cursor = Cursors.Default;
		}

		private void dgv_reporte_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			Cursor = Cursors.WaitCursor;
			try
			{
				if (e.RowIndex >= 0 && dgv_reporte.Columns[e.ColumnIndex].Name == "col_detalle")
				{
					int consecutivo = Convert.ToInt32(dgv_reporte["col_consecutivo", e.RowIndex].Value);
					VerDetalle(consecutivo);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			Cursor = Cursors.Default;
		}

		private void btnCerrar_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void btn_exportar_Click(object sender, EventArgs e)
		{
			try
			{
				_saveFileDialog.FileName = "Reporte Estado";

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
							reporte.Cell(4, i + 1).SetValue<string>(dgv_detalle.Columns[i].HeaderText);
						}
						int c = 5;
						for (int i = 0; i < dgv_detalle.Rows.Count; i++)
						{
							for (int j = 0; j < dgv_detalle.Columns.Count; j++)
							{
								string dato = Convert.ToString(dgv_detalle[j, i].Value);
								if (j == dgv_detalle.Columns.Count - 1)
								{
									bool rechazado = Convert.ToBoolean(dgv_detalle[j, i].Value);
									if (rechazado)
									{
										reporte.Cell(c, j + 1).SetValue<string>("✓");
									}
									else
									{
										reporte.Cell(c, j + 1).SetValue<string>("");
									}
								}
								else
								{
									reporte.Cell(c, j + 1).SetValue<string>(Convert.ToString(dgv_detalle[j, i].FormattedValue));
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
							reporte.Cell(7, i + 1).SetValue<string>(dgv_detalle.Columns[i].HeaderText);
						}
						int c = 8;
						for (int i = 0; i < dgv_detalle.Rows.Count; i++)
						{
							for (int j = 0; j < dgv_detalle.Columns.Count; j++)
							{
								string dato = Convert.ToString(dgv_detalle[j, i].Value);
								if (j == dgv_detalle.Columns.Count - 1)
								{
									bool rechazado = Convert.ToBoolean(dgv_detalle[j, i].Value);
									if (rechazado)
									{
										reporte.Cell(c, j + 1).SetValue<string>("✓");
									}
									else
									{
										reporte.Cell(c, j + 1).SetValue<string>("");
									}
								}
								else
								{
									reporte.Cell(c, j + 1).SetValue<string>(Convert.ToString(dgv_detalle[j, i].Value));
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

		private void btn_exportar_descuentos_Click(object sender, EventArgs e)
		{
			try
			{
				_saveFileDialog.FileName = "Reporte Estado";

				if (_saveFileDialog.ShowDialog().Equals(DialogResult.OK))
				{
					XLWorkbook libro = new XLWorkbook();
					IXLWorksheet reporte = libro.Worksheets.Add("reporte");

					for (int i = 0; i < dgv_reporte.Columns.Count - 1; i++)
					{
						reporte.Cell(1, i + 1).SetValue<string>(dgv_reporte.Columns[i].HeaderText);
					}
					int c = 2;
					for (int i = 0; i < dgv_reporte.Rows.Count; i++)
					{
						for (int j = 0; j < dgv_reporte.Columns.Count - 1; j++)
						{
							string dato = Convert.ToString(dgv_reporte[j, i].Value);
							if (j == 0)
								if (dato.Length == 0)
									reporte.Cell(c, j + 1).SetValue<string>("");
								else
									reporte.Cell(c, j + 1).SetValue<string>(dato.PadLeft(4, '0'));
							else
								reporte.Cell(c, j + 1).SetValue<string>(dato);
						}
						c++;
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
