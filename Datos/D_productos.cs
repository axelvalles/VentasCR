using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Datos
{
    public class D_productos
    {
        static string conexionString = "server=localhost; user id=postgres; password=1234; database=ventas";

        NpgsqlConnection con = new NpgsqlConnection(conexionString);

        public DataTable Consultar()
        {
            string query = "select * from productos";
            NpgsqlCommand cmd = new NpgsqlCommand(query, con);
            NpgsqlDataAdapter datos = new NpgsqlDataAdapter(cmd);
            DataTable tabla = new DataTable();
            datos.Fill(tabla);
            return tabla;
        }

        public DataTable Consultarxid(int id)
        {
            string query = "select * from productos where id_producto=" + id + "";
            NpgsqlCommand cmd = new NpgsqlCommand(query, con);
            NpgsqlDataAdapter datos = new NpgsqlDataAdapter(cmd);
            DataTable tabla = new DataTable();
            datos.Fill(tabla);
            return tabla;
        }

        public DataTable Insertar(string nombre,int precio)
        {
            string query = "insert into productos(nombre,precio) " +
                "values ('" + nombre + "'," + precio + ")";
            NpgsqlCommand cmd = new NpgsqlCommand(query,con);
            NpgsqlDataAdapter datos = new NpgsqlDataAdapter(cmd);
            DataTable tabla = new DataTable();
            datos.Fill(tabla);
            return tabla;
        }

        public void Eliminar(int id)
        {
            string query = "delete from productos where id_producto=" + id + "";

            NpgsqlCommand cmd = new NpgsqlCommand(query, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void Editar(int id, string nombre, int precio)
        {
            string query = "update productos set nombre='" + nombre + "',precio=" + precio + " where id_producto=" + id + "";
            
            NpgsqlCommand cdm = new NpgsqlCommand(query, con);
            con.Open();
            cdm.ExecuteNonQuery();
            con.Close();
        }
    }
}
