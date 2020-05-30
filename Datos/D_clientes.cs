using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using System.Data;

namespace Datos
{
    public class D_clientes
    {
        static string conexionString = "server=localhost; user id=postgres; password=1234; database=ventas";

        NpgsqlConnection con = new NpgsqlConnection(conexionString);

        public DataTable Consultar()
        {
            string query = "select * from clientes";
            NpgsqlCommand cmd = new NpgsqlCommand(query, con);
            NpgsqlDataAdapter datos = new NpgsqlDataAdapter(cmd);
            DataTable tabla = new DataTable();
            datos.Fill(tabla);
            return tabla;
        }

        public DataTable Consultarxid(int id)
        {
            string query = "select * from clientes where id_cliente="+id+"";
            NpgsqlCommand cmd = new NpgsqlCommand(query, con);
            NpgsqlDataAdapter datos = new NpgsqlDataAdapter(cmd);
            DataTable tabla = new DataTable();
            datos.Fill(tabla);
            return tabla;
        }

        public void Insertar(string nombre, string nid, string tlf, string direccion1,
            string direccion2)
        {
            string query = "insert into clientes (nombre,dni,tlf,direccion1,direccion2)" +
                "values('" + nombre + "', '" + nid + "', '" + tlf + "', '" + direccion1 + "', '" + direccion2 + "')";

            NpgsqlCommand cdm = new NpgsqlCommand(query, con);
            con.Open();
            cdm.ExecuteNonQuery();
            con.Close();
        }

        public void Eliminar(int id)
        {
            string query = "delete from clientes where id_cliente="+id+"";

            NpgsqlCommand cmd = new NpgsqlCommand(query, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void Editar(int id, string nombre, string nid, string tlf, string direccion1,
            string direccion2)
        {
            string query = "update clientes set nombre='"+nombre+"',dni='"+nid+"',tlf='"+tlf+"',direccion1='"+direccion1+"',direccion2='"+direccion2+"' where id_cliente="+id+"";

            NpgsqlCommand cdm = new NpgsqlCommand(query, con);
            con.Open();
            cdm.ExecuteNonQuery();
            con.Close();
        }

        public DataTable Combox()
        {
            string query = "select id_cliente, nombre, tlf from clientes";
            NpgsqlCommand cmd = new NpgsqlCommand(query, con);
            NpgsqlDataAdapter datos = new NpgsqlDataAdapter(cmd);
            DataTable tabla = new DataTable();
            datos.Fill(tabla);
            return tabla;

        }

     

    }
}
