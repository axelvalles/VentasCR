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
    public partial class modal_producto : Form
    {
        private int? id;
        D_productos productos = new D_productos();
        public modal_producto(int? id = null)
        {
            InitializeComponent();
            this.id = id;
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {

            string nombre = txt_nombre.Text.Trim();
            decimal precio = txt_precio.Value;
            
            if (nombre == "" || precio <= 0)
            {
                sub_frm.modal_login modal = new sub_frm.modal_login();
                modal.ShowDialog();
            }
            else
            {

                if (id == null)
                {
                    productos.Insertar(nombre, (int)precio);
                    int? x = 2;
                    sub_frm.modal_login modal = new sub_frm.modal_login(x);
                    modal.ShowDialog();
                    this.Close();
                }
                else
                {
                    productos.Editar((int)id, nombre, (int)precio);
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

        private void modal_producto_Load(object sender, EventArgs e)
        {
            if (id != null)
            {
                DataTable tabla = new DataTable();
                tabla = productos.Consultarxid((int)id);
                string nom = tabla.Rows[0]["nombre"].ToString();
                string precio = tabla.Rows[0]["precio"].ToString();


                txt_nombre.Text = nom;
                txt_precio.Value = decimal.Parse(precio);

            }
        }
    }
}
