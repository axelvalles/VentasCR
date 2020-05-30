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
    public partial class modal_usuarios : Form
    {
        D_usuarios usuarios = new D_usuarios();
        private int? id;
        public modal_usuarios(int? id=null)
        {
            InitializeComponent();
            this.id = id;
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            string nombre = txt_nombre.Text.Trim();
            string usuario = txt_usuario.Text.Trim();
            string pass = txt_pass.Text.Trim();
            string confir_pass = txt_confir_pass.Text.Trim();
            string rol;

            if (cb_admin.Checked ==false && cb_vendedor.Checked==false)
            {
                sub_frm.modal_login modal = new sub_frm.modal_login();
                modal.ShowDialog();
            }
            else
            {
                if (pass != confir_pass )
                {
                    int? x = 3;
                    sub_frm.modal_login modal = new sub_frm.modal_login(x);
                    modal.ShowDialog();
                }
                else
                {
                    if (cb_admin.Checked == true)
                    {
                        rol = "Admin";
                    }
                    else
                    {
                        rol = "Vendedor";
                    }

                    if (nombre == "" || usuario == "" || pass == "" || confir_pass == "")
                    {
                        sub_frm.modal_login modal = new sub_frm.modal_login();
                        modal.ShowDialog();
                    }
                    else
                    {
                        if (id == null)
                        {
                            usuarios.Insertar(nombre, usuario, pass, rol);
                            int? x = 2;
                            sub_frm.modal_login modal = new sub_frm.modal_login(x);
                            modal.ShowDialog();
                            this.Close();
                        }
                        else
                        {
                            usuarios.Editar((int)id, nombre, usuario, pass, rol);
                            int? x = 2;
                            sub_frm.modal_login modal = new sub_frm.modal_login(x);
                            modal.ShowDialog();
                            this.Close();
                        }
                    }
                }
               
            }


            

        }

        private void cb_admin_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_admin.Checked==true)
            {
                cb_vendedor.Checked = false;
            }
            
        }

        private void cb_vendedor_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_vendedor.Checked==true)
            {
                cb_admin.Checked = false;
            }
            
        }

        private void modal_usuarios_Load(object sender, EventArgs e)
        {
            if (id != null)
            {
                DataTable tabla = new DataTable();
                tabla = usuarios.Consultarxid((int)id);
                string nom = tabla.Rows[0]["nombre"].ToString();
                string usuario = tabla.Rows[0]["usuario"].ToString();
                string pass = tabla.Rows[0]["pass"].ToString();
                string rol = tabla.Rows[0]["rol"].ToString();


                txt_nombre.Text = nom;
                txt_usuario.Text = usuario;
                txt_pass.Text = pass;
                txt_confir_pass.Text = pass;

                if (rol=="Admin")
                {
                    cb_admin.Checked = true;
                }
                else
                {
                    cb_vendedor.Checked = true;
                }
            }
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
