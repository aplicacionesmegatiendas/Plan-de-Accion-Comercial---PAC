using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PlanAccionComercial.Class;
using static PlanAccionComercial.Class.Permisos;

namespace PlanAccionComercial.Forms
{
    public partial class FrmEditarRetroplanning : Form
    {
        Retroplanning.Planning planning;
        public FrmEditarRetroplanning(Retroplanning.Planning planning)
        {
            InitializeComponent();
            this.planning = planning;
        }

        private void ListarNegociadoresDescuentoRetroplanning()
        {
            Retroplanning retroplanning = new Retroplanning();
            clb_negociador.DataSource = retroplanning.ListarNegociadoresDescuentoRetroplanning();
            clb_negociador.DisplayMember = "f04_usuario";
            clb_negociador.ValueMember = "f04_id";
        }

        private void ListarTiposDinamica()
        {
            TipoDinamica tipo_dinamica = new TipoDinamica();
            Task<DataTable> task = Task.Run(() => tipo_dinamica.ListarTiposDinamica());
            task.Wait();
            cmb_tipo_dinamica.DataSource = task.Result;
            cmb_tipo_dinamica.ValueMember = "f08_id";
            cmb_tipo_dinamica.DisplayMember = "f08_descripcion";
            cmb_tipo_dinamica.SelectedIndex = -1;
        }

        private void FrmEditarRetroplanning_Load(object sender, EventArgs e)
        {
            try
            {
                Icon = Properties.Resources.plan_24;
                ListarTiposDinamica();
                ListarNegociadoresDescuentoRetroplanning();

                txt_consecutivo.Text = planning.Consecutivo.ToString().PadLeft(4, '0');
                txt_nombre.Text = planning.Descripcion;
                cmb_tipo_dinamica.SelectedValue = planning.Dinamica;
                dtp_fecha_ini_vig.Value = planning.FechaInicialVigencia;
                dtp_fecha_fin_vig.Value = planning.FechaFinalVigencia;
                dtp_fecha_mercadeo.Value = planning.FechaEntregaMercadeo;
                dtp_fecha_comecial.Value = planning.FechaEntregaComercial;

                for (int i = 0; i < clb_negociador.Items.Count; i++)
                {
                    clb_negociador.SelectedIndex = i;
                    for (int j = 0; j < planning.Negociadores.Count; j++)
                    {
                        if (Convert.ToString(clb_negociador.SelectedValue) == planning.Negociadores[j].ToString())
                        {
                            clb_negociador.SetItemChecked(i, true);
                        }
                    }
                }
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

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txt_nombre.Text.Equals(""))
            {
                MessageBox.Show("Escriba el nombre de la dinámica", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_nombre.Focus();
                return;
            }

            if (dtp_fecha_ini_vig.Value.Date > dtp_fecha_fin_vig.Value.Date)
            {
                MessageBox.Show("La fecha final de la vigencia de ser mayor a la fecha inicial", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (dtp_fecha_mercadeo.Value.Date > dtp_fecha_fin_vig.Value.Date)
            {
                MessageBox.Show("La fecha de entrega a mercado no debe ser despues de la fecha final de la vigencia", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                dtp_fecha_mercadeo.Focus();
                return;
            }

            if (dtp_fecha_comecial.Value.Date > dtp_fecha_fin_vig.Value.Date)
            {
                MessageBox.Show("La fecha de entrega a comercial no debe ser despues de la fecha final de la vigencia", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                dtp_fecha_comecial.Focus();
                return;
            }

            if (clb_negociador.CheckedItems.Count == 0)
            {
                MessageBox.Show("Seleccione los negociadores", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                clb_negociador.Focus();
                return;
            }

            if (cmb_tipo_dinamica.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione el tipo de dinámica", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            try
            {
                Retroplanning retroplanning = new Retroplanning();

                planning.Descripcion = txt_nombre.Text.Trim();
                planning.FechaInicialVigencia = dtp_fecha_ini_vig.Value.Date;
                planning.FechaFinalVigencia = dtp_fecha_fin_vig.Value.Date;
                planning.Dinamica = Convert.ToInt32(cmb_tipo_dinamica.SelectedValue);
                planning.FechaEntregaMercadeo = dtp_fecha_mercadeo.Value.Date;
                planning.FechaEntregaComercial = dtp_fecha_comecial.Value.Date;
                List<int> negociadores = new List<int>();
                foreach (DataRowView item in clb_negociador.CheckedItems)
                {
                    negociadores.Add(Convert.ToInt32(item[0].ToString()));
                }
                planning.Negociadores = negociadores;

                retroplanning.EditarRetroplanning(planning);
                MessageBox.Show("Retroplanning guardado correctamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
