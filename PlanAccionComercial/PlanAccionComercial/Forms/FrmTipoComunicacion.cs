using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using PlanAccionComercial.Class;

namespace PlanAccionComercial.Forms
{
    public partial class FrmTipoComunicacion : Form
    {
        public FrmTipoComunicacion()
        {
            InitializeComponent();
        }

        private void ListarTiposComunicacion()
        {
            TipoComunicacion tipo_comunicacion = new TipoComunicacion();
            dgv_tipos.AutoGenerateColumns = false;
            col_id.DataPropertyName = "f07_id";
            col_desc.DataPropertyName = "f07_descripcion";
            col_activo.DataPropertyName = "f07_activo";
            col_correo.DataPropertyName = "f07_email";
            Task<DataTable> task = Task.Run(() => tipo_comunicacion.ListarTiposComunicacion());
            task.Wait();
            dgv_tipos.DataSource = task.Result;
        }

        private void FrmTipoComunicacion_Load(object sender, EventArgs e)
        {
            try
            {
                this.Top = (this.Parent.ClientSize.Height - this.Height) / 2;
                this.Left = (this.Parent.ClientSize.Width - this.Width) / 2;
                this.Icon = Properties.Resources.plan_24;
                ListarTiposComunicacion();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txt_desc.Text.Trim().Equals("") || txt_correo.Text.Trim().Equals(""))
            {
                MessageBox.Show("Escriba la descripción y el correo", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            string[] correos = txt_correo.Text.Split(';');
            for (int i = 0; i < correos.Length; i++)
            {
                if (!Regex.IsMatch(correos[i], @"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.IgnoreCase))
                {
                    MessageBox.Show($"El correo {correos[i]} no es valido", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txt_correo.Focus();
                    txt_correo.SelectAll();
                    return;
                }
            }
            try
            {
                TipoComunicacion tipo_comunicacion = new TipoComunicacion();
                TipoComunicacion.Tipo tipo = new TipoComunicacion.Tipo();
                tipo.Descripcion = txt_desc.Text.Trim();
                tipo.Activo = chk_activo.Checked;
                tipo.Correo=txt_correo.Text.Trim();
                tipo_comunicacion.GuardarTipoComunicacion(tipo);
                ListarTiposComunicacion();
                MessageBox.Show("Tipo de comunicación guardado correctamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt_desc.Focus();
                txt_desc.SelectAll();   
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

        private void dgv_tipos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4 && e.RowIndex >= 0)
            {
                try
                {
                    TipoComunicacion.Tipo tipo = new TipoComunicacion.Tipo();
                    tipo.Id = Convert.ToInt32(dgv_tipos["col_id", e.RowIndex].Value);
                    tipo.Descripcion = Convert.ToString(dgv_tipos["col_desc", e.RowIndex].Value);
                    tipo.Activo = Convert.ToBoolean(dgv_tipos["col_activo", e.RowIndex].Value);
                    tipo.Correo= Convert.ToString(dgv_tipos["col_correo", e.RowIndex].Value);
                    new FrmEditarTipoComunicacion(tipo).ShowDialog(this);
                    ListarTiposComunicacion();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
			if (e.ColumnIndex == 5 && e.RowIndex >= 0)
			{
				try
				{
					if (MessageBox.Show("¿Confirma eliminar este Tipo de comunicación?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
					{
						TipoComunicacion tipo_com = new TipoComunicacion();
						int id = Convert.ToInt32(dgv_tipos["col_id", e.RowIndex].Value);
						tipo_com.EliminarTipoComunicacion(id);
						ListarTiposComunicacion();
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}

        private void dgv_tipos_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
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
