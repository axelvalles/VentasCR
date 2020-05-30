using Datos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion.sub_frm
{
    public partial class modal_login : Form
    {
        private int? x;
        public modal_login(int? x=null)
        {
            InitializeComponent();
            this.x = x;
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            modal_login modal = new modal_login();
            this.Close();
        }

        private void modal_login_Load(object sender, EventArgs e)
        {
            if (x==1)
            {
                lbl_validacion.Text = "Usuario o Contraseña";
                lbl_validacion2.Text = "Invalida";
            }
            else
            {
                lbl_validacion.Text = "Rellene los campos";
                lbl_validacion2.Text = "obligatorios";
            }

            if (x==2)
            {
                lbl_validacion.Text = "Operacion Exitosa";
                lbl_validacion2.Text = "";
                panel.BackColor= Color.FromArgb(92, 184, 92);
            }

            if (x == 3)
            {
                lbl_validacion.Text = "Verifique las ";
                lbl_validacion2.Text = "contraseñas";
                
            }
        }
    }
}
