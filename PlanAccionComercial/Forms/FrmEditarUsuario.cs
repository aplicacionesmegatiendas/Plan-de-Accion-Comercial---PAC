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
    public partial class FrmEditarUsuario : Form
    {
        Usuarios.Usuario usuario;

        public FrmEditarUsuario(Usuarios.Usuario usuario)
        {
            InitializeComponent();
            this.usuario = usuario;
        }

        private void ListarRoles()
        {
            Roles roles = new Roles();
            cmb_rol.DataSource = roles.ListarRoles(true);
            cmb_rol.ValueMember = "f02_id";
            cmb_rol.DisplayMember = "f02_descripcion";
            cmb_rol.SelectedIndex = -1;
        }

        private void FrmEditarUsuario_Load(object sender, EventArgs e)
        {
            try
            {
                Icon = Properties.Resources.plan_24;
                txt_nombre.Text = usuario.Nombre;
                txt_usuario.Text = usuario.NombUsuario;
                txt_correo.Text = usuario.Email;
                txt_contra.Text = usuario.Contraseña;
                ListarRoles();
                cmb_rol.SelectedValue = usuario.Rol;
                chk_activo.Checked = usuario.Activo;
                chk_negociador.Checked = usuario.Negociador;
                txt_correos_cc.Text = usuario.EmailCC;
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
            if (txt_usuario.Text.Equals("") || txt_nombre.Text.Equals("") || txt_correo.Text.Equals("") || txt_correo.Text.Equals("") /*|| cmb_rol.SelectedIndex == -1*/)
            {
                MessageBox.Show("Escriba todos los datos antes de guardar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                Usuarios usuarios = new Usuarios();
                usuario.Nombre = txt_nombre.Text.Trim();
                usuario.NombUsuario = txt_usuario.Text.Trim();
                usuario.Contraseña = usuarios.Encriptar(txt_contra.Text.Trim());
                usuario.Email = txt_correo.Text.Trim();
                usuario.Rol = cmb_rol.SelectedIndex == -1 ? -1 : Convert.ToInt32(cmb_rol.SelectedValue);
                usuario.Activo = chk_activo.Checked;
                usuario.Negociador = chk_negociador.Checked;
                usuario.EmailCC = txt_correos_cc.Text.Trim();
                usuarios.EditarUsuario(usuario);

                MessageBox.Show("Usuario guardado correctamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmEditarUsuario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F12)
            {
                txt_contra.UseSystemPasswordChar = false;
            }
        }

        private void FrmEditarUsuario_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F12)
            {
                txt_contra.UseSystemPasswordChar = true;
            }
        }

        private void chk_negociador_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_negociador.Checked == true)
            {
                txt_correos_cc.Enabled = true;
                txt_correos_cc.Focus();
            }
            else
            {
                txt_correos_cc.Enabled = false;
                txt_correos_cc.Text = string.Empty;
            }
        }
    }
}
