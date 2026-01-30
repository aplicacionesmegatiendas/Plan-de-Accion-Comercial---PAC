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
using static PlanAccionComercial.Class.Permisos;

namespace PlanAccionComercial.Forms
{
    public partial class FrmDescuentosRetroplanning : Form
    {
        DataTable dt_plan = null;
        DataTable dt_criterio = null;

        public FrmDescuentosRetroplanning()
        {
            InitializeComponent();
        }

        private void LimpiarDescuento()
        {
            txt_consecutivo.Text = string.Empty;
            txt_nombre.Text = string.Empty;
            
            txt_tipo_dinamica.Text = string.Empty;
       
            cmb_periodicidad.SelectedIndex = -1;

            for (int i = 0; i < clb_tipo_comunicacion.Items.Count; i++)
            {
                clb_tipo_comunicacion.SetItemChecked(i, false);
            }
        }

        private void LimpiarDetalle()
        {
            txt_item.Text = string.Empty;
            txt_ref.Text = string.Empty;
            txt_descripcion.Text = string.Empty;
            txt_marca.Text = string.Empty;
            txt_um.Text = string.Empty;
            txt_precio.Text = string.Empty;
            txt_pum.Text = string.Empty;
            txt_existencia.Text = string.Empty;
            txt_descuento.Text = string.Empty;
            txt_porc_prov.Text = string.Empty;
            txt_porc_mega.Text = string.Empty;
            cmb_cluster.SelectedIndex = -1;
            cmb_co.SelectedIndex = -1;
        }

        private void ListarPlanes()
        {
            DescuentoRetroplanning descuento = new DescuentoRetroplanning();
            Task<DataTable> task = Task.Run(() => descuento.ListarPlanes());
            task.Wait();
            dt_plan = task.Result;
            cmb_plan.DataSource = dt_plan;
            cmb_plan.DisplayMember = "f105_descripcion";
            cmb_plan.ValueMember = "f105_id";
            cmb_plan.SelectedIndex = -1;
            cmb_plan.SelectedIndexChanged += Cmb_plan_SelectedIndexChanged;
        }

        private void Cmb_plan_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ListarCriterios(Convert.ToString(cmb_plan.SelectedValue));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ListarCriterios(string id_plan)
        {
            DescuentoRetroplanning descuento = new DescuentoRetroplanning();
            Task<DataTable> task = Task.Run(() => descuento.ListarCriterios(id_plan));
            task.Wait();
            dt_criterio = task.Result;
            cmb_criterio.DataSource = dt_criterio;
            cmb_criterio.DisplayMember = "f106_descripcion";
            cmb_criterio.ValueMember = "f106_id";
            cmb_criterio.SelectedIndex = -1;
        }

        private void ListarTiposComunicacion()
        {
            TipoComunicacion tipo_comunicacion = new TipoComunicacion();
            Task<DataTable> task = Task.Run(() => tipo_comunicacion.ListarTiposComunicacion(true));
            task.Wait();
            clb_tipo_comunicacion.DataSource = task.Result;
            clb_tipo_comunicacion.ValueMember = "f07_id";
            clb_tipo_comunicacion.DisplayMember = "f07_descripcion";
            clb_tipo_comunicacion.SelectedIndex = -1;
        }

        private void ListarClusters()
        {
            Clusters clusters = new Clusters();
            Task<DataTable> task = Task.Run(() => clusters.ListarClusters(true));
            task.Wait();
            cmb_cluster.DataSource = task.Result;
            cmb_cluster.ValueMember = "f05_cod";
            cmb_cluster.DisplayMember = "f05_descripcion";
            cmb_cluster.SelectedIndex = -1;
            cmb_cluster.SelectedIndexChanged += Cmb_cluster_SelectedIndexChanged;
        }

