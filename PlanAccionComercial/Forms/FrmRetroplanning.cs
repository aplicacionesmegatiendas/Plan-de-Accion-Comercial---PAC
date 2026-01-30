using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using PlanAccionComercial.Class;

namespace PlanAccionComercial.Forms
{
    public partial class FrmRetroplanning : Form
    {
        public FrmRetroplanning()
        {
            InitializeComponent();
        }

        private int ObtenerConsecutivo(int id)
        {
            Retroplanning retroplanning = new Retroplanning();
            return Convert.ToInt32(retroplanning.ObtenerValorConfiguracion(1));
        }

        private void Limpiar()
        {
            txt_nombre.Text = "";
            cmb_tipo_dinamica.SelectedIndex = -1;
            for (int i = 0; i < clb_negociador.Items.Count; i++)
            {
                clb_negociador.SetItemChecked(i, false);
            }
            clb_negociador.ClearSelected();
        }

        private string CrearMensaje(string usuario)
        {
            string message = $@"<html>
                                <title>Nuevo Retroplanning</title>
                                <body>
                                    <p>Sr(a):</p>           
                                    <p>{usuario}</p>
                                    <p>Se le informa que se ha generado un nuevo Retroplanning, a continuación los datos:</p>
                                    <div>
                                        <h2 style=margin-bottom:0px>Consecutivo</h2>
                                        <h1 style=margin-top:0px>{txt_consecutivo.Text}</h1>
                                    </div>
                                    <div>
                                        <p style=margin-bottom:0px>Nombre de la dinámica:</p>
                                        <h3 style=margin-top:0px>{txt_nombre.Text}</h3>
                                    
                                    <div>
                                        <p style=margin-bottom:0px>Tipo de dinámica:</p>
                                        <h3 style=margin-top:0px>{cmb_tipo_dinamica.Text}</h3>
                                    </div>
                                    <p>Vigencia: Desde {dtp_fecha_ini_vig.Value.Date.ToShortDateString()} Hasta {dtp_fecha_fin_vig.Value.Date.ToShortDateString()}</p>
                                    <p>Los descuentos se deben cargar desde el programa <i>Plan de Acción Comercial (PAC)</i> hasta el día {dtp_fecha_mercadeo.Value.Date.ToShortDateString()}</p>

                                </body>            
                            </html>";

            return message;
        }

        private void ListarRetroplanning()
        {
            Retroplanning retroplanning = new Retroplanning();
            dgv_retroplanning.AutoGenerateColumns = false;
            col_consecutivo.DataPropertyName = "f12_consecutivo";
            col_dinamica.DataPropertyName = "f12_descripcion";
            col_id_tipo_dinamica.DataPropertyName = "f08_id";
            col_tipo_dinamica.DataPropertyName = "f08_descripcion";
            col_fecha_ini_vig.DataPropertyName = "f12_fecha_ini_vig";
            col_fecha_fin_vig.DataPropertyName = "f12_fecha_fin_vig";
            col_fecha_ent_mercadeo.DataPropertyName = "f12_fecha_entrega_mercadeo";
            col_fecha_ent_comercial.DataPropertyName = "f12_fecha_entrega_comercial";
            col_id_estado.DataPropertyName = "f11_id";
            col_estado.DataPropertyName = "f11_descripcion";
            dgv_retroplanning.DataSource = retroplanning.ListarRetroplanning();
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
            Task<DataTable> task = Task.Run(() => tipo_dinamica.ListarTiposDinamica(true));
            task.Wait();
            cmb_tipo_dinamica.DataSource = task.Result;
            cmb_tipo_dinamica.ValueMember = "f08_id";
            cmb_tipo_dinamica.DisplayMember = "f08_descripcion";
            cmb_tipo_dinamica.SelectedIndex = -1;
        }

        private void FrmRetroplanning_Load(object sender, EventArgs e)
        {
            try
            {
                this.Top = (this.Parent.ClientSize.Height - this.Height) / 2;
                this.Left = (this.Parent.ClientSize.Width - this.Width) / 2;
                this.Icon = Properties.Resources.plan_24;

                txt_consecutivo.Text = ObtenerConsecutivo(1).ToString().PadLeft(4, '0');
                ListarTiposDinamica();
                ListarNegociadoresDescuentoRetroplanning();
                ListarRetroplanning();
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
            Cursor = Cursors.WaitCursor;
            try
            {
                Retroplanning retroplanning = new Retroplanning();
                Retroplanning.Planning planning = new Retroplanning.Planning();
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

                retroplanning.GuardarRetroplanning(planning);
                Usuarios usuarios = new Usuarios();

                foreach (DataRowView item in clb_negociador.CheckedItems)
                {
                    string to = usuarios.ListarCorreosNegociador(Convert.ToInt32(item[0].ToString()));
                    string subject = $"Nuevo Retroplanning";
                    string body = CrearMensaje(Convert.ToString(item[1]));
                    DescuentoDirecto descuento_directo = new DescuentoDirecto();
                    try
                    {
                        string[] emails = to.Split(';');
                        foreach (string email in emails)
                        {
                            descuento_directo.EnviarCorreo(email, body, subject, null);
                        }
                    }
                    catch (Exception)
                    {
                        descuento_directo.GuardarCorreoPendiente(to, body, subject,"");
                        continue;
                    }
                }

                MessageBox.Show("Retroplanning guardado correctamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ListarRetroplanning();
                txt_consecutivo.Text = ObtenerConsecutivo(1).ToString().PadLeft(4, '0');
                Limpiar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Cursor = Cursors.Default;
        }

        private void dgv_retroplanning_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 10 && e.RowIndex >= 0)
            {
                try
                {
                    Retroplanning retroplanning = new Retroplanning();
                    Retroplanning.Planning planning = new Retroplanning.Planning();
                    planning.Consecutivo = Convert.ToInt32(dgv_retroplanning["col_consecutivo", e.RowIndex].Value);
                    planning.Descripcion = Convert.ToString(dgv_retroplanning["col_dinamica", e.RowIndex].Value);
                    planning.FechaInicialVigencia = Convert.ToDateTime(dgv_retroplanning["col_fecha_ini_vig", e.RowIndex].Value);
                    planning.FechaFinalVigencia = Convert.ToDateTime(dgv_retroplanning["col_fecha_fin_vig", e.RowIndex].Value);
                    planning.Dinamica = Convert.ToInt32(dgv_retroplanning["col_id_tipo_dinamica", e.RowIndex].Value);
                    planning.FechaEntregaMercadeo = Convert.ToDateTime(dgv_retroplanning["col_fecha_ent_mercadeo", e.RowIndex].Value);
                    planning.FechaEntregaComercial = Convert.ToDateTime(dgv_retroplanning["col_fecha_ent_comercial", e.RowIndex].Value);
                    planning.Negociadores = retroplanning.ListarNegociadoresRetroplanning(planning.Consecutivo);

                    new FrmEditarRetroplanning(planning).ShowDialog(this);
                    ListarRetroplanning();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgv_retroplanning_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
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
