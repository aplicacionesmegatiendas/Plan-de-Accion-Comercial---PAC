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
    public partial class FrmPrecios : Form
    {
        List<object[]> list;
        FrmDescuentosRetroplanning frm;
        FrmDescuentoDirecto frm2;
        FrmEditarDescuentoDirecto frm3;
        string cluster;
        public FrmPrecios(List<object[]> list, FrmDescuentosRetroplanning frm, string cluster)
        {
            InitializeComponent();
            this.list = list;
            this.frm = frm;
            this.cluster = cluster;
        }

        public FrmPrecios(List<object[]> list, FrmDescuentoDirecto frm, string cluster)
        {
            InitializeComponent();
            this.list = list;
            this.frm2 = frm;
            this.cluster = cluster;
        }

        public FrmPrecios(List<object[]> list, FrmEditarDescuentoDirecto frm, string cluster)
        {
            InitializeComponent();
            this.list = list;
            this.frm3 = frm;
            this.cluster = cluster;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmPrecios_Load(object sender, EventArgs e)
        {
            lbl_cluster.Text = cluster;
            foreach (object[] item in list)
            {
                decimal precio = Math.Truncate(100 * Convert.ToDecimal(item[1]) / 100);
                decimal existencia = Math.Truncate(100 * Convert.ToDecimal(item[3]) / 100);
                dgv_precios.Rows.Add(item[0], precio, item[2], existencia, item[4], item[5]);
            }
        }

        private void btn_aceptar_Click(object sender, EventArgs e)
        {
            if (frm != null)
            {
                int nro = dgv_precios.Rows.Count;

                decimal precio_prom = 0;
                decimal suma_precio = 0;
                decimal pum_prom = 0;
                decimal suma_pum = 0;
                decimal existencia = 0;
                for (int i = 0; i < dgv_precios.Rows.Count; i++)
                {
                    suma_precio += Convert.ToDecimal(dgv_precios["col_precio", i].Value);
                    suma_pum += Convert.ToDecimal(dgv_precios["col_pum", i].Value);
                    existencia += Convert.ToDecimal(dgv_precios["col_exist", i].Value);
                }
                precio_prom = suma_precio / nro;
                frm.txt_precio.Text = precio_prom.ToString();

                pum_prom = suma_pum / nro;
                frm.txt_pum.Text = pum_prom.ToString();

                frm.txt_existencia.Text = existencia.ToString();
            }
            if (frm2 != null)
            {
                int nro=dgv_precios.Rows.Count;

                decimal precio_prom = 0;
                decimal suma_precio = 0;
                decimal pum_prom = 0;
                decimal suma_pum = 0;
                decimal existencia = 0;
                for (int i = 0; i < dgv_precios.Rows.Count; i++)
                {
                    suma_precio += Convert.ToDecimal(dgv_precios["col_precio", i].Value);
                    suma_pum += Convert.ToDecimal(dgv_precios["col_pum", i].Value);
                    existencia += Convert.ToDecimal(dgv_precios["col_exist", i].Value);
                }
                precio_prom=suma_precio/nro;
                frm2.txt_precio.Text = precio_prom.ToString();

                pum_prom = suma_pum / nro;
                frm2.txt_pum.Text = pum_prom.ToString();

                frm2.txt_existencia.Text = existencia.ToString();
            }

            if (frm3 != null)
            {
                int nro = dgv_precios.Rows.Count;

                decimal precio_prom = 0;
                decimal suma_precio = 0;
                decimal pum_prom = 0;
                decimal suma_pum = 0;
                decimal existencia = 0;
                for (int i = 0; i < dgv_precios.Rows.Count; i++)
                {
                    suma_precio += Convert.ToDecimal(dgv_precios["col_precio", i].Value);
                    suma_pum += Convert.ToDecimal(dgv_precios["col_pum", i].Value);
                    existencia += Convert.ToDecimal(dgv_precios["col_exist", i].Value);
                }
                precio_prom = suma_precio / nro;
                frm3.txt_precio.Text = precio_prom.ToString();

                pum_prom = suma_pum / nro;
                frm3.txt_pum.Text = pum_prom.ToString();

                frm3.txt_existencia.Text = existencia.ToString();
            }

            Close();
        }
    }
}
