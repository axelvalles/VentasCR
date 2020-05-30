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
    public partial class frm_domicilios : Form
    {
        D_domicilios domicilios = new D_domicilios();

        public frm_domicilios()
        {
            InitializeComponent();
        }

        private void frm_domicilios_Load(object sender, EventArgs e)
        {
            dtg_domicilios.DataSource = domicilios.Consultar();
        }
        private void btn_crear_Click(object sender, EventArgs e)
        {
            sub_frm.modal_domicilios modal = new sub_frm.modal_domicilios();
            modal.ShowDialog();
            dtg_domicilios.DataSource = domicilios.Consultar();
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            int? id = getId();
            if (id != null)
            {
                sub_frm.modal_eliminar modal = new sub_frm.modal_eliminar(3,id);
                modal.ShowDialog();
                dtg_domicilios.DataSource = domicilios.Consultar();
            }
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            int? id = getId();
            if (id != null)
            {
                sub_frm.modal_domicilios modal = new sub_frm.modal_domicilios(id);
                modal.ShowDialog();
                dtg_domicilios.DataSource = domicilios.Consultar();
            }
        }
        private int? getId()
        {
            try
            {
                return int.Parse(
                    dtg_domicilios.Rows[dtg_domicilios.CurrentRow.Index].Cells[0].Value.ToString());
            }
            catch
            {
                return null;
                throw;
            }
        }

        
    }
}
