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
    public partial class FrmEditarCluster : Form
    {
        Clusters.Cluster cluster;
        public FrmEditarCluster(Clusters.Cluster cluster)
        {
            InitializeComponent();
            this.cluster = cluster;
        }

        private void ListarCentrosOperacion(string orden)
        {
            try
            {
                CentrosOperacionListasPrecio clusters = new CentrosOperacionListasPrecio();
                Task<DataTable> task = Task.Run(() => clusters.ListarCentroLista(orden));
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

        private void FrmEditarCluster_Load(object sender, EventArgs e)
        {
            try
            {
                Icon = Properties.Resources.plan_24;
                
                txt_cod.Text = cluster.Codigo;
                txt_desc.Text = cluster.Descripcion;
                chk_activo.Checked = cluster.Activo;
                chk_ppal.Checked = cluster.Principal;
                Clusters clusters = new Clusters();
                
                List<string> cos = clusters.ListarCentrosOperacionCluster(cluster.Codigo);
                string orden = "";
                for (int j = 0; j < cos.Count; j++)
                {
                    orden = orden + "'" + cos[j] + "',";
                }
                ListarCentrosOperacion(orden.Trim(','));
                for (int i = 0; i < clb_co.Items.Count; i++)
                {
                    clb_co.SelectedIndex = i;
                    for (int j = 0; j < cos.Count; j++)
                    {
                        if (Convert.ToString(clb_co.SelectedValue) == cos[j])
                        {
                            clb_co.SetItemChecked(i, true);
                        }
                    }
                }
                clb_co.SelectedIndex = 0;
            }
            
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txt_desc.Text.Trim().Equals("") || clb_co.CheckedItems.Count == 0)
            {
                MessageBox.Show("Escriba los datos del cluster y seleccione los centros de operación", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            try
            {
                Clusters clusters = new Clusters();
                
                cluster.Descripcion = txt_desc.Text.Trim();

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
                cluster.Activo=chk_activo.Checked;
                cluster.Principal=chk_ppal.Checked;
                clusters.EditarCluster(cluster);
                
                MessageBox.Show("Cluster guardado correctamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
