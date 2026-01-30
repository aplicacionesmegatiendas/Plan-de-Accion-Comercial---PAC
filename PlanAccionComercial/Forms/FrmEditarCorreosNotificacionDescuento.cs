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
    public partial class FrmEditarCorreosNotificacionDescuento : Form
    {
        int id;
        string email;
        bool activo;
        public FrmEditarCorreosNotificacionDescuento(int id, string email, bool activo)
        {
            InitializeComponent();
            this.id = id;
            this.email = email;
            this.activo = activo;
        }

        private void FrmEditarCorreosNotificacionDescuento_Load(object sender, EventArgs e)
        {
            try
            {
                Icon = Properties.Resources.plan_24;
                txt_correo.Text = email;
                chk_activo.Checked = activo;
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
            if (!Regex.IsMatch(txt_correo.Text.Trim(), @"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.IgnoreCase))
            {
                MessageBox.Show("El correo no es valido", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_correo.Focus();
                txt_correo.SelectAll();
                return;
            }
            try
            {
                Usuarios usuario = new Usuarios();
                usuario.EditarCorreoNotificacionDescuento(id, txt_correo.Text.Trim(), chk_activo.Checked);
                MessageBox.Show("Correo guardado correctamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("¿Confirma eliminar este correo?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.Yes))
                {
                    Usuarios usuarios = new Usuarios();
                    usuarios.EliminarCorreoNotificacionDescuento(id);
                    MessageBox.Show("Correo eliminado correctamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
