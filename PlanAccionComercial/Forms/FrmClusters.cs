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
	public partial class FrmClusters : Form
	{
		public FrmClusters()
		{
			InitializeComponent();
		}

		private void ListarClusters()
		{
			Clusters clusters = new Clusters();
			dgv_clusters.AutoGenerateColumns = false;
			col_cod.DataPropertyName = "f05_cod";
			col_desc.DataPropertyName = "f05_descripcion";
			col_ppal.DataPropertyName = "f05_principal";
			col_activo.DataPropertyName = "f05_activo";
			Task<DataTable> task = Task.Run(() => clusters.ListarClusters(false));
			task.Wait();
			dgv_clusters.DataSource = task.Result;
		}

		private void ListarCentrosOperacion()
		{
			try
			{
				CentrosOperacionListasPrecio clusters = new CentrosOperacionListasPrecio();
				Task<DataTable> task = Task.Run(() => clusters.ListarCentroLista());
				task.Wait();
				clb_co.DataSource = task.Result;
				clb_co.ValueMember = "f23_id_co";
				clb_co.DisplayMember = "f23_co";
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void FrmClusters_Load(object sender, EventArgs e)
		{
			try
			{
				this.Top = (this.Parent.ClientSize.Height - this.Height) / 2;
				this.Left = (this.Parent.ClientSize.Width - this.Width) / 2;
				ListarCentrosOperacion();
				ListarClusters();
				this.Icon = Properties.Resources.plan_24;
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
			if (txt_cod.Text.Trim().Equals("") || txt_desc.Text.Trim().Equals("") || clb_co.CheckedItems.Count == 0)
			{
				MessageBox.Show("Escriba los datos del cluster y seleccione los centros de operación", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}
			try
			{
				Clusters clusters = new Clusters();
				Clusters.Cluster cluster = new Clusters.Cluster();
				cluster.Codigo = txt_cod.Text.Trim();
				cluster.Descripcion = txt_desc.Text.Trim();
				cluster.Activo = chk_activo.Checked;
				cluster.Principal=chk_ppal.Checked;
				List<string[]> cos = new List<string[]>();
				foreach (object itemChecked in clb_co.CheckedItems)
				{
					string[] co = new string[2];
					DataRowView castedItem = itemChecked as DataRowView;
					co[0] = (string)castedItem["f23_id_co"];
					co[1] = (string)castedItem["f23_co"];
					cos.Add(co);
				}
				cluster.CentrosOperacion = cos;
				clusters.GuardarCluster(cluster);
				ListarClusters();
				MessageBox.Show("Cluster guardado correctamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void dgv_clusters_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.ColumnIndex == 4 && e.RowIndex >= 0)
			{
				try
				{
					Clusters.Cluster cluster = new Clusters.Cluster();
					cluster.Codigo = Convert.ToString(dgv_clusters["col_cod", e.RowIndex].Value);
					cluster.Descripcion = Convert.ToString(dgv_clusters["col_desc", e.RowIndex].Value);
					cluster.Activo = Convert.ToBoolean(dgv_clusters["col_activo", e.RowIndex].Value);
					cluster.Principal= Convert.ToBoolean(dgv_clusters["col_ppal", e.RowIndex].Value);
					new FrmEditarCluster(cluster).ShowDialog(this);
					ListarClusters();
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
					if (MessageBox.Show("¿Confirma eliminar este Cluster?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
					{
						Clusters clusters = new Clusters();
						string codigo = Convert.ToString(dgv_clusters["col_cod", e.RowIndex].Value);
						clusters.EliminarCluster(codigo);
						ListarClusters();
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}


		private void dgv_clusters_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
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
