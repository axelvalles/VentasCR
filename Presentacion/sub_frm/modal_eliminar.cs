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
    public partial class modal_eliminar : Form
    {
        D_clientes clientes = new D_clientes();
        D_domicilios domicilios = new D_domicilios();
        D_productos productos = new D_productos();
        D_usuarios usuarios = new D_usuarios();

        private int var;
        private int? id;
        
        public modal_eliminar(int var,int? id=null )
        {
            InitializeComponent();
            this.id = id;
            this.var = var;
        }


        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            if (var==1)
            {
                clientes.Eliminar((int)id);
                this.Close();
            }
            if (var == 2)
            {
                productos.Eliminar((int)id);
                this.Close();
            }
            if (var == 3)
            {
                domicilios.Eliminar((int)id);
                this.Close();
            }

            if (var == 4)
            {
                usuarios.Eliminar((int)id);
                this.Close();
            }
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
