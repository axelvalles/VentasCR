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

namespace Presentacion
{
    public partial class frm_productos : Form
    {
        D_productos productos = new D_productos();
        public frm_productos()
        {
            InitializeComponent();
        }

        private void frm_productos_Load(object sender, EventArgs e)
        {
            dtg_productos.DataSource = productos.Consultar();
        }
        private void btn_buscar_Click(object sender, EventArgs e)
        {

        }

        private void btn_crear_Click(object sender, EventArgs e)
        {
            sub_frm.modal_producto modal = new sub_frm.modal_producto();
            modal.ShowDialog();
            dtg_productos.DataSource = productos.Consultar();
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            int? id = getId();
            if (id != null)
            {
                sub_frm.modal_producto modal = new sub_frm.modal_producto(id);
                modal.ShowDialog();
                dtg_productos.DataSource = productos.Consultar();
            }
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            int? id = getId();
            if (id != null)
            {
                sub_frm.modal_eliminar modal = new sub_frm.modal_eliminar(2,id);
                modal.ShowDialog();
                dtg_productos.DataSource = productos.Consultar();
            }
        }
        private int? getId()
        {
            try
            {
                return int.Parse(
                    dtg_productos.Rows[dtg_productos.CurrentRow.Index].Cells[0].Value.ToString());
            }
            catch
            {
                return null;
                throw;
            }
        }

        
    }
}
