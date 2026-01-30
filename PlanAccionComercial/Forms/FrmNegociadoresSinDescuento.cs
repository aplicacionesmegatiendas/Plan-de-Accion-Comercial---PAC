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
    public partial class FrmNegociadoresSinDescuento : Form
    {
        string consecutivo;
        public FrmNegociadoresSinDescuento(string consecutivo)
        {
            InitializeComponent();
            this.consecutivo = consecutivo;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ListarNegociadoresSinDescuento(string consecutivo)
        {
            Reportes reportes = new Reportes();
            dgv_reporte.AutoGenerateColumns = false;
            List<string> negs = reportes.ListarNegociadoresSinDescuento(consecutivo);
            if (negs != null)
            {
                foreach (string item in negs)
                {
                    dgv_reporte.Rows.Add(item);
                }
            }
        }

        private void FrmNegociadoresSinDescuento_Load(object sender, EventArgs e)
        {
            try
            {
                this.Icon = Properties.Resources.plan_24;
                ListarNegociadoresSinDescuento(consecutivo);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
