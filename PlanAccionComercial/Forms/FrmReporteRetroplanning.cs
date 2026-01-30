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
	public partial class FrmReporteRetroplanning : Form
	{
		DataTable dt_detalle = null;
		public FrmReporteRetroplanning()
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

		private void CrearReporteRetroplanning(string fecha_ini, string fecha_fin, int tipo_dinamica, int consecutivo)
		{
			dgv_reporte.AutoGenerateColumns = false;
			col_retroplanning.DataPropertyName = "f12_consecutivo";
			col_nomb_dinamica.DataPropertyName = "f12_descripcion";
			col_dinamica.DataPropertyName = "f08_descripcion";
			col_fecha_ini_vig.DataPropertyName = "f12_fecha_ini_vig";
			col_fecha_fin_vig.DataPropertyName = "f12_fecha_fin_vig";
			col_fecha_ent_merc.DataPropertyName = "f12_fecha_entrega_mercadeo";
			col_fecha_ent_comer.DataPropertyName = "f12_fecha_entrega_comercial";
			col_estado.DataPropertyName = "f11_descripcion";
			Reportes reportes = new Reportes();
			dt_detalle=reportes.CrearReporteRetroplanning(fecha_ini, fecha_fin, tipo_dinamica, consecutivo);
			dgv_reporte.DataSource = dt_detalle;
		}

		private void ListarNegociadoresRetroplanning(int consecutivo)
		{
			dgv_negociadores.AutoGenerateColumns = false;
			col_negociador.DataPropertyName = "f04_nombre";
			col_cargado.DataPropertyName = "cargado";
			Reportes reportes = new Reportes();
			dgv_negociadores.DataSource = reportes.ListarNegociadoresRetroplanning(consecutivo);
		}

		private void FrmReporteRetroplanning_Load(object sender, EventArgs e)
		{
			try
			{
				this.Top = (this.Parent.ClientSize.Height - this.Height) / 2;
				this.Left = (this.Parent.ClientSize.Width - this.Width) / 2;

				this.Icon = Properties.Resources.plan_24;

				ListarTiposDinamica();

				if (Usuarios.Permisos.Contains("030601"))
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
				int tipo_dinamica = cmb_dinamicas.SelectedIndex >= 1 ? Convert.ToInt32(cmb_dinamicas.SelectedValue) : -1;
				int consecutivo = txt_consecutivo.Text.Trim() == "" ? -1 : Convert.ToInt32(txt_consecutivo.Text.Trim());

				dgv_reporte.DataSource = null;

				CrearReporteRetroplanning(dtp_fecha_ini.Value.Date.ToString("yyyyMMdd"), dtp_fecha_fin.Value.Date.ToString("yyyyMMdd"), tipo_dinamica, consecutivo);
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

		private void dgv_reporte_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			try
			{
				if (dgv_reporte.Columns[e.ColumnIndex].Name.Equals("col_retroplanning") && e.RowIndex >= 0)
				{
					int consecutivo = Convert.ToInt32(dgv_reporte[e.ColumnIndex, e.RowIndex].Value);
					ListarNegociadoresRetroplanning(consecutivo);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void btn_exportar_Click(object sender, EventArgs e)
		{
			try
			{
				_saveFileDialog.FileName = "Reporte Retroplanning";
				if (_saveFileDialog.ShowDialog().Equals(DialogResult.OK))
				{
					XLWorkbook libro = new XLWorkbook();
					IXLWorksheet reporte = libro.Worksheets.Add("reporte");

					for (int i = 0; i < dgv_reporte.Columns.Count; i++)
					{
						if ((dgv_reporte.Columns[i].Visible == true))
							reporte.Cell(1, i + 1).SetValue<string>(dgv_reporte.Columns[i].HeaderText);
					}
					int c = 2;
					for (int i = 0; i < dgv_reporte.Rows.Count; i++)
					{
						for (int j = 0; j < dgv_reporte.Columns.Count; j++)
						{
							if ((dgv_reporte.Columns[j].Visible == true))
							{
								string dato = Convert.ToString(dgv_reporte[j, i].Value);
								reporte.Cell(c, j + 1).SetValue<string>(Convert.ToString(dgv_reporte[j, i].FormattedValue));
							}
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

		private void btnCerrar_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void txt_filtrar_TextChanged(object sender, EventArgs e)
		{
			Cursor=Cursors.WaitCursor;
			try
			{
				if (dt_detalle!=null)
				{
					dt_detalle.DefaultView.RowFilter = $"f12_descripcion like '%{txt_filtrar.Text.Trim()}%'";
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
			Cursor=Cursors.Default;
		}
	}
}
