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
    public partial class FrmCentrosOperacionListaPrecios : Form
    {
        public FrmCentrosOperacionListaPrecios()
        {
            InitializeComponent();
        }

        private void ListarCentrosOperacion()
        {
            try
            {
                CentrosOperacionListasPrecio centros_listas = new CentrosOperacionListasPrecio();
                Task<DataTable> task = Task.Run(() => centros_listas.ListarCentrosOperacion());
                task.Wait();
                cmb_co.DataSource = task.Result;
                cmb_co.ValueMember = "f157_id";
                cmb_co.DisplayMember = "f157_descripcion";
                cmb_co.SelectedIndex = -1;
                cmb_co.SelectedIndexChanged += Cmb_co_SelectedIndexChanged;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ObtenerListasPrecio(string co)
        {
            Clusters clusters = new Clusters();
            cmb_lp.DataSource = clusters.ObtenerListasPrecio(co);
            cmb_lp.DisplayMember = "f112_descripcion";
            cmb_lp.ValueMember = "f112_id";
            cmb_lp.SelectedIndex = -1;
        }

        private void ListarCentroLista()
        {
            CentrosOperacionListasPrecio centros_listas = new CentrosOperacionListasPrecio();
            dgv_centro_lista.AutoGenerateColumns = false;
            col_id.DataPropertyName = "f23_id";
            col_id_co.DataPropertyName = "f23_id_co";
            col_co.DataPropertyName = "f23_co";
            col_lp.DataPropertyName = "f23_lp";
            dgv_centro_lista.DataSource = centros_listas.ListarCentroLista();
        }

        private void Cmb_co_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ObtenerListasPrecio(cmb_co.SelectedValue.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmCentrosOperacionListaPrecios_Load(object sender, EventArgs e)
        {
            try
            {
                this.Top = (this.Parent.ClientSize.Height - this.Height) / 2;
                this.Left = (this.Parent.ClientSize.Width - this.Width) / 2;

                this.Icon = Properties.Resources.plan_24;
                ListarCentrosOperacion();
                ListarCentroLista();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            if (cmb_co.SelectedIndex == -1 || cmb_lp.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione el Centro de operación y la Lista de precios", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            try
            {
                CentrosOperacionListasPrecio centros_listas = new CentrosOperacionListasPrecio();
                CentrosOperacionListasPrecio.CentroLista centro_lista = new CentrosOperacionListasPrecio.CentroLista();
                centro_lista.CentroOperacion = cmb_co.Text;
                centro_lista.IdCentroOperacion = cmb_co.SelectedValue.ToString();
                centro_lista.ListaPrecio = cmb_lp.SelectedValue.ToString();
                centros_listas.GuardarCentroLista(centro_lista);
                ListarCentroLista();
                MessageBox.Show("Centro de operación y Lista de precio guardados correctamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgv_centro_lista_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4 && e.RowIndex >= 0)
            {
                try
                {
                    if (MessageBox.Show("¿Confirma eliminar el registro?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        CentrosOperacionListasPrecio centros_listas = new CentrosOperacionListasPrecio();
                        int id = Convert.ToInt32(dgv_centro_lista[0, e.RowIndex].Value);
                        centros_listas.EliminarCentroLista(id);
                        ListarCentroLista();
                        MessageBox.Show("Registro eliminado correctamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void dgv_centro_lista_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
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
