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
    public partial class FrmReporteOperaciones : Form
    {
        DataTable dt_report = null;

		public FrmReporteOperaciones()
        {
            InitializeComponent();
        }

        private void ListarCentrosOperacion()
        {
            try
            {
                CentrosOperacionListasPrecio clusters = new CentrosOperacionListasPrecio();
                Task<DataTable> task = Task.Run(() => clusters.ListarCentroLista());
                task.Wait();
                cmb_co.DataSource = task.Result;
                cmb_co.ValueMember = "f23_id_co";
                cmb_co.DisplayMember = "f23_co";
                cmb_co.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ListarTiposDinamica()
        {
            TipoDinamica tipo_dinamica = new TipoDinamica();
            Task<DataTable> task = Task.Run(() => tipo_dinamica.ListarTiposDinamica(true));
            task.Wait();
            DataTable dt = task.Result;
            DataRow dr=dt.NewRow();
            dr[0] = 0;
            dr[1] = "";
            dt.Rows.InsertAt(dr,0);
            cmb_dinamicas.DataSource = dt;
            cmb_dinamicas.ValueMember = "f08_id";
            cmb_dinamicas.DisplayMember = "f08_descripcion";
            cmb_dinamicas.SelectedIndex = -1;
        }

        private void CargarReporte(string fecha_ini, string fecha_fin, string co, int tipo_dinamica)
        {
            Reportes reportes = new Reportes();
            dt_report = reportes.ReporteOperaciones(fecha_ini, fecha_fin, co, tipo_dinamica);
            
            Cursor = Cursors.WaitCursor;
           
			if (dt_report != null)
            {
                dgv_datos.AutoGenerateColumns = false;

				col_co.DataPropertyName = "f19_co";
                col_item.DataPropertyName = "f19_item";
                col_ref.DataPropertyName = "f19_referencia";
                col_desc.DataPropertyName = "f19_descripcion";
                col_plan.DataPropertyName = "f19_plan";
                col_criterio.DataPropertyName = "f19_criterio";
                col_fecha_ini.DataPropertyName = "f19_fecha_ini_desc";
                col_fecha_fin.DataPropertyName = "f19_fecha_fin_desc";
                col_tipo_dinamica.DataPropertyName = "tipo_din";
                col_tipo_exh.DataPropertyName = "tipo_exh";
                col_descuento.DataPropertyName = "f19_descuento";
                col_precio.DataPropertyName = "f19_precio_fin";
                col_existencia.DataPropertyName = "f19_existencia";
                col_tipo_com.DataPropertyName = "f19_observacion";

				//dgv_datos.DataSource = dt_report;

				BindingSource miBindingSource = new BindingSource();
				miBindingSource.DataSource = dt_report;
				dgv_datos.DataSource = miBindingSource;
			}
            Cursor = Cursors.Default;
		}

        private void FrmReporteOperaciones_Load(object sender, EventArgs e)
        {
            try
            {
                this.Top = (this.Parent.ClientSize.Height - this.Height) / 2;
                this.Left = (this.Parent.ClientSize.Width - this.Width) / 2;
                ListarCentrosOperacion();
                ListarTiposDinamica();
                Icon = Properties.Resources.plan_24;
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

        private void btn_buscar_Click(object sender, EventArgs e)
        {
            if (dtp_fecha_ini.Value.Date > dtp_fecha_fin.Value.Date)
            {
                MessageBox.Show("La fecha final debe ser mayor o igual a la fecha inicial", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                dtp_fecha_fin.Focus();
                return;
            }
            Cursor = Cursors.WaitCursor;
            try
            {
                string co = cmb_co.SelectedIndex >= 0 ? cmb_co.SelectedValue.ToString() : "";
                int tipo_dinamica = cmb_dinamicas.SelectedIndex >= 1 ? Convert.ToInt32(cmb_dinamicas.SelectedValue) : 0;
                CargarReporte(dtp_fecha_ini.Value.Date.ToString("yyyyMMdd"), dtp_fecha_fin.Value.Date.ToString("yyyyMMdd"), co, tipo_dinamica);
                
                if (dgv_datos.Rows.Count == 0)
                {
                    MessageBox.Show("No hay informacíón", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            Cursor= Cursors.Default;
        }

        private void btn_exportar_Click(object sender, EventArgs e)
        {
            try
            {
                _saveFileDialog.FileName = "Reporte operaciones";
				if (_saveFileDialog.ShowDialog().Equals(DialogResult.OK))
                {
                    XLWorkbook libro = new XLWorkbook();
                    IXLWorksheet reporte = libro.Worksheets.Add("reporte");
                    for (int i = 0; i < dgv_datos.Columns.Count; i++)
                    {
                        reporte.Cell(1, i + 1).SetValue<string>(dgv_datos.Columns[i].HeaderText);
                    }
                    int c = 2;
                    for (int i = 0; i < dgv_datos.Rows.Count; i++)
                    {
                        for (int j = 0; j < dgv_datos.Columns.Count; j++)
                        {
                            reporte.Cell(c, j + 1).SetValue<string>(Convert.ToString(dgv_datos[j, i].Value));
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

        private void dgv_datos_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
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

		private void txt_filtrar_TextChanged(object sender, EventArgs e)
		{
            this.Cursor = Cursors.WaitCursor;
            Application.DoEvents();
            try
            {
				string texto = txt_filtrar.Text.Replace("'", "''");
				((BindingSource)dgv_datos.DataSource).Filter = $"f19_descripcion like '%{texto}%' or tipo_din like '%{texto}%'";

				//dt_report.DefaultView.RowFilter = $"f19_descripcion like '%{txt_filtrar.Text.Trim()}%' or tipo_din like '%{txt_filtrar.Text.Trim()}%'";
            }
            catch (Exception ex)
            {
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
            this.Cursor = Cursors.Default;
		}
	}
}
