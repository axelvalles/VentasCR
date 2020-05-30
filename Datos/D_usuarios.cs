using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Npgsql;

namespace Datos
{
    public class D_usuarios
    {
        static string conexionString = "server=localhost; user id=postgres; password=1234; database=ventas";

        NpgsqlConnection con = new NpgsqlConnection(conexionString);

        public int consultaLogin (string usuario, string contra)
        {
            con.Open();
            int count;
            string query = "select count(*) from usuarios where usuario='" + usuario + "' and pass='" + contra + "'";
            NpgsqlCommand comando = new NpgsqlCommand(query,con);
            count = Convert.ToInt32(comando.ExecuteScalar());
            con.Close();

            return count; 
        }

        public DataTable Consultar()
        {
            string query = "select * from usuarios";
            NpgsqlCommand cmd = new NpgsqlCommand(query, con);
            NpgsqlDataAdapter datos = new NpgsqlDataAdapter(cmd);
            DataTable tabla = new DataTable();
            datos.Fill(tabla);
            return tabla;
        }

        public DataTable Consultarxid(int id)
        {
            string query = "select * from usuarios where id_usuario=" + id + "";
            NpgsqlCommand cmd = new NpgsqlCommand(query, con);
            NpgsqlDataAdapter datos = new NpgsqlDataAdapter(cmd);
            DataTable tabla = new DataTable();
            datos.Fill(tabla);
            return tabla;
        }

        public DataTable Insertar(string nombre, string usuario, string pass, string rol)
        {
            string query = "insert into usuarios(nombre,usuario,pass,rol) " +
                "values ('" + nombre + "','" + usuario + "','" + pass + "','" + rol + "')";
            NpgsqlCommand cmd = new NpgsqlCommand(query, con);
            NpgsqlDataAdapter datos = new NpgsqlDataAdapter(cmd);
            DataTable tabla = new DataTable();
            datos.Fill(tabla);
            return tabla;
        }

        public void Eliminar(int id)
        {
            string query = "delete from usuarios where id_usuario=" + id + "";

            NpgsqlCommand cmd = new NpgsqlCommand(query, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void Editar(int id, string nombre, string usuario, string pass, string rol)
        {
            string query = "update usuarios set nombre='" + nombre + "',usuario='" + usuario + "',pass='" + pass + "',rol='" + rol + "' where id_usuario=" + id + "";

            NpgsqlCommand cdm = new NpgsqlCommand(query, con);
            con.Open();
            cdm.ExecuteNonQuery();
            con.Close();
        }
    }
}
