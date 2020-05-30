using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace Datos
{
    public class D_domicilios
    {

        static string conexionString = "server=localhost; user id=postgres; password=1234; database=ventas";

        NpgsqlConnection con = new NpgsqlConnection(conexionString);

        public DataTable Consultar()
        {
            string query = "select * from domicilios";
            NpgsqlCommand cmd = new NpgsqlCommand(query,con);
            NpgsqlDataAdapter data = new NpgsqlDataAdapter(cmd);
            DataTable tabla = new DataTable();
            data.Fill(tabla);
            return tabla;
        }

        public DataTable Consultarxid(int id)
        {
            string query = "select * from domicilios where id_domicilio=" + id + "";
            NpgsqlCommand cmd = new NpgsqlCommand(query, con);
            NpgsqlDataAdapter datos = new NpgsqlDataAdapter(cmd);
            DataTable tabla = new DataTable();
            datos.Fill(tabla);
            return tabla;
        }

        public DataTable Insertar(string zona, int precio)
        {
            string query = "insert into domicilios(zona,precio) " +
                "values ('" + zona + "'," + precio + ")";
            NpgsqlCommand cmd = new NpgsqlCommand(query, con);
            NpgsqlDataAdapter datos = new NpgsqlDataAdapter(cmd);
            DataTable tabla = new DataTable();
            datos.Fill(tabla);
            return tabla;
        }

        public void Eliminar(int id)
        {
            string query = "delete from domicilios where id_domicilio=" + id + "";

            NpgsqlCommand cmd = new NpgsqlCommand(query, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void Editar(int id, string zona, int precio)
        {
            string query = "update domicilios set zona='" + zona + "',precio=" + precio + " where id_domicilio=" + id + "";

            NpgsqlCommand cdm = new NpgsqlCommand(query, con);
            con.Open();
            cdm.ExecuteNonQuery();
            con.Close();
        }
    }
}
