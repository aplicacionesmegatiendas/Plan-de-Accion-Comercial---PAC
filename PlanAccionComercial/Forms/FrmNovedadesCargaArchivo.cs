using ClosedXML.Excel;
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
    public partial class FrmNovedadesCargaArchivo : Form
    {
        List<string> novedades;
        public FrmNovedadesCargaArchivo(List<string> novedades)
        {
            InitializeComponent();
            this.novedades = novedades;
        }

        private void FrmNovedadesCargaArchivo_Load(object sender, EventArgs e)
        {
            try
            {
                foreach (string item in novedades)
                {
                    dgv_novedades.Rows.Add(item);
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
                if (_saveFileDialog.ShowDialog().Equals(DialogResult.OK))
                {
                    XLWorkbook libro = new XLWorkbook();
                    IXLWorksheet reporte = libro.Worksheets.Add("novedades");
                    for (int i = 0; i < dgv_novedades.Columns.Count; i++)
                    {
                        reporte.Cell(1, i + 1).SetValue<string>(dgv_novedades.Columns[i].HeaderText);
                    }
                    int c = 2;
                    for (int i = 0; i < dgv_novedades.Rows.Count; i++)
                    {
                        for (int j = 0; j < dgv_novedades.Columns.Count; j++)
                        {
                            reporte.Cell(c, j + 1).SetValue<string>(Convert.ToString(dgv_novedades[j, i].Value));
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

        private void dgv_novedades_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
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
    }
}
