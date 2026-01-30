using ClosedXML.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
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
    public partial class FrmDetalleItemsRegionalCluster : Form
    {
        int consecutivo;
        string item;
        string referencia;
        string descripcion;
        string regional_cluster;
        public FrmDetalleItemsRegionalCluster(int consecutivo, string item, string referencia, string descripcion, string regional_cluster)
        {
            InitializeComponent();
            this.consecutivo = consecutivo;
            this.item = item;
            this.referencia = referencia;
            this.descripcion = descripcion;
            this.regional_cluster = regional_cluster;
        }

        private void VerDetalleItemRegionalCluster(int consecutivo, string item, string regional_cluster)
        {
            dgv_detalle.AutoGenerateColumns = false;
            col_cod_co.DataPropertyName = "f19_id_co";
            col_co.DataPropertyName = "f19_co";
            col_precio_antes.DataPropertyName = "f19_precio";
            col_precio_fin.DataPropertyName = "f19_precio_fin";
            col_pum.DataPropertyName = "f19_pum2";
            col_existencia.DataPropertyName = "f19_existencia";
            Reportes reportes = new Reportes();
            DataTable dt=reportes.VerDetalleItemRegionalCluster(consecutivo, item, regional_cluster);
            dgv_detalle.DataSource = dt;
            decimal total = 0;
            foreach (DataGridViewRow fila in dgv_detalle.Rows)
            {
                decimal.TryParse(Convert.ToString(fila.Cells["col_existencia"].Value), out decimal r);
                total+=r;
            }
            lbl_total.Text = total.ToString();
        }

        private void FrmDetalleItemsRegionalCluster_Load(object sender, EventArgs e)
        {
            try
            {
                this.Icon = Properties.Resources.plan_24;
                lbl_item.Text = item;
                lbl_referencia.Text = referencia;
                lbl_descripcion.Text = descripcion;
                lbl_regional_cluster.Text = regional_cluster;
                VerDetalleItemRegionalCluster(consecutivo, item, regional_cluster);
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

        private void btn_exportar_Click(object sender, EventArgs e)
        {
            try
            {
                if (_saveFileDialog.ShowDialog().Equals(DialogResult.OK))
                {
                    XLWorkbook libro = new XLWorkbook();
                    IXLWorksheet reporte = libro.Worksheets.Add("detalle");

                    reporte.Cell(1, "A").SetValue<string>("Ítem:");
                    reporte.Cell(1, "B").SetValue<string>(lbl_item.Text);

                    reporte.Cell(2, "A").SetValue<string>("Referencia:");
                    reporte.Cell(2, "B").SetValue<string>(lbl_referencia.Text);

                    reporte.Cell(3, "A").SetValue<string>("Descripción:");
                    reporte.Cell(3, "B").SetValue<string>(lbl_descripcion.Text);

                    reporte.Cell(4, "A").SetValue<string>("Regional/Cluster:");
                    reporte.Cell(4, "B").SetValue<string>(lbl_regional_cluster.Text);

                    for (int i = 0; i < dgv_detalle.Columns.Count; i++)
                    {
                        if ((dgv_detalle.Columns[i].Visible == true))
                            reporte.Cell(6, i + 1).SetValue<string>(dgv_detalle.Columns[i].HeaderText);
                    }
                    int c = 7;
                    for (int i = 0; i < dgv_detalle.Rows.Count; i++)
                    {
                        for (int j = 0; j < dgv_detalle.Columns.Count; j++)
                        {
                            if ((dgv_detalle.Columns[j].Visible == true))
                            {
                                string dato = Convert.ToString(dgv_detalle[j, i].Value);
                                reporte.Cell(c, j + 1).SetValue<string>(Convert.ToString(dgv_detalle[j, i].FormattedValue));
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
    }
}
