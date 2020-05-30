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
    public partial class frm_clientes : Form
    {
        D_clientes clientes = new D_clientes();

        public frm_clientes()
        {
            InitializeComponent();
        }

        private void frm_clientes_Load(object sender, EventArgs e)
        {

            dtg_clientes.DataSource = clientes.Consultar();

        }

        private void btn_crear_Click(object sender, EventArgs e)
        {
            sub_frm.modal_cliente modal = new sub_frm.modal_cliente();
            modal.ShowDialog();
            dtg_clientes.DataSource = clientes.Consultar();
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            int? id = getId();
            if (id!=null)
            {
                sub_frm.modal_cliente modal = new sub_frm.modal_cliente(id);
                modal.ShowDialog();
                dtg_clientes.DataSource = clientes.Consultar();
            }
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            int? id = getId();
            if (id != null)
            {
                sub_frm.modal_eliminar modal = new sub_frm.modal_eliminar(1,id);
                modal.ShowDialog();
                dtg_clientes.DataSource = clientes.Consultar();
            }
        }

        private int? getId()
        {
            try
            {
                return int.Parse(
                    dtg_clientes.Rows[dtg_clientes.CurrentRow.Index].Cells[0].Value.ToString());
            }
            catch
            {
                return null;
                throw;
            }
        }

       
    }
}
