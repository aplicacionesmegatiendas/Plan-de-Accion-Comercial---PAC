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
    public partial class FrmSesion : Form
    {
        int contador = 0;
        public FrmSesion()
        {
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (txt_usuario.Text.Trim().Equals("") || txt_contraseña.Text.Trim().Equals(""))
            {
                MessageBox.Show("Escriba el nombre de usuario y la contraseña", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            try
            {
                Usuarios usuario = new Usuarios();
                object[] res = usuario.IniciarSesion(txt_usuario.Text.Trim(), usuario.Encriptar(txt_contraseña.Text.Trim()));
                
                if (res != null)
                {
                    if (Convert.ToInt32(res[2]) == 1)
                    {
                        Task<List<string>> task_permisos = Task.Run(() => usuario.ObtenerPermisosUsuario(Convert.IsDBNull(res[1])?-1: Convert.ToInt32(res[1])));
                        task_permisos.Wait();
                        List<string> permisos = task_permisos.Result;
                        if (permisos == null)
                        {
                            MessageBox.Show("El rol del usuario o los permisos del rol estan inactivos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Application.Exit();
                        }
                        Usuarios.Permisos = permisos;
                        Usuarios.Id =Convert.ToInt32(res[0]);
                        Usuarios.NombreUsuario = txt_usuario.Text.Trim();
                        Usuarios.Nombre = Convert.ToString(res[4]);
                        Usuarios.Contraseña = txt_contraseña.Text.Trim();
                        Usuarios.Rol =Convert.ToInt32(res[1]);
                        Usuarios.Email = Convert.ToString(res[3]);
                    }
                    
                    else
                    {
                        MessageBox.Show("Usuario inactivo", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Application.Exit();
                    }

                    this.Close();
                }
                else
                {
                    MessageBox.Show("Nombre de usuario ó contraseña incorrecto", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (contador >= 3)
                    {
                        MessageBox.Show("Demasiados intentos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        Application.Exit();
                    }

                    contador++;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FrmSesion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F12)
            {
                txt_contraseña.UseSystemPasswordChar = false;
            }
        }

        private void FrmSesion_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F12)
            {
                txt_contraseña.UseSystemPasswordChar = true;
            }
        }
    }
}
