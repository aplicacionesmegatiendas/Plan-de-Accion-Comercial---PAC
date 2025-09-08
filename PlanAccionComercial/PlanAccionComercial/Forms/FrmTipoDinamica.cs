using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PlanAccionComercial.Class;

namespace PlanAccionComercial.Forms
{
	public partial class FrmTipoDinamica : Form
	{
		public FrmTipoDinamica()
		{
			InitializeComponent();
		}

		private void ListarTiposDinamica()
		{
			TipoDinamica tipo_dinamica = new TipoDinamica();
			dgv_tipos.AutoGenerateColumns = false;
			col_id.DataPropertyName = "f08_id";
			col_desc.DataPropertyName = "f08_descripcion";
			col_activo.DataPropertyName = "f08_activo";
			Task<DataTable> task = Task.Run(() => tipo_dinamica.ListarTiposDinamica());
			task.Wait();
			dgv_tipos.DataSource = task.Result;
		}

		private void FrmTipoDinamica_Load(object sender, EventArgs e)
		{
			try
			{
				this.Top = (this.Parent.ClientSize.Height - this.Height) / 2;
				this.Left = (this.Parent.ClientSize.Width - this.Width) / 2;
				this.Icon = Properties.Resources.plan_24;
				ListarTiposDinamica();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void btnGuardar_Click(object sender, EventArgs e)
		{
			if (txt_desc.Text.Trim().Equals(""))
			{
				MessageBox.Show("Escriba la descripción", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				txt_desc.Focus();
				txt_desc.SelectAll();
				return;
			}
			try
			{
				TipoDinamica tipo_dinamica = new TipoDinamica();
				TipoDinamica.Tipo tipo = new TipoDinamica.Tipo();
				tipo.Descripcion = txt_desc.Text.Trim();
				tipo.Activo = chk_activo.Checked;
				tipo_dinamica.GuardarTipoDinamica(tipo);
				ListarTiposDinamica();
				MessageBox.Show("Tipo de dinámica guardado correctamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
				txt_desc.Focus();
				txt_desc.SelectAll();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void dgv_tipos_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.ColumnIndex == 3 && e.RowIndex >= 0)
			{
				try
				{
					TipoDinamica.Tipo tipo = new TipoDinamica.Tipo();
					tipo.Id = Convert.ToInt32(dgv_tipos["col_id", e.RowIndex].Value);
					tipo.Descripcion = Convert.ToString(dgv_tipos["col_desc", e.RowIndex].Value);
					tipo.Activo = Convert.ToBoolean(dgv_tipos["col_activo", e.RowIndex].Value);
					new FrmEditarTipoDinamica(tipo).ShowDialog(this);
					ListarTiposDinamica();
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
			if (e.ColumnIndex == 4 && e.RowIndex >= 0)
			{
				try
				{
					if (MessageBox.Show("¿Confirma eliminar este Tipo de dinámica?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
					{
						TipoDinamica tipo_dinamica = new TipoDinamica();
						int id = Convert.ToInt32(dgv_tipos["col_id", e.RowIndex].Value);
						tipo_dinamica.EliminarTipoDinamica(id);
						ListarTiposDinamica();
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}

		private void btnCerrar_Click(object sender, EventArgs e)
		{
			Close();
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