        private void Cmb_cluster_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (rdb_item.Checked)
                    if (cmb_cluster.SelectedIndex >= 0)
                    {
                        Cursor = Cursors.WaitCursor;
                        cmb_co.SelectedIndex = -1;
                        txt_precio.Text = "";
                        txt_pum.Text = "";
                        txt_existencia.Text = "";

                        DescuentoRetroplanning descuento = new DescuentoRetroplanning();
                        List<string> res = descuento.ObtenerCoCluster(cmb_cluster.SelectedValue.ToString());
                        if (res != null)
                        {
                            string cos = "";
                            foreach (string item in res)
                            {
                                cos += $"'{item}',";
                            }
                            List<object[]> data = descuento.ObtenerDatosItemCo(txt_item.Text.Trim(), cos.Trim(','));
                            if (data != null)
                            {
                                new FrmPrecios(data, this, cmb_cluster.Text).ShowDialog(this);
                            }
                        }
                        Cursor = Cursors.Default;
                    }
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ListarCentrosOperacion()
        {
            try
            {
                CentrosOperacionListasPrecio clusters = new CentrosOperacionListasPrecio();
                Task<DataTable> task = Task.Run(() => clusters.ListarCentroLista());
                task.Wait();
                cmb_co.DataSource = task.Result;
                cmb_co.ValueMember = "f23_id_co";
                cmb_co.DisplayMember = "f23_co";
                cmb_co.SelectedIndex = -1;
                cmb_co.SelectedIndexChanged += Cmb_co_SelectedIndexChanged;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ObtenerDatosItem(string item_ref)
        {
            try
            {
                DescuentoRetroplanning descuento = new DescuentoRetroplanning();
                string[] data = descuento.ObtenerDatosItem(item_ref);
                if (data != null)
                {
                    txt_item.Text = data[0].Trim();
                    txt_ref.Text = data[1].Trim();
                    txt_descripcion.Text = data[2].Trim();
                    txt_marca.Text = data[3].Trim();
                    txt_um.Text = data[4].Trim();
                }
                else
                {
                    MessageBox.Show("El ítem no existe", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Cmb_co_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (rdb_item.Checked)
                    if (cmb_co.SelectedIndex >= 0)
                    {
                        Cursor = Cursors.WaitCursor;
                        txt_precio.Text = "";
                        txt_pum.Text = "";
                        txt_existencia.Text = "";

                        cmb_cluster.SelectedIndex = -1;
                        DescuentoRetroplanning descuento = new DescuentoRetroplanning();
                        List<object[]> data = descuento.ObtenerDatosItemCo(txt_item.Text.Trim(), $"'{cmb_co.SelectedValue.ToString()}'");
                        if (data != null)
                        {
                            txt_precio.Text = (Math.Truncate(100 * Convert.ToDecimal(data[0][1])) / 100).ToString();
                            txt_pum.Text = data[0][2].ToString();
                            txt_existencia.Text = (Math.Truncate(100 * Convert.ToDecimal(data[0][3])) / 100).ToString();
                        }
                        Cursor = Cursors.Default;
                    }
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmDescuentosRetroplanning_Load(object sender, EventArgs e)
        {
            try
            {
                Icon = Properties.Resources.plan_24;
                this.Top = (this.Parent.ClientSize.Height - this.Height) / 2;
                this.Left = (this.Parent.ClientSize.Width - this.Width) / 2;
                lbl_usuario.Text = Usuarios.NombreUsuario;

                ListarTiposComunicacion();
                ListarPlanes();
                ListarClusters();
                ListarCentrosOperacion();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erorr", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_cargar_retro_Click(object sender, EventArgs e)
        {
            try
            {
                new FrmCargarRetroplanning(this).ShowDialog(this);

                if (!txt_consecutivo.Text.Equals(""))
                {
                    //dtp_fecha_ini_desc.MinDate = Convert.ToDateTime(txt_fecha_ini_vig.Text);
                    //dtp_fecha_ini_desc.MaxDate = Convert.ToDateTime(txt_fecha_fin_vig.Text);
                    //dtp_fecha_ini_desc.Value = Convert.ToDateTime(txt_fecha_ini_vig.Text);

                    //dtp_fecha_fin_desc.MinDate = Convert.ToDateTime(txt_fecha_ini_vig.Text);
                    //dtp_fecha_fin_desc.MaxDate = Convert.ToDateTime(txt_fecha_fin_vig.Text);
                    //dtp_fecha_fin_desc.Value = Convert.ToDateTime(txt_fecha_fin_vig.Text);

                    DescuentoRetroplanning descuento_retroplanning = new DescuentoRetroplanning();
                    object[] desc = descuento_retroplanning.ObtenerDatosDescuento(Convert.ToInt32(txt_consecutivo.Text));
                    int id_descuento = -1;
                    if (desc != null)
                    {
                        id_descuento = Convert.ToInt32(desc[0]);
                        cmb_periodicidad.Text = Convert.ToString(desc[1]).Trim();

                        List<int> tipo_com = descuento_retroplanning.ObtenerTiposComunicacionDescuento(id_descuento);
                        for (int i = 0; i < clb_tipo_comunicacion.Items.Count; i++)
                        {
                            clb_tipo_comunicacion.SelectedIndex = i;
                            for (int j = 0; j < tipo_com.Count; j++)
                            {
                                if (Convert.ToInt32(clb_tipo_comunicacion.SelectedValue) == tipo_com[j])
                                {
                                    clb_tipo_comunicacion.SetItemChecked(i, true);
                                }
                            }
                        }

                        DataTable dt = descuento_retroplanning.ObtenerDetalleDescuento(id_descuento);
                        if (dt != null)
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                dgv_descuentos.Rows.Add(dt.Rows[i]["f16_tipo"], dt.Rows[i]["f16_item"], dt.Rows[i]["f16_referencia"], dt.Rows[i]["f16_descripcion"],
                                                        dt.Rows[i]["f16_marca_item"], dt.Rows[i]["f16_um"], dt.Rows[i]["f16_precio"], dt.Rows[i]["f16_pum"],
                                                        dt.Rows[i]["f16_existencia"], dt.Rows[i]["f16_id_plan"], dt.Rows[i]["f16_plan"], dt.Rows[i]["f16_id_criterio"],
                                                        dt.Rows[i]["f16_criterio"], dt.Rows[i]["f16_tipo_descuento"], dt.Rows[i]["f16_descuento"], dt.Rows[i]["f16_porc_proveedor"], dt.Rows[i]["f16_porc_megatiendas"],
                                                        dt.Rows[i]["f16_fecha_ini_desc"], dt.Rows[i]["f16_fecha_fin_desc"], dt.Rows[i]["f05_cod"], dt.Rows[i]["f05_descripcion"], dt.Rows[i]["f16_id_co"], dt.Rows[i]["f16_co"]);
                            }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rdb_item_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb_item.Checked)
            {
                pnl_item.Visible = true;
                pnl_plan.Visible = false;
            }
        }

        private void rdb_plan_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb_plan.Checked)
            {
                pnl_item.Visible = false;
                pnl_plan.Visible = true;
            }
        }

        private void btn_agregar_Click(object sender, EventArgs e)
        {
            try
            {
                int tipo = 0;
                if (rdb_item.Checked)
                {
                    if (txt_descripcion.Text.Equals(""))
                    {
                        MessageBox.Show("Busque la información del ítem", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    tipo = 1;
                    string item = null;
                    string referencia = null;
                    string cod_cluster = null;
                    string cluster = null;
                    string id_co = null;
                    string co = null;
                    item = txt_item.Text;
                    referencia = txt_ref.Text;
                    char tipo_desc = rdb_desc_porc.Checked ? 'P' : 'V';
                    if (txt_descuento.Text.Equals("") || txt_porc_prov.Text.Equals("") || txt_porc_mega.Text.Equals("") || (cmb_cluster.SelectedIndex == -1 && cmb_co.SelectedIndex == -1))
                    {
                        MessageBox.Show("Escriba los valores de descuento y seleccione el cluster o centro de operación", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    if (tipo_desc == 'P')
                    {
                        if (Convert.ToDecimal(txt_porc_prov.Text) + Convert.ToDecimal(txt_porc_mega.Text) > Convert.ToInt32(txt_descuento.Text))
                        {
                            MessageBox.Show($"Los valores de porcentaje asumido por el proveedor y Megatiendas suman mas del {txt_descuento.Text}%", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }
                        if (Convert.ToDecimal(txt_porc_prov.Text) + Convert.ToDecimal(txt_porc_mega.Text) < Convert.ToInt32(txt_descuento.Text))
                        {
                            MessageBox.Show($"Los valores de porcentaje asumido por el proveedor y Megatiendas suman menos del {txt_descuento.Text}%", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }
                    }
                    if (cmb_cluster.SelectedIndex >= 0)
                    {
                        cod_cluster = cmb_cluster.SelectedValue.ToString();
                        cluster = cmb_cluster.Text.ToString();
                    }
                    if (cmb_co.SelectedIndex >= 0)
                    {
                        id_co = cmb_co.SelectedValue.ToString();
                        co = cmb_co.Text.ToString();
                    }

                    dgv_descuentos.Rows.Add(tipo, item, referencia, txt_descripcion.Text, txt_marca.Text, txt_um.Text, txt_precio.Text,
                                            txt_pum.Text, txt_existencia.Text, null, null, null, null, tipo_desc, txt_descuento.Text, txt_porc_prov.Text,
                                            txt_porc_mega.Text, dtp_fecha_ini_desc.Value.Date.ToString("yyyyMMdd"), dtp_fecha_fin_desc.Value.Date.ToString("yyyyMMdd"),
                                            cod_cluster, cluster, id_co, co);
                }

                if (rdb_plan.Checked)
                {
                    if (cmb_plan.SelectedIndex == -1 || cmb_criterio.SelectedIndex == -1)
                    {
                        MessageBox.Show("Seleccione el Plan y el Criterio", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    tipo = 2;

                    string id_plan = cmb_plan.SelectedValue.ToString();
                    string plan = cmb_plan.Text;

                    string id_criterio = cmb_criterio.SelectedValue.ToString();
                    string criterio = cmb_criterio.Text;

                    string cod_cluster = null;
                    string cluster = null;
                    string id_co = null;
                    string co = null;

                    if (cmb_cluster.SelectedIndex >= 0)
                    {
                        cod_cluster = cmb_cluster.SelectedValue.ToString();
                        cluster = cmb_cluster.Text.ToString();
                    }
                    if (cmb_co.SelectedIndex >= 0)
                    {
                        id_co = cmb_co.SelectedValue.ToString();
                        co = cmb_co.Text.ToString();
                    }
                    char tipo_desc = rdb_desc_porc.Checked ? 'P' : 'V';
                    dgv_descuentos.Rows.Add(tipo, null, null, null, null, null, null,
                                            null, null, id_plan, plan, id_criterio, criterio, tipo_desc, txt_descuento.Text, txt_porc_prov.Text,
                                            txt_porc_mega.Text, dtp_fecha_ini_desc.Value.Date.ToString("yyyyMMdd"), dtp_fecha_fin_desc.Value.Date.ToString("yyyyMMdd"),
                                            cod_cluster, cluster, id_co, co);
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

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            if (txt_consecutivo.Text == "")
            {
                MessageBox.Show("Cargue el retroplanning", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                btn_cargar_retro.Focus();
                return;
            }
            if (cmb_periodicidad.SelectedIndex == -1 || clb_tipo_comunicacion.CheckedItems.Count == 0)
            {
                MessageBox.Show("Seleccione la Periodicidad, el Tipo de dinámica y el Tipo de comunicación", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (dgv_descuentos.Rows.Count == 0)
            {
                MessageBox.Show("No hay información para guardar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Cursor = Cursors.WaitCursor;
            try
            {
                DescuentoRetroplanning descuento_retroplanning = new DescuentoRetroplanning();
                DescuentoRetroplanning.Descuento descuento = new DescuentoRetroplanning.Descuento();
                List<DescuentoRetroplanning.Descuento.Detalle> detalles = new List<DescuentoRetroplanning.Descuento.Detalle>();

                descuento.ConsecutivoRetroplanning = Convert.ToInt32(txt_consecutivo.Text);
                descuento.Periodicidad = cmb_periodicidad.Text;

                List<int> ints = new List<int>();
                foreach (DataRowView item in clb_tipo_comunicacion.CheckedItems)
                {
                    ints.Add((int)item[0]);
                }
                descuento.TipoComunicacion = ints;
                foreach (DataGridViewRow item in dgv_descuentos.Rows)
                {
                    DescuentoRetroplanning.Descuento.Detalle detalle = new DescuentoRetroplanning.Descuento.Detalle();
                    detalle.Tipo = Convert.ToInt32(item.Cells["col_tipo"].Value);
                    detalle.Item = Convert.ToString(item.Cells["col_item"].Value);
                    detalle.Referencia = Convert.ToString(item.Cells["col_ref"].Value);
                    detalle.Descripcion = Convert.ToString(item.Cells["col_desc"].Value);
                    detalle.MarcaItem = Convert.ToString(item.Cells["col_marca_item"].Value);
                    detalle.UndMedida = Convert.ToString(item.Cells["col_um"].Value);
                    decimal.TryParse(Convert.ToString(item.Cells["col_precio"].Value), out decimal precio);
                    detalle.Precio = precio;
                    decimal.TryParse(Convert.ToString(item.Cells["col_pum"].Value), out decimal pum);
                    detalle.PUM = pum;
                    decimal.TryParse(Convert.ToString(item.Cells["col_existencia"].Value), out decimal existencia);
                    detalle.Existencia = existencia;
                    detalle.IdPlan = Convert.ToString(item.Cells["col_id_plan"].Value);
                    detalle.Plan = Convert.ToString(item.Cells["col_plan"].Value);
                    detalle.IdCriterio = Convert.ToString(item.Cells["col_id_criterio"].Value);
                    detalle.Criterio = Convert.ToString(item.Cells["col_criterio"].Value);
                    detalle.TipoDescuento = Convert.ToChar(item.Cells["col_tipo_desc"].Value);
                    detalle.Descuento = Convert.ToDecimal(item.Cells["col_descuento"].Value);
                    detalle.AsumeProveedor = Convert.ToDecimal(item.Cells["col_porc_prov"].Value);
                    detalle.AsumeMegatiendas = Convert.ToInt32(item.Cells["col_porc_mega"].Value);
                    detalle.FechaInicialDescuento = Convert.ToString(item.Cells["col_fecha_ini"].Value);
                    detalle.FechaFinalDescuento = Convert.ToString(item.Cells["col_fecha_fin"].Value);
                    int.TryParse(Convert.ToString(item.Cells["col_cod_cluster"].Value), out int cluster);
                    detalle.Cluster = cluster;
                    detalle.IdCentroOperacion = Convert.ToString(item.Cells["col_id_co"].Value);
                    detalle.CentroOperacion = Convert.ToString(item.Cells["col_co"].Value);
                    detalles.Add(detalle);
                }
                descuento_retroplanning.GuardarDescuento(descuento, detalles);
                MessageBox.Show("Descuento guardado correctamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                int[] nro_descuentos = descuento_retroplanning.VerificarDescuentosNegociadores(Convert.ToInt32(txt_consecutivo.Text));
                if (nro_descuentos != null)
                {
                    Retroplanning retroplanning = new Retroplanning();
                    if (nro_descuentos[1] < nro_descuentos[0])
                    {
                        retroplanning.CambiarEstadoRetroplanning(2, Convert.ToInt32(txt_consecutivo.Text));
                    }
                    if (nro_descuentos[1] == nro_descuentos[0])
                    {
                        retroplanning.CambiarEstadoRetroplanning(3, Convert.ToInt32(txt_consecutivo.Text));
                    }
                }
                Usuarios usuario = new Usuarios();
                DataTable lst_correos = usuario.ListarCorreosNotificacionDescuento(true);
                if (lst_correos != null)
                {
                    foreach (DataRow item in lst_correos.Rows)
                    {
                        //descuento_retroplanning.EnviarCorreo(Usuarios.Email, item["f09_email"].ToString(), "xxxxxx", "notificacion");
                    }
                }
                LimpiarDescuento();
                LimpiarDetalle();
                dgv_descuentos.DataSource = null;
                dgv_descuentos.Rows.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Cursor = Cursors.Default;
        }

        private void txt_item_ref_Leave(object sender, EventArgs e)
        {
            try
            {
                if (!txt_item.Text.Trim().Equals(""))
                {
                    txt_ref.Text = "";
                    txt_descripcion.Text = "";
                    txt_marca.Text = "";
                    txt_um.Text = "";
                    txt_precio.Text = "";
                    txt_pum.Text = "";
                    txt_existencia.Text = "";
                    cmb_cluster.SelectedIndex = -1;
                    cmb_co.SelectedIndex = -1;

                    ObtenerDatosItem(txt_item.Text);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgv_descuentos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_descuentos.Columns[e.ColumnIndex].Name == "col_quitar" && e.RowIndex >= 0)
            {
                try
                {
                    dgv_descuentos.Rows.RemoveAt(e.RowIndex);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txt_buscar_criterio_TextChanged(object sender, EventArgs e)
        {
            try
            {
                dt_criterio.DefaultView.RowFilter = "f106_descripcion Like'%" + txt_buscar_criterio.Text + "%'";
                cmb_criterio.DroppedDown = true;
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txt_buscar_plan_TextChanged(object sender, EventArgs e)
        {
            try
            {
                dt_plan.DefaultView.RowFilter = "f105_descripcion Like'%" + txt_buscar_plan.Text + "%'";
                cmb_plan.DroppedDown = true;
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chk_tipo_com_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < clb_tipo_comunicacion.Items.Count; i++)
            {
                clb_tipo_comunicacion.SetItemChecked(i, chk_tipo_com.Checked);
            }
        }

        private void FrmDescuentosRetroplanning_Resize(object sender, EventArgs e)
        {
            try
            {
                if (this.WindowState == FormWindowState.Maximized)
                {
                    col_desc.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    return;
                }
                col_desc.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                col_desc.Width = 150;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
        }
    }
}
