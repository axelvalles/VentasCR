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
    public partial class frm_usuarios : Form
    {
        D_usuarios usuarios = new D_usuarios();
        public frm_usuarios()
        {
            InitializeComponent();
        }

        private void frm_usuarios_Load(object sender, EventArgs e)
        {
            dtg_usuarios.DataSource = usuarios.Consultar();
        }

        private void btn_crear_Click(object sender, EventArgs e)
        {
            sub_frm.modal_usuarios modal = new sub_frm.modal_usuarios();
            modal.ShowDialog();
            dtg_usuarios.DataSource = usuarios.Consultar();
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            int? id = getId();
            if (id != null)
            {
                sub_frm.modal_eliminar modal = new sub_frm.modal_eliminar(4, id);
                modal.ShowDialog();
                dtg_usuarios.DataSource = usuarios.Consultar();
            }
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            int? id = getId();
            if (id != null)
            {
                sub_frm.modal_usuarios modal = new sub_frm.modal_usuarios(id);
                modal.ShowDialog();
                dtg_usuarios.DataSource = usuarios.Consultar();
            }
        }

        private int? getId()
        {
            try
            {
                return int.Parse(
                    dtg_usuarios.Rows[dtg_usuarios.CurrentRow.Index].Cells[0].Value.ToString());
            }
            catch
            {
                return null;
                throw;
            }
        }
    }
}
