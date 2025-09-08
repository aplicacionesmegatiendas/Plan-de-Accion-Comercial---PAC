using PlanAccionComercial.Class;
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

namespace PlanAccionComercial.Forms
{
	public partial class FrmTipoExhibicion : Form
	{
		public FrmTipoExhibicion()
		{
			InitializeComponent();
		}

		private void ListarTiposExhibicion()
		{
			TipoExhibicion tipo_exhibicion = new TipoExhibicion();
			dgv_tipos.AutoGenerateColumns = false;
			col_id.DataPropertyName = "f21_id";
			col_desc.DataPropertyName = "f21_descripcion";
			col_activo.DataPropertyName = "f21_activo";
			Task<DataTable> task = Task.Run(() => tipo_exhibicion.ListarTiposExhibicion());
			task.Wait();
			dgv_tipos.DataSource = task.Result;
		}

		private void FrmTipoExhibicion_Load(object sender, EventArgs e)
		{
			try
			{
				this.Top = (this.Parent.ClientSize.Height - this.Height) / 2;
				this.Left = (this.Parent.ClientSize.Width - this.Width) / 2;
				this.Icon = Properties.Resources.plan_24;
				ListarTiposExhibicion();
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
				return;
			}

			try
			{
				TipoExhibicion tipo_exhibicion = new TipoExhibicion();
				TipoExhibicion.Tipo tipo = new TipoExhibicion.Tipo();
				tipo.Descripcion = txt_desc.Text.Trim();
				tipo.Activo = chk_activo.Checked;
				tipo_exhibicion.GuardarTipoExhibicion(tipo);
				ListarTiposExhibicion();
				MessageBox.Show("Tipo de exhibición guardado correctamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
			if (e.ColumnIndex == 3 && e.RowIndex >= 0)
			{
				try
				{
					TipoExhibicion.Tipo tipo = new TipoExhibicion.Tipo();
					tipo.Id = Convert.ToInt32(dgv_tipos["col_id", e.RowIndex].Value);
					tipo.Descripcion = Convert.ToString(dgv_tipos["col_desc", e.RowIndex].Value);
					tipo.Activo = Convert.ToBoolean(dgv_tipos["col_activo", e.RowIndex].Value);
					new FrmEditarTipoExhibicion(tipo).ShowDialog(this);
					ListarTiposExhibicion();
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
					if (MessageBox.Show("¿Confirma eliminar este Tipo de exhibición?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
					{
						TipoExhibicion tipo_exh = new TipoExhibicion();
						int id = Convert.ToInt32(dgv_tipos["col_id", e.RowIndex].Value);
						tipo_exh.EliminarTipoExhibicion(id);
						ListarTiposExhibicion();
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
