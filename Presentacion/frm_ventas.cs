using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Datos;
namespace Presentacion
{
    public partial class frm_ventas : Form
    {
        D_clientes clientes = new D_clientes();
        DataTable tabla = new DataTable();

        public frm_ventas()
        {
            InitializeComponent();

        }

        private void frm_ventas_Load(object sender, EventArgs e)
        {

        }

        private void cbox_buscar1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string x = cbox_buscar1.DisplayMember.ToString();
        }


        private void cbox_buscar2_Enter(object sender, EventArgs e)
        {
            tabla = clientes.Consultar();
            string cbox = cbox_buscar1.Text;
            label1.Text = cbox_buscar1.Text;

            if (cbox == "Telefono")
            {
                cbox = "tlf";
            }
            if (cbox == "Nombre")
            {
                cbox = "nombre";
            }
            if (cbox == "Direecion")
            {
                cbox = "direccion1";
            }



            AutoCompleteStringCollection coleccion = new AutoCompleteStringCollection();
            foreach (DataRow row in tabla.Rows)
            {
                coleccion.Add(Convert.ToString(row[cbox]));

            }
            cbox_buscar2.AutoCompleteCustomSource = coleccion;
            cbox_buscar2.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbox_buscar2.AutoCompleteSource = AutoCompleteSource.CustomSource;


        }



    }







        
    }

