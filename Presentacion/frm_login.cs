using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Datos;
namespace Presentacion
{
    public partial class frm_login : Form
    {
        D_usuarios con = new D_usuarios();
        public frm_login()
        {
            InitializeComponent();
        }

        private void btn_ingresar_Click(object sender, EventArgs e)
        {
            frm_Main frm_main = new frm_Main();
            
            if (con.consultaLogin(txt_usuario.Text, txt_contra.Text) == 1)
                {
                
                this.Hide();
                frm_main.Show();
                }
                else
                {
                    int? x = 1;
                    sub_frm.modal_login modal = new sub_frm.modal_login(x);
                     modal.ShowDialog();
                }
            
            

        }

        private void txt_usuario_Enter(object sender, EventArgs e)
        {
            txt_usuario.Text = "";
            txt_usuario.ForeColor = Color.FromArgb(82, 82, 82);
        }

        private void txt_usuario_Leave(object sender, EventArgs e)
        {
            if (txt_usuario.Text == "")
            {
                txt_usuario.Text = "Usuario";
                txt_usuario.ForeColor = Color.FromArgb(200, 200, 200);
            }
        }

        private void txt_contra_Enter(object sender, EventArgs e)
        {
            txt_contra.UseSystemPasswordChar = true;
            txt_contra.Text = "";
            txt_contra.ForeColor = Color.FromArgb(82, 82, 82);
        }

        private void txt_contra_Leave(object sender, EventArgs e)
        {
            if (txt_contra.Text=="")
            {
                txt_contra.UseSystemPasswordChar = false;
                txt_contra.Text = "Contraseña";
                txt_contra.ForeColor = Color.FromArgb(200, 200, 200);
            }
           
        }

        private void btn_cerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_minimizar_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
    }
}
