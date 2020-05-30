using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Presentacion
{
    public partial class frm_Main : Form
    {
        public frm_Main()
        {
            InitializeComponent();
        }

        //Funcionalidades del from
        private void btn_cerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_maximizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            btn_maximizar.Visible = false;
            btn_restaurar.Visible = true;
        }

        private void btn_restaurar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            btn_restaurar.Visible = false;
            btn_maximizar.Visible = true;
        }

        private void btn_minimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        
        private void barra_titulo_MouseMove(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        //Fin

        //Botones y formularios

        private void  AbrirFormularios<frm>() where frm : Form, new()
        {
            Form formulario;
            formulario = panel_contenedor.Controls.OfType<frm>().FirstOrDefault();//buscar formularios

            if (formulario==null)
            {
                formulario = new frm();
                formulario.TopLevel = false;
                formulario.FormBorderStyle = FormBorderStyle.None;
                formulario.Dock = DockStyle.Fill;
                panel_contenedor.Controls.Add(formulario);
                panel_contenedor.Tag = formulario;
                formulario.Show();
                formulario.BringToFront();
            }
            else
            {
                formulario.BringToFront();
            }
        }

        private void btn_clientes_Click(object sender, EventArgs e)
        {
            AbrirFormularios<frm_clientes>();
        }

        private void btn_productos_Click(object sender, EventArgs e)
        {
            AbrirFormularios<frm_productos>();
        }

        private void btn_domicilios_Click(object sender, EventArgs e)
        {
            AbrirFormularios<frm_domicilios>();
        }

        private void btn_empleados_Click(object sender, EventArgs e)
        {
            AbrirFormularios<frm_usuarios>();
        }

        private void btn_ventas_Click(object sender, EventArgs e)
        {
            AbrirFormularios<frm_ventas>();
        }
    }
}
