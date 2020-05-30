using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using System.Data;


namespace Negocios
{
    public class N_clientes
    {
        D_clientes clientes = new D_clientes();

        public DataTable Consultaclientes()
        {
            return clientes.Consultar();
        }




    }
}
