using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Datos;

namespace Presentacion.sub_frm
{
    public partial class modal_cliente : Form
    {
        D_clientes clientes = new D_clientes();

        private int? id;
        public modal_cliente(int? id=null)
        {
            InitializeComponent();
            this.id = id;
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {

                string nombre = txt_nombre.Text.Trim();
                string nid = txt_nid.Text.Trim();
                string tlf = txt_tlf.Text.Trim();
                string direc1 = txt_direc1.Text.Trim();
                string direc2 = txt_direc2.Text.Trim();


            if (nombre == "" || tlf == "" || direc1 == "")
                {

                
                sub_frm.modal_login modal = new sub_frm.modal_login();
                modal.ShowDialog();
            }
            else
            {
                if (direc2 == "")
                {
                    direc2 = "no posee";
                }
                if (nid == "")
                {
                    nid = "no posee";
                }


                if (id == null)
                {
                    clientes.Insertar(nombre, nid, tlf, direc1, direc2);
                    int? x = 2;
                    sub_frm.modal_login modal = new sub_frm.modal_login(x);
                    modal.ShowDialog();        
                    this.Close();
                }
                else
                {
                    clientes.Editar((int)id, nombre, nid, tlf, direc1, direc2);
                    int? x = 2;
                    sub_frm.modal_login modal = new sub_frm.modal_login(x);
                    modal.ShowDialog();
                    this.Close();
                }
            }
           
            
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            
            this.Close();
        }

        private void modal_cliente_Load(object sender, EventArgs e)
        {
            if (id!=null)
            {
               DataTable tabla = new DataTable();
               tabla = clientes.Consultarxid((int)id);
               string nom =tabla.Rows[0]["nombre"].ToString();
               string dni = tabla.Rows[0]["dni"].ToString();
               string tlf = tabla.Rows[0]["tlf"].ToString();
               string direccion1 = tabla.Rows[0]["direccion1"].ToString();
               string direccion2 = tabla.Rows[0]["direccion2"].ToString();

                txt_nombre.Text = nom;
                txt_nid.Text = dni;
                txt_tlf.Text = tlf;
                txt_direc1.Text = direccion1;
                txt_direc2.Text = direccion2;
            }
        }
    }
}
