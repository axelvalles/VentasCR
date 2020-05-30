using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Negocios
{
    public class N_conexion
    {
        D_usuarios cn = new D_usuarios();

        public int consql(string usuario,string contra)
        {
            return cn.consultaLogin(usuario, contra);
        }

    }
}
