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
    public partial class FrmUsuarios : Form
    {
        public FrmUsuarios()
        {
            InitializeComponent();
        }

        private void Limpiar()
        {
            txt_nombre.Text = "";
            txt_usuario.Text = "";
            txt_correo.Text = "";
            txt_contra.Text = "";
            cmb_rol.SelectedIndex = -1;
        }

        private void ListarUsuarios()
        {
            Usuarios usuarios = new Usuarios();
            col_id_usuario.DataPropertyName = "f04_id";
            col_usuario.DataPropertyName = "f04_usuario";
            col_nombre.DataPropertyName = "f04_nombre";
            col_email.DataPropertyName = "f04_email";
            col_email_cc.DataPropertyName = "f04_email_cc";
            col_contra.DataPropertyName = "f04_contraseña";
            col_id_rol.DataPropertyName = "f02_id";
            col_rol.DataPropertyName = "f02_descripcion";
            col_activo.DataPropertyName = "f04_activo";
            col_negociador.DataPropertyName = "f04_negociador";
            dgvUsuarios.AutoGenerateColumns = false;
            DataTable dt_usuarios=usuarios.ListarUsuarios();
            foreach (DataRow row in dt_usuarios.Rows)
            {
                row["f04_contraseña"] = usuarios.Desencriptar(row["f04_contraseña"].ToString());
            }
            dgvUsuarios.DataSource = dt_usuarios;
        }

        private void ListarRoles()
        {
            Roles roles = new Roles();
            cmb_rol.DataSource = roles.ListarRoles(true);
            cmb_rol.ValueMember = "f02_id";
            cmb_rol.DisplayMember = "f02_descripcion";
            cmb_rol.SelectedIndex = -1;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmUsuarios_Load(object sender, EventArgs e)
        {
            try
            {
                this.Top = (this.Parent.ClientSize.Height - this.Height) / 2;
                this.Left = (this.Parent.ClientSize.Width - this.Width) / 2;
                ListarRoles();
                ListarUsuarios();
                this.Icon = Properties.Resources.plan_24;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txt_usuario.Text.Equals("") || txt_nombre.Text.Equals("") || txt_correo.Text.Equals("") || txt_correo.Text.Equals("") /*|| cmb_rol.SelectedIndex == -1*/)
            {
                MessageBox.Show("Escriba todos los datos antes de guardar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
            if (chk_negociador.Checked == true)
            {
                if (!txt_correos_cc.Text.Equals(""))
                {
                    string[] correos_cc = txt_correos_cc.Text.Split(';');
                    for (int i = 0; i < correos_cc.Length; i++)
                    {
                        if (!Regex.IsMatch(correos_cc[i], @"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.IgnoreCase))
                        {
                            MessageBox.Show($"El correo {correos_cc[i]} no es valido", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            txt_correos_cc.Focus();
                            txt_correos_cc.SelectAll();
                            return;
                        }
                    }
                }
            }
            try
            {
                Usuarios.Usuario usuario = new Usuarios.Usuario();
                Usuarios usuarios = new Usuarios();
                usuario.Nombre = txt_nombre.Text.Trim();
                usuario.NombUsuario = txt_usuario.Text.Trim();
                usuario.Contraseña = usuarios.Encriptar(txt_contra.Text.Trim());
                usuario.Email = txt_correo.Text.Trim();
                usuario.Rol = cmb_rol.SelectedIndex == -1 ? -1 : Convert.ToInt32(cmb_rol.SelectedValue);
                usuario.EmailCC = txt_correos_cc.Text.Trim();
                usuario.Activo = chk_activo.Checked;
                usuario.Negociador = chk_negociador.Checked;
                usuarios.GuardarUsuario(usuario);
                Limpiar();
                ListarUsuarios();

                MessageBox.Show("Usuario guardado correctamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 10 && e.RowIndex >= 0)
            {
                try
                {
                    Usuarios usuarios = new Usuarios();
                    Usuarios.Usuario usuario = new Usuarios.Usuario();
                    usuario.Id = Convert.ToInt32(dgvUsuarios["col_id_usuario", e.RowIndex].Value);
                    usuario.Nombre = Convert.ToString(dgvUsuarios["col_nombre", e.RowIndex].Value);
                    usuario.NombUsuario = Convert.ToString(dgvUsuarios["col_usuario", e.RowIndex].Value);
                    usuario.Contraseña = Convert.ToString(dgvUsuarios["col_contra", e.RowIndex].Value);
                    usuario.Email = Convert.ToString(dgvUsuarios["col_email", e.RowIndex].Value);
                    usuario.Rol = Convert.IsDBNull(dgvUsuarios["col_id_rol", e.RowIndex].Value) ? -1 : Convert.ToInt32(dgvUsuarios["col_id_rol", e.RowIndex].Value);
                    usuario.EmailCC = Convert.ToString(dgvUsuarios["col_email_cc", e.RowIndex].Value);
                    usuario.Activo = Convert.ToBoolean(dgvUsuarios["col_activo", e.RowIndex].Value);
                    usuario.Negociador = Convert.ToBoolean(dgvUsuarios["col_negociador", e.RowIndex].Value);
                    new FrmEditarUsuario(usuario).ShowDialog(this);

                    ListarUsuarios();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void chk_negociador_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_negociador.Checked==true)
            {
                txt_correos_cc.Enabled = true;
                txt_correos_cc.Focus();
            }
            else
            {
                txt_correos_cc.Enabled = false;
                txt_correos_cc.Text= string.Empty;
            }
        }

        private void dgvUsuarios_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
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
